using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Vecto_.Services.Interfaces;

namespace Vecto_
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageProcessingController : ControllerBase
    {
        private readonly IImageProcessingService _imageProcessingService;

        public ImageProcessingController(IImageProcessingService imageProcessingService)
        {
            _imageProcessingService = imageProcessingService;
        }

        [HttpPost("AddImages")]
        public IActionResult AddImage(List<Image> images)
        {
            _imageProcessingService.AddImage(images);
            return Ok();
        }

        [HttpPost("ApplyEffects")]
        public IActionResult ApplyEffects(List<ImageChange> parameters)
        {
            try
            {
                _imageProcessingService.ApplyEffects(parameters);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
