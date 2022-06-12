<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="AddAds.aspx.cs" Inherits="DECXML_Assignment.AddAds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container tm-mt-big tm-mb-big">
      <div class="row">
        <div class="col-xl-9 col-lg-10 col-md-12 col-sm-12 mx-auto">
          <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
            <div class="row">
              <div class="col-12">
                <h2 class="tm-block-title d-inline-block">Add New Ads</h2>
              </div>
            </div>
            <div class="row tm-edit-product-row">
              <div class="col-xl-6 col-lg-6 col-md-12">
                <form action="" class="tm-edit-product-form">
                  <div class="form-group mb-3">
                    <label
                      for="NavigateUrl"
                      >Navigate Url</label
                    >
                     <asp:TextBox ID="txtNavigateUrl" runat="server" class="form-control validate" TextMode="SingleLine" required="required" ></asp:TextBox>
                  </div>
                    <div class="form-group mb-3">
                    <label
                      for="Caption"
                      >Caption</label
                    >
                     <asp:TextBox ID="txtCaption" runat="server" class="form-control validate" TextMode="SingleLine" required="required" ></asp:TextBox>
                  </div>

                  <div class="row">
                      <div class="form-group mb-3 col-xs-12 col-sm-6">
                          <label
                            for="AlternateText"
                            >AlternateText
                          </label>
                          <asp:TextBox ID="txtAlternateText" runat="server" class="form-control validate" TextMode="SingleLine" required="required" ></asp:TextBox>
                        </div>
                        <div class="form-group mb-3 col-xs-12 col-sm-6">
                          <label
                            for="KeyWord"
                            >KeyWord
                          </label>
                            <asp:TextBox ID="txtKeyWord" runat="server" class="form-control validate" TextMode="SingleLine" required="required"></asp:TextBox>
                        </div>
                  </div>
                  <asp:Label ID="lblMessage" runat="server" style="font-size: medium;" Font-Bold="True"></asp:Label>
              </div>
              <div class="col-xl-6 col-lg-6 col-md-12 mx-auto mb-4">
                <div class="tm-product-img-dummy mx-auto">
                    <div class="imgbox">
                        <img id="output"/>
                    </div> 
                </div>
                <div class="custom-file mt-3 mb-3">
                  <asp:FileUpload ID="fileInput" runat="server" style="display:none;" onchange="loadFile(event)" />
                  <input
                      type="button"
                      class="btn btn-primary btn-block mx-auto"
                      value="UPLOAD Ads IMAGE"
                      onclick="showBrowseDialog();" />
                </div>
                <script>
                    function showBrowseDialog() {
                        var fileuploadctrl = document.getElementById('<%= fileInput.ClientID %>');
                        fileuploadctrl.click();

                    }
                    var loadFile = function (event) {
                        var image = document.getElementById('output');
                        image.src = URL.createObjectURL(event.target.files[0]);
                    };
                </script>
                
              </div>
              
              <div class="col-12">
                  <asp:Button ID="btnAddAds" runat="server" class="btn btn-primary btn-block text-uppercase" Text="Add Ads Now" OnClick="btnAddAds_Click" />
              </div>
            </form>
            </div>
          </div>
        </div>
      </div>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>
</asp:Content>
