using System;
using System.Collections.Generic;
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

      Log.Info( "Generating random strings." );

      var testSettings = new List<Program.TestSetting>
        {
          new TestSetting( 1000, 1*1024 ), new TestSetting( 1000, 2*1024 ), new TestSetting( 1000, 4*1024 ),
          new TestSetting( 1000, 8*1024 ), new TestSetting( 1000, 16*1024 ), new TestSetting( 1000, 32*1024 ),
          new TestSetting( 10000, 1*1024 ), new TestSetting( 10000, 2*1024 ), new TestSetting( 10000, 4*1024 ),
          new TestSetting( 10000, 8*1024 ), new TestSetting( 10000, 16*1024 ), new TestSetting( 10000, 32*1024 )
        };

      var program = new Program();
      var fileSystemRunner = new FileSystemRunner();
      var esentRunner = new EsentRunner();
      foreach( var testSetting in testSettings )
      {
        Log.Info( string.Format( "Starting test with size '{0}' and amount '{1}'.", testSetting.Size, testSetting.Amount ) );

        // Generate n of strings of size x
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

    private Dictionary<string, string> GetSampleData( Program.TestSetting testSetting )
    {
      var randomBytesGenerator = new RandomBytesGenerator();
      var sampleData = new Dictionary<string, string>( testSetting.Amount );
      for( int i = 0; i < testSetting.Amount; i++ )
      {
        sampleData.Add( Guid.NewGuid().ToString(), randomBytesGenerator.GetRandomAscii( testSetting.Size ) );
      }
      return sampleData;
    }

    private class TestSetting
    {
      private readonly int m_Amount;
      private readonly int m_Size;

      public TestSetting( int amount, int size )
      {
        m_Amount = amount;
        m_Size = size;
      }

      public int Size
      {
        get
        {
          return m_Size;
        }
      }

      public int Amount
      {
        get
        {
          return m_Amount;
        }
      }
    }
  }
}