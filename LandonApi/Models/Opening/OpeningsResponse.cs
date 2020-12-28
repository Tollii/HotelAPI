using LandonApi.Models.Paging;

namespace LandonApi.Models.Opening
{
    public class OpeningsResponse : PagedCollection<Opening>
    {
        public Form OpeningsQuery { get; set; }
    }
}
