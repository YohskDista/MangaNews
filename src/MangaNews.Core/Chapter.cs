namespace MangaNews.Core;

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
