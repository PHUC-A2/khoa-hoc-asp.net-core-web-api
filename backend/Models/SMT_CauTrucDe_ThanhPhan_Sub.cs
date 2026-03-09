using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("SMT_CauTrucDe_ThanhPhan_Sub")]
    public class SMT_CauTrucDe_ThanhPhan_Sub
    {
        [Key]
        public long id { get; set; }

        public long id_cautrucde_thanhphan { get; set; }

        public long id_nhomcauhoi { get; set; }

        public long id_chude { get; set; }

        public long id_mucdo { get; set; }

        public int so_cau { get; set; }

        public int order { get; set; }

        public long created_user_id { get; set; }

        public DateTime created_time { get; set; }

        public long? last_modified_user_id { get; set; }

        public DateTime? last_modified_times { get; set; }

        public string? ten_chude { get; set; }

        public string? ten_muc_tri_nang { get; set; }

        public int total_question { get; set; }

        // Relationship
        [ForeignKey("id_cautrucde_thanhphan")]
        public SMT_CauTrucDe_ThanhPhan? ThanhPhan { get; set; }
    }
}