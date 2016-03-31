using TelegramSharp.Core.Objects.NetAPI;

namespace TelegramSharp.Core {
    public class BotEvents {
        public delegate void MessageReceivedHandler(Message receivedMessage, User fromBot);
        public event MessageReceivedHandler MessageReceived;
    }
}