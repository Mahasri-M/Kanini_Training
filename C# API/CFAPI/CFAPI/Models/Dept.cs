using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFAPI.Models
{
    public class Dept
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Deptno { get; set; }
        [Required]
        public string Ename { get; set; }=string.Empty;

        public virtual ICollection<Emp>? Emps { get; set; }
    }
}
