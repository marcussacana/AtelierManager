
namespace GustFontEditor
{
    partial class Main
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbGameInfo = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRetryOffsetFind = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.tbGlyphCount = new System.Windows.Forms.TextBox();
            this.lblGlyphCount = new System.Windows.Forms.Label();
            this.tbTableOffset = new System.Windows.Forms.TextBox();
            this.lblTableOffset = new System.Windows.Forms.Label();
            this.tbGame = new System.Windows.Forms.TextBox();
            this.lblGame = new System.Windows.Forms.Label();
            this.btnSelectTex = new System.Windows.Forms.Button();
            this.tbTexturePath = new System.Windows.Forms.TextBox();
            this.lblTexture = new System.Windows.Forms.Label();
            this.btnSelectExe = new System.Windows.Forms.Button();
            this.tbExePath = new System.Windows.Forms.TextBox();
            this.lblExecutable = new System.Windows.Forms.Label();
            this.pgRedraw = new System.Windows.Forms.TabControl();
            this.pgGlyphs = new System.Windows.Forms.TabPage();
            this.nudBottom = new System.Windows.Forms.NumericUpDown();
            this.nudRigth = new System.Windows.Forms.NumericUpDown();
            this.nudLeft = new System.Windows.Forms.NumericUpDown();
            this.nudTop = new System.Windows.Forms.NumericUpDown();
            this.lblPaddingRigth = new System.Windows.Forms.Label();
            this.lblPaddingLeft = new System.Windows.Forms.Label();
            this.lblPaddingBottom = new System.Windows.Forms.Label();
            this.lblPaddingTop = new System.Windows.Forms.Label();
            this.pnFont = new System.Windows.Forms.Panel();
            this.pbMainTexture = new System.Windows.Forms.PictureBox();
            this.tbChar = new System.Windows.Forms.TextBox();
            this.nudY = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudX = new System.Windows.Forms.NumericUpDown();
            this.btnSearchChar = new System.Windows.Forms.Button();
            this.tbSearchChar = new System.Windows.Forms.TextBox();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblChar = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.pbCharVeiwer = new System.Windows.Forms.PictureBox();
            this.tabRedraw = new System.Windows.Forms.TabPage();
            this.cbTrimming = new System.Windows.Forms.CheckBox();
            this.cbRemapEnabled = new System.Windows.Forms.CheckBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.tbPreview = new System.Windows.Forms.TextBox();
            this.lblPreview = new System.Windows.Forms.Label();
            this.tbSize = new System.Windows.Forms.TextBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblFont = new System.Windows.Forms.Label();
            this.tbFacename = new System.Windows.Forms.TextBox();
            this.tbRemap = new System.Windows.Forms.TextBox();
            this.lblRemapList = new System.Windows.Forms.Label();
            this.tbRedraw = new System.Windows.Forms.TextBox();
            this.lblRedrawList = new System.Windows.Forms.Label();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.tbImportantList = new System.Windows.Forms.TextBox();
            this.lblImportantList = new System.Windows.Forms.Label();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.btnSecret = new System.Windows.Forms.Button();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblToolTitle = new System.Windows.Forms.Label();
            this.wbEgg = new System.Windows.Forms.WebBrowser();
            this.fdOpenTexture = new System.Windows.Forms.OpenFileDialog();
            this.fdExecutable = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadLST = new System.Windows.Forms.Button();
            this.gbGameInfo.SuspendLayout();
            this.pgRedraw.SuspendLayout();
            this.pgGlyphs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRigth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).BeginInit();
            this.pnFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainTexture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharVeiwer)).BeginInit();
            this.tabRedraw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGameInfo
            // 
            this.gbGameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGameInfo.Controls.Add(this.btnExport);
            this.gbGameInfo.Controls.Add(this.btnRetryOffsetFind);
            this.gbGameInfo.Controls.Add(this.btnReload);
            this.gbGameInfo.Controls.Add(this.tbGlyphCount);
            this.gbGameInfo.Controls.Add(this.lblGlyphCount);
            this.gbGameInfo.Controls.Add(this.tbTableOffset);
            this.gbGameInfo.Controls.Add(this.lblTableOffset);
            this.gbGameInfo.Controls.Add(this.tbGame);
            this.gbGameInfo.Controls.Add(this.lblGame);
            this.gbGameInfo.Controls.Add(this.btnSelectTex);
            this.gbGameInfo.Controls.Add(this.tbTexturePath);
            this.gbGameInfo.Controls.Add(this.lblTexture);
            this.gbGameInfo.Controls.Add(this.btnSelectExe);
            this.gbGameInfo.Controls.Add(this.tbExePath);
            this.gbGameInfo.Controls.Add(this.lblExecutable);
            this.gbGameInfo.Location = new System.Drawing.Point(12, 339);
            this.gbGameInfo.Name = "gbGameInfo";
            this.gbGameInfo.Size = new System.Drawing.Size(820, 130);
            this.gbGameInfo.TabIndex = 0;
            this.gbGameInfo.TabStop = false;
            this.gbGameInfo.Text = "Game Info:";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(640, 97);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(84, 23);
            this.btnExport.TabIndex = 14;
            this.btnExport.Text = "Save Font";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnRetryOffsetFind
            // 
            this.btnRetryOffsetFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRetryOffsetFind.Location = new System.Drawing.Point(326, 97);
            this.btnRetryOffsetFind.Name = "btnRetryOffsetFind";
            this.btnRetryOffsetFind.Size = new System.Drawing.Size(56, 23);
            this.btnRetryOffsetFind.TabIndex = 13;
            this.btnRetryOffsetFind.Text = "Retry";
            this.btnRetryOffsetFind.UseVisualStyleBackColor = true;
            this.btnRetryOffsetFind.Click += new System.EventHandler(this.btnRetryOffsetFind_Click);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReload.Location = new System.Drawing.Point(730, 97);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(84, 23);
            this.btnReload.TabIndex = 12;
            this.btnReload.Text = "Load Font";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // tbGlyphCount
            // 
            this.tbGlyphCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGlyphCount.Location = new System.Drawing.Point(462, 99);
            this.tbGlyphCount.Name = "tbGlyphCount";
            this.tbGlyphCount.Size = new System.Drawing.Size(172, 20);
            this.tbGlyphCount.TabIndex = 11;
            // 
            // lblGlyphCount
            // 
            this.lblGlyphCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGlyphCount.AutoSize = true;
            this.lblGlyphCount.Location = new System.Drawing.Point(388, 102);
            this.lblGlyphCount.Name = "lblGlyphCount";
            this.lblGlyphCount.Size = new System.Drawing.Size(68, 13);
            this.lblGlyphCount.TabIndex = 10;
            this.lblGlyphCount.Text = "Glyph Count:";
            // 
            // tbTableOffset
            // 
            this.tbTableOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTableOffset.Location = new System.Drawing.Point(83, 99);
            this.tbTableOffset.Name = "tbTableOffset";
            this.tbTableOffset.Size = new System.Drawing.Size(237, 20);
            this.tbTableOffset.TabIndex = 9;
            // 
            // lblTableOffset
            // 
            this.lblTableOffset.AutoSize = true;
            this.lblTableOffset.Location = new System.Drawing.Point(9, 102);
            this.lblTableOffset.Name = "lblTableOffset";
            this.lblTableOffset.Size = new System.Drawing.Size(68, 13);
            this.lblTableOffset.TabIndex = 8;
            this.lblTableOffset.Text = "Table Offset:";
            // 
            // tbGame
            // 
            this.tbGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbGame.Location = new System.Drawing.Point(83, 71);
            this.tbGame.Name = "tbGame";
            this.tbGame.ReadOnly = true;
            this.tbGame.Size = new System.Drawing.Size(731, 20);
            this.tbGame.TabIndex = 7;
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Location = new System.Drawing.Point(31, 74);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(38, 13);
            this.lblGame.TabIndex = 6;
            this.lblGame.Text = "Game:";
            // 
            // btnSelectTex
            // 
            this.btnSelectTex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectTex.Location = new System.Drawing.Point(782, 43);
            this.btnSelectTex.Name = "btnSelectTex";
            this.btnSelectTex.Size = new System.Drawing.Size(32, 23);
            this.btnSelectTex.TabIndex = 5;
            this.btnSelectTex.Text = "...";
            this.btnSelectTex.UseVisualStyleBackColor = true;
            this.btnSelectTex.Click += new System.EventHandler(this.btnSelectTex_Click);
            // 
            // tbTexturePath
            // 
            this.tbTexturePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTexturePath.Location = new System.Drawing.Point(83, 45);
            this.tbTexturePath.Name = "tbTexturePath";
            this.tbTexturePath.ReadOnly = true;
            this.tbTexturePath.Size = new System.Drawing.Size(693, 20);
            this.tbTexturePath.TabIndex = 4;
            // 
            // lblTexture
            // 
            this.lblTexture.AutoSize = true;
            this.lblTexture.Location = new System.Drawing.Point(31, 48);
            this.lblTexture.Name = "lblTexture";
            this.lblTexture.Size = new System.Drawing.Size(46, 13);
            this.lblTexture.TabIndex = 3;
            this.lblTexture.Text = "Texture:";
            // 
            // btnSelectExe
            // 
            this.btnSelectExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectExe.Location = new System.Drawing.Point(782, 17);
            this.btnSelectExe.Name = "btnSelectExe";
            this.btnSelectExe.Size = new System.Drawing.Size(32, 23);
            this.btnSelectExe.TabIndex = 2;
            this.btnSelectExe.Text = "...";
            this.btnSelectExe.UseVisualStyleBackColor = true;
            this.btnSelectExe.Click += new System.EventHandler(this.btnSelectExe_Click);
            // 
            // tbExePath
            // 
            this.tbExePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbExePath.Location = new System.Drawing.Point(83, 19);
            this.tbExePath.Name = "tbExePath";
            this.tbExePath.ReadOnly = true;
            this.tbExePath.Size = new System.Drawing.Size(693, 20);
            this.tbExePath.TabIndex = 1;
            // 
            // lblExecutable
            // 
            this.lblExecutable.AutoSize = true;
            this.lblExecutable.Location = new System.Drawing.Point(14, 22);
            this.lblExecutable.Name = "lblExecutable";
            this.lblExecutable.Size = new System.Drawing.Size(63, 13);
            this.lblExecutable.TabIndex = 0;
            this.lblExecutable.Text = "Executable:";
            // 
            // pgRedraw
            // 
            this.pgRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgRedraw.Controls.Add(this.pgGlyphs);
            this.pgRedraw.Controls.Add(this.tabRedraw);
            this.pgRedraw.Controls.Add(this.tabAbout);
            this.pgRedraw.Location = new System.Drawing.Point(2, 2);
            this.pgRedraw.Name = "pgRedraw";
            this.pgRedraw.SelectedIndex = 0;
            this.pgRedraw.Size = new System.Drawing.Size(842, 331);
            this.pgRedraw.TabIndex = 1;
            // 
            // pgGlyphs
            // 
            this.pgGlyphs.Controls.Add(this.nudBottom);
            this.pgGlyphs.Controls.Add(this.nudRigth);
            this.pgGlyphs.Controls.Add(this.nudLeft);
            this.pgGlyphs.Controls.Add(this.nudTop);
            this.pgGlyphs.Controls.Add(this.lblPaddingRigth);
            this.pgGlyphs.Controls.Add(this.lblPaddingLeft);
            this.pgGlyphs.Controls.Add(this.lblPaddingBottom);
            this.pgGlyphs.Controls.Add(this.lblPaddingTop);
            this.pgGlyphs.Controls.Add(this.pnFont);
            this.pgGlyphs.Controls.Add(this.tbChar);
            this.pgGlyphs.Controls.Add(this.nudY);
            this.pgGlyphs.Controls.Add(this.nudHeight);
            this.pgGlyphs.Controls.Add(this.nudWidth);
            this.pgGlyphs.Controls.Add(this.nudX);
            this.pgGlyphs.Controls.Add(this.btnSearchChar);
            this.pgGlyphs.Controls.Add(this.tbSearchChar);
            this.pgGlyphs.Controls.Add(this.lblHeight);
            this.pgGlyphs.Controls.Add(this.lblWidth);
            this.pgGlyphs.Controls.Add(this.lblChar);
            this.pgGlyphs.Controls.Add(this.lblY);
            this.pgGlyphs.Controls.Add(this.lblX);
            this.pgGlyphs.Controls.Add(this.lblID);
            this.pgGlyphs.Controls.Add(this.pbCharVeiwer);
            this.pgGlyphs.Location = new System.Drawing.Point(4, 22);
            this.pgGlyphs.Name = "pgGlyphs";
            this.pgGlyphs.Padding = new System.Windows.Forms.Padding(3);
            this.pgGlyphs.Size = new System.Drawing.Size(834, 305);
            this.pgGlyphs.TabIndex = 0;
            this.pgGlyphs.Text = "Glyphs";
            this.pgGlyphs.UseVisualStyleBackColor = true;
            // 
            // nudBottom
            // 
            this.nudBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudBottom.Location = new System.Drawing.Point(751, 226);
            this.nudBottom.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBottom.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nudBottom.Name = "nudBottom";
            this.nudBottom.Size = new System.Drawing.Size(69, 20);
            this.nudBottom.TabIndex = 30;
            this.nudBottom.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudBottom.ValueChanged += new System.EventHandler(this.nudBottom_ValueChanged);
            // 
            // nudRigth
            // 
            this.nudRigth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRigth.Location = new System.Drawing.Point(751, 253);
            this.nudRigth.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudRigth.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nudRigth.Name = "nudRigth";
            this.nudRigth.Size = new System.Drawing.Size(69, 20);
            this.nudRigth.TabIndex = 29;
            this.nudRigth.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudRigth.ValueChanged += new System.EventHandler(this.nudRigth_ValueChanged);
            // 
            // nudLeft
            // 
            this.nudLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudLeft.Location = new System.Drawing.Point(634, 253);
            this.nudLeft.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudLeft.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nudLeft.Name = "nudLeft";
            this.nudLeft.Size = new System.Drawing.Size(67, 20);
            this.nudLeft.TabIndex = 28;
            this.nudLeft.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudLeft.ValueChanged += new System.EventHandler(this.nudLeft_ValueChanged);
            // 
            // nudTop
            // 
            this.nudTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTop.Location = new System.Drawing.Point(635, 226);
            this.nudTop.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTop.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.nudTop.Name = "nudTop";
            this.nudTop.Size = new System.Drawing.Size(66, 20);
            this.nudTop.TabIndex = 27;
            this.nudTop.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTop.ValueChanged += new System.EventHandler(this.nudTop_ValueChanged);
            // 
            // lblPaddingRigth
            // 
            this.lblPaddingRigth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaddingRigth.AutoSize = true;
            this.lblPaddingRigth.Location = new System.Drawing.Point(710, 255);
            this.lblPaddingRigth.Name = "lblPaddingRigth";
            this.lblPaddingRigth.Size = new System.Drawing.Size(35, 13);
            this.lblPaddingRigth.TabIndex = 26;
            this.lblPaddingRigth.Text = "Rigth:";
            // 
            // lblPaddingLeft
            // 
            this.lblPaddingLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaddingLeft.AutoSize = true;
            this.lblPaddingLeft.Location = new System.Drawing.Point(600, 255);
            this.lblPaddingLeft.Name = "lblPaddingLeft";
            this.lblPaddingLeft.Size = new System.Drawing.Size(28, 13);
            this.lblPaddingLeft.TabIndex = 25;
            this.lblPaddingLeft.Text = "Left:";
            // 
            // lblPaddingBottom
            // 
            this.lblPaddingBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaddingBottom.AutoSize = true;
            this.lblPaddingBottom.Location = new System.Drawing.Point(704, 228);
            this.lblPaddingBottom.Name = "lblPaddingBottom";
            this.lblPaddingBottom.Size = new System.Drawing.Size(43, 13);
            this.lblPaddingBottom.TabIndex = 24;
            this.lblPaddingBottom.Text = "Bottom:";
            // 
            // lblPaddingTop
            // 
            this.lblPaddingTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaddingTop.AutoSize = true;
            this.lblPaddingTop.Location = new System.Drawing.Point(600, 228);
            this.lblPaddingTop.Name = "lblPaddingTop";
            this.lblPaddingTop.Size = new System.Drawing.Size(29, 13);
            this.lblPaddingTop.TabIndex = 23;
            this.lblPaddingTop.Text = "Top:";
            // 
            // pnFont
            // 
            this.pnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFont.AutoScroll = true;
            this.pnFont.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pnFont.Controls.Add(this.pbMainTexture);
            this.pnFont.Location = new System.Drawing.Point(0, 0);
            this.pnFont.Name = "pnFont";
            this.pnFont.Size = new System.Drawing.Size(594, 305);
            this.pnFont.TabIndex = 0;
            // 
            // pbMainTexture
            // 
            this.pbMainTexture.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbMainTexture.Location = new System.Drawing.Point(0, 0);
            this.pbMainTexture.Name = "pbMainTexture";
            this.pbMainTexture.Size = new System.Drawing.Size(1, 1);
            this.pbMainTexture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbMainTexture.TabIndex = 0;
            this.pbMainTexture.TabStop = false;
            this.pbMainTexture.DoubleClick += new System.EventHandler(this.pbMainTexture_DoubleClick);
            // 
            // tbChar
            // 
            this.tbChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbChar.Location = new System.Drawing.Point(707, 147);
            this.tbChar.MaxLength = 1;
            this.tbChar.Name = "tbChar";
            this.tbChar.Size = new System.Drawing.Size(113, 20);
            this.tbChar.TabIndex = 14;
            this.tbChar.TextChanged += new System.EventHandler(this.tbChar_TextChanged);
            // 
            // nudY
            // 
            this.nudY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudY.Location = new System.Drawing.Point(721, 173);
            this.nudY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudY.Name = "nudY";
            this.nudY.Size = new System.Drawing.Size(99, 20);
            this.nudY.TabIndex = 13;
            this.nudY.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudY.ValueChanged += new System.EventHandler(this.nudY_ValueChanged);
            // 
            // nudHeight
            // 
            this.nudHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudHeight.Location = new System.Drawing.Point(745, 200);
            this.nudHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(75, 20);
            this.nudHeight.TabIndex = 12;
            this.nudHeight.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
            // 
            // nudWidth
            // 
            this.nudWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudWidth.Location = new System.Drawing.Point(637, 200);
            this.nudWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(55, 20);
            this.nudWidth.TabIndex = 11;
            this.nudWidth.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // nudX
            // 
            this.nudX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudX.Location = new System.Drawing.Point(623, 173);
            this.nudX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudX.Name = "nudX";
            this.nudX.Size = new System.Drawing.Size(69, 20);
            this.nudX.TabIndex = 10;
            this.nudX.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudX.ValueChanged += new System.EventHandler(this.nudX_ValueChanged);
            // 
            // btnSearchChar
            // 
            this.btnSearchChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchChar.Location = new System.Drawing.Point(751, 277);
            this.btnSearchChar.Name = "btnSearchChar";
            this.btnSearchChar.Size = new System.Drawing.Size(75, 23);
            this.btnSearchChar.TabIndex = 9;
            this.btnSearchChar.Text = "Search Char";
            this.btnSearchChar.UseVisualStyleBackColor = true;
            this.btnSearchChar.Click += new System.EventHandler(this.btnSearchChar_Click);
            // 
            // tbSearchChar
            // 
            this.tbSearchChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchChar.Location = new System.Drawing.Point(603, 279);
            this.tbSearchChar.MaxLength = 5;
            this.tbSearchChar.Name = "tbSearchChar";
            this.tbSearchChar.Size = new System.Drawing.Size(142, 20);
            this.tbSearchChar.TabIndex = 8;
            this.tbSearchChar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearchChar_KeyDown);
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(698, 202);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(41, 13);
            this.lblHeight.TabIndex = 7;
            this.lblHeight.Text = "Height:";
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(600, 202);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(38, 13);
            this.lblWidth.TabIndex = 6;
            this.lblWidth.Text = "Width:";
            // 
            // lblChar
            // 
            this.lblChar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChar.AutoSize = true;
            this.lblChar.Location = new System.Drawing.Point(669, 150);
            this.lblChar.Name = "lblChar";
            this.lblChar.Size = new System.Drawing.Size(32, 13);
            this.lblChar.TabIndex = 5;
            this.lblChar.Text = "Char:";
            // 
            // lblY
            // 
            this.lblY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(698, 175);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 4;
            this.lblY.Text = "Y:";
            // 
            // lblX
            // 
            this.lblX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(600, 175);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 3;
            this.lblX.Text = "X:";
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(600, 150);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(24, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "ID: ";
            // 
            // pbCharVeiwer
            // 
            this.pbCharVeiwer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCharVeiwer.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pbCharVeiwer.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbCharVeiwer.Location = new System.Drawing.Point(592, 0);
            this.pbCharVeiwer.Margin = new System.Windows.Forms.Padding(0);
            this.pbCharVeiwer.Name = "pbCharVeiwer";
            this.pbCharVeiwer.Size = new System.Drawing.Size(242, 144);
            this.pbCharVeiwer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCharVeiwer.TabIndex = 1;
            this.pbCharVeiwer.TabStop = false;
            this.pbCharVeiwer.DoubleClick += new System.EventHandler(this.pbCharVeiwer_DoubleClick);
            // 
            // tabRedraw
            // 
            this.tabRedraw.Controls.Add(this.btnLoadLST);
            this.tabRedraw.Controls.Add(this.cbTrimming);
            this.tabRedraw.Controls.Add(this.cbRemapEnabled);
            this.tabRedraw.Controls.Add(this.btnPreview);
            this.tabRedraw.Controls.Add(this.tbPreview);
            this.tabRedraw.Controls.Add(this.lblPreview);
            this.tabRedraw.Controls.Add(this.tbSize);
            this.tabRedraw.Controls.Add(this.lblSize);
            this.tabRedraw.Controls.Add(this.lblFont);
            this.tabRedraw.Controls.Add(this.tbFacename);
            this.tabRedraw.Controls.Add(this.tbRemap);
            this.tabRedraw.Controls.Add(this.lblRemapList);
            this.tabRedraw.Controls.Add(this.tbRedraw);
            this.tabRedraw.Controls.Add(this.lblRedrawList);
            this.tabRedraw.Controls.Add(this.btnRedraw);
            this.tabRedraw.Controls.Add(this.tbImportantList);
            this.tabRedraw.Controls.Add(this.lblImportantList);
            this.tabRedraw.Controls.Add(this.pbPreview);
            this.tabRedraw.Location = new System.Drawing.Point(4, 22);
            this.tabRedraw.Name = "tabRedraw";
            this.tabRedraw.Padding = new System.Windows.Forms.Padding(3);
            this.tabRedraw.Size = new System.Drawing.Size(834, 305);
            this.tabRedraw.TabIndex = 1;
            this.tabRedraw.Text = "Redraw";
            this.tabRedraw.UseVisualStyleBackColor = true;
            // 
            // cbTrimming
            // 
            this.cbTrimming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTrimming.AutoSize = true;
            this.cbTrimming.Location = new System.Drawing.Point(758, 243);
            this.cbTrimming.Name = "cbTrimming";
            this.cbTrimming.Size = new System.Drawing.Size(68, 17);
            this.cbTrimming.TabIndex = 16;
            this.cbTrimming.Text = "Trimming";
            this.cbTrimming.UseVisualStyleBackColor = true;
            // 
            // cbRemapEnabled
            // 
            this.cbRemapEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRemapEnabled.AutoSize = true;
            this.cbRemapEnabled.Location = new System.Drawing.Point(761, 217);
            this.cbRemapEnabled.Name = "cbRemapEnabled";
            this.cbRemapEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbRemapEnabled.TabIndex = 15;
            this.cbRemapEnabled.Text = "Enabled";
            this.cbRemapEnabled.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.Location = new System.Drawing.Point(689, 268);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(66, 23);
            this.btnPreview.TabIndex = 14;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // tbPreview
            // 
            this.tbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPreview.Location = new System.Drawing.Point(333, 270);
            this.tbPreview.Name = "tbPreview";
            this.tbPreview.Size = new System.Drawing.Size(267, 20);
            this.tbPreview.TabIndex = 13;
            this.tbPreview.Text = "The quick brown fox jumps over the lazy dog";
            this.tbPreview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPreview_KeyDown);
            // 
            // lblPreview
            // 
            this.lblPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPreview.AutoSize = true;
            this.lblPreview.Location = new System.Drawing.Point(282, 273);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(48, 13);
            this.lblPreview.TabIndex = 12;
            this.lblPreview.Text = "Preview:";
            // 
            // tbSize
            // 
            this.tbSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbSize.Location = new System.Drawing.Point(230, 270);
            this.tbSize.Name = "tbSize";
            this.tbSize.Size = new System.Drawing.Size(46, 20);
            this.tbSize.TabIndex = 11;
            this.tbSize.Text = "38,0";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(194, 273);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(30, 13);
            this.lblSize.TabIndex = 10;
            this.lblSize.Text = "Size:";
            // 
            // lblFont
            // 
            this.lblFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(52, 273);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(31, 13);
            this.lblFont.TabIndex = 9;
            this.lblFont.Text = "Font:";
            // 
            // tbFacename
            // 
            this.tbFacename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbFacename.Location = new System.Drawing.Point(89, 270);
            this.tbFacename.Name = "tbFacename";
            this.tbFacename.Size = new System.Drawing.Size(99, 20);
            this.tbFacename.TabIndex = 8;
            this.tbFacename.Text = "Consolas";
            // 
            // tbRemap
            // 
            this.tbRemap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRemap.Location = new System.Drawing.Point(89, 215);
            this.tbRemap.Name = "tbRemap";
            this.tbRemap.Size = new System.Drawing.Size(666, 20);
            this.tbRemap.TabIndex = 7;
            this.tbRemap.Text = "------------------------------------------------------------------------ｱｰｯﾔﾒｵｻｴｮ" +
    "ｪｬｭ｡ｩｨｫｧｲｳﾌﾈｹｺﾙﾂﾀﾊﾇﾕﾃﾍﾁﾉﾓﾚ";
            // 
            // lblRemapList
            // 
            this.lblRemapList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemapList.AutoSize = true;
            this.lblRemapList.Location = new System.Drawing.Point(20, 218);
            this.lblRemapList.Name = "lblRemapList";
            this.lblRemapList.Size = new System.Drawing.Size(63, 13);
            this.lblRemapList.TabIndex = 6;
            this.lblRemapList.Text = "Remap List:";
            // 
            // tbRedraw
            // 
            this.tbRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRedraw.Location = new System.Drawing.Point(89, 189);
            this.tbRedraw.Name = "tbRedraw";
            this.tbRedraw.Size = new System.Drawing.Size(737, 20);
            this.tbRedraw.TabIndex = 5;
            this.tbRedraw.Text = " 0123456789ABCDEFGHIJKLMNOPQRSTUVXWYZabcdefghijklmnopqrstuvxwyz+!?,.:;~¿ÑñôòÕÛÔÎÊ" +
    "ÌÍÁÉÈÂÇÒÓìèÙÚùâàêçõãíáéóú";
            this.tbRedraw.TextChanged += new System.EventHandler(this.RedrawTextChanged);
            // 
            // lblRedrawList
            // 
            this.lblRedrawList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRedrawList.AutoSize = true;
            this.lblRedrawList.Location = new System.Drawing.Point(17, 192);
            this.lblRedrawList.Name = "lblRedrawList";
            this.lblRedrawList.Size = new System.Drawing.Size(66, 13);
            this.lblRedrawList.TabIndex = 4;
            this.lblRedrawList.Text = "Redraw List:";
            // 
            // btnRedraw
            // 
            this.btnRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRedraw.Location = new System.Drawing.Point(761, 268);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(65, 23);
            this.btnRedraw.TabIndex = 3;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.btnRedraw_Click);
            // 
            // tbImportantList
            // 
            this.tbImportantList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbImportantList.Location = new System.Drawing.Point(89, 241);
            this.tbImportantList.Name = "tbImportantList";
            this.tbImportantList.Size = new System.Drawing.Size(666, 20);
            this.tbImportantList.TabIndex = 2;
            this.tbImportantList.Text = "0:10,10:31";
            // 
            // lblImportantList
            // 
            this.lblImportantList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblImportantList.AutoSize = true;
            this.lblImportantList.Location = new System.Drawing.Point(10, 244);
            this.lblImportantList.Name = "lblImportantList";
            this.lblImportantList.Size = new System.Drawing.Size(73, 13);
            this.lblImportantList.TabIndex = 1;
            this.lblImportantList.Text = "Important List:";
            // 
            // pbPreview
            // 
            this.pbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreview.BackColor = System.Drawing.Color.DarkSlateGray;
            this.pbPreview.Location = new System.Drawing.Point(0, 0);
            this.pbPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(834, 183);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPreview.TabIndex = 0;
            this.pbPreview.TabStop = false;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.btnSecret);
            this.tabAbout.Controls.Add(this.lblAuthor);
            this.tabAbout.Controls.Add(this.lblToolTitle);
            this.tabAbout.Controls.Add(this.wbEgg);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(834, 305);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // btnSecret
            // 
            this.btnSecret.Location = new System.Drawing.Point(736, 276);
            this.btnSecret.Name = "btnSecret";
            this.btnSecret.Size = new System.Drawing.Size(92, 23);
            this.btnSecret.TabIndex = 2;
            this.btnSecret.Text = "Secret Options";
            this.btnSecret.UseVisualStyleBackColor = true;
            this.btnSecret.Click += new System.EventHandler(this.btnSecret_Click);
            this.btnSecret.MouseEnter += new System.EventHandler(this.SecretEnter);
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(728, 69);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(92, 13);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "By Marcussacana";
            // 
            // lblToolTitle
            // 
            this.lblToolTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToolTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblToolTitle.Location = new System.Drawing.Point(6, 3);
            this.lblToolTitle.Name = "lblToolTitle";
            this.lblToolTitle.Size = new System.Drawing.Size(820, 79);
            this.lblToolTitle.TabIndex = 0;
            this.lblToolTitle.Text = "Gust Font Editor";
            this.lblToolTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // wbEgg
            // 
            this.wbEgg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbEgg.IsWebBrowserContextMenuEnabled = false;
            this.wbEgg.Location = new System.Drawing.Point(0, 85);
            this.wbEgg.Margin = new System.Windows.Forms.Padding(0);
            this.wbEgg.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbEgg.Name = "wbEgg";
            this.wbEgg.ScriptErrorsSuppressed = true;
            this.wbEgg.ScrollBarsEnabled = false;
            this.wbEgg.Size = new System.Drawing.Size(831, 217);
            this.wbEgg.TabIndex = 3;
            this.wbEgg.Visible = false;
            this.wbEgg.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.Triggered);
            // 
            // fdOpenTexture
            // 
            this.fdOpenTexture.DefaultExt = "png";
            this.fdOpenTexture.Filter = "All PNG and DDS Files|*.png;*.dds";
            this.fdOpenTexture.FileOk += new System.ComponentModel.CancelEventHandler(this.fdOpenTexture_FileOk);
            // 
            // fdExecutable
            // 
            this.fdExecutable.DefaultExt = "exe";
            this.fdExecutable.Filter = "All Executables|*.exe";
            this.fdExecutable.FileOk += new System.ComponentModel.CancelEventHandler(this.fdExecutable_FileOk);
            // 
            // btnLoadLST
            // 
            this.btnLoadLST.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadLST.Location = new System.Drawing.Point(608, 268);
            this.btnLoadLST.Name = "btnLoadLST";
            this.btnLoadLST.Size = new System.Drawing.Size(75, 23);
            this.btnLoadLST.TabIndex = 17;
            this.btnLoadLST.Text = "Load LST";
            this.btnLoadLST.UseVisualStyleBackColor = true;
            this.btnLoadLST.Click += new System.EventHandler(this.btnLoadLST_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 481);
            this.Controls.Add(this.pgRedraw);
            this.Controls.Add(this.gbGameInfo);
            this.MinimumSize = new System.Drawing.Size(860, 520);
            this.Name = "Main";
            this.Text = "Gust Font Editor";
            this.gbGameInfo.ResumeLayout(false);
            this.gbGameInfo.PerformLayout();
            this.pgRedraw.ResumeLayout(false);
            this.pgGlyphs.ResumeLayout(false);
            this.pgGlyphs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRigth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTop)).EndInit();
            this.pnFont.ResumeLayout(false);
            this.pnFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMainTexture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCharVeiwer)).EndInit();
            this.tabRedraw.ResumeLayout(false);
            this.tabRedraw.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGameInfo;
        private System.Windows.Forms.Button btnSelectTex;
        private System.Windows.Forms.TextBox tbTexturePath;
        private System.Windows.Forms.Label lblTexture;
        private System.Windows.Forms.Button btnSelectExe;
        private System.Windows.Forms.TextBox tbExePath;
        private System.Windows.Forms.Label lblExecutable;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TextBox tbGlyphCount;
        private System.Windows.Forms.Label lblGlyphCount;
        private System.Windows.Forms.TextBox tbTableOffset;
        private System.Windows.Forms.Label lblTableOffset;
        private System.Windows.Forms.TextBox tbGame;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.TabControl pgRedraw;
        private System.Windows.Forms.TabPage pgGlyphs;
        private System.Windows.Forms.TabPage tabRedraw;
        private System.Windows.Forms.Panel pnFont;
        private System.Windows.Forms.PictureBox pbMainTexture;
        private System.Windows.Forms.OpenFileDialog fdOpenTexture;
        private System.Windows.Forms.OpenFileDialog fdExecutable;
        private System.Windows.Forms.Button btnRetryOffsetFind;
        private System.Windows.Forms.PictureBox pbCharVeiwer;
        private System.Windows.Forms.TextBox tbChar;
        private System.Windows.Forms.NumericUpDown nudY;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudX;
        private System.Windows.Forms.Button btnSearchChar;
        private System.Windows.Forms.TextBox tbSearchChar;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblChar;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.NumericUpDown nudBottom;
        private System.Windows.Forms.NumericUpDown nudRigth;
        private System.Windows.Forms.NumericUpDown nudLeft;
        private System.Windows.Forms.NumericUpDown nudTop;
        private System.Windows.Forms.Label lblPaddingRigth;
        private System.Windows.Forms.Label lblPaddingLeft;
        private System.Windows.Forms.Label lblPaddingBottom;
        private System.Windows.Forms.Label lblPaddingTop;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.TextBox tbRedraw;
        private System.Windows.Forms.Label lblRedrawList;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.TextBox tbImportantList;
        private System.Windows.Forms.Label lblImportantList;
        private System.Windows.Forms.TextBox tbRemap;
        private System.Windows.Forms.Label lblRemapList;
        private System.Windows.Forms.TextBox tbSize;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.TextBox tbFacename;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.TextBox tbPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.CheckBox cbRemapEnabled;
        private System.Windows.Forms.CheckBox cbTrimming;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.Label lblToolTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Button btnSecret;
        private System.Windows.Forms.WebBrowser wbEgg;
        private System.Windows.Forms.Button btnLoadLST;
    }
}

