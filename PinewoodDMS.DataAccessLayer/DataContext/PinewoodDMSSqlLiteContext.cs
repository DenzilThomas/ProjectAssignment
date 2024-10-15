using Microsoft.EntityFrameworkCore;
using PinewoodDMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodDMS.DataAccessLayer.DataContext
{
    public class PinewoodDMSSqlLiteContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            var connectionString = "Data Source=PinewoodDMSSqlLite.db;";
            optionsBuilder.UseSqlite(connectionString);

        }


        public static void CreateInitialDatabase(PinewoodDMSSqlLiteContext context)
        {

            context.Database.EnsureDeleted();
            context.Database.Migrate();
            context.Customers.Add(new Customer { FirstName = "Amanda", LastName = "Smith", HouseNumber = "12A", AddressLine1 = "Church Lane", AddressLine2 = "Winsor Gardens", Telephone = "07888543215", Email = "Amanda.Smith@yahoo.com", City = "Oxford", PostalCode = "OX12 5ED", Country = "United Kingdom" });
            context.Customers.Add(new Customer { FirstName = "Robert", LastName = "Spencer", HouseNumber = "11", AddressLine1 = "High Street", AddressLine2 = "Nightingale Area", Telephone = "07672543234", Email = "Robert.Spencer@outlook.com", City = "Warwick", PostalCode = "CV23 5ED", Country = "United Kingdom" });
            context.Customers.Add(new Customer { FirstName = "Clavin", LastName = "White", HouseNumber = "20", AddressLine1 = "Evan close", AddressLine2 = "Jephons", Telephone = "07634543234", Email = "Clavin.White@gmail.com", City = "London", PostalCode = "L12 5ED", Country = "United Kingdom" });
            context.SaveChanges();

        }


    }
}
