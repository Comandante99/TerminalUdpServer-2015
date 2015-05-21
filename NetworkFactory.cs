using System;
using System.Net.Sockets;
using System.Threading;

namespace UdpServer
{
  internal class NetworkFactory
  {
    private static NetworkFactory _instance;
    private static UdpClient _client;

    public NetworkFactory()
    {
      UdpClient udpClient = new UdpClient(40003);
      Console.WriteLine("Auth server listening clients at " + (object) 40003);
      NetworkFactory._client = (UdpClient) null;
      while (true)
      {
        Thread.Sleep(100);
        if (udpClient != null)
        {
          try
          {
            if (udpClient.Available > 0)
            {
              NetworkFactory._client = udpClient;
              NetworkFactory.accept(NetworkFactory._client);
            }
          }
          catch
          {
          }
        }
      }
    }

    public static NetworkFactory getInstance()
    {
      if (NetworkFactory._instance != null)
        return NetworkFactory._instance;
      NetworkFactory._instance = new NetworkFactory();
      return NetworkFactory._instance;
    }

    private static void accept(UdpClient client)
    {
      ClientManager.getInstance().addClient(client);
    }
  }
}
