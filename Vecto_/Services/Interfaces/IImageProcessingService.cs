namespace Vecto_.Services.Interfaces
{
    public interface IImageProcessingService
    {
        void AddImage(List<Image> image);
        void ApplyEffects(List<ImageChange> parameters);
    }
}
