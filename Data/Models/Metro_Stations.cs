using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Metro_Line_Management.Data.Models
{
    public class Metro_Stations
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? StationName { get; set; }
        [Required]
        public int LineId { get; set; }
        [JsonIgnore]
        public Metro_Lines? Line { get; set; }
    }
}
