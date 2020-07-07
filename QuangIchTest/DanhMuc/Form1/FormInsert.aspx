<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormInsert.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form1.FormInsert" %>

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
        

        <div>

            <div class="container editForm-subject">
                <div class="row">
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
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Tên :  <span style="color: red">(*)</span></span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTen"
                                ForeColor="Red" ErrorMessage="Tên môn học bắt buộc nhập" Display="Dynamic"
                                SetFocusOnError="true"> 
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Chọn Cấp học <span style="color: red">(*)</span></span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <telerik:RadComboBox ID="RadComboBox1" runat="server" DataSourceID="objKhoi" DataTextField="TEN" DataValueField="MA" Width="100%"
                                EmptyMessage="Chọn cấp học" AllowCustomText="true" Filter="Contains">
                            </telerik:RadComboBox>
                            <asp:RequiredFieldValidator ID="rfvKhoi" runat="server" ControlToValidate="RadComboBox1"
                                CssClass="valid-control" ForeColor="Red" ErrorMessage="Thông tin bắt buộc nhập" Display="Dynamic"
                                SetFocusOnError="true"> </asp:RequiredFieldValidator>
                            <asp:ObjectDataSource ID="objKhoi" runat="server" SelectMethod="GetItems" TypeName="QuangIchTest.DanhMuc.Form1.BindingData" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Kiểu môn</span>
                        </label>
                        <div class="col-xs-12 col-sm-8 col-md-8">
                            <telerik:RadComboBox ID="rcbKieuMonHoc" runat="server" DataTextField="TEN" DataValueField="MA" Width="100%"
                                EmptyMessage="Chọn cách tính điểm" AllowCustomText="true" Filter="Contains">
                                <Items>
                                    <telerik:RadComboBoxItem Text="Tính điểm" Value="1" />
                                    <telerik:RadComboBoxItem Text="Nhận xét" Value="2" />
                                </Items>
                            </telerik:RadComboBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                            <span class="qi-name-control">Thứ tự :</span>
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
                    <div class="col-md-6"></div>
                    <div class="col-md-6">
                        <div class="form-group editForm-button">
                            <asp:Button ID="btnGhi" OnClick="btn_Save" Text='Thêm'
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
