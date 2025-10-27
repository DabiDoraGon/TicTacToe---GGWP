namespace TicTacToe___GGWP
{
    partial class frmResult
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnShowLeaderboard = new System.Windows.Forms.Button();

            // 
            // frmResult
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowLeaderboard);
            this.Text = "Kết quả trận đấu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Size = new System.Drawing.Size(400, 50);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblScore
            // 
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblScore.Location = new System.Drawing.Point(0, 80);
            this.lblScore.Size = new System.Drawing.Size(400, 30);
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 130);
            this.txtName.Size = new System.Drawing.Size(160, 22);
            this.txtName.PlaceholderText = "Nhập tên của bạn";

            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 170);
            this.btnSave.Size = new System.Drawing.Size(160, 35);
            this.btnSave.Text = "Lưu kết quả";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnShowLeaderboard
            // 
            this.btnShowLeaderboard.Location = new System.Drawing.Point(120, 220);
            this.btnShowLeaderboard.Size = new System.Drawing.Size(160, 35);
            this.btnShowLeaderboard.Text = "Xem bảng xếp hạng";
            this.btnShowLeaderboard.Click += new System.EventHandler(this.btnShowLeaderboard_Click);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnShowLeaderboard;
    }
}
