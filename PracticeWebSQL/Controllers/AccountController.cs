using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeWebSQL.Models;
using PracticeWebSQL.Models.DatabaseIdentities;

namespace PracticeWebSQL.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _database;
        public AccountController(ApplicationContext options)
        {
            _database = options;
        }
        
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Account account)
        {
            _database.Accounts.Add(account);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ActionName(nameof(Edit))]
        public async Task<IActionResult> Editing(int? id)
        {
            if (id != null)
            {
                var user = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id);
                if (user != null)
                {
                    return View(user);
                }

                return NotFound();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Account account)
        {
            _database.Accounts.Update(account);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ActionName(nameof(Delete))]
        public async Task<IActionResult> Deleting(int? id)
        {
            if (id != null)
            {
                var user = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id);

                if (user != null)
                {
                    return View(user);
                }

                return NotFound();
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
                    return RedirectToAction("Index", "Home");
                }

                return NotFound();
            }

            return NotFound();

        }
    }
}