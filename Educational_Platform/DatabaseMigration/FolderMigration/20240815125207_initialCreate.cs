using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Educational_Platform.DatabaseMigration.FolderMigration
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Educational_Platform");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Post_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "Educational_Platform",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interests = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "Educational_Platform",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AcademicDegree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teacher_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "Educational_Platform",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(type: "int", nullable: false),
                    UserID_ForComment = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostID",
                        column: x => x.PostID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Post",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "Educational_Platform",
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Course",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Teacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID_ForRating = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: true),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    RatingValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    View = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rating_Student_StudentID",
                        column: x => x.StudentID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Teacher",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID_ForCourseStudent = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    JoinDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Course_CourseID",
                        column: x => x.CourseID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Student_StudentID",
                        column: x => x.StudentID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Student",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    TeacherID_ForCourseTeacher = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Course_CourseID",
                        column: x => x.CourseID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Teacher_TeacherID",
                        column: x => x.TeacherID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Teacher",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SenderID_ForMessage = table.Column<int>(type: "int", nullable: false),
                    SenderID = table.Column<int>(type: "int", nullable: true),
                    ReceiverID_ForMessage = table.Column<int>(type: "int", nullable: false),
                    ReceiverID = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Message_Course_CourseID",
                        column: x => x.CourseID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_User_ReceiverID",
                        column: x => x.ReceiverID,
                        principalSchema: "Educational_Platform",
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Message_User_SenderID",
                        column: x => x.SenderID,
                        principalSchema: "Educational_Platform",
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID_ForRegistration = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: true),
                    RegisterationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Registration_Course_CourseID",
                        column: x => x.CourseID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Student_StudentID",
                        column: x => x.StudentID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Student",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Scheduling",
                schema: "Educational_Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseTeacherID = table.Column<int>(type: "int", nullable: false),
                    RegisterID = table.Column<int>(type: "int", nullable: false),
                    RegistrationID = table.Column<int>(type: "int", nullable: true),
                    ConflictStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suggestions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndHour = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduling", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Scheduling_CourseTeacher_CourseTeacherID",
                        column: x => x.CourseTeacherID,
                        principalSchema: "Educational_Platform",
                        principalTable: "CourseTeacher",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scheduling_Registration_RegistrationID",
                        column: x => x.RegistrationID,
                        principalSchema: "Educational_Platform",
                        principalTable: "Registration",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostID",
                schema: "Educational_Platform",
                table: "Comment",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserID",
                schema: "Educational_Platform",
                table: "Comment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherID",
                schema: "Educational_Platform",
                table: "Course",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_CourseID",
                schema: "Educational_Platform",
                table: "CourseStudent",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentID",
                schema: "Educational_Platform",
                table: "CourseStudent",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_CourseID",
                schema: "Educational_Platform",
                table: "CourseTeacher",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeacherID",
                schema: "Educational_Platform",
                table: "CourseTeacher",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_CourseID",
                schema: "Educational_Platform",
                table: "Message",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_ReceiverID",
                schema: "Educational_Platform",
                table: "Message",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Message_SenderID",
                schema: "Educational_Platform",
                table: "Message",
                column: "SenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserID",
                schema: "Educational_Platform",
                table: "Post",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_StudentID",
                schema: "Educational_Platform",
                table: "Rating",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_TeacherID",
                schema: "Educational_Platform",
                table: "Rating",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_CourseID",
                schema: "Educational_Platform",
                table: "Registration",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_StudentID",
                schema: "Educational_Platform",
                table: "Registration",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_CourseTeacherID",
                schema: "Educational_Platform",
                table: "Scheduling",
                column: "CourseTeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_RegistrationID",
                schema: "Educational_Platform",
                table: "Scheduling",
                column: "RegistrationID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserID",
                schema: "Educational_Platform",
                table: "Student",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_UserID",
                schema: "Educational_Platform",
                table: "Teacher",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "CourseStudent",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "Message",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "Rating",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "Scheduling",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "CourseTeacher",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "Registration",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "Course",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "Teacher",
                schema: "Educational_Platform");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Educational_Platform");
        }
    }
}
