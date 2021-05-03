using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Models
{
    public class Filter
    {
        public string name { get; set; }
    }

    public class UserSearch
    {
        public Filter filter { get; set; }
    }
}
