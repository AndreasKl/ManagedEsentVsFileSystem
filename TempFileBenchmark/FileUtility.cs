using System.IO;

namespace TempFileBenchmark
{
  public class FileUtility
  {
    public void DeleteFile( string fileName )
    {
      File.Delete( fileName );
    }
    
    public string ReadFile( string fileName )
    {
      return File.ReadAllText( fileName );
    }
  }
}
