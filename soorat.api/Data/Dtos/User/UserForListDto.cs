using System;
using System.Collections.Generic;
using soorat.api.Models;

namespace soorat.api.Data.Dtos.User
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CodeMeli { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public byte[] Pic { get; set; }
        public string Jensiyat { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastActive { get; set; }
        public bool Active { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}