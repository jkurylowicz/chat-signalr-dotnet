using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatServer.Models
{
    public static class ChatStorage
    {
        public readonly static IList<ChatMessage> _msgs = new List<ChatMessage>();
        public readonly static IDictionary<string, string> _users = new Dictionary<string, string>();
    }
}