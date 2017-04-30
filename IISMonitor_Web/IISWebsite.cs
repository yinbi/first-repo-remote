using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.Collections;

namespace IISMonitor_Web
{
    public class IISWebsite
    {
        private DirectoryEntry websiteEntry = null;
        internal const string IIsWebServer = "IIsWebServer";

        protected IISWebsite(DirectoryEntry Server)
        {
            websiteEntry = Server;
        }

        public static IISWebsite OpenWebsite(string name)
        {
            // get directory service
            DirectoryEntry Services = new DirectoryEntry("IIS://localhost/W3SVC");
            IEnumerator ie = Services.Children.GetEnumerator();
            DirectoryEntry Server = null;

            // find iis website
            while (ie.MoveNext())
            {
                Server = (DirectoryEntry)ie.Current;
                if (Server.SchemaClassName == IIsWebServer)
                {
                    // "ServerComment" means name
                    if (Server.Properties["ServerComment"][0].ToString() == name)
                    {
                        return new IISWebsite(Server);
                        break;
                    }
                }
            }

            return null;
        }

        public static IISAppPool OpenAppPool(string name)
        {
            string connectStr = "IIS://localhost/W3SVC/AppPools/";
            connectStr += name;

            if (IISAppPool.Exsit(name) == false)
            {
                return null;
            }

            DirectoryEntry entry = new DirectoryEntry(connectStr);
            return new IISAppPool(entry);
        }



    }
}
