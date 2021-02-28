using Microsoft.EntityFrameworkCore.Migrations;

namespace JobPortal.Migrations
{
    public partial class addingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecruiterDetails_UserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "JobDetails",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Eligibility = table.Column<string>(nullable: true),
                    SkillsRequired = table.Column<string>(nullable: true),
                    MinimumExperienceRequired = table.Column<string>(nullable: true),
                    PostedRecruiterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_JobDetails_AspNetUsers_PostedRecruiterId",
                        column: x => x.PostedRecruiterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualificationDetails",
                columns: table => new
                {
                    QualificationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantDetailsId = table.Column<string>(nullable: true),
                    TenthPercentage = table.Column<int>(nullable: false),
                    TwelthPercentage = table.Column<int>(nullable: false),
                    HighestQualifcation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationDetails", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_QualificationDetails_AspNetUsers_ApplicantDetailsId",
                        column: x => x.ApplicantDetailsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantJobsRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<string>(nullable: true),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantJobsRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantJobsRelation_AspNetUsers_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicantJobsRelation_JobDetails_JobId",
                        column: x => x.JobId,
                        principalTable: "JobDetails",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RecruiterDetails_UserId",
                table: "AspNetUsers",
                column: "RecruiterDetails_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJobsRelation_ApplicantId",
                table: "ApplicantJobsRelation",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJobsRelation_JobId",
                table: "ApplicantJobsRelation",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobDetails_PostedRecruiterId",
                table: "JobDetails",
                column: "PostedRecruiterId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationDetails_ApplicantDetailsId",
                table: "QualificationDetails",
                column: "ApplicantDetailsId",
                unique: true,
                filter: "[ApplicantDetailsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_UserId",
                table: "AspNetUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_RecruiterDetails_UserId",
                table: "AspNetUsers",
                column: "RecruiterDetails_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_RecruiterDetails_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ApplicantJobsRelation");

            migrationBuilder.DropTable(
                name: "QualificationDetails");

            migrationBuilder.DropTable(
                name: "JobDetails");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RecruiterDetails_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RecruiterDetails_UserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
