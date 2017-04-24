using System;
using DMMLib;
using System.IO;
using Newtonsoft.Json;

namespace DualMeetManager.Service.Saving
{
    /// <summary>
    /// Implementation for saving objects as Json files
    /// </summary>
    public class SavingJsonSvcImpl : ISavingSvc
    {
        /// <summary>
        /// Implementation for saving a Meet object as a JSON object
        /// </summary>
        /// <param name="filePath">filename for the Meet</param>
        /// <param name="meetToSave">Meet object to save</param>
        /// <returns>boolean that tells the user whether or not the Meet was succcessfully saved or not</returns>
        public bool saveMeet(string filePath, Meet meetToSave)
        {
            bool didSave = true;
            TextWriter writer = null;
            try
            {
                //Serialize object with json.net
                string jsonData = JsonConvert.SerializeObject(meetToSave, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                });

                writer = new StreamWriter(filePath, false);
                writer.Write(jsonData);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error: file not found - " + filePath);
                Console.WriteLine(ioe.ToString());
                Console.Write(ioe.StackTrace);
                didSave = false;
            }
            catch (JsonWriterException jwe)
            {
                Console.WriteLine("Error: JsonWriterException - " + filePath);
                Console.WriteLine(jwe.ToString());
                Console.Write(jwe.StackTrace);
            }
            catch (JsonSerializationException jse)
            {
                Console.WriteLine("Error: JsonSerializationException - " + filePath);
                Console.WriteLine(jse.ToString());
                Console.Write(jse.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Undefined - " + filePath);
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                didSave = false;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
            
            return didSave;
        }

        /// <summary>
        /// Implementation for opening a saved Meet object JSON file
        /// </summary>
        /// <param name="fileName">filename for the Meet to be open</param>
        /// <returns>Opened Meet</returns>
        public Meet openMeet(string fileName)
        {
            Meet myMeet;
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // Read the stream to a string, and write the string to the console.
                    string line = sr.ReadToEnd();
                    //Console.WriteLine(line);

                    myMeet = JsonConvert.DeserializeObject<Meet>(line);
                }
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.ToString());
                Console.Write(fnfe.StackTrace);
                return null;
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.ToString());
                Console.Write(ioe.StackTrace);
                return null;
            }
            catch (JsonReaderException jre)
            {
                Console.WriteLine("Error: JsonReaderException");
                Console.WriteLine(jre.ToString());
                Console.Write(jre.StackTrace);
                return null;
            }
            catch (JsonSerializationException jse)
            {
                Console.WriteLine("Error: JsonSerializationException");
                Console.WriteLine(jse.ToString());
                Console.Write(jse.StackTrace);
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.Write(e.StackTrace);
                return null;
            }
            Console.WriteLine("Leaving openMeet");
            //Console.WriteLine(myMeet.ToString());
            return myMeet;
        }
    }
}
