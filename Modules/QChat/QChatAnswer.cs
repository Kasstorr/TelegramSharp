using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;
using System.Configuration;

namespace TelegramSharp.Modules.QChat {
	/// <summary>
	/// QChatAnswer.
	/// </summary>
	[DataContract]
	public class QChatAnswer {
		/// <summary>
		/// Gets or sets the triggers.
		/// </summary>
		/// <value>The triggers.</value>
		[DataMember (Name = "Triggers")]public List<string> Triggers { get; set; }

		/// <summary>
		/// Gets or sets the answers.
		/// <value>The answers.</value>
		/// </summary>
		[DataMember (Name = "Answers")] public List<string> Answers { get; set; }

		/// <summary>
		/// Gets or sets the allowed Ids.
		/// </summary>
		/// <value>The allowed Ids.</value>
		[DataMember (IsRequired = false, Name = "AllowedIDs")] public List<int> AllowedIDs { get; set; }

		/// <summary>
		/// Gets or sets the banned Ids.
		/// </summary>
		/// <value>The banned Ids.</value>
		[DataMember (IsRequired = false, Name = "BannedIDs")] public List<int> BannedIDs{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Modules.QChat.QChatAnswer"/> randomize answers.
		/// </summary>
		/// <value><c>true</c> if randomize answers; otherwise, <c>false</c>.</value>
		[DataMember (Name = "RandomizeAnswers")]public bool RandomizeAnswers{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Modules.QChat.QChatAnswer"/> is restricted.
		/// </summary>
		/// <value><c>true</c> if restricted; otherwise, <c>false</c>.</value>
		[DataMember (IsRequired = false, Name = "Restricted")]public bool Restricted { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Modules.QChat.QChatAnswer"/> class.
		/// </summary>
		public QChatAnswer () { 
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Modules.QChat.QChatAnswer"/> class.
		/// </summary>
		/// <param name="triggerStrings">Trigger strings.</param>
		/// <param name="answersStrings">Answers strings.</param>
		/// <param name="allowedIdInts">Allowed identifier ints.</param>
		/// <param name="bannedIdsInts">Banned identifiers ints.</param>
		/// <param name="randomizeAnswers">If set to <c>true</c> randomize answers.</param>
		/// <param name="restricted">If set to <c>true</c> restricted.</param>
		public QChatAnswer (string[] triggerStrings, string[] answersStrings, int[] allowedIdInts, int[] bannedIdsInts, bool randomizeAnswers = false, bool restricted = false) {
			Triggers = new List<string> ();
			foreach (string trigger in triggerStrings) {
				Triggers.Add (trigger);
			}

			Answers = new List<string> ();
			foreach (string answer in answersStrings) {
				Answers.Add (answer);
			}

			AllowedIDs = new List<int> ();
			foreach (int allowedId in allowedIdInts) {
				AllowedIDs.Add (allowedId);
			}

			BannedIDs = new List<int> ();
			foreach (int bannedId in bannedIdsInts)
				BannedIDs.Add (bannedId);
			
			//RandomizeAnswers = new bool ();
			RandomizeAnswers = randomizeAnswers;

			//Restricted = new bool ();
			Restricted = restricted;
		}
	}
}
