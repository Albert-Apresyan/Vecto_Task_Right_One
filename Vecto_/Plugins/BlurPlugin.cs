using System;
using System.Collections.Generic;
using Vecto_.Plugins.Interfaces;

public class BlurPlugin : IPlugin
{
    public string Name => "Blur";
    public int? Size { get; set; }

    public void ApplyEffect(ImageChange parameters)
    {
        if (parameters.Blur.Size.HasValue)
        {
            Console.WriteLine($"Applying blur of size {parameters.Blur.Size} to {parameters.ImageName}.");
        }
    }

}
