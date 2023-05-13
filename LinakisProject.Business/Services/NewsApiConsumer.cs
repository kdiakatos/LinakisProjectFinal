using LinakisProject.Business.Interfaces;
using LinakisProject.Business.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LinakisProject.Business.Services
{
    public class NewsApiConsumer : INewsApiConsumer
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;

        public NewsApiConsumer(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _configuration = configuration;
            _apiKey = _configuration.GetSection("NewsApiKey").Value;
        }

        public async Task<List<NewsModel>> GetArticlesByTitle(string title)
        {
            var retrievedArticles = new List<NewsModel>();
            var httpClient = _httpClientFactory.CreateClient("NewApiClient");

            var url = $"everything?q={title.ToLower()}&apiKey={_apiKey}";
            using (var response = await httpClient.GetAsync(url))
            {
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<NewsApiModel>(stream, _options);

                if (result?.Articles != null)
                {
                    foreach (var item in result.Articles.Take(5))
                    {
                        var article = new NewsModel();
                        article.Url = item.Url;
                        article.Title = item.Title;
                        article.SourceName = item.Source?.Name;
                        article.PublishedDate = item.PublishedAt.ToString("dd/MM", CultureInfo.InvariantCulture);
                        retrievedArticles.Add(article);
                    }
                }

                return retrievedArticles;
            }
        }
    }
}
