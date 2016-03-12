using System;
using System.Diagnostics;
using Core;
using Core.Objects;
using Core.Objects.NetAPI;

namespace Core {
	public class TelegramBot {
		public BotSetup Cfg;
		public Stopwatch UpTimeCounter;
		public User BotIdentity;

		public void Start () {
			JsonDataManager JSON = new JsonDataManager ();
			Console.WriteLine ("Loaded TelegramAPI 0.1!");
			Console.WriteLine ("BotWorker Started");

			UpTimeCounter = new Stopwatch ();
			UpTimeCounter.Start ();

			Console.WriteLine ("Getting bot account data");
			string getme = NetManaging.GetMe (Cfg.BotToken); 
			if (JSON.DeserializeAndParseGetMe (getme, this) != null) {
				string s = NetManaging.GetUpdates (Cfg.BotToken);
				JSON.DeserializeAndParseMessages (s, this);
				while (true) {
					s = NetManaging.GetUpdates (Cfg.BotToken, JSON.Offset + 1, 60);
					JSON.DeserializeAndParseMessages (s, this);
				}
			}
		}

		public TelegramBot (BotSetup cfg) {
			Cfg = cfg;
		}
	}
}


