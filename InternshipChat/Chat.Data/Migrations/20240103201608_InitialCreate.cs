using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable
namespace Chat.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupChats",
                columns: table => new
                {
                    GroupChatId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupChats", x => x.GroupChatId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSender = table.Column<int>(type: "integer", nullable: false),
                    GroupChatId = table.Column<int>(type: "integer", nullable: false),
                    MessageContent = table.Column<string>(type: "text", nullable: true),
                    SentAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupMessages_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "GroupChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrivateMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdSender = table.Column<int>(type: "integer", nullable: false),
                    IdReciver = table.Column<int>(type: "integer", nullable: false),
                    MessageContent = table.Column<string>(type: "text", nullable: true),
                    SentAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivateMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivateMessages_Users_IdSender",
                        column: x => x.IdSender,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    GroupChatId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.UserId, x.GroupChatId });
                    table.ForeignKey(
                        name: "FK_UserGroups_GroupChats_GroupChatId",
                        column: x => x.GroupChatId,
                        principalTable: "GroupChats",
                        principalColumn: "GroupChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GroupChats",
                columns: new[] { "GroupChatId", "Name" },
                values: new object[,]
                {
                    { 1, "Developers" },
                    { 2, "Marketing" },
                    { 3, "Multimedia" },
                    { 4, "Designers" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 1, "mariomitov@gmail.com", true, "Mario", "12345678", "Mitov" },
                    { 2, "johndoe@gmail.com", false, "John", "12345678", "Doe" },
                    { 3, "janesmith@gmail.com", false, "Jane", "12345678", "Smith" },
                    { 4, "peterjones@gmail.com", false, "Peter", "12345678", "Jones" },
                    { 5, "elizabethwilliams@gmail.com", false, "Elizabeth", "12345678", "Williams" },
                    { 6, "michaelbrown@gmail.com", false, "Michael", "12345678", "Brown" },
                    { 7, "susananderson@gmail.com", false, "Susan", "12345678", "Anderson" },
                    { 8, "davidtaylor@gmail.com", false, "David", "12345678", "Taylor" },
                    { 9, "emilywilson@gmail.com", false, "Emily", "12345678", "Wilson" },
                    { 10, "charlesgarcia@gmail.com", false, "Charles", "12345678", "Garcia" },
                    { 11, "margaretrobinson@gmail.com", false, "Margaret", "12345678", "Robinson" },
                    { 12, "robertmartinez@gmail.com", false, "Robert", "12345678", "Martinez" },
                    { 13, "jenniferthompson@gmail.com", false, "Jennifer", "12345678", "Thompson" }
                });

            migrationBuilder.InsertData(
                table: "GroupMessages",
                columns: new[] { "Id", "GroupChatId", "IdSender", "MessageContent", "SentAt" },
                values: new object[,]
                {
                    { 1, 1, 1, "Kada je rok za domaći?", new DateTimeOffset(new DateTime(2024, 1, 3, 21, 16, 7, 865, DateTimeKind.Unspecified).AddTicks(7057), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 2, 1, 2, "4. siječnja", new DateTimeOffset(new DateTime(2024, 1, 3, 21, 16, 7, 865, DateTimeKind.Unspecified).AddTicks(7063), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 3, 1, 2, "2024", new DateTimeOffset(new DateTime(2024, 1, 3, 21, 16, 7, 865, DateTimeKind.Unspecified).AddTicks(7067), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 4, 1, 3, "Odlično!", new DateTimeOffset(new DateTime(2024, 1, 3, 21, 16, 7, 865, DateTimeKind.Unspecified).AddTicks(7070), new TimeSpan(0, 1, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "PrivateMessages",
                columns: new[] { "Id", "IdReciver", "IdSender", "MessageContent", "SentAt" },
                values: new object[,]
                {
                    { 1, 2, 1, "Hej, Sretan Božić!", new DateTimeOffset(new DateTime(2024, 1, 3, 21, 16, 7, 865, DateTimeKind.Unspecified).AddTicks(6982), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 2, 1, 2, "Hvala, također!", new DateTimeOffset(new DateTime(2024, 1, 3, 21, 16, 7, 865, DateTimeKind.Unspecified).AddTicks(7034), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 3, 3, 2, "Možeš li mi pomoć sutra?", new DateTimeOffset(new DateTime(2024, 1, 3, 21, 16, 7, 865, DateTimeKind.Unspecified).AddTicks(7037), new TimeSpan(0, 1, 0, 0, 0)) },
                    { 4, 2, 3, "Moogu oko 3 popodne.", new DateTimeOffset(new DateTime(2024, 1, 3, 21, 16, 7, 865, DateTimeKind.Unspecified).AddTicks(7042), new TimeSpan(0, 1, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "GroupChatId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessages_GroupChatId",
                table: "GroupMessages",
                column: "GroupChatId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivateMessages_IdSender",
                table: "PrivateMessages",
                column: "IdSender");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupChatId",
                table: "UserGroups",
                column: "GroupChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMessages");

            migrationBuilder.DropTable(
                name: "PrivateMessages");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "GroupChats");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
