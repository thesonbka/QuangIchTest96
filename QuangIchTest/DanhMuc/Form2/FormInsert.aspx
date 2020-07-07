<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormInsert.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form2.FormInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</head>
<body>
    <telerik:RadCodeBlock runat="server">
        <script>
            function getRadWindow() {
                debugger;
                if (window.radWindow) {
                    return window.radWindow;
                }
                if (window.frameElement && window.frameElement.radWindow) {
                    return window.frameElement.radWindow;
                }
                return null;
            }
            function onClientClose(arg) {
                debugger;
                getRadWindow().close(arg);
            }
            function CloseAndRebind(args) {
                debugger;
                getRadWindow().BrowserWindow.refreshGrid(args);
                getRadWindow().close();
            }
            function NumberValidation(sender, args) {

                var numberformat = /^[0-9]*$/;
                var currValue = args.Value;

                if (currValue !== '') {
                    if (numberformat.test(currValue) == false) {
                        args.IsValid = false;
                    }
                }
            }

        </script>

    </telerik:RadCodeBlock>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                 <telerik:AjaxSetting AjaxControlID="rcbNhomLop">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbNhomTuoi" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
               

            </AjaxSettings>
        </telerik:RadAjaxManager>
         <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
        <div>
            <div class="container editForm-subject">
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Nhóm lớp <span style="color: red">(*)</span></span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <telerik:RadComboBox ID="rcbNhomLop" runat="server" DataSourceID="objKhoi" DataTextField="TEN" DataValueField="MA" Width="100%"
                                EmptyMessage="Chọn lớp học" CausesValidation="false" AutoPostBack="true" OnSelectedIndexChanged="LoadChangeComboxCapHoc" AllowCustomText="true" Filter="Contains" >
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvKhoi" runat="server" ControlToValidate="rcbNhomLop"
                                CssClass="valid-control" ForeColor="Red" ErrorMessage="Thông tin bắt buộc nhập" Display="Dynamic"
                                SetFocusOnError="true"> </asp:RequiredFieldValidator>
                            <asp:ObjectDataSource ID="objKhoi" runat="server" SelectMethod="GetItems" TypeName="QuangIchTest.DanhMuc.Form2.BindingData" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Nhóm tuổi <span style="color: red">(*)</span></span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <telerik:RadComboBox ID="rcbNhomTuoi" runat="server" DataTextField="TEN" DataValueField="MA" Width="100%"
                                EmptyMessage="Chọn nhóm tuổi" AllowCustomText="true" Filter="Contains">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcbNhomTuoi"
                                CssClass="valid-control" ForeColor="Red" ErrorMessage="Thông tin bắt buộc nhập" Display="Dynamic"
                                SetFocusOnError="true"> </asp:RequiredFieldValidator>
                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetItems" TypeName="QuangIchTest.DanhMuc.Form2.BindingData" />
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Nhập mã :  <span style="color: red">(*)</span></span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <asp:TextBox ID="txtMaLop" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMaLop"
                                ForeColor="Red" ErrorMessage="Tên bắt buộc nhập" Display="Dynamic"
                                SetFocusOnError="true"> 
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Tên :  <span style="color: red">(*)</span></span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTen"
                                ForeColor="Red" ErrorMessage="Tên bắt buộc nhập" Display="Dynamic"
                                SetFocusOnError="true"> 
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Thứ tự hiển thị :</span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <asp:TextBox ID="txtThutu" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:CustomValidator Display="Dynamic" ForeColor="red" runat="server" ID="NumberValidator" EnableClientScript="true"
                                ClientValidationFunction="NumberValidation" ControlToValidate="txtThutu" ErrorMessage="Bạn phải nhập số dương">
                            </asp:CustomValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <label class="col-xs-12 col-sm-4 col-md-4 control-label ">
                        <span class="qi-name-control">Học bán trú</span>
                    </label>
                    <div class="col-xs-12 col-sm-8 col-md-8 ">


                        <asp:CheckBox ID="chkBanTru" Checked='false' runat="server" />
                    </div>
                     <label class="col-xs-12 col-sm-4 col-md-4 control-label ">
                        <span class="qi-name-control">Học 2 buổi 1 ngày</span>
                    </label>
                    <div class="col-xs-12 col-sm-8 col-md-8 ">


                        <asp:CheckBox ID="chk2buoi"   runat="server" AutoPostBack="true" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Điểm trường</span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <telerik:RadComboBox ID="rcbDiemTruong" runat="server" DataTextField="TEN" DataValueField="MA" Width="100%"
                                EmptyMessage="Chọn điểm trường " CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                            </telerik:RadComboBox>


                        </div>
                    </div>
                </div>
                
                <div class="row">

                    <div class="col-md-6"></div>
                    <div class="col-md-6">
                        <div class="form-group editForm-button">
                            <asp:Button ID="btnGhi" OnClick="btn_Save" Text='Cập nhật'
                                runat="server"></asp:Button>
                            &nbsp;
                        <asp:Button ID="btnCancel" Text="Đóng" runat="server" CausesValidation="False"
                            CommandName="Cancel" OnClientClick="onClientClose()"></asp:Button>
                        </div>

                    </div>


                </div>

            </div>
        </div>
    </form>
</body>
</html>
