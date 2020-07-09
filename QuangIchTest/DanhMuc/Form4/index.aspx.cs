using DataAccess;
using DataAccess.Repository;
using DataAccess.SqlCommandQuangIch;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace QuangIchTest.DanhMuc.Form4
{
    public class BindingData
    {

    }
    public partial class index : System.Web.UI.Page
    {
        DbAcessProvider dbaProvider = new DbAcessProvider();
        HocSinhRepository resHocSinh = new HocSinhRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rcbTrangThai.DataSource = resHocSinh.getTrangThaiHS();
                rcbTrangThai.DataBind();
            }
        }

        protected void LoadDataGrid(object sender, GridNeedDataSourceEventArgs e)
        {
            string nhomLop = rcbNhomLop.SelectedValue;
            string lop = rcbLop.SelectedValue;
            string trangThai = rcbTrangThai.SelectedValue;
            List<Form4ViewModel> list = resHocSinh.getPage(nhomLop, lop, trangThai, out int totalRecord);
            RadGrid1.VirtualItemCount = totalRecord;
            list.Take(RadGrid1.PageSize).Skip(e.StartRowIndex);
            RadGrid1.DataSource = list;
        }
        protected void LoadChangeLopHoc(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string nhomLop = rcbNhomLop.SelectedValue;
            rcbLop.DataSource = resHocSinh.getLop(nhomLop);
            rcbLop.DataBind();
            RadGrid1.Rebind();
        }
        protected void LoadLopGrid1(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
        protected void LoadLopGrid2(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                HyperLink editLink = (HyperLink)e.Item.FindControl("EditLink");
                editLink.Attributes["href"] = "javascript:void(0);";
                editLink.Attributes["onclick"] = String.Format("return ShowEditForm('{0}','{1}');", e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ID"], e.Item.ItemIndex);
            }
        }

        protected void btn_Search(object sender, EventArgs e)
        {
            RadGrid1.Rebind();
        }
        protected void btXoa_Click(object sender, EventArgs e)
        {
            string listItemId = "";
            foreach (GridDataItem row in RadGrid1.SelectedItems)
            {
                string id = row.GetDataKeyValue("ID").ToString();
                listItemId += id + ",";


            }
            string listId = listItemId.Substring(0, listItemId.Length - 1);
            string query = String.Format(Form4Command.deleteHocSinhId, listId);
            try
            {
                dbaProvider.ExecuteCommand(query);

            }
            catch
            {

            }
            System.Threading.Thread.Sleep(1000);
            RadGrid1.Rebind();
        }
        protected void LoadChangeComboxCapHoc(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
    }
}




