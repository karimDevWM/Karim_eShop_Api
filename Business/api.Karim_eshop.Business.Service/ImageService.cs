using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace api.Karim_eshop.Business.Service
{
    public class ImageService
    {
        private readonly Cloudinary _cloudinary;
        private readonly ILogger<ImageService> _logger;
        //private readonly string _cloudName;
        //private readonly string _apiKey;
        //private readonly string _apiSecret;

        public ImageService(IOptions<CloudinarySettings> config, ILogger<ImageService> logger)
        {

            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);

            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));

            // Retrieve Cloudinary configuration from appsettings
            //_cloudName = config["Cloudinary:CloudName"];
            //_apiKey = config["Cloudinary:ApiKey"];
            //_apiSecret = config["Cloudinary:ApiSecret"];

            // Log Cloudinary account details (but never log sensitive data like ApiSecret)
            //_logger.LogInformation("Cloudinary Configuration: CloudName={CloudName}, ApiKey={ApiKey}",
            //    _cloudName, _apiKey);

            //if (string.IsNullOrEmpty(_cloudName) || string.IsNullOrEmpty(_apiKey) || string.IsNullOrEmpty(_apiSecret))
            //{
            //    throw new ArgumentException("Cloudinary account details are missing.");
            //}

            //_logger.LogInformation("Cloudinary Configuration: CloudName={CloudName}, ApiKey={ApiKey}",
            //_cloudName, _apiKey);

            //var account = new Account(_cloudName, _apiKey, _apiSecret);
            //_cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
        {
            //_logger.LogInformation("Uploading image using CloudName: {CloudName}", _cloudName);
            //_logger.LogInformation("Uploading image using ApiKey: {ApiKey}", _apiKey);
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }
    }
}
