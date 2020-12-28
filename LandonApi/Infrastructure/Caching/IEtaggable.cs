namespace LandonApi.Infrastructure.Caching
{
    public interface IEtaggable
    {
        string GetEtag();
    }
}
