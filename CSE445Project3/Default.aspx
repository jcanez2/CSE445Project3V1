<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445Project3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Try It GUI</h1>
        <p class="lead">Tool To Try out the Different Services</p>
        <br/>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Weather Forecaster Enter Zip</h2>
            <p>
                <br/>
                <asp:Label ID="labLocation" runat="server" Text="Location"></asp:Label>
                <br/>
                <asp:Label ID="labWeather1" runat="server" Text="Weather Info"></asp:Label>
                <br/>
                <asp:Label ID="labWeather2" runat="server" Text="Weather Info"></asp:Label>
                <br/>
                <asp:Label ID="labWeather3" runat="server" Text="Weather Info"></asp:Label>
                <br/>
                <asp:Label ID="labWeather4" runat="server" Text="Weather Info"></asp:Label>
                <br/>
                <asp:Label ID="labWeather5" runat="server" Text="Weather Info"></asp:Label>
                <br/>
                <asp:TextBox ID="txtWeather" runat="server">85281</asp:TextBox>
                <br/>
                <asp:Button ID="btnWeather" runat="server" Text="Update Weather" OnClick="btnWeather_Click" />
            </p>
            <br/>
        </div>
        <div class="col-md-4">
            <h2>Solar Index</h2>
            <p>
                <asp:Label ID="labSolarPromt" runat="server" Text="Solar Index:"></asp:Label>
                <br/>
                <asp:Label ID="labSolarIndex" runat="server" Text="0"></asp:Label>

            </p>
            <br/>
            <p>
                Annual Sunshine index 1-2 (low), 6-7 (high), 11+ (extreme). Enter a latitude and longitude to find the value of your desired area.
            </p>
            <p>
                Washington DC : 38.9, -77.1&nbsp;&nbsp; New York: 40.7, -73.9&nbsp;&nbsp;&nbsp; Los Angeles : 33.9, -118.4</p>
            <p>
                <br/>
               
                <asp:TextBox ID="txtbLat" runat="server">33.45</asp:TextBox>
&nbsp;<asp:Label ID="labLatitude" runat="server" Text="Latitude"></asp:Label>
                <br/>
                
                &nbsp;<asp:TextBox ID="txtbLong" runat="server">-112.07</asp:TextBox>
                <asp:Label ID="labLongitude" runat="server" Text="Longitude"></asp:Label>
                <br/>
                <asp:Button ID="btnSunShine" runat="server" Text="Get SunShine Index" OnClick="btnSunShine_Click" />
                <br/>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Saved User Credentials on Server Validate Against Entry</h2>
            <p>
                Enter A User Name and Password they will be saved and reference if you wish to review login later.
            </p>
            <p>
                Valid Entries (UserName, Password): (guest, password1), (user, password2), (super, password3)</p>
            <asp:TextBox ID="txtUserName" runat="server">UserName</asp:TextBox>
            <asp:Label ID="labUserName" runat="server" Text="Enter User Name"></asp:Label>
            <br/>
            <p>
                <asp:TextBox ID="txtPassword" runat="server">Password</asp:TextBox>
                <asp:Label ID="labPassword" runat="server" Text="Enter Password"></asp:Label>
                <br/>

            </p>
            <asp:Button ID="btnCredentials" runat="server" Text="Submit" OnClick="btnCredentials_Click" />
            <br/>
            <p>
                <asp:Label ID="labUserPrompt" runat="server" Text="Response Message:"></asp:Label>
            </p>
            <p>

                <asp:Label ID="labResponseMessage" runat="server" Text="N/A"></asp:Label>

            </p>
            <br/>
        </div>
        <div class="col-md-4">
            <h2>Store Text File</h2>
            <p>
                Upload Text File to Server
            </p>
            <p>
                <asp:Label ID="labReturnPath" runat="server" Text="Uploaded File Path"></asp:Label>
            </p>
            Upload .txt file only
            <br/>
            <p>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </p>
            <p>
                <asp:Button ID="btnUpload" runat="server" Text="Upload" />
                <br/>
            </p>
            <br/>
        </div>
    </div>

</asp:Content>
