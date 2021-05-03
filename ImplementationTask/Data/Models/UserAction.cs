using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Data.Models
{
    public class UserAction
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Action { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
