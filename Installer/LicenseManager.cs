using System;
using System.Management;

namespace Lab12BPDT.Installer
{
    public class LicenseManager
    {
        public static bool VerifyLicense(string inputKey)
        {
            string systemKey = GenerateSystemKey();
            string validKey = GenerateLicenseKey(systemKey);
            return inputKey == validKey;
        }

        private static string GenerateSystemKey()
        {
            // Використовуємо серійний номер диска як унікальний ідентифікатор
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_PhysicalMedia");
            foreach (ManagementObject obj in searcher.Get())
            {
                return obj["SerialNumber"].ToString();
            }
            return "UNKNOWN";
        }

        private static string GenerateLicenseKey(string systemKey)
        {
            // Простий механізм генерації ключа
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(systemKey + "SecretSalt"));
        }
    }

}
