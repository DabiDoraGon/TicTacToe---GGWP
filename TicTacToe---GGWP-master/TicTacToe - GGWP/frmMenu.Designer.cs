
namespace TicTacToe___GGWP
{
    partial class frmMenu
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
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnCredits = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlModeSelect = new System.Windows.Forms.Panel();
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.btnModeBack = new System.Windows.Forms.Button();
            this.btnModeNext = new System.Windows.Forms.Button();
            this.rdoPvP = new System.Windows.Forms.RadioButton();
            this.rdoPvE = new System.Windows.Forms.RadioButton();
            this.pnlVariantSelect = new System.Windows.Forms.Panel();
            this.grpVariant = new System.Windows.Forms.GroupBox();
            this.btnVariantBack = new System.Windows.Forms.Button();
            this.btnVariantNext = new System.Windows.Forms.Button();
            this.rdoAdvanced = new System.Windows.Forms.RadioButton();
            this.rdoLimited = new System.Windows.Forms.RadioButton();
            this.rdoBasic = new System.Windows.Forms.RadioButton();
            this.pnlDifficultySelect = new System.Windows.Forms.Panel();
            this.grpDifficulty = new System.Windows.Forms.GroupBox();
            this.btnDifficultyBack = new System.Windows.Forms.Button();
            this.btnDifficultyNext = new System.Windows.Forms.Button();
            this.rdoEasy = new System.Windows.Forms.RadioButton();
            this.rdoNormal = new System.Windows.Forms.RadioButton();
            this.rdoHard = new System.Windows.Forms.RadioButton();
            this.rdoBoss = new System.Windows.Forms.RadioButton();
            this.pnlMarkSelect = new System.Windows.Forms.Panel();
            this.grpMark = new System.Windows.Forms.GroupBox();
            this.btnMarkBack = new System.Windows.Forms.Button();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.rdoO = new System.Windows.Forms.RadioButton();
            this.rdoX = new System.Windows.Forms.RadioButton();
            this.pnlCenter.SuspendLayout();
            this.pnlModeSelect.SuspendLayout();
            this.grpMode.SuspendLayout();
            this.pnlVariantSelect.SuspendLayout();
            this.grpVariant.SuspendLayout();
            this.pnlDifficultySelect.SuspendLayout();
            this.grpDifficulty.SuspendLayout();
            this.pnlMarkSelect.SuspendLayout();
            this.grpMark.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.AutoSize = true;
            this.lblGameTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameTitle.Location = new System.Drawing.Point(211, 105);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(310, 31);
            this.lblGameTitle.TabIndex = 0;
            this.lblGameTitle.Text = "TIC TAC TOE - GGWP";
            this.lblGameTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPlay.Location = new System.Drawing.Point(274, 282);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(168, 50);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "PLAY";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnOptions.Location = new System.Drawing.Point(274, 366);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(168, 50);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnCredits
            // 
            this.btnCredits.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCredits.Location = new System.Drawing.Point(274, 453);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(168, 50);
            this.btnCredits.TabIndex = 3;
            this.btnCredits.Text = "Credits";
            this.btnCredits.UseVisualStyleBackColor = true;
            this.btnCredits.Click += new System.EventHandler(this.btnCredits_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.pnlModeSelect);
            this.pnlCenter.Controls.Add(this.pnlVariantSelect);
            this.pnlCenter.Controls.Add(this.pnlDifficultySelect);
            this.pnlCenter.Controls.Add(this.pnlMarkSelect);
            this.pnlCenter.Location = new System.Drawing.Point(112, 262);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(504, 300);
            this.pnlCenter.TabIndex = 4;
            // 
            // pnlModeSelect
            // 
            this.pnlModeSelect.Controls.Add(this.grpMode);
            this.pnlModeSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModeSelect.Location = new System.Drawing.Point(0, 0);
            this.pnlModeSelect.Name = "pnlModeSelect";
            this.pnlModeSelect.Size = new System.Drawing.Size(504, 300);
            this.pnlModeSelect.TabIndex = 0;
            this.pnlModeSelect.Visible = false;
            this.pnlModeSelect.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlModeSelect_Paint);
            // 
            // grpMode
            // 
            this.grpMode.Controls.Add(this.btnModeBack);
            this.grpMode.Controls.Add(this.btnModeNext);
            this.grpMode.Controls.Add(this.rdoPvP);
            this.grpMode.Controls.Add(this.rdoPvE);
            this.grpMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMode.Location = new System.Drawing.Point(15, 16);
            this.grpMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMode.Name = "grpMode";
            this.grpMode.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMode.Size = new System.Drawing.Size(435, 244);
            this.grpMode.TabIndex = 0;
            this.grpMode.TabStop = false;
            this.grpMode.Text = "Select Mode";
            this.grpMode.Enter += new System.EventHandler(this.grpMode_Enter);
            // 
            // btnModeBack
            // 
            this.btnModeBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModeBack.Location = new System.Drawing.Point(90, 162);
            this.btnModeBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModeBack.Name = "btnModeBack";
            this.btnModeBack.Size = new System.Drawing.Size(90, 49);
            this.btnModeBack.TabIndex = 4;
            this.btnModeBack.Text = "Back";
            this.btnModeBack.UseVisualStyleBackColor = true;
            this.btnModeBack.Click += new System.EventHandler(this.btnModeBack_Click);
            // 
            // btnModeNext
            // 
            this.btnModeNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModeNext.Location = new System.Drawing.Point(270, 162);
            this.btnModeNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnModeNext.Name = "btnModeNext";
            this.btnModeNext.Size = new System.Drawing.Size(90, 49);
            this.btnModeNext.TabIndex = 3;
            this.btnModeNext.Text = "Next";
            this.btnModeNext.UseVisualStyleBackColor = true;
            this.btnModeNext.Click += new System.EventHandler(this.btnModeNext_Click);
            // 
            // rdoPvP
            // 
            this.rdoPvP.AutoSize = true;
            this.rdoPvP.Location = new System.Drawing.Point(15, 98);
            this.rdoPvP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoPvP.Name = "rdoPvP";
            this.rdoPvP.Size = new System.Drawing.Size(201, 24);
            this.rdoPvP.TabIndex = 2;
            this.rdoPvP.TabStop = true;
            this.rdoPvP.Text = "PvP – 2 Players (local)";
            this.rdoPvP.UseVisualStyleBackColor = true;
            this.rdoPvP.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rdoPvE
            // 
            this.rdoPvE.AutoSize = true;
            this.rdoPvE.Location = new System.Drawing.Point(15, 49);
            this.rdoPvE.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoPvE.Name = "rdoPvE";
            this.rdoPvE.Size = new System.Drawing.Size(179, 24);
            this.rdoPvE.TabIndex = 1;
            this.rdoPvE.TabStop = true;
            this.rdoPvE.Text = "PvE – Player vs Bot";
            this.rdoPvE.UseVisualStyleBackColor = true;
            this.rdoPvE.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // pnlVariantSelect
            // 
            this.pnlVariantSelect.Controls.Add(this.grpVariant);
            this.pnlVariantSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVariantSelect.Location = new System.Drawing.Point(0, 0);
            this.pnlVariantSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlVariantSelect.Name = "pnlVariantSelect";
            this.pnlVariantSelect.Size = new System.Drawing.Size(504, 300);
            this.pnlVariantSelect.TabIndex = 5;
            this.pnlVariantSelect.Visible = false;
            // 
            // grpVariant
            // 
            this.grpVariant.Controls.Add(this.btnVariantBack);
            this.grpVariant.Controls.Add(this.btnVariantNext);
            this.grpVariant.Controls.Add(this.rdoAdvanced);
            this.grpVariant.Controls.Add(this.rdoLimited);
            this.grpVariant.Controls.Add(this.rdoBasic);
            this.grpVariant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVariant.Location = new System.Drawing.Point(15, 16);
            this.grpVariant.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpVariant.Name = "grpVariant";
            this.grpVariant.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpVariant.Size = new System.Drawing.Size(435, 244);
            this.grpVariant.TabIndex = 0;
            this.grpVariant.TabStop = false;
            this.grpVariant.Text = "Select Variant";
            // 
            // btnVariantBack
            // 
            this.btnVariantBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVariantBack.Location = new System.Drawing.Point(90, 162);
            this.btnVariantBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVariantBack.Name = "btnVariantBack";
            this.btnVariantBack.Size = new System.Drawing.Size(90, 49);
            this.btnVariantBack.TabIndex = 7;
            this.btnVariantBack.Text = "Back";
            this.btnVariantBack.UseVisualStyleBackColor = true;
            this.btnVariantBack.Click += new System.EventHandler(this.btnVariantBack_Click);
            // 
            // btnVariantNext
            // 
            this.btnVariantNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVariantNext.Location = new System.Drawing.Point(270, 162);
            this.btnVariantNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVariantNext.Name = "btnVariantNext";
            this.btnVariantNext.Size = new System.Drawing.Size(90, 49);
            this.btnVariantNext.TabIndex = 6;
            this.btnVariantNext.Text = "Next";
            this.btnVariantNext.UseVisualStyleBackColor = true;
            this.btnVariantNext.Click += new System.EventHandler(this.btnVariantNext_Click);
            // 
            // rdoAdvanced
            // 
            this.rdoAdvanced.AutoSize = true;
            this.rdoAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAdvanced.Location = new System.Drawing.Point(15, 122);
            this.rdoAdvanced.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoAdvanced.Name = "rdoAdvanced";
            this.rdoAdvanced.Size = new System.Drawing.Size(259, 21);
            this.rdoAdvanced.TabIndex = 5;
            this.rdoAdvanced.TabStop = true;
            this.rdoAdvanced.Text = "Advanced (5x5, 4-in-a-row wins)";
            this.rdoAdvanced.UseVisualStyleBackColor = true;
            // 
            // rdoLimited
            // 
            this.rdoLimited.AutoSize = true;
            this.rdoLimited.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLimited.Location = new System.Drawing.Point(15, 81);
            this.rdoLimited.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoLimited.Name = "rdoLimited";
            this.rdoLimited.Size = new System.Drawing.Size(196, 21);
            this.rdoLimited.TabIndex = 4;
            this.rdoLimited.TabStop = true;
            this.rdoLimited.Text = "Limited (3 mark limited)";
            this.rdoLimited.UseVisualStyleBackColor = true;
            // 
            // rdoBasic
            // 
            this.rdoBasic.AutoSize = true;
            this.rdoBasic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBasic.Location = new System.Drawing.Point(15, 41);
            this.rdoBasic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoBasic.Name = "rdoBasic";
            this.rdoBasic.Size = new System.Drawing.Size(192, 21);
            this.rdoBasic.TabIndex = 3;
            this.rdoBasic.TabStop = true;
            this.rdoBasic.Text = "Basic (3-in-a-row wins)";
            this.rdoBasic.UseVisualStyleBackColor = true;
            // 
            // pnlDifficultySelect
            // 
            this.pnlDifficultySelect.Controls.Add(this.grpDifficulty);
            this.pnlDifficultySelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDifficultySelect.Location = new System.Drawing.Point(0, 0);
            this.pnlDifficultySelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlDifficultySelect.Name = "pnlDifficultySelect";
            this.pnlDifficultySelect.Size = new System.Drawing.Size(504, 300);
            this.pnlDifficultySelect.TabIndex = 6;
            this.pnlDifficultySelect.Visible = false;
            // 
            // grpDifficulty
            // 
            this.grpDifficulty.Controls.Add(this.btnDifficultyBack);
            this.grpDifficulty.Controls.Add(this.btnDifficultyNext);
            this.grpDifficulty.Controls.Add(this.rdoEasy);
            this.grpDifficulty.Controls.Add(this.rdoNormal);
            this.grpDifficulty.Controls.Add(this.rdoHard);
            this.grpDifficulty.Controls.Add(this.rdoBoss);
            this.grpDifficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDifficulty.Location = new System.Drawing.Point(15, 16);
            this.grpDifficulty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDifficulty.Name = "grpDifficulty";
            this.grpDifficulty.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpDifficulty.Size = new System.Drawing.Size(466, 263);
            this.grpDifficulty.TabIndex = 1;
            this.grpDifficulty.TabStop = false;
            this.grpDifficulty.Text = "Select Difficulty";
            // 
            // btnDifficultyBack
            // 
            this.btnDifficultyBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDifficultyBack.Location = new System.Drawing.Point(90, 162);
            this.btnDifficultyBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDifficultyBack.Name = "btnDifficultyBack";
            this.btnDifficultyBack.Size = new System.Drawing.Size(90, 49);
            this.btnDifficultyBack.TabIndex = 4;
            this.btnDifficultyBack.Text = "Back";
            this.btnDifficultyBack.UseVisualStyleBackColor = true;
            // 
            // btnDifficultyNext
            // 
            this.btnDifficultyNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDifficultyNext.Location = new System.Drawing.Point(270, 162);
            this.btnDifficultyNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDifficultyNext.Name = "btnDifficultyNext";
            this.btnDifficultyNext.Size = new System.Drawing.Size(90, 49);
            this.btnDifficultyNext.TabIndex = 3;
            this.btnDifficultyNext.Text = "Next";
            this.btnDifficultyNext.UseVisualStyleBackColor = true;
            // 
            // rdoEasy
            // 
            this.rdoEasy.Location = new System.Drawing.Point(15, 31);
            this.rdoEasy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoEasy.Name = "rdoEasy";
            this.rdoEasy.Size = new System.Drawing.Size(368, 23);
            this.rdoEasy.TabIndex = 1;
            this.rdoEasy.Text = "Easy";
            this.rdoEasy.UseVisualStyleBackColor = true;
            this.rdoEasy.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged_1);
            // 
            // rdoNormal
            // 
            this.rdoNormal.AutoSize = true;
            this.rdoNormal.Location = new System.Drawing.Point(15, 60);
            this.rdoNormal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoNormal.Name = "rdoNormal";
            this.rdoNormal.Size = new System.Drawing.Size(83, 24);
            this.rdoNormal.TabIndex = 2;
            this.rdoNormal.Text = "Normal";
            this.rdoNormal.UseVisualStyleBackColor = true;
            // 
            // rdoHard
            // 
            this.rdoHard.AutoSize = true;
            this.rdoHard.Location = new System.Drawing.Point(15, 88);
            this.rdoHard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoHard.Name = "rdoHard";
            this.rdoHard.Size = new System.Drawing.Size(66, 24);
            this.rdoHard.TabIndex = 5;
            this.rdoHard.Text = "Hard";
            this.rdoHard.UseVisualStyleBackColor = true;
            // 
            // rdoBoss
            // 
            this.rdoBoss.AutoSize = true;
            this.rdoBoss.Location = new System.Drawing.Point(15, 115);
            this.rdoBoss.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoBoss.Name = "rdoBoss";
            this.rdoBoss.Size = new System.Drawing.Size(67, 24);
            this.rdoBoss.TabIndex = 6;
            this.rdoBoss.Text = "Boss";
            this.rdoBoss.UseVisualStyleBackColor = true;
            // 
            // pnlMarkSelect
            // 
            this.pnlMarkSelect.Controls.Add(this.grpMark);
            this.pnlMarkSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMarkSelect.Location = new System.Drawing.Point(0, 0);
            this.pnlMarkSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlMarkSelect.Name = "pnlMarkSelect";
            this.pnlMarkSelect.Size = new System.Drawing.Size(504, 300);
            this.pnlMarkSelect.TabIndex = 5;
            this.pnlMarkSelect.Visible = false;
            // 
            // grpMark
            // 
            this.grpMark.Controls.Add(this.btnMarkBack);
            this.grpMark.Controls.Add(this.btnStartGame);
            this.grpMark.Controls.Add(this.rdoO);
            this.grpMark.Controls.Add(this.rdoX);
            this.grpMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMark.Location = new System.Drawing.Point(15, 16);
            this.grpMark.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMark.Name = "grpMark";
            this.grpMark.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpMark.Size = new System.Drawing.Size(466, 263);
            this.grpMark.TabIndex = 1;
            this.grpMark.TabStop = false;
            this.grpMark.Text = "Choose Your Mark";
            this.grpMark.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnMarkBack
            // 
            this.btnMarkBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkBack.Location = new System.Drawing.Point(90, 162);
            this.btnMarkBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMarkBack.Name = "btnMarkBack";
            this.btnMarkBack.Size = new System.Drawing.Size(90, 49);
            this.btnMarkBack.TabIndex = 4;
            this.btnMarkBack.Text = "Back";
            this.btnMarkBack.UseVisualStyleBackColor = true;
            this.btnMarkBack.Click += new System.EventHandler(this.btnMarkBack_Click);
            // 
            // btnStartGame
            // 
            this.btnStartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGame.Location = new System.Drawing.Point(270, 162);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(90, 49);
            this.btnStartGame.TabIndex = 3;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // rdoO
            // 
            this.rdoO.AutoSize = true;
            this.rdoO.Location = new System.Drawing.Point(15, 98);
            this.rdoO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoO.Name = "rdoO";
            this.rdoO.Size = new System.Drawing.Size(244, 24);
            this.rdoO.TabIndex = 2;
            this.rdoO.Text = "O (goes second in round 1)";
            this.rdoO.UseVisualStyleBackColor = true;
            // 
            // rdoX
            // 
            this.rdoX.AutoSize = true;
            this.rdoX.Checked = true;
            this.rdoX.Location = new System.Drawing.Point(15, 49);
            this.rdoX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdoX.Name = "rdoX";
            this.rdoX.Size = new System.Drawing.Size(216, 24);
            this.rdoX.TabIndex = 1;
            this.rdoX.TabStop = true;
            this.rdoX.Text = "X (goes first in round 1)";
            this.rdoX.UseVisualStyleBackColor = true;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 683);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnCredits);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.lblGameTitle);
            this.Name = "frmMenu";
            this.Text = "Tic Tac Toe - GGWP";
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.pnlCenter.ResumeLayout(false);
            this.pnlModeSelect.ResumeLayout(false);
            this.grpMode.ResumeLayout(false);
            this.grpMode.PerformLayout();
            this.pnlVariantSelect.ResumeLayout(false);
            this.grpVariant.ResumeLayout(false);
            this.grpVariant.PerformLayout();
            this.pnlDifficultySelect.ResumeLayout(false);
            this.grpDifficulty.ResumeLayout(false);
            this.grpDifficulty.PerformLayout();
            this.pnlMarkSelect.ResumeLayout(false);
            this.grpMark.ResumeLayout(false);
            this.grpMark.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnCredits;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel pnlModeSelect;
        private System.Windows.Forms.GroupBox grpMode;
        private System.Windows.Forms.RadioButton rdoPvP;
        private System.Windows.Forms.RadioButton rdoPvE;
        private System.Windows.Forms.Button btnModeNext;
        private System.Windows.Forms.Button btnModeBack;
        private System.Windows.Forms.Panel pnlVariantSelect;
        private System.Windows.Forms.GroupBox grpVariant;
        private System.Windows.Forms.RadioButton rdoBasic;
        private System.Windows.Forms.RadioButton rdoLimited;
        private System.Windows.Forms.RadioButton rdoAdvanced;
        private System.Windows.Forms.Button btnVariantBack;
        private System.Windows.Forms.Button btnVariantNext;
        private System.Windows.Forms.Panel pnlMarkSelect;
        private System.Windows.Forms.GroupBox grpMark;
        private System.Windows.Forms.Button btnMarkBack;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.RadioButton rdoO;
        private System.Windows.Forms.RadioButton rdoX;
        private System.Windows.Forms.Panel pnlDifficultySelect;
        private System.Windows.Forms.GroupBox grpDifficulty;
        private System.Windows.Forms.Button btnDifficultyBack;
        private System.Windows.Forms.Button btnDifficultyNext;
        private System.Windows.Forms.RadioButton rdoNormal;
        private System.Windows.Forms.RadioButton rdoEasy;
        private System.Windows.Forms.RadioButton rdoHard;
        private System.Windows.Forms.RadioButton rdoBoss;
    }
}