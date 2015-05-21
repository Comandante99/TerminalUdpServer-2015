using UdpServer;

namespace UdpServer.serverpackets
{
  internal class opcode_65284_SERVER : SendBasePacket
  {
    public opcode_65284_SERVER()
    {
      this.makeme();
    }

    protected internal override void write()
    {
      this.writeB(new byte[82]
      {
        (byte) 4,
        byte.MaxValue,
        (byte) 145,
        (byte) 237,
        (byte) 11,
        (byte) 65,
        (byte) 1,
        (byte) 82,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 0,
        (byte) 23,
        (byte) 0,
        (byte) 0,
        (byte) 10,
        (byte) 0,
        (byte) 0,
        (byte) 230,
        (byte) 206,
        (byte) 193,
        (byte) 68,
        (byte) 154,
        (byte) 190,
        (byte) 239,
        (byte) 85,
        (byte) 179,
        (byte) 67,
        (byte) 5,
        (byte) 0,
        (byte) 240,
        (byte) 31,
        (byte) 9,
        (byte) 10,
        (byte) 0,
        (byte) 6,
        (byte) 0,
        (byte) 0,
        (byte) 9,
        (byte) 11,
        (byte) 0,
        (byte) 6,
        (byte) 0,
        (byte) 0,
        (byte) 9,
        (byte) 12,
        (byte) 0,
        (byte) 6,
        (byte) 0,
        (byte) 0,
        (byte) 9,
        (byte) 13,
        (byte) 0,
        (byte) 6,
        (byte) 0,
        (byte) 0,
        (byte) 9,
        (byte) 14,
        (byte) 0,
        (byte) 6,
        (byte) 0,
        (byte) 0
      });
    }
  }
}
