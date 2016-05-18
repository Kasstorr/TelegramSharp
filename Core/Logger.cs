//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using TelegramSharp.Core.Objects;

namespace TelegramSharp.Core
{
    class Logger
    {
        public BotSetup Cfg;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public void Fatal(string msg, Exception e = null)
        {
            if (e == null)
            {
                string log = String.Format("{0},{1:ffff}|FATAL|{2}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg);
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "FATAL");
            }
            else
            {
                string log = String.Format("{0},{1:ffff}|FATAL|{2}; {3}; {4}; {5}; {6}; {7}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg, e.HResult.ToString(), e.Message.ToString(), e.Source.ToString(), e.TargetSite.ToString(), e.StackTrace.ToString());
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "FATAL");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public void Error(string msg, Exception e = null)
        {
            if (e == null)
            {
                string log = String.Format("{0},{1:ffff}|ERROR|{2}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg);
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "ERROR");
            }
            else
            {
                string log = String.Format("{0},{1:ffff}|ERROR|{2}; {3}; {4}; {5}; {6}; {7}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg, e.HResult.ToString(), e.Message.ToString(), e.Source.ToString(), e.TargetSite.ToString(), e.StackTrace.ToString());
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "ERROR");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public void Warn(string msg, Exception e = null)
        {
            if (e == null)
            {
                string log = String.Format("{0},{1:ffff}|WAEN|{2}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg);
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "WARN");
            }
            else
            {
                string log = String.Format("{0},{1:ffff}|WARN|{2}; {3}; {4}; {5}; {6}; {7}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg, e.HResult.ToString(), e.Message.ToString(), e.Source.ToString(), e.TargetSite.ToString(), e.StackTrace.ToString());
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "WARN");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public void Info(string msg, Exception e = null)
        {
            if (e == null)
            {
                string log = String.Format("{0},{1:ffff}|INFO|{2}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg);
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "INFO");
            }
            else
            {
                string log = String.Format("{0},{1:ffff}|INFO|{2}; {3}; {4}; {5}; {6}; {7}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg, e.HResult.ToString(), e.Message.ToString(), e.Source.ToString(), e.TargetSite.ToString(), e.StackTrace.ToString());
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "INFO");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="e"></param>
        public void Debug(string msg, Exception e = null)
        {
            if (e == null)
            {
                string log = String.Format("{0},{1:ffff}|DEBUG|{2}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg);
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "DEBUG");
            }
            else
            {
                string log = String.Format("{0},{1:ffff}|DEBUG|{2}; {3}; {4}; {5}; {6}; {7}", DateTime.Now.ToString(), DateTime.Now.Millisecond, msg, e.HResult.ToString(), e.Message.ToString(), e.Source.ToString(), e.TargetSite.ToString(), e.StackTrace.ToString());
                if (Cfg.VerboseMode)
                {
                    Console.WriteLine(log);
                }
                LogToFile(log, "DEBUG");
            }
        }
        /// <summary>
        /// Logs a message into a file given the global path and level.
        /// </summary>
        /// <param name="Msg">Message Log to store.</param>
        public void LogToFile(string msg, string logLevel)
        {
            if (logLevel == Cfg.LoggingLevel)
            {
                if (File.Exists(Cfg.LoggingPath))
                {
                    try
                    {
                        File.AppendAllText(Cfg.LoggingPath, msg);
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
                        File.WriteAllText(Cfg.LoggingPath, msg);
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
