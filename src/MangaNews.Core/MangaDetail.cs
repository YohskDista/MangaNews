namespace MangaNews.Core;

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
