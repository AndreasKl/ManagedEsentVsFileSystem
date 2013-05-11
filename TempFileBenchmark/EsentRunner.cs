using System;
using System.Collections.Generic;
using Microsoft.Isam.Esent.Collections.Generic;

namespace TempFileBenchmark
{
  internal class EsentRunner
  {
    private const string Directory = @"C:\Temp\";
    private readonly PersistentDictionary<string, string> m_PersistentDictionary = CreatePersistentDictionary();

    public void Run( IDictionary<string, string> sampleData )
    {
      m_PersistentDictionary.Clear();
      foreach( var data in sampleData )
      {
        string id = data.Key;
        m_PersistentDictionary.Add( id, data.Value );
      }
      
      foreach( var data in sampleData )
      {
        String storedValue;
        m_PersistentDictionary.TryGetValue( data.Key, out storedValue );
        if( string.IsNullOrEmpty( storedValue ) )
        {
          throw new InvalidOperationException( "Read data is empty." );
        }
        m_PersistentDictionary.Remove( data.Key );
      }
    }

    private static PersistentDictionary<string, string> CreatePersistentDictionary()
    {
      if( PersistentDictionaryFile.Exists( Directory ) )
      {
        PersistentDictionaryFile.DeleteFiles( Directory );
      }
      var persistentDictionary = new PersistentDictionary<string, string>( Directory );
      return persistentDictionary;
    }
  }
}