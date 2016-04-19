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
using TelegramSharp.Modules.QChat;
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

        public event EventHandler<MessageReceivedArgs> MessageReceived;
        protected virtual void OnMessageReceived(Message message, User bot) {
            if (true) {
                MessageReceived(this, new MessageReceivedArgs(message, bot));
            }
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
        public void ParseMessage(Message msg, TelegramBot bot) {
            parsedMessagesCount++;
            if (msg.Text != null && msg.Date >= ToUnixTime(DateTime.UtcNow) - 10) {

                #region QChatAnswers
                foreach (QChatAnswer qChatAnsw in bot.Cfg.QChatModule) {
                    foreach (string trigger in qChatAnsw.Triggers) {
                        if (CheckForString(trigger, msg.Text, bot)) {
                            if (qChatAnsw.Answers.Count == 1) {
                                commandsParsed++;
                                NetManaging.SendMessage(bot.Cfg.BotToken, msg.Chat.Id, qChatAnsw.Answers[0]);
                                return;
                            } else if (qChatAnsw.Answers.Count > 1) {
                                commandsParsed++;
                                Random rnd = new Random();

                                NetManaging.SendMessage(bot.Cfg.BotToken, msg.Chat.Id,
                                    qChatAnsw.Answers[rnd.Next(0, qChatAnsw.Answers.Count)]);

                                return;
                            }
                        }
                    }
                }
                #endregion

                #region /me
                if (msg.Text.ToLower() == "/me" && msg.From.Id == bot.Cfg.OwnerId ||
                    msg.Text.ToLower() == "/me@" + bot.BotIdentity.Username.ToLower() && msg.From.Id == bot.Cfg.OwnerId) {
                    commandsParsed++;

                    NetManaging.SendMessage(bot.Cfg.BotToken, msg.Chat.Id,
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

                    NetManaging.SendMessage(bot.Cfg.BotToken, msg.Chat.Id,
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

                    int triggerscount = 0;
                    int answerscount = 0;
                    foreach (QChatAnswer qCA in bot.Cfg.QChatModule) {
                        triggerscount += qCA.Triggers.Count;
                        answerscount += qCA.Answers.Count;
                    }

                    NetManaging.SendMessage(bot.Cfg.BotToken, msg.Chat.Id, "*UPTIME:* `" +
                    uptime.Days + "D " + uptime.Hours + "H " + uptime.Minutes + "M " +
                    uptime.Seconds + "S`\n*Parsed Messages:* `" + parsedMessagesCount +
                    "`\n*Parsed user commands:* `" + commandsParsed +
                    "`\n*QChatAnswer Module stats:\n   Triggers:* `" + triggerscount +
                    "`\n   *Answers:* `" + answerscount + "`", "markdown");

                    return;
                }
                #endregion

                OnMessageReceived(msg, bot.BotIdentity);
            }
        }

        public bool CheckForString(string trigger, string msg, TelegramBot bot) {
            trigger = trigger.ToLower();
            if (msg == trigger || msg + "@" + bot.BotIdentity.Username.ToLower() == trigger)
                return true;
            if (msg.ToLower().EndsWith(" " + trigger) || msg.ToLower().Contains(" " + trigger + "@" + bot.BotIdentity.Username.ToLower()))
                return true;
            if (msg.ToLower().Contains(trigger + " ") || msg.ToLower().Contains(trigger + "@" + bot.BotIdentity.Username.ToLower() + " "))
                return true;
            return false;
        }

        bool CheckForPermission(Message msg, QChatAnswer triggeredAnswers) {
            foreach (int id in triggeredAnswers.BannedIDs) {
                if (msg.From.Id == id)
                    return false;
            }

            foreach (int id in triggeredAnswers.AllowedIDs) {
                if (msg.From.Id == id)
                    return true;
            }
            return true;
        }
    }
}
