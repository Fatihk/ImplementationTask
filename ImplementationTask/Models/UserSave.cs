using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Models
{
    public class UserSave
    {
        public int userId { get; set; }
        public string action { get; set; }
        public DateTime timestamp { get; set; }
    }
}
