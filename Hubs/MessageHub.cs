using Microsoft.AspNetCore.SignalR;
using OOP.Models.Lab3;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace OOP.Hubs
{
    public class MessageHub : Hub<IMessageClient>
    {
        public Task SendToOthers(Message message)
        {
            string? name = Context.Items["Name"] as string;
            Bird bird = DefineRole(name);
            Type type = typeof(Bird);

            foreach (var method in type.GetMethods())
            {
                if (method.IsVirtual && message.Text == method.Name)
                {
                    return Clients.Others.Send(
                        NewMessage.Create(name, method.Invoke(bird, null) as string));
                }
            }

            return Task.CompletedTask;
        }

        public Task SetMyName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Task.CompletedTask;

            if (Context.Items.ContainsKey("Name"))
            {
                Context.Items["Name"] = name;
            }
            else
            {
                Context.Items.Add("Name", name);
            }

            return Task.CompletedTask;
        }

        private Bird DefineRole(string? role)
        {
            Type parentType = typeof(Bird);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();

            switch (role)
            {
                case "Eagle":
                    return new Eagle();
                case "Duck":
                    return new Duck();
                default:
                    throw new ArgumentException("Didn't define a bird");
            }
        }
    }
} 
