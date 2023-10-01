using System;

namespace PX.Opc
{
    public class Shell : ShellBase
    {
        public Shell() : base() { }

        public override void Start()
        {
            while(this.run)
            {
                switch (this.Command())
                {
                    case "stop":
                        this.Stop();
                        break;
                    case "help":
                        this.Help();
                        break;
                    case "?":
                        this.About();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Stop() => this.run = false;

        protected override void Help()
        {
            Console.WriteLine("stop -> Stop");
            Console.WriteLine("help -> Help");
            Console.WriteLine("? -> About");
        }

        public void UnknowCommand()
        {
            Console.WriteLine("Unknow command, try 'help' command.");
        }

        protected override void About()
        {
            Console.WriteLine("By Pierre GRIESMAR.");
            Console.WriteLine("Version X.X.X.");
        }
    }
}
