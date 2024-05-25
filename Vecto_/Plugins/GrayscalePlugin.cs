using System;
using System.Collections.Generic;
using Vecto_.Plugins.Interfaces;

public class GrayscalePlugin : IPlugin
{
    public string Name => "Grayscale";
    public bool IsNeeded { get; set; }
    public void ApplyEffect(ImageChange parameters)
    {
        if (parameters.Grayscale.IsNeeded)
        {
            Console.WriteLine($"Converting {parameters.ImageName} to grayscale.");
        }
    }

}
