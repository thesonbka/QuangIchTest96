using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.SqlCommandQuangIch;
using DataAccess;
using Telerik.Web.UI;
using Telerik.Web.UI.PivotGrid.Queryable.Groups;
using System.Data;
using DataAccess.ViewModel;
using Telerik.Charting;
using DataAccess.Repository;

namespace QuangIchTest.DanhMuc.Form1
{
    public class BindingData
    {
        public List<ListItemCapHoc> GetItems()
        {
            DbAcessProvider dbaProvider = new DbAcessProvider();

            var table = dbaProvider.ExecuteCommand(Form1Command.queryComboboxCapHoc);
            List<ListItemCapHoc> list = new List<ListItemCapHoc>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                ListItemCapHoc model = new ListItemCapHoc();
                model.MA = table.Rows[i][0].ToString();
                model.TEN = table.Rows[i][1].ToString();

                list.Add(model);

            }
            return list;
        }
    }
    public partial class index : System.Web.UI.Page
    {
        DbAcessProvider dbaProvider = new DbAcessProvider();
        Form1Repository data = new Form1Repository();



        protected void Page_Load(object sender, EventArgs e)
        {
         
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

        
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
           


        }
       
        protected void LoadCapHoc(object sender, GridNeedDataSourceEventArgs e)
        {
            string str = RadComboBox1.SelectedValue;
            if (!string.IsNullOrEmpty(str))
            {
                int itemID = int.Parse(RadComboBox1.SelectedValue);
                string query = String.Format(Form1Command.queryGetCaphoc, itemID, e.StartRowIndex, RadGrid1.PageSize);
                var table = dbaProvider.ExecuteCommand(query);
                List<Form1ViewModel> list = new List<Form1ViewModel>();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Form1ViewModel model = new Form1ViewModel();
                    model.ID = int.Parse(table.Rows[i][1].ToString());
                    model.MA = int.Parse(table.Rows[i][2].ToString());
                    model.TEN = table.Rows[i][3].ToString();
                    model.TENCAPHOC = table.Rows[i][4].ToString();
                    model.KIEUMON = table.Rows[i][5].ToString();
                    model.THUTU = table.Rows[i][6].ToString();
                    list.Add(model);

                }
                RadGrid1.VirtualItemCount = Int32.Parse(table.Rows[0]["TOTAL_ROW"].ToString());
                RadGrid1.DataSource = list;

            }
            else
            {
                string query = String.Format(Form1Command.queryGetAll, e.StartRowIndex, RadGrid1.PageSize);
                var table = dbaProvider.ExecuteCommand(query);
                List<Form1ViewModel> list = new List<Form1ViewModel>();

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    Form1ViewModel model = new Form1ViewModel();
                    model.ID = int.Parse(table.Rows[i][1].ToString());
                    model.MA = int.Parse(table.Rows[i][2].ToString());
                    model.TEN = table.Rows[i][3].ToString();
                    model.TENCAPHOC = table.Rows[i][4].ToString();
                    model.KIEUMON = table.Rows[i][5].ToString();
                    model.THUTU = table.Rows[i][6].ToString();
                    list.Add(model);

                }
                RadGrid1.VirtualItemCount = Int32.Parse(table.Rows[0]["TOTAL_ROW"].ToString());
                RadGrid1.DataSource = list;

            }

        }
        protected void LoadChangeComboxCapHoc(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
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
            string query = String.Format(Form1Command.deleteMonhocId, listId);
            dbaProvider.ExecuteCommand(query);
            System.Threading.Thread.Sleep(1000);
            RadGrid1.Rebind();


        }


        public List<Form1ViewModel> getComboboChange(int itemID)
        {

            string query = String.Format(Form1Command.queryGetCaphoc, itemID);
            var table = dbaProvider.ExecuteCommand(query);
            List<Form1ViewModel> list = new List<Form1ViewModel>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Form1ViewModel model = new Form1ViewModel();
                model.ID = i + 1;
                model.MA = int.Parse(table.Rows[i][0].ToString());
                model.TEN = table.Rows[i][1].ToString();
                model.TENCAPHOC = table.Rows[i][2].ToString();
                model.KIEUMON = table.Rows[i][3].ToString();
                model.THUTU = table.Rows[i][4].ToString();
                list.Add(model);

            }
            return list;
        }

    }
}