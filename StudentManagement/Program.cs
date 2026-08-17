using System;
using TvcLesson1;

namespace TvcLesson1
{
    internal class Student
    {
        public string? MaSv { get; set;}
        public string? HoTen { get; set;}
        public string? NgaySinh { get; set;}
        public string? GioiTinh { get; set;}
        public string? Email { get; set;}
        public string? Sdt { get; set;}
        public string? NganhHoc { get; set;}
        public double DiemTrungBinh { get; set;}
        public string? TrangThaiHocTap { get; set;}
    }
    internal class StudentService
    {
        private List<Student> dssv = new List<Student>();
        public List<Student> Dssv { get => dssv; set => dssv = value; }
        private StudentValidator validator = new StudentValidator();
        public StudentService(StudentValidator validator)
        {
            this.validator = validator;
        }
        public void ThemSv()
        {
            Student sv = new Student();
            Console.WriteLine("Nhap ma sinh vien:");
            sv.MaSv = Console.ReadLine();
            while(sv.MaSv != null && !validator.KiemTraMaSv(dssv, sv.MaSv))
            {
                Console.WriteLine("Ma sinh vien da ton tai. Vui long nhap lai:");
                sv.MaSv = Console.ReadLine();
            }
            Console.WriteLine("Nhap ten sinh vien:");
            sv.HoTen = Console.ReadLine();
            while(sv.HoTen == null)
            {
                Console.WriteLine("Ho ten sinh vien khong duoc de trong. Vui long nhap lai:");
                sv.HoTen = Console.ReadLine();
            }
            Console.WriteLine("Nhap ngay sinh:");
            sv.NgaySinh = Console.ReadLine();
            Console.WriteLine("Nhap gioi tinh:");
            sv.GioiTinh = Console.ReadLine();
            Console.WriteLine("Nhap Email sinh vien:");
            sv.Email = Console.ReadLine();
            while (sv.Email != null && !validator.KiemTraEmail(sv.Email))
            {
                Console.WriteLine("Email khong hop le. Vui long nhap lai:");
                sv.Email = Console.ReadLine();
            }
            Console.WriteLine("Nhap so dien thoai:");
            sv.Sdt = Console.ReadLine();
            Console.WriteLine("Nhap nganh hoc:");
            sv.NganhHoc = Console.ReadLine();
            Console.WriteLine("Nhap diem trung binh:");
            sv.DiemTrungBinh = double.Parse(Console.ReadLine());
            while(!validator.KiemTraDiemTrungBinh(sv.DiemTrungBinh))
            {
                Console.WriteLine("Diem trung binh khong hop le. Vui long nhap lai:");
                sv.DiemTrungBinh = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("Nhap trang thai hoc tap:");
            sv.TrangThaiHocTap = Console.ReadLine();
            dssv.Add(sv);
        }

        public void HienThiDanhSach(List<Student> danhSach)
        {
            string format = "{0,-10} | {1,-22} | {2,-12} | {3,-10} | {4,-28} | {5,-12} | {6,-18} | {7,-5} | {8,-18}";
            Console.WriteLine(format
                            ,"Ma sv","Ho ten","Ngay sinh","Gioi tinh","Email","Sdt","Nganh hoc","DTB","Trang thai hoc tap");
            foreach (Student sv in danhSach)
            {
                Console.WriteLine(format
                         ,sv.MaSv,sv.HoTen,sv.NgaySinh,sv.GioiTinh,sv.Email,sv.Sdt,sv.NganhHoc,sv.DiemTrungBinh,sv.TrangThaiHocTap);
            }
        }

        public void HienThiDanhSach()
        {
            HienThiDanhSach(dssv);
        }

        public Student TimSinhVien(String masv)
        {
            if(masv == null) return null;
            return dssv.FirstOrDefault(sv => sv.MaSv == masv);
        }

        public void TimKiemSinhVienTheoMa(String masv)
        {
            Student sv = TimSinhVien(masv);
            if (sv != null)
            {
                List<Student> ketqua = new List<Student>();
                ketqua.Add(sv);
                HienThiDanhSach(ketqua);
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien co ma: " + masv);
            }
        }

        //Tinh so buoc de chuyen xau 1 sang xau 2
        private int SuaXau(String tensv1, String tensv2)
        {
            int x=tensv1.Length;
            int y=tensv2.Length;
            int[,] dp = new int[x + 1, y + 1];

            for (int i = 0; i < x; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 0; j < y; j++)
            {
                dp[0, j] = j;
            }
            for (int i = 1; i <= x; i++)
            {
                for (int j = 1; j <= y; j++)
                {
                    if (tensv1[i - 1] == tensv2[j - 1] || tensv1[i - 1] + 32 == tensv2[j - 1] || tensv1[i - 1] - 32 == tensv2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                    }
                }
            }
            return dp[x, y];
        }

        public List<Student> TimKiemSinhVien(String tensv)
        {
            List<Student> ketqua = new List<Student>();
            foreach (Student sv in dssv)
            {
                if (SuaXau(sv.HoTen, tensv) <= 2)
                {
                    ketqua.Add(sv);
                }
            }
            return ketqua;
        }

        public void XoaSinhVien(String masv)
        {
            Student sv = TimSinhVien(masv);
            if (sv != null)
            {
                dssv.Remove(sv);
                Console.WriteLine("Xoa sinh vien co ma: " + masv + " thanh cong!");
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien co ma: " + masv);
            }
        }

        public void CapNhatSinhVien(String masv)
        {
            if(validator.KiemTraMaSv(dssv, masv))
            {
                Console.WriteLine("Khong tim thay sinh vien co ma: " + masv);
                return;
            }
            Student sv = TimSinhVien(masv);
            int choice = 0;
            while(choice > 0)
            {
               choice = Console.ReadKey().KeyChar - '0';
                switch (choice) {
                        case 1:
                        Console.WriteLine("Nhap ten sinh vien:");
                        sv.HoTen = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Nhap ngay sinh:");
                        sv.NgaySinh = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Nhap gioi tinh:");
                        sv.GioiTinh = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Nhap Email sinh vien:");
                        sv.Email = Console.ReadLine();
                        break;
                    case 5:
                        Console.WriteLine("Nhap so dien thoai:");
                        sv.Sdt = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("Nhap nganh hoc:");
                        sv.NganhHoc = Console.ReadLine();
                        break;
                    case 7:
                        Console.WriteLine("Nhap diem trung binh:");
                        sv.DiemTrungBinh = double.Parse(Console.ReadLine());
                        break;
                    case 8:
                        Console.WriteLine("Nhap trang thai hoc tap:");
                        sv.TrangThaiHocTap = Console.ReadLine();
                        break;
                }
            }
        }

        public void SapXepSinhVienTheoTen()
        {
            dssv.Sort((sv1, sv2) => sv1.HoTen.CompareTo(sv2.HoTen));
        }

        public void SapXepSinhVienTheoDiem()
        {
            dssv.Sort((sv1, sv2) => sv1.DiemTrungBinh.CompareTo(sv2.DiemTrungBinh));
        }

        public void HienThiSinhVienCoDiemTren8()
        {
            List<Student> ketqua = new List<Student>();
            foreach (Student sv in dssv)
            {
                if (sv.DiemTrungBinh > 8)
                {
                    ketqua.Add(sv);
                }
            }
            HienThiDanhSach(ketqua);
        }

        public void HienThiSinhVienCoDiemCaoNhat()
        {
            List<Student> ketqua = new List<Student>();
            double max = 0;
            foreach (Student sv in dssv)
            {
                if (sv.DiemTrungBinh > max)
                {
                    max = sv.DiemTrungBinh;
                }
            }
            foreach (Student sv in dssv)
            {
                if (sv.DiemTrungBinh == max)
                {
                    ketqua.Add(sv);
                }
            }
            HienThiDanhSach(ketqua);
        }

        public double DiemTrungBinhToanBoSinhVien()
        {
            double sum = 0;
            foreach (Student sv in dssv)
            {
                sum += sv.DiemTrungBinh;
            }
            return sum / dssv.Count;
        }

        public void ThongKeSinhVienTheoNganhHoc()
        {
            Dictionary<string, int> ketqua = new Dictionary<string, int>();
            foreach (Student sv in dssv)
            {
                if (ketqua.ContainsKey(sv.NganhHoc))
                {
                    ketqua[sv.NganhHoc]++;
                }
                else
                {
                    ketqua[sv.NganhHoc] = 1;
                }
            }
            Console.WriteLine("Thong ke sinh vien theo nganh hoc:");
            foreach (var item in ketqua)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
        public void ThongKeSinhVienTheoTrangThaiHocTap()
        {
            Dictionary<string, int> ketqua = new Dictionary<string, int>();
            foreach (Student sv in dssv)
            {
                if (ketqua.ContainsKey(sv.TrangThaiHocTap))
                {
                    ketqua[sv.TrangThaiHocTap]++;
                }
                else
                {
                    ketqua[sv.TrangThaiHocTap] = 1;
                }
            }
            Console.WriteLine("Thong ke sinh vien theo trang thai hoc tap:");
            foreach (var item in ketqua)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }

    internal class StudentValidator
    {
        public bool KiemTraMaSv(List<Student> dssv, string masv)
        {
            foreach (Student sv in dssv)
            {
                if (sv.MaSv == masv)
                {
                    return false;
                }
            }
            return true;
        }
        public bool KiemTraEmail(string email)
        {
            if (!email.Contains("@"))
            {
                return false;
            }
            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }
            if (!parts[1].Contains("."))
            {
                return false;
            }
            return true;
        }
        public bool KiemTraDiemTrungBinh(double diem)
        {
            if (diem < 0 || diem > 10)
            {
                return false;
            }
            return true;
        }
    }
    internal class StudentConSoleView
    {
        public void HienThiMenu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Hien thi danh sach sinh vien");
            Console.WriteLine("3. Tim kiem sinh vien theo ma");
            Console.WriteLine("4. Tim kiem sinh vien theo ten");
            Console.WriteLine("5. Xoa sinh vien");
            Console.WriteLine("6. Cap nhat sinh vien");
            Console.WriteLine("7. Sap xep sinh vien theo ten");
            Console.WriteLine("8. Sap xep sinh vien theo diem trung binh");
            Console.WriteLine("9. Hien thi sinh vien co diem trung binh tren 8");
            Console.WriteLine("10. Hien thi sinh vien co diem trung binh cao nhat");
            Console.WriteLine("11. Thong ke sinh vien theo nganh hoc");
            Console.WriteLine("12. Thong ke sinh vien theo trang thai hoc tap");
            Console.WriteLine("0. Thoat");
        }
        public void UpdateStudentMenu()
        {
            Console.WriteLine("================================");
            Console.WriteLine("1. Cap nhat ten sinh vien");
            Console.WriteLine("2. Cap nhat ngay sinh");
            Console.WriteLine("3. Cap nhat gioi tinh");
            Console.WriteLine("4. Cap nhat email");
            Console.WriteLine("5. Cap nhat so dien thoai");
            Console.WriteLine("6. Cap nhat nganh hoc");
            Console.WriteLine("7. Cap nhat diem trung binh");
            Console.WriteLine("8. Cap nhat trang thai hoc tap");
            Console.WriteLine("0. Thoat");
        }
    }
    internal class MenuManager
    {
        private StudentService studentService;
        private StudentConSoleView studentConSoleView;
        public MenuManager(StudentService studentService, StudentConSoleView studentConSoleView)
        {
            this.studentService = studentService;
            this.studentConSoleView = studentConSoleView;
        }
        public void Run()
        {
            int choice = -1;
            while (choice != 0)
            {
                studentConSoleView.HienThiMenu();
                Console.WriteLine("Nhap lua chon cua ban:");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("================================");
                switch (choice)
                {
                    case 1:
                        studentService.ThemSv();
                        break;
                    case 2:
                        studentService.HienThiDanhSach();
                        break;
                    case 3:
                        Console.WriteLine("Nhap ma sinh vien can tim:");
                        string masv = Console.ReadLine();
                        studentService.TimKiemSinhVienTheoMa(masv);
                        break;
                    case 4:
                        Console.WriteLine("Nhap ten sinh vien can tim:");
                        string tensv = Console.ReadLine();
                        List<Student> ketqua = studentService.TimKiemSinhVien(tensv);
                        studentService.HienThiDanhSach(ketqua);
                        break;
                    case 5:
                        Console.WriteLine("Nhap ma sinh vien can xoa:");
                        string masv1 = Console.ReadLine();
                        studentService.XoaSinhVien(masv1);
                        break;
                    case 6:
                        studentConSoleView.UpdateStudentMenu();
                        Console.WriteLine("Nhap ma sinh vien can cap nhat:");
                        string masv2 = Console.ReadLine();
                        studentService.CapNhatSinhVien(masv2);
                        break;
                    case 7:
                        studentService.SapXepSinhVienTheoTen();
                        break;
                    case 8:
                        studentService.SapXepSinhVienTheoDiem();
                        break;
                    case 9:
                        studentService.HienThiSinhVienCoDiemTren8();
                        break;
                    case 10:
                        studentService.HienThiSinhVienCoDiemCaoNhat();
                        break;
                    case 11:
                        studentService.ThongKeSinhVienTheoNganhHoc();
                        break;
                    case 12:
                        studentService.ThongKeSinhVienTheoTrangThaiHocTap();
                        break;
                }
            }
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            MenuManager menuManager = new MenuManager(new StudentService(new StudentValidator()), new StudentConSoleView());
            menuManager.Run();
        }
    }
}
