using AutoMapper;
using LandonApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace LandonApi.Services
{
    public class DefaultRoomService : IRoomService
    {
        private readonly HotelApiDbContext _context;
        private readonly IConfigurationProvider _mappingConfiguration;

        public DefaultRoomService(HotelApiDbContext context, IConfigurationProvider mappingConfiguration)
        {
            _context = context;
            _mappingConfiguration = mappingConfiguration;
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            var query = _context.Rooms.ProjectTo<Room>(_mappingConfiguration);

            return await query.ToArrayAsync();
        }

        public async Task<Room> GetRoomAsync(Guid id)
        {
            var entity = await _context.Rooms.SingleOrDefaultAsync(x => x.Id == id);
            var mapper = _mappingConfiguration.CreateMapper();
            return entity == null ? null : _mappingConfiguration.CreateMapper().Map<Room>(entity);
        }
    }
}
