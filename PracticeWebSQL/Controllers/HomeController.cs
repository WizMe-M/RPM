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

        public async Task<IActionResult> Index()
        {
            var model = new DatabaseModel
            {
                Accounts = await _database.Accounts.ToListAsync(),
                Roles = await _database.Roles.ToListAsync()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> CreateAccount()
        {
            var model = new AccountRolesModel
            {
                Account = new Account(),
                Roles = await _database.Roles.ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAccount(Account account, int role_id)
        {
            account.RoleID = role_id;
            _database.Accounts.Add(account);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName(nameof(EditAccount))]
        public async Task<IActionResult> EditingAccount(int? id)
        {
            if (id != null)
            {
                var model = new AccountRolesModel
                {
                    Account = await _database.Accounts.FirstOrDefaultAsync(user => user.ID == id),
                    Roles = await _database.Roles.ToListAsync()
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> EditAccount(Account account)
        {
            _database.Accounts.Update(account);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName(nameof(DeleteAccount))]
        public async Task<IActionResult> DeletingAccount(int? id)
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
        public async Task<ActionResult> DeleteAccount(int? id)
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

                return NotFound();
            }

            return NotFound();
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(Role role)
        {
            var existing = await _database.Roles.FirstOrDefaultAsync(r => r.Name == role.Name);
            if (existing is null)
            {
                _database.Roles.Add(role);
                await _database.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName(nameof(EditRole))]
        public async Task<IActionResult> EditingRole(int? id)
        {
            if (id != null)
            {
                var role = await _database.Roles.FirstOrDefaultAsync();
                return View(role);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> EditRole(Role role)
        {
            var existing = await _database.Roles.FirstOrDefaultAsync(r => r.Name == role.Name);
            if (existing is null)
            {
                _database.Roles.Update(role);
                await _database.SaveChangesAsync();
            }
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName(nameof(DeleteRole))]
        public async Task<IActionResult> DeletingRole(int? id)
        {
            if (id != null)
            {
                var role = await _database.Roles.FirstOrDefaultAsync(r => r.ID == id);
                return View(role);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteRole(int? id)
        {
            if (id != null)
            {
                var role = await _database.Roles.FirstOrDefaultAsync(r => r.ID == id);
                
                if (role != null)
                {
                    _database.Roles.Remove(role);
                    await _database.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return NotFound();
            }

            return NotFound();
        }
    }
}