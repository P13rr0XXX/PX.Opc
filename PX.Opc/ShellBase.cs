using System;

namespace PX.Opc
{
    public abstract class ShellBase
    {
        protected bool run;

        protected ShellBase()
        {
            this.run = true;
        }

        protected string Command()
        {
            Console.WriteLine(">");
            return Console.ReadLine();
        }

        public abstract void Start();

        protected abstract void Help();

        protected abstract void About();
    }
}
