using DataBaseDemo.Controllers;
using Microsoft.EntityFrameworkCore;

namespace DataBaseDemo.DataBase
{
    public class MyDbContext :DbContext
    {
        public MyDbContext()
        {
            
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MyServer; DataBase = MyDataBase");
        }
    }
}
