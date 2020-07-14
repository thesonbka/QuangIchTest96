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
            foreach(var item in listTruong)
            {
                ThongKeNhaTreViewModel model = new ThongKeNhaTreViewModel();
                model.Type = 2;
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
            }
            //tiêu chí  07
            ThongKeNhaTreViewModel treLopMauGiaoDocLap = new ThongKeNhaTreViewModel();
            treLopMauGiaoDocLap.Type = 2;
            treLopMauGiaoDocLap.TongSoTotal = 0;
            treLopMauGiaoDocLap.TongSoCongLap = 0;
            treLopMauGiaoDocLap.TongSoTuThuc = 0;
            treLopMauGiaoDocLap.TongSoDanLap = 0;
            list.Add(treLopMauGiaoDocLap);
           
            // I 1. số điểm trường  08
            ThongKeNhaTreViewModel soDiemTruong = new ThongKeNhaTreViewModel();
            soDiemTruong.Type = 2;
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

            // II.Nhóm , lớp  09
            ThongKeNhaTreViewModel nhomLop = new ThongKeNhaTreViewModel();
            nhomLop.Type = 1;
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

            //2 tiêu chí 10 11
            List<string> listNhomLop = context.DM_KHOI.Where(p => p.MA_CAP_HOC == "01").Select(p => p.MA).ToList();
            foreach(var item in listNhomLop)
            {
                ThongKeNhaTreViewModel nhomLopTre = new ThongKeNhaTreViewModel();
                nhomLopTre.Type = 2;
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

            }

            //III Trẻ em  12
            ThongKeNhaTreViewModel treEm = new ThongKeNhaTreViewModel();
            treEm.Type = 1;
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
                                    where obj.MA_TRUONG == maTruong && context.TRUONGs.Any(p => p.MA == maTruong && p.MA_LOAI_HINH_TRUONG == "03")
                                    select 1).Count();
            list.Add(treEm);

            // quy mô trẻ 13
            ThongKeNhaTreViewModel nhomTre = new ThongKeNhaTreViewModel();
            nhomTre.Type = 1;
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
            //2 tiêu chí 14 15

            foreach (var item in listNhomLop)
            {
                ThongKeNhaTreViewModel nhomLopTre = new ThongKeNhaTreViewModel();
                nhomLopTre.Type = 2;
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

            }

            //3.2 tinh trang dinh duong tre em

            ThongKeNhaTreViewModel tinhtrangDinhDuongTreEm = new ThongKeNhaTreViewModel();

            tinhtrangDinhDuongTreEm.Type = 2;
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


            //3.2.1 trẻ em nhà trẻ  17

            ThongKeNhaTreViewModel treEmNhaTre = new ThongKeNhaTreViewModel();

            treEmNhaTre.Type = 2;
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

            // 4 tiêu chí 18 19 20 21
            ThongKeNhaTreViewModel treEmNheCan = new ThongKeNhaTreViewModel();
            treEmNheCan.TongSoTotal = 0;
            treEmNheCan.TongSoCongLap = 0;
            treEmNheCan.TongSoTuThuc = 0;
            treEmNheCan.TongSoDanLap = 0;
            list.Add(treEmNheCan);

            ThongKeNhaTreViewModel treEmThapCoi = new ThongKeNhaTreViewModel();
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

            ThongKeNhaTreViewModel treEmCoiCoc = new ThongKeNhaTreViewModel();
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

            ThongKeNhaTreViewModel treEmBeoPhi = new ThongKeNhaTreViewModel();
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
           
            //trẻ em mẫu giáo 22
            ThongKeNhaTreViewModel treEmMauGiao = new ThongKeNhaTreViewModel();

            treEmMauGiao.Type = 2;
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

            //4 tiêu chí 23 24 25 26
            ThongKeNhaTreViewModel mauGiaoNheCan = new ThongKeNhaTreViewModel();
            mauGiaoNheCan.TongSoTotal = 0;
            mauGiaoNheCan.TongSoCongLap = 0;
            mauGiaoNheCan.TongSoTuThuc = 0;
            mauGiaoNheCan.TongSoDanLap = 0;
            list.Add(mauGiaoNheCan);

            ThongKeNhaTreViewModel mauGiaoThapCoi = new ThongKeNhaTreViewModel();
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

            ThongKeNhaTreViewModel mauGiaoCoiCoc = new ThongKeNhaTreViewModel();
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

            ThongKeNhaTreViewModel mauGiaoBeoPhi = new ThongKeNhaTreViewModel();
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

            // IV cán bộ quản lý, giáo viên và nhân viên  27
            ThongKeNhaTreViewModel canBoQuanLyGiaoVienNhanVien = new ThongKeNhaTreViewModel();
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


            //4.1 cán bộ quản lý  28
            ThongKeNhaTreViewModel canBoQuanLy = new ThongKeNhaTreViewModel();
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

            //4.1 hiệu trưởng 29
            ThongKeNhaTreViewModel hieuTruong = new ThongKeNhaTreViewModel();
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
            //2 tieu chi 30 31
            ThongKeNhaTreViewModel hieuTruongNhaTre = new ThongKeNhaTreViewModel();
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

            ThongKeNhaTreViewModel hieuTruongMauGiao = new ThongKeNhaTreViewModel();
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


            //4.2 phó hiệu trưởng 32
            ThongKeNhaTreViewModel phoHieuTruong = new ThongKeNhaTreViewModel();
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


            //2 tieu chi 33 34
            ThongKeNhaTreViewModel PhohieuTruongNhaTre = new ThongKeNhaTreViewModel();
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

            ThongKeNhaTreViewModel PhohieuTruongMauGiao = new ThongKeNhaTreViewModel();
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

            //4.2 giáo viên 35

            ThongKeNhaTreViewModel giaovien = new ThongKeNhaTreViewModel();
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

            //4.2.1 giáo viên nhà trẻ 36 
            ThongKeNhaTreViewModel giaovienNhaTre = new ThongKeNhaTreViewModel();
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



            //4.2.2 giáo viên mẫu giáo 41
            ThongKeNhaTreViewModel giaovienMauGiao = new ThongKeNhaTreViewModel();
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



            //4.3 giáo viên nghĩ hưu trong năm 46
            ThongKeNhaTreViewModel giaovienNghiHuu = new ThongKeNhaTreViewModel();
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


            // 2 tiêu chí 47 48
            ThongKeNhaTreViewModel giaovienNghiHuuNhaTtre = new ThongKeNhaTreViewModel();
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

            ThongKeNhaTreViewModel giaovienNghiHuuMauGiao = new ThongKeNhaTreViewModel();
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




            //4.5 nhân viên 52
            ThongKeNhaTreViewModel nhanVien = new ThongKeNhaTreViewModel();
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

            // 2 tiêu chí 53 54

            ThongKeNhaTreViewModel nhanVienNhaTre = new ThongKeNhaTreViewModel();
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

            ThongKeNhaTreViewModel nhanVienMauGiao = new ThongKeNhaTreViewModel();
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


            return list;
        }
    }
}
