using Flickr.Api.Services.Interfaces;
using System.Text.Json;

namespace Flickr.Api.Services
{
    public class FlickrPhotosService : IFlickrPhotosService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public FlickrPhotosService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _apiKey = configuration["Flickr:ApiKey"] ?? throw new ArgumentNullException("Flickr:ApiKey is not configured.");
        }

        /// <summary>
        /// Return a list of photos matching some criteria. Only photos visible to the calling user will be returned. 
        /// To return private or semi-private photos, the caller must be authenticated with 'read' permissions, 
        /// and have permission to view the photos. 
        /// Unauthenticated calls will only return public photos
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tags"></param>
        /// <param name="tagMode"></param>
        /// <param name="text"></param>
        /// <param name="minUploadDate"></param>
        /// <param name="maxUploadDate"></param>
        /// <param name="minTakenDate"></param>
        /// <param name="maxTakenDate"></param>
        /// <param name="license"></param>
        /// <param name="sort"></param>
        /// <param name="privacyFilter"></param>
        /// <param name="bbox"></param>
        /// <param name="accuracy"></param>
        /// <param name="safeSearch"></param>
        /// <param name="contentTypes"></param>
        /// <param name="extras"></param>
        /// <param name="perPage"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task<dynamic?> SearchPhotosAsync(
            string? userId = null,
            string? tags = null,
            string? tagMode = null,
            string? text = null,
            string? minUploadDate = null,
            string? maxUploadDate = null,
            string? minTakenDate = null,
            string? maxTakenDate = null,
            string? license = null,
            string? sort = null,
            int? privacyFilter = null,
            string? bbox = null,
            int? accuracy = null,
            int? safeSearch = null,
            string? contentTypes = null,
            string? extras = null,
            int perPage = 100,
            int page = 1)
        {
            var url = "https://www.flickr.com/services/rest/";
            var parameters = new Dictionary<string, string>
            {
                { "method", "flickr.photos.search" },
                { "api_key", _apiKey },
                { "format", "json" },
                { "nojsoncallback", "1" },
                { "per_page", perPage.ToString() },
                { "page", page.ToString() }
            };

            if (!string.IsNullOrEmpty(userId)) parameters.Add("user_id", userId);
            if (!string.IsNullOrEmpty(tags)) parameters.Add("tags", tags);
            if (!string.IsNullOrEmpty(tagMode)) parameters.Add("tag_mode", tagMode);
            if (!string.IsNullOrEmpty(text)) parameters.Add("text", text);
            if (!string.IsNullOrEmpty(minUploadDate)) parameters.Add("min_upload_date", minUploadDate);
            if (!string.IsNullOrEmpty(maxUploadDate)) parameters.Add("max_upload_date", maxUploadDate);
            if (!string.IsNullOrEmpty(minTakenDate)) parameters.Add("min_taken_date", minTakenDate);
            if (!string.IsNullOrEmpty(maxTakenDate)) parameters.Add("max_taken_date", maxTakenDate);
            if (!string.IsNullOrEmpty(license)) parameters.Add("license", license);
            if (!string.IsNullOrEmpty(sort)) parameters.Add("sort", sort);
            if (privacyFilter.HasValue) parameters.Add("privacy_filter", privacyFilter.Value.ToString());
            if (!string.IsNullOrEmpty(bbox)) parameters.Add("bbox", bbox);
            if (accuracy.HasValue) parameters.Add("accuracy", accuracy.Value.ToString());
            if (safeSearch.HasValue) parameters.Add("safe_search", safeSearch.Value.ToString());
            if (!string.IsNullOrEmpty(contentTypes)) parameters.Add("content_types", contentTypes);
            if (!string.IsNullOrEmpty(extras)) parameters.Add("extras", extras);

            var requestUrl = $"{url}?{string.Join("&", parameters.Select(p => $"{p.Key}={Uri.EscapeDataString(p.Value)}"))}";
            var response = await _httpClient.GetStringAsync(requestUrl);

            return JsonSerializer.Deserialize<dynamic?>(response);
        }
    }
}