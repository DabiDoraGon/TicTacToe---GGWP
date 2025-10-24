using System;
using System.Windows.Forms;

namespace TicTacToe___GGWP
{
    public partial class frmMenu : Form
    {
        // ================= ENUM & CONFIG =================
        public enum GameMode { PvE, PvP }
        public enum Variant { Basic, Limited, Advanced }
        public enum Mark { X, O }
        public enum BotLevel { Easy, Normal, Hard, Boss }

        public class GameConfig
        {
            public GameMode Mode { get; set; }
            public Variant Variant { get; set; }
            public Mark PlayerMark { get; set; }
            public bool Player1Starts { get; set; }
            public BotLevel Difficulty { get; set; }
        }

        private GameConfig _config = new GameConfig();

        // ================= CONSTRUCTOR =================
        public frmMenu()
        {
            InitializeComponent();
            InitUiState();
        }

        // ================= INITIAL SETUP =================
        private void InitUiState()
        {
            // Reset config cho phiên mới
            _config = new GameConfig();

            // Đưa các panel con (kể cả Difficulty) về đúng chỗ trong pnlCenter
            EnsurePanelInCenter(pnlModeSelect);
            EnsurePanelInCenter(pnlVariantSelect);
            EnsurePanelInCenter(pnlMarkSelect);
            EnsurePanelInCenter(pnlDifficultySelect);

            // Ẩn tất cả panel con
            if (pnlModeSelect != null) pnlModeSelect.Visible = false;
            if (pnlVariantSelect != null) pnlVariantSelect.Visible = false;
            if (pnlMarkSelect != null) pnlMarkSelect.Visible = false;
            if (pnlDifficultySelect != null) pnlDifficultySelect.Visible = false;

            // Mặc định tick
            if (rdoX != null) { rdoX.Checked = true; }
            if (rdoO != null) { rdoO.Checked = false; }

            if (rdoPvE != null) rdoPvE.Checked = false;
            if (rdoPvP != null) rdoPvP.Checked = false;

            if (rdoBasic != null) rdoBasic.Checked = false;
            if (rdoLimited != null) rdoLimited.Checked = false;
            if (rdoAdvanced != null) rdoAdvanced.Checked = false;

            if (rdoEasy != null) rdoEasy.Checked = false;
            if (rdoNormal != null) rdoNormal.Checked = false;
            if (rdoHard != null) rdoHard.Checked = false;
            if (rdoBoss != null) rdoBoss.Checked = false;

            // Bảo đảm Difficulty panel đã gán sự kiện cho Next/Back
            EnsureDifficultyPanelWired();

            ToggleMainMenu(true);
        }

        // Bảo đảm 1 panel đang thuộc pnlCenter (để ShowOnlyPanel xử lý được)
        private void EnsurePanelInCenter(Panel panel)
        {
            if (panel == null) return;
            if (panel.Parent != pnlCenter)
            {
                if (panel.Parent != null)
                    panel.Parent.Controls.Remove(panel);
                pnlCenter.Controls.Add(panel);
                panel.Dock = DockStyle.Fill;
            }
        }

        // Đảm bảo panel Difficulty nằm đúng chỗ & đã gán sự kiện Next/Back
        private void EnsureDifficultyPanelWired()
        {
            EnsurePanelInCenter(pnlDifficultySelect);

            // Gán sự kiện click phòng Designer chưa gán
            if (btnDifficultyNext != null)
            {
                btnDifficultyNext.Click -= btnDifficultyNext_Click;
                btnDifficultyNext.Click += btnDifficultyNext_Click;
            }
            if (btnDifficultyBack != null)
            {
                btnDifficultyBack.Click -= btnDifficultyBack_Click;
                btnDifficultyBack.Click += btnDifficultyBack_Click;
            }

            // Nếu chưa chọn độ khó nào → mặc định Easy
            if (rdoEasy != null && rdoNormal != null && rdoHard != null && rdoBoss != null)
            {
                if (!rdoEasy.Checked && !rdoNormal.Checked && !rdoHard.Checked && !rdoBoss.Checked)
                    rdoEasy.Checked = true;
            }
        }

        // ================= CORE UI CONTROL =================
        private void ToggleMainMenu(bool show)
        {
            btnPlay.Visible = show;
            btnOptions.Visible = show;
            btnCredits.Visible = show;
        }

        // Chỉ quản lý các panel nằm bên trong pnlCenter
        private void ShowOnlyPanel(Panel target)
        {
            foreach (Control c in pnlCenter.Controls)
                c.Visible = (c == target);

            if (target != null)
            {
                target.Visible = true;
                target.BringToFront();
            }
        }

        // ================= EVENT HANDLERS =================

        private void frmMenu_Load(object sender, EventArgs e)
        {
            // Có thể add hiệu ứng khởi động tại đây
        }

        // PLAY → vào chọn Mode
        private void btnPlay_Click(object sender, EventArgs e)
        {
            _config = new GameConfig(); // reset cấu hình trận mới
            ToggleMainMenu(false);
            ShowOnlyPanel(pnlModeSelect);
        }

        // Mode Next
        private void btnModeNext_Click(object sender, EventArgs e)
        {
            if (!rdoPvE.Checked && !rdoPvP.Checked)
            {
                MessageBox.Show("Hãy chọn chế độ: PvE hoặc PvP.", "Thiếu lựa chọn");
                return;
            }

            _config.Mode = rdoPvE.Checked ? GameMode.PvE : GameMode.PvP;

            if (_config.Mode == GameMode.PvE)
            {
                EnsureDifficultyPanelWired(); // đảm bảo panel difficulty sẵn sàng
                ShowOnlyPanel(pnlDifficultySelect);
            }
            else
            {
                ShowOnlyPanel(pnlVariantSelect);
            }
        }

        // Mode Back
        private void btnModeBack_Click(object sender, EventArgs e)
        {
            ShowOnlyPanel(null);
            ToggleMainMenu(true);
        }

        // Difficulty Next
        private void btnDifficultyNext_Click(object sender, EventArgs e)
        {
            // Nếu vì lý do nào đó 4 radio chưa có → chặn lại
            if (rdoEasy == null || rdoNormal == null || rdoHard == null || rdoBoss == null)
            {
                MessageBox.Show("Thiếu control chọn độ khó trong Designer. Hãy tạo rdoEasy/rdoNormal/rdoHard/rdoBoss.",
                                "Lỗi Designer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!(rdoEasy.Checked || rdoNormal.Checked || rdoHard.Checked || rdoBoss.Checked))
            {
                MessageBox.Show("Hãy chọn độ khó: Easy / Normal / Hard / Boss.", "Thiếu lựa chọn");
                return;
            }

            if (rdoEasy.Checked) _config.Difficulty = BotLevel.Easy;
            else if (rdoNormal.Checked) _config.Difficulty = BotLevel.Normal;
            else if (rdoHard.Checked) _config.Difficulty = BotLevel.Hard;
            else _config.Difficulty = BotLevel.Boss;

            ShowOnlyPanel(pnlVariantSelect);
        }

        // Difficulty Back
        private void btnDifficultyBack_Click(object sender, EventArgs e)
        {
            ShowOnlyPanel(pnlModeSelect);
        }

        // Variant Next
        private void btnVariantNext_Click(object sender, EventArgs e)
        {
            if (!rdoBasic.Checked && !rdoLimited.Checked && !rdoAdvanced.Checked)
            {
                MessageBox.Show("Vui lòng chọn kiểu chơi: Basic / Limited / Advanced.",
                                "Thiếu lựa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdoBasic.Checked) _config.Variant = Variant.Basic;
            else if (rdoLimited.Checked) _config.Variant = Variant.Limited;
            else _config.Variant = Variant.Advanced;

            ShowOnlyPanel(pnlMarkSelect);
        }

        // Variant Back
        private void btnVariantBack_Click(object sender, EventArgs e)
        {
            // Nếu từ PvE đi qua thì quay lại Difficulty; nếu PvP thì quay lại Mode
            if (_config.Mode == GameMode.PvE)
                ShowOnlyPanel(pnlDifficultySelect);
            else
                ShowOnlyPanel(pnlModeSelect);
        }

        // Mark Start
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (!rdoX.Checked && !rdoO.Checked)
            {
                MessageBox.Show("Vui lòng chọn dấu (X hoặc O).", "Thiếu lựa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _config.PlayerMark = rdoX.Checked ? Mark.X : Mark.O;

            // Ván 1: PvP → Player1 (X) đi trước; PvE → chọn X thì người đi trước
            _config.Player1Starts = (_config.Mode == GameMode.PvP) || (_config.PlayerMark == Mark.X);

            var game = new frmGamePlay(_config);

            // Khi form gameplay đóng → quay về menu & reset UI
            game.FormClosed += (s, args) =>
            {
                this.Show();
                InitUiState();
            };

            game.Show();
            this.Hide();
        }

        // Mark Back
        private void btnMarkBack_Click(object sender, EventArgs e)
        {
            ShowOnlyPanel(pnlVariantSelect);
        }

        // OPTIONS
        private void btnOptions_Click(object sender, EventArgs e)
        {
            ToggleMainMenu(false);
            MessageBox.Show("Tuỳ chọn nhạc nền và hiệu ứng sẽ được thêm sau.",
                            "Options (Đang phát triển)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ToggleMainMenu(true);
        }

        // CREDITS
        private void btnCredits_Click(object sender, EventArgs e)
        {
            ToggleMainMenu(false);
            MessageBox.Show("Nhóm phát triển GGWP Studio\n\n- Lê Kim Nhật Huy\n- Thành viên khác (cập nhật sau)",
                            "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ToggleMainMenu(true);
        }

        // ====== Handlers trống để Designer không lỗi nếu còn gán ======
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void grpMode_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pnlModeSelect_Paint(object sender, PaintEventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { } // rdoPvE
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { } // rdoPvP
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e) { }
    }
}
