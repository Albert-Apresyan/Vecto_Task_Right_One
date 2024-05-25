using System;
using System.Collections.Generic;
using Vecto_.Plugins.Interfaces;

public class ResizePlugin : IPlugin
{
    public string Name => "Resize";
    public int? Size { get; set; }

    public void ApplyEffect(ImageChange parameters)
    {
        if (parameters.Resize.Size.HasValue)
        {
            Console.WriteLine($"Applying resize of size {parameters.Resize.Size} to {parameters.ImageName}.");
        }
    }

}
