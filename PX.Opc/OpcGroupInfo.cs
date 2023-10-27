namespace PX.Opc
{
    public class OpcGroupInfo
    {
        public int ClientHandle { get; set; }
        public float DeadBand { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; set; }
        public bool IsSubscribed { get; set; }
        public int LocalId { get; set; }
        public string Name { get; set; }
        public string ServerName { get; set; }
        public int ServerHandle { get; internal set; }
        public int TimeBias { get; set; }
        public int UpdateRate { get; set; }

        public OpcGroupInfo()
        {
            this.ClientHandle = default;
            this.DeadBand = default;
            this.IsActive = default;
            this.IsPublic = default;
            this.IsSubscribed = default;
            this.LocalId = default;
            this.Name = default;
            this.ServerName = default;
            this.ServerHandle = default;
            this.TimeBias = default;
            this.UpdateRate = default;
        }

        public override string ToString()
        {
            return $"ClientHandle: {ClientHandle}, DeadBand: {DeadBand}, IsActive: {IsActive}, IsPublic: {IsPublic}, " +
                $"IsSubscribed: {IsSubscribed}, LocalId: {LocalId}, Name: {Name}, ServerName {ServerName}, " +
                $"ServerHandle: {ServerHandle}, TimeBias: {TimeBias}, UpdateRate: {UpdateRate}.";
        }
    }
}
