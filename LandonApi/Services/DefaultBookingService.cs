using System;
using System.Threading.Tasks;
using LandonApi.Models;

namespace LandonApi.Services
{
    public class DefaultBookingService : IBookingService
    {
        public Task<Booking> GetBookingAsync(Guid bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateBookingAsync(Guid userId, Guid roomId, DateTimeOffset startAt, DateTimeOffset endAt)
        {
            throw new NotImplementedException();
        }
    }
}