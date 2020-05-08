using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace CS_20200422
{
    class TimerManager
    {
        public event EventHandler Initialized;
        private readonly string _name;

        public TimerManager(string name)
        {
            _name = name;
        }

        public void Initialize()
        {
            var random = new Random();
            var time = random.Next(1000, 5000);

            System.Diagnostics.Debug.WriteLine($"Timer impostato a {time} millesimi di secondo");

            var timer = new Timer(5000);
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            OnInitialized(new TimerInitializedEventArgs(_name));
        }

        private void OnInitialized(TimerInitializedEventArgs e)
        {
            Initialized?.Invoke(this, e);
        }
    }
}
