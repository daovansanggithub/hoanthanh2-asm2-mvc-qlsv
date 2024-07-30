using Microsoft.AspNetCore.Mvc;
using Student_manager_mvc.Models;
using System.Diagnostics;

namespace Student_manager_mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        QuanLySinhVienMvcContext db = new QuanLySinhVienMvcContext();
        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult manager_student()
        {
            // khai báo list , 
            List<SinhVien> students = new List<SinhVien>();
            students = db.SinhViens.ToList();

			// Truyền danh sách học sinh tới View để hiển thị
			return View(students);
			
        }

        // quan li tai khoan
        public IActionResult manager_account()
        {
            // khai báo list , 
            List<TaiKhoan> tk = new List<TaiKhoan>();
            tk = db.TaiKhoans.ToList();

            // Truyền danh sách học sinh tới View để hiển thị
            return View(tk);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
