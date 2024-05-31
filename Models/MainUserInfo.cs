using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Love.Models
{
    public class MainUserInfo
    {
        public Guid userId { get; set; }
        public string userName { get; set; }
        public string userEmail { get; set; }
    }
}