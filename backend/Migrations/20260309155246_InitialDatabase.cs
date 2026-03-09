using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMT_CauTrucDe",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_mon = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_maudethi = table.Column<long>(type: "bigint", nullable: false),
                    is_dungtailieu = table.Column<bool>(type: "bit", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_kieuhienthi = table.Column<long>(type: "bigint", nullable: false),
                    is_trondethi = table.Column<bool>(type: "bit", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false),
                    created_user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_user_id = table.Column<long>(type: "bigint", nullable: true),
                    last_modified_times = table.Column<DateTime>(type: "datetime2", nullable: true),
                    order = table.Column<int>(type: "int", nullable: false),
                    so_cau_hoi = table.Column<int>(type: "int", nullable: false),
                    id_he = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMT_CauTrucDe", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SMT_CauTrucDe_ThanhPhan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cautrucde = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_answer = table.Column<int>(type: "int", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false),
                    coefficient = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    is_fixed = table.Column<bool>(type: "bit", nullable: false),
                    created_user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_user_id = table.Column<long>(type: "bigint", nullable: true),
                    last_modified_times = table.Column<DateTime>(type: "datetime2", nullable: true),
                    so_cau_hoi = table.Column<int>(type: "int", nullable: false),
                    total_question = table.Column<int>(type: "int", nullable: false),
                    total_score = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMT_CauTrucDe_ThanhPhan", x => x.id);
                    table.ForeignKey(
                        name: "FK_SMT_CauTrucDe_ThanhPhan_SMT_CauTrucDe_id_cautrucde",
                        column: x => x.id_cautrucde,
                        principalTable: "SMT_CauTrucDe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SMT_CauTrucDe_ThanhPhan_Sub",
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
                    table.PrimaryKey("PK_SMT_CauTrucDe_ThanhPhan_Sub", x => x.id);
                    table.ForeignKey(
                        name: "FK_SMT_CauTrucDe_ThanhPhan_Sub_SMT_CauTrucDe_ThanhPhan_id_cautrucde_thanhphan",
                        column: x => x.id_cautrucde_thanhphan,
                        principalTable: "SMT_CauTrucDe_ThanhPhan",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SMT_CauTrucDe_ThanhPhan_id_cautrucde",
                table: "SMT_CauTrucDe_ThanhPhan",
                column: "id_cautrucde");

            migrationBuilder.CreateIndex(
                name: "IX_SMT_CauTrucDe_ThanhPhan_Sub_id_cautrucde_thanhphan",
                table: "SMT_CauTrucDe_ThanhPhan_Sub",
                column: "id_cautrucde_thanhphan");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMT_CauTrucDe_ThanhPhan_Sub");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SMT_CauTrucDe_ThanhPhan");

            migrationBuilder.DropTable(
                name: "SMT_CauTrucDe");
        }
    }
}
