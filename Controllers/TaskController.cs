using Microsoft.AspNetCore.Mvc;
using ProjectManagementApplication.Data;
using ProjectManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagementApplication.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index(int userstoryid)
        {
            var taskList = _context.Tasks.ToList();
            List<Task> taskStoryList = new List<Task>();

            foreach (Task task in taskList)
            {
                if (task.userstory_id == userstoryid)
                {
                    taskStoryList.Add(task);
                }
            }

            ViewBag.currentUserStoryID = userstoryid;
            ViewBag.Tasks = taskStoryList;

            return RedirectToAction("Index", "UserStoryController");
        }

        [HttpPost]
        public IActionResult CreateEditTask(Task task, int usid)
        {
            task.userstory_id = usid;

            if (task.id == 0)
            {
                _context.Tasks.Add(task);
            }
            else
            {
                _context.Tasks.Update(task);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask(int id, int usid)
        {
            var taskDB = _context.Tasks.Find(id);

            if (taskDB == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(taskDB);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // This method creates a new Task and adds it into the database
        // It is called by a function in JavaScript
        [HttpPost]
        public JsonResult SetTask(string taskname, int storyID, int projectID)
        {
            // Insert values for new Task
            Task newTask = new Task();
            newTask.userstory_id = storyID;
            newTask.taskText = taskname;
            newTask.project_id = projectID;
            newTask.state = 0;

            if (newTask.id == 0)
            {
                _context.Tasks.Add(newTask);
            }

            _context.SaveChanges();

            List<String> list = new List<String>();
            list.Add(taskname);
            return Json(list);
        }

    }
}
