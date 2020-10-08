using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    // set a default name for the file
    public static string currentFileName = "FileWithoutName";
    // get the save folder path
    public string saveFolderPath = HttpRuntime.AppDomainAppPath + "\\App_Data";
    
    public void SendFileName(string fileName)
    {
        // change incoming file name
        currentFileName = fileName;
    }

    public string SendFileAsStream(Stream fileContents)
    {
        string filePath = String.Format(@"{0}\{1}", saveFolderPath, currentFileName);

        if (currentFileName.Equals("FileWithoutName"))
        {
            filePath += Guid.NewGuid().ToString() + ".txt";
        }
        // read in the stream sent from the client
        StreamReader reader = new StreamReader(fileContents);

        var contentString = reader.ReadToEnd();
        // create a new file at path location
        File.WriteAllText(filePath, contentString);
        // change file name to default
        currentFileName = "FileWithoutName";

        return filePath;
    }

    public string StringToFile(string fileContent) // used for debugging 
    {
        string filePath = String.Format(@"{0}\testfile", saveFolderPath);
        
        filePath += Guid.NewGuid().ToString() + ".txt";

        File.WriteAllText(filePath, fileContent);

        return filePath;
    }

}
