using System;

namespace PX.Opc
{
    public class OpcServerInfo
    {
        public long Bandwidth { get; }
        public int BuildVersion { get; }
        public string ClientName { get; }
        public DateTime CurrentTime { get; }
        public DateTime LastUpdateTime { get; }
        public long LocaleId { get; }
        public int MajorVersion { get; }
        public int MinorVersion { get; }
        public string ServerName { get; }
        public string ServerNode { get; }
        public long ServerState { get; }
        public DateTime StartTime { get; }
        public string VendorInfo { get; }
        public Version Version
        {
            get => new Version(MajorVersion, MinorVersion, BuildVersion);
        }

        public OpcServerInfo(long bandwidth, int buildVersion, string clientName, DateTime currentTime,
            DateTime lastUpdateTime, long localeId, int majorVersion, int minorVersion,
            string serverName, string serverNode, long serverState, DateTime startTime,
            string vendorInfo)
        {
            Bandwidth = bandwidth;
            BuildVersion = buildVersion;
            ClientName = clientName;
            CurrentTime = currentTime;
            LastUpdateTime = lastUpdateTime;
            LocaleId = localeId;
            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            ServerName = serverName;
            ServerNode = serverNode;
            ServerState = serverState;
            StartTime = startTime;
            VendorInfo = vendorInfo;
        }

        public override string ToString()
        {
            return $"Bandwidth: {Bandwidth}, BuildVersion: {BuildVersion}, ClientName: {ClientName}, CurrentTime: {CurrentTime}, " +
                $"LastUpdateTime: {LastUpdateTime}, LocaleId: {LocaleId}, MajorVersion: {MajorVersion}, MinorVersion: {MinorVersion}, " +
                $"ServerName: {ServerName}, ServerNode: {ServerNode}, ServerState: {ServerState}, StartTime: {StartTime}, " +
                $"VendorInfo: {VendorInfo}, Version: {Version}.";
        }
    }
}
