using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaAPI.Models
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public required string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(250)")]
        public required string Description { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public required int State { get; set; }

        [Required]
        public required DateTime CreationDate { get; set; }

        public DateTime? CompletedDate { get; set; }
    }

}
