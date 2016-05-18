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
using TelegramSharp.Core.Objects.NetAPI;
using Newtonsoft.Json;

namespace TelegramSharp.Core {
	/// <summary>
	/// Json data manager.
	/// </summary>
	public class JsonDataManager {
		/// <summary>
		/// The offset of last requested update
		/// </summary>
		public int Offset;
        static Logger Logging;
		/// <summary>
		/// Deserializes the and parse messages.
		/// </summary>
		/// <param name="inJson">JSON to deserialize.</param>
		/// <param name="bot">Bot that should parse the message.</param>
		public void DeserializeAndParseMessages (string inJson, TelegramService bot)
        {
		    MessageServerUpdate serverUpdate = JsonConvert.DeserializeObject<MessageServerUpdate> (inJson);
			if (serverUpdate.Result != null)
            {
				foreach (Update upd in serverUpdate.Result)
                {
					Offset = upd.UpdateId;
                    bot.Parser.ParseMessage(upd.Message, bot);
                    Message msgToLog = upd.Message;
                    User Bot = bot.BotIdentity;
                    Logging.Info(String.Format("{0}:From chat {1}, by {3} Message: {2}", Bot.Username, msgToLog.Chat.Title + " " + msgToLog.Chat.Username, msgToLog.Text, msgToLog.From.Id + " " + msgToLog.From.FirstName + " " + msgToLog.From.LastName));
                }
			}
		}

		/// <summary>
		/// Deserializes the and parse a get me.
		/// </summary>
		/// <returns>Bot user information</returns>
		/// <param name="inJson">JSON to deserialize.</param>
		/// <param name="bot">Bot that should parse the message.</param>
		public User DeserializeAndParseGetMe (string inJson, TelegramService bot) {
			try {
				GetMeServerUpdate serverUpdate = JsonConvert.DeserializeObject<GetMeServerUpdate> (inJson);
				if (serverUpdate.GetMe != null)
					ConsoleLogger.GetBotLog (serverUpdate.GetMe);
				bot.BotIdentity = serverUpdate.GetMe;
				return serverUpdate.GetMe;
			} catch (JsonReaderException e) {
				Logging.Error ("ERROR: Server not returned a valid JSON, chek your token and connection. From the website: " + inJson, e);
			}
			return null;
		}
	}
}