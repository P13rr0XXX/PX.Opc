using OPCAutomation;
using System;
using System.Collections.Generic;

namespace PX.Opc
{
    internal class Opc
    {
        private const int one = 1;

        public OPCServer OpcServer;
        public List<OPCGroups> OpcGroups;

        public Opc()
        {
            this.OpcServer = new OPCServer();
            this.OpcGroups = new List<OPCGroups>();
        }

        public List<string> GetOpcServers(string node = default)
        {
            object opc = this.OpcServer.GetOPCServers(node);

            Array opcServers = (Array)opc;
            List<string> list = new List<string>();
            for(int i = one; i < opcServers.Length + one; i++)
            {
                list.Add(opcServers.GetValue(i).ToString());
            }
            return list;
        }

        public void Connect(OpcServerConfig opcServerConfig)
        {
            this.OpcServer.Connect(opcServerConfig.Name, opcServerConfig.Node);
        }

        public void AddGroup(string name)
        {
            this.OpcServer.OPCGroups.Add(name);
        }

        /*
        public void Event(string name)
        {
            this.OpcServer.OPCGroups.Item(name).DataChange += this.Opc_DataChange;
        }

        private void Opc_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            Console.WriteLine(TransactionID.ToString());
            for(int i = 0; i < NumItems; i++)
            {

            }
        }
        */

        public void AddItem(string name, OpcItemConfig itemConfig)
        {
            this.OpcServer.OPCGroups.Item(name).OPCItems.AddItem(itemConfig.Id, itemConfig.Handle);
        }

        public void AddItems(string name, List<OpcItemConfig> itemConfigs)
        {
            int count = itemConfigs.Count;
            Array ids = new string[count + one];
            Array clientHandles = new int[count + one];
            Array serverHandles = new int[count + one];
            Array errors = new int[count + one];

            for (int i = one; i < count + one; i++)
            {
                ids.SetValue(itemConfigs[i - one].Id, i);
                clientHandles.SetValue(itemConfigs[i - one].Handle, i);
            }

            this.OpcServer.OPCGroups.Item(name).OPCItems.AddItems(count, ids, clientHandles, out serverHandles, out errors);

            for (int i = one; i < count + one; i++)
            {
                if ((int)errors.GetValue(i) != 0)
                {

                }
            }
        }

        public object ReadItem(string name, OpcItemConfig itemConfig)
        {
            short source = (short)OpcSource.Device;

            this.OpcServer.OPCGroups.Item(name).OPCItems.Item(itemConfig.Id).Read(source, out object value, out object quality, out object timeStamp);
            return value; ;
        }

        public void WriteItem(string name, OpcItemConfig itemConfig, object value)
        {
            this.OpcServer.OPCGroups.Item(name).OPCItems.Item(itemConfig.Id).Write(value);
        }

        public OpcItemInfo GetItemInfo(string name, OpcItemConfig itemConfig)
        {
            OpcItemInfo opcItemInfo = new OpcItemInfo();

            OPCItem item = this.OpcServer.OPCGroups.Item(name).OPCItems.Item(itemConfig.Id);
            opcItemInfo.AccessPath = item.AccessPath;
            opcItemInfo.AccessRights = item.AccessRights;
            opcItemInfo.CanonicalDataType = item.CanonicalDataType;
            opcItemInfo.ClientHandle = item.ClientHandle;
            opcItemInfo.IsActive = item.IsActive;
            opcItemInfo.Id = item.ItemID;
            opcItemInfo.GroupName = item.Parent.Name;
            opcItemInfo.Quality = item.Quality;
            opcItemInfo.RequestedDataType = item.RequestedDataType;
            opcItemInfo.ServerHandle = item.ServerHandle;
            opcItemInfo.TimeStamp = item.TimeStamp;
            opcItemInfo.Value = item.Value;

            return opcItemInfo;
        }

        public OpcGroupInfo GetGroupInfo(string name)
        {
            OPCGroup group = this.OpcServer.OPCGroups.Item(name);
            
            return new OpcGroupInfo(
                group.ClientHandle,
                group.DeadBand,
                group.IsActive,
                group.IsPublic,
                group.IsSubscribed,
                group.LocaleID,
                group.Name,
                group.Parent.ServerName,
                group.ServerHandle,
                group.TimeBias,
                group.UpdateRate
                );
        }

        public OpcServerInfo GetServerInfo()
        {
            return new OpcServerInfo(
                OpcServer.Bandwidth,
                OpcServer.BuildNumber,
                OpcServer.ClientName,
                OpcServer.CurrentTime,
                OpcServer.LastUpdateTime,
                OpcServer.LocaleID,
                OpcServer.MajorVersion,
                OpcServer.MinorVersion,
                OpcServer.ServerName,
                OpcServer.ServerNode,
                OpcServer.ServerState,
                OpcServer.StartTime,
                OpcServer.VendorInfo
                );
        }

        public void Disconnect()
        {
            this.OpcServer.OPCGroups.RemoveAll();
            this.OpcServer.Disconnect();
        }
    }
}
