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
    public string currentFileName = "FileWithoutName";

    public string saveFolderPath = HttpRuntime.AppDomainAppPath + "\\App_Data";
    
    public void SendFileName(string fileName)
    {
        currentFileName = fileName;
    }

    public string SendFileAsStream(Stream fileContents)
    {
        string filePath = String.Format(@"{0}\{1}", saveFolderPath, currentFileName);

        if (currentFileName.Equals("FileWithoutName"))
        {
            filePath += Guid.NewGuid().ToString() + ".txt";
        }
        else
        {
            filePath += currentFileName;
        }

        StreamReader reader = new StreamReader(fileContents);

        var contentString = reader.ReadToEnd();

        File.WriteAllText(filePath, contentString);

        return filePath;
    }

    public string StringToFile(string fileContent)
    {
        string filePath = String.Format(@"{0}\testfile", saveFolderPath);
        
        filePath += Guid.NewGuid().ToString() + ".txt";

        File.WriteAllText(filePath, fileContent);

        return filePath;
    }

}
