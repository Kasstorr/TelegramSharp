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
using TelegramSharp.Core.Objects.NetAPI;
using System;

namespace TelegramSharp.Core {
    /// <summary>
    /// Message parser.
    /// </summary>
    public class MessageParser {
        /// <summary>
        /// The parsed messages count.
        /// </summary>
        public int parsedMessagesCount = 0;
        /// <summary>
        /// The commands parsed count.
        /// </summary>
        public int commandsParsed = 0;

        public delegate void UpdateReceivedHandler(object sender, UpdateReceivedEventArgs args);
        public event UpdateReceivedHandler UpdateReceived;
        protected virtual void OnUpdateReceived(Message message, User bot) {
            UpdateReceived?.Invoke(this, new UpdateReceivedEventArgs(message, bot));
        }

        public delegate void TextMessageReceived(object sender, TextMessageReceivedEventArgs args);
        public event TextMessageReceived TextMessageReceivedEvent;
        protected virtual void OnTextMessageReceived(Message msg, User bot) {
            TextMessageReceivedEvent?.Invoke(this, new TextMessageReceivedEventArgs(msg, bot));
        }

        long ToUnixTime(DateTime date) {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }
        /// <summary>
        /// Parses the message.
        /// </summary>
        /// <param name="msg">Message to parse.</param>
        /// <param name="bot">Bot that should parse the message.</param>
        public void ParseMessage(Message msg, TelegramService bot) {
            parsedMessagesCount++;
            if (msg.Text != null /*&& msg.Date >= ToUnixTime(DateTime.UtcNow) - 10*/) {
                #region /me
                if (msg.Text.ToLower() == "/me" && msg.From.Id == bot.Cfg.OwnerId ||
                    msg.Text.ToLower() == "/me@" + bot.BotIdentity.Username.ToLower() && msg.From.Id == bot.Cfg.OwnerId) {
                    commandsParsed++;

                    NetworkSender.SendMessage(bot.Cfg.BotToken, msg.Chat.Id,
                        "<i>Oh master, you need your personal data??\nOk, sure</i>\n<b>You are:</b> <i>" +
                        msg.From.FirstName + " " + msg.From.LastName + "</i>\n<b>Your username is:</b> <i>" +
                        msg.From.Username + "</i>\n<b>Your unique ID is:</b> <i>" +
                        msg.From.Id + "</i>\n<b>And you are chatting in:</b> <i>" +
                        msg.Chat.Title + "</i>\n<b>ID:</b> <i>" + msg.Chat.Id +
                        "\n**blinks** it's all ok master? **blinks**</i>", "HTML");

                    return;
                }

                if (msg.Text.ToLower() == "/me" || msg.Text.ToLower() == "/me@" + bot.BotIdentity.Username.ToLower()) {
                    commandsParsed++;

                    NetworkSender.SendMessage(bot.Cfg.BotToken, msg.Chat.Id,
                        "<i>Uh, ok, you want to know what i know about you?\nOk, let's start!</i>\n<b>You are:</b> <i>" +
                        msg.From.FirstName + " " + msg.From.LastName + "</i>\n<b>Your username is:</b> <i>" +
                        msg.From.Username + "</i>\n<b>Your unique ID is:</b> <i>" +
                        msg.From.Id + "</i>\n<b>And you are chatting in:</b> <i>" +
                        msg.Chat.Title + "</i>\n<b>ID:</b> <i>" + msg.Chat.Id +
                        "\nOk?</i>", "HTML");

                    return;
                }
                #endregion
                #region BotStats
                if (msg.Text.ToLower() == "/botstats" || msg.Text.ToLower() == "/botstats@" + bot.BotIdentity.Username.ToLower()) {
                    TimeSpan uptime = new TimeSpan(0, 0, 0, 0, (int)bot.UpTimeCounter.ElapsedMilliseconds);
                    commandsParsed++;

                    NetworkSender.SendMessage(bot.Cfg.BotToken, msg.Chat.Id, "*UPTIME:* " +
                    uptime.Days + "D " + uptime.Hours + "H " + uptime.Minutes + "M " +
                    uptime.Seconds + "S\n*Parsed Messages:* " + parsedMessagesCount +
                    "\n*Parsed user commands:* " + commandsParsed + "\n_Running on TelegramSharp V=.2","markdown");
                    return;
                }
                #endregion
                OnUpdateReceived(msg, bot.BotIdentity);
                OnTextMessageReceived(msg, bot.BotIdentity);
            }
        }

        /// <summary>
        /// Check the presence of a trigger in the string
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="msg"></param>
        /// <param name="bot"></param>
        /// <returns></returns>
        public bool CheckForString(string trigger, string msg, TelegramService bot) {
            trigger = trigger.ToLower();
            if (msg == trigger || msg + "@" + bot.BotIdentity.Username.ToLower() == trigger)
                return true;
            if (msg.ToLower().EndsWith(" " + trigger) || msg.ToLower().Contains(" " + trigger + "@" + bot.BotIdentity.Username.ToLower()))
                return true;
            if (msg.ToLower().Contains(trigger + " ") || msg.ToLower().Contains(trigger + "@" + bot.BotIdentity.Username.ToLower() + " "))
                return true;
            return false;
        }
    }
}
