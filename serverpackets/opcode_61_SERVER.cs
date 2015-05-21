using UdpServer;

namespace UdpServer.serverpackets
{
  internal class opcode_61_SERVER : SendBasePacket
  {
    public opcode_61_SERVER()
    {
      this.makeme();
    }

    protected internal override void write()
    {
      this.writeB(new byte[38]
      {
        (byte) 97,
        (byte) 0,
        (byte) 108,
        (byte) 18,
        (byte) 11,
        (byte) 64,
        (byte) 1,
        (byte) 38,
        (byte) 0,
        (byte) 71,
        (byte) 76,
        (byte) 73,
        (byte) 65,
        (byte) 32,
        (byte) 70,
        (byte) 69,
        (byte) 82,
        (byte) 79,
        (byte) 67,
        (byte) 69,
        (byte) 32,
        (byte) 33,
        (byte) 33,
        (byte) 33,
        (byte) 0,
        (byte) 114,
        (byte) 0,
        (byte) 3,
        (byte) 0,
        (byte) 147,
        (byte) 1,
        (byte) 0,
        (byte) 0,
        byte.MaxValue,
        (byte) 203,
        (byte) 41,
        (byte) 0,
        (byte) 0
      });
    }
  }
}
