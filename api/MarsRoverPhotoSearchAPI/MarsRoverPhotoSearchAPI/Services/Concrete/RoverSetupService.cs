using System;
using System.Collections.Generic;
using MarsRoverPhotoSearchAPI.Models;
using MarsRoverPhotoSearchAPI.Services.Abstract;

namespace MarsRoverPhotoSearchAPI.Services.Concrete
{
    public class RoverSetupService : IRoverSetupService
    {
       
        public ICollection<Rover> GetSupportedRovers()
        {
            return new List<Rover> {
                new Rover { Name = SupportedRovers.CURIOSITY, AvailableCameras = GetRoverCameras(SupportedRovers.CURIOSITY) },
                new Rover { Name = SupportedRovers.OPPORTUNITY, AvailableCameras = GetRoverCameras(SupportedRovers.OPPORTUNITY) },
                new Rover { Name = SupportedRovers.SPIRIT, AvailableCameras = GetRoverCameras(SupportedRovers.SPIRIT) }
            };
           
        }

        private ICollection<Camera> GetRoverCameras(string roverName)
        {
            switch (roverName.ToLower().Trim())
            {
                case SupportedRovers.CURIOSITY:
                    return new List<Camera> {
                        new Camera { Name = "FHAZ", FullName = "Front Hazard Avoidance Camera" },
                        new Camera { Name = "RHAZ", FullName = "Rear Hazard Avoidance Camera" },
                        new Camera { Name = "MAST", FullName = "Mast Camera" },
                        new Camera { Name = "CHEMCAM", FullName = "Chemistry and Camera Complex"},
                        new Camera { Name = "MAHLI", FullName = "Mars Hand Lens Imager"},
                        new Camera { Name = "MARDI", FullName = "Mars Descent Imager"},
                        new Camera { Name = "NAVCAM", FullName = "Navigation Camera"},
                    };


                case SupportedRovers.OPPORTUNITY:
                    return new List<Camera> {
                        new Camera { Name = "FHAZ", FullName = "Front Hazard Avoidance Camera" },
                        new Camera { Name = "RHAZ", FullName = "Rear Hazard Avoidance Camera" },
                        new Camera { Name = "NAVCAM", FullName = "Navigation Camera" },
                        new Camera { Name = "PANCAM", FullName = "Panoramic Camera" },
                        new Camera { Name = "MINITES", FullName = "Miniature Thermal Emission Spectrometer (Mini-TES)" }
                    };

                default:
                    return new List<Camera> {
                         new Camera { Name = "FHAZ", FullName = "Front Hazard Avoidance Camera" },
                        new Camera { Name = "RHAZ", FullName = "Rear Hazard Avoidance Camera" },
                        new Camera { Name = "NAVCAM", FullName = "Navigation Camera" },
                        new Camera { Name = "PANCAM", FullName = "Panoramic Camera" },
                        new Camera { Name = "MINITES", FullName = "Miniature Thermal Emission Spectrometer (Mini-TES)" }
                    };

            }
        }
    }
}
