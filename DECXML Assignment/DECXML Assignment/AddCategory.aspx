<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="DECXML_Assignment.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container tm-mt-big tm-mb-big">
      <div class="row">
        <div class="col-xl-9 col-lg-10 col-md-12 col-sm-12 mx-auto">
          <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
            <div class="row">
              <div class="col-12">
                <h2 class="tm-block-title d-inline-block">Add Category</h2>
              </div>
            </div>
            <div class="row tm-edit-product-row">
              <div class="col-xl-6 col-lg-6 col-md-12">
                <form action="" class="tm-edit-product-form">
                  <div class="form-group mb-3">
                    <label
                      for="name"
                      >Category Name
                    </label>
                    <asp:TextBox ID="txtCategoryName" style="width:210%" runat="server" class="form-control validate" TextMode="SingleLine" required="required"></asp:TextBox>
                  </div>
                  <div class="form-group mb-3">
                    <label
                      for="description"
                      >Category Description</label
                    >
                     <asp:TextBox ID="txtCategoryDescription" style="width:210%" runat="server" class="form-control validate" TextMode="MultiLine" rows="3" required="required"></asp:TextBox>
                  </div>
                   <asp:Label ID="lblMessage" runat="server" style="font-size: medium;" Font-Bold="True"></asp:Label>
              </div>          
            </div>             
              <div class="col-12">
                  <asp:Button ID="btnAddCategory" runat="server" class="btn btn-primary btn-block text-uppercase" Text="Add New Category" OnClick="btnAddCategory_Click" />
              </div>
            </form>
            </div>
          </div>
        </div>
      </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
</asp:Content>
