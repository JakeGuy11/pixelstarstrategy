namespace PixelStarStrategy
{
    partial class d_form
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
            this.d_titleLabel = new System.Windows.Forms.Label();
            this.d_subTitleLabel = new System.Windows.Forms.Label();
            this.d_tabControl = new System.Windows.Forms.TabControl();
            this.d_tabAnalyze = new System.Windows.Forms.TabPage();
            this.d_progressBar = new System.Windows.Forms.ProgressBar();
            this.d_centralLabel = new System.Windows.Forms.Label();
            this.d_analyzeButton = new System.Windows.Forms.Button();
            this.d_tabPriorities = new System.Windows.Forms.TabPage();
            this.d_fetchPri = new System.Windows.Forms.Button();
            this.d_submitPri = new System.Windows.Forms.Button();
            this.d_priCrewSlider = new System.Windows.Forms.TrackBar();
            this.d_priCrew = new System.Windows.Forms.Label();
            this.d_priRoomSlider = new System.Windows.Forms.TrackBar();
            this.d_priRoomLabel = new System.Windows.Forms.Label();
            this.d_priTimeSlider = new System.Windows.Forms.TrackBar();
            this.d_priTimeLabel = new System.Windows.Forms.Label();
            this.d_priHPSlider = new System.Windows.Forms.TrackBar();
            this.d_priorityTitle = new System.Windows.Forms.Label();
            this.d_priHPLabel = new System.Windows.Forms.Label();
            this.d_prioritySubtitle = new System.Windows.Forms.Label();
            this.d_inputDataTab = new System.Windows.Forms.TabPage();
            this.d_clearMatchData = new System.Windows.Forms.Button();
            this.d_saveMatch = new System.Windows.Forms.Button();
            this.d_opCrewBox = new System.Windows.Forms.NumericUpDown();
            this.d_opRoomsBox = new System.Windows.Forms.NumericUpDown();
            this.d_opCrewLabel = new System.Windows.Forms.Label();
            this.d_opRoomsLabel = new System.Windows.Forms.Label();
            this.d_opHP = new System.Windows.Forms.TextBox();
            this.d_enemyHPLabel = new System.Windows.Forms.Label();
            this.d_myCrewKilled = new System.Windows.Forms.NumericUpDown();
            this.d_myRoomsDestroyed = new System.Windows.Forms.NumericUpDown();
            this.d_timeMins = new System.Windows.Forms.TextBox();
            this.d_timeSecs = new System.Windows.Forms.TextBox();
            this.d_myHPBox = new System.Windows.Forms.TextBox();
            this.d_layoutNum = new System.Windows.Forms.NumericUpDown();
            this.d_colonLabel = new System.Windows.Forms.Label();
            this.d_crewLabel = new System.Windows.Forms.Label();
            this.d_roomsLabel = new System.Windows.Forms.Label();
            this.d_TimeLabel = new System.Windows.Forms.Label();
            this.d_myHPLabel = new System.Windows.Forms.Label();
            this.d_layoutNumLabel = new System.Windows.Forms.Label();
            this.d_matchTitle = new System.Windows.Forms.Label();
            this.d_matchSubtitle = new System.Windows.Forms.Label();
            this.d_tabControl.SuspendLayout();
            this.d_tabAnalyze.SuspendLayout();
            this.d_tabPriorities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_priCrewSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_priRoomSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_priTimeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_priHPSlider)).BeginInit();
            this.d_inputDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_opCrewBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_opRoomsBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_myCrewKilled)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_myRoomsDestroyed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_layoutNum)).BeginInit();
            this.SuspendLayout();
            // 
            // d_titleLabel
            // 
            this.d_titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.d_titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_titleLabel.Location = new System.Drawing.Point(0, 0);
            this.d_titleLabel.Name = "d_titleLabel";
            this.d_titleLabel.Size = new System.Drawing.Size(584, 41);
            this.d_titleLabel.TabIndex = 0;
            this.d_titleLabel.Text = "PixelStarStrategy";
            this.d_titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // d_subTitleLabel
            // 
            this.d_subTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.d_subTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_subTitleLabel.Location = new System.Drawing.Point(0, 41);
            this.d_subTitleLabel.Name = "d_subTitleLabel";
            this.d_subTitleLabel.Size = new System.Drawing.Size(584, 24);
            this.d_subTitleLabel.TabIndex = 1;
            this.d_subTitleLabel.Text = "A Data-Driven Pixel Starships Strategy Analyzer";
            this.d_subTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // d_tabControl
            // 
            this.d_tabControl.Controls.Add(this.d_tabAnalyze);
            this.d_tabControl.Controls.Add(this.d_tabPriorities);
            this.d_tabControl.Controls.Add(this.d_inputDataTab);
            this.d_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.d_tabControl.Location = new System.Drawing.Point(0, 65);
            this.d_tabControl.Name = "d_tabControl";
            this.d_tabControl.SelectedIndex = 0;
            this.d_tabControl.Size = new System.Drawing.Size(584, 646);
            this.d_tabControl.TabIndex = 2;
            // 
            // d_tabAnalyze
            // 
            this.d_tabAnalyze.Controls.Add(this.d_progressBar);
            this.d_tabAnalyze.Controls.Add(this.d_centralLabel);
            this.d_tabAnalyze.Controls.Add(this.d_analyzeButton);
            this.d_tabAnalyze.Location = new System.Drawing.Point(4, 22);
            this.d_tabAnalyze.Name = "d_tabAnalyze";
            this.d_tabAnalyze.Padding = new System.Windows.Forms.Padding(3);
            this.d_tabAnalyze.Size = new System.Drawing.Size(576, 620);
            this.d_tabAnalyze.TabIndex = 0;
            this.d_tabAnalyze.Text = "Analyze";
            this.d_tabAnalyze.UseVisualStyleBackColor = true;
            // 
            // d_progressBar
            // 
            this.d_progressBar.Location = new System.Drawing.Point(8, 589);
            this.d_progressBar.Name = "d_progressBar";
            this.d_progressBar.Size = new System.Drawing.Size(560, 23);
            this.d_progressBar.TabIndex = 4;
            // 
            // d_centralLabel
            // 
            this.d_centralLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.d_centralLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_centralLabel.Location = new System.Drawing.Point(3, 3);
            this.d_centralLabel.Name = "d_centralLabel";
            this.d_centralLabel.Size = new System.Drawing.Size(570, 205);
            this.d_centralLabel.TabIndex = 3;
            this.d_centralLabel.Text = "No data. Please update and make sure you have submitted information.";
            this.d_centralLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // d_analyzeButton
            // 
            this.d_analyzeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_analyzeButton.Location = new System.Drawing.Point(184, 285);
            this.d_analyzeButton.Name = "d_analyzeButton";
            this.d_analyzeButton.Size = new System.Drawing.Size(200, 150);
            this.d_analyzeButton.TabIndex = 0;
            this.d_analyzeButton.Text = "Update And Analyze";
            this.d_analyzeButton.UseVisualStyleBackColor = true;
            this.d_analyzeButton.Click += new System.EventHandler(this.UpdateAnalyze);
            // 
            // d_tabPriorities
            // 
            this.d_tabPriorities.Controls.Add(this.d_fetchPri);
            this.d_tabPriorities.Controls.Add(this.d_submitPri);
            this.d_tabPriorities.Controls.Add(this.d_priCrewSlider);
            this.d_tabPriorities.Controls.Add(this.d_priCrew);
            this.d_tabPriorities.Controls.Add(this.d_priRoomSlider);
            this.d_tabPriorities.Controls.Add(this.d_priRoomLabel);
            this.d_tabPriorities.Controls.Add(this.d_priTimeSlider);
            this.d_tabPriorities.Controls.Add(this.d_priTimeLabel);
            this.d_tabPriorities.Controls.Add(this.d_priHPSlider);
            this.d_tabPriorities.Controls.Add(this.d_priorityTitle);
            this.d_tabPriorities.Controls.Add(this.d_priHPLabel);
            this.d_tabPriorities.Controls.Add(this.d_prioritySubtitle);
            this.d_tabPriorities.Location = new System.Drawing.Point(4, 22);
            this.d_tabPriorities.Name = "d_tabPriorities";
            this.d_tabPriorities.Padding = new System.Windows.Forms.Padding(3);
            this.d_tabPriorities.Size = new System.Drawing.Size(576, 620);
            this.d_tabPriorities.TabIndex = 1;
            this.d_tabPriorities.Text = "Set Priorities";
            this.d_tabPriorities.UseVisualStyleBackColor = true;
            // 
            // d_fetchPri
            // 
            this.d_fetchPri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_fetchPri.Location = new System.Drawing.Point(218, 278);
            this.d_fetchPri.Name = "d_fetchPri";
            this.d_fetchPri.Size = new System.Drawing.Size(200, 100);
            this.d_fetchPri.TabIndex = 15;
            this.d_fetchPri.Text = "Restore Values From Last Save";
            this.d_fetchPri.UseVisualStyleBackColor = true;
            this.d_fetchPri.Click += new System.EventHandler(this.GetPriPrefs);
            // 
            // d_submitPri
            // 
            this.d_submitPri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_submitPri.Location = new System.Drawing.Point(12, 278);
            this.d_submitPri.Name = "d_submitPri";
            this.d_submitPri.Size = new System.Drawing.Size(200, 100);
            this.d_submitPri.TabIndex = 14;
            this.d_submitPri.Text = "Submit Priorities";
            this.d_submitPri.UseVisualStyleBackColor = true;
            this.d_submitPri.Click += new System.EventHandler(this.WritePriPrefs);
            // 
            // d_priCrewSlider
            // 
            this.d_priCrewSlider.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.d_priCrewSlider.Location = new System.Drawing.Point(8, 227);
            this.d_priCrewSlider.Name = "d_priCrewSlider";
            this.d_priCrewSlider.Size = new System.Drawing.Size(556, 45);
            this.d_priCrewSlider.TabIndex = 13;
            // 
            // d_priCrew
            // 
            this.d_priCrew.AutoSize = true;
            this.d_priCrew.Location = new System.Drawing.Point(5, 211);
            this.d_priCrew.Name = "d_priCrew";
            this.d_priCrew.Size = new System.Drawing.Size(87, 13);
            this.d_priCrew.TabIndex = 12;
            this.d_priCrew.Text = "Crew Remaining:";
            // 
            // d_priRoomSlider
            // 
            this.d_priRoomSlider.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.d_priRoomSlider.Location = new System.Drawing.Point(8, 176);
            this.d_priRoomSlider.Name = "d_priRoomSlider";
            this.d_priRoomSlider.Size = new System.Drawing.Size(556, 45);
            this.d_priRoomSlider.TabIndex = 11;
            // 
            // d_priRoomLabel
            // 
            this.d_priRoomLabel.AutoSize = true;
            this.d_priRoomLabel.Location = new System.Drawing.Point(5, 160);
            this.d_priRoomLabel.Name = "d_priRoomLabel";
            this.d_priRoomLabel.Size = new System.Drawing.Size(94, 13);
            this.d_priRoomLabel.TabIndex = 10;
            this.d_priRoomLabel.Text = "Rooms Destroyed:";
            // 
            // d_priTimeSlider
            // 
            this.d_priTimeSlider.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.d_priTimeSlider.Location = new System.Drawing.Point(8, 125);
            this.d_priTimeSlider.Name = "d_priTimeSlider";
            this.d_priTimeSlider.Size = new System.Drawing.Size(556, 45);
            this.d_priTimeSlider.TabIndex = 9;
            // 
            // d_priTimeLabel
            // 
            this.d_priTimeLabel.AutoSize = true;
            this.d_priTimeLabel.Location = new System.Drawing.Point(5, 109);
            this.d_priTimeLabel.Name = "d_priTimeLabel";
            this.d_priTimeLabel.Size = new System.Drawing.Size(86, 13);
            this.d_priTimeLabel.TabIndex = 8;
            this.d_priTimeLabel.Text = "Time Remaining:";
            // 
            // d_priHPSlider
            // 
            this.d_priHPSlider.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.d_priHPSlider.Location = new System.Drawing.Point(8, 74);
            this.d_priHPSlider.Name = "d_priHPSlider";
            this.d_priHPSlider.Size = new System.Drawing.Size(556, 45);
            this.d_priHPSlider.TabIndex = 7;
            // 
            // d_priorityTitle
            // 
            this.d_priorityTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.d_priorityTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_priorityTitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.d_priorityTitle.Location = new System.Drawing.Point(3, 3);
            this.d_priorityTitle.Name = "d_priorityTitle";
            this.d_priorityTitle.Size = new System.Drawing.Size(570, 28);
            this.d_priorityTitle.TabIndex = 6;
            this.d_priorityTitle.Text = "Set Priorities";
            this.d_priorityTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // d_priHPLabel
            // 
            this.d_priHPLabel.AutoSize = true;
            this.d_priHPLabel.Location = new System.Drawing.Point(9, 58);
            this.d_priHPLabel.Name = "d_priHPLabel";
            this.d_priHPLabel.Size = new System.Drawing.Size(78, 13);
            this.d_priHPLabel.TabIndex = 1;
            this.d_priHPLabel.Text = "HP Remaining:";
            // 
            // d_prioritySubtitle
            // 
            this.d_prioritySubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.d_prioritySubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_prioritySubtitle.Location = new System.Drawing.Point(8, 31);
            this.d_prioritySubtitle.Name = "d_prioritySubtitle";
            this.d_prioritySubtitle.Size = new System.Drawing.Size(565, 27);
            this.d_prioritySubtitle.TabIndex = 0;
            this.d_prioritySubtitle.Text = "Select how important the following criteria are:";
            this.d_prioritySubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // d_inputDataTab
            // 
            this.d_inputDataTab.Controls.Add(this.d_clearMatchData);
            this.d_inputDataTab.Controls.Add(this.d_saveMatch);
            this.d_inputDataTab.Controls.Add(this.d_opCrewBox);
            this.d_inputDataTab.Controls.Add(this.d_opRoomsBox);
            this.d_inputDataTab.Controls.Add(this.d_opCrewLabel);
            this.d_inputDataTab.Controls.Add(this.d_opRoomsLabel);
            this.d_inputDataTab.Controls.Add(this.d_opHP);
            this.d_inputDataTab.Controls.Add(this.d_enemyHPLabel);
            this.d_inputDataTab.Controls.Add(this.d_myCrewKilled);
            this.d_inputDataTab.Controls.Add(this.d_myRoomsDestroyed);
            this.d_inputDataTab.Controls.Add(this.d_timeMins);
            this.d_inputDataTab.Controls.Add(this.d_timeSecs);
            this.d_inputDataTab.Controls.Add(this.d_myHPBox);
            this.d_inputDataTab.Controls.Add(this.d_layoutNum);
            this.d_inputDataTab.Controls.Add(this.d_colonLabel);
            this.d_inputDataTab.Controls.Add(this.d_crewLabel);
            this.d_inputDataTab.Controls.Add(this.d_roomsLabel);
            this.d_inputDataTab.Controls.Add(this.d_TimeLabel);
            this.d_inputDataTab.Controls.Add(this.d_myHPLabel);
            this.d_inputDataTab.Controls.Add(this.d_layoutNumLabel);
            this.d_inputDataTab.Controls.Add(this.d_matchTitle);
            this.d_inputDataTab.Controls.Add(this.d_matchSubtitle);
            this.d_inputDataTab.Location = new System.Drawing.Point(4, 22);
            this.d_inputDataTab.Name = "d_inputDataTab";
            this.d_inputDataTab.Size = new System.Drawing.Size(576, 620);
            this.d_inputDataTab.TabIndex = 2;
            this.d_inputDataTab.Text = "Input Data";
            this.d_inputDataTab.UseVisualStyleBackColor = true;
            // 
            // d_clearMatchData
            // 
            this.d_clearMatchData.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_clearMatchData.Location = new System.Drawing.Point(354, 166);
            this.d_clearMatchData.Name = "d_clearMatchData";
            this.d_clearMatchData.Size = new System.Drawing.Size(214, 100);
            this.d_clearMatchData.TabIndex = 11;
            this.d_clearMatchData.Text = "Clear All Match Data";
            this.d_clearMatchData.UseVisualStyleBackColor = true;
            this.d_clearMatchData.Click += new System.EventHandler(this.ClearMatchData);
            // 
            // d_saveMatch
            // 
            this.d_saveMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_saveMatch.Location = new System.Drawing.Point(354, 58);
            this.d_saveMatch.Name = "d_saveMatch";
            this.d_saveMatch.Size = new System.Drawing.Size(214, 100);
            this.d_saveMatch.TabIndex = 10;
            this.d_saveMatch.Text = "Save Match Data";
            this.d_saveMatch.UseVisualStyleBackColor = true;
            this.d_saveMatch.Click += new System.EventHandler(this.WriteUserDataToJSON);
            // 
            // d_opCrewBox
            // 
            this.d_opCrewBox.Location = new System.Drawing.Point(178, 284);
            this.d_opCrewBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.d_opCrewBox.Name = "d_opCrewBox";
            this.d_opCrewBox.Size = new System.Drawing.Size(43, 20);
            this.d_opCrewBox.TabIndex = 9;
            // 
            // d_opRoomsBox
            // 
            this.d_opRoomsBox.Location = new System.Drawing.Point(178, 228);
            this.d_opRoomsBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.d_opRoomsBox.Name = "d_opRoomsBox";
            this.d_opRoomsBox.Size = new System.Drawing.Size(43, 20);
            this.d_opRoomsBox.TabIndex = 8;
            // 
            // d_opCrewLabel
            // 
            this.d_opCrewLabel.AutoSize = true;
            this.d_opCrewLabel.Location = new System.Drawing.Point(175, 268);
            this.d_opCrewLabel.Name = "d_opCrewLabel";
            this.d_opCrewLabel.Size = new System.Drawing.Size(137, 13);
            this.d_opCrewLabel.TabIndex = 23;
            this.d_opCrewLabel.Text = "Opponent Crew Remaining:";
            // 
            // d_opRoomsLabel
            // 
            this.d_opRoomsLabel.AutoSize = true;
            this.d_opRoomsLabel.Location = new System.Drawing.Point(175, 212);
            this.d_opRoomsLabel.Name = "d_opRoomsLabel";
            this.d_opRoomsLabel.Size = new System.Drawing.Size(144, 13);
            this.d_opRoomsLabel.TabIndex = 22;
            this.d_opRoomsLabel.Text = "Opponent Rooms Destroyed:";
            // 
            // d_opHP
            // 
            this.d_opHP.Location = new System.Drawing.Point(178, 121);
            this.d_opHP.MaxLength = 4;
            this.d_opHP.Name = "d_opHP";
            this.d_opHP.Size = new System.Drawing.Size(43, 20);
            this.d_opHP.TabIndex = 7;
            this.d_opHP.Text = "00.0";
            // 
            // d_enemyHPLabel
            // 
            this.d_enemyHPLabel.AutoSize = true;
            this.d_enemyHPLabel.Location = new System.Drawing.Point(175, 105);
            this.d_enemyHPLabel.Name = "d_enemyHPLabel";
            this.d_enemyHPLabel.Size = new System.Drawing.Size(128, 13);
            this.d_enemyHPLabel.TabIndex = 20;
            this.d_enemyHPLabel.Text = "Opponent HP Remaining:";
            // 
            // d_myCrewKilled
            // 
            this.d_myCrewKilled.Location = new System.Drawing.Point(11, 284);
            this.d_myCrewKilled.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.d_myCrewKilled.Name = "d_myCrewKilled";
            this.d_myCrewKilled.Size = new System.Drawing.Size(43, 20);
            this.d_myCrewKilled.TabIndex = 6;
            // 
            // d_myRoomsDestroyed
            // 
            this.d_myRoomsDestroyed.Location = new System.Drawing.Point(11, 228);
            this.d_myRoomsDestroyed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.d_myRoomsDestroyed.Name = "d_myRoomsDestroyed";
            this.d_myRoomsDestroyed.Size = new System.Drawing.Size(43, 20);
            this.d_myRoomsDestroyed.TabIndex = 5;
            // 
            // d_timeMins
            // 
            this.d_timeMins.Location = new System.Drawing.Point(11, 176);
            this.d_timeMins.MaxLength = 1;
            this.d_timeMins.Name = "d_timeMins";
            this.d_timeMins.Size = new System.Drawing.Size(16, 20);
            this.d_timeMins.TabIndex = 3;
            this.d_timeMins.Text = "3";
            // 
            // d_timeSecs
            // 
            this.d_timeSecs.Location = new System.Drawing.Point(45, 176);
            this.d_timeSecs.Name = "d_timeSecs";
            this.d_timeSecs.Size = new System.Drawing.Size(30, 20);
            this.d_timeSecs.TabIndex = 4;
            this.d_timeSecs.Text = "00";
            // 
            // d_myHPBox
            // 
            this.d_myHPBox.Location = new System.Drawing.Point(11, 121);
            this.d_myHPBox.MaxLength = 4;
            this.d_myHPBox.Name = "d_myHPBox";
            this.d_myHPBox.Size = new System.Drawing.Size(43, 20);
            this.d_myHPBox.TabIndex = 2;
            this.d_myHPBox.Text = "00.0";
            // 
            // d_layoutNum
            // 
            this.d_layoutNum.Location = new System.Drawing.Point(11, 71);
            this.d_layoutNum.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.d_layoutNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.d_layoutNum.Name = "d_layoutNum";
            this.d_layoutNum.Size = new System.Drawing.Size(43, 20);
            this.d_layoutNum.TabIndex = 1;
            this.d_layoutNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // d_colonLabel
            // 
            this.d_colonLabel.AutoSize = true;
            this.d_colonLabel.Location = new System.Drawing.Point(29, 179);
            this.d_colonLabel.Name = "d_colonLabel";
            this.d_colonLabel.Size = new System.Drawing.Size(10, 13);
            this.d_colonLabel.TabIndex = 14;
            this.d_colonLabel.Text = ":";
            // 
            // d_crewLabel
            // 
            this.d_crewLabel.AutoSize = true;
            this.d_crewLabel.Location = new System.Drawing.Point(8, 268);
            this.d_crewLabel.Name = "d_crewLabel";
            this.d_crewLabel.Size = new System.Drawing.Size(112, 13);
            this.d_crewLabel.TabIndex = 13;
            this.d_crewLabel.Text = "Your Crew Remaining:";
            // 
            // d_roomsLabel
            // 
            this.d_roomsLabel.AutoSize = true;
            this.d_roomsLabel.Location = new System.Drawing.Point(8, 212);
            this.d_roomsLabel.Name = "d_roomsLabel";
            this.d_roomsLabel.Size = new System.Drawing.Size(119, 13);
            this.d_roomsLabel.TabIndex = 12;
            this.d_roomsLabel.Text = "Your Rooms Destroyed:";
            // 
            // d_TimeLabel
            // 
            this.d_TimeLabel.AutoSize = true;
            this.d_TimeLabel.Location = new System.Drawing.Point(8, 160);
            this.d_TimeLabel.Name = "d_TimeLabel";
            this.d_TimeLabel.Size = new System.Drawing.Size(86, 13);
            this.d_TimeLabel.TabIndex = 11;
            this.d_TimeLabel.Text = "Time Remaining:";
            // 
            // d_myHPLabel
            // 
            this.d_myHPLabel.AutoSize = true;
            this.d_myHPLabel.Location = new System.Drawing.Point(8, 105);
            this.d_myHPLabel.Name = "d_myHPLabel";
            this.d_myHPLabel.Size = new System.Drawing.Size(103, 13);
            this.d_myHPLabel.TabIndex = 10;
            this.d_myHPLabel.Text = "Your HP Remaining:";
            // 
            // d_layoutNumLabel
            // 
            this.d_layoutNumLabel.AutoSize = true;
            this.d_layoutNumLabel.Location = new System.Drawing.Point(8, 55);
            this.d_layoutNumLabel.Name = "d_layoutNumLabel";
            this.d_layoutNumLabel.Size = new System.Drawing.Size(82, 13);
            this.d_layoutNumLabel.TabIndex = 9;
            this.d_layoutNumLabel.Text = "Layout Number:";
            // 
            // d_matchTitle
            // 
            this.d_matchTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.d_matchTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_matchTitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.d_matchTitle.Location = new System.Drawing.Point(0, 0);
            this.d_matchTitle.Name = "d_matchTitle";
            this.d_matchTitle.Size = new System.Drawing.Size(576, 28);
            this.d_matchTitle.TabIndex = 8;
            this.d_matchTitle.Text = "Input Match Data";
            this.d_matchTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // d_matchSubtitle
            // 
            this.d_matchSubtitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.d_matchSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.d_matchSubtitle.Location = new System.Drawing.Point(3, 28);
            this.d_matchSubtitle.Name = "d_matchSubtitle";
            this.d_matchSubtitle.Size = new System.Drawing.Size(565, 27);
            this.d_matchSubtitle.TabIndex = 7;
            this.d_matchSubtitle.Text = "Fill out the following parameters:";
            this.d_matchSubtitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // d_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 711);
            this.Controls.Add(this.d_tabControl);
            this.Controls.Add(this.d_subTitleLabel);
            this.Controls.Add(this.d_titleLabel);
            this.Name = "d_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PixelStarStrategy";
            this.d_tabControl.ResumeLayout(false);
            this.d_tabAnalyze.ResumeLayout(false);
            this.d_tabPriorities.ResumeLayout(false);
            this.d_tabPriorities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_priCrewSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_priRoomSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_priTimeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_priHPSlider)).EndInit();
            this.d_inputDataTab.ResumeLayout(false);
            this.d_inputDataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_opCrewBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_opRoomsBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_myCrewKilled)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_myRoomsDestroyed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d_layoutNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label d_titleLabel;
        private System.Windows.Forms.Label d_subTitleLabel;
        private System.Windows.Forms.TabControl d_tabControl;
        private System.Windows.Forms.TabPage d_tabAnalyze;
        private System.Windows.Forms.TabPage d_tabPriorities;
        private System.Windows.Forms.TabPage d_inputDataTab;
        private System.Windows.Forms.Button d_analyzeButton;
        private System.Windows.Forms.Label d_centralLabel;
        private System.Windows.Forms.ProgressBar d_progressBar;
        private System.Windows.Forms.Label d_priHPLabel;
        private System.Windows.Forms.Label d_prioritySubtitle;
        private System.Windows.Forms.Label d_priorityTitle;
        private System.Windows.Forms.TrackBar d_priCrewSlider;
        private System.Windows.Forms.Label d_priCrew;
        private System.Windows.Forms.TrackBar d_priRoomSlider;
        private System.Windows.Forms.Label d_priRoomLabel;
        private System.Windows.Forms.TrackBar d_priTimeSlider;
        private System.Windows.Forms.Label d_priTimeLabel;
        private System.Windows.Forms.TrackBar d_priHPSlider;
        private System.Windows.Forms.Button d_submitPri;
        private System.Windows.Forms.Button d_fetchPri;
        private System.Windows.Forms.Label d_matchTitle;
        private System.Windows.Forms.Label d_matchSubtitle;
        private System.Windows.Forms.Label d_colonLabel;
        private System.Windows.Forms.Label d_crewLabel;
        private System.Windows.Forms.Label d_roomsLabel;
        private System.Windows.Forms.Label d_TimeLabel;
        private System.Windows.Forms.Label d_myHPLabel;
        private System.Windows.Forms.Label d_layoutNumLabel;
        private System.Windows.Forms.NumericUpDown d_layoutNum;
        private System.Windows.Forms.TextBox d_myHPBox;
        private System.Windows.Forms.TextBox d_timeMins;
        private System.Windows.Forms.TextBox d_timeSecs;
        private System.Windows.Forms.NumericUpDown d_myRoomsDestroyed;
        private System.Windows.Forms.NumericUpDown d_myCrewKilled;
        private System.Windows.Forms.TextBox d_opHP;
        private System.Windows.Forms.Label d_enemyHPLabel;
        private System.Windows.Forms.NumericUpDown d_opCrewBox;
        private System.Windows.Forms.NumericUpDown d_opRoomsBox;
        private System.Windows.Forms.Label d_opCrewLabel;
        private System.Windows.Forms.Label d_opRoomsLabel;
        private System.Windows.Forms.Button d_clearMatchData;
        private System.Windows.Forms.Button d_saveMatch;
    }
}

