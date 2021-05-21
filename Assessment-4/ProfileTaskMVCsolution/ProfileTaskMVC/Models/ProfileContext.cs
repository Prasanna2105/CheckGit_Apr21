using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileTaskMVC.Models
{
    public class ProfileContext:DbContext
    {
        public ProfileContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Profile> Profiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
              new Profile() { Id=1,Name = "Ramu", Age= 25,Qualification="BE",IsEmployed="YES",NoticePeriod="2",CurrentCTC=25000 });
        }
    }
}
