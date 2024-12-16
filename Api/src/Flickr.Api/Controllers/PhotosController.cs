using Flickr.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Flickr.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PhotosController : ControllerBase
    {
        private readonly IFlickrPhotosService _flickrPhotosService;

        public PhotosController(IFlickrPhotosService flickrPhotosService)
        {
            _flickrPhotosService = flickrPhotosService;
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
        [HttpGet("search")]
        public async Task<IActionResult> SearchPhotos(
            [FromQuery] string? userId = null,
            [FromQuery] string? tags = null,
            [FromQuery] string? tagMode = null,
            [FromQuery] string? text = null,
            [FromQuery] string? minUploadDate = null,
            [FromQuery] string? maxUploadDate = null,
            [FromQuery] string? minTakenDate = null,
            [FromQuery] string? maxTakenDate = null,
            [FromQuery] string? license = null,
            [FromQuery] string? sort = null,
            [FromQuery] int? privacyFilter = null,
            [FromQuery] string? bbox = null,
            [FromQuery] int? accuracy = null,
            [FromQuery] int? safeSearch = null,
            [FromQuery] string? contentTypes = null,
            [FromQuery] string? extras = null,
            [FromQuery] int perPage = 100,
            [FromQuery] int page = 1)
        {
            try
            {
                var result = await _flickrPhotosService.SearchPhotosAsync(
                    userId,
                    tags,
                    tagMode,
                    text,
                    minUploadDate,
                    maxUploadDate,
                    minTakenDate,
                    maxTakenDate,
                    license,
                    sort,
                    privacyFilter,
                    bbox,
                    accuracy,
                    safeSearch,
                    contentTypes,
                    extras,
                    perPage,
                    page
                );

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}