namespace Vecto_.Plugins.Interfaces
{
    public interface IPlugin
    {
        string Name { get; }
        void ApplyEffect(ImageChange request);
    }
}
