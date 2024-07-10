using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaNews.Parser.Extensions
{
    internal static class HtmlNodeExtensions
    {
        public static IEnumerable<HtmlNode> FindClass(this IEnumerable<HtmlNode> nodes, string classValue)
        {
            return nodes.Where(d => d.Attributes.FirstOrDefault(a => a.Name == "class")?.Value == classValue);
        }
    }
}
