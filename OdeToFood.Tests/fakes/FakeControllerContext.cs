using System.Collections.Specialized;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Tests.fakes
{
    class FakeControllerContext : ControllerContext
    {
        private HttpContextBase _context = new FakeHttpContext();

        public override System.Web.HttpContextBase HttpContext
        {
            get { return _context; }
            set { _context = value; }
        }

    }

    internal class FakeHttpContext : HttpContextBase
    {
        private HttpRequestBase _request = new FakeHttpRequest();

        public override HttpRequestBase Request
        {
            get { return _request; }
        }
    }

    internal class FakeHttpRequest : HttpRequestBase
    {
        public override string this[string key]
        {
            get { return null; }
        }

        public override NameValueCollection Headers
        {
            get
            {
                return new NameValueCollection();
            }
        }
    }
}
