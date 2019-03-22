using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizTime.Migrations.AppDb
{
    public partial class InitialQuiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListOfQuizzes",
                columns: table => new
                {
                    QuizModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListOfQuizzes", x => x.QuizModelID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionModel",
                columns: table => new
                {
                    QuestionModelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    QuestionFormulation = table.Column<string>(nullable: true),
                    CorrectAnswer = table.Column<string>(nullable: true),
                    WrongAnswer = table.Column<string>(nullable: true),
                    QuizModelID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionModel", x => x.QuestionModelID);
                    table.ForeignKey(
                        name: "FK_QuestionModel_ListOfQuizzes_QuizModelID",
                        column: x => x.QuizModelID,
                        principalTable: "ListOfQuizzes",
                        principalColumn: "QuizModelID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionModel_QuizModelID",
                table: "QuestionModel",
                column: "QuizModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionModel");

            migrationBuilder.DropTable(
                name: "ListOfQuizzes");
        }
    }
}
