using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json.Serialization;

namespace Modules.QChat {
	[DataContract]
	public class QChatAnswer {
		[DataMember (Name = "Triggers")] List<string> _triggers = new List<string> ();
		[DataMember (Name = "Answers")] List<string> _answers = new List<string> ();
		[DataMember (IsRequired = false, Name = "AllowedIDs")] List<int> _allowedIDs = new List<int> ();
		[DataMember (IsRequired = false, Name = "BannedIDs")] List<int> _bannedIDs = new List<int> ();
		[DataMember (IsRequired = false, Name = "Restricted")] bool _restricted = false;
		[DataMember (Name = "RandomizeAnswers")] bool _randomizeAnswers = false;


		public List<string> Triggers {
			get {
				return _triggers;
			}

			set {
				_triggers = value;
			}
		}

		public List<string> Answers {
			get {
				return _answers;
			}

			set {
				_answers = value;
			}
		}

		public List<int> AllowedIDs {
			get {
				return _allowedIDs;
			}

			set {
				_allowedIDs = value;
			}
		}

		public List<int> BannedIDs {
			get {
				return _bannedIDs;
			}

			set {
				_bannedIDs = value;
			}
		}

		public bool RandomizeAnswers {
			get {
				return _randomizeAnswers;
			}

			set {
				_randomizeAnswers = value;
			}
		}

		public bool Restricted {
			get {
				return _restricted;
			}

			set {
				_restricted = value;
			}
		}

		public QChatAnswer () {
            
		}

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
