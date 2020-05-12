using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace user_microservice.Models
{
    public class Roles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool EditPrivilege { get; set; }
    }
}
