using DBF_Food.Models;
using Microsoft.AspNetCore.Mvc;

namespace DBF_Food.Repository.Category_Services
{
    public interface ICategory
    {
        Task<ActionResult<IEnumerable<Category>>> GetCategories();
        Task<ActionResult<Category>> GetCategory(string id);
        Task<IActionResult> PutCategory(string id, Category category);
        Task<ActionResult<Category>> PostCategory(Category category);
        Task<string> DeleteCategory(string id);
    }
}
