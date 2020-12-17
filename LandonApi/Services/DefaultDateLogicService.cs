using System;
using System.Collections.Generic;
using LandonApi.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Options;

namespace LandonApi.Services
{
    public class DefaultDateLogicService : IDateLogicService
    {
        private readonly HotelOptions _hotelOptions;

        public DefaultDateLogicService(IOptions<HotelOptions> optionAccessor)
        {
            _hotelOptions = optionAccessor.Value;
        }
        public DateTimeOffset AlignStartTime(DateTimeOffset original)
        {
            var dateInServerOffset = original.ToOffset(TimeSpan.FromHours(_hotelOptions.UtcOffsetHours));
            return new DateTimeOffset(
                dateInServerOffset.Year,
                dateInServerOffset.Month,
                dateInServerOffset.Day,
                12, 00, 00,
                dateInServerOffset.Offset);
        }

        public TimeSpan GetMinimumStay() => TimeSpan.FromHours(_hotelOptions.MinimumStayHours);

        public DateTimeOffset FurthestPossibleBooking(DateTimeOffset now)
            => AlignStartTime(now) + TimeSpan.FromDays(_hotelOptions.MaxAdvanceBookingDays);

        public IEnumerable<BookingRange> GetAllSlots(DateTimeOffset start, DateTimeOffset? end = null)
        {
            var newStart = AlignStartTime(start);
            
            while (true)
            {
                if (newStart > end) yield break;

                var newEnd = newStart.Add(TimeSpan.FromHours(_hotelOptions.MinimumStayHours));
                yield return new BookingRange
                {
                    StartAt = newStart,
                    EndAt = newEnd
                };

                newStart = newEnd;
            }
        }

        public bool DoesConflict(BookingRange b, DateTimeOffset start, DateTimeOffset end)
        {
            return
                (b.StartAt == start || b.EndAt == end)
                || (b.StartAt < start && b.EndAt > start)
                || (b.StartAt > start && b.EndAt < end);
        }
    }
}