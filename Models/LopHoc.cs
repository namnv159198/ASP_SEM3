using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP_SEM3.Models
{
    public class LopHoc
    {
        [DisplayName("Mã Sinh Viên")]
        [Required]
        [Key]
        public String MSV { get; set; }
        [Required]
        [DisplayName("Hình Thức Nộp Phạt")]
        public EnumHinhThucNopPhat Hinh_Thuc_Nop_Phat { get; set; }
        public enum EnumHinhThucNopPhat
        {
            [Display(Name = "Chống đẩy")]
            Chong_Day = 1,
            [Display(Name = "Đóng tiền phạt")]
            Nop_Tien = 2,
        }
        [Required]
        [DisplayName("Nộp Phạt")]
        public long NopPhat { get; set; }
        [Required]
        [DisplayName("Ngày Nộp")]
        public DateTime NgayNop { get; set; }
    }
}