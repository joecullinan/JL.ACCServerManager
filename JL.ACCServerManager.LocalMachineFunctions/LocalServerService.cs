using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using JL.ACCServerManager.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using System.Web.Http;

namespace JL.ACCServerManager.LocalMachineFunctions
{

    /// <summary>
    /// Low-Level functions for controlling the server process, starting and stopping, and modifying the filesystem to update configs. 
    /// </summary>
    public class LocalServerService: ILocalServerService
    {

        private readonly IConfiguration Configuration;
        private Process serverProcess;
        private FileInfo serverExe;


        public LocalServerService(IConfiguration configuration)
        {
            Configuration = configuration;
            //see if server exists at location
            serverExe = new FileInfo(Configuration["ACCServerPath"] +  Configuration["ACCServerExecutableName"]);
            if (!serverExe.Exists) { throw new Exception($"Could not find server exe at {Configuration["ACCServerPath"]}{Configuration["ACCServerExecutableName"]}"); }
            //see if server is running, and if so kill it. 
            stopServer();

        }


        public bool restartServer()
        {
            stopServer();
            startServer();
            return true;
        }
        public async Task<bool> stopServer()
        {
            Process[] processes = Process.GetProcessesByName(Configuration["ACCServerExecutableName"]);
            foreach (Process p in processes)
            {
                p.Kill();
            }
            return true;
        }
        public async Task<bool> startServer()
        {
            serverProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = serverExe.FullName,
                    Arguments = "",
                    UseShellExecute = true,
                    RedirectStandardOutput = false,//true, true if we're capturing output
                    CreateNoWindow = true
                }
            };
            return serverProcess.Start();
            //while (!serverProcess.StandardOutput.EndOfStream)
            //{

            //    string line = serverProcess.StandardOutput.ReadLine();
            //    parseOutputLines(line);

            //}

             
        }
        private void parseOutputLines(string outputLine)
        {
            Console.WriteLine(outputLine);
        }

        public async Task<Event> getEventConfig()
        {
            var configString = File.ReadAllText(Configuration["ACCServerPath"] + "/cfg/event.json", Encoding.Unicode);
            Event resultEvent = new Event();
            resultEvent = JsonConvert.DeserializeObject<Event>(configString);
            return resultEvent;

        }

        public async Task<string> writeEventConfig([FromBody] Event eventConfig){

            //Event eventConfig = JsonConvert.DeserializeObject<Event>(eventConfigString);


            File.WriteAllText(Configuration["ACCServerPath"] + "/cfg/event.json", JsonConvert.SerializeObject(eventConfig), Encoding.Unicode);



            return JsonConvert.SerializeObject(getEventConfig());
        }
        
    }
}
