using System;

namespace PX.Opc
{
    internal class OpcItemInfo
    {
        public string AccessPath { get; set; }
        public int AccessRights { get; set; }
        public int CanonicalDataType { get; set; }
        public long ClientHandle { get; set; }
        public bool IsActive { get; set; }
        public string Id { get; set; }
        public string GroupName { get; set; }
        public int Quality { get; set; }
        public int RequestedDataType { get; set; }
        public long ServerHandle { get; set; }
        public DateTime TimeStamp { get; set; }
        public object Value { get; set; }

        public OpcItemInfo()
        {
            this.AccessPath = default;
            this.AccessRights = default;
            this.CanonicalDataType = default;
            this.ClientHandle = default;
            this.IsActive = default;
            this.Id = default;
            this.GroupName = default;
            this.Quality = default;
            this.RequestedDataType = default;
            this.ServerHandle = default;
            this.TimeStamp = default;
            this.Value = default;
        }

        public override string ToString()
        {
            return $"AccessPath: {AccessPath}, AccessRights: {AccessRights}, CanonicalDataType: {CanonicalDataType}, " +
                $"ClientHandle: {ClientHandle}, IsActive: {IsActive}, Id: {Id}, GroupName: {GroupName}, " +
                $"Quality: {Quality}, RequestDataType: {RequestedDataType}, ServerHandle: {ServerHandle}, " +
                $"TimeStamp: {TimeStamp}, Value: {Value}.";
        }
    }
}
