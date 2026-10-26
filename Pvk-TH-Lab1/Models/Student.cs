using System.ComponentModel.DataAnnotations;

namespace Pvk_TH_Lab1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage =("Họ tên không được bỏ trống"))]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Email bắt buộc phải được nhập")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@gmail\.com",ErrorMessage ="Email phải có đuôi gmail.com")]
        public string? Email { get; set; }

        [StringLength(100,MinimumLength = 8,ErrorMessage = "Mật khẩu phải có độ dài tối thiểu là 8")]
        [RegularExpression(@"(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[.!%@?#$^&*]).{6,}")]
        [Required(ErrorMessage ="Mật khẩu Không được bỏ trống")]
        public string? Password { get; set; }

        [Required(ErrorMessage =("Chi nhánh không được bỏ trống"))]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage ="Giới không được bỏ trống")]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage ="Địa chỉ không được bỏ trống")]
        public string? Address { get; set; }

        [Range(typeof(DateTime),"1/1/1963","31/12/2008")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Ngày sinh không được để trống")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage ="Điểm không được bỏ trống")]
        [Range(0.0,10.0,ErrorMessage =("Điểm phải nằm trong khoảng từ 0.0 đến 10.0"))]
        public float? Diem {  get; set; }
    }
}
