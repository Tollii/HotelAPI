using Microsoft.EntityFrameworkCore;
using LandonApi.Models;
using LandonApi.Models.Booking;
using LandonApi.Models.Room;

namespace LandonApi
{
    public class HotelApiDbContext : DbContext
    {
        public HotelApiDbContext(DbContextOptions options) : base (options) { }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
    }
}
