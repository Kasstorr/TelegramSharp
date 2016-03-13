using System;
using System.Diagnostics;
using Core;
using Core.Objects;
using Core.Objects.NetAPI;

namespace Core {
	/// <summary>
	/// Telegram bot.
	/// </summary>
	public class TelegramBot {
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
				string getme = NetManaging.GetMe (Cfg.BotToken); 
				if (JSON.DeserializeAndParseGetMe (getme, this) != null) {
					string s = NetManaging.GetUpdates (Cfg.BotToken);
					JSON.DeserializeAndParseMessages (s, this);
					while (true) {
						s = NetManaging.GetUpdates (Cfg.BotToken, JSON.Offset + 1, 60);
						JSON.DeserializeAndParseMessages (s, this);
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