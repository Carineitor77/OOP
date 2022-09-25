using OOP.Models.Lab3;
using System.Threading.Tasks;

namespace OOP.Hubs
{
    public interface IMessageClient
    {
        Task Send(NewMessage message);
    }
}