using System;
using System.Collections.Generic;

namespace MarsRoverPhotoSearchAPI.Models
{
    public class Rover
    {
        public string Name { get; set; }
        public DateTime? MaxDate { get; set; }
        public ICollection<Camera> AvailableCameras { get; set; }
    }
}

