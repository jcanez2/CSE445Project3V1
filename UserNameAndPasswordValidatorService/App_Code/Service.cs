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

//=================JSON Models============================
public class UserObject
{
    public string name { get; set; }
    public string password { get; set; }
}
public class RootJSONObject
{
    public List<UserObject> validUsers { get; set; }
}
//=========================================================


public class Service : IService
{
    public string SubmitUserCredentials(string name, string password)
    {
        string serverResponse = "Not a valid user!"; // default server response
        RootJSONObject JSONUsersReturn; // create JSON object to catch converted JSON

        // create credential json file path
        string pathToSaveFolder = HttpRuntime.AppDomainAppPath + "\\App_Data\\UsersNamesAndPasswords.json";
        
        try
        {
            string JSONAsString = File.ReadAllText(pathToSaveFolder); // get the contents of the file
            // convert file contents to object
            JSONUsersReturn = JsonConvert.DeserializeObject<RootJSONObject>(JSONAsString);
            // if the  list of user in the object has values
            if (JSONUsersReturn.validUsers.Any())
            {
                foreach (var user in JSONUsersReturn.validUsers) // iterate through users
                {
                    if (name == user.name) // check to see if the user in in the list of valid users
                    {
                        if (password == user.password) // check to see if user password matches
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
            serverResponse = ex.Message; // handle exception
        }

        return serverResponse;
    }
}
