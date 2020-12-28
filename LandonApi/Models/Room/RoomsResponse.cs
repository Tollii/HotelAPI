using LandonApi.Models.Paging;

namespace LandonApi.Models.Room
{
    public class RoomsResponse : PagedCollection<Room>
    {
        public Link Openings { get; set; }

        public Form RoomsQuery { get; set; }
    }
}
