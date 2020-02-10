using System;
using System.Collections.Generic;
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

        public PhotosController(ILogger<PhotosController> logger, IConfiguration config, IDownloadService downloadService)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            _logger = logger;
            _downloadService = downloadService;
        }


        /*
         * This endpoint just returns a status (Pending) and schedules work on the service side to start downloading
         * the files asynchronously and add them the file name  to a queue object.
        */
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> Get(string date, string camera, string rover = SupportedRovers.SPIRIT)
        {
            //read the dates file
            string[] parseDates;
            string[] dates = System.IO.File.ReadAllLines("dates.txt");
            var parsed = dates.TryParseAsNasaDates(out parseDates);
            if(parsed)
            {
                await _downloadService.ScheduleWork(parseDates);
                return Ok("Pending");
            }
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }


        /*
         * This endpoint continually picks up files (if not empty) and removes the filename from the queue, generate the bytes and 
         * will send them to the client. The front will continually poll and have a timer for this. 
        */
        [HttpGet]
        [Route("Gallery")]
        [ProducesResponseType(StatusCodes.Status200OK)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<List<FileContentResult>> Gallery()
        {
            var contentResultList = new List<FileContentResult>();
            var imgBytes = await _downloadService.GetFilesStream();
            if(imgBytes != null)
            {
                var result = File(imgBytes, "image/png");
                contentResultList.Add(result);
                return contentResultList;
            }
            return null;
        }
    }
}
