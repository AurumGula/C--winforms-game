using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace WinForms24._06._2025
{
    public static class SoundManager
    {
        private static SoundPlayer hitSound;
        private static SoundPlayer shootSound;
        private static SoundPlayer gameOverSound;
        private static SoundPlayer scoreSound;

        private static string soundsPath;
        public static bool SoundEnabled { get; set; } = true;

        public static void Initialize()
        {
            try
            {

                soundsPath = Path.Combine(Application.StartupPath, "Sounds");

                hitSound = new SoundPlayer(Path.Combine(soundsPath, "hit.wav"));
                shootSound = new SoundPlayer(Path.Combine(soundsPath, "shoot.wav"));
                scoreSound = new SoundPlayer(Path.Combine(soundsPath, "score.wav"));

                hitSound.LoadAsync();
                shootSound.LoadAsync();
                scoreSound.LoadAsync();
            }
            catch (Exception ex) {}
        }
        public static void PlayHit() => PlaySound(hitSound);
        public static void PlayShoot() => PlaySound(shootSound);
        public static void PlayScore() => PlaySound(scoreSound);

        private static void PlaySound(SoundPlayer player)
        {
            if (player != null && SoundEnabled)
            {
                try
                {
                    player.Play();
                }
                catch {}
            }
        }
        public static void Dispose()
        {
            hitSound?.Dispose();
            shootSound?.Dispose();
            scoreSound?.Dispose();
        }
    }
}
