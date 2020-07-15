using DataAccess.IRepository;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class ThongkeNhaTreRepository
    {
        public static TRUONG getById(string maTruong)
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            return context.TRUONGs.FirstOrDefault(p => p.MA == maTruong);

        }
        public List<ThongKeNhaTreViewModel> getPageTruong(string maTruong)
        {
            List<ThongKeNhaTreViewModel> list = new List<ThongKeNhaTreViewModel>();
            var context = new BO_GIAO_DUC_TEMPEntities();            
            //I. Trường 01          
                ThongKeNhaTreViewModel modelRow1 = new ThongKeNhaTreViewModel();
            modelRow1.Type = 1;
            modelRow1.TT = "<p><b>I.</b></p>";
            modelRow1.DONVITINH = "trường";
            modelRow1.CHITIEU = "<p><b>Trường</b></p>";
            modelRow1.MASO = "01";
            modelRow1.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA == maTruong
                                     && obj.DS_CAP_HOC == "01"
                                     select 1).Count();
            modelRow1.TongSoCongLap = (from obj in context.TRUONGs
                                      where obj.MA == maTruong
                                      && obj.DS_CAP_HOC == "01" &&obj.MA_LOAI_HINH_TRUONG=="01"
                                      select 1).Count();
            modelRow1.TongSoTuThuc = (from obj in context.TRUONGs
                                      where obj.MA == maTruong
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "09"
                                      select 1).Count();
            modelRow1.TongSoDanLap = (from obj in context.TRUONGs
                                      where obj.MA == maTruong
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "03"
                                      select 1).Count();
            list.Add(modelRow1);
            // 5 tiêu chí 02 - 06

            List<string> listTruong = context.DM_NHOM_CAP_HOC.Where(p => p.DS_CAP == "01").Select(p => p.MA).ToList();
            int maSo = 2;
          
            foreach(var item in listTruong)
            {
                string TEN = context.DM_NHOM_CAP_HOC.Where(p => p.MA == item).Select(p => p.TEN).FirstOrDefault();
                ThongKeNhaTreViewModel model = new ThongKeNhaTreViewModel();
                model.Type = 2;
                model.MASO = "0"+ maSo.ToString();
                model.DONVITINH = "trường";
                model.CHITIEU = "<p>"+TEN+"</p>";
                model.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA == maTruong
                                     && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC==item
                                     select 1).Count();
                model.TongSoCongLap = (from obj in context.TRUONGs
                                       where obj.MA == maTruong
                                       && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC == item &&obj.MA_LOAI_HINH_TRUONG=="01"
                                       select 1).Count();
                model.TongSoTuThuc = (from obj in context.TRUONGs
                                       where obj.MA == maTruong
                                       && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC == item && obj.MA_LOAI_HINH_TRUONG == "09"
                                       select 1).Count();
                model.TongSoCongLap = (from obj in context.TRUONGs
                                       where obj.MA == maTruong
                                       && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC == item && obj.MA_LOAI_HINH_TRUONG == "03"
                                       select 1).Count();
                list.Add(model);
                maSo++;
              
            }
            //tiêu chí  07
            ThongKeNhaTreViewModel treLopMauGiaoDocLap = new ThongKeNhaTreViewModel();
            treLopMauGiaoDocLap.Type = 2;
            treLopMauGiaoDocLap.DONVITINH = "cơ sở";
            treLopMauGiaoDocLap.CHITIEU = "<p>Nhóm trẻ, lớp mẫu giáo độc lập</p>";
            treLopMauGiaoDocLap.MASO = "0" + maSo.ToString();
            treLopMauGiaoDocLap.TongSoTotal = 0;
            treLopMauGiaoDocLap.TongSoCongLap = 0;
            treLopMauGiaoDocLap.TongSoTuThuc = 0;
            treLopMauGiaoDocLap.TongSoDanLap = 0;
            list.Add(treLopMauGiaoDocLap);
            maSo++;
           
            // I 1. số điểm trường  08
            ThongKeNhaTreViewModel soDiemTruong = new ThongKeNhaTreViewModel();
            soDiemTruong.Type = 2;
            soDiemTruong.MASO = "0" + maSo.ToString();
            soDiemTruong.DONVITINH = "điểm";
            soDiemTruong.CHITIEU = "<p>Số điểm trường</p>";
            soDiemTruong.TongSoTotal = (from obj in context.DIEM_TRUONG
                                        where obj.MA_TRUONG == maTruong
                                        select 1).Count();  
            soDiemTruong.TongSoCongLap = (from obj in context.DIEM_TRUONG
                                          where obj.MA_TRUONG == maTruong && context.TRUONGs.Any(p=>p.MA==maTruong && p.MA_LOAI_HINH_TRUONG=="01")                                         
                                          select 1).Count();
            soDiemTruong.TongSoTuThuc = (from obj in context.DIEM_TRUONG
                                          where obj.MA_TRUONG == maTruong && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                          select 1).Count();
            soDiemTruong.TongSoDanLap = (from obj in context.DIEM_TRUONG
                                         where obj.MA_TRUONG == maTruong && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                         select 1).Count();
            list.Add(soDiemTruong);
            maSo++;

            // II.Nhóm , lớp  09
            ThongKeNhaTreViewModel nhomLop = new ThongKeNhaTreViewModel();
            nhomLop.Type = 1;
            nhomLop.TT = " <p><b>II.</b></p>";
            nhomLop.DONVITINH = "nhóm, lớp";
            nhomLop.CHITIEU = "<p><b>Nhóm,lớp</b></p>";
            nhomLop.MASO = "0" + maSo.ToString();
            nhomLop.TongSoTotal = (from obj in context.LOPs
                                   where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong
                                   select 1).Count();
            nhomLop.TongSoCongLap = (from obj in context.LOPs
                                     where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && context.TRUONGs.Any(p=>p.MA==maTruong && p.MA_LOAI_HINH_TRUONG=="01")
                                     select 1).Count();
            nhomLop.TongSoTuThuc = (from obj in context.LOPs
                                     where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                     select 1).Count();
            nhomLop.TongSoDanLap = (from obj in context.LOPs
                                     where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                     select 1).Count();
            list.Add(nhomLop);
            maSo++;

            //2 tiêu chí 10 11
            List<string> listNhomLop = context.DM_KHOI.Where(p => p.MA_CAP_HOC == "01").Select(p => p.MA).ToList();
            foreach(var item in listNhomLop)
            {
                ThongKeNhaTreViewModel nhomLopTre = new ThongKeNhaTreViewModel();
                string Ten = context.DM_KHOI.Where(p => p.MA == item).Select(p => p.TEN).FirstOrDefault();
                nhomLopTre.Type = 2;
                nhomLopTre.DONVITINH = "nhóm";
                nhomLopTre.CHITIEU = "<p>"+Ten+"</p>";
                nhomLopTre.MASO = maSo.ToString();
                nhomLopTre.TongSoTotal = (from obj in context.LOPs
                                          where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && obj.MA_KHOI== item
                                          select 1).Count();
                nhomLopTre.TongSoCongLap = (from obj in context.LOPs
                                          where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && obj.MA_KHOI == item && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                          select 1).Count();
                nhomLopTre.TongSoTuThuc = (from obj in context.LOPs
                                          where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && obj.MA_KHOI == item && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                          select 1).Count();
                nhomLopTre.TongSoDanLap = (from obj in context.LOPs
                                          where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && obj.MA_KHOI == item && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                          select 1).Count();
                list.Add(nhomLopTre);
                maSo++;

            }

            //III Trẻ em  12
            ThongKeNhaTreViewModel treEm = new ThongKeNhaTreViewModel();
            treEm.Type = 1;
            treEm.TT = " <p><b>III.</b></p>";
            treEm.CHITIEU = "<p><b>Trẻ em</b></p>";
            treEm.MASO = maSo.ToString();
            treEm.DONVITINH = "người";

            treEm.TongSoTotal = (from obj in context.HOC_SINH
                                   where obj.MA_TRUONG == maTruong 
                                   select 1).Count();
            treEm.TongSoCongLap = (from obj in context.HOC_SINH
                                     where obj.MA_TRUONG == maTruong  && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                     select 1).Count();
            treEm.TongSoTuThuc = (from obj in context.HOC_SINH
                                    where obj.MA_TRUONG == maTruong  && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                    select 1).Count();
            treEm.TongSoDanLap = (from obj in context.HOC_SINH
                                    where obj.MA_TRUONG == maTruong  && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                    select 1).Count();
            list.Add(treEm);
            maSo++;

            // quy mô trẻ 13
            ThongKeNhaTreViewModel nhomTre = new ThongKeNhaTreViewModel();
            nhomTre.Type = 2;
            nhomTre.MASO = maSo.ToString();
            nhomTre.TT= " <p><b>3.1</b></p>";
            nhomTre.DONVITINH = "người";
            nhomTre.CHITIEU = "<p><b>Quy mô trẻ</b></p>";
            nhomTre.TongSoTotal = (from obj in context.HOC_SINH
                                   where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01"
                                   select 1).Count();
            nhomTre.TongSoCongLap = (from obj in context.HOC_SINH
                                   where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && context.TRUONGs.Any(p=>p.MA==maTruong && p.MA_LOAI_HINH_TRUONG=="01")
                                   select 1).Count();
            nhomTre.TongSoTuThuc = (from obj in context.HOC_SINH
                                     where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                     select 1).Count();
            nhomTre.TongSoDanLap = (from obj in context.HOC_SINH
                                     where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                     select 1).Count();
            list.Add(nhomTre);
            maSo++;
            //2 tiêu chí 14 15

            foreach (var item in listNhomLop)
            {
                ThongKeNhaTreViewModel nhomLopTre = new ThongKeNhaTreViewModel();
                nhomLopTre.Type = 3;                
                nhomLopTre.DONVITINH = "người";
                nhomLopTre.CHITIEU = "<p>Trẻ em nhà trẻ</p>";
                nhomLopTre.MASO = maSo.ToString();
                nhomLopTre.TongSoTotal = (from obj in context.HOC_SINH
                                          where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" &&obj.MA_KHOI==item
                                          select 1).Count();
                nhomLopTre.TongSoCongLap = (from obj in context.HOC_SINH
                                            where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && obj.MA_KHOI == item && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                            select 1).Count();
                nhomLopTre.TongSoTuThuc = (from obj in context.HOC_SINH
                                           where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && obj.MA_KHOI == item && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                           select 1).Count();
                nhomLopTre.TongSoDanLap = (from obj in context.HOC_SINH
                                           where obj.MA_CAP_HOC == "01" && obj.MA_TRUONG == maTruong && obj.MA_KHOI == item && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                           select 1).Count();
                list.Add(nhomLopTre);
                maSo++;

            }

            //3.2 tinh trang dinh duong tre em

            ThongKeNhaTreViewModel tinhtrangDinhDuongTreEm = new ThongKeNhaTreViewModel();
            tinhtrangDinhDuongTreEm.TT = "<p><b>3.2</b></p>";
            tinhtrangDinhDuongTreEm.CHITIEU = "<p><b>Tình trạng dinh dưỡng trẻ em</b></p>";
            tinhtrangDinhDuongTreEm.Type = 2;
            tinhtrangDinhDuongTreEm.DONVITINH = "người";
            tinhtrangDinhDuongTreEm.MASO = maSo.ToString();
            tinhtrangDinhDuongTreEm.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                       where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" 
                                       select 1
                                       ).Count();
            tinhtrangDinhDuongTreEm.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                         where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01"  && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                         select 1
                                       ).Count();
            tinhtrangDinhDuongTreEm.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                        select 1
                                       ).Count();
            tinhtrangDinhDuongTreEm.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01"  && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                        select 1
                                       ).Count();
            list.Add(tinhtrangDinhDuongTreEm);
            maSo++;


            //3.2.1 trẻ em nhà trẻ  17

            ThongKeNhaTreViewModel treEmNhaTre = new ThongKeNhaTreViewModel();

            treEmNhaTre.Type = 3;
            treEmNhaTre.MASO = maSo.ToString();
            treEmNhaTre.DONVITINH = "nguời";
            treEmNhaTre.TT = "<p>3.2.1</p>";
            treEmNhaTre.CHITIEU = "<p>Trẻ em nhà trẻ được kiểm tra sức khỏe và đánh giá tình trạng dinh dưỡng</p>";
            treEmNhaTre.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                       where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16"
                                       select 1
                                       ).Count();
            treEmNhaTre.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                       where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                       select 1
                                       ).Count();
            treEmNhaTre.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                       where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                        select 1
                                       ).Count();
            treEmNhaTre.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                       where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                        select 1
                                       ).Count();
            list.Add(treEmNhaTre);
            maSo++;

            // 4 tiêu chí 18 19 20 21
            ThongKeNhaTreViewModel treEmNheCan = new ThongKeNhaTreViewModel();
            treEmNheCan.Type = 4;
            treEmNheCan.CHITIEU = "<p style='margin - left:10px; '>- Trẻ suy dinh dưỡng thể nhẹ cân</p>";
            treEmNheCan.DONVITINH = "nguời";
            treEmNheCan.MASO = maSo.ToString();
            treEmNheCan.TongSoTotal = 0;
            treEmNheCan.TongSoCongLap = 0;
            treEmNheCan.TongSoTuThuc = 0;
            treEmNheCan.TongSoDanLap = 0;
            list.Add(treEmNheCan);
            maSo++;

            ThongKeNhaTreViewModel treEmThapCoi = new ThongKeNhaTreViewModel();
            treEmThapCoi.Type = 4;
            treEmThapCoi.DONVITINH= "nguời";
            treEmThapCoi.CHITIEU = "<p style='margin - left:10px; '>- Trẻ suy dinh dưỡng thể thấp còi</p>";
            treEmThapCoi.MASO = maSo.ToString();
            treEmThapCoi.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && obj.IS_SUY_DINH_DUONG_THE_THAP_COI==1
                                        select 1
                                       ).Count();
            treEmThapCoi.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                          where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                          && obj.IS_SUY_DINH_DUONG_THE_THAP_COI == 1
                                          select 1
                                       ).Count();
            treEmThapCoi.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                         where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                           && obj.IS_SUY_DINH_DUONG_THE_THAP_COI == 1
                                         select 1
                                       ).Count();
            treEmThapCoi.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                         where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                           && obj.IS_SUY_DINH_DUONG_THE_THAP_COI == 1
                                         select 1
                                       ).Count();
            list.Add(treEmThapCoi);
            maSo++;

            ThongKeNhaTreViewModel treEmCoiCoc = new ThongKeNhaTreViewModel();
            treEmCoiCoc.Type = 4;
            treEmCoiCoc.CHITIEU = "<p style='margin - left:10px; '>- Trẻ suy dinh dưỡng thể còi cọc</p>";
            treEmCoiCoc.DONVITINH = "nguời";
            treEmCoiCoc.MASO = maSo.ToString();

            treEmCoiCoc.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                       where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && obj.IS_SUY_DINH_DUONG_THE_COI_COC == 1
                                       select 1
                                       ).Count();
            treEmCoiCoc.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                         where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                         && obj.IS_SUY_DINH_DUONG_THE_COI_COC == 1
                                         select 1
                                       ).Count();
            treEmCoiCoc.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                          && obj.IS_SUY_DINH_DUONG_THE_COI_COC == 1
                                        select 1
                                       ).Count();
            treEmCoiCoc.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                          && obj.IS_SUY_DINH_DUONG_THE_COI_COC == 1
                                        select 1
                                       ).Count();
            list.Add(treEmCoiCoc);
            maSo++;

            ThongKeNhaTreViewModel treEmBeoPhi = new ThongKeNhaTreViewModel();
            treEmBeoPhi.Type = 4;
            treEmBeoPhi.CHITIEU = "<p style='margin - left:10px; '> - Trẻ thừa cân, béo phì</p>";
            treEmBeoPhi.DONVITINH = "nguời";
            treEmBeoPhi.MASO = maSo.ToString();

            treEmBeoPhi.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                       where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && obj.IS_TRE_BI_BEO_PHI == 1
                                       select 1
                                       ).Count();
            treEmBeoPhi.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                         where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                         && obj.IS_TRE_BI_BEO_PHI == 1
                                         select 1
                                       ).Count();
            treEmBeoPhi.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                          && obj.IS_TRE_BI_BEO_PHI == 1
                                        select 1
                                       ).Count();
            treEmBeoPhi.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "16" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                          && obj.IS_TRE_BI_BEO_PHI == 1
                                        select 1
                                       ).Count();
            list.Add(treEmBeoPhi);
            maSo++;

            //trẻ em mẫu giáo 22
            ThongKeNhaTreViewModel treEmMauGiao = new ThongKeNhaTreViewModel();

            treEmMauGiao.Type = 3;
            treEmMauGiao.TT = "<p>3.2.2</p>";
            treEmMauGiao.CHITIEU = "<p> Trẻ em mẫu giáo được kiểm tra sức khỏe và đánh giá tình trạng dinh dưỡng</p>";
            treEmMauGiao.MASO = maSo.ToString();
            treEmMauGiao.DONVITINH = "người";
            treEmMauGiao.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                       where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17"
                                       select 1
                                       ).Count();
            treEmMauGiao.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                         where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                         select 1
                                       ).Count();
            treEmMauGiao.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                        select 1
                                       ).Count();
            treEmMauGiao.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                        where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                        select 1
                                       ).Count();
            list.Add(treEmMauGiao);
            maSo++;

            //4 tiêu chí 23 24 25 26
            ThongKeNhaTreViewModel mauGiaoNheCan = new ThongKeNhaTreViewModel();
            mauGiaoNheCan.Type = 4;
            mauGiaoNheCan.MASO = maSo.ToString();
            mauGiaoNheCan.CHITIEU = "<p style='margin - left:10px; '>- Trẻ suy dinh dưỡng thể nhẹ cân</p>";
            mauGiaoNheCan.DONVITINH = "người";
            mauGiaoNheCan.TongSoTotal = 0;
            mauGiaoNheCan.TongSoCongLap = 0;
            mauGiaoNheCan.TongSoTuThuc = 0;
            mauGiaoNheCan.TongSoDanLap = 0;
            list.Add(mauGiaoNheCan);
            maSo++;

            ThongKeNhaTreViewModel mauGiaoThapCoi = new ThongKeNhaTreViewModel();
            mauGiaoThapCoi.Type = 4;
            mauGiaoThapCoi.CHITIEU = "<p style='margin - left:10px; '> - Trẻ suy dinh dưỡng thể thấp còi</p>";
            mauGiaoThapCoi.MASO = maSo.ToString();
            mauGiaoThapCoi.DONVITINH = "người";
            mauGiaoThapCoi.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                          where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17"
                                          &&obj.IS_SUY_DINH_DUONG_THE_THAP_COI==1
                                          select 1
                                       ).Count();
            mauGiaoThapCoi.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                            where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                              && obj.IS_SUY_DINH_DUONG_THE_THAP_COI == 1

                                            select 1
                                       ).Count();
            mauGiaoThapCoi.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                           where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                             && obj.IS_SUY_DINH_DUONG_THE_THAP_COI == 1

                                           select 1
                                       ).Count();
            mauGiaoThapCoi.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                           where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                             && obj.IS_SUY_DINH_DUONG_THE_THAP_COI == 1

                                           select 1
                                       ).Count();
            list.Add(mauGiaoThapCoi);
            maSo++;

            ThongKeNhaTreViewModel mauGiaoCoiCoc = new ThongKeNhaTreViewModel();
            mauGiaoCoiCoc.Type = 4;
            mauGiaoCoiCoc.CHITIEU = "<p style='margin - left:10px; '>  - Trẻ suy dinh dưỡng thể còi cọc</p>";
            mauGiaoCoiCoc.MASO = maSo.ToString();
            mauGiaoCoiCoc.DONVITINH = "người";
            mauGiaoCoiCoc.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                         where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17"
                                         && obj.IS_SUY_DINH_DUONG_THE_COI_COC == 1
                                         select 1
                                       ).Count();
            mauGiaoCoiCoc.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                           where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                             && obj.IS_SUY_DINH_DUONG_THE_COI_COC == 1

                                           select 1
                                       ).Count();
            mauGiaoCoiCoc.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                          where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                            && obj.IS_SUY_DINH_DUONG_THE_COI_COC == 1

                                          select 1
                                       ).Count();
            mauGiaoCoiCoc.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                          where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                            && obj.IS_SUY_DINH_DUONG_THE_COI_COC == 1

                                          select 1
                                       ).Count();
            list.Add(mauGiaoCoiCoc);
            maSo++;

            ThongKeNhaTreViewModel mauGiaoBeoPhi = new ThongKeNhaTreViewModel();
            mauGiaoBeoPhi.Type = 4;
            mauGiaoBeoPhi.MASO = maSo.ToString();
            mauGiaoBeoPhi.DONVITINH = "người";
            mauGiaoBeoPhi.CHITIEU = "<p style='margin - left:10px; '>- Trẻ thừa cân, béo phì</p>";
            mauGiaoBeoPhi.TongSoTotal = (from obj in context.SUC_KHOE_NUOI_DUONG
                                         where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17"
                                         && obj.IS_TRE_BI_BEO_PHI == 1
                                         select 1
                                       ).Count();
            mauGiaoBeoPhi.TongSoCongLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                           where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "01")
                                             && obj.IS_TRE_BI_BEO_PHI == 1

                                           select 1
                                       ).Count();
            mauGiaoBeoPhi.TongSoTuThuc = (from obj in context.SUC_KHOE_NUOI_DUONG
                                          where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "09")
                                            && obj.IS_TRE_BI_BEO_PHI == 1

                                          select 1
                                       ).Count();
            mauGiaoBeoPhi.TongSoDanLap = (from obj in context.SUC_KHOE_NUOI_DUONG
                                          where obj.MA_TRUONG == maTruong && obj.MA_CAP_HOC == "01" && obj.MA_KHOI == "17" && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                            && obj.IS_TRE_BI_BEO_PHI == 1

                                          select 1
                                       ).Count();
            list.Add(mauGiaoBeoPhi);
            maSo++;

            // IV cán bộ quản lý, giáo viên và nhân viên  27
            ThongKeNhaTreViewModel canBoQuanLyGiaoVienNhanVien = new ThongKeNhaTreViewModel();
            canBoQuanLyGiaoVienNhanVien.Type = 1;
            canBoQuanLyGiaoVienNhanVien.TT = "<p><b>IV.</b></p>";
            canBoQuanLyGiaoVienNhanVien.CHITIEU = "<p><b>Cán bộ quản lý, giáo viên và nhân viên</b></p>";
            canBoQuanLyGiaoVienNhanVien.MASO = maSo.ToString();
            canBoQuanLyGiaoVienNhanVien.DONVITINH = "người";
            canBoQuanLyGiaoVienNhanVien.TongSoTotal = (from obj in context.NHAN_SU
                                      where obj.MA_TRUONG == maTruong
                                      select 1).Count();
            canBoQuanLyGiaoVienNhanVien.TongSoCongLap = (from obj in context.NHAN_SU
                                        where obj.MA_TRUONG == maTruong
                                        && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                        select 1).Count();
            canBoQuanLyGiaoVienNhanVien.TongSoTuThuc = (from obj in context.NHAN_SU
                                       where obj.MA_TRUONG == maTruong
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                       select 1).Count();
            canBoQuanLyGiaoVienNhanVien.TongSoDanLap = (from obj in context.NHAN_SU
                                       where obj.MA_TRUONG == maTruong
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                       select 1).Count();
            list.Add(canBoQuanLyGiaoVienNhanVien);
            maSo++;


            //4.1 cán bộ quản lý  28
            ThongKeNhaTreViewModel canBoQuanLy = new ThongKeNhaTreViewModel();
            canBoQuanLy.Type = 2;
            canBoQuanLy.TT = "<p><b>4.1</b></p>";
            canBoQuanLy.CHITIEU = "<p><b>Cán bộ quản lý</b></p>";
            canBoQuanLy.MASO = maSo.ToString();
            canBoQuanLy.DONVITINH = "người";
            canBoQuanLy.TongSoTotal = (from obj in context.NHAN_SU
                                      where (obj.MA_LOAI_CAN_BO == "01" || obj.MA_LOAI_CAN_BO=="02") && obj.MA_TRUONG == maTruong
                                      select 1).Count();
            canBoQuanLy.TongSoCongLap = (from obj in context.NHAN_SU
                                        where (obj.MA_LOAI_CAN_BO == "01" || obj.MA_LOAI_CAN_BO == "02") && obj.MA_TRUONG == maTruong
                                        && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                        select 1).Count();
            canBoQuanLy.TongSoTuThuc = (from obj in context.NHAN_SU
                                       where (obj.MA_LOAI_CAN_BO == "01" || obj.MA_LOAI_CAN_BO == "02") && obj.MA_TRUONG == maTruong
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                       select 1).Count();
            canBoQuanLy.TongSoDanLap = (from obj in context.NHAN_SU
                                       where (obj.MA_LOAI_CAN_BO == "01" || obj.MA_LOAI_CAN_BO == "02") && obj.MA_TRUONG == maTruong
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                       select 1).Count();
            list.Add(canBoQuanLy);
            maSo++;

            //4.1 hiệu trưởng 29
            ThongKeNhaTreViewModel hieuTruong = new ThongKeNhaTreViewModel();
            hieuTruong.Type = 3;
            hieuTruong.TT = "<p>4.1.1</p>";
            hieuTruong.CHITIEU = "<p>Hiệu trưởng</p>";
            hieuTruong.MASO = maSo.ToString();
            hieuTruong.DONVITINH = "người";
            hieuTruong.TongSoTotal = (from obj in context.NHAN_SU
                                      where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                      select 1).Count();
            hieuTruong.TongSoCongLap = (from obj in context.NHAN_SU
                                        where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                        && context.TRUONGs.Any(p=>p.MA==obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG=="01")
                                        select 1).Count();
            hieuTruong.TongSoTuThuc = (from obj in context.NHAN_SU
                                       where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                       select 1).Count();
            hieuTruong.TongSoDanLap = (from obj in context.NHAN_SU
                                       where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                       select 1).Count();
            list.Add(hieuTruong);
            maSo++;
            //2 tieu chi 30 31
            ThongKeNhaTreViewModel hieuTruongNhaTre = new ThongKeNhaTreViewModel();
            hieuTruongNhaTre.Type = 4;
            hieuTruongNhaTre.MASO = maSo.ToString();
            hieuTruongNhaTre.DONVITINH = "người";
            hieuTruongNhaTre.CHITIEU = "<p style='margin - left:10px; '> - Hiệu trưởng nhà trẻ </p>";
            hieuTruongNhaTre.TongSoTotal = (from obj in context.NHAN_SU
                                      where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong && obj.MA_MON_DAY=="01"
                                      select 1).Count();
            hieuTruongNhaTre.TongSoCongLap = (from obj in context.NHAN_SU
                                        where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                        && obj.MA_MON_DAY == "01"
                                        && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                        select 1).Count();
            hieuTruongNhaTre.TongSoTuThuc = (from obj in context.NHAN_SU
                                       where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                       && obj.MA_MON_DAY == "01"
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                       select 1).Count();
            hieuTruongNhaTre.TongSoDanLap = (from obj in context.NHAN_SU
                                       where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                       && obj.MA_MON_DAY == "01"
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                       select 1).Count();
            list.Add(hieuTruongNhaTre);
            maSo++;

            ThongKeNhaTreViewModel hieuTruongMauGiao = new ThongKeNhaTreViewModel();
            hieuTruongMauGiao.Type = 4;
            hieuTruongMauGiao.MASO = maSo.ToString();
            hieuTruongMauGiao.DONVITINH = "người";
            hieuTruongMauGiao.CHITIEU = "<p style='margin - left:10px; '> - Hiệu trưởng mẫu giáo , mầm non</p>";
            hieuTruongMauGiao.TongSoTotal = (from obj in context.NHAN_SU
                                            where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                            && obj.MA_MON_DAY == "02"
                                             select 1).Count();
            hieuTruongMauGiao.TongSoCongLap = (from obj in context.NHAN_SU
                                              where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                                 && obj.MA_MON_DAY == "02"
                                              && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                              select 1).Count();
            hieuTruongMauGiao.TongSoTuThuc = (from obj in context.NHAN_SU
                                             where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                               && obj.MA_MON_DAY == "02"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                             select 1).Count();
            hieuTruongMauGiao.TongSoDanLap = (from obj in context.NHAN_SU
                                             where obj.MA_LOAI_CAN_BO == "01" && obj.MA_TRUONG == maTruong
                                               && obj.MA_MON_DAY == "02"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                             select 1).Count();
            list.Add(hieuTruongMauGiao);
            maSo++;


            //4.2 phó hiệu trưởng 32
            ThongKeNhaTreViewModel phoHieuTruong = new ThongKeNhaTreViewModel();
            phoHieuTruong.Type = 3;
            phoHieuTruong.TT = "<p>4.1.2</p>";
            phoHieuTruong.CHITIEU = "<p> Phó Hiệu trưởng</p>";
            phoHieuTruong.MASO = maSo.ToString();
            phoHieuTruong.DONVITINH = "người";
            phoHieuTruong.TongSoTotal = (from obj in context.NHAN_SU
                                      where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                      select 1).Count();
            phoHieuTruong.TongSoCongLap = (from obj in context.NHAN_SU
                                        where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                        && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                        select 1).Count();
            phoHieuTruong.TongSoTuThuc = (from obj in context.NHAN_SU
                                       where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                       select 1).Count();
            phoHieuTruong.TongSoDanLap = (from obj in context.NHAN_SU
                                       where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                       select 1).Count();
            list.Add(phoHieuTruong);
            maSo++;


            //2 tieu chi 33 34
            ThongKeNhaTreViewModel PhohieuTruongNhaTre = new ThongKeNhaTreViewModel();
            PhohieuTruongNhaTre.Type = 4;
            PhohieuTruongNhaTre.MASO = maSo.ToString();
            PhohieuTruongNhaTre.DONVITINH = "người";
            PhohieuTruongNhaTre.CHITIEU = "<p style='margin - left:10px; '> - Phó Hiệu trưởng nhà trẻ</p>";
            PhohieuTruongNhaTre.TongSoTotal = (from obj in context.NHAN_SU
                                            where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong && obj.MA_MON_DAY == "01"
                                            select 1).Count();
            PhohieuTruongNhaTre.TongSoCongLap = (from obj in context.NHAN_SU
                                              where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                              && obj.MA_MON_DAY == "01"
                                              && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                              select 1).Count();
            PhohieuTruongNhaTre.TongSoTuThuc = (from obj in context.NHAN_SU
                                             where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                             && obj.MA_MON_DAY == "01"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                             select 1).Count();
            PhohieuTruongNhaTre.TongSoDanLap = (from obj in context.NHAN_SU
                                             where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                             && obj.MA_MON_DAY == "01"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                             select 1).Count();
            list.Add(PhohieuTruongNhaTre);
            maSo++;

            ThongKeNhaTreViewModel PhohieuTruongMauGiao = new ThongKeNhaTreViewModel();
            PhohieuTruongMauGiao.Type = 4;
            PhohieuTruongMauGiao.MASO = maSo.ToString();
            PhohieuTruongMauGiao.DONVITINH = "người";
            PhohieuTruongMauGiao.CHITIEU = "<p style='margin - left:10px; '>- Phó Hiệu trưởng mẫu giáo, mầm non</p>";
            PhohieuTruongMauGiao.TongSoTotal = (from obj in context.NHAN_SU
                                             where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                             && obj.MA_MON_DAY == "02"
                                             select 1).Count();
            PhohieuTruongMauGiao.TongSoCongLap = (from obj in context.NHAN_SU
                                               where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                                  && obj.MA_MON_DAY == "02"
                                               && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                               select 1).Count();
            PhohieuTruongMauGiao.TongSoTuThuc = (from obj in context.NHAN_SU
                                              where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                                && obj.MA_MON_DAY == "02"
                                              && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                              select 1).Count();
            PhohieuTruongMauGiao.TongSoDanLap = (from obj in context.NHAN_SU
                                              where obj.MA_LOAI_CAN_BO == "02" && obj.MA_TRUONG == maTruong
                                                && obj.MA_MON_DAY == "02"
                                              && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                              select 1).Count();
            list.Add(PhohieuTruongMauGiao);
            maSo++;

            //4.2 giáo viên 35

            ThongKeNhaTreViewModel giaovien = new ThongKeNhaTreViewModel();
            giaovien.Type = 2;
            giaovien.MASO = maSo.ToString();
            giaovien.DONVITINH = "người";
            giaovien.TT = "<p><b>4.2</b></p>";
            giaovien.CHITIEU = "<p><b>Giáo viên</b></p>";

            giaovien.TongSoTotal = (from obj in context.NHAN_SU
                                          where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                          
                                          select 1).Count();
            giaovien.TongSoCongLap = (from obj in context.NHAN_SU
                                            where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                            
                                            && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                            select 1).Count();
            giaovien.TongSoTuThuc = (from obj in context.NHAN_SU
                                           where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                           
                                           && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                           select 1).Count();
            giaovien.TongSoDanLap = (from obj in context.NHAN_SU
                                           where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                             
                                           && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                           select 1).Count();
            list.Add(giaovien);
            maSo++;

            //4.2.1 giáo viên nhà trẻ 36 
            ThongKeNhaTreViewModel giaovienNhaTre = new ThongKeNhaTreViewModel();
            giaovienNhaTre.Type = 3;
            giaovienNhaTre.MASO = maSo.ToString();
            giaovienNhaTre.DONVITINH = "người";
            giaovienNhaTre.TT = "<p>4.2.1</p>";
            giaovienNhaTre.CHITIEU = "<p>Giáo viên nhà trẻ</p>";
            giaovienNhaTre.TongSoTotal = (from obj in context.NHAN_SU
                                                where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                                && obj.MA_MON_DAY=="01"
                                                select 1).Count();
            giaovienNhaTre.TongSoCongLap = (from obj in context.NHAN_SU
                                                  where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                                     && obj.MA_MON_DAY == "01"
                                                  && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                                  select 1).Count();
            giaovienNhaTre.TongSoTuThuc = (from obj in context.NHAN_SU
                                                 where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                                   && obj.MA_MON_DAY == "01"
                                                 && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                                 select 1).Count();
            giaovienNhaTre.TongSoDanLap = (from obj in context.NHAN_SU
                                                 where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                                   && obj.MA_MON_DAY == "01"
                                                 && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                                 select 1).Count();
            list.Add(giaovienNhaTre);
            maSo++;



            //4.2.2 giáo viên mẫu giáo 41
            ThongKeNhaTreViewModel giaovienMauGiao = new ThongKeNhaTreViewModel();
            giaovienMauGiao.Type = 3;
            giaovienMauGiao.CHITIEU = "<p>Giáo viên mẫu giáo</p>";
            giaovienMauGiao.MASO = maSo.ToString();
            giaovienMauGiao.DONVITINH = "người";
            giaovienMauGiao.TT = "<p>4.2.2</p>";
            giaovienMauGiao.TongSoTotal = (from obj in context.NHAN_SU
                                          where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                          && obj.MA_MON_DAY == "02"
                                          select 1).Count();
            giaovienMauGiao.TongSoCongLap = (from obj in context.NHAN_SU
                                            where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                               && obj.MA_MON_DAY == "02"
                                            && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                            select 1).Count();
            giaovienMauGiao.TongSoTuThuc = (from obj in context.NHAN_SU
                                           where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                             && obj.MA_MON_DAY == "02"
                                           && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                           select 1).Count();
            giaovienMauGiao.TongSoDanLap = (from obj in context.NHAN_SU
                                           where obj.MA_NHOM_CAN_BO == "03" && obj.MA_TRUONG == maTruong
                                             && obj.MA_MON_DAY == "02"
                                           && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                           select 1).Count();
            list.Add(giaovienMauGiao);
            maSo++;



            //4.3 giáo viên nghĩ hưu trong năm 46
            ThongKeNhaTreViewModel giaovienNghiHuu = new ThongKeNhaTreViewModel();
            giaovienNghiHuu.Type = 2;
            giaovienNghiHuu.MASO = maSo.ToString();
            giaovienNghiHuu.DONVITINH = "người";
            giaovienNghiHuu.TT = "<p><b>4.3</b></p>";
            giaovienNghiHuu.CHITIEU = "<p><b>Giáo viên nghĩ hưu trong năm</b></p>";

            giaovienNghiHuu.TongSoTotal = (from obj in context.NHAN_SU
                                           where obj.MA_TRUONG == maTruong
                                           && obj.MA_TRANG_THAI_CAN_BO=="05"
                                          
                                           select 1).Count();
            giaovienNghiHuu.TongSoCongLap = (from obj in context.NHAN_SU
                                           where obj.MA_TRUONG == maTruong
                                           && obj.MA_TRANG_THAI_CAN_BO == "05"
                                            && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                            select 1).Count();
            giaovienNghiHuu.TongSoTuThuc = (from obj in context.NHAN_SU
                                             where obj.MA_TRUONG == maTruong
                                             && obj.MA_TRANG_THAI_CAN_BO == "05"
                                              && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                             select 1).Count();
            giaovienNghiHuu.TongSoDanLap = (from obj in context.NHAN_SU
                                            where obj.MA_TRUONG == maTruong
                                            && obj.MA_TRANG_THAI_CAN_BO == "05"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                            select 1).Count();
            list.Add(giaovienNghiHuu);
            maSo++;


            // 2 tiêu chí 47 48
            ThongKeNhaTreViewModel giaovienNghiHuuNhaTtre = new ThongKeNhaTreViewModel();
            giaovienNghiHuuNhaTtre.Type = 3;
            giaovienNghiHuuNhaTtre.MASO = maSo.ToString();
            giaovienNghiHuuNhaTtre.CHITIEU = "<p style='margin - left:10px; '>- Giáo viên nhà trẻ</p>";
            giaovienNghiHuuNhaTtre.DONVITINH = "người";
            giaovienNghiHuuNhaTtre.TongSoTotal = (from obj in context.NHAN_SU
                                           where obj.MA_TRUONG == maTruong
                                           && obj.MA_TRANG_THAI_CAN_BO == "05"
                                           && obj.MA_MON_DAY=="01"

                                           select 1).Count();
            giaovienNghiHuuNhaTtre.TongSoCongLap = (from obj in context.NHAN_SU
                                             where obj.MA_TRUONG == maTruong
                                             && obj.MA_TRANG_THAI_CAN_BO == "05"
                                             && obj.MA_MON_DAY == "01"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                             select 1).Count();
            giaovienNghiHuuNhaTtre.TongSoTuThuc = (from obj in context.NHAN_SU
                                            where obj.MA_TRUONG == maTruong
                                            && obj.MA_TRANG_THAI_CAN_BO == "05"
                                             && obj.MA_MON_DAY == "01"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                            select 1).Count();
            giaovienNghiHuuNhaTtre.TongSoDanLap = (from obj in context.NHAN_SU
                                            where obj.MA_TRUONG == maTruong
                                            && obj.MA_TRANG_THAI_CAN_BO == "05"
                                             && obj.MA_MON_DAY == "01"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                            select 1).Count();
            list.Add(giaovienNghiHuuNhaTtre);
            maSo++;

            ThongKeNhaTreViewModel giaovienNghiHuuMauGiao = new ThongKeNhaTreViewModel();
            giaovienNghiHuuMauGiao.Type = 3;
            giaovienNghiHuuMauGiao.CHITIEU = "<p style='margin - left:10px; '>- Giáo viên mẫu giáo</p>";
            giaovienNghiHuuMauGiao.MASO = maSo.ToString();
            giaovienNghiHuuMauGiao.DONVITINH = "người";
            giaovienNghiHuuMauGiao.TongSoTotal = (from obj in context.NHAN_SU
                                                  where obj.MA_TRUONG == maTruong
                                                   && obj.MA_MON_DAY == "02"
                                                  && obj.MA_TRANG_THAI_CAN_BO == "05"

                                                  select 1).Count();
            giaovienNghiHuuMauGiao.TongSoCongLap = (from obj in context.NHAN_SU
                                                    where obj.MA_TRUONG == maTruong
                                                     && obj.MA_MON_DAY == "02"
                                                    && obj.MA_TRANG_THAI_CAN_BO == "05"
                                                     && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                                    select 1).Count();
            giaovienNghiHuuMauGiao.TongSoTuThuc = (from obj in context.NHAN_SU
                                                   where obj.MA_TRUONG == maTruong
                                                    && obj.MA_MON_DAY == "02"
                                                   && obj.MA_TRANG_THAI_CAN_BO == "05"
                                                    && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                                   select 1).Count();
            giaovienNghiHuuMauGiao.TongSoDanLap = (from obj in context.NHAN_SU
                                                   where obj.MA_TRUONG == maTruong
                                                    && obj.MA_MON_DAY == "02"
                                                   && obj.MA_TRANG_THAI_CAN_BO == "05"
                                                    && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                                   select 1).Count();
            list.Add(giaovienNghiHuuMauGiao);
            maSo++;




            //4.5 nhân viên 52
            ThongKeNhaTreViewModel nhanVien = new ThongKeNhaTreViewModel();
            nhanVien.Type = 2;
            nhanVien.MASO = maSo.ToString();
            nhanVien.DONVITINH = "người";
            nhanVien.CHITIEU= "<p><b>Nhân viên</b></p>";
            nhanVien.TT = "<p><b>4.4</b></p>";
            nhanVien.TongSoTotal = (from obj in context.NHAN_SU
                                           where obj.MA_TRUONG == maTruong
                                           && obj.MA_NHOM_CAN_BO=="02"

                                           select 1).Count();
            nhanVien.TongSoCongLap = (from obj in context.NHAN_SU
                                             where obj.MA_TRUONG == maTruong
                                              && obj.MA_NHOM_CAN_BO == "02"
                                              && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                             select 1).Count();
            nhanVien.TongSoTuThuc = (from obj in context.NHAN_SU
                                            where obj.MA_TRUONG == maTruong
                                             && obj.MA_NHOM_CAN_BO == "02"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                            select 1).Count();
            nhanVien.TongSoDanLap = (from obj in context.NHAN_SU
                                            where obj.MA_TRUONG == maTruong
                                            && obj.MA_NHOM_CAN_BO == "02"
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                            select 1).Count();
            list.Add(nhanVien);
            maSo++;

            // 2 tiêu chí 53 54

            ThongKeNhaTreViewModel nhanVienNhaTre = new ThongKeNhaTreViewModel();
            nhanVienNhaTre.Type = 3;
            nhanVienNhaTre.MASO = maSo.ToString();
            nhanVienNhaTre.CHITIEU = "<p>Nhân viên nhà trẻ</p>";
            nhanVienNhaTre.TT = "<p>4.4.1</p>";
            nhanVienNhaTre.DONVITINH = "người";
            nhanVienNhaTre.TongSoTotal = (from obj in context.NHAN_SU
                                    where obj.MA_TRUONG == maTruong
                                    && obj.MA_NHOM_CAN_BO == "02"                                 
                                    &&context.TRUONGs.Any(p=>p.MA==maTruong && p.MA_NHOM_CAP_HOC=="03")
                                    select 1).Count();
            nhanVienNhaTre.TongSoCongLap = (from obj in context.NHAN_SU
                                      where obj.MA_TRUONG == maTruong
                                       && obj.MA_NHOM_CAN_BO == "02"
                                       && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                        && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_NHOM_CAP_HOC == "03")
                                            select 1).Count();
            nhanVienNhaTre.TongSoTuThuc = (from obj in context.NHAN_SU
                                     where obj.MA_TRUONG == maTruong
                                      && obj.MA_NHOM_CAN_BO == "02"
                                      && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                       && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_NHOM_CAP_HOC == "03")
                                           select 1).Count();
            nhanVienNhaTre.TongSoDanLap = (from obj in context.NHAN_SU
                                     where obj.MA_TRUONG == maTruong
                                     && obj.MA_NHOM_CAN_BO == "02"
                                      && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                       && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_NHOM_CAP_HOC == "03")
                                           select 1).Count();
            list.Add(nhanVienNhaTre);
            maSo++;

            ThongKeNhaTreViewModel nhanVienMauGiao = new ThongKeNhaTreViewModel();
            nhanVienMauGiao.Type = 3;
            nhanVienMauGiao.MASO = maSo.ToString();
            nhanVienMauGiao.DONVITINH = "người";
            nhanVienMauGiao.TT = "<p>4.4.2</p>";
            nhanVienMauGiao.CHITIEU = "<p>Nhân viên mẫu giáo,mầm non</p>";
            nhanVienMauGiao.TongSoTotal = (from obj in context.NHAN_SU
                                          where obj.MA_TRUONG == maTruong
                                          && obj.MA_NHOM_CAN_BO == "02"
                                           && context.TRUONGs.Any(p => p.MA == maTruong && (p.MA_NHOM_CAP_HOC == "01" ||p.MA_NHOM_CAP_HOC=="02"))

                                           select 1).Count();
            nhanVienMauGiao.TongSoCongLap = (from obj in context.NHAN_SU
                                            where obj.MA_TRUONG == maTruong
                                             && obj.MA_NHOM_CAN_BO == "02"
                                               && context.TRUONGs.Any(p => p.MA == maTruong && (p.MA_NHOM_CAP_HOC == "01" || p.MA_NHOM_CAP_HOC == "02"))
                                             && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "01")
                                            select 1).Count();
            nhanVienMauGiao.TongSoTuThuc = (from obj in context.NHAN_SU
                                           where obj.MA_TRUONG == maTruong
                                            && obj.MA_NHOM_CAN_BO == "02"
                                              && context.TRUONGs.Any(p => p.MA == maTruong && (p.MA_NHOM_CAP_HOC == "01" || p.MA_NHOM_CAP_HOC == "02"))
                                            && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "09")
                                           select 1).Count();
            nhanVienMauGiao.TongSoDanLap = (from obj in context.NHAN_SU
                                           where obj.MA_TRUONG == maTruong
                                           && obj.MA_NHOM_CAN_BO == "02"
                                             && context.TRUONGs.Any(p => p.MA == maTruong && (p.MA_NHOM_CAP_HOC == "01" || p.MA_NHOM_CAP_HOC == "02"))
                                            && context.TRUONGs.Any(p => p.MA == obj.MA_TRUONG && p.MA_LOAI_HINH_TRUONG == "03")
                                           select 1).Count();
            list.Add(nhanVienMauGiao);
            maSo++;            
            return list;
        }
    }
}
