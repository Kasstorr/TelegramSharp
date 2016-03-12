using System;
using Core.Objects.NetAPI;
using Newtonsoft.Json;
using Modules.Logger;

namespace Modules.Logger {
	public static class Logger {
		public static void LogDBAdd (Message msgToLog) {
			LoggedMessage log = new LoggedMessage (msgToLog);
			System.IO.File.AppendAllText ("DatabaseLog.db", JsonConvert.SerializeObject (log));
		}

		public static void LogConsoleWrite () {
			Console.WriteLine ("Logger started");
			while (true) {
//				foreach (LoggableMessage msgToLog in Bot.LogPool) {
//					if (!msgToLog.Logged) {
//						Console.WriteLine ("");
//						Console.ForegroundColor = ConsoleColor.Green;
//						Console.WriteLine ("***Received Message from bot:" + msgToLog.FromBot.FirstName + " " + msgToLog.FromBot.LastName + "***");
//						Console.Write ("Chat:");
//						Console.ForegroundColor = ConsoleColor.DarkRed;
//						Console.WriteLine (msgToLog.Chat.Title + " " + msgToLog.Chat.Username);
//						Console.ForegroundColor = ConsoleColor.Green;
//						Console.Write ("Sent by: ");
//						Console.ForegroundColor = ConsoleColor.Yellow;
//						Console.WriteLine (msgToLog.From.FirstName + " " + msgToLog.From.LastName + " - @" + msgToLog.From.Username);
//						Console.ForegroundColor = ConsoleColor.Green;
//						if (msgToLog.Text != null) {
//							Console.Write ("Message:");
//							Console.ForegroundColor = ConsoleColor.White;
//							Console.WriteLine (msgToLog.Text);
//							LogDBAdd (msgToLog);
//						}
//						if (msgToLog.LeftChatParticipant != null) {
//							Console.WriteLine (msgToLog.LeftChatParticipant.FirstName + "" + msgToLog.LeftChatParticipant.LastName + "(" + msgToLog.LeftChatParticipant.Username + ") Leaved the group");
//						}
//						if (msgToLog.NewChatParticipant != null) {
//							Console.WriteLine (msgToLog.NewChatParticipant.FirstName + "" + msgToLog.NewChatParticipant.LastName + "(" + msgToLog.NewChatParticipant.Username + ") Joined the group");
//						}
//						Console.ForegroundColor = ConsoleColor.Green;
//						Console.WriteLine ("***End of message***");
//						Console.WriteLine ("");
//					} else {
//						Bot.LogPool.Remove (msgToLog);
//					}
//				}
			}
		}

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

