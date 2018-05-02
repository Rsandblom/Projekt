using FlickrNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.FlickrData
{
    public class FlickrService : IFlickrService
    {
        private Flickr flickr;
        private readonly IOptions<FlickrSettings> _flickrSettings;

        public FlickrService(IOptions<FlickrSettings> flickrSettings)
        {
            _flickrSettings = flickrSettings;
            string key = _flickrSettings.Value.FlickrKey;            
            flickr = new Flickr(key);
            
        }

        public PhotoCollection GetPhotosByTagList(List<SearchTag> tagList)
        {
            string tagString = "";

            for(int i = 0;  i < tagList.Count(); i++)
            {
                tagString += string.Format("{0}, ", tagList[i].Tag);
            }

            var options = new PhotoSearchOptions();
            options.PerPage = 28;
            options.Page = 1;
            options.Tags = tagString;
            PhotoCollection photos = flickr.PhotosSearch(options);

            return photos;
        }
    }
}
