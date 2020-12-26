using System;
using System.Linq;
using System.Threading.Tasks;

using LandonApi.Models;

using Microsoft.Extensions.DependencyInjection;

namespace LandonApi
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(
                services.GetRequiredService<HotelApiDbContext>());
        }

        public static async Task AddTestData(HotelApiDbContext context)
        {
            // If a real database with data in it, is connected, return, else add in-memory test data
            if (context.Rooms.Any())
                return;

            await context.Rooms.AddAsync(new RoomEntity
            {
                Id = Guid.Parse("301df04d-8679-4b1b-ab92-0a586ae53d08"),
                Name = "Oxford Suite",
                Rate = 10119
            });

            await context.Rooms.AddAsync(new RoomEntity
            {
                Id = Guid.Parse("ee2b83be-91db-4de5-8122-35a9e9195976"),
                Name = "Driscoll Suite",
                Rate = 23959
            });

            await context.Rooms.AddAsync(new RoomEntity
            {
                Id = Guid.Parse("b9187284-18c6-4c96-8360-5277fb0ab400"),
                Name = "Janna Suite",
                Rate = 1210
            });
            await context.Rooms.AddAsync(new RoomEntity
            {
                Id = Guid.Parse("446e095d-165a-4ff4-a05b-007b2168d94b"),
                Name = "Awesome Suite",
                Rate = 1201
            });
            await context.Rooms.AddAsync(new RoomEntity
            {
                Id = Guid.Parse("f3209878-fae4-4bbf-964f-e5f06c014590"),
                Name = "random Suite",
                Rate = 123
            });
            await context.SaveChangesAsync();
        }
    }
}
