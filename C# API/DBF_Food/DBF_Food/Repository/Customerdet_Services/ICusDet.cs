using DBF_Food.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBF_Food.Repository.Customerdet_Services
{
    public interface ICusDet
    {
        Task<ActionResult<IEnumerable<Category>>> GetCustomerDets();
        Task<ActionResult<CustomerDet>> GetCustomerDet(int id);
        Task<IActionResult> PutCustomerDet(int id, CustomerDet customerDet);
        Task<ActionResult<CustomerDet>> PostCustomerDet(CustomerDet customerDet);
        Task<IActionResult> DeleteCustomerDet(int id);

    }
}
