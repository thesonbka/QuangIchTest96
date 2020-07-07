<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Popup.Master" AutoEventWireup="true" CodeBehind="FormInsert.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form3.FormInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <telerik:RadCodeBlock runat="server">
        <script>
            function PhoneNumberValidation(sender, args) {
                var vnf_regex = /((09|03|07|08|05)+([0-9]{8})\b)/g;
                var currValue = args.Value;
                if (currValue !== '') {
                    if (vnf_regex.test(currValue) == false) {
                        args.IsValid = false;
                    }
                }
            }

            function EmailValidation(sender, args) {
                var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
                var currValue = args.Value;
                if (currValue !== '') {
                    if (mailformat.test(currValue) == false) {
                        args.IsValid = false;
                    }
                }
            }

            // WebsiteValidation
            function WebsiteValidation(sender, args) {
                var patternUrl = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/;
                var currValue = args.Value;
                if (currValue !== '') {
                    if (patternUrl.test(currValue) == false) {
                        args.IsValid = false;
                    }
                }
            }


        </script>

    </telerik:RadCodeBlock>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="row" style="padding-top: 10px;">
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Mã <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtMa" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMa"
                        ForeColor="Red" ErrorMessage="Mã môn học bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>

                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Email</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtMail" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:CustomValidator Display="Dynamic" ForeColor="red" runat="server" ID="EmailValidator" EnableClientScript="true"
                        ClientValidationFunction="EmailValidation" ControlToValidate="txtMail" ErrorMessage="Email không đúng định dạng">
                    </asp:CustomValidator>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Họ tên <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHoTen"
                        ForeColor="Red" ErrorMessage="Tên bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Điện thoại <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:CustomValidator Display="Dynamic" ForeColor="red" runat="server" ID="CustomValidator1" EnableClientScript="true"
                        ClientValidationFunction="PhoneNumberValidation" ControlToValidate="txtDienThoai" ErrorMessage="Điện thoại không đúng định dạng">
                    </asp:CustomValidator>

                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Ngày sinh <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Dân tộc <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Trạng thái CB <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Tôn giáo </span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">CMTNN/TCC <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Quê quán</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                </div>
            </div>
        </div>



    </div>


</asp:Content>
