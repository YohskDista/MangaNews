using HtmlAgilityPack;
using MangaNews.Parser;

var provider = new MangaProvider(new HtmlWeb());

var latestReleases = await provider.GetMangaAsync("manga-aa951409");

Console.WriteLine($"Got the latest releases: {latestReleases}");

