﻿namespace FlightWebApi.Models
{
    public class GroupPermission
    {
        public int Id { get; set; }
        public string RoleName {  get; set; }
        public int UserId { get; set; }
        public ICollection<Permisson> permissons { get; set; }
    }
}
