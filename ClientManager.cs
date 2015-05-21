using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace UdpServer
{
  internal class ClientManager
  {
    private static ClientManager _instance = new ClientManager();
    private List<UDPclient> _loggedClients = new List<UDPclient>();

    public ClientManager()
    {
      Console.WriteLine("ClientManager Initialized.");
    }

    public static ClientManager getInstance()
    {
      return ClientManager._instance;
    }

    public List<UDPclient> getLoggedClients()
    {
      return this._loggedClients;
    }

    public void addClient(UdpClient client)
    {
      UDPclient udPclient = new UDPclient(client);
      if (this._loggedClients.Contains(udPclient))
        return;
      this._loggedClients.Add(udPclient);
    }

    public void removeClient(UDPclient loginClient)
    {
      if (!this._loggedClients.Contains(loginClient))
        return;
      this._loggedClients.Remove(loginClient);
    }
  }
}
