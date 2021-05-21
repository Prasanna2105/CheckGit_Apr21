using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProfileTaskMVC.Models;
using ProfileTaskMVC.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileTaskMVC.Controllers
{
    public class ProfileController : Controller
    {
        
        private ILogger<ProfileController> _logger;
        private IRepo<Profile> _repo;

        public ProfileController(IRepo<Profile> repo, ILogger<ProfileController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public IActionResult Index()
        {
            List<Profile> profiles = _repo.GetAll().ToList();
            return View(profiles);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Profile profile)
        {
           
                _repo.Add(profile);
                return RedirectToAction("Index");
            
            
        }
        public IActionResult Details(int id)
        {
            Profile profile = _repo.Get(id);
            return View(profile);
        }
        [HttpPost]
        public IActionResult Details(Profile profile)
        {
            _repo.Delete(profile);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Profile profile = _repo.Get(id);
            return View(profile);
        }
        [HttpPost]
        public IActionResult Edit(int id, Profile profile)
        {
            _repo.Update(id, profile);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Profile profile = _repo.Get(id);
            return View(profile);
        }
        public IActionResult Delete(Profile profile)
        {
            _repo.Delete(profile);
            return RedirectToAction("Index");
        }


    }
}
