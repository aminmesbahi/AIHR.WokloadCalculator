using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIHR.WorkloadCalculator.Service.Data.Migrations
{
    public partial class InitDatatbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SuggestedDailyStudyHours = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalculationHistoryCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WorkloadCalculateHistoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationHistoryCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalculationHistoryCourses_CalculationHistory_WorkloadCalculateHistoryId",
                        column: x => x.WorkloadCalculateHistoryId,
                        principalTable: "CalculationHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 1, 8, "Blockchain and HR" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 2, 32, "Compensation & Benefits" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 3, 40, "Digital HR" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 4, 10, "Digital HR Strategy" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 5, 8, "Digital HR Transformation" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 6, 20, "Diversity & Inclusion" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 7, 12, "Employee Experience & Design Thinking" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 8, 6, "Employer Branding" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 9, 12, "Global Data Integrity" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 10, 15, "Hiring & Recruitment Strategy" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 11, 21, "HR Analytics Leader" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 12, 40, "HR Business Partner 2.0" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 13, 18, "HR Data Analyst" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 14, 12, "HR Data Science in R" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 15, 12, "HR Data Visualization" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 16, 40, "HR Metrics & Reporting" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 17, 30, "Learning & Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 18, 30, "Organizational Development" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 19, 40, "People Analytics" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 20, 15, "Statistics in HR" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 21, 34, "Strategic HR Leadership" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 22, 17, "Strategic HR Metrics" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Duration", "Name" },
                values: new object[] { 23, 40, "Talent Acquisition" });

            migrationBuilder.CreateIndex(
                name: "IX_CalculationHistoryCourses_WorkloadCalculateHistoryId",
                table: "CalculationHistoryCourses",
                column: "WorkloadCalculateHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationHistoryCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "CalculationHistory");
        }
    }
}
