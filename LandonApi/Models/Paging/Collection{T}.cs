namespace LandonApi.Models.Paging
{
    public class Collection<T> : Resource
    {
        public T[] Value { get; set; }
    }
}
