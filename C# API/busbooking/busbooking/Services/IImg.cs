using busbooking.Models;

namespace busbooking.Services
{
    public interface IImg
    {
        void AddImage(Img image);
        Img GetImage(int id);
        IEnumerable<Img> GetAllImages();
    }
}
