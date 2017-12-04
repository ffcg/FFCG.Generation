using System;

namespace FFCG.Generation.Collector.Host.Presenters
{
    public class ShoutingConsolePresenter : IPresenter
    {
        public void Present(string name, int age)
        {
            Console.WriteLine($"{name} is age: {age}".ToUpper());
        }
    }
}