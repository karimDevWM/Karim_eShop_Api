using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public ImageService(IConfiguration config, ILogger<ImageService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            var cloudinaryConfig = new CloudinaryConfig();
            config.GetSection("Cloudinary").Bind(cloudinaryConfig);

            //var cloudName = Environment.GetEnvironmentVariable("CLOUDINARY_CLOUD_NAME");
            //var apiKey = Environment.GetEnvironmentVariable("CLOUDINARY_API_KEY");
            //var apiSecret = Environment.GetEnvironmentVariable("CLOUDINARY_API_SECRET");

            if (string.IsNullOrEmpty(cloudinaryConfig.CloudName) || string.IsNullOrEmpty(cloudinaryConfig.ApiKey) || string.IsNullOrEmpty(cloudinaryConfig.ApiSecret))
            {
                throw new ArgumentException("Cloudinary account details are missing.");
            }

            _logger.LogInformation("cloudinary infos ", cloudinaryConfig.CloudName, cloudinaryConfig.ApiKey);

            var account = new Account(cloudinaryConfig.CloudName, cloudinaryConfig.ApiKey, cloudinaryConfig.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
        {
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

        private class CloudinaryConfig
        {
            public string CloudName { get; set; }
            public string ApiKey { get; set; }
            public string ApiSecret { get; set; }
        }
    }
}
