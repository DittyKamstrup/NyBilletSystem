using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BilletLibrary;

namespace BilletSystemService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class BilletSystemService : IBilletSystem
    {

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetBilBro()
        {
            var bil = new Bil("Storebælt", "1234567", DateTime.Now, true);
            return bil.Køretøj();
        }

        public double GetBilPris()
        {
            var bil = new Bil("Storebælt", "1234567", DateTime.Now, true);
            return bil.Pris();
        }

        public double GetMCPris()
        {
            var mc = new MC("Storebælt", "1234567", DateTime.Now, true);
            return mc.Pris();
        }

        public string GetMCBro()
        {
            var mc = new MC("Storebælt", "1234567", DateTime.Now, true);
            return mc.Køretøj();
        }

        public double GetBilRabatBro()
        {
            DateTime today = DateTime.Today;
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysUntilSaturday = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSaturday = today.AddDays(daysUntilSaturday);
            var bil = new Bil("Storebælt", "1234567", nextSaturday, true);
            return bil.Pris();
        }
    }
}
