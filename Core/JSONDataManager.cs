using System;
using Core.Objects.NetAPI;
using Modules.Logger;
using Newtonsoft.Json;

namespace Core {
	/// <summary>
	/// Json data manager.
	/// </summary>
	public class JsonDataManager {
		/// <summary>
		/// The offset of last requested update
		/// </summary>
		public int Offset;

		/// <summary>
		/// Deserializes the and parse messages.
		/// </summary>
		/// <param name="inJson">JSON to deserialize.</param>
		/// <param name="bot">Bot that should parse the message.</param>
		public void DeserializeAndParseMessages (string inJson, TelegramBot bot) {
			MessageServerUpdate serverUpdate = JsonConvert.DeserializeObject<MessageServerUpdate> (inJson);
			if (serverUpdate.Result != null) {
				foreach (Update upd in serverUpdate.Result) {
					Offset = upd.UpdateId;
					MessageParser.ParseMessage (upd.Message, bot);
				}
			}
		}

		/// <summary>
		/// Deserializes the and parse a get me.
		/// </summary>
		/// <returns>Bot user information</returns>
		/// <param name="inJson">JSON to deserialize.</param>
		/// <param name="bot">Bot that should parse the message.</param>
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