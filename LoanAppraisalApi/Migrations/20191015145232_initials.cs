using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanAppraisalApi.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(600)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    Cellphone = table.Column<string>(type: "nvarchar(13)", nullable: true),
                    EmployeeIDNO = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "inspections",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessRegNo = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Image_ = table.Column<string>(nullable: true),
                    LoaneeAccountNo = table.Column<string>(nullable: true),
                    GPSLAT = table.Column<double>(nullable: true),
                    GPSLONG = table.Column<double>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_inspections_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "loanAppraisalDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoaneeFirstName = table.Column<string>(nullable: true),
                    LoaneeeLastName = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    LoaneeAccount = table.Column<string>(nullable: true),
                    LoaneeIdNo = table.Column<string>(nullable: true),
                    BusinessRegNo = table.Column<string>(nullable: true),
                    LoanAmount = table.Column<double>(nullable: false),
                    ImageOne = table.Column<string>(nullable: true),
                    ImageTwo = table.Column<string>(nullable: true),
                    CurrentGPSLAT = table.Column<double>(nullable: true),
                    CurrentGPSLONG = table.Column<double>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loanAppraisalDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_loanAppraisalDetails_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_inspections_UserId",
                table: "inspections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_loanAppraisalDetails_UserId",
                table: "loanAppraisalDetails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inspections");

            migrationBuilder.DropTable(
                name: "loanAppraisalDetails");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
