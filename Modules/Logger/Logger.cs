using System;
using TelegramSharp.Core.Objects.NetAPI;
using Newtonsoft.Json;
using TelegramSharp.Modules.Logger;

namespace TelegramSharp.Modules.Logger {
	/// <summary>
	/// Message Logger.
	/// </summary>
	public static class Logger {
		
		static void LogDBAdd (Message msgToLog) {
			LoggedMessage log = new LoggedMessage (msgToLog);
			System.IO.File.AppendAllText ("DatabaseLog.db", JsonConvert.SerializeObject (log));
		}

		/// <summary>
		/// Logs a message to the console.
		/// </summary>
		/// <param name="msgToLog">Message to log.</param>
		public static void LogConsoleWrite (LoggableMessage msgToLog) {
			Console.WriteLine ("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine ("***Received Message from bot:" + msgToLog.FromBot.FirstName + " " + msgToLog.FromBot.LastName + "***");
			Console.Write ("Chat:");
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine (msgToLog.Chat.Title + " " + msgToLog.Chat.Username);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Write ("Sent by: ");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine (msgToLog.From.FirstName + " " + msgToLog.From.LastName + " - @" + msgToLog.From.Username);
			Console.ForegroundColor = ConsoleColor.Green;
			if (msgToLog.Text != null) {
				Console.Write ("Message:");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine (msgToLog.Text);
				LogDBAdd (msgToLog);
			}
			if (msgToLog.LeftChatParticipant != null) {
				Console.WriteLine (msgToLog.LeftChatParticipant.FirstName + "" + msgToLog.LeftChatParticipant.LastName + "(" + msgToLog.LeftChatParticipant.Username + ") Leaved the group");
			}
			if (msgToLog.NewChatParticipant != null) {
				Console.WriteLine (msgToLog.NewChatParticipant.FirstName + "" + msgToLog.NewChatParticipant.LastName + "(" + msgToLog.NewChatParticipant.Username + ") Joined the group");
			}
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine ("***End of message***");
			Console.WriteLine ("");
		}

		/// <summary>
		/// Logs the bot identity.
		/// </summary>
		/// <param name="getMe">Get me.</param>
		public static void LogWrite (User getMe) {
			Console.WriteLine ("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine ("***Received Bot Identity***");
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine ("Name: " + getMe.FirstName + " " + getMe.LastName);
			Console.WriteLine ("Username: @" + getMe.Username + " ID: " + getMe.Id);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine ("***End of Bot Identity***");
			Console.WriteLine ("");
		}
	}
}

