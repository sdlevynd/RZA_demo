using RZA_sly.Models;
using Microsoft.EntityFrameworkCore;

namespace RZA_sly.Services
{
    public class RoomService
    {
        private readonly TlSlyRzaContext _context;
        public RoomService(TlSlyRzaContext context)
        {
            _context = context;
        }
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        public async Task<Room> GetRoomAsync(int roomNumber)
        {
            return await _context.Rooms.FirstAsync(r => r.RoomNumber == roomNumber);
        }
    }
}
