namespace PX.Opc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Config config = Xml.Deserilize<Config>("Config.xml");

            LoopEngine loopEngine = new LoopEngine(new Looping(config), new LoopConfig("Looping", 4000));
            loopEngine.Start();

            new Shell().Start();

            loopEngine.Stop();
        }
    }
}
