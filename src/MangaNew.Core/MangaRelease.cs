using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaNew.Core
{
    public sealed record MangaRelease
    {
        public MangaRelease(string title, string relativeUri, string imageLink, IEnumerable<Chapter> chapters)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(relativeUri);
            ArgumentException.ThrowIfNullOrWhiteSpace(imageLink);

            Title = title;
            RelativeUri = relativeUri;
            ImageLink = imageLink;
            Chapters = chapters?.ToArray() ?? throw new ArgumentNullException(nameof(chapters));
        }

        public string Title { get; set; }

        public string RelativeUri { get; set; }

        public string ImageLink { get; set; }

        public IReadOnlyList<Chapter> Chapters { get; set; }
    }

    public sealed record Chapter
    {
        public Chapter(string title, string releaseTime, string link)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(title);
            ArgumentException.ThrowIfNullOrWhiteSpace(releaseTime);
            ArgumentException.ThrowIfNullOrWhiteSpace(link);

            Title = title;
            ReleaseTime = releaseTime;
            Link = link;
        }

        public string Title { get; set; }

        public string ReleaseTime { get; set; }

        public string Link { get; set; }
    }
}
