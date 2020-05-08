using System;
using System.Collections.Generic;
using System.Text;

namespace CS_20200422
{
    class TimerInitializedEventArgs : EventArgs
    { 
        public string Name { get; private set; }

        public TimerInitializedEventArgs()
        {

        }

        public TimerInitializedEventArgs(string name)
        {
            Name = name;
        }

    }
}
