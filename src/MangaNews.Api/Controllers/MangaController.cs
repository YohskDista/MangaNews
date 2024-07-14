using MangaNews.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace MangaNews.Api.Controllers;

public class MangaController(IMangaProvider mangaProvider) : Controller
{
    private readonly IMangaProvider _mangaProvider = mangaProvider 
        ?? throw new ArgumentNullException(nameof(mangaProvider));

    [HttpGet]
    public void GetLatestMangas()
    {
        // TODO
    }

    [HttpGet("/{mangaId}")]
    public void GetManga(string mangaId)
    {
        // TODO
    }
}
