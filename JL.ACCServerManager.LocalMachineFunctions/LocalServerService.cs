using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;
using JL.ACCServerManager.Models;
using Newtonsoft.Json;

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
            serverExe = new FileInfo(Configuration["ACCServerPath"] + "/server/" + Configuration["ACCServerExecutableName"]);
            if (!serverExe.Exists) { throw new Exception($"Could not find server exe at {Configuration["ACCServerPath"]}/server/{Configuration["ACCServerExecutableName"]}"); }
            //see if server is running, and if so kill it. 
            stopServer();

        }


        public bool restartServer()
        {
            stopServer();
            startServer();
            return true;
        }
        public bool stopServer()
        {
            Process[] processes = Process.GetProcessesByName(Configuration["ACCServerExecutableName"]);
            foreach (Process p in processes)
            {
                p.Kill();
            }
            return true;
        }
        public void startServer()
        {
            serverProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = serverExe.FullName,
                    Arguments = "",
                    UseShellExecute = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            serverProcess.Start();
            while (!serverProcess.StandardOutput.EndOfStream)
            {

                string line = serverProcess.StandardOutput.ReadLine();
                parseOutputLines(line);

            }
        }
        private void parseOutputLines(string outputLine)
        {
            Console.WriteLine(outputLine);
        }

        private Event getEventConfig()
        {
            var configString = File.ReadAllText(Configuration["ACCServerPath"] + "/cfg/current/event.txt");
            Event resultEvent = new Event();
            resultEvent = JsonConvert.DeserializeObject<Event>(configString);
            return resultEvent;

        }
    }
}
