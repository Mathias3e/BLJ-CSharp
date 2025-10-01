using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Music
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayMusic("Audio.wav");
            Thread.Sleep(1000);
            PlayMusic("Audio.wav");

            Console.ReadKey();
        }

        public static void PlayMusic(string filepath)
        {
            SoundPlayer musicPlayer = new SoundPlayer();
            musicPlayer.SoundLocation = filepath;
            musicPlayer.Play();
        }
    }
}
