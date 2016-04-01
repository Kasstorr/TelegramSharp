using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core {
    public class MessageReceivedArgs : EventArgs {
        Message Message;
        User FromBot;
        public MessageReceivedArgs(Message msg, User bot) {
            Message = msg;
            FromBot = bot;
        }
    }
}