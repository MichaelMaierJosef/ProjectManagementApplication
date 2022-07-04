using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApplication.Models
{
    public class Task
    {
        public int id { get; set; }
        public int userstory_id { get; set; }
        public int project_id { get; set; }
        public String taskText { get; set; }
        public int state { get; set; }
    }
}
