using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApplication.Models
{
    public class Project
    {
        public int id { get; set; }

        public String projectName { get; set; }

        public String tense { get; set; }

        public String description { get; set; }
    }
}
