namespace PX.Opc
{
    public class OpcGroupInfo
    {
        public int ClientHandle { get; }
        public float DeadBand { get; }
        public bool IsActive { get; }
        public bool IsPublic { get; }
        public bool IsSubscribed { get; }
        public int LocalId { get; }
        public string Name { get; }
        public string ServerName { get; }
        public int ServerHandle { get; }
        public int TimeBias { get; }
        public int UpdateRate { get; }

        public OpcGroupInfo(int clientHandle, float deadBand, bool isActive, bool isPublic, bool isSubscribed, int localId, string name, string serverName, int serverHandle, int timeBias, int updateRate)
        {
            this.ClientHandle = clientHandle;
            this.DeadBand = deadBand;
            this.IsActive = isActive;
            this.IsPublic = isPublic;
            this.IsSubscribed = isSubscribed;
            this.LocalId = localId;
            this.Name = name;
            this.ServerName = serverName;
            this.ServerHandle = serverHandle;
            this.TimeBias = timeBias;
            this.UpdateRate = updateRate;
        }

        public override string ToString()
        {
            return $"ClientHandle: {ClientHandle}, DeadBand: {DeadBand}, IsActive: {IsActive}, IsPublic: {IsPublic}, " +
                $"IsSubscribed: {IsSubscribed}, LocalId: {LocalId}, Name: {Name}, ServerName {ServerName}, " +
                $"ServerHandle: {ServerHandle}, TimeBias: {TimeBias}, UpdateRate: {UpdateRate}.";
        }
    }
}
