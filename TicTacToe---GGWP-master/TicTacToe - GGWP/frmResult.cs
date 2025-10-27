using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TicTacToe___GGWP
{
    public partial class frmResult : Form
    {
        private int _win, _draw, _lose;
        private bool _isWinHiddenBoss;

        public frmResult(int win, int draw, int lose, bool isWinHiddenBoss)
        {
            InitializeComponent();
            _win = win;
            _draw = draw;
            _lose = lose;
            _isWinHiddenBoss = isWinHiddenBoss;
            LoadResult();
        }

        private void LoadResult()
        {
            lblTitle.Text = _isWinHiddenBoss && _win >= _lose ? "🎉 YOU WIN!" : "💀 YOU LOSE!";
            lblScore.Text = $"Win: {_win} | Draw: {_draw} | Lose: {_lose}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên của bạn!", "Thông báo");
                return;
            }

            string path = "Leaderboard.txt";
            string line = $"{name}|{_win}|{_draw}|{_lose}|{DateTime.Now}";
            File.AppendAllLines(path, new[] { line });

            MessageBox.Show("Đã lưu kết quả! Xem Leaderboard để kiểm tra.", "Thông báo");
            this.Close();
        }

        private void btnShowLeaderboard_Click(object sender, EventArgs e)
        {
            new frmLeaderboard().ShowDialog();
        }
    }
}
