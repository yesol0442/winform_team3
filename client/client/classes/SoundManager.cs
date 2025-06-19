using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client.classes
{
    public static class SoundManager
    {
        private static SoundPlayer player;

        public static bool SoundEnabled { get; set; } = true;

        public static void PlaySound(string filePath)
        {
            StopSound();

            if (!SoundEnabled || string.IsNullOrEmpty(filePath))
                return;

            try
            {
                player = new SoundPlayer(filePath);
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사운드 재생 오류: {ex.Message}");
            }
        }

        public static void PlaySoundLoop(string filePath)
        {
            StopSound();

            if (!SoundEnabled || string.IsNullOrEmpty(filePath))
                return;

            try
            {
                player = new SoundPlayer(filePath);
                player.PlayLooping(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"반복 사운드 재생 오류: {ex.Message}");
            }
        }


        public static void StopSound()
        {
            if (player != null)
            {
                player.Stop();
            }
        }
    }
}
