using System;
using UdpServer;
using UdpServer.models;
using UdpServer.serverpackets;

namespace UdpServer.clientpackets
{
  internal class opcode_03_CLIENT : ReceiveBasePacket
  {
    private UDPclient _uDPclient;
    private byte[] buff;
    private Player _player;

    public opcode_03_CLIENT(UDPclient uDPclient, byte[] buff)
    {
      this._uDPclient = uDPclient;
      this.makeme(uDPclient, buff);
    }

    protected internal override void read()
    {
      Console.WriteLine("==opcode_03_CLIENT==");
      this._player = this.getClient().getPlayer();
      this._player.setRotateX(this.readC());
      this._player.setRotateY(this.readC());
      this.getClient().UpdatePlayer(this._player);
      Console.WriteLine("X: " + (object) this._player.getRotateX());
      Console.WriteLine("Y: " + (object) this._player.getRotateY());
      Console.WriteLine("==opcode_03_CLIENT==");
    }

    protected internal override void run()
    {
      this.getClient().sendPacket((SendBasePacket) new opcode_65284_SERVER());
    }
  }
}
