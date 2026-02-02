using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms24._06._2025
{
    public partial class GameForm : Form
    {
        string basePath = Path.Combine(Application.StartupPath, "Animations");

        PictureBox enemy;
        PictureBox fireball;

        Image[] walkRightFrames;
        Image[] walkLeftFrames;
        Image[] walkUpFrames;
        Image[] walkDownFrames;

        Image[] fireballAnimationLeft;
        Image[] fireballAnimationRight;
        Image[] fireballAnimationUp;
        Image[] fireballAnimationDown;

        int currentFrame = 0;

        int heroSpeed = 10;
        int enemySpeed = 10;
        int fireballSpeed = 15;

        int HeroHP = 100;
        int score = 0;
        int highScore = 0;

        bool movingRight = true;
        bool movingUp = false;
        bool movingDown = false;
        bool movingLeft = false;

        bool currentUp = false;
        bool currentRight = false;
        bool currentLeft = true;
        bool currentDown = false;

        System.Windows.Forms.Timer animationTimer;
        System.Windows.Forms.Timer fireballFrameTimer;
        System.Windows.Forms.Timer enemySpawnTimer;
        System.Windows.Forms.Timer enemyMoveTimer;

        Random rndEnemyLocSpawn = new Random();
        public GameForm()
        {

            InitializeComponent();

            LoadHighScore();
            LoadSprites();

            SetupHeroAndFireballAnimation();
            SetupEnemySpawn();


            InitializeHighScore();

            SoundManager.Initialize();
            SoundManager.SoundEnabled = true;


            Hero.Location = new Point(this.Width, this.Height / 2);

            this.FormClosing += (e, b) => StopGame();
        }
        public void StopGame()
        {
            animationTimer?.Stop();
            fireballFrameTimer?.Stop();
            enemySpawnTimer?.Stop();
            enemyMoveTimer?.Stop();

            animationTimer?.Dispose();
            fireballFrameTimer?.Dispose();
            enemySpawnTimer?.Dispose();
            enemyMoveTimer?.Dispose();

            animationTimer = null;
            fireballFrameTimer = null;
            enemySpawnTimer = null;
            enemyMoveTimer = null;

            enemy?.Dispose();
            enemy = null;

            fireball?.Dispose();
            fireball = null;
        }
        private void GameOver()
        {
            animationTimer.Stop();
            enemySpawnTimer.Stop();

            if (enemyMoveTimer != null) enemyMoveTimer.Stop();
            if (fireballFrameTimer != null) fireballFrameTimer.Stop();

            MessageBox.Show($"GAME OVER! Ваш счёт: {score}", "Конец игры");

            this.Dispose();
        }
        private async Task ShakeForm(int intensity = 50, int duration = 500)
        {
            var originalLocation = this.Location;
            var rnd = new Random();

            for (int i = 0; i < duration / 10; i++)
            {
                this.Location = new Point(
                    originalLocation.X + rnd.Next(-intensity, intensity),
                    originalLocation.Y + rnd.Next(-intensity, intensity));
                await Task.Delay(5);
            }
            this.Location = originalLocation;
        }
        private void LoadSprites()
        {
            walkRightFrames = new Image[4];
            walkLeftFrames = new Image[4];
            walkUpFrames = new Image[4];
            walkDownFrames = new Image[4];

            fireballAnimationLeft = new Image[4];
            fireballAnimationRight = new Image[4];
            fireballAnimationUp = new Image[4];
            fireballAnimationDown = new Image[4];

            try
            {
                for (int i = 0; i < 4; i++)
                {
                    walkRightFrames[i] = Image.FromFile(Path.Combine(basePath, $"Right{i + 1}.png"));
                    walkLeftFrames[i] = Image.FromFile(Path.Combine(basePath, $"Left{i + 1}.png"));
                    walkUpFrames[i] = Image.FromFile(Path.Combine(basePath, $"Up_0{i + 1}.png"));
                    walkDownFrames[i] = Image.FromFile(Path.Combine(basePath, $"Down_0{i + 1}.png"));
                
                    fireballAnimationLeft[i] = Image.FromFile(Path.Combine(basePath, "fireballAnimation", $"FireBall_animation1_{i + 1}.png"));
                    fireballAnimationRight[i] = Image.FromFile(Path.Combine(basePath, "fireballAnimation", $"FireBall_animation1_{i + 1}.png"));
                    fireballAnimationUp[i] = Image.FromFile(Path.Combine(basePath, "fireballAnimation", $"FireBall_animation1_{i + 1}.png"));
                    fireballAnimationDown[i] = Image.FromFile(Path.Combine(basePath, "fireballAnimation", $"FireBall_animation1_{i + 1}.png"));

                    fireballAnimationRight[i].RotateFlip(RotateFlipType.Rotate180FlipNone);
                    fireballAnimationUp[i].RotateFlip(RotateFlipType.Rotate90FlipNone);
                    fireballAnimationDown[i].RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ошибка загрузки спрайтов: {ex.Message}");
            }
        }
        private void LoadHighScore()
        {
            try
            {
                if (File.Exists("highscore.txt"))
                {
                    string text = File.ReadAllText("highscore.txt");
                    if (int.TryParse(text, out int loadedScore))
                    {
                        highScore = loadedScore;
                    }
                }
            }
            catch {}
        }
        private void InitializeHighScore()
        {
            lblHighScore.Text = $"Рекорд: {highScore}";
        }
        private void SaveHighScore()
        {
            try
            {
                File.WriteAllText("highscore.txt", highScore.ToString());
            }
            catch {}
        }
        private void UpdateScore()
        {
            score += 1;
            lblScore.Text = $"Счёт: {score}";

            if (score > highScore)
            {
                highScore = score;
                SaveHighScore();
                lblHighScore.Text = $"Рекорд: {highScore}";
            }
        }
        private void SetupEnemySpawn()
        {
            enemySpawnTimer = new System.Windows.Forms.Timer();
            enemySpawnTimer.Interval = 100;
            enemySpawnTimer.Tick += (sender, e) =>
            {

                if (enemy == null || enemy.IsDisposed)
                {
                    SpawnEnemy();
                }
                if (fireball != null && enemy != null && enemyMoveTimer != null)
                {
                    if (ArePictureBoxesIntersecting(enemy, fireball))
                    {
                        UpdateScore();
                        SoundManager.PlayScore();
                        enemyMoveTimer.Stop();
                        this.Controls.Remove(enemy);
                        enemy.Dispose();
                        enemy = null;
                        ShakeForm();
                    }
                }
                if (Hero != null && enemy != null)
                {
                    if (ArePictureBoxesIntersecting(Hero, enemy))
                    {
                        SoundManager.PlayHit();
                        GameOver();
                    }
                }
            };
            enemySpawnTimer.Start();
        }

        private void SpawnEnemy()
        {
            enemy = new PictureBox();
            this.Controls.Add(enemy);
            enemy.Name = "Enemy";
            LoadPictureBox(enemy, Path.Combine(basePath, "enemy.gif"));
            enemy.Size = new Size(125, 125);
            enemy.Location = new Point(0, rndEnemyLocSpawn.Next(lblScore.Height, this.Height - enemy.Height + 1));

            enemy.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy.Show();

            enemyMoveTimer = new System.Windows.Forms.Timer();
            enemyMoveTimer.Interval = 30;

            enemyMoveTimer.Tick += (sender, e) =>
            {
                if (enemy != null && !enemy.IsDisposed)
                {
                    enemy.Left += enemySpeed;

                    if (enemy.Right > this.ClientSize.Width)
                    {
                        HeroHP -= 20;
                        SoundManager.PlayHit();
                        ShakeForm();
                        lblHP.Text = HeroHP.ToString();
                        CheckHeroXpAndChangeColor();
                        enemyMoveTimer.Stop();
                        this.Controls.Remove(enemy);
                        enemy.Dispose();
                        enemy = null;
                    }
                    if (lblHP.Text == "0")
                    {
                        GameOver();
                    }
                }
            };
            enemyMoveTimer.Start();
        }

        private void CheckHeroXpAndChangeColor()
        {
            if (HeroHP <= 60 && HeroHP > 40)
            {
                lblHP.BackColor = Color.Olive;
            }
            if (HeroHP <= 40)
            {
                lblHP.BackColor = Color.DarkRed;
            }
        }
        private void LoadPictureBox(PictureBox entity, string path)
        {
            entity.Image = Image.FromFile(path);
        }

        private void SetupHeroAndFireballAnimation()
        {
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 100;
            animationTimer.Tick += AnimateCharacter;
            animationTimer.Start();
        }
        private void AnimateFireball(object sender, EventArgs e)
        {
            if (currentRight)
            {
                fireball.Image = fireballAnimationRight[currentFrame];
            }
            else if (currentLeft)
            {
                fireball.Image = fireballAnimationLeft[currentFrame];
            }
            else if (currentUp)
            {
                fireball.Image = fireballAnimationUp[currentFrame];
            }
            else if (currentDown)
            {
                fireball.Image = fireballAnimationDown[currentFrame];
            }

            currentFrame = (currentFrame + 1) % 4;
        }
        private void AnimateCharacter(object sender, EventArgs e)
        {
            if (movingRight)
                Hero.Image = walkRightFrames[currentFrame];
            else if (movingLeft)
                Hero.Image = walkLeftFrames[currentFrame];
            else if (movingUp)
                Hero.Image = walkUpFrames[currentFrame];
            else if (movingDown)
                Hero.Image = walkDownFrames[currentFrame];

            currentFrame = (currentFrame + 1) % 4;
        }
        private void MoveRight()
        {
            movingRight = true;
            movingDown = false;
            movingLeft = false;
            movingUp = false;
            currentFrame = 0;

            Point newLocation = new Point(Hero.Location.X + heroSpeed, Hero.Location.Y);

            if (CanMoveTo(newLocation))
            {
                Hero.Location = newLocation;
            }
        }

        private void MoveLeft()
        {
            movingRight = false;
            movingDown = false;
            movingLeft = true;
            movingUp = false;
            currentFrame = 0;

            Point newLocation = new Point(Hero.Location.X - heroSpeed, Hero.Location.Y);

            if (CanMoveTo(newLocation))
            {
                Hero.Location = newLocation;
            }
        }
        private void MoveUp()
        {
            movingRight = false;
            movingDown = false;
            movingLeft = false;
            movingUp = true;
            currentFrame = 0;

            Point newLocation = new Point(Hero.Location.X, Hero.Location.Y - heroSpeed);

            if (CanMoveTo(newLocation))
            {
                Hero.Location = newLocation;
            }
        }
        private void MoveDown()
        {
            movingRight = false;
            movingDown = true;
            movingLeft = false;
            movingUp = false;
            currentFrame = 0;

            Point newLocation = new Point(Hero.Location.X, Hero.Location.Y + heroSpeed);

            if (CanMoveTo(newLocation))
            {
                Hero.Location = newLocation;
            }
        }
        private async Task SpawnPictureBox()
        {
            if (fireball == null || fireball.IsDisposed)
            {
                fireball = new PictureBox();
                this.Controls.Add(fireball);
                fireball.Name = "fireball";
                fireball.Size = new Size(125, 125);
                if (movingRight)
                {
                    fireball.Location = new Point(Hero.Location.X + Hero.Width, Hero.Location.Y + 20);
                }
                if (movingUp)
                {
                    fireball.Location = new Point(Hero.Location.X, Hero.Location.Y - 15);
                }
                if (movingLeft)
                {
                    fireball.Location = new Point(Hero.Location.X - 20, Hero.Location.Y + 20);
                }
                if (movingDown)
                {
                    fireball.Location = new Point(Hero.Location.X, Hero.Location.Y + 15);
                }
                fireball.SizeMode = PictureBoxSizeMode.StretchImage;
                SoundManager.PlayShoot();
                fireball.Show();
                await FlyFireBall();
            }
        }
        private async Task FlyFireBall()
        {
            int x = 0;
            int y = 0;
            int targetX = 0;
            int targetY = 0;

            currentUp = movingUp;
            currentDown = movingDown;
            currentLeft = movingLeft;
            currentRight = movingRight;

            if (currentUp)
            {
                x = 0;
                y = -fireballSpeed;
                targetY = 0;
            }
            if (currentDown)
            {
                x = 0;
                y = fireballSpeed;
                targetY = this.ClientSize.Height;
            }
            if (currentRight)
            {
                x = fireballSpeed;
                y = 0;
                targetX = this.ClientSize.Width;
            }
            if (currentLeft)
            {
                x = -fireballSpeed;
                y = 0;
                targetX = 0;
            }

            fireballFrameTimer = new System.Windows.Forms.Timer();
            fireballFrameTimer.Interval = 100;
            fireballFrameTimer.Tick += AnimateFireball;
            fireballFrameTimer.Start();

            while (
                (currentRight && fireball.Location.X < targetX) ||
                (currentLeft && fireball.Location.X > targetX) ||
                (currentUp && fireball.Location.Y > targetY) ||
                (currentDown && fireball.Location.Y < targetY) || fireball.IsDisposed
            )
            {
                await Task.Delay(1);
                fireball.Location = new Point(fireball.Location.X + x, fireball.Location.Y + y);
            }
            fireballFrameTimer.Stop();
            this.Controls.Remove(fireball);
            fireball.Dispose();
            fireball = null;
        }
        private bool ArePictureBoxesIntersecting(PictureBox pb1, PictureBox pb2)
        {
            return pb1.Bounds.IntersectsWith(pb2.Bounds);
        }
        private bool CanMoveTo(Point newLocation)
        {
            Rectangle newBounds = new Rectangle(newLocation, Hero.Size);

            if (!IsWithinFormBounds(newBounds))
            {
                return false;
            }
            if (WouldCollideWithPanels(newBounds))
            {
                return false;
            }
            if(IsCollideWithLabelScore(newBounds))
            {
                return false;
            }
            return true;
        }
        private bool IsCollideWithLabelScore(Rectangle bounds)
        {
            if (bounds.IntersectsWith(lblScore.Bounds))
            {
                return true;
            }
            return false;
        }
        private bool IsWithinFormBounds(Rectangle bounds)
        {
            return bounds.Left >= 0 &&
                   bounds.Top >= 0 &&
                   bounds.Right <= this.ClientSize.Width &&
                   bounds.Bottom <= this.ClientSize.Height;
        }
        private bool WouldCollideWithPanels(Rectangle bounds)
        {
            List<Panel> panels = GetAllPanels();

            foreach (Panel panel in panels)
            {
                if (bounds.IntersectsWith(panel.Bounds))
                {
                    return true;
                }
            }
            return false;
        }
        public List<Panel> GetAllPanels()
        {
            List<Panel> panels = new List<Panel>();

            GetAllPanelsRecursive(this.Controls, panels);
            return panels;
        }
        private void GetAllPanelsRecursive(Control.ControlCollection controls, List<Panel> panels)
        {
            foreach (Control control in controls)
            {
                if (control is Panel panel)
                {
                    panels.Add(panel);
                }
                if (control.HasChildren)
                {
                    GetAllPanelsRecursive(control.Controls, panels);
                }
            }
        }
        private void Subform1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad4)
            {
                MoveLeft();
            }
            if (e.KeyCode == Keys.NumPad6)
            {
                MoveRight();
            }
            if (e.KeyCode == Keys.NumPad8)
            {
                MoveUp();
            }
            if (e.KeyCode == Keys.NumPad2)
            {
                MoveDown();
            }
            if (e.KeyCode == Keys.NumPad7)
            {
                SpawnPictureBox();
            }
        }
    }
}
