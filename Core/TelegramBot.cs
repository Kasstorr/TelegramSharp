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
using System.Diagnostics;
using TelegramSharp.Core;
using TelegramSharp.Core.Objects;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core {
	/// <summary>
	/// Telegram bot.
	/// </summary>
	public class TelegramBot {

        //public event EventArgs received message


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

		/// <summary>
		/// Start the bot. Use this method as thread, as is going to use an infinite loop.
		/// </summary>
		public void Start () {
			JsonDataManager JSON = new JsonDataManager ();
			Console.WriteLine ("Loaded TelegramAPI 0.1!");
			Console.WriteLine ("BotWorker Started");

			UpTimeCounter = new Stopwatch ();
			UpTimeCounter.Start ();

			Console.WriteLine ("Getting bot account data");
			try {
				if (Cfg == null) {
					Console.WriteLine ("Missing configuration, compile the generated config file and restart the program.");
				}
				string getme = NetManaging.GetMe (Cfg.BotToken); 
				if (JSON.DeserializeAndParseGetMe (getme, this) != null) {
					while (true) {
						string s = NetManaging.GetUpdates (Cfg.BotToken, JSON.Offset + 1, 60);
						if (s != null) {
							JSON.DeserializeAndParseMessages (s, this);
						}
					}
				}
			} catch (Exception e) {
				Console.WriteLine ("WebException generated, see Error.log");
				System.IO.File.AppendAllText ("Error.log", "\nError generated on " + DateTime.Now.ToString () + "\n" + e.ToString ());
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Core.TelegramBot"/> class.
		/// </summary>
		/// <param name="cfg">Cfg.</param>
		public TelegramBot (BotSetup cfg) {
			Cfg = cfg;
		}
	}
}