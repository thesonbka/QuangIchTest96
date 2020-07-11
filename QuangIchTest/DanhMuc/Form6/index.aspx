<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form6.index" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rcbLoaiHinh">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbDanToc">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbGioiTinh">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid1" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"></telerik:RadAjaxLoadingPanel>
    <telerik:RadCodeBlock runat="server">
    </telerik:RadCodeBlock>

    <div class="row">
        <div class="col-sm-3 qi-tieu-de-form">
            <telerik:RadLabel ID="lblTieuDe" runat="server" Text="Thống kê trẻ em theo độ tuổi"></telerik:RadLabel>
        </div>
        <!-- right -->
        <div class="col-sm-9 qi-button-form text-right">
        </div>
    </div>
    <div class="row" style="padding-top: 10px;">
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Loại hình</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbLoaiHinh" runat="server" DataSourceID="objLoaiHinh" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="objLoaiHinh" runat="server" SelectMethod="getLoaiHinh" TypeName="DataAccess.Repository.HocSinhRepository" />

                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Dân tộc</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbDanToc" runat="server" DataSourceID="objDanToc" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="objDanToc" runat="server" SelectMethod="getDanToc" TypeName="DataAccess.Repository.NHANSURepository" />
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Giới tính</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbGioiTinh" runat="server" DataSourceID="objGioiTinh" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="objGioiTinh" runat="server" SelectMethod="getGioiTinh" TypeName="DataAccess.Repository.NHANSURepository" />
                </div>
            </div>
        </div>

    </div>
    <!-- do du lieu ra radgrid -->
    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" GroupPanelPosition="Top" OnNeedDataSource="RadGrid1_NeedDataSource"
        AutoGenerateColumns="False" PageSize="100">
        <ClientSettings>
            <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true"></Scrolling>
        </ClientSettings>
        <MasterTableView HorizontalAlign="NotSet" AutoGenerateColumns="False">
            <NoRecordsTemplate>
                Không có bản ghi nào!
            </NoRecordsTemplate>
            <HeaderStyle CssClass="qi-head-list-grid" HorizontalAlign="Center" />
            <ColumnGroups>
                <telerik:GridColumnGroup HeaderText="Trẻ em nhà trẻ" Name="NT">
                </telerik:GridColumnGroup>
                <telerik:GridColumnGroup HeaderText="Trong đó" Name="NT_TD" ParentGroupName="NT">
                </telerik:GridColumnGroup>

                <telerik:GridColumnGroup HeaderText="Trẻ em mẫu giáo" Name="MG">
                </telerik:GridColumnGroup>
                <telerik:GridColumnGroup HeaderText="Trong đó" Name="MG_TD" ParentGroupName="MG">
                </telerik:GridColumnGroup>
            </ColumnGroups>
            <Columns>
                <telerik:GridBoundColumn DataField="STT" HeaderStyle-Width="40px" HeaderText="STT" SortExpression="STT"
                        UniqueName="STT">
                    </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="150px" DataField="TENSOGIAODUC" FilterControlAltText="Filter LOP column" HeaderText="Đơn vị" SortExpression="TENSOGIAODUC" UniqueName="TENSOGIAODUC" ItemStyle-HorizontalAlign="Left">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="NT" DataField="NHATRETONGSOHOCSINH" FilterControlAltText="Filter NT_TONG_SO column" HeaderText="Tổng số" SortExpression="NT_TONG_SO" UniqueName="NT_TONG_SO" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="NT_TD" DataField="NHATRE3TO12" FilterControlAltText="Filter NT_3_12 column" HeaderText="Trẻ 3 - 12 tháng" SortExpression="NT_3_12" UniqueName="NT_3_12" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="NT_TD" DataField="NT_13_24" FilterControlAltText="Filter NT_13_24 column" HeaderText="Trẻ 13 - 24 tháng" SortExpression="NT_13_24" UniqueName="NT_13_24" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="NT_TD" DataField="NT_25_36" FilterControlAltText="Filter NT_25_36 column" HeaderText="Trẻ 25 - 36 tháng" SortExpression="NT_25_36" UniqueName="NT_25_36" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="NT_TD" DataField="NT_36" FilterControlAltText="Filter NT_36 column" HeaderText="Trẻ từ 36 tháng trở lên" SortExpression="NT_36" UniqueName="NT_36" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="MG" DataField="MAUGIAOTONGSOHOCSINH" FilterControlAltText="Filter MG_TONG_SO column" HeaderText="Tổng số" SortExpression="MG_TONG_SO" UniqueName="MG_TONG_SO" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="MG_TD" DataField="MG_3" FilterControlAltText="Filter MG_3 column" HeaderText="Trẻ dưới 3 tuổi" SortExpression="MG_3" UniqueName="MG_3" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="MG_TD" DataField="MG_3_4" FilterControlAltText="Filter MG_3_4 column" HeaderText="Trẻ 3 - 4 tuổi" SortExpression="MG_3_4" UniqueName="MG_3_4" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="MG_TD" DataField="MG_4_5" FilterControlAltText="Filter MG_4_5 column" HeaderText="Trẻ 4 - 5 tuổi" SortExpression="MG_4_5" UniqueName="MG_4_5" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="MG_TD" DataField="MG_5_6" FilterControlAltText="Filter MG_5_6 column" HeaderText="Trẻ 5 - 6 tuổi" SortExpression="MG_5_6" UniqueName="MG_5_6" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderStyle-Width="70px" ColumnGroupName="MG_TD" DataField="MG_6" FilterControlAltText="Filter MG_6 column" HeaderText="Trẻ trên 6 tuổi" SortExpression="MG_6" UniqueName="MG_6" ItemStyle-HorizontalAlign="Right">
                </telerik:GridBoundColumn>

            </Columns>
           
        </MasterTableView>
    </telerik:RadGrid>

    <div>
    </div>

</asp:Content>
