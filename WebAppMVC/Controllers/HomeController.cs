using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC.Models;
using WebAppMVC.Models.DB;
using WebAppMVC.Models.Interfaces;

namespace WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        // ссылка на репозиторий
        private readonly IBlogRepository _blogRepos;
        private readonly ILogger<HomeController> _logger;
        private readonly IRequestRepository _requestRepos;

        // Также добавим инициализацию в конструктор
        public HomeController(ILogger<HomeController> logger, IBlogRepository blogRepos, IRequestRepository requestRepos)
        {
            _logger = logger;
            _blogRepos = blogRepos;
            _requestRepos = requestRepos;
        }

        // Сделаем метод асинхронным
        public async Task<IActionResult> Index()
        {
            // Добавим создание нового пользователя
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "Andrey",
                LastName = "Petrov",
                JoinDate = DateTime.Now
            };

            // Добавим в базу
            await _blogRepos.AddUser(newUser);

            // Выведем результат
            Console.WriteLine($"User with id {newUser.Id}, named {newUser.FirstName} was successfully added on {newUser.JoinDate}");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Метод для просмотра всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Authors()
        {
            var authors = await _blogRepos.GetUsers();
            return View(authors);
        }

        public async Task<IActionResult> Logs()
        {
            var logs = await _requestRepos.GetLog();
            return View(logs);
        }
    }
}