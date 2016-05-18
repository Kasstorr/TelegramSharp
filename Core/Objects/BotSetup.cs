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
		[DataMember] public string BotToken { get; set; }

        /// <summary>
        /// Gets or sets the path to the log file.
        /// </summary>
        /// <value>The path to the log file.</value>
        [DataMember] public string LoggingPath { get; set; }

        /// <summary>
        /// Gets or sets the logging level.
        /// </summary>
        /// <value>The logging level.</value>
        [DataMember] public string LoggingLevel { get; set; }
	}
}
