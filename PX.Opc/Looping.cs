using System;
using System.Collections.Generic;

namespace PX.Opc
{
    public class Looping : ILoop
    {
        private readonly Config config;
        private readonly Opc opc;

        public Looping(Config config)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config), "Config can't be null.");
            this.opc = new Opc();
        }

        public void PreLoop()
        {
            List<string> opcServers = opc.GetOpcServers("127.0.0.1");
            opcServers.ForEach(x => Console.WriteLine(x));

            this.opc.Connect(this.config.OpcServerConfig);
            Console.WriteLine("OPC connection ok.");

            this.opc.AddGroup("MyGroup");
            this.opc.AddItems("MyGroup", this.config.OpcServerConfig.OpcGroupConfigs[0].OpcItemConfigs);
        }

        public void Loop()
        {
            // Write item 0 value.
            this.opc.WriteItem("MyGroup", this.config.OpcServerConfig.OpcGroupConfigs[0].OpcItemConfigs[0], (object)33);

            // Read item 1 value.
            object value = opc.ReadItem("MyGroup", this.config.OpcServerConfig.OpcGroupConfigs[0].OpcItemConfigs[1]);
            Console.WriteLine(value.ToString());

            // Get group 0 information.
            OpcGroupInfo opcGroupInfo = opc.GetGroupInfo("MyGroup");
            Console.WriteLine(opcGroupInfo.ToString());

            // Get item 1 information.
            OpcItemInfo itemInfo = opc.GetItemInfo("MyGroup", this.config.OpcServerConfig.OpcGroupConfigs[0].OpcItemConfigs[1]);
            Console.WriteLine(itemInfo.ToString());
        }

        public void PostLoop()
        {
            this.opc.Disconnect();
            Console.WriteLine("OPC diconnection ok.");
        }
    }
}
