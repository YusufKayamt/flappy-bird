using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;

namespace flappy_bird
{
    public partial class Form1 : Form
    {
        // Kuş ve boru hareket değişkenleri
        int birdSpeed = 5;
        int gravity = 10;
        int pipeSpeed = 8;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            gameTimer.Start(); // Zamanlayıcıyı başlat
                               
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Kuşun aşağı düşmesi
            bird.Top += gravity;

            // Boruların hareketi
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;

            // Borular ekran dışına çıkarsa sıfırlanır
            if (pipeTop.Left < -50)
            {
                pipeTop.Left = 800;
                score++;
            }

            if (pipeBottom.Left < 20)
            {
                pipeBottom.Left = 750;
                score++;
            }

            // Skoru güncelleme
            scoreText.Text = "Score: " + score;

            // Kuşun zemine çarpması
            if (bird.Bounds.IntersectsWith(ground.Bounds) || bird.Bounds.IntersectsWith(pipeTop.Bounds) || bird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame(); // Oyun sona erdirilir
            }

            // Kuş ekranın dışına çıkarsa oyun biter
            if (bird.Top < -25)
            {
                endGame();
            }
        }

        private void endGame()
        {
            gameTimer.Stop(); // Timer durdurulur
            scoreText.Text = "Game Over!";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10; // Kuş yukarı çıkar
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            gravity = 10; // Kuş tekrar aşağı düşer
        }

        private void gameTimer_Tick_1(object sender, EventArgs e)
        {
            bird.Top += gravity; // Kuşun yerçekimi ile düşüşü
        }

        private void scoreText_Click(object sender, EventArgs e)
        {

        }

        private void bird_Click(object sender, EventArgs e)
        {

        }
    }
}
