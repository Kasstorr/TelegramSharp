using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Message server update.
	/// </summary>
	[DataContract]
	public class MessageServerUpdate {
		[DataMember (Name = "ok")] private bool _ok;
		[DataMember (Name = "result", IsRequired = false)] private Update[] _result;

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.MessageServerUpdate"/> is ok.
		/// </summary>
		/// <value><c>true</c> if ok; otherwise, <c>false</c>.</value>
		public bool Ok {
			get {
				return _ok;
			}

			set {
				_ok = value;
			}
		}

		/// <summary>
		/// Gets or sets the result.
		/// </summary>
		/// <value>The result.</value>
		public Update[] Result {
			get {
				return _result;
			}

			set {
				_result = value;
			}
		}
	}
}