using System;

namespace PluginContract.Core
{
    public enum MessageType
    {
        Normal,
        Warning,
        Error
    }

    public class MessageUpdateArgs : EventArgs
    {

        #region Constructors

        public MessageUpdateArgs(string Message)
        {
            this.Message = Message;
        }

        public MessageUpdateArgs(MessageType Type, string Message) : this(Message)
        {
            this.Type = Type;
        }

        #endregion

        #region Properties

        public MessageType Type { get; private set; }

        public string Message { get; private set; }

        #endregion

    }
}
