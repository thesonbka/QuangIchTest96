using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ViewModel;

namespace DataAccess.Repository
{
   public  class ThongKeRepository
    {
        //public int getMonth(DateTime current,DateTime namsinh)
        //{
        //    return Math.Abs((current.Month - namsinh.Month)) + 12 * (current.Year - namsinh.Year);
        //}
        public List<Form6ViewModel> getPage()
        {
            List<Form6ViewModel> listGetPage = new List<Form6ViewModel>();
            var context = new BO_GIAO_DUC_TEMPEntities();
            List<string> listMASoGD = context.HOC_SINH.Select(p => p.MA_TINH).Distinct().ToList();
            int STT = 0;
            foreach (var item in listMASoGD)
            {
                STT++;
                Form6ViewModel detail = new Form6ViewModel();
                detail.TENSOGIAODUC = context.SO_GD.FirstOrDefault(p => p.MA == item).TEN;
                detail.NHATRETONGSOHOCSINH = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "16" && p.MA_TINH==item).Count();                
                detail.MAUGIAOTONGSOHOCSINH = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "17" && p.MA_TINH == item).Count();                
                detail.STT = STT.ToString();
                listGetPage.Add(detail);
            }
            return listGetPage;
        }

    }
}
