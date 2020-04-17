using System;
using System.ComponentModel.DataAnnotations;
namespace Pirate.Models
{
    public class PirateMember
    {
        [Key]
        public int PirateId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string PirateRole { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}