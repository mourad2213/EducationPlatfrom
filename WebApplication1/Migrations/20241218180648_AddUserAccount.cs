using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)

        {

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber2 = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceLevel = table.Column<int>(type: "int", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Badges",
                columns: table => new
                {
                    Badge_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Badge_Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Badge_Points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Badges__3326E30430BC55B3", x => x.Badge_ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Course_Credit_Hours = table.Column<int>(type: "int", nullable: true),
                    Course_Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Difficulty_Level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__37E005FB8902CD41", x => x.Course_ID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    Instructor_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instructor_Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Expertise_Areas = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Qualifications = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instruct__DD4B9A8AFFF401BE", x => x.Instructor_ID);
                });

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    Quest_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Difficulty_Level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Criteria = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Quests__6D9E739BABC867A3", x => x.Quest_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseLearningObjectives",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    LearningObjective = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseLe__47FAD9E8B6A45399", x => new { x.Course_ID, x.LearningObjective });
                    table.ForeignKey(
                        name: "FK__CourseLea__Cours__5812160E",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                });

            migrationBuilder.CreateTable(
                name: "CoursePrerequisites",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Prerequisite = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CoursePr__37E005FBEF28DC3C", x => x.Course_ID);
                    table.ForeignKey(
                        name: "FK__CoursePre__Cours__5535A963",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                });

            migrationBuilder.CreateTable(
                name: "Leaderboards",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Board_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPoints = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Leaderbo__36217AA16016EB39", x => new { x.Course_ID, x.Board_ID });
                    table.ForeignKey(
                        name: "FK__Leaderboa__Cours__49C3F6B7",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Module_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level_of_Difficulty = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Content_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Course_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modules__1DE4E028290D4F85", x => x.Module_ID);
                    table.ForeignKey(
                        name: "FK__Modules__Course___5BE2A6F2",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                });

            migrationBuilder.CreateTable(
                name: "CoursesInstructor",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Instructor_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CoursesI__8A34BC5381155A32", x => new { x.Course_ID, x.Instructor_ID });
                    table.ForeignKey(
                        name: "FK__CoursesIn__Cours__46B27FE2",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                    table.ForeignKey(
                        name: "FK__CoursesIn__Instr__47A6A41B",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructor",
                        principalColumn: "Instructor_ID");
                });

            migrationBuilder.CreateTable(
                name: "InstructorEmail",
                columns: table => new
                {
                    Instructor_ID = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Instruct__97D68AD9EB79A6D2", x => new { x.Instructor_ID, x.Email });
                    table.ForeignKey(
                        name: "FK__Instructo__Instr__2BFE89A6",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructor",
                        principalColumn: "Instructor_ID");
                });

            migrationBuilder.CreateTable(
                name: "CollaborativeQuest",
                columns: table => new
                {
                    Quest_ID = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    Max_Participants = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Collabor__6D9E739B6FD09241", x => x.Quest_ID);
                    table.ForeignKey(
                        name: "FK__Collabora__Quest__123EB7A3",
                        column: x => x.Quest_ID,
                        principalTable: "Quests",
                        principalColumn: "Quest_ID");
                });

            migrationBuilder.CreateTable(
                name: "SkillMasteryQuest",
                columns: table => new
                {
                    Quest_ID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Skills_To_Be_Mastered = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SkillMas__6D9E739BF5EEE563", x => x.Quest_ID);
                    table.ForeignKey(
                        name: "FK__SkillMast__Quest__0F624AF8",
                        column: x => x.Quest_ID,
                        principalTable: "Quests",
                        principalColumn: "Quest_ID");
                });

            migrationBuilder.CreateTable(
                name: "Learner",
                columns: table => new
                {
                    Learner_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Learner_Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Learner_Gender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Country_of_Origin = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Experience_Level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Learner_Age = table.Column<int>(type: "int", nullable: true, computedColumnSql: "(datepart(year,getdate())-datepart(year,[Learner_Birthday_Date]))", stored: false),
                    Learner_Birthday_Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: true),
                    Board_ID = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learner__3DE277FF83027DBD", x => x.Learner_ID);
                    table.ForeignKey(
                        name: "FK_Learner_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Learner__4D94879B",
                        columns: x => new { x.Course_ID, x.Board_ID },
                        principalTable: "Leaderboards",
                        principalColumns: new[] { "Course_ID", "Board_ID" });
                    table.ForeignKey(
                        name: "FK__Learner__Course___4CA06362",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Assessment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grading_Criteria = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Max_Score = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Course_ID = table.Column<int>(type: "int", nullable: true),
                    Instructor_ID = table.Column<int>(type: "int", nullable: true),
                    Module_ID = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Assessme__6B3C1D928095953C", x => x.Assessment_ID);
                    table.ForeignKey(
                        name: "FK__Assessmen__Cours__2645B050",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                    table.ForeignKey(
                        name: "FK__Assessmen__Instr__2739D489",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructor",
                        principalColumn: "Instructor_ID");
                    table.ForeignKey(
                        name: "FK__Assessmen__Modul__282DF8C2",
                        column: x => x.Module_ID,
                        principalTable: "Modules",
                        principalColumn: "Module_ID");
                });

            migrationBuilder.CreateTable(
                name: "ContentLibrary",
                columns: table => new
                {
                    Content_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Content_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Module_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ContentL__4F5E1825D762E643", x => x.Content_ID);
                    table.ForeignKey(
                        name: "FK__ContentLi__Modul__778AC167",
                        column: x => x.Module_ID,
                        principalTable: "Modules",
                        principalColumn: "Module_ID");
                });

            migrationBuilder.CreateTable(
                name: "DiscussionForums",
                columns: table => new
                {
                    Forum_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Module_ID = table.Column<int>(type: "int", nullable: true),
                    Last_Time_Active = table.Column<DateTime>(type: "datetime", nullable: true),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discussi__E49DF9138BA8B854", x => x.Forum_ID);
                    table.ForeignKey(
                        name: "FK__Discussio__Modul__7E37BEF6",
                        column: x => x.Module_ID,
                        principalTable: "Modules",
                        principalColumn: "Module_ID");
                });

            migrationBuilder.CreateTable(
                name: "ModulesLinks",
                columns: table => new
                {
                    Module_ID = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ModulesL__86669DEEE65F3A99", x => new { x.Module_ID, x.Link });
                    table.ForeignKey(
                        name: "FK__ModulesLi__Modul__656C112C",
                        column: x => x.Module_ID,
                        principalTable: "Modules",
                        principalColumn: "Module_ID");
                });

            migrationBuilder.CreateTable(
                name: "ModulesTargetTraits",
                columns: table => new
                {
                    Module_ID = table.Column<int>(type: "int", nullable: false),
                    Target_Trait = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ModulesT__1A139C72C367DB66", x => new { x.Module_ID, x.Target_Trait });
                    table.ForeignKey(
                        name: "FK__ModulesTa__Modul__68487DD7",
                        column: x => x.Module_ID,
                        principalTable: "Modules",
                        principalColumn: "Module_ID");
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollment",
                columns: table => new
                {
                    Learner_ID = table.Column<int>(type: "int", nullable: false),
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Enrollment_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Enrollment_Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Completion_Date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CourseEn__9E9C77A0138D9DDA", x => new { x.Learner_ID, x.Course_ID });
                    table.ForeignKey(
                        name: "FK__CourseEnr__Cours__70DDC3D8",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                    table.ForeignKey(
                        name: "FK__CourseEnr__Learn__6FE99F9F",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "InteractionLogs",
                columns: table => new
                {
                    Log_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Log_Type = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Time_Stamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Log_Duration = table.Column<int>(type: "int", nullable: true),
                    Learner_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Interact__2D26E7AE7788A041", x => x.Log_ID);
                    table.ForeignKey(
                        name: "FK__Interacti__Learn__628FA481",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerBadges",
                columns: table => new
                {
                    Badge_ID = table.Column<int>(type: "int", nullable: false),
                    Learner_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerB__D0F8C47B121C63BB", x => new { x.Badge_ID, x.Learner_ID });
                    table.ForeignKey(
                        name: "FK__LearnerBa__Badge__09A971A2",
                        column: x => x.Badge_ID,
                        principalTable: "Badges",
                        principalColumn: "Badge_ID");
                    table.ForeignKey(
                        name: "FK__LearnerBa__Learn__0A9D95DB",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerCourses",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false),
                    Learner_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerC__D43E2284F7B269A0", x => new { x.Course_ID, x.Learner_ID });
                    table.ForeignKey(
                        name: "FK__LearnerCo__Cours__55009F39",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                    table.ForeignKey(
                        name: "FK__LearnerCo__Learn__55F4C372",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerQuests",
                columns: table => new
                {
                    Quest_ID = table.Column<int>(type: "int", nullable: false),
                    Learner_ID = table.Column<int>(type: "int", nullable: false),
                    Completion_Status = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerQ__8E4054E450C18CF5", x => new { x.Quest_ID, x.Learner_ID });
                    table.ForeignKey(
                        name: "FK__LearnerQu__Learn__1F98B2C1",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                    table.ForeignKey(
                        name: "FK__LearnerQu__Quest__1EA48E88",
                        column: x => x.Quest_ID,
                        principalTable: "Quests",
                        principalColumn: "Quest_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerSkills",
                columns: table => new
                {
                    Learner_ID = table.Column<int>(type: "int", nullable: true),
                    Learner_Skills = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__LearnerSk__Learn__52593CB8",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearningGoals",
                columns: table => new
                {
                    Goal_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Deadline = table.Column<DateOnly>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Learner_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__09AD12A277DD4F11", x => x.Goal_ID);
                    table.ForeignKey(
                        name: "FK__LearningG__Learn__01142BA1",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearningPath",
                columns: table => new
                {
                    Path_ID = table.Column<int>(type: "int", nullable: false),
                    Rules = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Learner_Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Path_Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Instructor_ID = table.Column<int>(type: "int", nullable: true),
                    Learner_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__12D3DFFB93EE5982", x => x.Path_ID);
                    table.ForeignKey(
                        name: "FK__LearningP__Instr__3F115E1A",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructor",
                        principalColumn: "Instructor_ID");
                    table.ForeignKey(
                        name: "FK__LearningP__Learn__40058253",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Notification_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message_Body = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    Urgency_Level = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Learner_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__8C1160B583D31540", x => x.Notification_ID);
                    table.ForeignKey(
                        name: "FK__Notificat__Learn__7A672E12",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "PersonalizationProfiles",
                columns: table => new
                {
                    PersonalizationProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Learner_ID = table.Column<int>(type: "int", nullable: true),
                    PathID = table.Column<int>(type: "int", nullable: true),
                    Personality_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Prefered_content_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Current_Emotional_State = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personal__724623AFA4037613", x => x.PersonalizationProfileID);
                    table.ForeignKey(
                        name: "FK__Personali__Learn__5070F446",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Reward_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardValue = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Learner_ID = table.Column<int>(type: "int", nullable: true),
                    Quest_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Rewards__69FE4BD444A95930", x => x.Reward_ID);
                    table.ForeignKey(
                        name: "FK__Rewards__Learner__151B244E",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                    table.ForeignKey(
                        name: "FK__Rewards__Quest_I__160F4887",
                        column: x => x.Quest_ID,
                        principalTable: "Quests",
                        principalColumn: "Quest_ID");
                });

            migrationBuilder.CreateTable(
                name: "SkillProgression",
                columns: table => new
                {
                    Skill_Progression_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Proficiency_Level = table.Column<int>(type: "int", nullable: true),
                    Learner_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SkillPro__50CEF27729A56E3F", x => x.Skill_Progression_ID);
                    table.ForeignKey(
                        name: "FK__SkillProg__Learn__18EBB532",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Survey_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Learner_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Surveys__6C04F7B49B00D26D", x => x.Survey_ID);
                    table.ForeignKey(
                        name: "FK__Surveys__Learner__03F0984C",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerAssessments",
                columns: table => new
                {
                    Learner_ID = table.Column<int>(type: "int", nullable: false),
                    Assessment_ID = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerA__0B51B62682D24FB9", x => new { x.Learner_ID, x.Assessment_ID });
                    table.ForeignKey(
                        name: "FK__LearnerAs__Asses__2FCF1A8A",
                        column: x => x.Assessment_ID,
                        principalTable: "Assessments",
                        principalColumn: "Assessment_ID");
                    table.ForeignKey(
                        name: "FK__LearnerAs__Learn__2EDAF651",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "DiscussionForumsLearner",
                columns: table => new
                {
                    Forum_ID = table.Column<int>(type: "int", nullable: true),
                    Learner_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Discussio__Forum__4D5F7D71",
                        column: x => x.Forum_ID,
                        principalTable: "DiscussionForums",
                        principalColumn: "Forum_ID");
                    table.ForeignKey(
                        name: "FK__Discussio__Learn__4E53A1AA",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerDiscussionForums",
                columns: table => new
                {
                    Forum_ID = table.Column<int>(type: "int", nullable: false),
                    Learner_ID = table.Column<int>(type: "int", nullable: false),
                    Post = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerD__A8E701A6D0C1FC84", x => new { x.Forum_ID, x.Learner_ID, x.Post });
                    table.ForeignKey(
                        name: "FK__LearnerDi__Forum__22751F6C",
                        column: x => x.Forum_ID,
                        principalTable: "DiscussionForums",
                        principalColumn: "Forum_ID");
                    table.ForeignKey(
                        name: "FK__LearnerDi__Learn__236943A5",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearningActivities",
                columns: table => new
                {
                    Activity_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activity_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Detailed_Instructions = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Max_Points = table.Column<int>(type: "int", nullable: true),
                    Module_ID = table.Column<int>(type: "int", nullable: true),
                    Log_ID = table.Column<int>(type: "int", nullable: true),
                    Course_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Learning__393F5BA52270CBF1", x => x.Activity_ID);
                    table.ForeignKey(
                        name: "FK__LearningA__Cours__6C190EBB",
                        column: x => x.Course_ID,
                        principalTable: "Courses",
                        principalColumn: "Course_ID");
                    table.ForeignKey(
                        name: "FK__LearningA__Log_I__6D0D32F4",
                        column: x => x.Log_ID,
                        principalTable: "InteractionLogs",
                        principalColumn: "Log_ID");
                    table.ForeignKey(
                        name: "FK__LearningA__Modul__6B24EA82",
                        column: x => x.Module_ID,
                        principalTable: "Modules",
                        principalColumn: "Module_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerNotifications",
                columns: table => new
                {
                    Learner_ID = table.Column<int>(type: "int", nullable: false),
                    Notification_ID = table.Column<int>(type: "int", nullable: false),
                    ReadStatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerN__752361F4410735BE", x => new { x.Learner_ID, x.Notification_ID });
                    table.ForeignKey(
                        name: "FK__LearnerNo__Learn__3B40CD36",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                    table.ForeignKey(
                        name: "FK__LearnerNo__Notif__3C34F16F",
                        column: x => x.Notification_ID,
                        principalTable: "Notifications",
                        principalColumn: "Notification_ID");
                });

            migrationBuilder.CreateTable(
                name: "PersonalizationProfilesLearningPaths",
                columns: table => new
                {
                    PathID = table.Column<int>(type: "int", nullable: false),
                    PersonalizationProfileID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Personal__2A43BE03A9479754", x => new { x.PathID, x.PersonalizationProfileID });
                    table.ForeignKey(
                        name: "FK__Personali__PathI__42E1EEFE",
                        column: x => x.PathID,
                        principalTable: "LearningPath",
                        principalColumn: "Path_ID");
                    table.ForeignKey(
                        name: "FK__Personali__Perso__43D61337",
                        column: x => x.PersonalizationProfileID,
                        principalTable: "PersonalizationProfiles",
                        principalColumn: "PersonalizationProfileID");
                });

            migrationBuilder.CreateTable(
                name: "SkillProgressionChallengingTasks",
                columns: table => new
                {
                    Skill_Progression_ID = table.Column<int>(type: "int", nullable: true),
                    Challenging_Task = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__SkillProg__Skill__1AD3FDA4",
                        column: x => x.Skill_Progression_ID,
                        principalTable: "SkillProgression",
                        principalColumn: "Skill_Progression_ID");
                });

            migrationBuilder.CreateTable(
                name: "LearnerSurveys",
                columns: table => new
                {
                    Learner_ID = table.Column<int>(type: "int", nullable: false),
                    Survey_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LearnerS__6B223884529ACB55", x => new { x.Learner_ID, x.Survey_ID });
                    table.ForeignKey(
                        name: "FK__LearnerSu__Learn__37703C52",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                    table.ForeignKey(
                        name: "FK__LearnerSu__Surve__3864608B",
                        column: x => x.Survey_ID,
                        principalTable: "Surveys",
                        principalColumn: "Survey_ID");
                });

            migrationBuilder.CreateTable(
                name: "SurveysQuestions",
                columns: table => new
                {
                    Survey_ID = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SurveysQ__EAB770122A788E1D", x => new { x.Survey_ID, x.Question });
                    table.ForeignKey(
                        name: "FK__SurveysQu__Surve__06CD04F7",
                        column: x => x.Survey_ID,
                        principalTable: "Surveys",
                        principalColumn: "Survey_ID");
                });

            migrationBuilder.CreateTable(
                name: "EmotionalFeedback",
                columns: table => new
                {
                    Feedback_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emotional_State = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Feedback_Time = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Learner_ID = table.Column<int>(type: "int", nullable: true),
                    Activity_ID = table.Column<int>(type: "int", nullable: true),
                    Instructor_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Emotiona__CD3992F8B5D6F044", x => x.Feedback_ID);
                    table.ForeignKey(
                        name: "FK__Emotional__Activ__5CA1C101",
                        column: x => x.Activity_ID,
                        principalTable: "LearningActivities",
                        principalColumn: "Activity_ID");
                    table.ForeignKey(
                        name: "FK__Emotional__Instr__5D95E53A",
                        column: x => x.Instructor_ID,
                        principalTable: "Instructor",
                        principalColumn: "Instructor_ID");
                    table.ForeignKey(
                        name: "FK__Emotional__Learn__5BAD9CC8",
                        column: x => x.Learner_ID,
                        principalTable: "Learner",
                        principalColumn: "Learner_ID");
                });

            migrationBuilder.CreateTable(
                name: "ModulesLearningActivities",
                columns: table => new
                {
                    Module_ID = table.Column<int>(type: "int", nullable: false),
                    Activity_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ModulesL__5E7715922B9F7755", x => new { x.Module_ID, x.Activity_ID });
                    table.ForeignKey(
                        name: "FK__ModulesLe__Activ__4B7734FF",
                        column: x => x.Activity_ID,
                        principalTable: "LearningActivities",
                        principalColumn: "Activity_ID");
                    table.ForeignKey(
                        name: "FK__ModulesLe__Modul__4A8310C6",
                        column: x => x.Module_ID,
                        principalTable: "Modules",
                        principalColumn: "Module_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_Course_ID",
                table: "Assessments",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_Instructor_ID",
                table: "Assessments",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_Module_ID",
                table: "Assessments",
                column: "Module_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ContentLibrary_Module_ID",
                table: "ContentLibrary",
                column: "Module_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_Course_ID",
                table: "CourseEnrollment",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesInstructor_Instructor_ID",
                table: "CoursesInstructor",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionForums_Module_ID",
                table: "DiscussionForums",
                column: "Module_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionForumsLearner_Forum_ID",
                table: "DiscussionForumsLearner",
                column: "Forum_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DiscussionForumsLearner_Learner_ID",
                table: "DiscussionForumsLearner",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionalFeedback_Activity_ID",
                table: "EmotionalFeedback",
                column: "Activity_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionalFeedback_Instructor_ID",
                table: "EmotionalFeedback",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EmotionalFeedback_Learner_ID",
                table: "EmotionalFeedback",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_InteractionLogs_Learner_ID",
                table: "InteractionLogs",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Learner_Course_ID_Board_ID",
                table: "Learner",
                columns: new[] { "Course_ID", "Board_ID" });

            migrationBuilder.CreateIndex(
                name: "IX_Learner_UserId",
                table: "Learner",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerAssessments_Assessment_ID",
                table: "LearnerAssessments",
                column: "Assessment_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerBadges_Learner_ID",
                table: "LearnerBadges",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerCourses_Learner_ID",
                table: "LearnerCourses",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerDiscussionForums_Learner_ID",
                table: "LearnerDiscussionForums",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerNotifications_Notification_ID",
                table: "LearnerNotifications",
                column: "Notification_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerQuests_Learner_ID",
                table: "LearnerQuests",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerSkills_Learner_ID",
                table: "LearnerSkills",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearnerSurveys_Survey_ID",
                table: "LearnerSurveys",
                column: "Survey_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningActivities_Course_ID",
                table: "LearningActivities",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningActivities_Log_ID",
                table: "LearningActivities",
                column: "Log_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningActivities_Module_ID",
                table: "LearningActivities",
                column: "Module_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningGoals_Learner_ID",
                table: "LearningGoals",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningPath_Instructor_ID",
                table: "LearningPath",
                column: "Instructor_ID");

            migrationBuilder.CreateIndex(
                name: "IX_LearningPath_Learner_ID",
                table: "LearningPath",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_Course_ID",
                table: "Modules",
                column: "Course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ModulesLearningActivities_Activity_ID",
                table: "ModulesLearningActivities",
                column: "Activity_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Learner_ID",
                table: "Notifications",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalizationProfiles_Learner_ID",
                table: "PersonalizationProfiles",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalizationProfilesLearningPaths_PersonalizationProfileID",
                table: "PersonalizationProfilesLearningPaths",
                column: "PersonalizationProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_Learner_ID",
                table: "Rewards",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_Quest_ID",
                table: "Rewards",
                column: "Quest_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillProgression_Learner_ID",
                table: "SkillProgression",
                column: "Learner_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SkillProgressionChallengingTasks_Skill_Progression_ID",
                table: "SkillProgressionChallengingTasks",
                column: "Skill_Progression_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_Learner_ID",
                table: "Surveys",
                column: "Learner_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CollaborativeQuest");

            migrationBuilder.DropTable(
                name: "ContentLibrary");

            migrationBuilder.DropTable(
                name: "CourseEnrollment");

            migrationBuilder.DropTable(
                name: "CourseLearningObjectives");

            migrationBuilder.DropTable(
                name: "CoursePrerequisites");

            migrationBuilder.DropTable(
                name: "CoursesInstructor");

            migrationBuilder.DropTable(
                name: "DiscussionForumsLearner");

            migrationBuilder.DropTable(
                name: "EmotionalFeedback");

            migrationBuilder.DropTable(
                name: "InstructorEmail");

            migrationBuilder.DropTable(
                name: "LearnerAssessments");

            migrationBuilder.DropTable(
                name: "LearnerBadges");

            migrationBuilder.DropTable(
                name: "LearnerCourses");

            migrationBuilder.DropTable(
                name: "LearnerDiscussionForums");

            migrationBuilder.DropTable(
                name: "LearnerNotifications");

            migrationBuilder.DropTable(
                name: "LearnerQuests");

            migrationBuilder.DropTable(
                name: "LearnerSkills");

            migrationBuilder.DropTable(
                name: "LearnerSurveys");

            migrationBuilder.DropTable(
                name: "LearningGoals");

            migrationBuilder.DropTable(
                name: "ModulesLearningActivities");

            migrationBuilder.DropTable(
                name: "ModulesLinks");

            migrationBuilder.DropTable(
                name: "ModulesTargetTraits");

            migrationBuilder.DropTable(
                name: "PersonalizationProfilesLearningPaths");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "SkillMasteryQuest");

            migrationBuilder.DropTable(
                name: "SkillProgressionChallengingTasks");

            migrationBuilder.DropTable(
                name: "SurveysQuestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Badges");

            migrationBuilder.DropTable(
                name: "DiscussionForums");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "LearningActivities");

            migrationBuilder.DropTable(
                name: "LearningPath");

            migrationBuilder.DropTable(
                name: "PersonalizationProfiles");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "SkillProgression");

            migrationBuilder.DropTable(
                name: "Surveys");

            migrationBuilder.DropTable(
                name: "InteractionLogs");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "Learner");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Leaderboards");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
