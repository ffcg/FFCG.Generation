using System.Collections.Generic;
using System.IO;

namespace FFCG.Generation.Collector.Host.Presenters
{
    public class FilePresenter : IPresenter
    {
        private readonly string _targetFilePath;

        public FilePresenter(string targetFilePath)
        {
            _targetFilePath = targetFilePath;
        }

        public void Present(string name, int age)
        {
            File.AppendAllLines(_targetFilePath, new List<string> {$"{name} {age}"});
        }
    }
}