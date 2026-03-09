using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.request.SMT_CauTrucDe
{
    public class ReqUpdateSMT_CauTrucDe_Thanh_PhanDTO
    {
        [Required(ErrorMessage = "Cấu trúc đề không được để trống")]
        public long id_cautrucde { get; set; }

        public string? note { get; set; }

        [Required(ErrorMessage = "Loại câu trả lời không được để trống")]
        public int type_answer { get; set; }

        [Required(ErrorMessage = "Thứ tự không được để trống")]
        public int order { get; set; }

        [Required(ErrorMessage = "Hệ số điểm không được để trống")]
        public decimal coefficient { get; set; }

        public bool is_fixed { get; set; }

        [Required(ErrorMessage = "Số câu hỏi không được để trống")]
        public int so_cau_hoi { get; set; }

        public int total_question { get; set; }

        [Required(ErrorMessage = "Tổng điểm không được để trống")]
        public decimal total_score { get; set; }
    }
}