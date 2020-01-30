using Microsoft.EntityFrameworkCore;

using ActivityAPI.Models;

namespace ActivityAPI.Models
{
    public class AppDbContex : DbContext    
    {
        //untuk menambah table baru, ditambahkan disini
        public DbSet<Activity> Activities{get; set;}
        
        public AppDbContex(DbContextOptions options) : base(options)
        {

        }
    }
}