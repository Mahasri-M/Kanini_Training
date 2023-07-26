using DBF_Food.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBF_Food.Repository.Category_Services
{
    public class CategorySer
    {
     /*   public FoodContext _food;
        public CategorySer (FoodContext food)
        {
            _food = food;
        }

        public object CId { get; private set; }
        public object CType { get; private set; }

        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var cate = await _food.Categories.ToListAsync();
            return cate;
        }
        public async Task<ActionResult<Category>> GetCategory(string id)
        {
            var cates=await _food.Categories.FindAsync(id);
            if(cates is null)
            {
                return null;
            }
            return cates;
        }
        public async Task<IActionResult> PutCategory(string id, Category category)
        {
            CategorySer cate = await _food.Categories.FirstOrDefaultAsync(x => x.CId == id);
            cate.CId = category.CId;
            cate.CType = category.CType;
            await _food.SaveChangesAsync();
            return (IActionResult)category;
        }

        public static implicit operator CategorySer?(Category? v)
        {
            throw new NotImplementedException();
        }
        public string PostCategory(Category category)
        {
            _food.Categories.Add(category);
            _food.SaveChanges();
            return "Added successfully";
        }
        public async Task<string> DeleteCategory(string id)
        {
            CategorySer cat=await _food.Categories.FirstOrDefaultAsync(x=>x.CId == id);
            _food.Categories.Remove(cat);
            _food.SaveChanges();
            return "Deleted succesfully";
        }*/
    }
}
