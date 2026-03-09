using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.request.SMT_CauTrucDe
{
    public class ReqCreateSMT_CauTrucDeDTO
    {
        [Required(ErrorMessage = "Môn học không được để trống")]
        public long id_mon { get; set; }

        [Required(ErrorMessage = "Tên cấu trúc đề không được để trống")]
        public string name { get; set; } = null!;

        [Required(ErrorMessage = "Mẫu đề thi không được để trống")]
        public long id_maudethi { get; set; }

        public bool is_dungtailieu { get; set; }

        public string? note { get; set; }

        [Required(ErrorMessage = "Kiểu hiển thị không được để trống")]
        public long id_kieuhienthi { get; set; }

        public bool is_trondethi { get; set; }

        [Required(ErrorMessage = "Thời gian làm bài không được để trống")]
        public int duration { get; set; }

        public int status { get; set; }

        public int order { get; set; }

        [Required(ErrorMessage = "Số câu hỏi không được để trống")]
        public int so_cau_hoi { get; set; }

        [Required(ErrorMessage = "Hệ đào tạo không được để trống")]
        public long id_he { get; set; }
    }
}