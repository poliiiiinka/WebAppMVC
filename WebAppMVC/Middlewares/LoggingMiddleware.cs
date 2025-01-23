using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System;
using WebAppMVC.Models.DB;
using WebAppMVC.Models.Interfaces;

namespace WebAppMVC.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _repo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository repo)
        {
            _next = next;
            _repo = repo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke  или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            var request = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = context.Request.Host.Value + context.Request.Path
            };

            await _repo.AddLog(request);

            // Для логирования данных о запросе используем свойства объекта HttpContext
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            // Передача запроса далее по конвейеру
            await _next.Invoke(context);
        }
    }
}
