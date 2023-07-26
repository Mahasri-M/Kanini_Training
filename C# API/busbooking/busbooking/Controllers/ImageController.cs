using busbooking.Models;
using busbooking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace busbooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImg imageRepository;

        public ImageController(IImg imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var image = imageRepository.GetImage(id);
        //    if (image == null)
        //    {
        //        return NotFound();
        //    }

        //    return File(image.Data, "image/jpeg"); // Adjust the content type as per your image type
        //}
        //[HttpPost]
        //public IActionResult Upload(IFormFile file)
        //{
        //    if (file != null && file.Length > 0)
        //    {
        //        byte[] imageData;
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            file.CopyTo(memoryStream);
        //            imageData = memoryStream.ToArray();
        //        }

        //        var img = new Img { Data = imageData };
        //        imageRepository.AddImage(img);

        //        return Ok(new { message = "Upload successful" });
        //    }

        //    return BadRequest(new { message = "No file or file is empty" });
        //}

        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    IEnumerable<Img> images = imageRepository.GetAllImages();
        //    return Ok(images);
        //}
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
