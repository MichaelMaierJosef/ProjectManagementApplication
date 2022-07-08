namespace ProjectManagementApplication.Models
{
    public class ProjectUser
    {

        public ProjectUser(int projectID, string userID, short admin)
        {
            ProjectID = projectID;
            UserID = userID;
            Admin = admin;
        }

        public int Id { get; set; }

        public int ProjectID { get; set; }

        public string UserID { get; set; }

        public short Admin { get; set; }
    }
}
