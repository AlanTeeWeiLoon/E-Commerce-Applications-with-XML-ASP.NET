<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout.Master" AutoEventWireup="true" CodeBehind="AdminHome.aspx.cs" Inherits="DECXML_Assignment.AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-12 tm-block-col" style="margin-top: 30px">
        <div class="tm-bg-primary-dark tm-block tm-block-taller tm-block-scroll">
            <h2 class="tm-block-title">Total Sales</h2>
            <table class="table">
                <thead>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <%= strRecords %>
                        </td>
                    </tr>

                </tbody>
            </table>
        </div>
    </div>
    <div class="col-12 tm-block-col" style="margin-top: 30px">
    <div class="tm-bg-primary-dark tm-block tm-block-taller tm-block-scroll">
        <h2 class="tm-block-title">Feedbacks</h2>
        <table class="table">
            <thead>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <%= strFeedbacks %>
                    </td>
                </tr>

            </tbody>
        </table>
    </div>
        </div>
</asp:Content>
