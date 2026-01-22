using Metro_Line_Management.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Metro_Line_Management.Data.Repositories
{
    
    public class Lines_Repository
    {
        private readonly Metro_DbContext _context;
        public Lines_Repository(Metro_DbContext context)
        {
            _context = context;
        }
        // Get all metro lines
        public async Task<List<Metro_Lines>> GetLines()
        {
            return await _context.Metro_Lines.ToListAsync();
        }
        // Get a metro line by its ID, including its stations
        public async Task<Metro_Lines?> GetLineWithStationsById(int id)
        {
               return await _context.Metro_Lines
                .Where(line => line.Id == id)
                .Include(line => line.Stations)
                .FirstOrDefaultAsync(); 

        }
        // Add a new metro line
        public async Task AddLine(Metro_Lines line)
        {
            _context.Metro_Lines.Add(line);
            await  _context.SaveChangesAsync();
        }
      
    }
}
