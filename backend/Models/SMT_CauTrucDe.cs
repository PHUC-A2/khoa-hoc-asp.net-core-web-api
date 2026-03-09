namespace backend.Models
{
    public class SMT_CauTrucDe
    {
        public long id { get; set; }

        public long id_mon { get; set; }

        public string name { get; set; } = null!;

        public long id_maudethi { get; set; }

        public bool is_dungtailieu { get; set; }

        public string? note { get; set; }

        public long id_kieuhienthi { get; set; }

        public bool is_trondethi { get; set; }

        public int duration { get; set; }

        public int status { get; set; }

        public bool is_deleted { get; set; }

        public long created_user_id { get; set; }

        public DateTime created_time { get; set; }

        public long? last_modified_user_id { get; set; }

        public DateTime? last_modified_times { get; set; }

        public int order { get; set; }

        public int so_cau_hoi { get; set; }

        public long id_he { get; set; }
    }
}