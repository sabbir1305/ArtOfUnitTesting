using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAn.UnitTests
{
    [TestFixture]
    class EventRelatedTests
    {
        public void Presenter_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();

            Presenter presenter = new Presenter(mockView);

            mockView.Loaded += Raise.Event<Action>();
            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hi")));
        }
    }
}
