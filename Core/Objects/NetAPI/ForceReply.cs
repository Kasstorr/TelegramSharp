using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// Force reply.
	/// </summary>
	[DataContract]
	public class ForceReply {
		/// <summary>
		/// Gets a value indicating whether this <see cref="Core.Objects.NetAPI.ForceReply"/> force reply.
		/// </summary>
		/// <value><c>true</c> if force reply; otherwise, <c>false</c>.</value>
		[DataMember (Name = "force_reply")] public bool forceReply{ get { return true; } }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.ForceReply"/> is selective.
		/// </summary>
		/// <value><c>true</c> if selective; otherwise, <c>false</c>.</value>
		[DataMember (Name = "name", IsRequired = false)] public bool Selective{ get; set; }
	}
}
