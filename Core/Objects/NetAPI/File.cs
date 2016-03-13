using System.Runtime.Serialization;

namespace Core.Objects.NetAPI {
	/// <summary>
	/// File.
	/// </summary>
	[DataContract]
	public class File {
		/// <summary>
		/// Gets or sets the file identifier.
		/// </summary>
		/// <value>The file identifier.</value>
		[DataMember (Name = "file_id")] public string FileId{ get; set; }

		/// <summary>
		/// Gets or sets the size of the file.
		/// </summary>
		/// <value>The size of the file.</value>
		[DataMember (Name = "file_size", IsRequired = false)] public int FileSize{ get; set; }

		/// <summary>
		/// Gets or sets the file path.
		/// </summary>
		/// <value>The file path.</value>
		[DataMember (Name = "file_path", IsRequired = false)] public string FilePath{ get; set; }
	}
}
