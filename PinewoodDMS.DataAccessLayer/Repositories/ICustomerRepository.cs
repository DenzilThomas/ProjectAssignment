using PinewoodDMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodDMS.DataAccessLayer.Repositories
{
    public interface ICustomerRepository
    {
        Customer Add(Customer entity);
        Customer Update(Customer entity);
        Customer? Get(Guid id);
        List<Customer> All();
        void SaveChanges();
        Customer Remove(Customer entity);
    }
}
