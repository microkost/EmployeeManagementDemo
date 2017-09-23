using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloDemoDomain
{
    public class SoloEmployer
    {
        [Key]
        public int ID { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Email { get; set; }

        [ForeignKey("Department")]
        public int IDdmp { get; set; }
        public virtual SoloDepartment Department { get; set; }

    }
}
