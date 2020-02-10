using System;
using System.Collections.Generic;
using System.Linq;
using MarsRoverPhotoSearchAPI.Services.Abstract;
using MarsRoverPhotoSearchAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MarsRoverPhotoSearchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PageController : ControllerBase
    {
        private readonly ILogger<PhotosController> _logger;
        private readonly IRoverSetupService _roverSetupService;

        public PageController(ILogger<PhotosController> logger, IRoverSetupService roverSetupService)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger;
            _roverSetupService = roverSetupService;
        }

        [HttpGet]
        [Route("Properties")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PageViewProps> Get()
        {
            var props = _roverSetupService.GetSupportedRovers().Select(rover => {
                return new KeyValuePair<string, ICollection<string>>(rover.Name, rover.AvailableCameras.Select(c => c.Name).ToList());
            });
             return Ok(new PageViewProps { Menus = new Dictionary<string, ICollection<string>>(props) });            
        }
    }
}
