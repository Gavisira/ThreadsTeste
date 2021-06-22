using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace ThreadsTeste.Controllers
{
    public static class TimerController
    {
        public static List<ThreadTime> ThreadTimes = new List<ThreadTime>();


        public static void AddTime(this Thread thread, int time)
        {
            ThreadTimes.FirstOrDefault(c => c.Thread.ManagedThreadId == thread.ManagedThreadId).Time += time;
        }

        public static int GetTime(this Thread thread)
        {
            return ThreadTimes.FirstOrDefault(c => c.Thread.ManagedThreadId == thread.ManagedThreadId).Time;
        }

    }

    public class ThreadTime
    {
        public ThreadTime(Thread thread, int time)
        {
            this.Thread = thread;
            this.Time = time;

        }
        public Thread Thread { get; set; }
        public int Time { get; set; }
    }


}