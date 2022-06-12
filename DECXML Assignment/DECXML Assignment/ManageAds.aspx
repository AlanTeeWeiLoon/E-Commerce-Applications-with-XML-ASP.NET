<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ManageAds.aspx.cs" Inherits="DECXML_Assignment.ManageAds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-5">
      <div class="row tm-content-row">
        <div class="col-sm-12 col-md-12 col-lg-8 col-xl-12 tm-block-col">
          <div class="tm-bg-primary-dark tm-block tm-block-products">
            <div class="tm-product-table-container">
              <table class="table table-hover tm-table-small tm-product-table">
                <thead>
                  <tr>
                    <th scope="col">ID</th>
                    <th scope="col">Ads Image</th>
                    <th scope="col">Navigate Url</th>
                    <th scope="col">Alternate Text</th>
                    <th scope="col">KeyWord</th>
                    <th scope="col">Caption</th>
                    <th scope="col">Action</th>
                    <th scope="col">&nbsp;</th>
                  </tr>
                </thead>
                <tbody>
                  <%=fetchAds()%>
                </tbody>
              </table>
            </div>
            <!-- table container -->
            <a
              href="AddAds.aspx"
              class="btn btn-primary btn-block text-uppercase mb-3">Add New Ads</a>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
