using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApplication.Models
{
    public class UserStory
    {

        public int id { get; set; }
        public int storyNumber { get; set; }
        public int project_id { get; set; }
        public String name { get; set; }
        public String descriptionTitle { get; set; }
        public String imageURLs { get; set; }
        public String description { get; set; }
        public int state {get; set;}

    }
}
