using System;
using System.Net.Mail;

namespace Typesafe.Mailgun.Routing
{
	public class RouteAction
	{
		protected internal RouteAction(string expression)
		{
			Expression = expression;
		}

		public static RouteAction MailForward(MailAddress address)
		{
			return new RouteAction(string.Format("forward(\"{0}\")", address.Address));
		}

		public static RouteAction InvokeWebHook(Uri url)
		{
			return new RouteAction(string.Format("forward(\"{0}\")", url));
		}
        
	        /// <summary>
	        /// just store emails temporarily
	        /// </summary>
	        /// <returns></returns>
	        public static RouteAction Store()
	        {
	            return new RouteAction(string.Format("store()"));
	        }
	
	        /// <summary>
	        /// store email and call provided url to notify for new ones
	        /// </summary>
	        /// <param name="callbackUri"></param>
	        /// <returns></returns>
	        public static RouteAction Store(Uri callbackUri)
	        {
	            return new RouteAction(string.Format("store(notify=\"{0}\")", callbackUri));
	        }

		public static RouteAction Stop()
		{
			return new RouteAction("stop()");
		}

		public string Expression { get; private set; }

		public override string ToString() { return Expression; }
	}
}
