using UdpServer;
using UdpServer.serverpackets;

namespace UdpServer.clientpackets
{
  internal class opcode_61_CLIENT : ReceiveBasePacket
  {
    private UDPclient uDPclient;
    private byte[] buff;

    public opcode_61_CLIENT(UDPclient uDPclient, byte[] buff)
    {
      this.makeme(uDPclient, buff);
    }

    protected internal override void read()
    {
    }

    protected internal override void run()
    {
      this.getClient().sendPacket((SendBasePacket) new opcode_61_SERVER());
    }
  }
}
