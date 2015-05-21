using System;
using System.Diagnostics;

namespace UdpServer
{
  internal class Program
  {
    private static Program auth = new Program();

    public Program()
    {
      ClientManager.getInstance();
      NetworkFactory.getInstance();
    }

    [STAThread]
    private static void Main()
    {
      Program.getInstance();
      Process.GetCurrentProcess().WaitForExit();
    }

    public static Program getInstance()
    {
      return Program.auth;
    }
  }
}
