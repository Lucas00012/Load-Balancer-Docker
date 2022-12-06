using Microsoft.AspNetCore.Mvc;
using Mvc1.Infrastructure.Data;
using Mvc1.Models;

namespace Mvc1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public HomeController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var produtos = _dbContext.Produtos.ToList();
            ViewData["Docker"] = $"Docker - {_configuration["HOSTNAME"]}";

            return View(produtos);
        }
    }
}
