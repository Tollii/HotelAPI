using System;
using LandonApi.Models.Booking;

namespace LandonApi.Models.Opening
{
    public class OpeningEntity : BookingRange
    {
        public Guid RoomId { get; set; }

        public int Rate { get; set; }
    }
}
