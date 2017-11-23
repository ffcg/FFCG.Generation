using System.Collections.Generic;

namespace FFCG.Generation.Collector.Host.Presenters
{
    public class MultiplePresenter: IPresenter
    {
        private readonly List<IPresenter> _presenters;

        public MultiplePresenter(List<IPresenter> presenters)
        {
            _presenters = presenters;
        }

        public void Present(string name, int age)
        {
            foreach (var presenter in _presenters)
            {
                presenter.Present(name, age);
            }   
        }
    }
}