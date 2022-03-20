using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mid_assignment_backend.Models
{
    public class ResponseUser
    {
        //public int? Id { get; set; }
        public string Username { get; set; }
        //public string Role { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}