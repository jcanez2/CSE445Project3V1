<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE445Project3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Try It GUI</h1>
        <p class="lead">Tool To Try out the Different Services</p>
        <br/>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Weather Forecaster</h2>
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
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
