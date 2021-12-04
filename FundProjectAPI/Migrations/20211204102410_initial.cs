using Microsoft.EntityFrameworkCore.Migrations;

namespace FundProjectAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Backer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectCreator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCreator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RewardPackage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reward = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardPackage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    Goal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoalGained = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProjectCreatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_ProjectCreator_ProjectCreatorId",
                        column: x => x.ProjectCreatorId,
                        principalTable: "ProjectCreator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BackerProject",
                columns: table => new
                {
                    BackersId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackerProject", x => new { x.BackersId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_BackerProject_Backer_BackersId",
                        column: x => x.BackersId,
                        principalTable: "Backer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackerProject_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectRewardPackage",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    RewardPackagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRewardPackage", x => new { x.ProjectsId, x.RewardPackagesId });
                    table.ForeignKey(
                        name: "FK_ProjectRewardPackage_Project_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectRewardPackage_RewardPackage_RewardPackagesId",
                        column: x => x.RewardPackagesId,
                        principalTable: "RewardPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackerProject_ProjectsId",
                table: "BackerProject",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectCreatorId",
                table: "Project",
                column: "ProjectCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectRewardPackage_RewardPackagesId",
                table: "ProjectRewardPackage",
                column: "RewardPackagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackerProject");

            migrationBuilder.DropTable(
                name: "ProjectRewardPackage");

            migrationBuilder.DropTable(
                name: "Backer");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "RewardPackage");

            migrationBuilder.DropTable(
                name: "ProjectCreator");
        }
    }
}
