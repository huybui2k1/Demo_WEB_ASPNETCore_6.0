<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ExampleWAD01._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<main > 
        <div>       
             <section class="col-md-12" aria-labelledby ="gettingStartedTille">
            <div class="form-body"> 
                <%--<div class--%>
                <p>     
                   <%-- <asp:Label ID=""--%>

                </p>
            </div>
            
           
        </section>

        </div>
        

    </main>--%>
       

    <div>   
        <%  
            XElement xelementEmployee = XElement.Load(@"E:\TAILIEU_APTECH\ASP_NET_MVC\WAD1808\ExampleWAD01\Employee.xml");
            var result = from list in xelementEmployee.Elements("Employee")
                         where (string)list.Element("Emplocation") == "VietNam"
                         select list;
            foreach(XElement xEle in result)
            {
                %>
        <% =xEle%>
        <%}
     %>
    </div>
</asp:Content>
