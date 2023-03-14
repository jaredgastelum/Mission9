using System;
using Microsoft.AspNetCore.Http;

namespace AmazonProject.Infastructure
{
    public static class UrlExtensions
    {
        // FOR URL EXTENSION
        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
