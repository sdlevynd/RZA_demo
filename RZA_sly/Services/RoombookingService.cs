﻿using RZA_sly.Models;
using Microsoft.EntityFrameworkCore;
namespace RZA_sly.Services
{
    public class RoombookingService
    {
        private readonly TlSlyRzaContext _context;
        public RoombookingService(TlSlyRzaContext context)
        {
            _context = context;
        }
        public async Task AddRoombookingAsync(Customer customer, Room room)
        {
            Roombooking newRoombooking = new Roombooking();
            newRoombooking.Customer = customer;
            newRoombooking.RoomNumberNavigation = room;
            newRoombooking.StartDate = DateOnly.FromDateTime(DateTime.Now);
            var temps = await _context.Roombookings.ToListAsync();

            var temp = await _context.Roombookings.Where(r => r.CustomerId == customer.CustomerId &&
                                                         r.RoomNumber == room.RoomNumber &&
                                                         r.StartDate == newRoombooking.StartDate).FirstOrDefaultAsync();
            if (temp == null)
            {
                await _context.Roombookings.AddAsync(newRoombooking);
                await _context.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("could not book room");
            }
            newRoombooking = null;
        }
        public async Task<List<Roombooking>> GetRoombookingsFromCustomer(Customer customer)
        {
            return await _context.Roombookings.Where(rb => rb.CustomerId == customer.CustomerId).ToListAsync();
        }
    }
}
