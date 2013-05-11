using System;
using System.Collections.Generic;
using System.IO;

namespace TempFileBenchmark
{
  internal class FileSystemRunner
  {
    private readonly string m_Directory;
    private readonly FileFactory m_FileFactory = new FileFactory();
    private readonly FileUtility m_FileUtility = new FileUtility();

    public FileSystemRunner( string directory )
    {
      m_Directory = directory;
    }

    public void Run( IDictionary<string, string> sampleData )
    {
      foreach( var data in sampleData )
      {
        string fileNameWithPath = GetFileNameWithPath( data );
        m_FileFactory.CreateFileWithSize( fileNameWithPath, data.Value );
      }

      foreach( var data in sampleData )
      {
        string fileNameWithPath = GetFileNameWithPath( data );
        string storedValue = m_FileUtility.ReadFile( fileNameWithPath );
        if( string.IsNullOrEmpty( storedValue ) )
        {
          throw new InvalidOperationException( "Read data is empty." );
        }
        m_FileUtility.DeleteFile( fileNameWithPath );
      }
    }

    private string GetFileNameWithPath( KeyValuePair<string, string> data )
    {
      return Path.Combine( m_Directory, data.Key );
    }
  }
}