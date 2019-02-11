using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRazor.Models
{
    public class HumanModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int FavoriteNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
