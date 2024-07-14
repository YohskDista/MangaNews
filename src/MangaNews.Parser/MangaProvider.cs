using HtmlAgilityPack;
using MangaNews.Core;
using MangaNews.Core.Services;
using MangaNews.Parser.Extensions;

namespace MangaNews.Parser;

public sealed class MangaProvider : IMangaProvider
{
    private const string UrlPageTemp = "https://ww8.mangakakalot.tv/";

    private readonly HtmlWeb _htmlWeb;

    public MangaProvider(HtmlWeb htmlWeb)
    {
        _htmlWeb = htmlWeb ?? throw new ArgumentNullException(nameof(htmlWeb));
    }

    public async Task<IReadOnlyList<MangaRelease>> GetLatestMangaAsync(
        CancellationToken cancellationToken = default)
    {
        var document = await _htmlWeb.LoadFromWebAsync(UrlPageTemp);

        return document.DocumentNode
            .Descendants("div")
            .FindClass("itemupdate first")
            .Select(convertToManga)
            .ToList();

        MangaRelease convertToManga(HtmlNode node)
        {
            var linkDescendants = node.Descendants("a");

            var imageUri = node.Descendants("img")
                .FindClass("img-loading")
                .Select(n => n.Attributes["data-src"].Value).First();

            var relativeUri = linkDescendants.Where(n => n.Attributes["rel"].Value == "nofollow")
                .Select(n => n.Attributes["href"].Value)
                .First();

            var title = linkDescendants.FindClass("tooltip")
                .Select(n => n.InnerHtml)
                .First();

            var chapters = node.Descendants("li").Skip(1).Select(convertToChapter).ToList();

            return new MangaRelease(title, relativeUri, imageUri, chapters);
        }

        Chapter convertToChapter(HtmlNode node)
        {
            var chapterNode = node.Descendants("a").FindClass("sts sts_1").First();
            var releaseTime = node.GetFirstDescandant("i").InnerHtml.TrimEnd(' ', '\n');

            return new Chapter(chapterNode.InnerHtml, releaseTime, chapterNode.Attributes["href"].Value);
        }
    }

    public async Task<MangaDetail> GetMangaAsync(
        string id, 
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);

        var document = await _htmlWeb.LoadFromWebAsync($"{UrlPageTemp}/manga/{id}");

        var imageSrc = document.DocumentNode
                               .Descendants("div")
                               .FindClass("manga-info-pic")
                               .First()
                               .Descendants("img")
                               .First()
                               .Attributes["src"]
                               .Value;

        var infoNode = document.DocumentNode
                               .Descendants("ul")
                               .FindClass("manga-info-text")
                               .First();

        var title = infoNode.GetFirstDescandant("h1").InnerHtml;

        var list = infoNode.SelectNodes("li");

        var author = list[1].GetFirstDescandant("a").InnerHtml;

        var updateTime = list[3].InnerHtml.Replace("Last updated : ", string.Empty);

        var t = document.DocumentNode
                .Descendants("div")
                .Where(n => n.Attributes.Contains("id") && n.Attributes["id"].Value == "noidungm")
                .First();

        t.RemoveChild(t.Descendants("h2").First());
        var description = t.InnerText;

        return new MangaDetail(title, description, DateTime.Now, imageSrc);

        throw new NotImplementedException();
    }
}
