using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{
    [OperationContract]
	void SendFileName(string fileName);

    [OperationContract]
    string SendFileAsStream(Stream fileContents);

    [OperationContract]
    string StringToFile(string fileContent);
}

