using Metro_Line_Management.Data;
using Metro_Line_Management.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Metro_Line_Management.Data.Models
{
    public class Metro_Lines
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? LineName { get; set; }
        [Required]
        public string? Color { get; set; }
        public List<Metro_Stations>? Stations { get; set; }
    }
}
