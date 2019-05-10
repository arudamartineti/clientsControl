using System;
using System.Collections.Generic;
using System.Text;

namespace clientsControl.Application.Licenses.Queries.GetStaticsLicenses
{
    public class GetStaticsLicensesQueryDto
    {
        public int Clients { set; get; }
        public int ClientsWithoutLicenses { set; get; }
        public int ClientsMoreThanOneLicense { set; get; }
        public int Licenses { set; get; }
        public int LicensesEmpty { set; get; }
    }
}
