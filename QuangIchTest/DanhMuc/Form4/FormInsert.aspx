<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Popup.Master" AutoEventWireup="true" CodeBehind="FormInsert.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form4.FormInsert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rcbTinh">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbHuyen" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rcbXa" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbHuyen">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbXa" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbNhomLop">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbLop" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
    <div class="row" style="padding-top: 10px;">
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Nhóm lớp <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbNhomLop" runat="server" DataSourceID="objNhomLop" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn nhóm lớp" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains" OnSelectedIndexChanged="LoadChangeLopHoc">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rcbNhomLop"
                        ForeColor="Red" ErrorMessage="Nhóm lớp bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                    <asp:ObjectDataSource ID="objNhomLop" runat="server" SelectMethod="getNhomLop" TypeName="DataAccess.Repository.HocSinhRepository" />
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Lớp <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbLop" runat="server" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn lớp" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rcbLop"
                        ForeColor="Red" ErrorMessage="Lớp bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div style="clear: both"></div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Mã <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">

                    <asp:TextBox ID="txtMa" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMa"
                        ForeColor="Red" ErrorMessage="Mã học sinh bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Tỉnh/ Thành phố <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbTinh" runat="server" DataSourceID="objTinh" OnSelectedIndexChanged="LoadHuyen" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="objTinh" runat="server" SelectMethod="getTinh" TypeName="DataAccess.Repository.NHANSURepository" />
                    <telerik:RadComboBox ID="rcbHuyen" runat="server" OnSelectedIndexChanged="LoadXa" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage=" Quận/ Huyện" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <telerik:RadComboBox ID="rcbXa" runat="server" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Xã / Phường" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>

                </div>
            </div>
        </div>
        <div style="clear: both"></div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Họ tên <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtHoTen"
                        ForeColor="Red" ErrorMessage="Mã học sinh bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>

                </div>
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Ngày sinh <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadDatePicker ID="dbNgaySinh" runat="server"></telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="dbNgaySinh"
                        ForeColor="Red" ErrorMessage="Họ tên bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Giới tính <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbGioiTinh" runat="server" DataSourceID="objGioiTinh" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn giới tính" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rcbGioiTinh"
                        ForeColor="Red" ErrorMessage="Giới tính bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                    <asp:ObjectDataSource ID="objGioiTinh" runat="server" SelectMethod="getGioiTinh" TypeName="DataAccess.Repository.NHANSURepository" />
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Nơi sinh</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtNoiinh" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Trạng thái HS <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbTrangThaiHS" runat="server" OnSelectedIndexChanged="rcbTrangThaiHS_SelectedIndexChanged" DataSourceID="objTrangThai" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn trạng thái" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rcbTrangThaiHS"
                        ForeColor="Red" ErrorMessage="Trạng thái bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                    <asp:ObjectDataSource ID="objTrangThai" runat="server" SelectMethod="getTrangThaiHS" TypeName="DataAccess.Repository.HocSinhRepository" />
                </div>
            </div>
        </div>

       

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Dân tộc <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbDanToc" runat="server" DataSourceID="objDanToc" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn trạng thái" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rcbDanToc"
                        ForeColor="Red" ErrorMessage="Dân tộc bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                     <asp:ObjectDataSource ID="objDanToc" runat="server" SelectMethod="getDanToc" TypeName="DataAccess.Repository.NHANSURepository" />
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Quốc tịch </span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbQuocTich" runat="server" DataSourceID="objQuocTich" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn trạng thái" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="objQuocTich" runat="server" SelectMethod="getQuocTich" TypeName="DataAccess.Repository.HocSinhRepository" />
                </div>
            </div>
        </div>

        <div style="clear: both"></div>
        <div class="col-md-6"></div>
        <div class="col-md-6">
            <div class="form-group editForm-button">
                <asp:Button ID="btnGhi" Text='Cập nhật'
                    runat="server" OnClick="btn_Save"></asp:Button>
                &nbsp;
                        <asp:Button ID="btnCancel" Text="Đóng" runat="server" CausesValidation="False"
                            CommandName="Cancel" OnClientClick="onClientClose()"></asp:Button>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="profile-detail-wrapper">
            <telerik:RadTabStrip CausesValidation="false" RenderMode="Classic" runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0" CssClass="qi-panel-search">
                <Tabs>
                    <telerik:RadTab Value="1" Text="I. Thông tin cá nhân" Width="200px"></telerik:RadTab>
                    <telerik:RadTab Value="2" Text="II. Thông tin liên hệ gia đình" Width="300px"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <div class="tab-content">
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
                    <telerik:RadPageView runat="server" ID="RadPageView1">
                        <div class="tab-content-wrapper">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Khu vực</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbLoaiKhuVuc" runat="server" DataSourceID="objKhuVuc" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                         <asp:ObjectDataSource ID="objKhuVuc" runat="server" SelectMethod="getKhuVuc" TypeName="DataAccess.Repository.HocSinhRepository" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        Học 2 buổi
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:CheckBox ID="chkIsHoc2Buoi" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        Có cha dân tộc
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:CheckBox ID="chkIsChaDT" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        Có mẹ dân tộc
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:CheckBox ID="chkIsMeDT" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        Trẻ lớp bán trú
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:CheckBox ID="chkhslopbantru" runat="server" AutoPostBack="true" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        Học bán trú
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbBanTru" runat="server" EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains" DataSourceID="objHocBanTru"
                                            DataTextField="TEN" DataValueField="MA" Width="100%">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objHocBanTru" runat="server" SelectMethod="getHocBantru" TypeName="DataAccess.Repository.HocSinhRepository" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        Loại khuyết tật
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbKhuyetTat" runat="server" EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains" DataSourceID="objkhuyetTat"
                                            DataTextField="TEN" DataValueField="MA" Width="100%">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objkhuyetTat" runat="server" SelectMethod="getLoaiKhuyetTat" TypeName="DataAccess.Repository.HocSinhRepository" />
                                    </div>
                                </div>
                            </div>

                             <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        Đối tượng chinh sách
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbDoituongCS" runat="server" EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains" DataSourceID="objDoiTuongCS"
                                            DataTextField="TEN" DataValueField="MA" Width="100%">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objDoiTuongCS" runat="server" SelectMethod="getDoiTuongChinhSach" TypeName="DataAccess.Repository.HocSinhRepository" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView2">
                        <div class="tab-content-wrapper">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Tên cha</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtCha" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Tên mẹ</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtMe" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Tên người đỡ đầu</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtNguoiDoDau" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Nghề nghiệp cha</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtNgheNghiepCha" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Nghề nghiệp mẹ</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtNgheNghiepMe" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Nghề nghiệp người Đ.Đầu</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtNgheNgiemDoDau" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </telerik:RadPageView>

                </telerik:RadMultiPage>
            </div>
        </div>
    </div>

</asp:Content>
