using HtmlAgilityPack;
using MangaNew.Core;
using MangaNew.Core.Services;
using MangaNews.Parser.Extensions;

namespace MangaNews.Parser
{
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
                var releaseTime = node.Descendants("i").First().InnerHtml.TrimEnd(' ', '\n');

                return new Chapter(chapterNode.InnerHtml, releaseTime, chapterNode.Attributes["href"].Value);
            }
        }
    }
}
