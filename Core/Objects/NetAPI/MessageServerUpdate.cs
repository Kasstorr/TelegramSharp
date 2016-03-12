using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class MessageServerUpdate {
		[DataMember (Name = "ok")] private bool _ok;
		[DataMember (Name = "result", IsRequired = false)] private Update[] _result;

		public bool Ok {
			get {
				return _ok;
			}

			set {
				_ok = value;
			}
		}

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