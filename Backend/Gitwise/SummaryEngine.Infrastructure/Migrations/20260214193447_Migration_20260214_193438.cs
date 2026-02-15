using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SummaryEngine.Adapter.Github.Migrations
{
    /// <inheritdoc />
    public partial class Migration_20260214_193438 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkSummaries",
                columns: table => new
                {
                    WorkSummaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeveloperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SummaryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    SummaryText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastCommitSha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastCommitTimestamp = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CommitCount = table.Column<int>(type: "int", nullable: false),
                    GeneratedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSummaries", x => x.WorkSummaryId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkSummaries");
        }
    }
}
