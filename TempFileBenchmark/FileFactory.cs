using System;
using System.IO;

namespace TempFileBenchmark
{
  public class FileFactory
  {
    public FileInfo CreateFileWithSize( string fileName, string content )
    {
      if( string.IsNullOrEmpty( fileName ) )
      {
        throw new ArgumentException( "fileName" );
      }

      File.WriteAllText( fileName, content );
      return new FileInfo( fileName );
    }
  }
}