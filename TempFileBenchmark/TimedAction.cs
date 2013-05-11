using System;
using System.Diagnostics;

namespace TempFileBenchmark
{
  public class TimedAction
  {
    private readonly string m_Name;
    private bool m_HasBeenStarted;
    private string m_Report = string.Empty;

    public TimedAction( string name )
    {
      m_Name = name;
    }

    public void StartTimedAction( Action action )
    {
      if( m_HasBeenStarted )
      {
        throw new InvalidOperationException( "This action was already started." );
      }
      m_HasBeenStarted = true;

      var watch = new Stopwatch();
      watch.Start();
      action.Invoke();
      watch.Stop();

      m_Report = String.Format( "Report for {0}: {1}", m_Name, watch.Elapsed );
    }

    public string Report
    {
      get
      {
        return m_Report;
      }
    }
  }
}