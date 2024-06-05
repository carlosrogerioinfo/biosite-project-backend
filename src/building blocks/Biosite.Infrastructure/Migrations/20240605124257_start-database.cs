using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biosite.Infrastructure.Migrations
{
    public partial class startdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "homolog_biosite_area",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homolog_biosite_area", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "homolog_biosite_biomarker",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Unity = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    BodyImageType = table.Column<short>(type: "smallint", nullable: false),
                    AboveImpact = table.Column<string>(type: "text", nullable: false),
                    BelowImpact = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homolog_biosite_biomarker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "homolog_biosite_organ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Svg = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homolog_biosite_organ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "homolog_biosite_plan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homolog_biosite_plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "homolog_biosite_biomarker_organ",
                columns: table => new
                {
                    BiomarkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homolog_biosite_biomarker_organ", x => new { x.BiomarkerId, x.OrganId });
                    table.ForeignKey(
                        name: "FK_homolog_biosite_biomarker_organ_homolog_biosite_biomarker_BiomarkerId",
                        column: x => x.BiomarkerId,
                        principalTable: "homolog_biosite_biomarker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_homolog_biosite_biomarker_organ_homolog_biosite_organ_OrganId",
                        column: x => x.OrganId,
                        principalTable: "homolog_biosite_organ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "homolog_biosite_plan_area",
                columns: table => new
                {
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homolog_biosite_plan_area", x => new { x.AreaId, x.PlanId });
                    table.ForeignKey(
                        name: "FK_homolog_biosite_plan_area_homolog_biosite_area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "homolog_biosite_area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_homolog_biosite_plan_area_homolog_biosite_plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "homolog_biosite_plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "homolog_biosite_user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    IsPregnant = table.Column<bool>(type: "bit", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    VerificationCode = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: true),
                    ActivationCode = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastAuthorizationCodeRequest = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homolog_biosite_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_homolog_biosite_user_homolog_biosite_plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "homolog_biosite_plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_homolog_biosite_biomarker_organ_OrganId",
                table: "homolog_biosite_biomarker_organ",
                column: "OrganId");

            migrationBuilder.CreateIndex(
                name: "IX_homolog_biosite_plan_area_PlanId",
                table: "homolog_biosite_plan_area",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_homolog_biosite_user_PlanId",
                table: "homolog_biosite_user",
                column: "PlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "homolog_biosite_biomarker_organ");

            migrationBuilder.DropTable(
                name: "homolog_biosite_plan_area");

            migrationBuilder.DropTable(
                name: "homolog_biosite_user");

            migrationBuilder.DropTable(
                name: "homolog_biosite_biomarker");

            migrationBuilder.DropTable(
                name: "homolog_biosite_organ");

            migrationBuilder.DropTable(
                name: "homolog_biosite_area");

            migrationBuilder.DropTable(
                name: "homolog_biosite_plan");
        }
    }
}
