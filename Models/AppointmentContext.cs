using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleSignUp.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments { get; set; }

        //seeding data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Appointment>().HasData(
                new Appointment
                {
                    AppointmentID= 1,
                    GroupName= "Joe's Peeps",
                    GroupSize= 15,
                    PhoneNumber= "555-555-5555",
                    Email = "email@email.com",
                    Date = new DateTime(2011, 6, 10),
                    Time = 16
                },
                new Appointment
                {
                    AppointmentID= 2,
                    GroupName= "Marsha",
                    Email= "Brady@email.com",
                    GroupSize= 10,
                    PhoneNumber = "921-345-6456",
                    Date = new DateTime(2022, 5, 5),
                    Time = 10
                }
            );
        }

    }
}
