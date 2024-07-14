using HtmlAgilityPack;
using MangaNews.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaNews.Parser.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMangaServices(this IServiceCollection serviceCollection)
    {
        ArgumentNullException.ThrowIfNull(serviceCollection);

        return serviceCollection.AddSingleton<IMangaProvider, MangaProvider>()
                                .AddSingleton(new HtmlWeb());
    }
}
