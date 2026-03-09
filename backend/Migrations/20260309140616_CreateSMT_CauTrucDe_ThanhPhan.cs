using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateSMT_CauTrucDe_ThanhPhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMT_CauTrucDe_ThanhPhans",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cautrucde = table.Column<long>(type: "bigint", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type_answer = table.Column<int>(type: "int", nullable: false),
                    order = table.Column<int>(type: "int", nullable: false),
                    coefficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    is_fixed = table.Column<bool>(type: "bit", nullable: false),
                    created_user_id = table.Column<long>(type: "bigint", nullable: false),
                    created_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_modified_user_id = table.Column<long>(type: "bigint", nullable: true),
                    last_modified_times = table.Column<DateTime>(type: "datetime2", nullable: true),
                    so_cau_hoi = table.Column<int>(type: "int", nullable: false),
                    total_question = table.Column<int>(type: "int", nullable: false),
                    total_score = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMT_CauTrucDe_ThanhPhans", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMT_CauTrucDe_ThanhPhans");
        }
    }
}
