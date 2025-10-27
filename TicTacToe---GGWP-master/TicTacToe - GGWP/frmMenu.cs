using System;
using System.Windows.Forms;
using System.Media;
using WMPLib;

namespace TicTacToe___GGWP
{
    /// <summary>
    /// Form Menu chính của game Tic Tac Toe
    /// Quản lý luồng chọn chế độ chơi, độ khó, kiểu chơi và bắt đầu game
    /// </summary>
    public partial class frmMenu : Form
    {
        // ═══════════════════════════════════════════════════════════════
        // VÙNG: ENUMS & CẤU TRÚC DỮ LIỆU
        // ═══════════════════════════════════════════════════════════════
        #region Enums & Cấu trúc dữ liệu

        /// <summary>
        /// Chế độ chơi: Người vs Máy (PvE) hoặc Người vs Người (PvP)
        /// </summary>
        public enum GameMode { PvE, PvP }

        /// <summary>
        /// Biến thể gameplay: Basic (cơ bản), Limited (giới hạn), Advanced (nâng cao)
        /// </summary>
        public enum Variant { Basic, Limited, Advanced }

        /// <summary>
        /// Ký hiệu quân cờ: X hoặc O
        /// </summary>
        public enum Mark { X, O }

        /// <summary>
        /// Độ khó của Bot AI: Easy (dễ), Normal (trung bình), Hard (khó), Boss (cực khó)
        /// </summary>
        public enum BotLevel { Easy, Normal, Hard, Boss }

        /// <summary>
        /// Class lưu trữ cấu hình game được chọn bởi người chơi
        /// </summary>
        public class GameConfig
        {
            public GameMode Mode { get; set; }          // Chế độ chơi
            public Variant Variant { get; set; }        // Kiểu chơi
            public Mark PlayerMark { get; set; }        // Dấu của người chơi
            public bool Player1Starts { get; set; }     // Player 1 có đi trước không
            public BotLevel Difficulty { get; set; }    // Độ khó bot (chỉ dùng cho PvE)
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: BIẾN PRIVATE
        // ═══════════════════════════════════════════════════════════════
        #region Biến Private

        /// <summary>
        /// Windows Media Player để phát nhạc nền menu
        /// </summary>
        private WindowsMediaPlayer _bgMusic;

        /// <summary>
        /// Cấu hình game hiện tại được xây dựng qua từng bước chọn
        /// </summary>
        private GameConfig _config = new GameConfig();

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: CONSTRUCTOR & KHỞI TẠO
        // ═══════════════════════════════════════════════════════════════
        #region Constructor & Khởi tạo

        /// <summary>
        /// Constructor - Khởi tạo form menu và bắt đầu phát nhạc nền
        /// </summary>
        public frmMenu()
        {
            InitializeComponent();
            InitializeBackgroundMusic();
            InitUiState();
        }

        /// <summary>
        /// Khởi tạo và cấu hình nhạc nền cho menu
        /// </summary>
        private void InitializeBackgroundMusic()
        {
            _bgMusic = new WindowsMediaPlayer();
            _bgMusic.URL = @"Sounds\start-game.mp3";
            _bgMusic.settings.setMode("loop", true);    // Phát lặp vô hạn
            _bgMusic.settings.volume = 60;               // Âm lượng 0-100
            _bgMusic.controls.play();
        }

        /// <summary>
        /// Khởi tạo trạng thái ban đầu của giao diện menu
        /// - Reset cấu hình game
        /// - Đưa các panel về đúng vị trí
        /// - Ẩn tất cả panel con
        /// - Set giá trị mặc định cho các radio button
        /// - Hiển thị menu chính
        /// </summary>
        private void InitUiState()
        {
            // Reset cấu hình cho phiên mới
            _config = new GameConfig();

            // Đảm bảo các panel con nằm đúng vị trí trong pnlCenter
            EnsurePanelInCenter(pnlModeSelect);
            EnsurePanelInCenter(pnlVariantSelect);
            EnsurePanelInCenter(pnlMarkSelect);
            EnsurePanelInCenter(pnlDifficultySelect);

            // Ẩn tất cả các panel con
            if (pnlModeSelect != null) pnlModeSelect.Visible = false;
            if (pnlVariantSelect != null) pnlVariantSelect.Visible = false;
            if (pnlMarkSelect != null) pnlMarkSelect.Visible = false;
            if (pnlDifficultySelect != null) pnlDifficultySelect.Visible = false;

            // Set giá trị mặc định cho radio button chọn dấu (X được chọn)
            if (rdoX != null) { rdoX.Checked = true; }
            if (rdoO != null) { rdoO.Checked = false; }

            // Bỏ chọn tất cả radio button chế độ chơi
            if (rdoPvE != null) rdoPvE.Checked = false;
            if (rdoPvP != null) rdoPvP.Checked = false;

            // Bỏ chọn tất cả radio button kiểu chơi
            if (rdoBasic != null) rdoBasic.Checked = false;
            if (rdoLimited != null) rdoLimited.Checked = false;
            if (rdoAdvanced != null) rdoAdvanced.Checked = false;

            // Bỏ chọn tất cả radio button độ khó
            if (rdoEasy != null) rdoEasy.Checked = false;
            if (rdoNormal != null) rdoNormal.Checked = false;
            if (rdoHard != null) rdoHard.Checked = false;
            if (rdoBoss != null) rdoBoss.Checked = false;

            // Đảm bảo Difficulty panel đã gán sự kiện cho Next/Back
            EnsureDifficultyPanelWired();

            // Hiển thị menu chính
            ToggleMainMenu(true);


        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: QUẢN LÝ PANEL & UI
        // ═══════════════════════════════════════════════════════════════
        #region Quản lý Panel & UI

        /// <summary>
        /// Đảm bảo một panel đang thuộc pnlCenter
        /// Nếu panel đang ở nơi khác, di chuyển nó vào pnlCenter
        /// </summary>
        /// <param name="panel">Panel cần kiểm tra và di chuyển</param>
        private void EnsurePanelInCenter(Panel panel)
        {
            if (panel == null) return;

            // Nếu panel chưa thuộc pnlCenter
            if (panel.Parent != pnlCenter)
            {
                // Xóa khỏi parent cũ (nếu có)
                if (panel.Parent != null)
                    panel.Parent.Controls.Remove(panel);

                // Thêm vào pnlCenter
                pnlCenter.Controls.Add(panel);
                panel.Dock = DockStyle.Fill;
            }
        }

        /// <summary>
        /// Đảm bảo panel Difficulty nằm đúng chỗ và đã gán sự kiện Next/Back
        /// Đồng thời set giá trị mặc định là Easy nếu chưa có gì được chọn
        /// </summary>
        private void EnsureDifficultyPanelWired()
        {
            // Đảm bảo panel nằm trong pnlCenter
            EnsurePanelInCenter(pnlDifficultySelect);

            // Gán sự kiện click cho nút Next (gỡ handler cũ trước để tránh trùng)
            if (btnDifficultyNext != null)
            {
                btnDifficultyNext.Click -= btnDifficultyNext_Click;
                btnDifficultyNext.Click += btnDifficultyNext_Click;
            }

            // Gán sự kiện click cho nút Back
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

        /// <summary>
        /// Bật/tắt hiển thị menu chính (Play, Options, Credits)
        /// </summary>
        /// <param name="show">true = hiện, false = ẩn</param>
        private void ToggleMainMenu(bool show)
        {
            btnPlay.Visible = show;
            btnOptions.Visible = show;
            btnCredits.Visible = show;
        }

        /// <summary>
        /// Hiển thị một panel cụ thể và ẩn tất cả các panel khác trong pnlCenter
        /// </summary>
        /// <param name="target">Panel cần hiển thị (null = ẩn tất cả)</param>
        private void ShowOnlyPanel(Panel target)
        {
            // Ẩn tất cả các control trong pnlCenter
            foreach (Control c in pnlCenter.Controls)
                c.Visible = (c == target);

            // Hiển thị panel được chọn
            if (target != null)
            {
                target.Visible = true;
                target.BringToFront();
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: QUẢN LÝ ÂM THANH
        // ═══════════════════════════════════════════════════════════════
        #region Quản lý âm thanh

        /// <summary>
        /// Tiếp tục phát nhạc nền (dùng khi quay lại từ form khác)
        /// </summary>
        public void ResumeMusic()
        {
            if (_bgMusic != null)
                _bgMusic.controls.play();
        }

        /// <summary>
        /// Phát âm thanh click chuột cho các button
        /// </summary>
        private void PlayClickSound()
        {
            try
            {
                WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
                wplayer.URL = @"Sounds\mouse-click-117076.mp3";
                wplayer.controls.play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi phát âm thanh: " + ex.Message);
            }
        }

        /// <summary>
        /// Đệ quy thêm âm thanh click cho tất cả button trong một control
        /// </summary>
        /// <param name="parent">Control cha cần duyệt qua</param>
        private void AddClickSoundToAllButtons(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Nếu là button thì gán sự kiện click
                if (control is Button button)
                {
                    // Gỡ handler cũ (nếu có) để tránh trùng lặp
                    button.Click -= (s, e) => PlayClickSound();
                    button.Click += (s, e) => PlayClickSound();
                }

                // Nếu control có con (panel, groupbox, v.v.) thì duyệt tiếp
                if (control.HasChildren)
                    AddClickSoundToAllButtons(control);
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: XỬ LÝ SỰ KIỆN FORM
        // ═══════════════════════════════════════════════════════════════
        #region Xử lý sự kiện Form

        /// <summary>
        /// Sự kiện khi form load - Thêm âm thanh click cho tất cả button
        /// </summary>
        private void frmMenu_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                AddClickSoundToAllButtons(control);
            }
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: XỬ LÝ SỰ KIỆN MENU CHÍNH
        // ═══════════════════════════════════════════════════════════════
        #region Xử lý sự kiện Menu chính

        /// <summary>
        /// Xử lý khi nhấn nút PLAY - Bắt đầu luồng chọn cấu hình game
        /// </summary>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            _config = new GameConfig(); // Reset cấu hình trận mới
            ToggleMainMenu(false);
            ShowOnlyPanel(pnlModeSelect);
        }

        /// <summary>
        /// Xử lý khi nhấn nút OPTIONS - Hiện thông báo đang phát triển
        /// </summary>
        private void btnOptions_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            ToggleMainMenu(false);
            MessageBox.Show("Tuỳ chọn nhạc nền và hiệu ứng sẽ được thêm sau.",
                            "Options (Đang phát triển)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ToggleMainMenu(true);
        }

        /// <summary>
        /// Xử lý khi nhấn nút CREDITS - Hiển thị thông tin nhóm phát triển
        /// </summary>
        private void btnCredits_Click(object sender, EventArgs e)
        {
            PlayClickSound();
            ToggleMainMenu(false);
            MessageBox.Show("Nhóm phát triển GGWP Studio\n\n- Lê Kim Nhật Huy\n- Thành viên khác (cập nhật sau)",
                            "Credits", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ToggleMainMenu(true);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: XỬ LÝ SỰ KIỆN CHỌN CHỂ ĐỘ (MODE SELECT)
        // ═══════════════════════════════════════════════════════════════
        #region Xử lý sự kiện chọn chế độ

        /// <summary>
        /// Xử lý khi nhấn nút NEXT ở màn chọn chế độ
        /// - Kiểm tra đã chọn PvE hoặc PvP chưa
        /// - Nếu PvE: chuyển sang màn chọn độ khó
        /// - Nếu PvP: chuyển sang màn chọn kiểu chơi
        /// </summary>
        private void btnModeNext_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn chế độ chưa
            if (!rdoPvE.Checked && !rdoPvP.Checked)
            {
                MessageBox.Show("Hãy chọn chế độ: PvE hoặc PvP.", "Thiếu lựa chọn");
                return;
            }

            // Lưu chế độ đã chọn vào config
            _config.Mode = rdoPvE.Checked ? GameMode.PvE : GameMode.PvP;

            // Nếu chọn PvE thì phải chọn độ khó trước
            if (_config.Mode == GameMode.PvE)
            {
                EnsureDifficultyPanelWired(); // Đảm bảo panel difficulty sẵn sàng
                ShowOnlyPanel(pnlDifficultySelect);
            }
            else // PvP thì chuyển thẳng sang chọn kiểu chơi
            {
                ShowOnlyPanel(pnlVariantSelect);
            }
        }

        /// <summary>
        /// Xử lý khi nhấn nút BACK ở màn chọn chế độ - Quay lại menu chính
        /// </summary>
        private void btnModeBack_Click(object sender, EventArgs e)
        {
            ShowOnlyPanel(null);
            ToggleMainMenu(true);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: XỬ LÝ SỰ KIỆN CHỌN ĐỘ KHÓ (DIFFICULTY SELECT)
        // ═══════════════════════════════════════════════════════════════
        #region Xử lý sự kiện chọn độ khó

        /// <summary>
        /// Xử lý khi nhấn nút NEXT ở màn chọn độ khó
        /// - Kiểm tra đã chọn độ khó chưa
        /// - Lưu độ khó vào config
        /// - Chuyển sang màn chọn kiểu chơi
        /// </summary>
        private void btnDifficultyNext_Click(object sender, EventArgs e)
        {
            // Kiểm tra các radio button độ khó có tồn tại không
            if (rdoEasy == null || rdoNormal == null || rdoHard == null || rdoBoss == null)
            {
                MessageBox.Show("Thiếu control chọn độ khó trong Designer. Hãy tạo rdoEasy/rdoNormal/rdoHard/rdoBoss.",
                                "Lỗi Designer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra đã chọn độ khó chưa
            if (!(rdoEasy.Checked || rdoNormal.Checked || rdoHard.Checked || rdoBoss.Checked))
            {
                MessageBox.Show("Hãy chọn độ khó: Easy / Normal / Hard / Boss.", "Thiếu lựa chọn");
                return;
            }

            // Lưu độ khó đã chọn vào config
            if (rdoEasy.Checked) _config.Difficulty = BotLevel.Easy;
            else if (rdoNormal.Checked) _config.Difficulty = BotLevel.Normal;
            else if (rdoHard.Checked) _config.Difficulty = BotLevel.Hard;
            else _config.Difficulty = BotLevel.Boss;

            // Chuyển sang màn chọn kiểu chơi
            ShowOnlyPanel(pnlVariantSelect);
        }

        /// <summary>
        /// Xử lý khi nhấn nút BACK ở màn chọn độ khó - Quay lại màn chọn chế độ
        /// </summary>
        private void btnDifficultyBack_Click(object sender, EventArgs e)
        {
            ShowOnlyPanel(pnlModeSelect);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: XỬ LÝ SỰ KIỆN CHỌN KIỂU CHƠI (VARIANT SELECT)
        // ═══════════════════════════════════════════════════════════════
        #region Xử lý sự kiện chọn kiểu chơi

        /// <summary>
        /// Xử lý khi nhấn nút NEXT ở màn chọn kiểu chơi
        /// - Kiểm tra đã chọn kiểu chơi chưa
        /// - Lưu kiểu chơi vào config
        /// - Chuyển sang màn chọn dấu
        /// </summary>
        private void btnVariantNext_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn kiểu chơi chưa
            if (!rdoBasic.Checked && !rdoLimited.Checked && !rdoAdvanced.Checked)
            {
                MessageBox.Show("Vui lòng chọn kiểu chơi: Basic / Limited / Advanced.",
                                "Thiếu lựa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu kiểu chơi đã chọn vào config
            if (rdoBasic.Checked) _config.Variant = Variant.Basic;
            else if (rdoLimited.Checked) _config.Variant = Variant.Limited;
            else _config.Variant = Variant.Advanced;

            // Chuyển sang màn chọn dấu
            ShowOnlyPanel(pnlMarkSelect);
        }

        /// <summary>
        /// Xử lý khi nhấn nút BACK ở màn chọn kiểu chơi
        /// - Nếu PvE: quay lại màn chọn độ khó
        /// - Nếu PvP: quay lại màn chọn chế độ
        /// </summary>
        private void btnVariantBack_Click(object sender, EventArgs e)
        {
            if (_config.Mode == GameMode.PvE)
                ShowOnlyPanel(pnlDifficultySelect);
            else
                ShowOnlyPanel(pnlModeSelect);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: XỬ LÝ SỰ KIỆN CHỌN DẤU & BẮT ĐẦU GAME (MARK SELECT)
        // ═══════════════════════════════════════════════════════════════
        #region Xử lý sự kiện chọn dấu & bắt đầu game

        /// <summary>
        /// Xử lý khi nhấn nút START GAME
        /// - Kiểm tra đã chọn dấu chưa
        /// - Lưu dấu vào config
        /// - Xác định ai đi trước
        /// - Dừng nhạc nền menu
        /// - Mở form gameplay
        /// </summary>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            // Kiểm tra đã chọn dấu chưa
            if (!rdoX.Checked && !rdoO.Checked)
            {
                MessageBox.Show("Vui lòng chọn dấu (X hoặc O).", "Thiếu lựa chọn",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu dấu đã chọn vào config
            _config.PlayerMark = rdoX.Checked ? Mark.X : Mark.O;

            // Xác định ai đi trước:
            // - Ván 1 PvP: Player1 (X) đi trước
            // - Ván 1 PvE: Chọn X thì người đi trước, chọn O thì bot đi trước
            _config.Player1Starts = (_config.Mode == GameMode.PvP) || (_config.PlayerMark == Mark.X);

            // Dừng nhạc nền menu
            if (_bgMusic != null)
                _bgMusic.controls.pause();

            // Tạo và mở form gameplay
            var game = new frmGamePlay(this, _config); // Truyền this để có thể resume nhạc sau

            // Xử lý khi đóng form gameplay
            game.FormClosed += (s, args) =>
            {
                this.Show();        // Hiện lại form menu
                InitUiState();      // Reset lại trạng thái UI
            };

            game.Show();
            this.Hide();
        }

        /// <summary>
        /// Xử lý khi nhấn nút BACK ở màn chọn dấu - Quay lại màn chọn kiểu chơi
        /// </summary>
        private void btnMarkBack_Click(object sender, EventArgs e)
        {
            ShowOnlyPanel(pnlVariantSelect);
        }

        #endregion

        // ═══════════════════════════════════════════════════════════════
        // VÙNG: SỰ KIỆN TRỐNG (ĐỂ DESIGNER KHÔNG LỖI)
        // ═══════════════════════════════════════════════════════════════
        #region Sự kiện trống để Designer không lỗi

        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void grpMode_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void pnlModeSelect_Paint(object sender, PaintEventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged_1(object sender, EventArgs e) { }

        #endregion
    }
}