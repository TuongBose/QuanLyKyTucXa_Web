﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnDBMS.Controllers
{
    public class NguoiDungNhanVienController : Controller
    {
        // GET: NguoiDungNhanVien
        Models.QLKTXDataContext db = new Models.QLKTXDataContext();

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection Data)
        {
            var id = Data["ID"];
            var pass = Data["Pass"];

            bool hasError = false;

            if (String.IsNullOrEmpty(id))
            {
                ViewData["LoiID"] = "ID Nhân viên không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(pass))
            {
                ViewData["LoiPass"] = "Mật khẩu không được bỏ trống";
                hasError = true;
            }

            if (hasError)
                return View();
            else
            {
                Models.NHANVIEN hasAccount = db.NHANVIENs.FirstOrDefault(x => x.ID_NHANVIEN == int.Parse(id) && x.MATKHAU == pass);
                if (hasAccount != null)
                {
                    Session["Account"] = hasAccount;
                    return RedirectToAction("TrangChuNhanVien", "TrangChu");
                }
                else
                    ViewBag.TB = "Sai ID hoặc sai mật khẩu, vui lòng nhập lại";

                return View();
            }
        }

        public ActionResult DangXuat()
        {
            Session["Account"] = null;
            return RedirectToAction("DangNhap","NguoiDungNhanVien");
        }
    }
}