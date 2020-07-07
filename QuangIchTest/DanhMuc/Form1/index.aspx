<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form1.index" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Form1 Index</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <%--xu ly ajax--%>

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
            <telerik:AjaxSetting AjaxControlID="RadComboBox1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />

                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="lkbtXoa">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--<telerik:AjaxSetting AjaxControlID="lkbtThemMoi">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="modalPopup" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
             
        </AjaxSettings>
    </telerik:RadAjaxManager>

    <%-----------------%>
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
            //function responseEnd(sender, eventArgs) {
            //    var eventTarget = eventArgs.get_eventTarget();
            //    addClasscoMaSo();
            //}

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


        </script>

    </telerik:RadCodeBlock>

    <div class="form-horizontal">
        <!-- nhom giao dien headertop -->

        <!-- left -->
        <div class="col-sm-3 qi-tieu-de-form">
            <telerik:RadLabel ID="lblTieuDe" runat="server" Text="Quản lý môn học"></telerik:RadLabel>
        </div>
        <!-- right -->
        <div class="col-sm-9 qi-button-form text-right">

            <div class="grbt-chucnang">

                <asp:Button ID="lkbtThemMoi" runat="server" CssClass="btn btn-success qi-bt" Text="Thêm mới" OnClientClick="if(!ShowInsertForm()) return false;" />
                <asp:Button ID="lkbtXoa" runat="server" CssClass="btn btn-success qi-bt" Text="Xóa" OnClick="btXoa_Click" OnClientClick="if(!btDeteleClick()) return false;" />
              
            </div>
        </div>

        <!-- --------------- -->
        <!-- label message -->
        <div id="qi-panel-message">
            <div class="messageContent">
                <asp:Label runat="server" ID="lblMessageNotice"></asp:Label>
            </div>
        </div>
        <!-- nhom chuc nang headerbottom -->

        <div id="qi-panel-search" class="fillterFieldsOneRow">
            <div class="form-group">
                <div class="col-sm-12 col-xs-12">
                    <label class="control-label pull-left">Chọn cấp học</label>
                    <div class="col-sm-2 lbleft">
                        <telerik:RadComboBox ID="RadComboBox1" runat="server" DataSourceID="objKhoi" DataTextField="TEN" DataValueField="MA" OnSelectedIndexChanged="LoadChangeComboxCapHoc" AutoPostBack="true" Width="100%" CausesValidation="false"
                            EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains">
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="objKhoi" runat="server" SelectMethod="GetItems" TypeName="QuangIchTest.DanhMuc.Form1.BindingData" />
                    </div>

                </div>
            </div>
            <div style="clear: both"></div>
        </div>
        <!-- do du lieu ra radgrid -->
        <div>
            <telerik:RadGrid ID="RadGrid1" runat="server" OnNeedDataSource="LoadCapHoc" OnItemDataBound="RadGrid1_ItemDataBound" OnItemCreated="RadGrid1_ItemCreated" ShowStatusBar="true"
                AllowMultiRowSelection="True"
                AutoGenerateColumns="False" PageSize="6"
                AllowPaging="True" AllowCustomPaging="True">
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

                        <telerik:GridBoundColumn DataField="MA" HeaderText="Mã" SortExpression="MA"
                            UniqueName="MA">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TEN" HeaderText="Tên" SortExpression="TEN"
                            UniqueName="TEN">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="TENCAPHOC" HeaderText="Cấp học" SortExpression="TENCAPHOC"
                            UniqueName="TENCAPHOC">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="KIEUMON" HeaderText="Kiểu môn" SortExpression="KIEUMON"
                            UniqueName="KIEUMON">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="THUTU" HeaderText="Thứ Tự" SortExpression="THUTU"
                            UniqueName="THUTU">
                        </telerik:GridBoundColumn>

                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
                <Windows>
                    <telerik:RadWindow RenderMode="Lightweight" ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="600px"
                        Height="400px" Title="Quản lý môn học" Behaviors="Reload,Close,Maximize" Modal="true" VisibleStatusbar="false">
                    </telerik:RadWindow>
                </Windows>
            </telerik:RadWindowManager>
        </div>
    </div>
</asp:Content>
