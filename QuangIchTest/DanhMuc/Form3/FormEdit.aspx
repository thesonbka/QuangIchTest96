<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Popup.Master" AutoEventWireup="true" CodeBehind="FormEdit.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form3.FormEdit" %>

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

            function rcbHinhThucHopDongOnClientSelectedIndexChanged(sender, eventArgs) {
                setValidTaskHinhThucHopDong();
            }
            function rcbLoaiCBOnClientSelectedIndexChanged(sender, eventArgs) {
                setValidTaskPhuCapChucVuLanhDao();
            }
            function rcbNhomCBOnClientSelectedIndexChanged(sender, eventArgs) {
                setValidTask();
            }

            function rcbNgoaiNguOnClientSelectedIndexChanged(sender, eventArgs) {
                setValidTask1();
            }

            function rcbTrinhDoDaoTaoNgoaiNguOnClientSelectedIndexChanged(sender, eventArgs) {
                setValidTask1();
            }

            function rcbNhomCChiNNguOnClientSelectedIndexChanged(sender, eventArgs) {
                setValidTask1();
            }

            function rcbLoaiCChiNNguOnClientSelectedIndexChanged(sender, eventArgs) {
                setValidTask1();
            }

            function rcbKhungNLucNNguOnClientSelectedIndexChanged(sender, eventArgs) {
                setValidTask1();
            }
            function pageLoad() {
                setValidTask();
                setValidTask1();
                setValidTaskHinhThucHopDong();
                setValidTaskPhuCapChucVuLanhDao();
            }
            function setValidTask1() {
               <%-- var maNN = $find("<%= rcbNgoaiNgu.ClientID%>");
                 var tdNN = $find("<%= rcbTrinhDoDaoTaoNgoaiNgu.ClientID%>");
                 var nhomNN = $find("<%= rcbNhomCChiNNgu.ClientID%>");
                 var loaiNN = $find("<%= rcbLoaiCChiNNgu.ClientID%>");
                 var khungNN = $find("<%= rcbKhungNLucNNgu.ClientID%>");

                $('.index-relate-g1, .index-relate-g2').removeClass('valid-task');
                if (maNN != null) {
                    var itemNN = maNN.get_selectedItem();
                    if (itemNN != null && itemNN.get_value() != '') {
                        $('.index-relate-g1, .index-relate-g2').addClass('valid-task');

                        if (tdNN != null) {
                            var itemTDNN = tdNN.get_selectedItem();
                            if (itemTDNN != null && itemTDNN.get_value() != '') {
                                $('.index-relate-g2').removeClass('valid-task');
                                $('.index-relate-g1').addClass('valid-task');
                            }
                        }

                        if (nhomNN != null && loaiNN != null && khungNN != null) {
                            var itemNhomNN = nhomNN.get_selectedItem();
                            var itemLoaiNN = loaiNN.get_selectedItem();
                            var itemKhungNN = khungNN.get_selectedItem();

                            if ((itemNhomNN != null && itemNhomNN.get_value() != '') ||
                                (itemLoaiNN != null && itemLoaiNN.get_value() != '') ||
                                (itemKhungNN != null && itemKhungNN.get_value() != '')) {
                                $('.index-relate-g1').removeClass('valid-task');
                                $('.index-relate-g2').addClass('valid-task');
                            }
                        }
                    }
                }--%>
            }

            function setValidTask() {
               <%-- var nhomCB = $find("<%= rcbNhomCB.ClientID%>");
        var maMonDay = $find("<%= rcbMonDay.ClientID%>");
        var htHopDong = $find("<%= rcbHinhThucHopDong.ClientID%>");
                $('.index-relate-1, .index-relate-2, .index-relate-3, .index-relate-4, .index-relate-5, .index-relate-6, .index-relate-7').removeClass('valid-task');
                if (nhomCB != null) {
                    var itemNhomCB = nhomCB.get_selectedItem();
                    if (itemNhomCB != null) {
                        var valueNhomCB = itemNhomCB.get_value();
                        if (valueNhomCB == '01') {
                            $('.index-relate-1, .index-relate-2, .index-relate-3, .index-relate-4, .index-relate-5, .index-relate-6, .index-relate-7').addClass('valid-task');
                        }
                        if (valueNhomCB == '02') {
                            $('.index-relate-1, .index-relate-5, .index-relate-6, .index-relate-7').addClass('valid-task');
                            if (htHopDong != null) {
                                var itemHtHopDong = htHopDong.get_selectedItem();
                                if (itemHtHopDong != null) {
                                    var valueHTHopDong = itemHtHopDong.get_value();
                                    var arrHTValid = new Array('02', '03', '04', '05');
                                    if ($.inArray(valueHTHopDong, arrHTValid) != -1) {
                                        $('.index-relate-5, .index-relate-6, .index-relate-7').removeClass('valid-task');
                                    }
                                }
                            }
                        }
                        if (valueNhomCB == '03' || valueNhomCB == '06') {
                            $('.index-relate-2, .index-relate-3, .index-relate-4, .index-relate-5, .index-relate-6, .index-relate-7').addClass('valid-task');
                        }
                    }
                }--%>
            }

            function setValidTaskHinhThucHopDong() {
               <%-- var htHopDong = $find("<%= rcbHinhThucHopDong.ClientID%>");
        var nhomCB = $find("<%= rcbNhomCB.ClientID%>");

                $('.index-relate-5, .index-relate-6, .index-relate-7, .index-relate-9').removeClass('valid-task');
                if (htHopDong != null) {
                    var itemHTHopDong = htHopDong.get_selectedItem();
                    if (itemHTHopDong != null) {
                        var valueHTHopDong = itemHTHopDong.get_value();
                        // .index-relate-5 -- > Ngạch/Hạng
                        // .index-relate-6 -- > Bậc lương
                        // .index-relate-7 -- > Hệ số lương
                        // .index-relate-9 -- > Mức phụ cấp ưu đãi nghề
                        if (valueHTHopDong == '07' || valueHTHopDong == '08' || valueHTHopDong == '02') {
                            $('.index-relate-6, .index-relate-7').addClass('valid-task');
                        }
                        if (nhomCB != null) {
                            var itemNhomCB = nhomCB.get_selectedItem();
                            if (itemNhomCB != null) {
                                var valueNhomCB = itemNhomCB.get_value();
                                if (valueNhomCB == '01' || valueNhomCB == '03') {
                                    if (valueHTHopDong == '07' || valueHTHopDong == '08')
                                        $('.index-relate-5, .index-relate-9').addClass('valid-task');
                                    else
                                        $('.index-relate-5, .index-relate-9').removeClass('valid-task');
                                }
                                if (valueNhomCB == '02') {
                                    if (valueHTHopDong == '07' || valueHTHopDong == '08')
                                        $('.index-relate-5').addClass('valid-task');
                                    else
                                        $('.index-relate-5').removeClass('valid-task');
                                }
                            }
                        }
                    }
                }--%>
            }

            function setValidTaskPhuCapChucVuLanhDao() {
                <%--var loaiCB = $find("<%= rcbLoaiCB.ClientID%>");

                $('.index-relate-10').removeClass('valid-task');
                if (loaiCB != null) {
                    var itemLoaiCB = loaiCB.get_selectedItem();
                    if (itemLoaiCB != null) {
                        var valueLoaiCB = itemLoaiCB.get_value();
                        if (valueLoaiCB == '01' || valueLoaiCB == '02' || valueLoaiCB == '03' || valueLoaiCB == '04') {
                            $('.index-relate-10').addClass('valid-task');

                        }
                    }
                }--%>
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
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbNgoaiNguChinh" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="rcbTrinhDoDaoTaoNgoaiNgu" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>

            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="rcbHuyen">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbXa" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="rcbNgach">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtMaSo" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>

            <telerik:AjaxSetting AjaxControlID="rcbViTri">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbHinhThucHD" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>



        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>

    <div class="row" style="padding-top: 10px;">
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Mã <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtMa" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMa"
                        ForeColor="Red" ErrorMessage="Mã giáo viên bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>

                </div>
            </div>
        </div>

        <div class="col-md-4">
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

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Họ tên <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHoTen"
                        ForeColor="Red" ErrorMessage="Họ tên bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div style="clear: both"></div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Điện thoại </span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtDienThoai" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:CustomValidator Display="Dynamic" ForeColor="red" runat="server" ID="CustomValidator1" EnableClientScript="true"
                        ClientValidationFunction="PhoneNumberValidation" ControlToValidate="txtDienThoai" ErrorMessage="Điện thoại không đúng định dạng">
                    </asp:CustomValidator>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Ngày sinh <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadDatePicker ID="dbNgaySinh" runat="server"></telerik:RadDatePicker>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="dbNgaySinh"
                        ForeColor="Red" ErrorMessage="Họ tên bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Dân tộc <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbDanToc" runat="server" DataSourceID="objDanToc" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn dân tộc" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rcbDanToc"
                        ForeColor="Red" ErrorMessage="Dân tộc bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>

                    <asp:ObjectDataSource ID="objDanToc" runat="server" SelectMethod="getDanToc" TypeName="DataAccess.Repository.NHANSURepository" />
                </div>
            </div>
        </div>
        <div style="clear: both"></div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Trạng thái CB <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbTrangThaiCB" runat="server" DataSourceID="objTrangThaiCB" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn trạng thái cơ bản" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rcbTrangThaiCB"
                        ForeColor="Red" ErrorMessage="Trường bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>

                    <asp:ObjectDataSource ID="objTrangThaiCB" runat="server" SelectMethod="getTrangThaiCB" TypeName="DataAccess.Repository.NHANSURepository" />
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Tôn giáo </span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbTonGiao" runat="server" DataSourceID="objTonGiao" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn trạng thái cơ bản" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>

                    <asp:ObjectDataSource ID="objTonGiao" runat="server" SelectMethod="getTonGiao" TypeName="DataAccess.Repository.NHANSURepository" />

                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">CMTNN/TCC <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <asp:TextBox ID="txtSoCMT" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtSoCMT"
                        ForeColor="Red" ErrorMessage="Trường bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator Display="Dynamic" ForeColor="red" runat="server" ID="CustomValidator2" EnableClientScript="true"
                        ControlToValidate="txtSoCMT" ErrorMessage="Bạn phải nhập số CMT">
                    </asp:CustomValidator>

                </div>
            </div>
        </div>
        <div style="clear: both"></div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Quê quán</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbTinh" runat="server" DataSourceID="objTinh" OnSelectedIndexChanged="LoadHuyen" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Tỉnh" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="objTinh" runat="server" SelectMethod="getTinh" TypeName="DataAccess.Repository.NHANSURepository" />
                    <telerik:RadComboBox ID="rcbHuyen" runat="server" OnSelectedIndexChanged="LoadXa" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Huyện" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <telerik:RadComboBox ID="rcbXa" runat="server" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Xã" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <span class="qi-name-control">Khu phố/ thôn xóm</span>
                    <asp:TextBox ID="txtKhuPho" runat="server" CssClass="form-control"></asp:TextBox>


                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Giới tính <span style="color: red">(*)</span></span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbGioiTinh" runat="server" DataSourceID="objGioiTinh" OnSelectedIndexChanged="LoadHuyen" DataTextField="TEN" DataValueField="MA" Width="100%"
                        EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rcbGioiTinh"
                        ForeColor="Red" ErrorMessage="Trường bắt buộc nhập" Display="Dynamic"
                        SetFocusOnError="true"> 
                    </asp:RequiredFieldValidator>

                    <asp:ObjectDataSource ID="objGioiTinh" runat="server" SelectMethod="getGioiTinh" TypeName="DataAccess.Repository.NHANSURepository" />

                </div>
            </div>
        </div>
        <div style="clear: both"></div>
        <div class="col-md-6"></div>
        <div class="col-md-6">
            <div class="form-group editForm-button">
                <asp:Button ID="btnGhi" OnClick="btn_Save" Text='Sửa bản ghi'
                    runat="server"></asp:Button>
                &nbsp;
                        <asp:Button ID="btnCancel" Text="Đóng" runat="server" CausesValidation="False"
                            CommandName="Cancel" OnClientClick="onClientClose()"></asp:Button>

                <%--<asp:Button ID="btSaveAndAdd" CssClass="btn btn-default qi-bt" runat="server" Text="Ghi và thêm" OnClick="btSaveAndAdd_Click" />--%>
            </div>

        </div>

    </div>
    <div class="row">
        <div class="profile-detail-wrapper">
            <telerik:RadTabStrip CausesValidation="false" RenderMode="Classic" runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" SelectedIndex="0" CssClass="qi-panel-search">
                <Tabs>
                    <telerik:RadTab Value="1" Text="I. Vị trí việc làm, TCCD" Width="200px"></telerik:RadTab>
                    <telerik:RadTab Value="2" Text="II. Phụ cấp" Width="100px"></telerik:RadTab>
                    <telerik:RadTab Value="3" Text="III. Đào tạo, bồi dưỡng" Width="200px"></telerik:RadTab>

                </Tabs>
            </telerik:RadTabStrip>
            <div class="tab-content">
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" CssClass="outerMultiPage">
                    <telerik:RadPageView runat="server" ID="RadPageView1">
                        <div class="tab-content-wrapper">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Vị trí việc làm <span style="color: red">(*)</span></span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbViTri" runat="server" DataSourceID="objViTri" OnSelectedIndexChanged="rcbViTri_LoadHinhThucHopDong" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="rcbViTri"
                                            ForeColor="Red" ErrorMessage="Trường bắt buộc nhập" Display="Dynamic"
                                            SetFocusOnError="true"> 
                                        </asp:RequiredFieldValidator>


                                        <asp:ObjectDataSource ID="objViTri" runat="server" SelectMethod="getVitri" TypeName="DataAccess.Repository.NHANSURepository" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Hình thức hợp đồng</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbHinhThucHD" runat="server" DataSourceID="objHinhThucHD" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objHinhThucHD" runat="server" SelectMethod="getHinhThucHopDong" TypeName="DataAccess.Repository.NHANSURepository" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                            </div>
                            <div style="clear: both"></div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Nhóm chức vụ</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbNhomChucVu" runat="server" DataSourceID="objNhomChucVu" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objNhomChucVu" runat="server" SelectMethod="getNhomChucVu" TypeName="DataAccess.Repository.NHANSURepository" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Ngạch/Hạng</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbNgach" runat="server" DataSourceID="objNgach" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains" OnSelectedIndexChanged="rcbNgach_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objNgach" runat="server" SelectMethod="getNgach" TypeName="DataAccess.Repository.NHANSURepository" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                            </div>
                            <div style="clear: both"></div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Dạy nhóm lớp</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbDayNhomLop" runat="server" DataSourceID="objDayNhomLop" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objDayNhomLop" runat="server" SelectMethod="getDayNhomLop" TypeName="DataAccess.Repository.NHANSURepository" />
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Mã số</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtMaSo" runat="server" CssClass="form-control"></asp:TextBox>
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
                                        <span class="qi-name-control">Mức phụ cấp nghề</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtPhuCapNghe" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Hệ số lương</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtHeSoLuong" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                            </div>
                            <div style="clear: both"></div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Mức phụ cấp thâm niên</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <asp:TextBox ID="txtMucPhuCapThamNien" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Ngày hưởng lương</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadDatePicker ID="dateNgayHuongLuong" runat="server"></telerik:RadDatePicker>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                            </div>
                            <div style="clear: both"></div>


                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Bậc lương</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbBacLuong" runat="server" DataSourceID="objBacLuong" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objBacLuong" runat="server" SelectMethod="getNgach" TypeName="DataAccess.Repository.NHANSURepository" />
                                    </div>
                                </div>
                            </div>

                        </div>

                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageView3">
                        <div class="tab-content-wrapper">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">KQ B.dưỡng t.xuyên</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbBoiDuongTX" runat="server" DataSourceID="objBoiDuongTX" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="rcbBoiDuongTX"
                                            ForeColor="Red" ErrorMessage="Trường bắt buộc nhập" Display="Dynamic"
                                            SetFocusOnError="true"> 
                                        </asp:RequiredFieldValidator>

                                        <asp:ObjectDataSource ID="objBoiDuongTX" runat="server" SelectMethod="getBoiDuongTX" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Ngoại nghữ chính</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbNgoaiNguChinh" runat="server" DataSourceID="objNgoaiNghuChinh" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains" OnSelectedIndexChanged="rcbNgoaiNgu_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objNgoaiNghuChinh" runat="server" SelectMethod="getNgoaiNgu" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Chuyên nghành chính</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbChuyenNghanhChinh" runat="server" DataSourceID="objChuyenNghanhChinh" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objChuyenNghanhChinh" runat="server" SelectMethod="getChuyenMon" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">T.độ c.môn n.vụ</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbTrinhDoChuyenMon" runat="server" DataSourceID="objTrinhDoChuyenMon" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="rcbTrinhDoChuyenMon"
                                            ForeColor="Red" ErrorMessage="Trường bắt buộc nhập" Display="Dynamic"
                                            SetFocusOnError="true"> 
                                        </asp:RequiredFieldValidator>

                                        <asp:ObjectDataSource ID="objTrinhDoChuyenMon" runat="server" SelectMethod="getTrinhDoChuyenMonNghiepVu" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">T.độ Đ.tạo N.Ngữ</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbTrinhDoDaoTaoNgoaiNgu" runat="server" DataSourceID="objDMTrinhDoDaoTaoNgoaiNgu" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objDMTrinhDoDaoTaoNgoaiNgu" runat="server" SelectMethod="getTrinhDoDaoTaoNgoaiNghu" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Trình độ chính</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbTrinhDo1" runat="server" DataSourceID="objTrinhDo" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objTrinhDo" runat="server" SelectMethod="getTrinhDoChinh" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">T.độ LLCT</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbTrinhDoLLCT" runat="server" DataSourceID="objTrinhDoLLCT" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objTrinhDoLLCT" runat="server" SelectMethod="getTrinhDoLLCT" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">T.độ tin học</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbTrinhDoTinHoc" runat="server" DataSourceID="objTrinhDoTinHoc" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objTrinhDoTinHoc" runat="server" SelectMethod="getTrinhDoTinHoc" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Chuyên ngành khác</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbChuyenMon2" runat="server" CausesValidation="false"
                                            DataSourceID="objChuyenNghanhChinh" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chuyên ngành khác" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>

                                    </div>
                                </div>
                            </div>
                            <div style="clear: both"></div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">T.độ quản lý GD</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbQuanLyGD" runat="server" DataSourceID="objTrinhDoQLGD" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>
                                        <asp:ObjectDataSource ID="objTrinhDoQLGD" runat="server" SelectMethod="getTrinhDoQLGD" TypeName="DataAccess.Repository.NHANSURepository" />

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                            </div>

                            <div class="col-md-4">
                                <div class="form-group">
                                    <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                                        <span class="qi-name-control">Trình độ khác</span>
                                    </label>
                                    <div class="col-xs-12 col-sm-8 col-md-8">
                                        <telerik:RadComboBox ID="rcbTrinhDo2" runat="server" CausesValidation="false"
                                            DataSourceID="objTrinhDo" DataTextField="TEN" DataValueField="MA" Width="100%"
                                            EmptyMessage="Chuyên ngành khác" AllowCustomText="true" Filter="Contains">
                                        </telerik:RadComboBox>

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
