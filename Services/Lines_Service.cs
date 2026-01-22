using Metro_Line_Management.Data.Repositories;
using Metro_Line_Management.Data.Models;
using System.Threading.Tasks;
namespace Metro_Line_Management.Services
{
    public class Lines_Service
    {
        private readonly Lines_Repository _linesRepository;
        public Lines_Service(Lines_Repository linesRepository)
        {
            _linesRepository = linesRepository;
        }
        public async Task<List<Metro_Lines>> GetAllLinesAsync()
        {
            var lines = await _linesRepository.GetLines();
            if (lines == null || !lines.Any())
            {
                throw new Exception("No lines found.");
            }
            return lines;
        }
        public async Task<Metro_Lines> GetLineWithStationByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid line ID.");
            }
            return await _linesRepository.GetLineWithStationsById(id);
        }
        public async Task AddLineAsync(Metro_Lines line)
        {
            if (line == null)
            {
                throw new ArgumentNullException(nameof(line), "Line cannot be null.");
            }
            await _linesRepository.AddLine(line);
        }

    }
}
