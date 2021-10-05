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

        [HttpPost]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var user = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id);
                if (user != null)
                {
                    _database.Accounts.Remove(user);
                    await _database.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }
        
        [HttpGet]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> ConfinDelete(int? id)
        {
            if (id != null)
            {
                var user = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id);
                if (user != null)
                {
                    return View(user);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var user = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id);
                if (user != null)
                {
                    _database.Accounts.Remove(user);
                    await _database.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }
    }
}