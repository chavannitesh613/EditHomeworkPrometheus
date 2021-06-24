using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Homework
    {
        public int HomeWorkID { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        public string ReqTime { get; set; }

        public string LongDescription { get; set; }

    }
}
