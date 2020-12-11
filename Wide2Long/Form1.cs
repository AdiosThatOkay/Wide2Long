using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.UserModel; // Excel 97-2003 formats (.xls) 
using NPOI.XSSF.UserModel; // Excel 2007+ formats (.xlsx)

namespace Wide2Long
{
    public partial class Form1 : Form
    {
        private IWorkbook srcWorkbook;
        private int sheetIndex;

        public Form1()
        {
            InitializeComponent();
            LB_SheetNum.Text = "";
        }

        private void btnOpenDialog_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            // ファイルを開くダイアログを表示
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                ofd.Filter = "Excel Books (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    TB_FilePath.Text = filePath;
                }
            }

            // 待機カーソルに変更
            Cursor.Current = Cursors.WaitCursor;

            // 各コントロールを初期化
            initializeControl();

            // Excelブックを読み込む
            // 排他ロックせずに読み取り専用で開く
            //var fs = new FileStream(TB_FilePath.Text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (var fs = File.OpenRead(TB_FilePath.Text))
            {
                this.srcWorkbook = WorkbookFactory.Create(fs);
                this.sheetIndex = 0;
            }

            // 最初のシートを取得して、情報をラベルに表示
            updateLabelSheetNum();
            updateLabelSheetName();

            // スキップボタンと列名読込ボタンを有効化
            btnSkip.Enabled = true;
            btnLoad.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                // バリデーション
                if (NUD_HeaderRow.Value < 1)
                {
                    MessageBox.Show("ヘッダ行を正しく指定してください。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 処理対象のシート取得
                ISheet sheet = this.srcWorkbook.GetSheetAt(this.sheetIndex);
                
                // ヘッダ行の項目読込
                var headerRow = sheet?.GetRow(decimal.ToInt32(NUD_HeaderRow.Value) - 1);

                // ヘッダ行の項目をListBoxに追加
                // Linqの遅延評価を終わらせるため最後にToArray()している
                headerRow.Select(column => column?.ToString())
                         .Select(item => LB_Columns.Items.Add(item))
                         .ToArray();

                // 開始行にヘッダ行の次の行をセット
                NUD_StartRow.Value = NUD_HeaderRow.Value + 1;
                // 終了行に最終行をセット
                // sheet.LastRowNumは最終行-1が返るため
                NUD_EndRow.Value = sheet.LastRowNum + 1;

                // 実行ボタンを有効化
                btnConvert.Enabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            int headerRow = decimal.ToInt32(NUD_HeaderRow.Value) - 1;
            int startRow = decimal.ToInt32(NUD_StartRow.Value) - 1;
            int endRow = decimal.ToInt32(NUD_EndRow.Value) - 1;

            if (headerRow < startRow && startRow <= endRow && headerRow >= 1)
            {
                if (LB_Columns.SelectedItems.Count < 2)
                {
                    MessageBox.Show("行に展開する列は2つ以上選択してください。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<ColObject> selectedItems = new List<ColObject>();
                List<ColObject> unselectedItems = new List<ColObject>();

                // LBで選択したものと選択しなかったものに分ける
                // 前提
                // ・選択しないもので始まり、選択しないものは連続している
                // ・選択したものは連続しており、選択したもので終わる
                // ・選択したもののあとに選択しないものが現れた場合、これらは処理の対象外とする
                for (int i = 0; i < LB_Columns.Items.Count; i++)
                {
                    if (LB_Columns.GetSelected(i))
                    {
                        // 最初の項目を選択した場合、拒否
                        if (i == 0)
                        {
                            MessageBox.Show($"{LB_Columns.Items[i].ToString()}は最初の項目のため行に展開できません。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        selectedItems.Add(new ColObject(i, LB_Columns.Items[i].ToString()));
                    }
                    else
                    {
                        // 最初のアイテムか、もしくは選択しないもののインデックスが連続しているか
                        // インデックスが連続していない場合、これ以降は処理しない
                        if (i == 0 || unselectedItems.Last().originalColumnNumber + 1 == i)
                        {
                            unselectedItems.Add(new ColObject(i, LB_Columns.Items[i].ToString()));
                        }
                        else
                        {
                            MessageBox.Show($"{selectedItems.Last().name} より後ろの列は無視します。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }

                // コンバート後のデータを記述するエクセルファイルを作成
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "converted.xlsx";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                sfd.Filter = "Excel Books (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // 待機カーソルに変更
                    Cursor.Current = Cursors.WaitCursor;
                    
                    // 処理対象のシートを取得
                    ISheet srcSheet = this.srcWorkbook.GetSheetAt(this.sheetIndex);

                    var dstBook = new XSSFWorkbook();
                    var dstSheet = dstBook.CreateSheet("converted");
                    using (var dstFs = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        int rowNum = 0;

                        // 1行目にもとのファイル名を出力
                        var row0 = dstSheet.CreateRow(rowNum);
                        var cell00 = row0.CreateCell(0);
                        cell00.SetCellValue("ファイル名");
                        var cell01 = row0.CreateCell(1);
                        cell01.SetCellValue(Path.GetFileName(TB_FilePath.Text));

                        rowNum++;

                        // 2行目にもとのシート名を出力
                        var row1 = dstSheet.CreateRow(rowNum);
                        var cell10 = row1.CreateCell(0);
                        cell10.SetCellValue("シート名");
                        var cell11 = row1.CreateCell(1);
                        cell11.SetCellValue(srcSheet.SheetName);

                        rowNum++;

                        // 3行目にヘッダを出力
                        var style = dstBook.CreateCellStyle();
                        style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                        var row2 = dstSheet.CreateRow(rowNum);
                        for (int i = 0; i < unselectedItems.Count; i++)
                        {
                            var cell2i = row2.CreateCell(i);
                            cell2i.SetCellValue(unselectedItems[i].name);
                            cell2i.CellStyle = style;
                        }

                        // 行に展開した列のヘッダ名（キーと値）
                        int lastCol2 = row2.LastCellNum;
                        var cell2k = row2.CreateCell(lastCol2);
                        cell2k.SetCellValue(TB_NewKeyName.Text);
                        cell2k.CellStyle = style;
                        var cell2v = row2.CreateCell(lastCol2 + 1);
                        cell2v.SetCellValue(TB_NewValueName.Text);
                        cell2v.CellStyle = style;

                        rowNum++;

                        // 4行目以降を出力
                        for (int sr = startRow; sr < endRow + 1; sr++)
                        {
                            var srcRow = srcSheet.GetRow(sr);

                            // srcRowがnullの場合無視して次の行へ
                            if (srcRow == null)
                            {
                                continue;
                            }
                            // srcRowがすべて空欄の場合も無視して次の行へ
                            else if (srcRow.Cells.All(c => c.CellType == CellType.Blank))
                            {
                                continue;
                            }

                            for (int dr = 0; dr < selectedItems.Count; dr++)
                            {
                                var dstRow = dstSheet.CreateRow(rowNum);
                                
                                // 行に展開しない部分のデータをコピー
                                for (int c = 0; c < unselectedItems.Count; c++)
                                {
                                    var srcCell = srcRow.GetCell(unselectedItems[c].originalColumnNumber);
                                    var dstCell = dstRow.CreateCell(c);
                                    switch (srcCell.CellType)
                                    {
                                        case CellType.String:
                                            dstCell.SetCellValue(srcCell.ToString());
                                            break;
                                        case CellType.Numeric:
                                            if (DateUtil.IsCellDateFormatted(srcCell))
                                            {
                                                dstCell.SetCellValue(srcCell.DateCellValue);
                                            }
                                            else
                                            {
                                                dstCell.SetCellValue(srcCell.NumericCellValue);
                                            }
                                            break;
                                        case CellType.Boolean:
                                            dstCell.SetCellValue(srcCell.BooleanCellValue);
                                            break;
                                        default:
                                            dstCell.SetCellValue(srcCell.ToString());
                                            break;
                                    }
                                    // CellTypeをコピー
                                    dstCell.SetCellType(srcCell.CellType);

                                    // スタイルをコピー
                                    var srcCellStyle = srcCell.CellStyle;
                                    CellUtil.SetCellStyleProperty(dstCell, CellUtil.DATA_FORMAT, srcCellStyle.DataFormat);
                                }

                                // 行に展開する部分のデータをコピー
                                // キー
                                var dstLastColl = dstRow.LastCellNum;
                                var dstLastKeyCell = dstRow.CreateCell(dstLastColl);
                                dstLastKeyCell.SetCellValue(selectedItems[dr].name);

                                // 値
                                var srcValueCell = srcRow.GetCell(selectedItems[dr].originalColumnNumber);
                                var dstLastValueCell = dstRow.CreateCell(dstLastColl + 1);

                                // コピー元のCellType（文字列とか数値とか）による分類
                                switch (srcValueCell.CellType)
                                {
                                    // 文字列
                                    case CellType.String:
                                        dstLastValueCell.SetCellValue(srcValueCell.ToString());
                                        break;
                                    // 数値・通貨
                                    case CellType.Numeric:
                                        // 日付を含むことがある
                                        if (DateUtil.IsCellDateFormatted(srcValueCell))
                                        {
                                            dstLastValueCell.SetCellValue(srcValueCell.DateCellValue);
                                        }
                                        else
                                        {
                                            dstLastValueCell.SetCellValue(srcValueCell.NumericCellValue);
                                        }
                                        break;
                                    // 真偽値
                                    case CellType.Boolean:
                                        dstLastValueCell.SetCellValue(srcValueCell.BooleanCellValue);
                                        break;
                                    // そのほかは文字列型とみなす
                                    default:
                                        dstLastValueCell.SetCellValue(srcValueCell.ToString());
                                        break;

                                }

                                // CellTypeをコピー
                                dstLastValueCell.SetCellType(srcValueCell.CellType);

                                // スタイルをコピー
                                var srcValueStyle = srcValueCell.CellStyle;
                                CellUtil.SetCellStyleProperty(dstLastValueCell, CellUtil.DATA_FORMAT, srcValueStyle.DataFormat);

                                rowNum++;
                            }
                        }

                        // 保存
                        dstBook.Write(dstFs);
                        MessageBox.Show("処理が完了しました。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("開始行と終了行を正しく指定してください。", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void NUD_HeaderRow_Enter(object sender, EventArgs e)
        {
            NUD_HeaderRow.Select(0, int.MaxValue);
        }

        private void NUD_HeaderRow_Click(object sender, EventArgs e)
        {
            NUD_HeaderRow.Select(0, int.MaxValue);
        }

        private void NUD_StartRow_Click(object sender, EventArgs e)
        {
            NUD_StartRow.Select(0, int.MaxValue);
        }

        private void NUD_StartRow_Enter(object sender, EventArgs e)
        {
            NUD_StartRow.Select(0, int.MaxValue);
        }

        private void NUD_EndRow_Enter(object sender, EventArgs e)
        {
            NUD_EndRow.Select(0, int.MaxValue);
        }

        private void NUD_EndRow_Click(object sender, EventArgs e)
        {
            NUD_EndRow.Select(0, int.MaxValue);
        }

        private void initializeControl()
        {
            NUD_HeaderRow.Value = 1;
            LB_Columns.Items.Clear();
            TB_NewKeyName.Clear();
            TB_NewValueName.Clear();
            NUD_StartRow.Value = 1;
            NUD_EndRow.Value = 1;
            btnConvert.Enabled = false;
        }

        private void updateLabelSheetNum()
        {
            LB_SheetNum.Text = $"{srcWorkbook.NumberOfSheets}シート中{this.sheetIndex + 1}シート目";
        }

        private void updateLabelSheetName()
        {
            LB_SheetName.Text = $"{srcWorkbook.GetSheetName(this.sheetIndex)}";
        }
    }

    internal class ColObject
    {
        public int originalColumnNumber { get; set; }
        public string name { get; set; }
        public ColObject(int originalColumnNumber, string name)
        {
            this.originalColumnNumber = originalColumnNumber;
            this.name = name;
        }
    }

}
