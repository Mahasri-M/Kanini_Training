using DBF_Food.Models;
using DBF_Food.Repository.Category_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBF_Food.Repository.Customerdet_Services
{
    public class CusDetSer
    {
      /*  public FoodContext _food;
        public CusDetSer(FoodContext food)
        {
            _food = food;
        }
        public async Task<ActionResult<IEnumerable<Category>>> GetCustomerDets()
        {
            var cusdet = await _food.CustomerDets.ToListAsync();
            return cusdet;
        }
        public async Task<ActionResult<CustomerDet>> GetCustomerDet(int id)
        {
            var cusdets = await _food.Categories.FindAsync(id);
            if (cusdets is null)
            {
                return null;
            }
            return cusdets;
        }
        public async Task<IActionResult> PutCategoryDet(int id, CustomerDet customerDet)
        {
            CategorySer cate = await _food.Categories.FirstOrDefaultAsync(x => x.MobNum == id);
            cate.Name = customerDet.Name;
            cate.MobNum = customerDet.MobNum;
            cate.City = customerDet.City;
            await _food.SaveChangesAsync();
            return (IActionResult)customerDet;
        }
        public string Task<ActionResult<CustomerDet>> PostCustomerDet(CustomerDet customerDet)
        {
            _food.Categories.Add(customerDet);
            _food.SaveChanges();
            return "Added successfully";
        }
        public async Task<IActionResult> DeleteCustomerDet(int id)
        {
            CategorySer cat = await _food.Categories.FirstOrDefaultAsync(x => x.MobNum == id);
            _food.Categories.Remove(cat);
            _food.SaveChanges();
            return "Deleted succesfully";
        }*/
    }
}
