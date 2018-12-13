using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml;

namespace Glyder.Licensing
{
    public class KCCrypt
    {
        private RijndaelManaged myRijndael = new RijndaelManaged();
        private int iterations;
        private byte[] salt;

        public KCCrypt(string strPassword)
        {
            myRijndael.BlockSize = 128;
            myRijndael.KeySize = 256;
            myRijndael.IV = HexStringToByteArray("6c462c84ea324938b664f4478bfd9461");

            myRijndael.Padding = PaddingMode.PKCS7;
            myRijndael.Mode = CipherMode.CBC;
            iterations = 1000;
            salt = System.Text.Encoding.UTF8.GetBytes("KCcryptography123");
            myRijndael.Key = GenerateKey(strPassword);
        }

        public string Encrypt(string strPlainText)
        {
            byte[] strText = new System.Text.UTF8Encoding().GetBytes(strPlainText);
            ICryptoTransform transform = myRijndael.CreateEncryptor();
            byte[] cipherText = transform.TransformFinalBlock(strText, 0, strText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public string Decrypt(string encryptedText)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            ICryptoTransform transform = myRijndael.CreateDecryptor();
            byte[] cipherText = transform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return System.Text.Encoding.UTF8.GetString(cipherText);
        }

        public static byte[] HexStringToByteArray(string strHex)
        {
            dynamic r = new byte[strHex.Length / 2];
            for (int i = 0; i <= strHex.Length - 1; i += 2)
            {
                r[i / 2] = Convert.ToByte(Convert.ToInt32(strHex.Substring(i, 2), 16));
            }
            return r;
        }

        private byte[] GenerateKey(string strPassword)
        {
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(System.Text.Encoding.UTF8.GetBytes(strPassword), salt, iterations);
            return rfc2898.GetBytes(myRijndael.KeySize / 8);
        }

        private void hashXML(string key, string xmlLocation, string outputXML)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(xmlLocation);

                KCCrypt kcc = new KCCrypt(key);

                foreach (XmlNode xNode in xDoc.SelectSingleNode("/WorkflowLicense").ChildNodes)
                {
                    string it = xNode.InnerText;

                    // Encrypt the string to an array of bytes.
                    string encrypted = kcc.Encrypt(it);
                    xNode.InnerText = encrypted;
                    //string decrypted = kcc.Decrypt(encrypted);

                    //Display the original data and the decrypted data.                                        
                }

                xDoc.Save(outputXML);

                //string hashies = XmlHash(xDoc);
                //XmlDehash(hashies);
            }
            catch (Exception ex)
            {

            }
        }

        private void dehashXML(string key, string xmlLocation, string outputXML)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(xmlLocation);

                KCCrypt kcc = new KCCrypt(key);

                foreach (XmlNode xNode in xDoc.SelectSingleNode("/WorkflowLicense").ChildNodes)
                {
                    string it = xNode.InnerText;

                    // Encrypt the string to an array of bytes.
                    string decrypted = kcc.Decrypt(it);
                    xNode.InnerText = decrypted;
                    //string decrypted = kcc.Decrypt(encrypted);

                    //Display the original data and the decrypted data.                                        
                }

                xDoc.Save(outputXML);

            }
            catch (Exception ex)
            {

            }
        }
    }
}