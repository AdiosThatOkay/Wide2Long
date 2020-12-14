namespace Wide2Long
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TB_FilePath = new System.Windows.Forms.TextBox();
            this.btnOpenDialog = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.NUD_HeaderRow = new System.Windows.Forms.NumericUpDown();
            this.btnConvert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NUD_StartRow = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.NUD_EndRow = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_NewKeyName = new System.Windows.Forms.TextBox();
            this.LB_Columns = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TB_NewValueName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSkip = new System.Windows.Forms.Button();
            this.LB_SheetName = new System.Windows.Forms.Label();
            this.LB_SheetNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_HeaderRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StartRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_EndRow)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Excelファイルを指定";
            // 
            // TB_FilePath
            // 
            this.TB_FilePath.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_FilePath.Location = new System.Drawing.Point(150, 20);
            this.TB_FilePath.Name = "TB_FilePath";
            this.TB_FilePath.ReadOnly = true;
            this.TB_FilePath.Size = new System.Drawing.Size(230, 24);
            this.TB_FilePath.TabIndex = 1;
            this.TB_FilePath.TabStop = false;
            // 
            // btnOpenDialog
            // 
            this.btnOpenDialog.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOpenDialog.Location = new System.Drawing.Point(386, 17);
            this.btnOpenDialog.Name = "btnOpenDialog";
            this.btnOpenDialog.Size = new System.Drawing.Size(63, 29);
            this.btnOpenDialog.TabIndex = 2;
            this.btnOpenDialog.Text = "参照";
            this.btnOpenDialog.UseVisualStyleBackColor = true;
            this.btnOpenDialog.Click += new System.EventHandler(this.btnOpenDialog_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnLoad.Location = new System.Drawing.Point(171, 153);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(103, 29);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "列名読込";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnExit.Location = new System.Drawing.Point(345, 645);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(103, 29);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "終了";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(12, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "ヘッダ行";
            // 
            // NUD_HeaderRow
            // 
            this.NUD_HeaderRow.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NUD_HeaderRow.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NUD_HeaderRow.Location = new System.Drawing.Point(79, 153);
            this.NUD_HeaderRow.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.NUD_HeaderRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_HeaderRow.Name = "NUD_HeaderRow";
            this.NUD_HeaderRow.Size = new System.Drawing.Size(72, 27);
            this.NUD_HeaderRow.TabIndex = 4;
            this.NUD_HeaderRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_HeaderRow.Click += new System.EventHandler(this.NUD_HeaderRow_Click);
            this.NUD_HeaderRow.Enter += new System.EventHandler(this.NUD_HeaderRow_Enter);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnConvert.Location = new System.Drawing.Point(221, 645);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(103, 29);
            this.btnConvert.TabIndex = 11;
            this.btnConvert.Text = "実行";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(13, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "行に展開する列を選択";
            // 
            // NUD_StartRow
            // 
            this.NUD_StartRow.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NUD_StartRow.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NUD_StartRow.Location = new System.Drawing.Point(65, 610);
            this.NUD_StartRow.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.NUD_StartRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_StartRow.Name = "NUD_StartRow";
            this.NUD_StartRow.Size = new System.Drawing.Size(118, 27);
            this.NUD_StartRow.TabIndex = 9;
            this.NUD_StartRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_StartRow.Click += new System.EventHandler(this.NUD_StartRow_Click);
            this.NUD_StartRow.Enter += new System.EventHandler(this.NUD_StartRow_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(11, 612);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "開始行";
            // 
            // NUD_EndRow
            // 
            this.NUD_EndRow.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NUD_EndRow.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.NUD_EndRow.Location = new System.Drawing.Point(65, 647);
            this.NUD_EndRow.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.NUD_EndRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_EndRow.Name = "NUD_EndRow";
            this.NUD_EndRow.Size = new System.Drawing.Size(118, 27);
            this.NUD_EndRow.TabIndex = 10;
            this.NUD_EndRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_EndRow.Click += new System.EventHandler(this.NUD_EndRow_Click);
            this.NUD_EndRow.Enter += new System.EventHandler(this.NUD_EndRow_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(11, 649);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "終了行";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(11, 531);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "新しい列名";
            // 
            // TB_NewKeyName
            // 
            this.TB_NewKeyName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_NewKeyName.Location = new System.Drawing.Point(63, 558);
            this.TB_NewKeyName.Name = "TB_NewKeyName";
            this.TB_NewKeyName.Size = new System.Drawing.Size(120, 27);
            this.TB_NewKeyName.TabIndex = 7;
            // 
            // LB_Columns
            // 
            this.LB_Columns.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LB_Columns.FormattingEnabled = true;
            this.LB_Columns.ItemHeight = 18;
            this.LB_Columns.Location = new System.Drawing.Point(17, 220);
            this.LB_Columns.Name = "LB_Columns";
            this.LB_Columns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LB_Columns.Size = new System.Drawing.Size(434, 292);
            this.LB_Columns.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(201, 561);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "値";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(24, 561);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "キー";
            // 
            // TB_NewValueName
            // 
            this.TB_NewValueName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TB_NewValueName.Location = new System.Drawing.Point(229, 558);
            this.TB_NewValueName.Name = "TB_NewValueName";
            this.TB_NewValueName.Size = new System.Drawing.Size(120, 27);
            this.TB_NewValueName.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(12, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "処理対象のシート";
            // 
            // btnSkip
            // 
            this.btnSkip.Enabled = false;
            this.btnSkip.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSkip.Location = new System.Drawing.Point(302, 104);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(146, 29);
            this.btnSkip.TabIndex = 3;
            this.btnSkip.Text = "このシートをスキップ";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // LB_SheetName
            // 
            this.LB_SheetName.AutoSize = true;
            this.LB_SheetName.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LB_SheetName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LB_SheetName.Location = new System.Drawing.Point(24, 108);
            this.LB_SheetName.Name = "LB_SheetName";
            this.LB_SheetName.Size = new System.Drawing.Size(66, 20);
            this.LB_SheetName.TabIndex = 19;
            this.LB_SheetName.Text = "シート名:";
            // 
            // LB_SheetNum
            // 
            this.LB_SheetNum.AutoSize = true;
            this.LB_SheetNum.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LB_SheetNum.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LB_SheetNum.Location = new System.Drawing.Point(146, 79);
            this.LB_SheetNum.Name = "LB_SheetNum";
            this.LB_SheetNum.Size = new System.Drawing.Size(100, 20);
            this.LB_SheetNum.TabIndex = 20;
            this.LB_SheetNum.Text = "LB_SheetNum";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 695);
            this.Controls.Add(this.LB_SheetNum);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TB_NewValueName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LB_Columns);
            this.Controls.Add(this.TB_NewKeyName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NUD_EndRow);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NUD_StartRow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.NUD_HeaderRow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnOpenDialog);
            this.Controls.Add(this.TB_FilePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LB_SheetName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Wide2Long (Ver 0.4.1)";
            ((System.ComponentModel.ISupportInitialize)(this.NUD_HeaderRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_StartRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_EndRow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_FilePath;
        private System.Windows.Forms.Button btnOpenDialog;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown NUD_HeaderRow;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NUD_StartRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NUD_EndRow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_NewKeyName;
        private System.Windows.Forms.ListBox LB_Columns;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TB_NewValueName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Label LB_SheetName;
        private System.Windows.Forms.Label LB_SheetNum;
    }
}

