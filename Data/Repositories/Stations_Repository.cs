using Metro_Line_Management.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Metro_Line_Management.Data.Repositories
{
    public class Stations_Repository
    {
        private readonly Metro_DbContext _context;  
        public Stations_Repository(Metro_DbContext context)
        {
            _context = context;
        }
        // Add a new metro station
        public async Task AddStation(Metro_Stations station)
        {
            _context.Metro_Stations.Add(station);
            await _context.SaveChangesAsync();
        }
       public async Task<List<Metro_Stations>> GetStationsByLineId(int id)
       {
            return await _context.Metro_Stations.Where(s=>s.LineId==id).ToListAsync();
       }
        // Get a metro station by its ID
       public async Task<Metro_Stations?> GetStationById(int id)
       {
            return await _context.Metro_Stations.FirstOrDefaultAsync(s=>s.Id==id);
       }
        //
        public async Task<int> GetNumOfStations()
        {
           return await _context.Metro_Stations.CountAsync();
        }

    }
}
