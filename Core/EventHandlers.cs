using System;
using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core {

    /// <summary>
    /// 
    /// </summary>
    public class UpdateReceivedEventArgs : EventArgs {
        public Message Message;
        public User FromBot;
        public long ChatID;
        public UpdateReceivedEventArgs(Message msg, User bot) {
            Message = msg;
            FromBot = bot;
            ChatID = msg.Chat.Id;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TextMessageReceivedEventArgs : EventArgs {
        public string MessageText;
        public User Sender;
        public User FromBot;
        public long ChatID;
        public TextMessageReceivedEventArgs(Message msg, User bot) {
            FromBot = bot;
            Sender = msg.From;
            MessageText = msg.Text;
            ChatID = msg.Chat.Id;
        }
    }
}