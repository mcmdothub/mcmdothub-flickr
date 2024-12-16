using System.Text.Json.Serialization;

namespace Flickr.Api.ApiResponse
{
    /// <summary>
    /// Represents the Flickr API response for photo search results.
    /// </summary>
    public class FlickrPhotoResponse
    {
        [JsonPropertyName("photos")]
        public PhotoCollection? Photos { get; set; }

        public class PhotoCollection
        {
            [JsonPropertyName("page")]
            public int Page { get; set; }

            [JsonPropertyName("pages")]
            public int Pages { get; set; }

            [JsonPropertyName("perpage")]
            public int PerPage { get; set; }

            [JsonPropertyName("total")]
            public int Total { get; set; }

            [JsonPropertyName("photo")]
            public List<Photo>? Photo { get; set; }
        }

        public class Photo
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } = string.Empty;

            [JsonPropertyName("owner")]
            public string Owner { get; set; } = string.Empty;

            [JsonPropertyName("secret")]
            public string Secret { get; set; } = string.Empty;

            [JsonPropertyName("server")]
            public string Server { get; set; } = string.Empty;

            [JsonPropertyName("farm")]
            public int Farm { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; } = string.Empty;

            [JsonPropertyName("ispublic")]
            public int IsPublic { get; set; }

            [JsonPropertyName("isfriend")]
            public int IsFriend { get; set; }

            [JsonPropertyName("isfamily")]
            public int IsFamily { get; set; }

            // Optional: Extra fields based on "extras" argument
            [JsonPropertyName("date_upload")]
            public string? DateUpload { get; set; }

            [JsonPropertyName("date_taken")]
            public string? DateTaken { get; set; }

            [JsonPropertyName("tags")]
            public string? Tags { get; set; }

            [JsonPropertyName("views")]
            public string? Views { get; set; }

            [JsonPropertyName("url_s")]
            public string? UrlSmall { get; set; }

            [JsonPropertyName("url_m")]
            public string? UrlMedium { get; set; }

            [JsonPropertyName("url_l")]
            public string? UrlLarge { get; set; }

            [JsonPropertyName("url_o")]
            public string? UrlOriginal { get; set; }
        }
    }
}