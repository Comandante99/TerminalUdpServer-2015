

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UdpServer.clientpackets;
using UdpServer.models;

namespace UdpServer
{
  public class UDPclient
  {
    private IPEndPoint remoteip = (IPEndPoint) null;
    private UdpClient _udpclient;
    private byte[] _buffer;
    private Player p;

    public UDPclient(UdpClient udp)
    {
      Console.WriteLine("Client connected.");
      this._udpclient = udp;
      this.p = new Player();
      new Thread(new ThreadStart(this.read)).Start();
    }

    public Player getPlayer()
    {
      return this.p;
    }

    public void UpdatePlayer(Player pl)
    {
      this.p = pl;
    }

    public void ConnectionClose()
    {
      try
      {
        Console.WriteLine("Connection Close.");
        ClientManager.getInstance().removeClient(this);
      }
      catch (Exception ex)
      {
        Console.WriteLine("FATAL ERROR: ");
        Console.WriteLine(ex.Message);
      }
    }

    public void sendPacket(SendBasePacket bp)
    {
      bp.write();
      byte[] numArray1 = bp.ToByteArray();
      List<byte> list = new List<byte>(numArray1.Length);
      list.AddRange((IEnumerable<byte>) numArray1);
      byte[] dgram = list.ToArray();
      byte[] numArray2 = new byte[2]
      {
        dgram[0],
        dgram[1]
      };
      Console.WriteLine(string.Concat(new object[4]
      {
        (object) "Sending :",
        (object) dgram.Length,
        (object) "; OPCODE: ",
        (object) BitConverter.ToUInt16(numArray2, 0)
      }));
      if (dgram.Length <= 0)
        return;
      this._udpclient.Send(dgram, dgram.Length, this.remoteip.Address.ToString(), this.remoteip.Port);
    }

    public void read()
    {
      try
      {
        if (this._udpclient.Available > 0)
        {
          Thread.Sleep(100);
          this._udpclient.BeginReceive(new AsyncCallback(this.OnReceiveCallbackStatic), (object) null);
        }
        else
          new Thread(new ThreadStart(this.read)).Start();
      }
      catch (Exception ex)
      {
      }
    }

    private void OnReceiveCallbackStatic(IAsyncResult result)
    {
      try
      {
        if (this._udpclient.Client.Available <= 0)
          return;
        this._buffer = new byte[this._udpclient.Available];
        this._buffer = this._udpclient.Receive(ref this.remoteip);
        this.handlePacket(this._buffer);
      }
      catch (Exception ex)
      {
      }
    }

    private void handlePacket(byte[] buff)
    {
      ushort num1 = BitConverter.ToUInt16(new byte[2]
      {
        buff[0],
        buff[1]
      }, 0);
      BitConverter.ToString(buff).Replace("-", " ");
      Console.WriteLine("Recieved packet opcode: " + (object) num1);
      Console.WriteLine("INFO: ");
      string[] strArray = BitConverter.ToString(buff).Split('-', ',', '.', ':', '\t');
      string str1 = "";
      foreach (string str2 in strArray)
        str1 = str1 + "0x" + str2 + " ";
      Console.WriteLine(str1);
      List<ReceiveBasePacket> list = new List<ReceiveBasePacket>();
      ushort num2 = num1;
      if ((uint) num2 <= 3U)
      {
        if ((int) num2 != 0 && (int) num2 == 3)
          list.Add((ReceiveBasePacket) new opcode_03_CLIENT(this, buff));
      }
      else if ((int) num2 != 61)
      {
        if ((int) num2 != 65)
        {
          if ((int) num2 == 97)
            ;
        }
        else
          list.Add((ReceiveBasePacket) new opcode_65_CLIENT(this, buff));
      }
      else
        list.Add((ReceiveBasePacket) new opcode_61_CLIENT(this, buff));
      if (list == null || list.ToArray().Length <= 0)
        return;
      foreach (ReceiveBasePacket receiveBasePacket in list)
        ThreadManager.runNewThread(new Thread(new ThreadStart(receiveBasePacket.run)));
    }
  }
}
