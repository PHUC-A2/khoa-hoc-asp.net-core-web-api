using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateSMT_CauTrucDeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SMT_CauTrucDes",
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
                    table.PrimaryKey("PK_SMT_CauTrucDes", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SMT_CauTrucDes");
        }
    }
}
