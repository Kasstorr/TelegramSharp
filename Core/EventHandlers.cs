using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core {
    public class UpdateReceivedEventArgs : EventArgs {
        public Message Message;
        public User FromBot;
        public UpdateReceivedEventArgs(Message msg, User bot) {
            Message = msg;
            FromBot = bot;
        }
    }
    public class TextMessageReceivedEventArgs : EventArgs {
        public string MessageText;
        public User Sender;
        public User FromBot;
        public TextMessageReceivedEventArgs(Message msg, User bot) {
            FromBot = bot;
            Sender = msg.From;
            MessageText = msg.Text;
        }
    }
}