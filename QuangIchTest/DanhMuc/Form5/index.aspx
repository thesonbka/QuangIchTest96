<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form5.index" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
         <%--   <telerik:AjaxSetting AjaxControlID="RadGrid1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>--%>
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
            <telerik:AjaxSetting AjaxControlID="lkbtCapNhat">
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
            <telerik:RadLabel ID="lblTieuDe" runat="server" Text="Nhập sức khỏe nuôi dưỡng"></telerik:RadLabel>
        </div>
        <!-- right -->
        <div class="col-sm-9 qi-button-form text-right">
            <div class="grbt-chucnang">
                <asp:Button ID="lkbtCapNhat" runat="server" CssClass="btn btn-success qi-bt" Text="Cập nhật" OnClick="btCapNhat_Click" />
            </div>
        </div>
    </div>
    <div class="row" style="padding-top: 10px;">
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
    </div>
    <!-- do du lieu ra radgrid -->
    <div>
        <telerik:RadGrid ID="RadGrid1" runat="server" Height="700px" ShowStatusBar="true"
            AllowMultiRowSelection="True"
            AutoGenerateColumns="False" PageSize="15"
            AllowPaging="True" AllowCustomPaging="True"  OnNeedDataSource="LoadDataGrid"  OnItemDataBound="RadGrid1_ItemDataBound">

            <ClientSettings>
                <Selecting AllowRowSelect="true" EnableDragToSelectRows="true"></Selecting>
                <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true"></Scrolling>
            </ClientSettings>
            <MasterTableView TableLayout="Fixed" CommandItemDisplay="Top" DataKeyNames="ID">
                <%--  <BatchEditingSettings EditType="Cell" HighlightDeletedRows="false" />--%>
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
                    <telerik:GridBoundColumn DataField="IDHOCSINH" HeaderText="IDHOCSINH" SortExpression="IDHOCSINH"
                        UniqueName="IDHOCSINH" Display="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="HOTEN" HeaderText="Họ Tên" SortExpression="HOTEN"
                        UniqueName="HOTEN">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NGAYSINH" HeaderText="Ngày Sinh" SortExpression="NGAYSINH"
                        UniqueName="NGAYSINH">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="GIOITINH" HeaderText="Giới tính" SortExpression="GIOITINH"
                        UniqueName="GIOITINH">
                    </telerik:GridBoundColumn>

                    <telerik:GridTemplateColumn DataField="CANNANG" HeaderText="Cân nặng" UniqueName="CANNANG">
                        <ItemTemplate>
                           
                            <telerik:RadNumericTextBox Width="80px" Value='<%# Eval("CANNANG") %>' ID="txtCanNang" runat="server" CssClass="form-control" MinValue="0" MaxValue="100" >
                                <NumberFormat GroupSeparator="" DecimalDigits="2" /> 
                            </telerik:RadNumericTextBox>
                            <span> Kg</span>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn DataField="CHIEUCAO" HeaderText="Chiều cao" UniqueName="CHIEUCAO">
                        <ItemTemplate>
                            
                            <telerik:RadNumericTextBox Value='<%# Eval("CHIEUCAO") %>' ID="txtCHIEUCAO" Width="80px" runat="server" CssClass="form-control" MinValue="0" MaxValue="100">
                                <NumberFormat GroupSeparator="" DecimalDigits="2" />
                            </telerik:RadNumericTextBox>
                              <span> m</span>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn UniqueName="TENCANTANGTRUONG" HeaderStyle-Width="300px"  DataField="TENCANTANGTRUONG" HeaderText="Kênh tăng trưởng cân nặng" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdMA_KENH_TANG_TRUONG_CAN_NANG" runat="server" Value='<%# Eval("TENCANTANGTRUONG") %>' />
                            
                            <telerik:RadComboBox ID="rcbKenhTangTruongCanNang" runat="server" DataSourceID="objKenhTangTruong" DataTextField="TEN" DataValueField="MA" Width="100%"
                                EmptyMessage="Chọn" CausesValidation="false" AutoPostBack="true" AllowCustomText="true" Filter="Contains" >
                            </telerik:RadComboBox>                           
                            
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>                  
                    <telerik:GridTemplateColumn UniqueName="SUYDINHDUONGTHETHAPCOI" DataField="SUYDINHDUONGTHETHAPCOI" HeaderText="Suy dinh dưỡng thẻ thấp còi" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkTheThapCoi" Checked='<%#Eval("SUYDINHDUONGTHETHAPCOI")%>' runat="server" AutoPostBack="true"  />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn UniqueName="SUYDINHDUONGTHECOICOC" DataField="SUYDINHDUONGTHECOICOC" HeaderText="Suy dinh dưỡng thẻ còi cọc" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkTheCoiCoc" Checked='<%#Eval("SUYDINHDUONGTHECOICOC")%>' runat="server" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn UniqueName="TREBIBEOPHI" DataField="TREBIBEOPHI" HeaderText="Trẻ bị béo phì" AllowFiltering="false">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkTreBeoPhi" Checked='<%#Eval("TREBIBEOPHI")%>'  runat="server" />
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <asp:ObjectDataSource ID="objKenhTangTruong" runat="server" SelectMethod="getKenhTangtruongCanNang" TypeName="DataAccess.Repository.HocSinhRepository" />
        <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
            <Windows>
                <telerik:RadWindow RenderMode="Lightweight" ID="RadWindow1" runat="server" ShowContentDuringLoad="false" Width="1100px"
                    Height="700px" Title="Chi tiết hồ sơ học sinh" Behaviors="Reload,Close,Maximize" Modal="true" VisibleStatusbar="false">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>
    </div>

</asp:Content>
