using System;
using Core.Objects.NetAPI;
using Modules.Logger;
using Newtonsoft.Json;

namespace Core {
	public class JsonDataManager {
		public int Offset;

		public void DeserializeAndParseMessages (string inJson, TelegramBot bot) {
			MessageServerUpdate serverUpdate = JsonConvert.DeserializeObject<MessageServerUpdate> (inJson);
			if (serverUpdate.Result != null) {
				foreach (Update upd in serverUpdate.Result) {
					Offset = upd.UpdateId;
					MessageParser.ParseMessage (upd.Message, bot);
				}
			}
		}

		public User DeserializeAndParseGetMe (string inJson, TelegramBot bot) {
			try {
				GetMeServerUpdate serverUpdate = JsonConvert.DeserializeObject<GetMeServerUpdate> (inJson);
				if (serverUpdate.GetMe != null)
					Logger.LogWrite (serverUpdate.GetMe);
				bot.BotIdentity = serverUpdate.GetMe;
				return serverUpdate.GetMe;
			} catch (JsonReaderException) {
				Console.WriteLine ("ERROR: Server not returned a valid JSON, chek your token and connection.");
				Console.WriteLine ("Returned from the website: " + inJson);
			}
			return null;
		}
	}
}