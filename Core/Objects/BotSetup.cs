//TelegramSharp - A library to make telegram bots
//Copyright (C) 2016  Samuele Lorefice
//
//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.
//
//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System.Collections.Generic;
using System.Runtime.Serialization;
using TelegramSharp.Modules.QChat;
using System;

namespace TelegramSharp.Core.Objects {
	/// <summary>
	/// Bot configuration.
	/// </summary>
	[DataContract]
	public class BotSetup {
		/// <summary>
		/// Gets or sets the bot token.
		/// </summary>
		/// <value>The bot token.</value>
		[DataMember] public string BotToken{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.BotSetup"/> Q chat answers enabled.
		/// </summary>
		/// <value><c>true</c> if Q chat answers enabled; otherwise, <c>false</c>.</value>
		[DataMember] public bool QChatAnswersEnabled{ get; set; }


		/// <summary>
		/// Gets or sets the Qchatmodule.
		/// </summary>
		/// <value>The Q chat module.</value>
		[DataMember] public List<QChatAnswer> QChatModule{ get; set; } = new List<QChatAnswer>();

		/// <summary>
		/// Gets or sets the owner identifier.
		/// </summary>
		/// <value>The owner identifier.</value>
		[DataMember] public int OwnerId{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.BotSetup"/> me enabled.
		/// </summary>
		/// <value><c>true</c> if me enabled; otherwise, <c>false</c>.</value>
		[DataMember] public bool MeEnabled{ get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Core.Objects.BotSetup"/> bot stats enabled.
		/// </summary>
		/// <value><c>true</c> if bot stats enabled; otherwise, <c>false</c>.</value>
		[DataMember] public bool BotStatsEnabled{ get; set; }

	}
}
