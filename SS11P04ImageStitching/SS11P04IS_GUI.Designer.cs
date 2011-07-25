namespace SS11P04ImageStitching
{
    partial class SS11P04IS_GUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLeftImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadRightImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxPanoramaImage = new System.Windows.Forms.GroupBox();
            this.imageBoxPanorama = new Emgu.CV.UI.ImageBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.imageBoxLeftImage = new Emgu.CV.UI.ImageBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.imageBoxRightImage = new Emgu.CV.UI.ImageBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericUpDownRansacThresh = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonTransformPlusBlend = new System.Windows.Forms.Button();
            this.buttonFindHomography = new System.Windows.Forms.Button();
            this.buttonFindCorrespondences = new System.Windows.Forms.Button();
            this.buttonFindFeatures = new System.Windows.Forms.Button();
            this.buttonComputePanorama = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownRansacSteps = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownK = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSearchRange = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownA = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxPanoramaImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxPanorama)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxLeftImage)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRightImage)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRansacThresh)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRansacSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLeftImageToolStripMenuItem,
            this.loadRightImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadLeftImageToolStripMenuItem
            // 
            this.loadLeftImageToolStripMenuItem.Name = "loadLeftImageToolStripMenuItem";
            this.loadLeftImageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.loadLeftImageToolStripMenuItem.Text = "Load Left Image...";
            this.loadLeftImageToolStripMenuItem.Click += new System.EventHandler(this.loadLeftImageToolStripMenuItem_Click);
            // 
            // loadRightImageToolStripMenuItem
            // 
            this.loadRightImageToolStripMenuItem.Name = "loadRightImageToolStripMenuItem";
            this.loadRightImageToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.loadRightImageToolStripMenuItem.Text = "Load Right Image...";
            this.loadRightImageToolStripMenuItem.Click += new System.EventHandler(this.loadRightImageToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1044, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1044, 481);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.groupBoxPanoramaImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 4);
            this.panel1.Size = new System.Drawing.Size(686, 314);
            this.panel1.TabIndex = 0;
            // 
            // groupBoxPanoramaImage
            // 
            this.groupBoxPanoramaImage.Controls.Add(this.imageBoxPanorama);
            this.groupBoxPanoramaImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPanoramaImage.Location = new System.Drawing.Point(0, 0);
            this.groupBoxPanoramaImage.Name = "groupBoxPanoramaImage";
            this.groupBoxPanoramaImage.Size = new System.Drawing.Size(686, 314);
            this.groupBoxPanoramaImage.TabIndex = 0;
            this.groupBoxPanoramaImage.TabStop = false;
            this.groupBoxPanoramaImage.Text = "Panorama";
            // 
            // imageBoxPanorama
            // 
            this.imageBoxPanorama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxPanorama.Location = new System.Drawing.Point(3, 16);
            this.imageBoxPanorama.Name = "imageBoxPanorama";
            this.imageBoxPanorama.Size = new System.Drawing.Size(680, 295);
            this.imageBoxPanorama.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBoxPanorama.TabIndex = 2;
            this.imageBoxPanorama.TabStop = false;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 2);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(695, 3);
            this.panel2.Name = "panel2";
            this.tableLayoutPanel1.SetRowSpan(this.panel2, 3);
            this.panel2.Size = new System.Drawing.Size(346, 234);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.imageBoxLeftImage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(346, 234);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Left Image";
            // 
            // imageBoxLeftImage
            // 
            this.imageBoxLeftImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxLeftImage.Location = new System.Drawing.Point(3, 16);
            this.imageBoxLeftImage.Name = "imageBoxLeftImage";
            this.imageBoxLeftImage.Size = new System.Drawing.Size(340, 215);
            this.imageBoxLeftImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBoxLeftImage.TabIndex = 2;
            this.imageBoxLeftImage.TabStop = false;
            // 
            // panel3
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel3, 2);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(695, 243);
            this.panel3.Name = "panel3";
            this.tableLayoutPanel1.SetRowSpan(this.panel3, 3);
            this.panel3.Size = new System.Drawing.Size(346, 235);
            this.panel3.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.imageBoxRightImage);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(346, 235);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Right Image";
            // 
            // imageBoxRightImage
            // 
            this.imageBoxRightImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageBoxRightImage.Location = new System.Drawing.Point(3, 16);
            this.imageBoxRightImage.Name = "imageBoxRightImage";
            this.imageBoxRightImage.Size = new System.Drawing.Size(340, 216);
            this.imageBoxRightImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBoxRightImage.TabIndex = 2;
            this.imageBoxRightImage.TabStop = false;
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 4);
            this.panel4.Controls.Add(this.groupBox4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 323);
            this.panel4.Name = "panel4";
            this.tableLayoutPanel1.SetRowSpan(this.panel4, 2);
            this.panel4.Size = new System.Drawing.Size(686, 155);
            this.panel4.TabIndex = 3;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.numericUpDownRansacThresh);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.buttonComputePanorama);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(686, 155);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // numericUpDownRansacThresh
            // 
            this.numericUpDownRansacThresh.DecimalPlaces = 1;
            this.numericUpDownRansacThresh.Location = new System.Drawing.Point(124, 124);
			this.numericUpDownRansacThresh.Minimum = 0.01m;
            this.numericUpDownRansacThresh.Maximum = 100.0m;
			this.numericUpDownRansacThresh.Increment = 0.01m;
            this.numericUpDownRansacThresh.Name = "numericUpDownRansacThresh";
            this.numericUpDownRansacThresh.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownRansacThresh.TabIndex = 7;
            this.numericUpDownRansacThresh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownRansacThresh.Value = 0.1m;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.buttonTransformPlusBlend);
            this.groupBox6.Controls.Add(this.buttonFindHomography);
            this.groupBox6.Controls.Add(this.buttonFindCorrespondences);
            this.groupBox6.Controls.Add(this.buttonFindFeatures);
            this.groupBox6.Location = new System.Drawing.Point(368, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(316, 139);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Single Steps";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox9);
            this.groupBox7.Controls.Add(this.textBox8);
            this.groupBox7.Controls.Add(this.textBox7);
            this.groupBox7.Controls.Add(this.textBox6);
            this.groupBox7.Controls.Add(this.textBox5);
            this.groupBox7.Controls.Add(this.textBox4);
            this.groupBox7.Controls.Add(this.textBox3);
            this.groupBox7.Controls.Add(this.textBox2);
            this.groupBox7.Controls.Add(this.textBox1);
            this.groupBox7.Location = new System.Drawing.Point(138, 9);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(172, 124);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Homography";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(113, 78);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(42, 20);
            this.textBox9.TabIndex = 8;
            this.textBox9.Text = "1";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(65, 78);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(42, 20);
            this.textBox8.TabIndex = 7;
            this.textBox8.Text = "0";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(17, 78);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(42, 20);
            this.textBox7.TabIndex = 6;
            this.textBox7.Text = "0";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(113, 52);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(42, 20);
            this.textBox6.TabIndex = 5;
            this.textBox6.Text = "0";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(65, 52);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(42, 20);
            this.textBox5.TabIndex = 4;
            this.textBox5.Text = "1";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(17, 52);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(42, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Text = "0";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(113, 26);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(42, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "0";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(65, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(42, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "0";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(42, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "1";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonTransformPlusBlend
            // 
            this.buttonTransformPlusBlend.Enabled = false;
            this.buttonTransformPlusBlend.Location = new System.Drawing.Point(6, 106);
            this.buttonTransformPlusBlend.Name = "buttonTransformPlusBlend";
            this.buttonTransformPlusBlend.Size = new System.Drawing.Size(126, 23);
            this.buttonTransformPlusBlend.TabIndex = 3;
            this.buttonTransformPlusBlend.Text = "Transform + Blend";
            this.buttonTransformPlusBlend.UseVisualStyleBackColor = true;
            this.buttonTransformPlusBlend.Click += new System.EventHandler(this.buttonTransformPlusBlend_Click);
            // 
            // buttonFindHomography
            // 
            this.buttonFindHomography.Enabled = false;
            this.buttonFindHomography.Location = new System.Drawing.Point(6, 77);
            this.buttonFindHomography.Name = "buttonFindHomography";
            this.buttonFindHomography.Size = new System.Drawing.Size(126, 23);
            this.buttonFindHomography.TabIndex = 2;
            this.buttonFindHomography.Text = "Find Homography";
            this.buttonFindHomography.UseVisualStyleBackColor = true;
            this.buttonFindHomography.Click += new System.EventHandler(this.buttonFindHomography_Click);
            // 
            // buttonFindCorrespondences
            // 
            this.buttonFindCorrespondences.Enabled = false;
            this.buttonFindCorrespondences.Location = new System.Drawing.Point(6, 48);
            this.buttonFindCorrespondences.Name = "buttonFindCorrespondences";
            this.buttonFindCorrespondences.Size = new System.Drawing.Size(126, 23);
            this.buttonFindCorrespondences.TabIndex = 1;
            this.buttonFindCorrespondences.Text = "Find Correspondences";
            this.buttonFindCorrespondences.UseVisualStyleBackColor = true;
            this.buttonFindCorrespondences.Click += new System.EventHandler(this.buttonFindCorrespondences_Click);
            // 
            // buttonFindFeatures
            // 
            this.buttonFindFeatures.Location = new System.Drawing.Point(6, 19);
            this.buttonFindFeatures.Name = "buttonFindFeatures";
            this.buttonFindFeatures.Size = new System.Drawing.Size(126, 23);
            this.buttonFindFeatures.TabIndex = 0;
            this.buttonFindFeatures.Text = "Find Features";
            this.buttonFindFeatures.UseVisualStyleBackColor = true;
            this.buttonFindFeatures.Click += new System.EventHandler(this.buttonFindFeatures_Click);
            // 
            // buttonComputePanorama
            // 
            this.buttonComputePanorama.Location = new System.Drawing.Point(215, 66);
            this.buttonComputePanorama.Name = "buttonComputePanorama";
            this.buttonComputePanorama.Size = new System.Drawing.Size(147, 23);
            this.buttonComputePanorama.TabIndex = 1;
            this.buttonComputePanorama.Text = "Compute Panorama";
            this.buttonComputePanorama.UseVisualStyleBackColor = true;
            this.buttonComputePanorama.Click += new System.EventHandler(this.buttonComputePanorama_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.numericUpDownRansacSteps);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.numericUpDownK);
            this.groupBox5.Controls.Add(this.numericUpDownSearchRange);
            this.groupBox5.Controls.Add(this.numericUpDownA);
            this.groupBox5.Location = new System.Drawing.Point(9, 10);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 139);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Parameter";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ransac Thresh";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ransac Steps";
            // 
            // numericUpDownRansacSteps
            // 
            this.numericUpDownRansacSteps.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRansacSteps.Location = new System.Drawing.Point(115, 88);
            this.numericUpDownRansacSteps.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownRansacSteps.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownRansacSteps.Name = "numericUpDownRansacSteps";
            this.numericUpDownRansacSteps.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownRansacSteps.TabIndex = 6;
            this.numericUpDownRansacSteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownRansacSteps.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "k";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search Range";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "a";
            // 
            // numericUpDownK
            // 
            this.numericUpDownK.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownK.Location = new System.Drawing.Point(115, 62);
            this.numericUpDownK.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numericUpDownK.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownK.Name = "numericUpDownK";
            this.numericUpDownK.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownK.TabIndex = 2;
            this.numericUpDownK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownK.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDownSearchRange
            // 
            this.numericUpDownSearchRange.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSearchRange.Location = new System.Drawing.Point(115, 36);
            this.numericUpDownSearchRange.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownSearchRange.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSearchRange.Name = "numericUpDownSearchRange";
            this.numericUpDownSearchRange.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownSearchRange.TabIndex = 1;
            this.numericUpDownSearchRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownSearchRange.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numericUpDownA
            // 
            this.numericUpDownA.DecimalPlaces = 3;
            this.numericUpDownA.Increment = 0.001m;
            this.numericUpDownA.Location = new System.Drawing.Point(115, 10);
            this.numericUpDownA.Name = "numericUpDownA";
            this.numericUpDownA.Size = new System.Drawing.Size(75, 20);
            this.numericUpDownA.TabIndex = 0;
            this.numericUpDownA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDownA.Value = 0.001m;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownHeight = 500;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(222, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(820, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // SS11P04IS_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 527);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SS11P04IS_GUI";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBoxPanoramaImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxPanorama)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxLeftImage)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxRightImage)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRansacThresh)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRansacSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLeftImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadRightImageToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxPanoramaImage;
        private Emgu.CV.UI.ImageBox imageBoxPanorama;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private Emgu.CV.UI.ImageBox imageBoxLeftImage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private Emgu.CV.UI.ImageBox imageBoxRightImage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonTransformPlusBlend;
        private System.Windows.Forms.Button buttonFindHomography;
        private System.Windows.Forms.Button buttonFindCorrespondences;
        private System.Windows.Forms.Button buttonFindFeatures;
        private System.Windows.Forms.Button buttonComputePanorama;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownK;
        private System.Windows.Forms.NumericUpDown numericUpDownSearchRange;
        private System.Windows.Forms.NumericUpDown numericUpDownA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownRansacThresh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownRansacSteps;
    }
}

