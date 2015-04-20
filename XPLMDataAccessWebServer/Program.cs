using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPLMDataAccessWebServer
{
    class Program
    {
        static void Main(string[] args)
        {

            string port = "1337";
            
            if (args.Length > 0)
                port = args[0];

            var listeningOn = "http://*:" + port + "/";
            var appHost = new AppHost();
            appHost.Init();

            appHost.Start(listeningOn);

            Console.WriteLine("XPLMDataAccesssWebServer created by A.Eckers");
            Console.WriteLine("Use XPLMDataAccesssWebServer.exe {port} commandline to change the default listening port to another portnumber.");
            Console.WriteLine("The default port is 1337");
            Console.WriteLine("");
            Console.WriteLine("Use the description page 'http://localhost:{port}/XPLMDataAccess' for more information.");
            Console.WriteLine("");
            Console.WriteLine("Created at {0}, listening on {1}", DateTime.Now, listeningOn);
            Console.WriteLine("Press any key for exit");
            Console.ReadKey();

        }
    }
}
