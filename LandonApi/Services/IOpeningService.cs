using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LandonApi.Models;

namespace LandonApi.Services
{
    public interface IOpeningService
    {
        Task<IEnumerable<Opening>> GetOpeningAsync();
        Task<IEnumerable<BookingRange>> GetConflictingSlots(Guid roomId, DateTimeOffset start, DateTimeOffset end);
    }
}