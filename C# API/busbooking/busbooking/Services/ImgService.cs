using busbooking.Models;
using Microsoft.EntityFrameworkCore;

namespace busbooking.Services
{
    public class ImgService:IImg
    {
        private readonly BusContext busContext;

        public ImgService(BusContext busContext)
        {
            this.busContext = busContext;
        }
        public void AddImage(Img image)
        {
            busContext.Imgs.Add(image);
            busContext.SaveChanges();
        }
        public Img GetImage(int id)
        {
            return busContext.Imgs.FirstOrDefault(image => image.Id == id);
        }

        public IEnumerable<Img> GetAllImages()
        {
            return busContext.Imgs.ToList();
        }
    }
}



  