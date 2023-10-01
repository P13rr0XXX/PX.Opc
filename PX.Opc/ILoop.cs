namespace PX.Opc
{
    public interface ILoop
    {
        void PreLoop();

        void Loop();

        void PostLoop();
    }
}
