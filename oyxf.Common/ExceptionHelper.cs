using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Threading;

namespace oyxf.Common
{
    public class ExceptionHelper
    {
        public static Queue<Exception> queue = new Queue<Exception>();
        public static ILog log = LogManager.GetLogger(typeof(ExceptionHelper));

        public static void Enqueue(Exception ex)
        {
            queue.Enqueue(ex);
        }

        public static void HandleException()
        {

            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    if (queue.Count > 0)
                    {
                        Exception ex = queue.Dequeue();
                        log.Error(ex);
                    }
                    else
                    {
                        Thread.Sleep(5000);
                    }
                }
            });
        }
    }
}
