using System.Runtime.Serialization;

namespace TelegramSharp.Core.Objects.NetAPI {
	/// <summary>
	/// A server update containing the bot user informations.
	/// </summary>
	[DataContract]
	public class GetMeServerUpdate {
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.NetAPI.GetMeServerUpdate"/> is ok.
		/// </summary>
		/// <value><c>true</c> if ok; otherwise, <c>false</c>.</value>
		[DataMember] public bool Ok{ get; set; }

		/// <summary>
		/// Gets or sets the get me.
		/// </summary>
		/// <value>The get me.</value>
		[DataMember (Name = "result", IsRequired = false)] public User GetMe{ get; set; }
	}
}