using System;

namespace Proxy
{

    public interface IClient
    {
        string GetData();
    }

    public class RealClient : IClient
    {
		private string Data;

        public RealClient()
        {
            Console.WriteLine("RealClient: Initialized");
            this.Data = "WSEI data";
        }

        public string GetData()
        {
			      return Data;
        }
    }


    public class ProxyClient : IClient
    {
      RealClient client = null;
      private string _pass = "dobrehaslo";
      private bool _authenticated = false;

      public ProxyClient(string password)
      {
          if (password == this._pass)
          {
              this._authenticated = true;
              Console.WriteLine("ProxyClient: Initialized");
          }
          else
          {
              this._authenticated = false;
				      Console.WriteLine("ProxyClient: Access denied");
          }
      }

      public string GetData()
      {
        if (this._authenticated)
        {
            this.client = new RealClient();
            return $"Data from Proxy Client = {client.GetData()}";
        }
        else
        {
            return null;  
        }
      }
    }


    class Program
    {
        static void Main(string[] args)
        {

          ProxyClient proxy1 = new ProxyClient("zlehaslo");
		    	Console.WriteLine(proxy1.GetData());

          ProxyClient proxy2 = new ProxyClient("dobrehaslo");
			    Console.WriteLine(proxy2.GetData());

        }

    }

}
