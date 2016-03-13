using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;

namespace TelegramSharp.Modules.QChat {
	/// <summary>
	/// QChatAnswer.
	/// </summary>
	[DataContract]
	public class QChatAnswer {
		[DataMember (Name = "Triggers")] List<string> _triggers = new List<string> ();
		[DataMember (Name = "Answers")] List<string> _answers = new List<string> ();
		[DataMember (IsRequired = false, Name = "AllowedIDs")] List<int> _allowedIDs = new List<int> ();
		[DataMember (IsRequired = false, Name = "BannedIDs")] List<int> _bannedIDs = new List<int> ();
		[DataMember (IsRequired = false, Name = "Restricted")] bool _restricted = false;
		[DataMember (Name = "RandomizeAnswers")] bool _randomizeAnswers = false;

		/// <summary>
		/// Gets or sets the triggers.
		/// </summary>
		/// <value>The triggers.</value>
		public List<string> Triggers {
			get {
				return _triggers;
			}

			set {
				_triggers = value;
			}
		}

		/// <summary>
		/// Gets or sets the answers.
		/// </summary>
		/// <value>The answers.</value>
		public List<string> Answers {
			get {
				return _answers;
			}

			set {
				_answers = value;
			}
		}

		/// <summary>
		/// Gets or sets the allowed Ids.
		/// </summary>
		/// <value>The allowed I ds.</value>
		public List<int> AllowedIDs {
			get {
				return _allowedIDs;
			}

			set {
				_allowedIDs = value;
			}
		}

		/// <summary>
		/// Gets or sets the banned Ids.
		/// </summary>
		/// <value>The banned I ds.</value>
		public List<int> BannedIDs {
			get {
				return _bannedIDs;
			}

			set {
				_bannedIDs = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Modules.QChat.QChatAnswer"/> randomize answers.
		/// </summary>
		/// <value><c>true</c> if randomize answers; otherwise, <c>false</c>.</value>
		public bool RandomizeAnswers {
			get {
				return _randomizeAnswers;
			}

			set {
				_randomizeAnswers = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Modules.QChat.QChatAnswer"/> is restricted.
		/// </summary>
		/// <value><c>true</c> if restricted; otherwise, <c>false</c>.</value>
		public bool Restricted {
			get {
				return _restricted;
			}

			set {
				_restricted = value;
			}
		}

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
			foreach (string trigger in triggerStrings)
				Triggers.Add (trigger);
			foreach (string answer in answersStrings)
				_answers.Add (answer);
			foreach (int allowedId in allowedIdInts)
				_allowedIDs.Add (allowedId);
			foreach (int bannedId in bannedIdsInts)
				_bannedIDs.Add (bannedId);
			_randomizeAnswers = randomizeAnswers;
			_restricted = restricted;
		}
	}
}
