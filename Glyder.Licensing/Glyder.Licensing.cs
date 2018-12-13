using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Glyder.Licensing.Models;
using System.Management;
using Glyder.Configuration;
using Glyder.Configuration.Models;
using System.Data.SqlClient;
using System.IO;

namespace Glyder.Licensing
{
    public class GlyderLicensing
    {
        private string glyderConfigurationConnectionstring;
        private GlyderGlobalConfiguration ggc;
        private RijndaelManaged myRijndael = new RijndaelManaged();
        public string key;
        private int iterations;
        private byte[] salt;

        public GlyderLicensing()
        {
            GlyderConfiguration gc = new GlyderConfiguration();
            ggc = gc.getGlobalConfig();

            //glyderConfigurationConnectionstring = ggc.connectionstrings.glyderConfigurationConnectionstring;
            //DEBUG
            glyderConfigurationConnectionstring = "Server=SRV-08-DESIGN\\SQLEXPRESS; Database=GlyderConfiguration; User Id=FS; Password=$RRMPJ!; ";

            string fingerPrint = FingerPrint.Value();
            //string password =generateKeyBasedOnCPU();
            key = fingerPrint;
            myRijndael.BlockSize = 128;
            myRijndael.KeySize = 256;
            myRijndael.IV = HexStringToByteArray("6c462c84ea324938b664f4478bfd9461");

            myRijndael.Padding = PaddingMode.PKCS7;
            myRijndael.Mode = CipherMode.CBC;
            iterations = 1000;
            salt = System.Text.Encoding.UTF8.GetBytes("KCcryptography123");
            myRijndael.Key = GenerateKey(key);
        }

        public xmlResult getLicenseXMLFromGlyderDatabase()
        {
            xmlResult xr = new xmlResult();

            try
            {
                using (SqlConnection con = new SqlConnection(glyderConfigurationConnectionstring))
                {
                    string selectQuery = "SELECT Configuration FROM tblConfigurations WHERE [ApplicationID] = 0 AND [CustomerGuid] = '" + ggc.customerGuid.ToString() + "'";

                    string licenseXMLString = string.Empty;
                    using (SqlCommand com = new SqlCommand(selectQuery, con))
                    {
                        con.Open();
                        var licenseXMLObject = com.ExecuteScalar();
                        con.Close();
                        if (licenseXMLObject != null)
                        {
                            licenseXMLString = licenseXMLObject.ToString();
                        }
                        if (!string.IsNullOrWhiteSpace(licenseXMLString))
                        {
                            xmlResult xmlLicenseResult = decryptXML(licenseXMLString);
                            {
                                if (xmlLicenseResult.success)
                                {
                                    xr.success = true;
                                    xr.xml = xmlLicenseResult.xml;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                xr.exception = ex;
                xr.success = false;
            }
            return xr;
        }

        public Result createNewLicense(glyderLicense gl)
        {
            

            Result createLicenseRes = new Result();
            try
            {
                if (ggc.loaded)
                {
                    xmlResult insertLicenseResult = encryptXML(@"<GlyderLicense>
                      <glyderStateServiceLicense>
                        <applicationID>1</applicationID>
                        <active>" + gl.glyderStateServiceLicense.active.ToString().ToLower() + @"</active>
                        <expirationDate>" + gl.glyderStateServiceLicense.expirationDate.ToString("o") + @"</expirationDate>
                      </glyderStateServiceLicense>
                      <glyderSMILicense>
                        <applicationID>2</applicationID>
                        <active>" + gl.glyderSMILicense.active.ToString().ToLower() + @"</active>
                        <expirationDate>" + gl.glyderSMILicense.expirationDate.ToString("o") + @"</expirationDate>
                      </glyderSMILicense>
                      <glyderWorkflowLicense>
                        <applicationID>3</applicationID>
                        <active>" + gl.glyderWorkflowLicense.active.ToString().ToLower() + @"</active>
                        <expirationDate>" + gl.glyderWorkflowLicense.expirationDate.ToString("o") + @"</expirationDate>
                      </glyderWorkflowLicense>
                      <glyderWorkspaceLicense>
                        <applicationID>4</applicationID>
                        <active>" + gl.glyderWorkspaceLicense.active.ToString().ToLower() + @"</active>
                        <expirationDate>" + gl.glyderWorkspaceLicense.expirationDate.ToString("o") + @"</expirationDate>
                      </glyderWorkspaceLicense>                      
                    </GlyderLicense>");

                    if (insertLicenseResult.success)
                    {
                        string createLicenseQuery = "INSERT INTO tblConfigurations (ApplicationID, Version, [Configuration], CustomerGuid) VALUES(0, 0, '" + insertLicenseResult.xml.OuterXml + "', '" + ggc.customerGuid.ToString() + @"')";

                        using (SqlConnection con = new SqlConnection(glyderConfigurationConnectionstring))
                        {
                            using (SqlCommand com = new SqlCommand(createLicenseQuery, con))
                            {
                                con.Open();
                                createLicenseRes.success = (int)com.ExecuteNonQuery() > 0;
                                con.Close();
                            }
                        }
                    }
                }
                else
                {
                    createLicenseRes.success = false;
                    createLicenseRes.exception = new Exception("Glyder Global Configuration not found");
                }
            }
            catch (Exception ex)
            {
                createLicenseRes.success = false;
                createLicenseRes.exception = ex;
            }
            return createLicenseRes;
        }

        public glyderLicense getGlyderLicense()
        {
            glyderLicense gl = new glyderLicense();
            try
            {
                xmlResult xr = getLicenseXMLFromGlyderDatabase();
                if (xr.success)
                {
                    //XmlDocument glyderLicenseXML = new XmlDocument();
                    //glyderLicenseXML.Load("c:\\Glyder.Licensing\\License.xml");
                    GlyderStateServiceLicense gsl = new GlyderStateServiceLicense();

                    using (XmlReader reader = new XmlNodeReader(xr.xml))
                    {
                        var serializer = new XmlSerializer(typeof(glyderLicense), new XmlRootAttribute("GlyderLicense"));
                        gl = (glyderLicense)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return gl;
        }

        public Result updateGlyderLicense(glyderLicense gl)
        {
            Result res = new Result();
            res.success = false;


            try
            {
                using (var sww = new StringWriter())
                {
                    using (XmlWriter writer = XmlWriter.Create(sww))
                    {
                        var serializer = new XmlSerializer(typeof(glyderLicense), new XmlRootAttribute("GlyderLicense"));

                        serializer.Serialize(writer, gl);
                        string xml = sww.ToString(); // Your XML
                        xmlResult xr = encryptXML(xml);

                        if (xr.success)
                        {
                            string updateQuery = "UPDATE tblConfigurations SET [Configuration] = @config WHERE ApplicationID = 0 AND Version = 0";
                            using (SqlConnection con = new SqlConnection(glyderConfigurationConnectionstring))
                            {
                                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                                {
                                    cmd.Parameters.AddWithValue("@config", xr.xml.OuterXml);
                                    con.Open();
                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        res.success = true;
                                    }
                                    con.Close();
                                }
                            }
                        }
                        else
                        {
                            res.exception = xr.exception;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                res.exception = ex;
            }
            return res;
        }


        public string encrypt(string strPlainText)
        {
            byte[] strText = new System.Text.UTF8Encoding().GetBytes(strPlainText);
            ICryptoTransform transform = myRijndael.CreateEncryptor();
            byte[] cipherText = transform.TransformFinalBlock(strText, 0, strText.Length);
            return Convert.ToBase64String(cipherText);
        }

        public string decrypt(string encryptedText)
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

        private string generateKeyBasedOnCPU()
        {
            string key = "KCN_";

            try
            {
                string cpuInfo = string.Empty;
                ManagementClass mc = new ManagementClass("win32_processor");
                ManagementObjectCollection moc = mc.GetInstances();

                foreach (ManagementObject mo in moc)
                {
                    if (string.IsNullOrWhiteSpace(cpuInfo))
                    {
                        //Get only the first CPU's ID
                        cpuInfo = mo.Properties["processorID"].Value.ToString();
                        break;
                    }
                }

                key += cpuInfo;
            }
            catch { }

            return key;
        }


        public xmlResult encryptXML(string xmlString)
        {
            xmlResult xr = new xmlResult();

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xmlString);

                XmlNode xNode = xDoc.DocumentElement;
                string it = xNode.InnerXml;
                string encrypted = encrypt(it);
                xNode.InnerXml = encrypted;
                xr.success = true;
                xr.xml = xDoc;
            }
            catch (Exception ex)
            {
                xr.success = false;
                xr.exception = ex;
            }
            return xr;
        }

        public xmlResult decryptXML(string xmlString)
        {
            xmlResult xr = new xmlResult();

            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(xmlString);

                XmlNode xNode = xDoc.DocumentElement;

                string it = xNode.InnerXml;

                string decrypted = decrypt(it);
                xNode.InnerXml = decrypted;

                xr.success = true;
                xr.xml = xDoc;

            }
            catch (Exception ex)
            {
                xr.success = false;
                xr.exception = ex;
            }

            return xr;
        }

        public bool checkifLicenseExists()
        {
            Boolean exists = false;
            try
            {
                string selectQuery = "SELECT COUNT([Configuration]) FROM [tblConfigurations] WHERE [ApplicationID] = 0";
                using (SqlConnection con = new SqlConnection(glyderConfigurationConnectionstring))
                {
                    using (SqlCommand com = new SqlCommand(selectQuery, con))
                    {
                        con.Open();
                        exists = (int)com.ExecuteScalar() > 0;
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return exists;
        }

        public bool deleteLicense()
        {
            Boolean exists = false;
            try
            {
                string selectQuery = "DELETE FROM [tblConfigurations] WHERE [ApplicationID] = 0";
                using (SqlConnection con = new SqlConnection(glyderConfigurationConnectionstring))
                {
                    using (SqlCommand com = new SqlCommand(selectQuery, con))
                    {
                        con.Open();
                        exists = (int)com.ExecuteNonQuery() > 0;
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return exists;
        }
    }
}