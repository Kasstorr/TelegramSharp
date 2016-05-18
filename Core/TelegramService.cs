﻿//TelegramSharp - A library to make telegram bots
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
using System.Diagnostics;
using TelegramSharp.Core.Objects;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core
{
    /// <summary>
    /// Telegram bot.
    /// </summary>
    public class TelegramService {

        /// <summary>
        /// The configuration file for this bot.
        /// </summary>
        public BotSetup Cfg;
        /// <summary>
        /// Up time counter.
        /// </summary>
        public Stopwatch UpTimeCounter;
        /// <summary>
        /// The bot identity.
        /// </summary>
        public User BotIdentity;
        public MessageParser Parser;
        public NetworkSender NetService;
        public JsonDataManager JSON;
        Logger Logging;

        /// <summary>
        /// Start the bot. Use this method as thread, as is going to use an infinite loop.
        /// </summary>
        public void Start() {
            if (Cfg == null) {
                Logging.Error("Missing configuration, compile the generated config file and restart the program or pass a reference to a CFG class containing all the fields.");
            }
            else
            {
                BotIdentity = JSON.DeserializeAndParseGetMe(NetworkSender.GetMe(Cfg.BotToken), this);
                Console.WriteLine("Loaded TelegramSharp " + Cfg.LibVersion.ToString() + "!");
                bool isStarted = false;
                UpTimeCounter.Start();
                while (true)
                {
                    if (!isStarted)
                    {
                        Console.WriteLine("Listener Started");
                    }
                    string s = NetworkSender.GetUpdates(Cfg.BotToken, JSON.Offset + 1, 60);
                    if (s != null)
                    {
                        JSON.DeserializeAndParseMessages(s, this);
                    }
                }
            }
        }


        public void Init() {
            JSON = new JsonDataManager();
            Parser = new MessageParser();
            NetService = new NetworkSender();
            UpTimeCounter = new Stopwatch();
            Console.WriteLine("TelegramSharpInit Complete");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Core.TelegramService"/> class.
        /// </summary>
        /// <param name="cfg">Cfg.</param>
        public TelegramService(BotSetup cfg) {
            Cfg = cfg;
            //Thread listener = new Thread(new ThreadStart(Start));
        }
    }
}