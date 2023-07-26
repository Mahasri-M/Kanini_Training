using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depts",
                columns: table => new
                {
                    Deptno = table.Column<int>(type: "int", nullable: false),
                    Ename = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depts", x => x.Deptno);
                });

            migrationBuilder.CreateTable(
                name: "emps",
                columns: table => new
                {
                    EmpNo = table.Column<int>(type: "int", nullable: false),
                    EName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deptno = table.Column<int>(type: "int", nullable: true),
                    DeptnavDeptno = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emps", x => x.EmpNo);
                    table.ForeignKey(
                        name: "FK_emps_Depts_DeptnavDeptno",
                        column: x => x.DeptnavDeptno,
                        principalTable: "Depts",
                        principalColumn: "Deptno");
                });

            migrationBuilder.CreateIndex(
                name: "IX_emps_DeptnavDeptno",
                table: "emps",
                column: "DeptnavDeptno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "emps");

            migrationBuilder.DropTable(
                name: "Depts");
        }
    }
}
