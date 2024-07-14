using HtmlAgilityPack;

namespace MangaNews.Parser.Extensions;

internal static class HtmlNodeExtensions
{
    public static IEnumerable<HtmlNode> FindClass(this IEnumerable<HtmlNode> nodes, string classValue)
    {
        ArgumentNullException.ThrowIfNull(nodes);
        ArgumentException.ThrowIfNullOrWhiteSpace(classValue);

        return nodes.Where(d => d.Attributes.FirstOrDefault(a => a.Name == "class")?.Value == classValue);
    }
    public static IEnumerable<HtmlNode> FindId(this IEnumerable<HtmlNode> nodes, string idValue)
    {
        ArgumentNullException.ThrowIfNull(nodes);
        ArgumentException.ThrowIfNullOrWhiteSpace(idValue);

        return nodes.Where(d => d.Attributes.FirstOrDefault(a => a.Name == "id")?.Value == idValue);
    }

    public static IEnumerable<HtmlNode> WithAttribute(this IEnumerable<HtmlNode> nodes, string attributeKey)
    {
        ArgumentNullException.ThrowIfNull(nodes);
        ArgumentException.ThrowIfNullOrWhiteSpace(attributeKey);

        return nodes.Where(n => n.Attributes.Contains(attributeKey));
    }

    public static HtmlNode GetFirstDescendant(this HtmlNode node, string name)
    {
        ArgumentNullException.ThrowIfNull(node);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        return node.Descendants(name).First();
    }
}
