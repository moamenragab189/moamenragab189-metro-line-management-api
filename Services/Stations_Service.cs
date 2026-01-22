using Metro_Line_Management.Data.Models;
using Metro_Line_Management.Data.Repositories;

namespace Metro_Line_Management.Services
{
    public class Stations_Service
    {
       private readonly Stations_Repository _stationsRepository;
       private readonly IConfiguration _configuration;
         public Stations_Service(Stations_Repository stationsRepository,IConfiguration configuration)
         {
              _stationsRepository = stationsRepository;
              _configuration = configuration;
         }
        // Adds a new metro station
        public async Task AddStationAsync(Metro_Stations station)
        {
            if (station == null)
            {
                throw new ArgumentNullException(nameof(AddStationAsync), "Station cannot be null.");
            }
            int StationNum= await _stationsRepository.GetNumOfStations();
            int MaxStationsPerLine = _configuration
        .GetValue<int>("MetroSettings:MaxStationsPerLine");
            if (StationNum>= MaxStationsPerLine)
            {
                throw new InvalidOperationException("This line has reached the maximum number of stations.");
            }
 
           
            await _stationsRepository.AddStation(station);
        }
        // Retrieves all metro stations
        public async Task<List<Metro_Stations>> GetStationsByLineIdAsync(int lineId)
        {
            if (lineId <= 0)
            {
                throw new ArgumentException("Invalid line ID.");
            }
            return await _stationsRepository.GetStationsByLineId(lineId);
        }
        // Retrieves a metro station by its ID
        public async Task<Metro_Stations?> GetStationByIdAsync(int stationId)
        {
            if (stationId <= 0)
            {
                throw new ArgumentException("Invalid station ID.");
            }
            return await _stationsRepository.GetStationById(stationId);
        }
    }
}
