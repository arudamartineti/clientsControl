using clientsControl.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace clientsControl.Infrastructure.PaymentControl
{
    public class PaymentControlTool : IPaymentControlTool
    {
        private string generatedPaymentControlPath;
        private string key = "FCKGWRHQQ2YXRKT8TG6W2B7Q8";
        
        #region General Utils
        public string createDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
            return directoryPath;
        }

        private string getDirectoryClient(string clientName)
        {
            return String.Join("_", clientName.Split(' '));
        }

        private string getDirectoryLicense(string licenseName)
        {
            return String.Join("_", licenseName.Split(' '));
        }



        #endregion

        public string generatePaymentControl(string clientDescription, string licenseName, DateTime authorizedUntil, string directoryPayments)
        {
            try
            {
                createDirectory(directoryPayments);

                string location = directoryPayments;

                location += "\\" + getDirectoryClient(clientDescription);

                string locationClient = location;

                createDirectory(location);
                location += "\\" + getDirectoryLicense(licenseName);

                createDirectory(location);

                string fileName = String.Format("{1}{2}{3}_{0}", getDirectoryLicense(licenseName), authorizedUntil.Year, authorizedUntil.Month.ToString("D2"), authorizedUntil.Day.ToString("D2"));
                //string fileNameClient = String.Format("{1}{2}{3}_{0}", getDirectoryClient(clientDescription), authorizedUntil.Year, authorizedUntil.Month.ToString("D2"), authorizedUntil.Day.ToString("D2"));

                string fullPathLicense = location + "\\" + fileName + ".txt";
                //string fullPathClient = locationClient + "\\" + fileNameClient + ".txt";

                Stream file = File.Open(fullPathLicense, FileMode.Create);
                StreamWriter filePaymentControl = new StreamWriter(file, System.Text.ASCIIEncoding.Unicode);

                filePaymentControl.WriteLine(licenseName);
                filePaymentControl.WriteLine(String.Format("Código válido hasta: {0} ", authorizedUntil.ToString("dd/MM/yyyy")));

                filePaymentControl.WriteLine("");

                string cryptedLicenseCode = Crypt(String.Join("", this.LicenseCode(licenseName, authorizedUntil)));

                filePaymentControl.WriteLine(cryptedLicenseCode);

                filePaymentControl.WriteLine("********************************************");

                filePaymentControl.Close();
                filePaymentControl.Dispose();

                file.Close();

                return fullPathLicense;
            }
            catch
            {
                return null;
            }
        }

        public string LicenseCode(string licenseName, DateTime authorizeUntil)
        {
            char[] licenseCode = new char[33];

            for (int i = 0; i < 33; i++) licenseCode[i] = '-';

            // Parametros de Fecha

            licenseCode[3] = authorizeUntil.Day.ToString("D2")[1];
            licenseCode[4] = authorizeUntil.Day.ToString("D2")[0];

            licenseCode[8] = authorizeUntil.Year.ToString()[3];
            licenseCode[9] = authorizeUntil.Year.ToString()[2];

            licenseCode[14] = authorizeUntil.Month.ToString("D2")[1];
            licenseCode[15] = authorizeUntil.Month.ToString("D2")[0];

            // Parametros Nombre Entidad
            if (licenseName.Length >= 6)
            {
                licenseCode[5] = licenseName[5];
            }
            else
            {
                licenseCode[5] = 'X';
            }

            if (licenseName.Length >= 7)
            {
                licenseCode[13] = licenseName[6];
            }
            else
            {
                licenseCode[13] = '@';
            }

            if (licenseName.Length >= 8)
            {
                licenseCode[19] = licenseName[7];
            }
            else
            {
                licenseCode[19] = '?';
            }

            return licenseCode.ToString();
        }

        public string Crypt(string code)
        {
            if (code == null) return null;

            long[] sBox = new long[256];
            long[] sBox2 = new long[256];
            long j, i, k, temp;
            double t;
            int x;
            string outp = "";

            for (i = 0; i < 256; i++)
                sBox[i] = i;

            j = 0;
            for (i = 0; i < 256; i++)
            {
                if (j >= key.Length)
                    j = 0;
                sBox2[i] = Microsoft.VisualBasic.Strings.AscW(key[Convert.ToInt32(j)]);                
                j++;
            }

            j = 0;
            for (i = 0; i < 256; i++)
            {
                j = (j + sBox[i] + sBox2[i]) % 256;
                temp = sBox[i];
                sBox[i] = sBox[j];
                sBox[j] = temp;
            }

            i = 0;
            j = 0;
            for (x = 0; x < code.Length; x++)
            {
                i = (i + 1) % 256;
                j = (j + sBox[i]) % 256;
                temp = sBox[i];
                sBox[i] = sBox[j];
                sBox[j] = temp;
                t = (sBox[i] + sBox[j]) % 256;
                k = sBox[Convert.ToInt32(t)];
                byte[] convert = new byte[20];
                outp += Microsoft.VisualBasic.Strings.ChrW((int)(Microsoft.VisualBasic.Strings.AscW(code[x]) ^ k));
            }
            return outp;
        }
    }
}
