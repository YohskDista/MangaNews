using HtmlAgilityPack;

namespace MangaNews.Parser.Extensions;

internal static class HtmlNodeExtensions
{
    public static IEnumerable<HtmlNode> FindClass(this IEnumerable<HtmlNode> nodes, string classValue)
    {
        return nodes.Where(d => d.Attributes.FirstOrDefault(a => a.Name == "class")?.Value == classValue);
    }
    public static IEnumerable<HtmlNode> FindId(this IEnumerable<HtmlNode> nodes, string idValue)
    {
        return nodes.Where(d => d.Attributes.FirstOrDefault(a => a.Name == "id")?.Value == idValue);
    }

    public static HtmlNode GetFirstDescandant(this HtmlNode node, string name)
    {
        return node.Descendants(name).First();
    }
}
