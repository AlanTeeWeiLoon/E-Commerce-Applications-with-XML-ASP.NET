<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="ManageProduct.aspx.cs" Inherits="DECXML_Assignment.ManageProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-5">
      <div class="row tm-content-row">
        <div class="col-sm-12 col-md-12 col-lg-8 col-xl-12 tm-block-col">
          <div class="tm-bg-primary-dark tm-block tm-block-products">
            <div class="tm-product-table-container">
              <table class="table table-hover tm-table-small tm-product-table">
                <thead>
                  <tr>
                    <th scope="col">ID</th>
                    <th scope="col">PRODUCT NAME</th>
                    <th scope="col">PRODUCT DESCRIPTION</th>
                    <th scope="col">PRODUCT CATEGORY</th>
                    <th scope="col">PRODUCT PRICE</th>
                    <th scope="col">PRODUCT STOCK</th>
                    <th scope="col">PRODUCT IMAGE</th>
                    <th scope="col">Action</th>
                    <th scope="col">&nbsp;</th>
                  </tr>
                </thead>
                <tbody>
                  <%=fetchProduct()%>
                </tbody>
              </table>
            </div>
            <!-- table container -->
            <a
              href="AddProduct.aspx"
              class="btn btn-primary btn-block text-uppercase mb-3">Add new product</a>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
