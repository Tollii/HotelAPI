using LandonApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandonApi.Models.Paging;
using LandonApi.Models.Room;

namespace LandonApi.Services
{
    public interface IRoomService
    {
        Task<PagedResults<Room>> GetRoomsAsync(
            PagingOptions pagingOptions,
            SortOptions<Room, RoomEntity> sortOptions,
            SearchOptions<Room, RoomEntity> searchOptions);

        Task<Room> GetRoomAsync(Guid id);
    }
}
