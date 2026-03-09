using System.ComponentModel.DataAnnotations;

namespace backend.DTOs.request.SMT_CauTrucDe
{
    public class ReqUpdateSMT_CauTrucDe_ThanhPhan_SubDTO
    {
        [Required(ErrorMessage = "Thành phần cấu trúc đề không được để trống")]
        public long id_cautrucde_thanhphan { get; set; }

        [Required(ErrorMessage = "Nhóm câu hỏi không được để trống")]
        public long id_nhomcauhoi { get; set; }

        [Required(ErrorMessage = "Chủ đề không được để trống")]
        public long id_chude { get; set; }

        [Required(ErrorMessage = "Mức độ không được để trống")]
        public long id_mucdo { get; set; }

        [Required(ErrorMessage = "Số câu không được để trống")]
        public int so_cau { get; set; }

        [Required(ErrorMessage = "Thứ tự không được để trống")]
        public int order { get; set; }

        public string? ten_chude { get; set; }

        public string? ten_muc_tri_nang { get; set; }

        public int total_question { get; set; }
    }
}