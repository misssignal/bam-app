using Microsoft.EntityFrameworkCore;
using PostgresDB.Controllers;

namespace PostgresDB.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Food> sample_table_food { get; set; }
        public DbSet<Juice> sample_table_juice { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class Food
    {
        public int id { get; set; }
        public string type { get; set; }
        public string chnl_name_1 { get; set; }
        public string chnl_name_2 { get; set; }
        public string chnl_name_3 { get; set; }
        public string to { get; set; }
        public string pos { get; set; }
        public string ml { get; set; }
        public string fl1 { get; set; }
        public string fl2 { get; set; }
        public string fl3 { get; set; }
        public string dim { get; set; }
        public string dir { get; set; }
        public string filt { get; set; }
    }
    public class Juice
    {
        public int id { get; set; }
        public string type { get; set; }
        public string chnl_name_1 { get; set; }
        public string chnl_name_2 { get; set; }
        public string chnl_name_3 { get; set; }
        public string to { get; set; }
        public string pos { get; set; }
        public string ml { get; set; }
        public string fl1 { get; set; }
        public string fl2 { get; set; }
        public string fl3 { get; set; }
        public string dim { get; set; }
        public string dir { get; set; }
        public string filt { get; set; }
    }
}
