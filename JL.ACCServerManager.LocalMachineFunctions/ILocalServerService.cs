using JL.ACCServerManager.Models;
using System.Threading.Tasks;

namespace JL.ACCServerManager.LocalMachineFunctions
{
    public interface ILocalServerService
    {
        public bool restartServer();
        public  Task<bool> startServer();
        public  Task<bool> stopServer();
        public Task<Event> getEventConfig();

        public Task<string> writeEventConfig(Event eventConfig);
    }
}