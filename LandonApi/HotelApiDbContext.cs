using Microsoft.EntityFrameworkCore;
using LandonApi.Models;

namespace LandonApi
{
    public class HotelApiDbContext : DbContext
    {
        public HotelApiDbContext(DbContextOptions options) : base (options) { }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<BookingEntity> Bookings { get; set; }
    }
}
