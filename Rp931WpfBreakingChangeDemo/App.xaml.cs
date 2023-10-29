using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using Reactive.Bindings;
using Reactive.Bindings.Schedulers;

namespace Rp931WpfBreakingChangeDemo
{
    public partial class App : Application
    {
        public App() => Startup += Application_Startup;

        // Combination confirmation results
        //  |                                 | 9.3.0 | 9.3.1 |
        //  | ------------------------------- | ----- | ----- |
        //  | SynchronizationContextScheduler | OK    | OK    |
        //  | ReactivePropertyWpfScheduler    | OK    | NG    |
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // If the following isn't invoke, the behavior will not change.
            ReactivePropertyScheduler.SetDefault(new ReactivePropertyWpfScheduler(Dispatcher));

            Debug.WriteLine($"RpVer: {(Assembly.GetAssembly(typeof(ReactiveTimer))?.GetName().Version?.ToString() ?? "")}");
            Debug.WriteLine($"RpScheduler: {ReactivePropertyScheduler.Default}");

            var timer = new ReactiveTimer(TimeSpan.FromSeconds(1), ReactivePropertyScheduler.Default);
            timer.Start();

            // If Rp is Ver9.3.1, it will not reach here.
            Debug.WriteLine("Timer start completed.");
        }
    }
}
