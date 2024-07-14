namespace MangaNews.Core;

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
