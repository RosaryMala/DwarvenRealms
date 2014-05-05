namespace DwarvenRealms
{
    partial class MainGui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LoadFileTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.elevationMapLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.elevationMapPathTextBox = new System.Windows.Forms.TextBox();
            this.elevationWaterMapPathTextBox = new System.Windows.Forms.TextBox();
            this.biomeMapPathTextBox = new System.Windows.Forms.TextBox();
            this.minecraftSaveTextBox = new System.Windows.Forms.TextBox();
            this.elevationMapLoadButton = new System.Windows.Forms.Button();
            this.elevationWaterMapLoadButton = new System.Windows.Forms.Button();
            this.biomeMapLoadButton = new System.Windows.Forms.Button();
            this.minecraftSaveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.borderNorthInput = new System.Windows.Forms.NumericUpDown();
            this.borderWestInput = new System.Windows.Forms.NumericUpDown();
            this.borderEastInput = new System.Windows.Forms.NumericUpDown();
            this.borderSouthInput = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.centerXInput = new System.Windows.Forms.NumericUpDown();
            this.centerYInput = new System.Windows.Forms.NumericUpDown();
            this.recenterButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.blocksPerTileInput = new System.Windows.Forms.NumericUpDown();
            this.areaOutputText = new System.Windows.Forms.Label();
            this.GenerateTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MapGenerationProgressBar = new System.Windows.Forms.ProgressBar();
            this.MapGenerationProgressLable = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.MapGenerationStartButton = new System.Windows.Forms.Button();
            this.MapGenerationAbortButton = new System.Windows.Forms.Button();
            this.mapGenerationWorker = new System.ComponentModel.BackgroundWorker();
            this.minecraftSaveSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.elevationMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.elevationWaterMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.biomeMapFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.caveHeightInput = new System.Windows.Forms.NumericUpDown();
            this.caveWidthInput = new System.Windows.Forms.NumericUpDown();
            this.caveCoverageInput = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.levelNameTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.LoadFileTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderNorthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderWestInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderEastInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderSouthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerXInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerYInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blocksPerTileInput)).BeginInit();
            this.GenerateTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.caveHeightInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caveWidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caveCoverageInput)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LoadFileTab);
            this.tabControl1.Controls.Add(this.GenerateTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 561);
            this.tabControl1.TabIndex = 0;
            // 
            // LoadFileTab
            // 
            this.LoadFileTab.Controls.Add(this.tableLayoutPanel2);
            this.LoadFileTab.Location = new System.Drawing.Point(4, 22);
            this.LoadFileTab.Name = "LoadFileTab";
            this.LoadFileTab.Padding = new System.Windows.Forms.Padding(3);
            this.LoadFileTab.Size = new System.Drawing.Size(776, 535);
            this.LoadFileTab.TabIndex = 2;
            this.LoadFileTab.Text = "Load Maps";
            this.LoadFileTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.Controls.Add(this.elevationMapLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.elevationMapPathTextBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.elevationWaterMapPathTextBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.biomeMapPathTextBox, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.minecraftSaveTextBox, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.elevationMapLoadButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.elevationWaterMapLoadButton, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.biomeMapLoadButton, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.minecraftSaveButton, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 8);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(770, 529);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // elevationMapLabel
            // 
            this.elevationMapLabel.AutoSize = true;
            this.elevationMapLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevationMapLabel.Location = new System.Drawing.Point(3, 0);
            this.elevationMapLabel.Name = "elevationMapLabel";
            this.elevationMapLabel.Size = new System.Drawing.Size(652, 20);
            this.elevationMapLabel.TabIndex = 0;
            this.elevationMapLabel.Text = "Elevation Map";
            this.elevationMapLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(652, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Elevation Water Map";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(652, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Biome Map";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(652, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Output Folder";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // elevationMapPathTextBox
            // 
            this.elevationMapPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevationMapPathTextBox.Location = new System.Drawing.Point(3, 23);
            this.elevationMapPathTextBox.Name = "elevationMapPathTextBox";
            this.elevationMapPathTextBox.Size = new System.Drawing.Size(652, 20);
            this.elevationMapPathTextBox.TabIndex = 4;
            this.elevationMapPathTextBox.TextChanged += new System.EventHandler(this.elevationMapPathTextBox_TextChanged);
            // 
            // elevationWaterMapPathTextBox
            // 
            this.elevationWaterMapPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevationWaterMapPathTextBox.Location = new System.Drawing.Point(3, 69);
            this.elevationWaterMapPathTextBox.Name = "elevationWaterMapPathTextBox";
            this.elevationWaterMapPathTextBox.Size = new System.Drawing.Size(652, 20);
            this.elevationWaterMapPathTextBox.TabIndex = 5;
            this.elevationWaterMapPathTextBox.TextChanged += new System.EventHandler(this.elevationWaterMapPathTextBox_TextChanged);
            // 
            // biomeMapPathTextBox
            // 
            this.biomeMapPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biomeMapPathTextBox.Location = new System.Drawing.Point(3, 115);
            this.biomeMapPathTextBox.Name = "biomeMapPathTextBox";
            this.biomeMapPathTextBox.Size = new System.Drawing.Size(652, 20);
            this.biomeMapPathTextBox.TabIndex = 6;
            this.biomeMapPathTextBox.TextChanged += new System.EventHandler(this.biomeMapPathTextBox_TextChanged);
            // 
            // minecraftSaveTextBox
            // 
            this.minecraftSaveTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minecraftSaveTextBox.Location = new System.Drawing.Point(3, 161);
            this.minecraftSaveTextBox.Name = "minecraftSaveTextBox";
            this.minecraftSaveTextBox.Size = new System.Drawing.Size(652, 20);
            this.minecraftSaveTextBox.TabIndex = 7;
            this.minecraftSaveTextBox.TextChanged += new System.EventHandler(this.minecraftSaveTextBox_TextChanged);
            // 
            // elevationMapLoadButton
            // 
            this.elevationMapLoadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevationMapLoadButton.Location = new System.Drawing.Point(661, 23);
            this.elevationMapLoadButton.Name = "elevationMapLoadButton";
            this.elevationMapLoadButton.Size = new System.Drawing.Size(106, 20);
            this.elevationMapLoadButton.TabIndex = 8;
            this.elevationMapLoadButton.Text = "Load";
            this.elevationMapLoadButton.UseVisualStyleBackColor = true;
            this.elevationMapLoadButton.Click += new System.EventHandler(this.elevationMapLoadButton_Click);
            // 
            // elevationWaterMapLoadButton
            // 
            this.elevationWaterMapLoadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elevationWaterMapLoadButton.Location = new System.Drawing.Point(661, 69);
            this.elevationWaterMapLoadButton.Name = "elevationWaterMapLoadButton";
            this.elevationWaterMapLoadButton.Size = new System.Drawing.Size(106, 20);
            this.elevationWaterMapLoadButton.TabIndex = 9;
            this.elevationWaterMapLoadButton.Text = "Load";
            this.elevationWaterMapLoadButton.UseVisualStyleBackColor = true;
            this.elevationWaterMapLoadButton.Click += new System.EventHandler(this.elevationWaterMapLoadButton_Click);
            // 
            // biomeMapLoadButton
            // 
            this.biomeMapLoadButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biomeMapLoadButton.Location = new System.Drawing.Point(661, 115);
            this.biomeMapLoadButton.Name = "biomeMapLoadButton";
            this.biomeMapLoadButton.Size = new System.Drawing.Size(106, 20);
            this.biomeMapLoadButton.TabIndex = 10;
            this.biomeMapLoadButton.Text = "Load";
            this.biomeMapLoadButton.UseVisualStyleBackColor = true;
            this.biomeMapLoadButton.Click += new System.EventHandler(this.biomeMapLoadButton_Click);
            // 
            // minecraftSaveButton
            // 
            this.minecraftSaveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minecraftSaveButton.Location = new System.Drawing.Point(661, 161);
            this.minecraftSaveButton.Name = "minecraftSaveButton";
            this.minecraftSaveButton.Size = new System.Drawing.Size(106, 20);
            this.minecraftSaveButton.TabIndex = 11;
            this.minecraftSaveButton.Text = "Chose";
            this.minecraftSaveButton.UseVisualStyleBackColor = true;
            this.minecraftSaveButton.Click += new System.EventHandler(this.minecraftSaveButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 2);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.borderNorthInput, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.borderWestInput, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.borderEastInput, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.borderSouthInput, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.centerXInput, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.centerYInput, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.recenterButton, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.blocksPerTileInput, 2, 4);
            this.tableLayoutPanel3.Controls.Add(this.areaOutputText, 3, 4);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.caveHeightInput, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.caveWidthInput, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.caveCoverageInput, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 10);
            this.tableLayoutPanel3.Controls.Add(this.levelNameTextBox, 2, 10);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 187);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 12;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(764, 339);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(103, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crop Borders";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // borderNorthInput
            // 
            this.borderNorthInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderNorthInput.Location = new System.Drawing.Point(103, 3);
            this.borderNorthInput.Maximum = new decimal(new int[] {
            4112,
            0,
            0,
            0});
            this.borderNorthInput.Name = "borderNorthInput";
            this.borderNorthInput.Size = new System.Drawing.Size(94, 20);
            this.borderNorthInput.TabIndex = 1;
            this.borderNorthInput.ValueChanged += new System.EventHandler(this.borderNorthInput_ValueChanged);
            // 
            // borderWestInput
            // 
            this.borderWestInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderWestInput.Location = new System.Drawing.Point(3, 29);
            this.borderWestInput.Maximum = new decimal(new int[] {
            4112,
            0,
            0,
            0});
            this.borderWestInput.Name = "borderWestInput";
            this.borderWestInput.Size = new System.Drawing.Size(94, 20);
            this.borderWestInput.TabIndex = 2;
            this.borderWestInput.ValueChanged += new System.EventHandler(this.borderWestInput_ValueChanged);
            // 
            // borderEastInput
            // 
            this.borderEastInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderEastInput.Location = new System.Drawing.Point(203, 29);
            this.borderEastInput.Maximum = new decimal(new int[] {
            4112,
            0,
            0,
            0});
            this.borderEastInput.Name = "borderEastInput";
            this.borderEastInput.Size = new System.Drawing.Size(94, 20);
            this.borderEastInput.TabIndex = 3;
            this.borderEastInput.ValueChanged += new System.EventHandler(this.borderEastInput_ValueChanged);
            // 
            // borderSouthInput
            // 
            this.borderSouthInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.borderSouthInput.Location = new System.Drawing.Point(103, 55);
            this.borderSouthInput.Maximum = new decimal(new int[] {
            4112,
            0,
            0,
            0});
            this.borderSouthInput.Name = "borderSouthInput";
            this.borderSouthInput.Size = new System.Drawing.Size(94, 20);
            this.borderSouthInput.TabIndex = 4;
            this.borderSouthInput.ValueChanged += new System.EventHandler(this.borderSouthInput_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(303, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Map Center X";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(303, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "Map Center Y";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // centerXInput
            // 
            this.centerXInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerXInput.Location = new System.Drawing.Point(403, 3);
            this.centerXInput.Maximum = new decimal(new int[] {
            4112,
            0,
            0,
            0});
            this.centerXInput.Name = "centerXInput";
            this.centerXInput.Size = new System.Drawing.Size(94, 20);
            this.centerXInput.TabIndex = 7;
            this.centerXInput.ValueChanged += new System.EventHandler(this.centerXInput_ValueChanged);
            // 
            // centerYInput
            // 
            this.centerYInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerYInput.Location = new System.Drawing.Point(403, 29);
            this.centerYInput.Maximum = new decimal(new int[] {
            4112,
            0,
            0,
            0});
            this.centerYInput.Name = "centerYInput";
            this.centerYInput.Size = new System.Drawing.Size(94, 20);
            this.centerYInput.TabIndex = 8;
            this.centerYInput.ValueChanged += new System.EventHandler(this.centerYInput_ValueChanged);
            // 
            // recenterButton
            // 
            this.recenterButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recenterButton.Location = new System.Drawing.Point(403, 55);
            this.recenterButton.Name = "recenterButton";
            this.recenterButton.Size = new System.Drawing.Size(94, 20);
            this.recenterButton.TabIndex = 9;
            this.recenterButton.Text = "Recenter";
            this.recenterButton.UseVisualStyleBackColor = true;
            this.recenterButton.Click += new System.EventHandler(this.recenterButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label7, 2);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 26);
            this.label7.TabIndex = 10;
            this.label7.Text = "Blocks Per Embark Tile";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // blocksPerTileInput
            // 
            this.blocksPerTileInput.Location = new System.Drawing.Point(203, 107);
            this.blocksPerTileInput.Maximum = new decimal(new int[] {
            144,
            0,
            0,
            0});
            this.blocksPerTileInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blocksPerTileInput.Name = "blocksPerTileInput";
            this.blocksPerTileInput.Size = new System.Drawing.Size(94, 20);
            this.blocksPerTileInput.TabIndex = 11;
            this.blocksPerTileInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.blocksPerTileInput.ValueChanged += new System.EventHandler(this.blocksPerTileInput_ValueChanged);
            // 
            // areaOutputText
            // 
            this.areaOutputText.AutoSize = true;
            this.areaOutputText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.areaOutputText.Location = new System.Drawing.Point(303, 104);
            this.areaOutputText.Name = "areaOutputText";
            this.areaOutputText.Size = new System.Drawing.Size(94, 26);
            this.areaOutputText.TabIndex = 12;
            this.areaOutputText.Text = "= Xkm2";
            this.areaOutputText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GenerateTab
            // 
            this.GenerateTab.Controls.Add(this.tableLayoutPanel1);
            this.GenerateTab.Location = new System.Drawing.Point(4, 22);
            this.GenerateTab.Name = "GenerateTab";
            this.GenerateTab.Padding = new System.Windows.Forms.Padding(3);
            this.GenerateTab.Size = new System.Drawing.Size(776, 535);
            this.GenerateTab.TabIndex = 1;
            this.GenerateTab.Text = "Generate";
            this.GenerateTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.MapGenerationProgressBar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.MapGenerationProgressLable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 529);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // MapGenerationProgressBar
            // 
            this.MapGenerationProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapGenerationProgressBar.Location = new System.Drawing.Point(3, 263);
            this.MapGenerationProgressBar.Maximum = 1000;
            this.MapGenerationProgressBar.Name = "MapGenerationProgressBar";
            this.MapGenerationProgressBar.Size = new System.Drawing.Size(764, 23);
            this.MapGenerationProgressBar.TabIndex = 0;
            // 
            // MapGenerationProgressLable
            // 
            this.MapGenerationProgressLable.AutoSize = true;
            this.MapGenerationProgressLable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapGenerationProgressLable.Location = new System.Drawing.Point(3, 240);
            this.MapGenerationProgressLable.Name = "MapGenerationProgressLable";
            this.MapGenerationProgressLable.Size = new System.Drawing.Size(764, 20);
            this.MapGenerationProgressLable.TabIndex = 1;
            this.MapGenerationProgressLable.Text = "Idle";
            this.MapGenerationProgressLable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.MapGenerationStartButton);
            this.flowLayoutPanel1.Controls.Add(this.MapGenerationAbortButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(770, 240);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // MapGenerationStartButton
            // 
            this.MapGenerationStartButton.Location = new System.Drawing.Point(3, 3);
            this.MapGenerationStartButton.Name = "MapGenerationStartButton";
            this.MapGenerationStartButton.Size = new System.Drawing.Size(103, 23);
            this.MapGenerationStartButton.TabIndex = 0;
            this.MapGenerationStartButton.Text = "Start Generation";
            this.MapGenerationStartButton.UseVisualStyleBackColor = true;
            this.MapGenerationStartButton.Click += new System.EventHandler(this.MapGenerationStartButton_Click);
            // 
            // MapGenerationAbortButton
            // 
            this.MapGenerationAbortButton.Enabled = false;
            this.MapGenerationAbortButton.Location = new System.Drawing.Point(112, 3);
            this.MapGenerationAbortButton.Name = "MapGenerationAbortButton";
            this.MapGenerationAbortButton.Size = new System.Drawing.Size(75, 23);
            this.MapGenerationAbortButton.TabIndex = 1;
            this.MapGenerationAbortButton.Text = "Abort";
            this.MapGenerationAbortButton.UseVisualStyleBackColor = true;
            this.MapGenerationAbortButton.Click += new System.EventHandler(this.MapGenerationAbortButton_Click);
            // 
            // mapGenerationWorker
            // 
            this.mapGenerationWorker.WorkerReportsProgress = true;
            this.mapGenerationWorker.WorkerSupportsCancellation = true;
            this.mapGenerationWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MapGenerationWorker_DoWork);
            this.mapGenerationWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MapGenerationWorker_ProgressChanged);
            this.mapGenerationWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MapGenerationWorker_RunWorkerCompleted);
            // 
            // elevationMapFileDialog
            // 
            this.elevationMapFileDialog.FileName = "world_graphic-el-*";
            this.elevationMapFileDialog.Filter = "Image Files(*.BMP;*.PNG)|*.BMP;*.PNG|All files (*.*)|*.*";
            // 
            // elevationWaterMapFileDialog
            // 
            this.elevationWaterMapFileDialog.FileName = "world_graphic-elw-*";
            this.elevationWaterMapFileDialog.Filter = "Image Files(*.BMP;*.PNG)|*.BMP;*.PNG|All files (*.*)|*.*";
            // 
            // biomeMapFileDialog
            // 
            this.biomeMapFileDialog.FileName = "world_graphic-bm-*";
            this.biomeMapFileDialog.Filter = "Image Files(*.BMP;*.PNG)|*.BMP;*.PNG|All files (*.*)|*.*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "Cave Height";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 26);
            this.label9.TabIndex = 14;
            this.label9.Text = "Cave Width";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 26);
            this.label10.TabIndex = 15;
            this.label10.Text = "Cave Coverage";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // caveHeightInput
            // 
            this.caveHeightInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caveHeightInput.Location = new System.Drawing.Point(103, 159);
            this.caveHeightInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.caveHeightInput.Name = "caveHeightInput";
            this.caveHeightInput.Size = new System.Drawing.Size(94, 20);
            this.caveHeightInput.TabIndex = 16;
            this.caveHeightInput.ValueChanged += new System.EventHandler(this.caveHeightInput_ValueChanged);
            // 
            // caveWidthInput
            // 
            this.caveWidthInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caveWidthInput.Location = new System.Drawing.Point(103, 185);
            this.caveWidthInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.caveWidthInput.Name = "caveWidthInput";
            this.caveWidthInput.Size = new System.Drawing.Size(94, 20);
            this.caveWidthInput.TabIndex = 17;
            this.caveWidthInput.ValueChanged += new System.EventHandler(this.caveWidthInput_ValueChanged);
            // 
            // caveCoverageInput
            // 
            this.caveCoverageInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caveCoverageInput.Location = new System.Drawing.Point(103, 211);
            this.caveCoverageInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.caveCoverageInput.Name = "caveCoverageInput";
            this.caveCoverageInput.Size = new System.Drawing.Size(94, 20);
            this.caveCoverageInput.TabIndex = 18;
            this.caveCoverageInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.caveCoverageInput.ValueChanged += new System.EventHandler(this.caveCoverageInput_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label11, 2);
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 260);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(194, 26);
            this.label11.TabIndex = 19;
            this.label11.Text = "Minecraft level name";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // levelNameTextBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.levelNameTextBox, 3);
            this.levelNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.levelNameTextBox.Location = new System.Drawing.Point(203, 263);
            this.levelNameTextBox.Name = "levelNameTextBox";
            this.levelNameTextBox.Size = new System.Drawing.Size(294, 20);
            this.levelNameTextBox.TabIndex = 20;
            this.levelNameTextBox.TextChanged += new System.EventHandler(this.levelNameTextBox_TextChanged);
            // 
            // MainGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainGui";
            this.Text = "Dorven Realms";
            this.tabControl1.ResumeLayout(false);
            this.LoadFileTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.borderNorthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderWestInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderEastInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderSouthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerXInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.centerYInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blocksPerTileInput)).EndInit();
            this.GenerateTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.caveHeightInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caveWidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caveCoverageInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GenerateTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar MapGenerationProgressBar;
        private System.ComponentModel.BackgroundWorker mapGenerationWorker;
        private System.Windows.Forms.Label MapGenerationProgressLable;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button MapGenerationStartButton;
        private System.Windows.Forms.Button MapGenerationAbortButton;
        private System.Windows.Forms.TabPage LoadFileTab;
        private System.Windows.Forms.FolderBrowserDialog minecraftSaveSelector;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label elevationMapLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox elevationMapPathTextBox;
        private System.Windows.Forms.TextBox elevationWaterMapPathTextBox;
        private System.Windows.Forms.TextBox biomeMapPathTextBox;
        private System.Windows.Forms.TextBox minecraftSaveTextBox;
        private System.Windows.Forms.Button elevationMapLoadButton;
        private System.Windows.Forms.Button elevationWaterMapLoadButton;
        private System.Windows.Forms.Button biomeMapLoadButton;
        private System.Windows.Forms.Button minecraftSaveButton;
        private System.Windows.Forms.OpenFileDialog elevationMapFileDialog;
        private System.Windows.Forms.OpenFileDialog elevationWaterMapFileDialog;
        private System.Windows.Forms.OpenFileDialog biomeMapFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown borderNorthInput;
        private System.Windows.Forms.NumericUpDown borderWestInput;
        private System.Windows.Forms.NumericUpDown borderEastInput;
        private System.Windows.Forms.NumericUpDown borderSouthInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown centerXInput;
        private System.Windows.Forms.NumericUpDown centerYInput;
        private System.Windows.Forms.Button recenterButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown blocksPerTileInput;
        private System.Windows.Forms.Label areaOutputText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown caveHeightInput;
        private System.Windows.Forms.NumericUpDown caveWidthInput;
        private System.Windows.Forms.NumericUpDown caveCoverageInput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox levelNameTextBox;
    }
}