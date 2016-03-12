using System;
using System.IO;
using System.Net;
using System.Text;

namespace Core {
	public static class NetManaging {
		//Receives the messages
		public static string GetUpdates (string token, int offset = 0, int limit = 100, int timeout = 60) {
			// Create a request
			WebRequest request = WebRequest.Create (CombineUri ("https://api.telegram.org/bot", token) + "/getUpdates");
			request.Method = "POST"; // Set the Method property of the request to POST.
			string postData = CombineParams (offset: offset, limit: limit, timeout: timeout); // Create POST data
			byte[] byteArray = Encoding.UTF8.GetBytes (postData); //Convert it to a byte array.
			request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
			request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
			Stream dataStream = request.GetRequestStream (); // Get the request stream.
			dataStream.Write (byteArray, 0, byteArray.Length); // Write the data to the request stream.
			dataStream.Close (); // Close the Stream object.
			WebResponse response = request.GetResponse (); // Get the response.
			Console.WriteLine ("Request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
			dataStream = response.GetResponseStream (); // Get the stream containing content returned by the server.
			StreamReader reader = new StreamReader (dataStream); // Open the stream using a StreamReader for easy access.
			string _out = reader.ReadToEnd (); // Read the content.
			reader.Close (); // Clean up the streams.
			response.Close ();
			return _out; // Return the value
		}

		//invia un messaggio
		public static void SendMessage (string token, int chatId, string text, string parseMode = "", bool disableWebPagePreview = false, int replyToMessageId = 0) {
			// Create a request
			WebRequest request = WebRequest.Create (CombineUri ("https://api.telegram.org/bot", token) + "/sendMessage");
			request.Method = "POST"; // Set the Method property of the request to POST.
			string postData = CombineParams (chatId, text, parseMode, disableWebPagePreview, replyToMessageId); // Create POST data
			byte[] byteArray = Encoding.UTF8.GetBytes (postData); //Convert it to a byte array.
			request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
			request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
			Stream dataStream = request.GetRequestStream (); // Get the request stream.
			dataStream.Write (byteArray, 0, byteArray.Length); // Write the data to the request stream.
			dataStream.Close (); // Close the Stream object.
			WebResponse response = request.GetResponse (); // Get the response.
			Console.WriteLine ("Request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
			dataStream = response.GetResponseStream (); // Get the stream containing content returned by the server.
			StreamReader reader = new StreamReader (dataStream); // Open the stream using a StreamReader for easy access.
			reader.Close (); // Clean up the streams.
			response.Close ();
		}

		//Controlla l'esistenza del bot token associato e che i servizi telegram siano attivi
		public static string GetMe (string token) {
			// Create a request
			WebRequest request = WebRequest.Create (CombineUri ("https://api.telegram.org/bot", token) + "/getMe");
			request.Method = "POST"; // Set the Method property of the request to POST.
			string postData = ""; // Create POST data
			byte[] byteArray = Encoding.UTF8.GetBytes (postData); //Convert it to a byte array.
			request.ContentType = "application/x-www-form-urlencoded"; // Set the ContentType property of the WebRequest.
			request.ContentLength = byteArray.Length; // Set the ContentLength property of the WebRequest.
			Stream dataStream = request.GetRequestStream (); // Get the request stream.
			dataStream.Write (byteArray, 0, byteArray.Length); // Write the data to the request stream.
			dataStream.Close (); // Close the Stream object.
			WebResponse response = request.GetResponse (); // Get the response.
			Console.WriteLine ("Request status:" + ((HttpWebResponse)response).StatusDescription); // Display the status.
			dataStream = response.GetResponseStream (); // Get the stream containing content returned by the server.
			StreamReader reader = new StreamReader (dataStream); // Open the stream using a StreamReader for easy access.
			string _out = reader.ReadToEnd (); // Read the content.
			reader.Close (); // Clean up the streams.
			response.Close ();
			return _out; // Return the value
		}

		//Ottiene gli URL a cui inviare le richieste
		private static string CombineUri (string url, string token) {
			return url + token;
		}

		//chat_id text parse_mode disable_web_page_preview reply_to_message_id offset limit timeout from_chat_id message_id
		private static string CombineParams (int chatId = 0, string text = "", string parseMode = "", bool disableWebPagePreview = false, int replyToMessageId = 0, int offset = 0, int limit = 0, int timeout = 0, int fromChatId = 0, int messageId = 0) {
			//get update offset, limit, timeout
			if (chatId == 0 && text == "" && parseMode == "" && disableWebPagePreview == false && replyToMessageId == 0 && fromChatId == 0 && messageId == 0) {
				return "offset=" + offset + "&limit=" + limit + "&timeout=" + timeout;
			}
			//send message signature: chat_id text  (parse_mode disable_web_page_preview reply_to_message_id)
			if (offset == 0 && limit == 0 && timeout == 0) {
				string _out = "chat_id=" + chatId + "&text=" + text;
				if (parseMode != "") {
					_out += "&parse_mode=" + parseMode;
				}
				if (disableWebPagePreview) {
					_out += "&disable_web_page_preview=true";
				}
				if (replyToMessageId != 0) {
					_out += "&reply_to_message_id=" + replyToMessageId;
				}
				return _out;
			}

			return null;
		}
	}
}