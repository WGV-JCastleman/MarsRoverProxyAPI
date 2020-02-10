using System;
using System.Collections.Generic;
using MarsRoverPhotoSearchAPI.Models;

namespace MarsRoverPhotoSearchAPI.ViewModels
{
    public class PageViewProps
    {
        public IDictionary<string, ICollection<string>>  Menus { get; set; } 
    }
}
