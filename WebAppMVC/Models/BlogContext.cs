using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models.DB;

namespace WebAppMVC.Models
{
    public class BlogContext : DbContext
    {
        /// <summary>
        /// Ссылка на таблицу Users
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Ссылка на таблицу UserPosts
        /// </summary>
        public DbSet<UserPost> UserPosts { get; set; }

        /// <summary>
        /// Ссылка на таблицу Requests
        /// </summary>
        public DbSet<Request> Requests { get; set; }

        /// <summary>
        /// Логика взаимодействия с таблицами в БД
        /// </summary>
        /// <param name="options"></param>
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            // чтобы база данных создавалась сразу при необходимости
            Database.EnsureCreated();
        }
    }
}
