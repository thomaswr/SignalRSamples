using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRTestApp.Models
{
	public class TestHub : Hub
	{
		public void Hello(string message)
		{
			Clients.All.hello(message);
		}

		public override Task OnConnected()
		{
			throw new Exception("onconnected exception");
			return base.OnConnected();
		}
	}
}