using System;

namespace TempFileBenchmark
{
  public interface IRandomBytesGenerator
  {
    byte[] GetRandomBytes( int size );
  }

  public class RandomBytesGenerator : IRandomBytesGenerator
  {
    private readonly Random m_Randomizer = new Random( DateTime.Now.Millisecond );

    public byte[] GetRandomBytes( int size )
    {
      if( size <= 0 )
      {
        throw new ArgumentException( "size" );
      }

      var randomData = new byte[size];
      m_Randomizer.NextBytes( randomData );
      return randomData;
    }

    public string GetRandomAscii( int size )
    {
      string base64String = Convert.ToBase64String( GetRandomBytes( size ) );
      return base64String.Substring( 0, size );
    }
  }
}