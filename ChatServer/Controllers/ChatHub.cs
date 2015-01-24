﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using ChatServer.Models;

namespace ChatServer.Controllers
{
    public class ChatHub : Hub
    {
        // POST: Chat message
        public void Send(string msg)
        {
            var message = new ChatMessage()
            {
                Message = msg,
                Author = ChatStorage._users[GetCurrentConnectionId()],
                Timestamp = DateTime.Now.ToString("HH:mm:ss")
            };

            ChatStorage._msgs.Add(message);

            Clients.All.receiveMessage(message);
        }

        // OnConnected
        public override System.Threading.Tasks.Task OnConnected()
        {
            string connId = GetCurrentConnectionId();
            if (!ChatStorage._users.Keys.Contains(connId))
            {
                ChatStorage._users.Add(connId, GetUniqueUsername());
            }
            Clients.All.updateUsers(ChatStorage._users.Values.ToArray());
            return base.OnConnected();
        }

        // OnDisconnected
        public override System.Threading.Tasks.Task OnDisconnected(bool stop)
        {
            string connId = GetCurrentConnectionId();
            if (ChatStorage._users.Keys.Contains(connId))
            {
                ChatStorage._users.Remove(connId);
            }
            Clients.All.updateUsers(ChatStorage._users.Values.ToArray());
            return base.OnDisconnected(stop);
        }

        private string GetUniqueUsername()
        {
            return GetNextUniqueUsername(ChatStorage._users.Count);
        }

        private string GetNextUniqueUsername(int i)
        {
            string username = Context.User.Identity.IsAuthenticated ? Context.User.Identity.Name : "Anonymous-" + i;
            if (ChatStorage._users.Values.Contains(username))
            {
                return GetNextUniqueUsername(i + 1);
            };
            return username;
        }

        private string GetCurrentConnectionId()
        {
            return Context.ConnectionId;
        }
    }   
}