using PinewoodDMS.DataAccessLayer.DataContext;
using PinewoodDMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodDMS.DataAccessLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private PinewoodDMSSqlLiteContext context;
        public CustomerRepository(PinewoodDMSSqlLiteContext context)
        {
            this.context = context;
        }
        public Customer Add(Customer entity)
        {
            var addedEntity = context.Add(entity).Entity;
            SaveChanges();
            return addedEntity;
        }
        public List<Customer> All()
        {
            var all = context.Set<Customer>().ToList();

            return all;
        }

        public Customer? Get(Guid id)
        {
            return context.Find<Customer>(id);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public Customer Update(Customer entity)
        {
            var updatedEntity = context.Update(entity).Entity;
            SaveChanges();
            return updatedEntity;
        }

        public Customer Remove(Customer entity)
        {
            var deletedEntity = context.Remove(entity).Entity;
            SaveChanges();
            return deletedEntity;
        }
    }
}
