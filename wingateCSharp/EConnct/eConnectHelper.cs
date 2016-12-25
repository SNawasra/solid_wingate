using System;
using Microsoft.Dynamics.GP.eConnect;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Dynamics.GP.eConnect.Serialization;

namespace wingateCSharp.EConnct
{
    class EConnectHelper
    {
        public static int DocumentBuilder(string connectionString)
        {
            var docNumbers = new GetNextDocNumbers();
            return Convert.ToInt32(docNumbers.GetNextGLJournalEntryNumber(IncrementDecrement.Increment, connectionString));
        }

        public static string GenerateDistributionRefrence(wingateSchema input)
        {
            string distRef = "";
            if (input.CardholderLastName.Length < 6)
                distRef = input.CardholderLastName;
            else
                distRef = input.CardholderLastName.Substring(0, 5);

            distRef = distRef + ";";

            if (input.SupplierName.Length < 6)
                distRef = input.SupplierName;
            else
                distRef = input.SupplierName.Substring(0, 5);

            return $"{distRef};{input.TransactionNotes}";
        }

        public static MemoryStream XMLSerialize(eConnectType eConnect) {
            var memoryStream = new MemoryStream();
            try
            {
                var xmlTextWriter = new XmlTextWriter(memoryStream, System.Text.Encoding.UTF8);
                var serializer = new XmlSerializer(eConnect.GetType());
                serializer.Serialize(xmlTextWriter, eConnect);
                memoryStream.Position = 0L;
                //writer.Close();               
            }
            catch (Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
            return memoryStream;
        }

        public static bool TryeConnectEntry(MemoryStream memoryStream, string connectionString, out string statusMessage) {
            var eConnect = new eConnectMethods();
            var myXmlDoc = new XmlDocument();

            try
            {
                try
                {
                    myXmlDoc.Load(memoryStream);
                    var eConnectProcessInfoOuk2tgoing = myXmlDoc.SelectSingleNode("//Outgoing");
                    statusMessage = eConnect.CreateTransactionEntity(connectionString, myXmlDoc.OuterXml);
                    return true;
                }
                catch (Exception ex)
                {
                    statusMessage = ex.Message.ToString();
                    return false;
                }
                //let x =  errorM            
            }
            finally
            {
                eConnect.Dispose();
            }
        }
    }
}
