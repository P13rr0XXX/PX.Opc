using System;
using System.Threading;

namespace PX.Opc
{
    public class LoopEngine
    {
        private delegate void Function();
        private Function preLoop;
        private Function loop;
        private Function postLoop;

        private readonly LoopConfig loopConfig;

        private bool run;
        private Thread thread;

        public LoopEngine(ILoop loop, LoopConfig loopConfig)
        {
            if (loop == null) throw new ArgumentNullException(nameof(loop), "Loop can't be null.");
            this.preLoop = loop.PreLoop;
            this.loop = loop.Loop;
            this.postLoop = loop.PostLoop;

            this.loopConfig = loopConfig ?? throw new ArgumentNullException(nameof(loopConfig), "LoopConfig can't be null.");

            this.run = default;
            this.thread = new Thread(new ThreadStart(this.Loop)) { Priority = ThreadPriority.Normal, Name = this.loopConfig.Name};
        }

        public void Start()
        {
            this.run = true;
            this.thread.Start();
        }

        public void Loop()
        {
            this.preLoop();

            while(this.run)
            {
                Thread.Sleep(this.loopConfig.SleepDuration);
                this.loop();
            }

            this.postLoop();
        }

        public void Stop()
        {
            this.run = false;
            this.thread.Join();
        }
    }
}
