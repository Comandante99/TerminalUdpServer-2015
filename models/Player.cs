namespace UdpServer.models
{
  public class Player
  {
    private byte rotateX = (byte) 0;
    private byte rotateY = (byte) 0;

    public void setRotateX(byte rX)
    {
      this.rotateX = rX;
    }

    public void setRotateY(byte rY)
    {
      this.rotateY = rY;
    }

    public byte getRotateX()
    {
      return this.rotateX;
    }

    public byte getRotateY()
    {
      return this.rotateY;
    }
  }
}
