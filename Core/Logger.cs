using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace TelegramSharp.Core
{
    class Logger
    {
        public static string LogLevel = "FATAL";
        public static string LogPath = "Path";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public static void Fatal(string Msg, Exception e = null)
        {
            string msg = String.Format("{0},{1:ffff}|INFO|{2}; {3}; {4}; {5}; {6}; {7}", DateTime.Now.ToString(), DateTime.Now.Millisecond, Msg, e.HResult.ToString(), e.Message.ToString(), e.Source.ToString(), e.TargetSite.ToString(), e.StackTrace.ToString());
            LogToFile(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public static void Error(string Msg, Exception e = null)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public static void Warn(string Msg, Exception e = null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public static void Info(string Msg, Exception e = null)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public static void Debug(string Msg, Exception e = null)
        {

        }
        /// <summary>
        /// Logs a message into a file given the global path and level.
        /// </summary>
        /// <param name="Msg">Message Log to store.</param>
        public static void LogToFile(string Msg)
        {
            if (LogLevel == "")
            {
                if (File.Exists(LogPath))
                {
                    try
                    {
                        File.AppendAllText(LogPath, Msg);
                    }
                    catch (Exception e)
                    {
                        Error("", e);
                    }
                }
                else
                {
                    try
                    {
                        File.WriteAllText(LogPath, Msg);
                    }
                    catch (Exception e)
                    {
                        Error("", e);
                    }
                }
            }
        }
    }
}
