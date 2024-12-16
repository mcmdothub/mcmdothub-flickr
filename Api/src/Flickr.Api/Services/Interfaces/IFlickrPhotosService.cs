using Flickr.Api.ApiResponse;

namespace Flickr.Api.Services.Interfaces
{
    public interface IFlickrPhotosService
    {
        Task<FlickrPhotoResponse?> SearchPhotosAsync(
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
            int page = 1
        );
    }
}