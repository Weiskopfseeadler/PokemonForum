using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonForum.Migrations
{
    public partial class DbSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageID);
                });

            migrationBuilder.CreateTable(
                name: "Threads",
                columns: table => new
                {
                    ThreadID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threads", x => x.ThreadID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    ApplicationsUserID = table.Column<long>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    AvatarImageID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_AvatarImageID",
                        column: x => x.AvatarImageID,
                        principalTable: "Images",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: true),
                    ThreadID = table.Column<long>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    ImageID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ImageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Threads_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "Threads",
                        principalColumn: "ThreadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 3L, null, "dolor-libero-eaque-rerum-aut-exercitationem-debitis-sint-sed-est-dignissimos-et-aut-nobis-voluptatibus-sed-facere-repellendus-nesciunt-modi-aut-rerum-aut-consequuntur-et-fugiat-et-ut-nobis-qui-deserunt-accusantium-sint-repellat-aspernatur-commodi-ea-velit-ex-nemo-ipsa-necessitatibus-perferendis-placeat-molestias-necessitatibus-quisquam-perferendis-maxime-voluptas-saepe-laudantium-minima-est-aut-ut-optio-repudiandae-omnis-ut-rerum-non-eum-aut-explicabo-quam-omnis-reiciendis-qui-et-voluptas-iste-molestiae-pariatur-sit-sed-fuga-modi-et-aut-aut-rerum-animi-nulla-magnam-magni-placeat-et-saepe-natus-libero-ducimus-quam-sunt-libero-excepturi-inventore-eaque-expedita-sunt", null, new DateTime(2018, 7, 21, 15, 1, 52, 613, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 5L, null, "praesentium-qui-aut-magni-itaque-molestias-illum-beatae-cupiditate-corrupti-doloremque-molestiae-ea-est-quis-id-tempore-non-illo-doloremque-nam-non-vitae-reiciendis-dolorem-necessitatibus-explicabo-voluptatum-ad-ducimus-sit-illo-totam-eos-illo-ut-et-tenetur-ab-voluptas-veritatis-accusantium-molestiae-modi-dolor-eos-necessitatibus-accusantium-aut-suscipit-quae-inventore-enim-quaerat-porro-dolore-veritatis-et-delectus-ab-velit-laboriosam-aut-architecto-corporis-reiciendis-sapiente-dolores-quidem-voluptatem-aut-quisquam-aut-quis-delectus-quidem-repellendus-vero-velit-corporis-repellat-et-commodi-itaque-in-quia-repellendus-quia-qui-aut-sed-quisquam-maiores-repellat-aliquid-quisquam-modi-aliquid-sint-et", null, new DateTime(2017, 12, 28, 11, 7, 14, 195, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 4L, null, "maxime-molestiae-magni-repellat-suscipit-aperiam-molestiae-molestiae-voluptatibus-repudiandae-voluptatum-exercitationem-et-nesciunt-repellat-molestiae-maiores-est-delectus-libero-facilis-vitae-voluptatem-rerum-qui-dolores-laboriosam-dolor-libero-veritatis-officia-similique-non-rerum-consequatur-numquam-rem-pariatur-sint-explicabo-quia-deleniti-voluptates-est-adipisci-voluptatem-dolorum-recusandae-libero-qui-architecto-ipsam-est-nihil-est-distinctio-ea-sit-animi-sed-optio-dolore-possimus-et-voluptas-et-assumenda-neque-temporibus-repellendus-blanditiis-dolores-consequatur-officiis-ut-dolorem-quia-autem-facere-et-excepturi-voluptate-excepturi-vitae-doloribus-enim-debitis-aut-hic-impedit-consequatur-nostrum-dolore-quo-in-architecto-quisquam-doloribus-quia-quis", null, new DateTime(2018, 7, 4, 15, 43, 1, 578, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 2L, null, "officiis-error-minus-impedit-adipisci-consequuntur-aut-rerum-sit-perferendis-consequatur-inventore-vel-vel-itaque-amet-ullam-perferendis-vel-consequatur-voluptatem-laboriosam-expedita-voluptatem-et-incidunt-aut-excepturi-exercitationem-dicta-magnam-et-facilis-ipsa-ut-eos-consequatur-est-distinctio-quod-rerum-ut-dolores-adipisci-aut-occaecati-hic-beatae-fugit-praesentium-et-est-hic-et-et-provident-et-velit-beatae-delectus-perferendis-animi-officia-et-omnis-qui-velit-est-voluptate-beatae-illum-non-aliquid-quasi-est-temporibus-nulla-laudantium-ut-odit-minima-aperiam-qui-quo-praesentium-id-sint-ea-dolores-iusto-tenetur-tenetur-eligendi-optio-est-ipsa-facilis-magnam-iusto-fugiat", null, new DateTime(2018, 10, 12, 0, 44, 6, 544, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 1L, null, "autem-optio-nostrum-dolorem-aspernatur-tempora-esse-sit-sint-et-unde-sunt-suscipit-consequatur-repudiandae-aspernatur-perspiciatis-dolore-doloribus-officiis-est-ducimus-et-voluptatibus-ipsa-debitis-eos-magni-in-quae-error-et-rerum-dolorem-eos-laborum-necessitatibus-unde-cum-quam-recusandae-quo-provident-odio-est-quasi-eaque-et-doloremque-sint-consectetur-optio-soluta-eum-nisi-non-harum-enim-dolor-eius-consequatur-quis-repellendus-accusamus-soluta-sed-qui-dolorem-accusamus-ullam-quia-asperiores-similique-similique-earum-perferendis-repudiandae-fuga-aliquam-ut-voluptas-molestiae-aspernatur-atque-vero-et-facere-sed-dolorem-non-voluptatibus-culpa-voluptas-blanditiis-illo-facilis-non-distinctio-omnis-est", null, new DateTime(2017, 12, 17, 5, 15, 13, 974, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Salvatore73", 0, null, "ApplicationsUser", "Joannie20@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 10L, null, "Maximilian", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Noe.Durgan56", 0, null, "ApplicationsUser", "Saul_Kuhic@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 9L, null, "Beryl", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Giuseppe22", 0, null, "ApplicationsUser", "Willis46@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 1L, null, "Era", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Albina25", 0, null, "ApplicationsUser", "Maynard.Crist@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 7L, null, "Ines", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Bulah.Bashirian", 0, null, "ApplicationsUser", "Elenora66@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 6L, null, "Rolando", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Angela.Hegmann32", 0, null, "ApplicationsUser", "Nathanial_Herzog60@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 5L, null, "Uriah", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Troy_Huels", 0, null, "ApplicationsUser", "Merl_Blanda91@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 4L, null, "Marian", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Nicklaus_Hermann38", 0, null, "ApplicationsUser", "Tracy.Flatley@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 3L, null, "Muriel", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Connor.Quitzon", 0, null, "ApplicationsUser", "Samir19@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 2L, null, "Ezra", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Gladyce48", 0, null, "ApplicationsUser", "Gwendolyn.Watsica5@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 8L, null, "Regan", null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path" },
                values: new object[] { 5L, "Fadel", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path" },
                values: new object[] { 4L, "Lebsack", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path" },
                values: new object[] { 2L, "Ritchie", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path" },
                values: new object[] { 1L, "O'Hara", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path" },
                values: new object[] { 3L, "Marks", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 4L, "est-ut-saepe-ducimus-soluta-ad-neque-quis" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 1L, "minima-repudiandae-sit-quidem-modi-dolorum-eveniet-maxime" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 2L, "quaerat-sed-dolore-ullam-quasi-esse-dolor-quas" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 3L, "aut-est-ut-sint-enim-sit-quis-est" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 5L, "odio-earum-perferendis-minus-earum-libero-cumque-et" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageID",
                table: "Articles",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ThreadID",
                table: "Articles",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                name: "IX_AspNetUsers_AvatarImageID",
                table: "AspNetUsers",
                column: "AvatarImageID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

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
                name: "Threads");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
