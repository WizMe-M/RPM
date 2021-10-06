using Microsoft.AspNetCore.Mvc;
using PracticeWebSQL.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PracticeWebSQL.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext _database;

        public HomeController(ApplicationContext context)
        {
            _database = context;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _database.Accounts.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Create(Account account)
        {
            _database.Accounts.Add(account);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Account account)
        {
            _database.Accounts.Update(account);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> Editing(int? id)
        {
            if (id == null) return NotFound();
            
            var user = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id);
            if (user != null)
            {
                return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var user = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id);
            
            if (user == null) return NotFound();
            _database.Accounts.Remove(user);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> Deleting(int? id)
        {
            if (id == null) return NotFound();
            var user = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id);
            
            if (user != null)
            {
                return View(user);
            }

            return NotFound();
        }
    }
}