using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer.Models
{
    public class ChatModel
    {
        public IList<ChatMessage> Messages { get; set; }
        public IDictionary<string, string> Users { get; set; }
        public string CurrentUserName { get; set; }
    }

    public class ChatMessage
    {
        public string Author { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
    }
}