using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace GameOfLife.Utilities
{
    public static class RefreshTimer
    {
        static Timer _timer;
        static List<DateTime> _1;
        
        public static List<DateTime> DateList
        {
            get
            {
                if ( _1 == null)
                {
                    Start();
                }
                return _1;
            }
        }

        static void Start()
        {
            _1 = new List<DateTime>();
            _timer = new Timer(1000);

            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true;
        }

        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _1.Add(DateTime.Now);
        }
    }
}
