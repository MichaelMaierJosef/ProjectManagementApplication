using Microsoft.AspNetCore.Mvc;
using ProjectManagementApplication.Data;
using ProjectManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApplication.Controllers
{
    public class UserStoryController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UserStoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(int projectid, string projectName)
        {
            var storyList = _context.UserStorys.ToList();
            List<UserStory> projectStoryList = new List<UserStory>();

            foreach (UserStory story in storyList)
            {
                if (story.project_id == projectid)
                {
                    projectStoryList.Add(story);
                }
            }

            ViewBag.currentProjectId = projectid;
            ViewBag.currentProjectName = projectName;
            ViewBag.UserStorys = projectStoryList;

            return View();
        }
        
        [HttpPost]
        public IActionResult CreateEditUserStory(UserStory story, int pid, string pname)
        {
            story.project_id = pid;

            if (story.id == 0)
            {
                _context.UserStorys.Add(story);
            }
            else
            {
                _context.UserStorys.Update(story);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", new { projectid = pid, projectName = pname });
        }

        public IActionResult DeleteStory(int id, int pid, string pname)
        {
            var storyDB = _context.UserStorys.Find(id);

            if (storyDB == null)
            {
                return NotFound();
            }

            _context.UserStorys.Remove(storyDB);
            _context.SaveChanges();

            return RedirectToAction("Index", new { projectid = pid, projectName = pname });
        }

        [HttpPost]
        public IActionResult ChangeStateUserStory(string newname, UserStory story, int pid, string pname)
        {

            switch (story.state)
            {
                case 0:
                    story.state = 1;
                    break;
                case 1:
                    story.state = 2;
                    break;
                case 2:
                    story.state = 0;
                    break;
            }

            _context.UserStorys.Update(story);
            _context.SaveChanges();

            return RedirectToAction("Index", _context.UserStorys);
        }

    }
}


