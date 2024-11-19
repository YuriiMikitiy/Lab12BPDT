using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace Installer
{
    public class LicenseManager
    {
        public static bool VerifyLicense(string inputKey)
        {
            string systemKey = GenerateSystemKey();
            string privateKey = File.ReadAllText("privateKey.xml");
            string validKey = GenerateLicenseKey(systemKey, privateKey);
            return inputKey == validKey;
        }

        public static string GenerateSystemKey()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia");
                foreach (ManagementObject obj in searcher.Get())
                {
                    if (obj["SerialNumber"] != null)
                        return obj["SerialNumber"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return "UNKNOWN";
        }

        public static string GenerateLicenseKey(string systemInfo, string privateKey)
        {
            byte[] data = Encoding.UTF8.GetBytes(systemInfo);

            using (RSA rsa = RSA.Create())
            {
                rsa.FromXmlString(privateKey);
                byte[] signedData = rsa.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                return Convert.ToBase64String(signedData);
            }
        }
    }
}
