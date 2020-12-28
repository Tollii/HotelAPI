using LandonApi.Infrastructure.SearchHelpers;
using LandonApi.Infrastructure.Sorting;

namespace LandonApi.Models.Room
{
    public class Room : Resource
    {
        [Sortable]
        [SearchableString]
        public string Name { get; set; }

        [Sortable(Default = true)]
        [SearchableDecimal]
        public decimal Rate { get; set; }

        public Form Book { get; set; }
    }
}
