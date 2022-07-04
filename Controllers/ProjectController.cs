using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementApplication.Data;
using ProjectManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApplication.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var projectList = _context.Projects.ToList();

            ViewBag.Projects = projectList;

            return View();
        }

        public IActionResult CreateEdit(int id)
        {
            if (id == 0)
            {
                return View("CreateEditProject");
            }

            var projectInDb = _context.Projects.Find(id);

            if (projectInDb == null)
            {
                return NotFound();
            }

            return View("CreateEditProject", projectInDb);
        }

        [HttpPost]
        public IActionResult CreateEditProject(Project project)
        {
            if (project.id == 0)
            {
                _context.Projects.Add(project);
            } else
            {
                _context.Projects.Update(project);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult DeleteProject(int id)
        {
            var projectInDb = _context.Projects.Find(id);

            if (projectInDb == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projectInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult setIdFromJs(string str_projectId)
        {
            int projectId = Int32.Parse(str_projectId);

            return RedirectToAction("CreateEdit", projectId);
        }
    }
}
