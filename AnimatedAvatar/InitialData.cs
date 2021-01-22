using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace AnimatedAvatar
{
    public static class InitialData
    {
        public static string MicrophoneName { get; set;  }
        public static int MicrophoneInputSoundMinLevel { get; set; }
        public static int MicrophoneInputSoundMaxLevel { get; set; }
        public static Color BackgroundColor { get; set; }

        public static void ReadIniFile()
        {
            List<string> fileData = new List<string>();

            if (!File.Exists("AnimatedAvatar.ini"))
            {
                fileData.Add("Полное название микрофона:");
                fileData.Add("Нижний уровень звука: 20");
                fileData.Add("Верхний уровень звука: 80");
                fileData.Add("Цвет фона: #ffffff");

                File.WriteAllLines("AnimatedAvatar.ini", fileData, Encoding.UTF8);
            }

            fileData = File.ReadAllLines("AnimatedAvatar.ini", Encoding.UTF8).Select(fileDataItem => fileDataItem.Split(':')[1].Trim()).ToList();

            MicrophoneName = fileData[0];
            MicrophoneInputSoundMinLevel = int.Parse(fileData[1]);
            MicrophoneInputSoundMaxLevel = int.Parse(fileData[2]);
            BackgroundColor = ColorTranslator.FromHtml(fileData[3]);
        }
    }
}