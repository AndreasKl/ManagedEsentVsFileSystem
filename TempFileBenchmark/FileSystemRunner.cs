using System;
using System.Collections.Generic;

namespace TempFileBenchmark
{
  internal class FileSystemRunner
  {
    private const string Directory = @"C:\Temp\";
    private const string Path = Directory + "{0}";
    private readonly FileFactory m_FileFactory = new FileFactory();
    private readonly FileUtility m_FileUtility = new FileUtility();

    public void Run( IDictionary<string, string> sampleData )
    {
      foreach( var data in sampleData )
      {
        string fileNameWithPath = string.Format( Path, data.Key );
        m_FileFactory.CreateFileWithSize( fileNameWithPath, data.Value );
      }

      foreach( var data in sampleData )
      {
        string fileNameWithPath = string.Format( Path, data.Key );
        string storedValue = m_FileUtility.ReadFile( fileNameWithPath );
        if( string.IsNullOrEmpty( storedValue ) )
        {
          throw new InvalidOperationException( "Read data is empty." );
        }
        m_FileUtility.DeleteFile( fileNameWithPath );
      }
    }
  }
}