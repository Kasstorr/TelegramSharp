using System.IO;
using Core.Objects;
using Modules.QChat;
using Newtonsoft.Json;
using System;


namespace Core {
	public static class IoManager {
		static string configPath;

		public static BotSetup LoadConfig (string ConfigPath = "TelegramBotConfig.json") {
			configPath = ConfigPath;
			BotSetup config = new BotSetup ();
			if (File.Exists (configPath)) {
				string jsonconfig = File.ReadAllText (configPath);

				try {
					config = JsonConvert.DeserializeObject<BotSetup> (jsonconfig);
				} catch (Exception ex) {
					Console.WriteLine (ex);
				}
				return config;
			}
			config = new BotSetup ();
			config.BotToken = "your token here";
			config.OwnerId = 0;
			config.QChatModule.Add (new QChatAnswer (new[] { "ping", "pong" }, new string[1] { "answer" }, new int[0], new int[0], false));
			SaveConfig (config);
			return config;
		}

		public static void SaveConfig (BotSetup config) {
			string json = JsonConvert.SerializeObject (config, Formatting.Indented);
			File.WriteAllText (configPath, json);
		}
	}
}
