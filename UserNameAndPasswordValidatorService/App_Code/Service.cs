using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using Newtonsoft.Json;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class UserObject
{
    public string name { get; set; }
    public string password { get; set; }
}
public class RootJSONObject
{
    public List<UserObject> validUsers { get; set; }
}
public class UserModel
{

}

public class Service : IService
{
    public string SubmitUserCredentials(string name, string password)
    {
        string serverResponse = "Not a valid user!";
        RootJSONObject JSONUsersReturn;

        //string jsonContent;
        //bool isVaiid = false;
        //bool userCreated = false;

        //string passwordHolder = "";

        string pathToSaveFolder = HttpRuntime.AppDomainAppPath + "\\App_Data\\UsersNamesAndPasswords.json";
        
        try
        {
            string JSONAsString = File.ReadAllText(pathToSaveFolder);

            JSONUsersReturn = JsonConvert.DeserializeObject<RootJSONObject>(JSONAsString);

            if (JSONUsersReturn.validUsers.Any())
            {
                foreach (var user in JSONUsersReturn.validUsers)
                {
                    if (name == user.name)
                    {
                        if (password == user.password)
                        {
                            serverResponse = "This is a Valid User";
                        }
                        else
                        {
                            serverResponse = "User Name is correct but password is invalid";
                        }
                    }
                }
            }

        }
        catch (Exception ex)
        {
            serverResponse = ex.Message;
        }

        return serverResponse;
    }
}
