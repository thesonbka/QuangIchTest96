using DataAccess.IRepository;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class ThongkeNhaTreRepository
    {
        public List<ThongKeNhaTreViewModel> getPageTruong(string maPhongGD)
        {
            List<ThongKeNhaTreViewModel> list = new List<ThongKeNhaTreViewModel>();
            var context = new BO_GIAO_DUC_TEMPEntities();

            //I. Trường
           
                ThongKeNhaTreViewModel modelRow1 = new ThongKeNhaTreViewModel();
            modelRow1.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA_PHONG_GD == maPhongGD
                                     && obj.DS_CAP_HOC == "01"
                                     select 1).Count();
            modelRow1.TongSoCongLap = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" &&obj.MA_LOAI_HINH_TRUONG=="01"
                                      select 1).Count();
            modelRow1.TongSoTuThuc = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "09"
                                      select 1).Count();
            modelRow1.TongSoDanLap = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "03"
                                      select 1).Count();
            list.Add(modelRow1);
            //Nhà trẻ
                ThongKeNhaTreViewModel modelRow2 = new ThongKeNhaTreViewModel();

            modelRow2.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA_PHONG_GD == maPhongGD
                                     && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC=="03" 
                                     select 1).Count();
            modelRow2.TongSoCongLap = (from obj in context.TRUONGs
                                       where obj.MA_PHONG_GD == maPhongGD
                                       && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "01" && obj.MA_NHOM_CAP_HOC == "03"
                                       select 1).Count();
            modelRow2.TongSoTuThuc = (from obj in context.TRUONGs
                                       where obj.MA_PHONG_GD == maPhongGD
                                       && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "09" && obj.MA_NHOM_CAP_HOC == "03"
                                       select 1).Count();
            modelRow2.TongSoDanLap = (from obj in context.TRUONGs
                                       where obj.MA_PHONG_GD == maPhongGD
                                       && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "03" && obj.MA_NHOM_CAP_HOC == "03"
                                       select 1).Count();
            list.Add(modelRow2);
            //Trường mẫu giáo

                ThongKeNhaTreViewModel modelRow3 = new ThongKeNhaTreViewModel();

            modelRow3.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA_PHONG_GD == maPhongGD
                                     && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC == "02"
                                     select 1).Count();
            modelRow3.TongSoCongLap = (from obj in context.TRUONGs
                                       where obj.MA_PHONG_GD == maPhongGD
                                       && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "01" && obj.MA_NHOM_CAP_HOC == "02"
                                       select 1).Count();
            modelRow3.TongSoTuThuc = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "09" && obj.MA_NHOM_CAP_HOC == "02"
                                      select 1).Count();
            modelRow3.TongSoDanLap = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "03" && obj.MA_NHOM_CAP_HOC == "02"
                                      select 1).Count();
            list.Add(modelRow3);

            //Trường mầm non

            ThongKeNhaTreViewModel modelRow4 = new ThongKeNhaTreViewModel();

            modelRow4.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA_PHONG_GD == maPhongGD
                                     && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC == "01"
                                     select 1).Count();
            modelRow4.TongSoCongLap = (from obj in context.TRUONGs
                                       where obj.MA_PHONG_GD == maPhongGD
                                       && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "01" && obj.MA_NHOM_CAP_HOC == "01"
                                       select 1).Count();
            modelRow4.TongSoTuThuc = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "09" && obj.MA_NHOM_CAP_HOC == "01"
                                      select 1).Count();
            modelRow4.TongSoDanLap = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "03" && obj.MA_NHOM_CAP_HOC == "01"
                                      select 1).Count();
            list.Add(modelRow4);

            //nhóm trẻ độc lập


            ThongKeNhaTreViewModel modelRow5 = new ThongKeNhaTreViewModel();

            modelRow5.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA_PHONG_GD == maPhongGD
                                     && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC == "04"
                                     select 1).Count();
            modelRow5.TongSoCongLap = (from obj in context.TRUONGs
                                       where obj.MA_PHONG_GD == maPhongGD
                                       && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "01" && obj.MA_NHOM_CAP_HOC == "04"
                                       select 1).Count();
            modelRow5.TongSoTuThuc = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "09" && obj.MA_NHOM_CAP_HOC == "04"
                                      select 1).Count();
            modelRow5.TongSoDanLap = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "03" && obj.MA_NHOM_CAP_HOC == "04"
                                      select 1).Count();
            list.Add(modelRow5);

            //lớp mẫu giáo độc lập

            ThongKeNhaTreViewModel modelRow6 = new ThongKeNhaTreViewModel();

            modelRow6.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA_PHONG_GD == maPhongGD
                                     && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC == "05"
                                     select 1).Count();
            modelRow6.TongSoCongLap = (from obj in context.TRUONGs
                                       where obj.MA_PHONG_GD == maPhongGD
                                       && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "01" && obj.MA_NHOM_CAP_HOC == "05"
                                       select 1).Count();
            modelRow6.TongSoTuThuc = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "09" && obj.MA_NHOM_CAP_HOC == "05"
                                      select 1).Count();
            modelRow6.TongSoDanLap = (from obj in context.TRUONGs
                                      where obj.MA_PHONG_GD == maPhongGD
                                      && obj.DS_CAP_HOC == "01" && obj.MA_LOAI_HINH_TRUONG == "03" && obj.MA_NHOM_CAP_HOC == "05"
                                      select 1).Count();
            list.Add(modelRow6);

            //Nhóm trẻ lớp mẫu giáo độc lập
            ThongKeNhaTreViewModel modelRow7 = new ThongKeNhaTreViewModel();
            modelRow7.TongSoTotal = 0;
            modelRow7.TongSoCongLap = 0;
            modelRow7.TongSoTuThuc = 0;
            modelRow7.TongSoDanLap = 0;
            list.Add(modelRow7);

            //Số điểm trường
            ThongKeNhaTreViewModel modelRow8 = new ThongKeNhaTreViewModel();
            modelRow8.TongSoTotal = (from obj in context.TRUONGs
                                     where obj.MA_PHONG_GD == maPhongGD
                                     && obj.DS_CAP_HOC == "01" && obj.MA_NHOM_CAP_HOC == "05"
                                     select 1).Count();
            list.Add(modelRow8);
            return list;
        }
    }
}
