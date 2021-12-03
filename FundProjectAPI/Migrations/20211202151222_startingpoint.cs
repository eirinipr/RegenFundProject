using Microsoft.EntityFrameworkCore.Migrations;

namespace FundProjectAPI.Migrations
{
    public partial class startingpoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundPackage");

            migrationBuilder.CreateTable(
                name: "RewardPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCreatorId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardPackage_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RewardPackage_ProjectCreator_ProjectCreatorId",
                        column: x => x.ProjectCreatorId,
                        principalTable: "ProjectCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCreatorRewardPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCreatorId = table.Column<int>(type: "int", nullable: true),
                    RewardPackageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCreatorRewardPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectCreatorRewardPackage_ProjectCreator_ProjectCreatorId",
                        column: x => x.ProjectCreatorId,
                        principalTable: "ProjectCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectCreatorRewardPackage_RewardPackage_RewardPackageId",
                        column: x => x.RewardPackageId,
                        principalTable: "RewardPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCreatorRewardPackage_ProjectCreatorId",
                table: "ProjectCreatorRewardPackage",
                column: "ProjectCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectCreatorRewardPackage_RewardPackageId",
                table: "ProjectCreatorRewardPackage",
                column: "RewardPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardPackage_ProjectCreatorId",
                table: "RewardPackage",
                column: "ProjectCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardPackage_ProjectId",
                table: "RewardPackage",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectCreatorRewardPackage");

            migrationBuilder.DropTable(
                name: "RewardPackage");

            migrationBuilder.CreateTable(
                name: "FundPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackagePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Reward = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundPackage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundPackage_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundPackage_ProjectId",
                table: "FundPackage",
                column: "ProjectId");
        }
    }
}
