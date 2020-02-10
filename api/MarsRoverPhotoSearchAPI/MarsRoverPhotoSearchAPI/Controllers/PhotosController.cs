using System;
using System.Linq;
using System.Threading.Tasks;
using MarsRoverPhotoSearchAPI.Helpers;
using MarsRoverPhotoSearchAPI.Models;
using MarsRoverPhotoSearchAPI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace MarsRoverPhotoSearchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        
        private readonly ILogger<PhotosController> _logger;
        private readonly IConfiguration _config;
        private readonly IDownloadService _downloadService;

        private ApiProxyClient _httpProxyClient;

        public PhotosController(ILogger<PhotosController> logger, IConfiguration config, IDownloadService downloadService)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            _logger = logger;
            _downloadService = downloadService;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Get(string date, string camera, string rover = SupportedRovers.SPIRIT)
        {
            //read the dates file
            string[] dates = System.IO.File.ReadAllLines("dates.txt");
            await _downloadService.ScheduleWork(dates);
            return "Pending";
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("PhotoGallery")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> PhotosGallery(string date, string camera, string rover = SupportedRovers.SPIRIT)
        {
            return null;
        }
    }
}
