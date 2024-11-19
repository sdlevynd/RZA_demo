using Microsoft.EntityFrameworkCore;
using RZA_sly.Models;

namespace RZA_sly.Services
{
    public class TicketbookingService
    {
        private readonly TlSlyRzaContext _context;
        public TicketbookingService(TlSlyRzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticketbooking>> GetTicketbookingsAsync()
        {
            return await _context.Ticketbookings.ToListAsync();
        }
        public async Task AddTicketbookingAsync(Ticketbooking newTicketbooking)
        {
            await _context.Ticketbookings.AddAsync(newTicketbooking);
            await _context.SaveChangesAsync();
        }
    }
}
