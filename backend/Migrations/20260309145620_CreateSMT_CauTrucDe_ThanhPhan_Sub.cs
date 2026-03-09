using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateSMT_CauTrucDe_ThanhPhan_Sub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMT_CauTrucDe_ThanhPhan_Subs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cautrucde_thanhphan = table.Column<long>(type: "bigint", nullable: false),
                    id_nhomcauhoi = table.Column<long>(type: "bigint", nullable: false),
                    id_chude = table.Column<long>(type: "bigint", nullable: false),
                    id_mucdo = table.Column<long>(type: "bigint", nullable: false),
                    so_cau = table.Column<int>(type: "int", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false),
                    created_user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_user_id = table.Column<long>(type: "bigint", nullable: true),
                    last_modified_times = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ten_chude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ten_muc_tri_nang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_question = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMT_CauTrucDe_ThanhPhan_Subs", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMT_CauTrucDe_ThanhPhan_Subs");
        }
    }
}
