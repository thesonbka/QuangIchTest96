<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form4.index" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lkbtThemMoi">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbNhomLop">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbLop" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbLop">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbTrangThai">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lkbtXoa">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
    <telerik:RadCodeBlock runat="server">
        <script>
            var indexControl = 1;
            var grid;
            function pageLoad() {
                try {
                    grid = $find("<%=RadGrid1.ClientID%>");
                    setBorderRowGrid(grid, 5);
                }
                catch (ex) { }
            }
            function RadWindowManager1_OnClientClose(sender, args) {
                var ajaxManager = $find("<%= RadAjaxManager1.ClientID %>").ajaxRequest("RadWindowManager1_Close");
                var arg = args.get_argument();
                if (arg != null) {
                    refreshGrid();
                    notification('success', arg);
                }
            }
            function refreshGrid() {
                var masterTable = $find("<%= RadGrid1.ClientID %>").get_masterTableView();
                masterTable.rebind();
            }

            function btDeteleClick() {
                var RadGrid1 = $find("<%=RadGrid1.ClientID %>");
                if (RadGrid1.get_masterTableView().get_selectedItems().length > 0) {
                    if (confirm("Bạn chắc chắn muốn xóa?")) {
                        return true;
                    }
                } else {
                    alert("Mời bạn chọn thông tin xóa.");
                    return false;
                }
            }
            function ShowEditForm(id, rowIndex) {
                debugger;
                var grid = $find("<%= RadGrid1.ClientID %>");

                var rowControl = grid.get_masterTableView().get_dataItems()[rowIndex].get_element();
                grid.get_masterTableView().selectItem(rowControl, true);

                window.radopen("FormEdit.aspx?ID=" + id, "RadWindow1");
                return false;
            }
            function ShowInsertForm() {
                debugger;
                window.radopen("FormInsert.aspx", "RadWindow1");
                return false;
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
    <div class="row">
        <div class="col-sm-3 qi-tieu-de-form">
            <telerik:RadLabel ID="lblTieuDe" runat="server" Text="Danh sách hồ sơ học sinh"></telerik:RadLabel>
        </div>
        <!-- right -->
        <div class="col-sm-9 qi-button-form text-right">
            <div class="grbt-chucnang">
                <asp:Button ID="btnSearch" runat="server" OnClick="btn_Search" CssClass="btn btn-success qi-bt" Text="Tìm kiếm" />
                <asp:Button ID="lkbtThemMoi" runat="server" CssClass="btn btn-success qi-bt" Text="Thêm mới" OnClientClick="if(!ShowInsertForm()) return false;" />
                <asp:Button ID="lkbtXoa" runat="server" CssClass="btn btn-success qi-bt" Text="Xóa" OnClick="btXoa_Click" OnClientClick="if(!btDeteleClick()) return false;" />
            </div>
        </div>
    </div>
    <div class="row" style="padding-top:10px;">
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Chọn nhóm lớp</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbNhomLop" runat="server" DataSourceID="objNhomLop" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains" OnSelectedIndexChanged="LoadChangeLopHoc">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="objNhomLop" runat="server" SelectMethod="getNhomLop" TypeName="DataAccess.Repository.HocSinhRepository" />

                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Chọn lớp</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbLop" runat="server" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains" OnSelectedIndexChanged="LoadLopGrid1">
                    </telerik:RadComboBox>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Chọn trạng thái</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbTrangThai" runat="server" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains" OnSelectedIndexChanged="LoadLopGrid2">
                    </telerik:RadComboBox>
                </div>
            </div>
        </div>
    </div>
    <!-- do du lieu ra radgrid -->
    <div>
        <telerik:RadGrid ID="RadGrid1" runat="server" Height="700px" ShowStatusBar="true"
            AllowMultiRowSelection="True"
            AutoGenerateColumns="False" PageSize="15"
            AllowPaging="True" AllowCustomPaging="True" OnItemCreated="RadGrid1_ItemCreated" OnNeedDataSource="LoadDataGrid">
            <ClientSettings>
                <Selecting AllowRowSelect="true" EnableDragToSelectRows="true"></Selecting>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true"></Scrolling>
            </ClientSettings>
            <MasterTableView TableLayout="Fixed" CommandItemDisplay="Top" DataKeyNames="ID">
                <NoRecordsTemplate>
                    Không có bản ghi nào!
                </NoRecordsTemplate>
                <CommandItemSettings ShowExportToExcelButton="true" ExportToExcelText="Xuất Excel"
                    ShowAddNewRecordButton="true" AddNewRecordText="Thêm mới"
                    CancelChangesText="Hủy" RefreshText="Làm mới" SaveChangesText="Lưu thay đổi" />
                <EditFormSettings>
                    <PopUpSettings />
                    <EditColumn UpdateText="Lưu" CancelText="Hủy" InsertText="Thêm" ButtonType="PushButton"></EditColumn>
                </EditFormSettings>
                <Columns>
                    <telerik:GridBoundColumn DataField="ID" HeaderText="ID" SortExpression="ID"
                        UniqueName="ID">
                    </telerik:GridBoundColumn>
                    <telerik:GridClientSelectColumn UniqueName="chkChon" HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    </telerik:GridClientSelectColumn>
                    <telerik:GridTemplateColumn UniqueName="TemplateEditColumn" HeaderText="Sửa">
                        <ItemTemplate>
                            <asp:HyperLink ID="EditLink" runat="server" Text="sửa"></asp:HyperLink>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridBoundColumn DataField="THUTU" HeaderText="Thứ tự" SortExpression="THUTU"
                        UniqueName="THUTU">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="MA" HeaderText="Mã Định Danh" SortExpression="MA"
                        UniqueName="HOTEN">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="HOTEN" HeaderText="Họ Tên" SortExpression="HOTEN"
                        UniqueName="HOTEN">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NGAYSINH" HeaderText="Ngày sinh" SortExpression="NGAYSINH"
                        UniqueName="NGAYSINH">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="GIOTINH" HeaderText="Giới tính" SortExpression="GIOTINH"
                        UniqueName="GIOTINH">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DANTOC" HeaderText="Dân tộc" SortExpression="DANTOC"
                        UniqueName="DANTOC">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TRANGTHAI" HeaderText="Trạng thái" SortExpression="TRANGTHAI"
                        UniqueName="TRANGTHAI">
                    </telerik:GridBoundColumn>


                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
            <Windows>
                <telerik:RadWindow RenderMode="Lightweight" ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="1100px"
                    Height="700px" Title="Chi tiết hồ sơ học sinh" Behaviors="Reload,Close,Maximize" Modal="true" VisibleStatusbar="false">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>

</asp:Content>
