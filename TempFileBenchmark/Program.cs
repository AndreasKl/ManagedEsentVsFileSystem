using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Common.Logging;

namespace TempFileBenchmark
{
  internal class Program
  {
    private static readonly ILog Log = LogManager.GetLogger( typeof( Program ) );

    private static void Main( string[] args )
    {
      Console.WindowWidth = 120;
      string directory = ConfigurationManager.AppSettings[ "directory" ];
      CheckEnvironment( directory );
      
      var testSettings = new List<TestSetting>
        {
          new TestSetting( 1000, 1*1024 ), new TestSetting( 1000, 2*1024 ), new TestSetting( 1000, 4*1024 ),
          new TestSetting( 1000, 8*1024 ), new TestSetting( 1000, 16*1024 ), new TestSetting( 1000, 32*1024 ),
          new TestSetting( 10000, 1*1024 ), new TestSetting( 10000, 2*1024 ), new TestSetting( 10000, 4*1024 ),
          new TestSetting( 10000, 8*1024 ), new TestSetting( 10000, 16*1024 ), new TestSetting( 10000, 32*1024 )
        };

      
      var fileSystemRunner = new FileSystemRunner( directory );
      var esentRunner = new EsentRunner( directory );

      var program = new Program();
      foreach( var testSetting in testSettings )
      {
        Log.Info( string.Format( "Starting test with size '{0}' bytes and '{1}' runs.", testSetting.Size, testSetting.Runs ) );

        var sampleData = program.GetSampleData( testSetting );

        var timedActionForFileSystem = new TimedAction( "FileSystem" );
        timedActionForFileSystem.StartTimedAction( () => fileSystemRunner.Run( sampleData ) );
        Log.Info( timedActionForFileSystem.Report );

        var timedActionForEsent = new TimedAction( "Esent" );
        timedActionForEsent.StartTimedAction( () => esentRunner.Run( sampleData ) );
        Log.Info( timedActionForEsent.Report );
      }

      Log.Info( "Done+. Press any key." );
      Console.ReadKey();
    }

    private static void CheckEnvironment( string directory )
    {
      if( !Directory.Exists( directory ) )
      {
        throw new ArgumentException( "The configured directory is not accessible. Check your application.config file." );
      }
    }

    private Dictionary<string, string> GetSampleData( TestSetting testSetting )
    {
      var randomBytesGenerator = new RandomBytesGenerator();
      var sampleData = new Dictionary<string, string>( testSetting.Runs );
      for( int i = 0; i < testSetting.Runs; i++ )
      {
        sampleData.Add( Guid.NewGuid().ToString(), randomBytesGenerator.GetRandomAscii( testSetting.Size ) );
      }
      return sampleData;
    }

    private class TestSetting
    {
      private readonly int m_Runs;
      private readonly int m_Size;

      public TestSetting( int runs, int size )
      {
        m_Runs = runs;
        m_Size = size;
      }

      public int Size
      {
        get
        {
          return m_Size;
        }
      }

      public int Runs
      {
        get
        {
          return m_Runs;
        }
      }
    }
  }
}