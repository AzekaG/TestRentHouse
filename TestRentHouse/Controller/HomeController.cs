using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestRentHouse.Context;
using TestRentHouse.Models;

namespace TestRentHouse.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly HouseDbContext _houseDbContext;
        public HomeController(HouseDbContext houseDbContext)
        {
            _houseDbContext = houseDbContext;
            
        }

        // GET: HomeController
        public async Task<IActionResult> Index()
        {
       
            int id = 1;
            var el = _houseDbContext.Users.Where(q => q.Id == id).Include(x => x.Status)
                                                .Include(y => y.Houses).FirstOrDefaultAsync().Result;

            var hs = await _houseDbContext.Houses.Where(x => x.Owner.Id == id).Include(x => x.Images_Path).ToListAsync();

            ModelUser_House mod = new ModelUser_House {HouseList = hs , User = el };

            return View(mod); 
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
