namespace PX.Opc
{
    public class OpcItem
    {
        public string Id { get; set; }
        public long ClientHandle { get; set; }
        public long ServerHandle { get; set; }
        public object Value { get; set; }

        public OpcItem() : this(default, default, default) { }

        public OpcItem(string id, long clientHandle, long serverHandle)
        {
            this.Id = id;
            this.ClientHandle = clientHandle;
            this.ServerHandle = serverHandle;
            this.Value = default;
        }
    }
}
