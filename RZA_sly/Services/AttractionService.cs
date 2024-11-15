using Microsoft.EntityFrameworkCore;
using RZA_sly.Models;

namespace RZA_sly.Services
{
    public class AttractionService
    {
        private readonly TlSlyRzaContext _context;
        public AttractionService(TlSlyRzaContext context)
        {
            _context = context;
        }
        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}
