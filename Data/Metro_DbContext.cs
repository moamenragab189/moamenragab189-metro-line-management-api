using Metro_Line_Management.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Metro_Line_Management.Data
{
    public class Metro_DbContext:DbContext
    {
        public Metro_DbContext(DbContextOptions<Metro_DbContext> options) : base(options)
        {
        }
        public DbSet<Metro_Lines>? Metro_Lines { get; set; }
        public DbSet<Metro_Stations>? Metro_Stations { get; set; }
    }
}
