using System;
using System.Collections.Generic;
using Vecto_.Plugins.Interfaces;
using Vecto_.Services.Interfaces;

namespace Vecto_
{
    // ImageProcessingService.cs
    public class ImageProcessingService : IImageProcessingService
    {
        private readonly List<Image> _images;
        private readonly IServiceProvider serviceProvider;

        public ImageProcessingService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            _images = new List<Image>();
        }

        public void AddImage(List<Image> images)
        {
            _images.AddRange(images);
        }

        public void ApplyEffects(List<ImageChange> parameters)
        {
            foreach (ImageChange imageRequest in parameters)
            {
                if (!_images.Any(image => image.ImageName == imageRequest.ImageName))
                {
                    throw new ArgumentException($"Image '{imageRequest.ImageName}' not found.");
                }

                IPlugin plugin;

                if (imageRequest.Blur.Size.HasValue)
                {
                    plugin = serviceProvider.GetServices<IPlugin>().FirstOrDefault(p => p.Name == imageRequest.Blur.Name);
                    plugin?.ApplyEffect(imageRequest);
                }

                if (imageRequest.Resize.Size.HasValue)
                {
                    plugin = serviceProvider.GetServices<IPlugin>().FirstOrDefault(p => p.Name == imageRequest.Resize.Name);
                    plugin?.ApplyEffect(imageRequest);
                }

                if (imageRequest.Grayscale.IsNeeded)
                {
                    plugin = serviceProvider.GetServices<IPlugin>().FirstOrDefault(p => p.Name == imageRequest.Grayscale.Name);
                    plugin?.ApplyEffect(imageRequest);
                }
            }
        }

    }
}