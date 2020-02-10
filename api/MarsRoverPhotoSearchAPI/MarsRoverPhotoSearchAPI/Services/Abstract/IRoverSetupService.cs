using System;
using System.Collections.Generic;
using MarsRoverPhotoSearchAPI.Models;

namespace MarsRoverPhotoSearchAPI.Services.Abstract
{
    /*
       Interface to setup each available rover
    */
    public interface IRoverSetupService
    {
        ICollection<Rover> GetSupportedRovers();
    }
}
