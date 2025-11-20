using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Call = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    VideoLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portfolio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolio_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Header = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    Clients = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    Projects = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    HoursOfSupport = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    HardWorkers = table.Column<int>(type: "int", maxLength: 6, nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SocialMediaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UpdatedDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutUs_SocialMedia_SocialMediaId",
                        column: x => x.SocialMediaId,
                        principalTable: "SocialMedia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "11/20/2025", "Projects", null },
                    { 2, "11/20/2025", "SiteWorks", null }
                });

            migrationBuilder.InsertData(
                table: "ContactUs",
                columns: new[] { "Id", "Call", "CreatedDate", "Email", "Location", "Map", "UpdatedDate" },
                values: new object[] { 1, "01111235495", "11/20/2025", "contact@gmail.com", "Cairo, Egypt", "testLinkMap", null });

            migrationBuilder.InsertData(
                table: "HomePage",
                columns: new[] { "Id", "CreatedDate", "Description", "Header", "UpdatedDate", "VideoLink" },
                values: new object[] { 1, "11/20/2025", "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla.", "Lorem ipsum dolor sit amet.", null, "testVideoLink" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "CreatedDate", "Description", "Icon", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "11/20/2025", "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla.", "Test", "Test", null },
                    { 2, "11/20/2025", "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla.", "Test2", "Test2", null },
                    { 3, "11/20/2025", "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla.", "Test3", "Test3", null }
                });

            migrationBuilder.InsertData(
                table: "SocialMedia",
                columns: new[] { "Id", "CreatedDate", "Facebook", "Instagram", "LinkedIn", "Twitter", "UpdatedDate" },
                values: new object[] { 1, "11/20/2025", "Testface", "Testinsta", null, null, null });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CreatedDate", "Facebook", "FileName", "FileType", "FullName", "Instagram", "LinkedIn", "Title", "Twitter", "UpdatedDate" },
                values: new object[] { 1, "11/20/2025", "facebook", "Test", "Test", "TestTeam1", "Intagram", null, "TestTitle", null, null });

            migrationBuilder.InsertData(
                table: "Testimonials",
                columns: new[] { "Id", "Comment", "CreatedDate", "FileName", "FileType", "FullName", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est.Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero,", "11/20/2025", "Test", "Test", "Test", "Test", null },
                    { 2, "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est.Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero2,", "11/20/2025", "Test2", "Test2", "Test2", "Test2", null },
                    { 3, "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est.Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero3,", "11/20/2025", "Test3", "Test3", "Test3", "Test3", null }
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "Clients", "CreatedDate", "Description", "FileName", "FileType", "HardWorkers", "Header", "HoursOfSupport", "Projects", "SocialMediaId", "UpdatedDate" },
                values: new object[] { 1, 5, "11/20/2025", "consectetur adipiscing elit. Duis arcu diam, rutrum et efficitur in, varius eget est. Nullam blandit, dui ut pellentesque placerat, tortor arcu euismod libero, nec pulvinar quam nisl eu turpis. Aenean egestas vulputate orci a tristique. Pellentesque vulputate viverra tristique. Morbi eu dignissim nulla.", "Test", "Test", 3, "Lorem ipsum dolor sit amet.", 150, 5, 1, null });

            migrationBuilder.InsertData(
                table: "Portfolio",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "FileName", "FileType", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "11/20/2025", "test", "file", "test", null },
                    { 2, 1, "11/20/2025", "test2", "file2", "test2", null },
                    { 3, 2, "11/20/2025", "test3", "file3", "test3", null },
                    { 4, 2, "11/20/2025", "test4", "file4", "test4", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutUs_SocialMediaId",
                table: "AboutUs",
                column: "SocialMediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_CategoryId",
                table: "Portfolio",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "HomePage");

            migrationBuilder.DropTable(
                name: "Portfolio");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Testimonials");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
