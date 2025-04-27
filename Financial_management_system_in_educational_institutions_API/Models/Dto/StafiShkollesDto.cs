using System;
using System.ComponentModel.DataAnnotations;

namespace Financial_management_system_in_educational_institutions_API.Models.Dto
{
    public class StafiShkollesDto
    {
        public int Id { get; set; }

        [Required]
        public int numriPersonal { get; set; }

        [Required, StringLength(100)]
        public string pozita { get; set; }

        [Required]
        public decimal paga { get; set; }

        [Required]
        public int numriOreve { get; set; }

        [Required]
        public int shkollaId { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime? updatedAt { get; set; }
    }
}
