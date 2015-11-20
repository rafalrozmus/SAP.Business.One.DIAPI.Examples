using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Business.One.DIAPI.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerConnection connection = new ServerConnection();
            // attempt connection; 0 = success
            if (connection.Connect() == 0)
            {
                Console.WriteLine("Successfully connected to " + connection.GetCompany().CompanyName + "!");
                connection.GetCompany().Disconnect();
            }
            else
            {
                Console.WriteLine("Error " + connection.GetErrorCode() + ": " + connection.GetErrorMessage());
            }
        }
    }
}
