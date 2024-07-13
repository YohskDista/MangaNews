namespace MangaNews.Core.Services;

public interface IMangaProvider
{
    Task<IReadOnlyList<MangaRelease>> GetLatestMangaAsync(CancellationToken cancellationToken = default);
}
