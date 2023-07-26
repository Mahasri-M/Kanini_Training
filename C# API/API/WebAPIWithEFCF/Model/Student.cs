using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIWithEFCF.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public int StudId { get; set; }
            public string Name { get; set; } = string.Empty;
            public string city { get; set; } = string.Empty;
            public int pin { get; set; }
        }
    }

