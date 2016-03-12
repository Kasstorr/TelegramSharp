using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	[DataContract]
	public class Contact {
		[DataMember (Name = "phone_number")] public string PhoneNumber;
		[DataMember (Name = "first_name")] public string FirstName;
		[DataMember (Name = "last_name", IsRequired = false)] public string LastName;
		[DataMember (Name = "user_id", IsRequired = false)] public int UserId;
	}
}
