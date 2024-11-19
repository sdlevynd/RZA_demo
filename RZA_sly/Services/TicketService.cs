using Microsoft.EntityFrameworkCore;
using RZA_sly.Models;

namespace RZA_sly.Services
{
    public class TicketService
    {
        private readonly TlSlyRzaContext _context;
        public TicketService(TlSlyRzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task AddTicketAsync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }
    }
}
