using Microsoft.AspNetCore.Mvc;
using PracticeWebSQL.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace PracticeWebSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _database;
        public HomeController(ApplicationContext context)
        {
            _database = context;
        }
        
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _database.Accounts.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}