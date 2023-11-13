namespace FlightWebApi.DTO
{
    public class PermissionDTO
    {
        public int TypeId { get; set; }
        public string Note { get; set; }
        public int GroupPermissionId { get; set; }
        public bool ReadAndModify { get; set; }
        public bool ReadOnly { get; set; }
        public bool NoPermission { get; set; }
    }
}
