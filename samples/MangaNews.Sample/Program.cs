using HtmlAgilityPack;
using MangaNews.Parser;

var provider = new MangaProvider(new HtmlWeb());

var latestReleases = await provider.GetLatestMangaAsync();

Console.WriteLine($"Got the latest releases: {latestReleases}");

