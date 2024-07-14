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

public sealed record MangaDetail
{
    public MangaDetail(
        string title, 
        string author, 
        string description, 
        DateTime lastUpdate, 
        string imageLink)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(author);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        ArgumentException.ThrowIfNullOrWhiteSpace(imageLink);

        Title = title;
        Author = author;
        Description = description;
        LastUpdate = lastUpdate;
        ImageLink = imageLink;
    }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Description { get; set; }

    public DateTime LastUpdate { get; set; }

    public string ImageLink { get; set; }


}
