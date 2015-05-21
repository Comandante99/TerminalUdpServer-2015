using UdpServer;

namespace UdpServer.serverpackets
{
  public class opcode_66_SERVER : SendBasePacket
  {
    public opcode_66_SERVER()
    {
      this.makeme();
    }

    protected internal override void write()
    {
      byte[] numArray = new byte[29];
      numArray[0] = (byte) 66;
      numArray[7] = (byte) 29;
      this.writeB(numArray);
    }
  }
}
