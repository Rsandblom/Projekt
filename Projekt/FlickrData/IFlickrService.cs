using FlickrNet;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.FlickrData
{
    public interface IFlickrService
    {
        PhotoCollection GetPhotosByTagList(List<SearchTag> tagList);
    }
}
