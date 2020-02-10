using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MarsRoverPhotoSearchAPI
{
    public class PhotoGallery
    {
        public List<Photo> Photos { get; set; }
    }

    public class Photo
    {
        public int Id { get; set; }
        public string img_src  { get; set; }  
    }
}
