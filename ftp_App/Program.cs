using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ftp_App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the object used to communicate with the server.
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://172.16.2.20//DEM//UPLOAD");
            
            //request.Method = WebRequestMethods.Ftp.

            //Set credentials
            request.Credentials = new NetworkCredential("AVR2057", "DAMMK2!");

            //Runs FTP CMD
//            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            //Get result of CMD
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            int fileCount = 0;
            while (reader.Peek() >= 0)
            {
                string filename = reader.ReadLine();
                Console.WriteLine(filename);
                fileCount++;
            }

            Console.WriteLine("\n" + fileCount);
            

            //Console.WriteLine(reader.ReadToEnd());

            //Console.WriteLine("Download Complete, status {0}", response.StatusDescription);



            reader.Close();
            response.Close(); 

        }
    }
}
