using System.ComponentModel.DataAnnotations;

namespace busbooking.Models
{
    public class Img
    {
        [Key]
        public int Id { get; set; }

        public byte[]? Data { get; set; }

    }
}
