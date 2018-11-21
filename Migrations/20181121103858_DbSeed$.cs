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
                    Path = table.Column<string>(nullable: true),
                    isAvatar = table.Column<bool>(nullable: false)
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
                values: new object[] { 3L, null, "reiciendis-ratione-est-voluptatem-dolorem-dolorem-ipsam-tempore-quibusdam-aliquam-aut-illum-culpa-corporis-provident-culpa-impedit-est-sunt-ut-suscipit-id-quia-qui-omnis-et-sit-in-totam-aut-voluptatem-reiciendis-et-blanditiis-sapiente-doloremque-molestias-temporibus-sint-dicta-sapiente-et-qui-magnam-voluptas-ullam-deleniti-cupiditate-excepturi-cum-dicta-quam-quaerat-qui-sint-autem-itaque-aut-atque-ut-fugiat-id-quia-dolorem-odit-et-perferendis-quia-laboriosam-quas-quasi-sint-quaerat-atque-in-rem-non-tenetur-rerum-deleniti-voluptatem-consequatur-et-temporibus-rerum-qui-quisquam-voluptatibus-sed-officia-explicabo-fuga-nemo-aut-magnam-modi-expedita-sunt-ratione-itaque", null, new DateTime(2018, 8, 9, 10, 39, 29, 938, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 5L, null, "dolores-doloribus-qui-non-alias-velit-a-excepturi-sapiente-voluptatem-aspernatur-corporis-ut-dolore-quia-ut-dicta-inventore-cupiditate-magni-vero-accusamus-similique-non-dolorem-eius-inventore-sed-voluptas-odio-quae-iusto-ea-labore-vel-quo-sit-officiis-sunt-deserunt-dicta-soluta-voluptatibus-voluptas-explicabo-voluptatem-libero-sint-sint-eos-assumenda-in-quis-consequatur-quisquam-et-quam-laborum-voluptas-repellendus-ex-quo-tempore-occaecati-eius-nam-earum-aut-et-laudantium-ex-non-atque-recusandae-ipsa-dolor-rerum-et-sed-perferendis-unde-qui-id-voluptatibus-tempore-facilis-et-unde-sint-amet-nostrum-sunt-odit-repellendus-ut-magnam-aut-praesentium-perspiciatis-et", null, new DateTime(2018, 9, 6, 15, 47, 12, 941, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 4L, null, "ex-sit-aut-est-dolorem-neque-est-et-ducimus-dolorem-voluptatibus-repellat-alias-reprehenderit-accusantium-tempore-quam-itaque-vel-amet-aperiam-officia-facere-voluptate-dignissimos-laborum-veniam-incidunt-ex-vel-quidem-consequatur-rerum-adipisci-autem-fuga-illo-sit-porro-similique-rerum-quod-sunt-nihil-aut-et-corporis-qui-tempora-omnis-labore-harum-voluptas-facere-magnam-voluptas-et-animi-neque-iste-debitis-perspiciatis-necessitatibus-harum-non-ipsum-ab-consequatur-mollitia-ea-dolorum-ut-eius-consequatur-labore-nostrum-et-sit-ullam-vel-nemo-cumque-consequatur-aut-in-alias-ipsa-adipisci-earum-doloremque-adipisci-blanditiis-sit-neque-est-in-at-blanditiis-saepe-itaque", null, new DateTime(2018, 4, 24, 15, 27, 21, 372, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 2L, null, "officia-qui-quia-dolores-tenetur-maxime-debitis-delectus-doloribus-ea-aperiam-aut-unde-dolorem-eos-asperiores-aperiam-tempora-quis-cum-quia-doloribus-blanditiis-nisi-voluptas-quo-eaque-dolor-quia-sed-culpa-numquam-recusandae-facere-odit-voluptate-aspernatur-ut-quasi-facere-tenetur-omnis-est-et-dolor-magni-est-eos-veritatis-nesciunt-at-quia-itaque-qui-error-animi-nobis-voluptatibus-nostrum-et-impedit-optio-possimus-blanditiis-dolorem-qui-officiis-autem-porro-qui-eveniet-nobis-nesciunt-dolorum-quisquam-assumenda-nisi-aut-neque-quo-itaque-quia-sed-ab-soluta-aliquam-minima-sed-consectetur-molestias-est-sed-inventore-dolorem-quae-aliquam-quibusdam-adipisci-eum-ea", null, new DateTime(2018, 8, 19, 19, 45, 6, 341, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 1L, null, "rem-voluptatem-reprehenderit-iste-iusto-et-est-voluptates-voluptatem-eum-enim-est-nobis-aut-sit-cupiditate-perspiciatis-recusandae-et-non-eum-recusandae-cumque-culpa-consequatur-repudiandae-quia-nemo-reprehenderit-perferendis-sapiente-aut-nulla-illo-deserunt-est-maxime-excepturi-non-sit-sunt-ea-aut-dolor-in-est-eius-expedita-aut-repudiandae-doloribus-totam-aut-voluptas-esse-sed-natus-consequatur-amet-cupiditate-velit-quam-sint-magnam-accusamus-molestias-voluptas-et-excepturi-natus-omnis-aperiam-est-aspernatur-ea-nihil-magni-cupiditate-alias-rerum-optio-omnis-nihil-deleniti-voluptatem-dolores-eum-occaecati-rerum-illo-numquam-itaque-quia-est-et-sequi-necessitatibus-omnis-enim-quasi", null, new DateTime(2018, 1, 2, 11, 18, 41, 198, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Elwin.Glover", 0, null, "ApplicationsUser", "Beatrice86@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 10L, null, "Janick", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Zachariah_Bahringer", 0, null, "ApplicationsUser", "Jonathon_Torphy13@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 9L, null, "Noel", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Keely50", 0, null, "ApplicationsUser", "Humberto_Runolfsson@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 1L, null, "Kaylee", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Floyd.Schowalter55", 0, null, "ApplicationsUser", "Mossie_Stamm61@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 7L, null, "Margarette", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Rita.Schultz87", 0, null, "ApplicationsUser", "Crystal.Robel31@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 6L, null, "Mikel", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Weldon.King35", 0, null, "ApplicationsUser", "Alana_Halvorson@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 5L, null, "Karson", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Destiney_Pfannerstill65", 0, null, "ApplicationsUser", "Betty_Renner@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 4L, null, "Kayli", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Laura78", 0, null, "ApplicationsUser", "Mavis42@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 3L, null, "Bennett", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Libbie.Kunde21", 0, null, "ApplicationsUser", "Rosie.Mayer@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 2L, null, "Daphnee", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Pietro_Kuvalis15", 0, null, "ApplicationsUser", "Roy85@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 8L, null, "Margarita", null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 5L, "Cummerata", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 4L, "Schimmel", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing", false });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 2L, "Ritchie", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing", false });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 1L, "McCullough", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 3L, "Dietrich", "C:\\Users\\vmadmin\\Desktop\\PokemonForum\\nothing", false });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 4L, "hic-exercitationem-ipsam-quasi-aut-necessitatibus-esse-ut" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 1L, "distinctio-laborum-culpa-vel-tempora-ratione-alias-impedit" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 2L, "rem-dolor-illum-delectus-cupiditate-eum-unde-commodi" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 3L, "non-odit-ullam-veritatis-eaque-dolores-et-facilis" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 5L, "possimus-numquam-iusto-sed-ea-ea-quaerat-dolore" });

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
