using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace soorat.api.Models
{
    public class User : IdentityUser<int>
    {
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
        public int SmsSendNumber { get; set; }
        public DateTime LastSmsSend { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}