<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="QuangIchTest.DanhMuc.Form7.index" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rcbSoGD">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbPhongGD" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbPhongGD">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rcbTruong" UpdatePanelCssClass="" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rcbTruong">
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
            <telerik:RadLabel ID="lblTieuDe" runat="server" Text="Báo cáo thống kê giáo dục mầm non"></telerik:RadLabel>
        </div>
        <!-- right -->
        <div class="col-sm-9 qi-button-form text-right">
        </div>
    </div>
    <div class="row" style="padding-top: 10px;">
        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Sở GD</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbSoGD" runat="server" DataSourceID="objSoGD" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains" OnSelectedIndexChanged="LoadPhongGD">
                    </telerik:RadComboBox>
                    <asp:ObjectDataSource ID="objSoGD" runat="server" SelectMethod="getSoGD" TypeName="DataAccess.Repository.HocSinhRepository" />

                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Phòng GD</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox ID="rcbPhongGD" runat="server" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        EmptyMessage="Chọn" AllowCustomText="true" Filter="Contains" OnSelectedIndexChanged="LoadTruong">
                    </telerik:RadComboBox>

                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="form-group">
                <label class="col-xs-12 col-sm-4 col-md-4 control-label">
                    <span class="qi-name-control">Chọn Trường</span>
                </label>
                <div class="col-xs-12 col-sm-8 col-md-8">
                    <telerik:RadComboBox EmptyMessage="Chọn" ID="rcbTruong" runat="server" OnSelectedIndexChanged="LoadGrid" DataTextField="TEN" DataValueField="MA" AutoPostBack="true" Width="100%" CausesValidation="false"
                        AllowCustomText="true" Filter="Contains" EnableLoadOnDemand="true">
                    </telerik:RadComboBox>

                </div>
            </div>
        </div>

    </div>

    <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" GroupPanelPosition="Top" OnNeedDataSource="RadGrid1_NeedDataSource"
    AutoGenerateColumns="False" PageSize="100" Height="550px" >
    <ClientSettings>
        <Scrolling AllowScroll="True" UseStaticHeaders="True" SaveScrollPosition="true"></Scrolling>
    </ClientSettings>
    <MasterTableView HorizontalAlign="NotSet" AutoGenerateColumns="False">
        <NoRecordsTemplate>
            Không có bản ghi nào!
        </NoRecordsTemplate>
        <HeaderStyle CssClass="qi-head-list-grid" HorizontalAlign="Center" />
       
        <Columns>
            <telerik:GridBoundColumn DataField="TT" HeaderStyle-Width="40px" HeaderText="TT" SortExpression="STT"
                    UniqueName="STT" ItemStyle-HorizontalAlign="Left">
                </telerik:GridBoundColumn>
              <telerik:GridBoundColumn DataField="CHITIEU"  HeaderStyle-Width="200px" HeaderText="Chỉ tiêu" SortExpression="CHITIEU"
                    UniqueName="CHITIEU" ItemStyle-HorizontalAlign="Left">
                </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderStyle-Width="150px"  DataField="DONVITINH" FilterControlAltText="Filter LOP column" HeaderText="Đơn vị tính" SortExpression="DONVITINH" UniqueName="DONVITINH" ItemStyle-HorizontalAlign="Center" >
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn HeaderStyle-Width="70px"  DataField="MASO" FilterControlAltText="Filter NT_TONG_SO column" HeaderText="Mã Số" SortExpression="MASO" UniqueName="MASO" ItemStyle-HorizontalAlign="Center">
            </telerik:GridBoundColumn>
            
            <telerik:GridBoundColumn HeaderStyle-Width="70px"  DataField="TongSoTotal" FilterControlAltText="Filter NT_13_24 column" HeaderText="Tổng số" SortExpression="TongSoTotal" UniqueName="TongSoTotal" ItemStyle-HorizontalAlign="Center">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderStyle-Width="70px"  DataField="TongSoCongLap" FilterControlAltText="Filter NT_25_36 column" HeaderText="Công lập" SortExpression="TongSoCongLap" UniqueName="TongSoCongLap" ItemStyle-HorizontalAlign="Center">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn HeaderStyle-Width="70px" DataField="TongSoCongLap" FilterControlAltText="Filter NT_36 column" HeaderText="Tư thục" SortExpression="NT_36" UniqueName="TongSoCongLap" ItemStyle-HorizontalAlign="Center">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn HeaderStyle-Width="70px"  DataField="TongSoDanLap" FilterControlAltText="Filter MG_TONG_SO column" HeaderText="Dân lập" SortExpression="TongSoDanLap" UniqueName="TongSoDanLap" ItemStyle-HorizontalAlign="Center">
            </telerik:GridBoundColumn>              
        </Columns>           
    </MasterTableView>
          </telerik:RadGrid>

   
</asp:Content>
