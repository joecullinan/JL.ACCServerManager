using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace JL.ACCServerManager.LocalMachineFunctions
{

    /// <summary>
    /// Low-Level functions for controlling the server process, starting and stopping, and modifying the filesystem to update configs. 
    /// </summary>
    public class LocalServerController
    {

        private readonly IConfiguration Configuration;


        public LocalServerController(IConfiguration configuration)
        {
            Configuration = configuration;
            //see if server exists at location
            var serverExe = new FileInfo(Configuration["ACCServerPath"] + Configuration["ACCServerExecutableName"] )
            //see if server is running
            


        }


        public string restartServer()
        {


        }
    }
}
