using System.Threading;

namespace UdpServer
{
  internal class ThreadManager
  {
    public static void runNewThread(Thread t)
    {
      t.Start();
    }
  }
}
