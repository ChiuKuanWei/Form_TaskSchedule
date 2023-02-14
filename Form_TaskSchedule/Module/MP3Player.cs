using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Form_TaskSchedule.Module
{
    public static class MP3Player
    {
        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, uint uReturnLength, uint hWndCallback);

        public static void PlayNmusinc(string path)
        {
            mciSendString(@"close temp_alias", null, 0, 0);
            mciSendString(@"open """ + path + @""" alias temp_alias", null, 0, 0);
            mciSendString("play temp_alias repeat", null, 0, 0);
        }

        /// <summary>
        /// 重複播放mp3
        /// </summary>
        /// <param name="sPath">mp3檔路徑</param>
        public static void PlayMusic_Repeat(string sPath)
        {
            try
            {
                mciSendString(@"close temp_music", " ", 0, 0);
                mciSendString(@"open " + sPath + " alias temp_music", " ", 0, 0);
                mciSendString(@"play temp_music repeat", " ", 0, 0);
            }
            catch
            { }
        }

        /// <summary>
        /// 播放mp3
        /// </summary>
        /// <param name="sPath">mp3檔路徑</param>
        public static void PlayMusic(string sPath)
        {
            try
            {
                mciSendString(@"close temp_music", " ", 0, 0);
                //mciSendString(@"open " + p_FileName + " alias temp_music", " ", 0, 0);
                mciSendString(@"open """ + sPath + @""" alias temp_music", null, 0, 0);
                mciSendString(@"play temp_music", " ", 0, 0);
            }
            catch
            { }
        }

        /// <summary>
        /// 停止播放mp3
        /// </summary>
        /// <param name="sPath">mp3檔路徑</param>
        public static void StopMusic(string sPath)
        {
            try
            {
                mciSendString(@"close " + sPath, " ", 0, 0);
            }
            catch { }
        }


    }
}
