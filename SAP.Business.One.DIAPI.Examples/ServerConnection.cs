using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SAP.Business.One.DIAPI.Examples
{
    class ServerConnection
    {
        private SAPbobsCOM.Company company = new SAPbobsCOM.Company();
        private int connectionResult;
        private int errorCode = 0;
        private string errorMessage = "";

        /// <summary>
        /// Initialises server settings, sets up connection credentials and attempts
        /// a new connection to SAP Business One server.
        /// </summary>
        /// <returns>Connection result as integer. Returns 0 if connection was successful</returns>
        public int connect()
        {
            // All the server settings and user credentials used below are stored in App.config file.
            // ConfigurationManager is being used to read the App.config file. 
            // You can store you own settings in App.config or use actual values directly in the code:
            // company.Server = "sapb1server";
            // Example.App.config is included in this project, rename it to App.config and populate it with your own values.
            company.Server = ConfigurationManager.AppSettings["server"].ToString();
            company.CompanyDB = ConfigurationManager.AppSettings["companydb"].ToString();
            company.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012;
            company.DbUserName = ConfigurationManager.AppSettings["dbuser"].ToString();
            company.DbPassword = ConfigurationManager.AppSettings["dbpassword"].ToString();
            company.UserName = ConfigurationManager.AppSettings["user"].ToString();
            company.Password = ConfigurationManager.AppSettings["password"].ToString();
            company.language = SAPbobsCOM.BoSuppLangs.ln_English_Gb;
            company.UseTrusted = false;
            company.LicenseServer = ConfigurationManager.AppSettings["licenseServer"].ToString();

            connectionResult = company.Connect();

            if (connectionResult != 0)
            {
                company.GetLastError(out errorCode, out errorMessage);
            }

            return connectionResult;
        }
        /// <summary>
        /// Returns SAP Business One Company Object
        /// </summary>
        /// <returns>SAPbobsCOM.Company object</returns>
        public SAPbobsCOM.Company getCompany()
        {
            return this.company;
        }

        /// <summary>
        /// Returns last error code
        /// </summary>
        /// <returns>Last error code as integer</returns>
        public int getErrorCode()
        {
            return this.errorCode;
        }

        /// <summary>
        /// Returns last error message
        /// </summary>
        /// <returns>Last error message as String</returns>
        public String getErrorMessage()
        {
            return this.errorMessage;
        }
    }
}
