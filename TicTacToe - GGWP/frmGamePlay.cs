using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe___GGWP
{
    public partial class frmGamePlay : Form
    {
        // =================== SCORE & TIMER ===================
        private int _scoreLeft = 0;   // Player (PvE) / Player1 (PvP)
        private int _scoreRight = 0;  // Bot (PvE) / Player2 (PvP)
        private int _turnSeconds = 0; // Countdown cho Boss (giây)

        // =================== RULES INTERFACE ===================
        public interface IGameRules
        {
            int Size { get; }                // 3 hoặc 5
            int InARowToWin { get; }         // 3 (Basic), 4 (Advanced)
            bool TryPlace(int r, int c, char mark, char[,] board);
            bool CheckWin(char[,] board, out char winner);
            bool IsDraw(char[,] board);
            void Reset(char[,] board);
        }

        // ---------- Basic: 3x3, thắng 3 ----------
        public class BasicRules : IGameRules
        {
            public int Size { get { return 3; } }
            public int InARowToWin { get { return 3; } }

            public bool TryPlace(int r, int c, char mark, char[,] board)
            {
                if (board[r, c] == '\0') { board[r, c] = mark; return true; }
                return false;
            }

            public bool CheckWin(char[,] board, out char winner)
            {
                // hàng & cột
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, 0] != '\0' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    { winner = board[i, 0]; return true; }
                    if (board[0, i] != '\0' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    { winner = board[0, i]; return true; }
                }
                // chéo
                if (board[0, 0] != '\0' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                { winner = board[0, 0]; return true; }
                if (board[0, 2] != '\0' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                { winner = board[0, 2]; return true; }

                winner = '\0'; return false;
            }

            public bool IsDraw(char[,] board)
            {
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                        if (board[r, c] == '\0') return false;
                return true;
            }

            public void Reset(char[,] board)
            {
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                        board[r, c] = '\0';
            }
        }

        // ---------- Advanced: 5x5, thắng 4 ----------
        public class AdvancedRules : IGameRules
        {
            public int Size { get { return 5; } }
            public int InARowToWin { get { return 4; } }

            public bool TryPlace(int r, int c, char mark, char[,] board)
            {
                if (board[r, c] == '\0') { board[r, c] = mark; return true; }
                return false;
            }

            public bool CheckWin(char[,] board, out char winner)
            {
                int n = 5, k = 4;
                int[][] dirs = { new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 1, -1 } };
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        char m = board[r, c];
                        if (m == '\0') continue;
                        for (int di = 0; di < dirs.Length; di++)
                        {
                            int rr = r, cc = c, count = 0;
                            while (rr >= 0 && rr < n && cc >= 0 && cc < n && board[rr, cc] == m)
                            {
                                count++; rr += dirs[di][0]; cc += dirs[di][1];
                                if (count == k) { winner = m; return true; }
                            }
                        }
                    }
                }
                winner = '\0'; return false;
            }

            public bool IsDraw(char[,] board)
            {
                for (int r = 0; r < 5; r++)
                    for (int c = 0; c < 5; c++)
                        if (board[r, c] == '\0') return false;
                return true;
            }

            public void Reset(char[,] board)
            {
                for (int r = 0; r < 5; r++)
                    for (int c = 0; c < 5; c++)
                        board[r, c] = '\0';
            }
        }

        // ---------- Limited3: decorator giới hạn mỗi người tối đa 3 dấu ----------
        public class Limited3Decorator : IGameRules
        {
            private readonly IGameRules _inner;
            private readonly Queue<Point> _xQueue = new Queue<Point>();
            private readonly Queue<Point> _oQueue = new Queue<Point>();
            private readonly Action<int, int> _onRemove;

            public Limited3Decorator(IGameRules inner, Action<int, int> onRemove)
            {
                _inner = inner;
                _onRemove = onRemove;
            }

            public int Size { get { return _inner.Size; } }
            public int InARowToWin { get { return _inner.InARowToWin; } }

            public bool TryPlace(int r, int c, char mark, char[,] board)
            {
                Queue<Point> q = (mark == 'X') ? _xQueue : _oQueue;
                if (q.Count >= 3)
                {
                    Point old = q.Dequeue();
                    board[old.Y, old.X] = '\0';
                    if (_onRemove != null) _onRemove(old.Y, old.X);
                }

                bool ok = _inner.TryPlace(r, c, mark, board);
                if (ok) q.Enqueue(new Point(c, r)); // lưu (X=c, Y=r)
                return ok;
            }

            public bool CheckWin(char[,] board, out char winner) { return _inner.CheckWin(board, out winner); }
            public bool IsDraw(char[,] board) { return _inner.IsDraw(board); }
            public void Reset(char[,] board)
            {
                _inner.Reset(board);
                _xQueue.Clear();
                _oQueue.Clear();
            }
        }

        // =================== BOT STRATEGIES ===================
        public interface IMoveStrategy
        {
            Point Choose(char botMark, char humanMark, char[,] board, IGameRules rules, Random rng);
        }

        // Easy: random
        public class RandomBot : IMoveStrategy
        {
            public Point Choose(char botMark, char humanMark, char[,] board, IGameRules rules, Random rng)
            {
                var empty = new List<Point>();
                for (int r = 0; r < rules.Size; r++)
                    for (int c = 0; c < rules.Size; c++)
                        if (board[r, c] == '\0') empty.Add(new Point(c, r));
                return empty.Count == 0 ? new Point(-1, -1) : empty[rng.Next(empty.Count)];
            }
        }

        // Normal: ưu tiên center & góc
        public class CenterDiagBot : IMoveStrategy
        {
            public Point Choose(char botMark, char humanMark, char[,] board, IGameRules rules, Random rng)
            {
                int n = rules.Size;
                int mid = n / 2;
                if (board[mid, mid] == '\0') return new Point(mid, mid);

                Point[] corners = {
                    new Point(0,0), new Point(n-1,0),
                    new Point(0,n-1), new Point(n-1,n-1)
                };
                foreach (var p in corners)
                    if (board[p.Y, p.X] == '\0') return p;

                return new RandomBot().Choose(botMark, humanMark, board, rules, rng);
            }
        }

        // Hard/Boss: thắng được thì đánh, không thì chặn
        public class WinBlockBot : IMoveStrategy
        {
            private bool WouldWin(int r, int c, char mark, char[,] board, IGameRules rules)
            {
                if (board[r, c] != '\0') return false;
                board[r, c] = mark;
                char w;
                bool ok = rules.CheckWin(board, out w) && w == mark;
                board[r, c] = '\0';
                return ok;
            }

            public Point Choose(char botMark, char humanMark, char[,] board, IGameRules rules, Random rng)
            {
                int n = rules.Size;

                // 1) Nước thắng
                for (int r = 0; r < n; r++)
                    for (int c = 0; c < n; c++)
                        if (WouldWin(r, c, botMark, board, rules)) return new Point(c, r);

                // 2) Chặn người chơi
                for (int r = 0; r < n; r++)
                    for (int c = 0; c < n; c++)
                        if (WouldWin(r, c, humanMark, board, rules)) return new Point(c, r);

                // 3) Ưu tiên center/góc
                var best = new CenterDiagBot().Choose(botMark, humanMark, board, rules, rng);
                if (best.X >= 0) return best;

                // 4) Random
                return new RandomBot().Choose(botMark, humanMark, board, rules, rng);
            }
        }

        // =================== FORM STATE ===================
        private readonly frmMenu.GameConfig _config;
        private IGameRules _rules;
        private IMoveStrategy _bot;  // null nếu PvP
        private char[,] _board;
        private char _current;       // 'X' / 'O'
        private readonly Dictionary<Point, Button> _btnMap = new Dictionary<Point, Button>();
        private readonly Random _rng = new Random();

        // Nếu Designer chưa có, 2 control này sẽ được tạo runtime
        private Label lblStatus;
        private TableLayoutPanel tblBoard;

        public frmGamePlay(frmMenu.GameConfig config)
        {
            InitializeComponent();

            // 1) Nhận config ngay đầu (đừng dùng _config trước khi gán)
            _config = config;

            // 2) Sửa Timer bot để gọi đúng handler (tránh Botmove cũ từ Designer)
            if (tmrBot != null)
            {
                tmrBot.Tick -= Botmove;
                tmrBot.Tick -= tmrBot_Tick;
                tmrBot.Tick += tmrBot_Tick;
            }

            // 3) Khởi tạo điểm + hiển thị label điểm
            _scoreLeft = 0;
            _scoreRight = 0;

            // Cho label tự giãn, anchor đúng
            lblPlayerWin.AutoSize = true;
            lblBotWin.AutoSize = true;
            lblPlayerWin.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            lblBotWin.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            UpdateScoreLabels();

            // 4) Ẩn 9 nút cũ nếu còn (không lỗi nếu đã xóa)
            try
            {
                button1.Visible = button2.Visible = button3.Visible =
                button4.Visible = button5.Visible = button6.Visible =
                button7.Visible = button8.Visible = button9.Visible = false;
            }
            catch { }

            if (btnReset != null) btnReset.Click += btnReset_Click;

            // 5) Tạo lblStatus + tblBoard nếu Designer chưa có
            EnsureRuntimeControls();

            // 6) Chọn luật theo Variant (+ Limited3 nếu cần)
            if (_config.Variant == frmMenu.Variant.Advanced) _rules = new AdvancedRules();
            else _rules = new BasicRules();

            if (_config.Variant == frmMenu.Variant.Limited)
                _rules = new Limited3Decorator(_rules, RemoveMarkUi);

            // 7) Chọn bot theo độ khó (chỉ PvE)
            if (_config.Mode == frmMenu.GameMode.PvE)
            {
                if (_config.Difficulty == frmMenu.BotLevel.Easy) _bot = new RandomBot();
                else if (_config.Difficulty == frmMenu.BotLevel.Normal) _bot = new CenterDiagBot();
                else _bot = new WinBlockBot(); // Hard/Boss
            }
            else _bot = null;

            // 8) Tạo bàn cờ + sắp xếp layout responsive
            _board = new char[_rules.Size, _rules.Size];
            BuildBoard(_rules.Size);
            SetupResponsiveLayout();   // <— GỌI HÀM LAYOUT Ở ĐÂY

            // 9) Bắt đầu ván
            RestartGame();
        }

        // =================== UI HELPERS ===================
        private void EnsureRuntimeControls()
        {
            if (lblStatus == null)
            {
                lblStatus = new Label
                {
                    AutoSize = false,
                    Dock = DockStyle.Top,
                    Height = 36,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Text = "Ready"
                };
                this.Controls.Add(lblStatus);
                lblStatus.BringToFront();
            }

            if (tblBoard == null)
            {
                tblBoard = new TableLayoutPanel
                {
                    Dock = DockStyle.Top,
                    Height = 540,
                    Width = 540,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                    BackColor = Color.Gainsboro,
                    Margin = new Padding(0, 8, 0, 8)
                };
                this.Controls.Add(tblBoard);
                tblBoard.BringToFront();
            }
        }

        private void BuildBoard(int size)
        {
            tblBoard.SuspendLayout();
            tblBoard.Controls.Clear();
            tblBoard.RowStyles.Clear();
            tblBoard.ColumnStyles.Clear();

            tblBoard.RowCount = size;
            tblBoard.ColumnCount = size;

            for (int i = 0; i < size; i++)
            {
                tblBoard.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / size));
                tblBoard.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / size));
            }

            _btnMap.Clear();
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    var btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", size == 3 ? 28 : 20, FontStyle.Bold),
                        Text = "",
                        Tag = new Point(c, r),
                        BackColor = Color.White
                    };
                    btn.Click += OnCellClick;

                    _btnMap[new Point(c, r)] = btn;
                    tblBoard.Controls.Add(btn, c, r);
                }
            }

            tblBoard.ResumeLayout();
        }

        private void RemoveMarkUi(int r, int c)
        {
            var key = new Point(c, r);
            if (_btnMap.ContainsKey(key))
            {
                _btnMap[key].Text = "";
                _btnMap[key].BackColor = Color.White;
                _btnMap[key].Enabled = true;
            }
        }

        private void RefreshBoardUi()
        {
            foreach (var kv in _btnMap)
            {
                int r = kv.Key.Y, c = kv.Key.X;
                char ch = _board[r, c];
                var b = kv.Value;
                b.Text = ch == '\0' ? "" : ch.ToString();

                // Chỉ enable ô trống & không phải đang lượt bot
                bool isEmpty = (ch == '\0');
                b.Enabled = isEmpty && (tmrBot == null || !tmrBot.Enabled);
                b.BackColor = (ch == '\0') ? Color.White : GetColorForMark(ch);
            }
        }

        private void UpdateScoreLabels()
        {
            if (_config.Mode == frmMenu.GameMode.PvE)
            {
                lblPlayerWin.Text = "Player: " + _scoreLeft;
                lblBotWin.Text = "Bot: " + _scoreRight;
            }
            else
            {
                lblPlayerWin.Text = "Player 1: " + _scoreLeft;
                lblBotWin.Text = "Player 2: " + _scoreRight;
            }
        }


        // =================== GAME FLOW ===================
        private void RestartGame()
        {
            if (tmrBot != null) tmrBot.Stop();
            if (tmrTurn != null) tmrTurn.Stop();
            _turnSeconds = 0;

            _rules.Reset(_board);
            ClearBoardColors();
            _current = _config.Player1Starts ? 'X' : 'O';
            lblStatus.Text = "Turn: " + _current;
            RefreshBoardUi();

            // PvE & người chọn O → bot đi trước
            if (_config.Mode == frmMenu.GameMode.PvE && _config.PlayerMark == frmMenu.Mark.O)
            {
                StartBotTurn();
                return;
            }

            // Boss countdown nếu tới lượt human
            SetupBossCountdownIfNeeded();
        }

        private void ClearBoardColors()
        {
            foreach (var kv in _btnMap)
            {
                kv.Value.BackColor = Color.White;   // về trắng
            }
        }

        private Color GetColorForMark(char m)
        {
            if (_config.Mode == frmMenu.GameMode.PvP)
                return (m == 'X') ? Color.Cyan : Color.DarkSalmon;   // P1=X, P2=O

            // PvE: người chơi = Cyan, bot = DarkSalmon
            char human = (_config.PlayerMark == frmMenu.Mark.X) ? 'X' : 'O';
            return (m == human) ? Color.Cyan : Color.DarkSalmon;
        }



        private void SetupBossCountdownIfNeeded()
        {
            if (_config.Mode == frmMenu.GameMode.PvE &&
                _config.Difficulty == frmMenu.BotLevel.Boss &&
                tmrTurn != null)
            {
                char human = (_config.PlayerMark == frmMenu.Mark.X) ? 'X' : 'O';
                if (_current == human)
                {
                    _turnSeconds = new Random().Next(3, 11);
                    lblStatus.Text = "Turn: " + _current + $"  (Time: {_turnSeconds}s)";
                    tmrTurn.Start();
                }
                else
                {
                    tmrTurn.Stop();
                }
            }
        }

        private bool IsHumanTurn()
        {
            if (_config.Mode == frmMenu.GameMode.PvP) return true;
            char human = (_config.PlayerMark == frmMenu.Mark.X) ? 'X' : 'O';
            return _current == human;
        }

        private void OnCellClick(object sender, EventArgs e)
        {
            if (!IsHumanTurn()) return;

            var btn = (Button)sender;
            var p = (Point)btn.Tag;
            int r = p.Y, c = p.X;

            if (!_rules.TryPlace(r, c, _current, _board)) return;

            // Màu của người chơi (Player / Player1)
            btn.Text = _current.ToString();
            btn.BackColor = GetColorForMark(_current);
            btn.Enabled = false;

            AfterPlacedAndMaybeContinue();
        }

        private void AfterPlacedAndMaybeContinue()
        {
            RefreshBoardUi();

            // 1) Thắng?
            char winner;
            if (_rules.CheckWin(_board, out winner))
            {
                bool leftWins;
                if (_config.Mode == frmMenu.GameMode.PvE)
                    leftWins = (winner == (_config.PlayerMark == frmMenu.Mark.X ? 'X' : 'O'));
                else
                    leftWins = (winner == 'X'); // Player1 là 'X'

                if (leftWins) _scoreLeft++; else _scoreRight++;
                UpdateScoreLabels();

                // Overkill nếu bot thắng (PvE)
                if (_config.Mode == frmMenu.GameMode.PvE && !leftWins)
                {
                    int chance = (_config.Difficulty == frmMenu.BotLevel.Boss) ? 50 : 15;
                    if (new Random().Next(1, 101) <= chance)
                    {
                        for (int r = 0; r < _rules.Size; r++)
                            for (int c = 0; c < _rules.Size; c++)
                                if (_board[r, c] == '\0')
                                {
                                    _board[r, c] = winner;
                                    var b = _btnMap[new Point(c, r)];
                                    b.Text = winner.ToString();
                                    b.BackColor = Color.DarkSalmon;
                                    b.Enabled = false;
                                    _scoreRight++;
                                }
                        UpdateScoreLabels();
                    }
                }

                lblStatus.Text = "Winner: " + winner;
                EndRound();
                return;
            }

            // 2) Hòa?
            if (_rules.IsDraw(_board))
            {
                lblStatus.Text = "Draw";
                EndRound();
                return;
            }

            // 3) Đổi lượt
            _current = (_current == 'X') ? 'O' : 'X';
            lblStatus.Text = "Turn: " + _current;

            // 4) PvE: tới lượt bot → bot đi
            if (_config.Mode == frmMenu.GameMode.PvE)
            {
                char botMark = (_config.PlayerMark == frmMenu.Mark.X) ? 'O' : 'X';
                if (_current == botMark)
                {
                    if (tmrTurn != null) tmrTurn.Stop(); // human hết lượt → dừng countdown Boss
                    StartBotTurn();
                    return;
                }
            }

            // 5) Boss: nếu tới lượt human → bật countdown
            SetupBossCountdownIfNeeded();
        }

        private void StartBotTurn()
        {
            if (tmrBot != null && tmrBot.Enabled) return; // tránh Start trùng
            foreach (var b in _btnMap.Values) b.Enabled = false;
            if (tmrBot != null) tmrBot.Start();
        }

        // Called by Designer Tick
        private void tmrBot_Tick(object sender, EventArgs e)
        {
            if (tmrBot != null) tmrBot.Stop();
            if (_bot == null) return;

            char botMark = (_config.PlayerMark == frmMenu.Mark.X) ? 'O' : 'X';
            char humanMark = (_config.PlayerMark == frmMenu.Mark.X) ? 'X' : 'O';

            Point move = _bot.Choose(botMark, humanMark, _board, _rules, _rng);
            if (move.X >= 0 && move.Y >= 0)
            {
                if (_rules.TryPlace(move.Y, move.X, botMark, _board))
                {
                    var b = _btnMap[new Point(move.X, move.Y)];
                    b.Text = botMark.ToString();
                    b.BackColor = GetColorForMark(botMark);
                    b.Enabled = false;
                    _current = botMark;
                }
            }

            AfterPlacedAndMaybeContinue();
        }

        // Called by Designer Tick (tmrTurn)
        private void tmrTurn_Tick(object sender, EventArgs e)
        {
            if (_turnSeconds > 0)
            {
                _turnSeconds--;
                lblStatus.Text = "Turn: " + _current + $"  (Time: {_turnSeconds}s)";
                if (_turnSeconds > 0) return;
            }

            // Hết giờ -> bot cướp lượt (Boss + PvE)
            if (tmrTurn != null) tmrTurn.Stop();

            if (_config.Mode == frmMenu.GameMode.PvE &&
                _config.Difficulty == frmMenu.BotLevel.Boss)
            {
                char human = (_config.PlayerMark == frmMenu.Mark.X) ? 'X' : 'O';
                if (_current == human)
                {
                    StartBotTurn();
                }
            }
        }

        private void EndRound()
        {
            foreach (var b in _btnMap.Values) b.Enabled = false;
            if (tmrBot != null) tmrBot.Stop();
            if (tmrTurn != null) tmrTurn.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        // Gọi ở cuối constructor:
        // BuildBoard(_rules.Size);
        // SetupResponsiveLayout();
        // RestartGame();

        private TableLayoutPanel _root;   // layout gốc 3 hàng
        private TableLayoutPanel _tlpTop; // thanh trên: Player | Status | Bot
        private Panel _pnlBottom;         // thanh dưới: nút Reset

        private void SetupResponsiveLayout()
        {
            // 0) Root layout: 3 hàng (Auto / 100% / Auto)
            if (_root == null)
            {
                _root = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 1,
                    RowCount = 3,
                    Padding = new Padding(8)
                };
                _root.RowStyles.Add(new RowStyle(SizeType.AutoSize));        // Top bar
                _root.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));   // Board
                _root.RowStyles.Add(new RowStyle(SizeType.AutoSize));        // Bottom
                Controls.Add(_root);
                _root.BringToFront();
            }

            // 1) Top bar (3 cột %)
            if (_tlpTop == null)
            {
                _tlpTop = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 3,
                    Padding = new Padding(0, 2, 0, 2),
                    Margin = new Padding(0, 0, 0, 6)
                };
                _tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
                _tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34f));
                _tlpTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
            }

            lblPlayerWin.AutoSize = true;
            lblBotWin.AutoSize = true;
            lblPlayerWin.TextAlign = ContentAlignment.MiddleLeft;
            lblBotWin.TextAlign = ContentAlignment.MiddleRight;
            if (lblStatus != null) lblStatus.TextAlign = ContentAlignment.MiddleCenter;

            _tlpTop.Controls.Clear();
            _tlpTop.Controls.Add(lblPlayerWin, 0, 0);
            _tlpTop.Controls.Add(lblStatus, 1, 0);
            _tlpTop.Controls.Add(lblBotWin, 2, 0);

            // 2) Board ở giữa (Fill)
            tblBoard.Dock = DockStyle.Fill;
            tblBoard.Margin = new Padding(0, 6, 0, 6); // cách top/bottom một chút

            // 3) Bottom: panel chứa nút Reset, canh giữa
            if (_pnlBottom == null)
            {
                _pnlBottom = new Panel { Dock = DockStyle.Fill, Height = 72, Margin = new Padding(0, 6, 0, 0) };
            }
            _pnlBottom.Controls.Clear();
            _pnlBottom.Controls.Add(btnReset);
            btnReset.AutoSize = true;
            btnReset.Anchor = AnchorStyles.None;

            void CenterReset(object s, EventArgs e)
            {
                btnReset.Left = (_pnlBottom.Width - btnReset.Width) / 2;
                btnReset.Top = (_pnlBottom.Height - btnReset.Height) / 2;
            }
            _pnlBottom.Resize -= CenterReset;
            _pnlBottom.Resize += CenterReset;
            CenterReset(null, EventArgs.Empty);

            // 4) Gắn các phần vào root theo hàng
            _root.SuspendLayout();
            _root.Controls.Clear();
            _root.Controls.Add(_tlpTop, 0, 0);
            _root.Controls.Add(tblBoard, 0, 1);
            _root.Controls.Add(_pnlBottom, 0, 2);
            _root.ResumeLayout();
            _root.PerformLayout();
        }

        // Nếu lỡ các label bị che do z-order khi tạo control runtime, gọi nhanh cái này
        private void BringHeadersToFront()
        {
            _tlpTop?.BringToFront();
            lblPlayerWin?.BringToFront();
            lblBotWin?.BringToFront();
            lblStatus?.BringToFront();
        }


        // ========== Stub cũ để Designer không lỗi nếu còn gán ==========
        private void PlayerClickButton(object sender, EventArgs e) { }
        private void Botmove(object sender, EventArgs e) { }
        private void lblBotWin_Click(object sender, EventArgs e) { }
    }
}
