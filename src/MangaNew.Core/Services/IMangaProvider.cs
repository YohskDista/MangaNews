namespace MangaNew.Core.Services
{
    public interface IMangaProvider
    {
        Task<IReadOnlyList<MangaRelease>> GetLatestMangaAsync(CancellationToken cancellationToken = default);
    }
}
