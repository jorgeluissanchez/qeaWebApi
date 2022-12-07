using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace qeawebapi.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CourseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subject_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Statement = table.Column<string>(type: "text", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uuid", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_question_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Statement = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_answer_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "explanation_note",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_explanation_note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_explanation_note_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "explanation_video",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Visible = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_explanation_video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_explanation_video_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "Description", "Name", "Visible" },
                values: new object[] { new Guid("00000001-0000-0000-0000-000000000001"), "Category 1 description", "Category 1", true });

            migrationBuilder.InsertData(
                table: "course",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Visible" },
                values: new object[] { new Guid("00000002-0000-0000-0000-000000000001"), new Guid("00000001-0000-0000-0000-000000000001"), "Course 1 description", "Course 1", true });

            migrationBuilder.InsertData(
                table: "subject",
                columns: new[] { "Id", "CourseId", "Description", "Name", "Visible" },
                values: new object[] { new Guid("00000002-0000-0000-0000-000000000001"), new Guid("00000002-0000-0000-0000-000000000001"), "Subject 1 description", "Subject 1", true });

            migrationBuilder.InsertData(
                table: "question",
                columns: new[] { "Id", "Statement", "SubjectId", "Visible" },
                values: new object[] { new Guid("00000000-0000-0001-0001-000000000001"), "Question 1", new Guid("00000002-0000-0000-0000-000000000001"), true });

            migrationBuilder.InsertData(
                table: "answer",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Statement", "Visible" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), true, new Guid("00000000-0000-0001-0001-000000000001"), "Answer 1", true },
                    { new Guid("00000000-0000-0000-0000-000000000002"), false, new Guid("00000000-0000-0001-0001-000000000001"), "Answer 2", true },
                    { new Guid("00000000-0000-0000-0000-000000000003"), false, new Guid("00000000-0000-0001-0001-000000000001"), "Answer 3", true },
                    { new Guid("00000000-0000-0000-0000-000000000004"), false, new Guid("00000000-0000-0001-0001-000000000001"), "Answer 4", true }
                });

            migrationBuilder.InsertData(
                table: "explanation_note",
                columns: new[] { "Id", "QuestionId", "Url", "Visible" },
                values: new object[] { new Guid("00000003-0001-0000-0000-000000000001"), new Guid("00000000-0000-0001-0001-000000000001"), "https://www.w3schools.com/images/w3schools_green.jpg", true });

            migrationBuilder.InsertData(
                table: "explanation_video",
                columns: new[] { "Id", "QuestionId", "Url", "Visible" },
                values: new object[] { new Guid("00000003-0002-0000-0000-000000000001"), new Guid("00000000-0000-0001-0001-000000000001"), "https://www.youtube.com/watch?v=1", true });

            migrationBuilder.CreateIndex(
                name: "IX_answer_QuestionId",
                table: "answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_course_CategoryId",
                table: "course",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_explanation_note_QuestionId",
                table: "explanation_note",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_explanation_video_QuestionId",
                table: "explanation_video",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_question_SubjectId",
                table: "question",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_subject_CourseId",
                table: "subject",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "answer");

            migrationBuilder.DropTable(
                name: "explanation_note");

            migrationBuilder.DropTable(
                name: "explanation_video");

            migrationBuilder.DropTable(
                name: "question");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "course");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
