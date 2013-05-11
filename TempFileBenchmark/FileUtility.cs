using System.IO;

namespace TempFileBenchmark
{
  public class FileUtility
  {
    public void DeleteFile( string fileName )
    {
      File.Delete( fileName );
    }

    /// <summary>
    ///   Reads a <see cref="byte" /> array from a file.
    /// </summary>
    /// <param name="fileName">Name of the file.</param>
    /// <returns>the byte array</returns>
    public string ReadFile( string fileName )
    {
      return File.ReadAllText( fileName );
    }
  }
}