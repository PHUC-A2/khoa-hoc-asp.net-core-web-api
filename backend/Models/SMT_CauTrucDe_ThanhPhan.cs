namespace backend.Models
{
    public class SMT_CauTrucDe_ThanhPhan
    {
        public long id { get; set; }

        public long id_cautrucde { get; set; }

        public string? note { get; set; }

        public int type_answer { get; set; }

        public int order { get; set; }

        public decimal coefficient { get; set; }

        public bool is_fixed { get; set; }

        public long created_user_id { get; set; }

        public DateTime created_time { get; set; }

        public long? last_modified_user_id { get; set; }

        public DateTime? last_modified_times { get; set; }

        public int so_cau_hoi { get; set; }

        public int total_question { get; set; }

        public decimal total_score { get; set; }
    }
}