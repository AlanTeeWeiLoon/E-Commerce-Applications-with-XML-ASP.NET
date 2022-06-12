<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="EditAds.aspx.cs" Inherits="DECXML_Assignment.EditAds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container tm-mt-big tm-mb-big">
      <div class="row">
        <div class="col-xl-9 col-lg-10 col-md-12 col-sm-12 mx-auto">
          <div class="tm-bg-primary-dark tm-block tm-block-h-auto">
            <div class="row">
              <div class="col-12">
                <h2 class="tm-block-title d-inline-block">Edit Ads</h2>
                  <asp:LinkButton ID="btn_deleteAds" runat="server" class="tm-product-delete-link" OnClick="btn_deleteAds_Click" OnClientClick="return confirm('Are you sure you want to delete this Ads?');"><i style="align-items:inherit" class="far fa-trash-alt tm-product-delete-icon"></i></asp:LinkButton>
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
                     <asp:TextBox ID="txtNavigateUrl" runat="server" class="form-control validate" TextMode="SingleLine"  ></asp:TextBox>
                  </div>
                    <div class="form-group mb-3">
                    <label
                      for="Caption"
                      >Caption</label
                    >
                     <asp:TextBox ID="txtCaption" runat="server" class="form-control validate" TextMode="SingleLine"  ></asp:TextBox>
                  </div>

                  <div class="row">
                      <div class="form-group mb-3 col-xs-12 col-sm-6">
                          <label
                            for="AlternateText"
                            >AlternateText
                          </label>
                          <asp:TextBox ID="txtAlternateText" runat="server" class="form-control validate" TextMode="SingleLine" ></asp:TextBox>
                        </div>
                        <div class="form-group mb-3 col-xs-12 col-sm-6">
                          <label
                            for="KeyWord"
                            >KeyWord
                          </label>
                            <asp:TextBox ID="txtKeyWord" runat="server" class="form-control validate" TextMode="SingleLine"></asp:TextBox>
                        </div>
                  </div>
                  <asp:Label ID="lblMessage" runat="server" style="font-size: medium;" Font-Bold="True"></asp:Label>
              </div>
               <div class="col-xl-6 col-lg-6 col-md-12 mx-auto mb-4">
                <div class="tm-product-img-dummy mx-auto">
                    <div  class="imgbox">
                    <asp:Image ID="UploadedImage" runat="server"/>
                        </div>
                </div>` 
                <div class="custom-file mt-3 mb-3">
                  <input id="fileInput" type="file" style="display:none;" />
                    <asp:FileUpload ID="fuAdsImg" runat="server" onchange="ImagePreview(this);"/>
                </div>
              </div>
                <script>
                    function ImagePreview(input) {
                        if (input.files && input.files[0]) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('#<%=UploadedImage.ClientID%>').prop('src', e.target.result)
                                        .width()
                                    .height(240);
                                };
                                reader.readAsDataURL(input.files[0]);
                            }
                        }

                </script>
                
              </div>
              
              <div class="col-12">
                  <asp:Button ID="btnEditAds" runat="server" class="btn btn-primary btn-block text-uppercase" Text="Edit Ads" OnClick="btnEditAds_Click" />
              </div>
            </form>
            </div>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
