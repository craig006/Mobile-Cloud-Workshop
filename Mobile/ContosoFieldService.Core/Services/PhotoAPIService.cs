﻿using System.Threading.Tasks;
using ContosoFieldService.Models;
using Plugin.Media.Abstractions;
using Refit;

namespace ContosoFieldService.Services
{
    [Headers(Helpers.Constants.ApiManagementKey)]
    public interface IPhotoServiceAPI
    {
        [Multipart]
        [Post("/photo/{jobId}/")]
        Task<Photo> UploadPhoto(string jobId, [AliasAs("file")] StreamPart stream);
    }

    public class PhotoAPIService
    {
        public async Task<Photo> UploadPhotoAsync(string jobId, MediaFile file)
        {
            var restService = RestService.For<IPhotoServiceAPI>(Helpers.Constants.BaseUrl);

            var streamPart = new StreamPart(file.GetStream(), "photo.jpg", "image/jpeg");
            var photo = await restService.UploadPhoto(jobId, streamPart);

            return photo;
        }
    }
}
