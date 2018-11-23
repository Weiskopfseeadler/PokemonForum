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
                values: new object[] { 3L, null, "dicta-delectus-numquam-illo-nihil-exercitationem-mollitia-minus-facilis-quam-quia-totam-odio-et-velit-iure-fugiat-excepturi-dolor-nulla-amet-deserunt-quas-ex-totam-deserunt-quae-odio-et-necessitatibus-aliquid-minima-hic-omnis-corporis-tempora-quis-non-omnis-temporibus-quos-atque-nisi-facilis-impedit-debitis-in-quia-et-voluptas-molestiae-saepe-natus-dolorem-voluptas-dolores-praesentium-eos-qui-fugit-magnam-sequi-fugit-facere-quasi-eveniet-occaecati-nam-voluptas-ut-sit-et-sapiente-doloribus-ex-nihil-dolore-vero-est-deserunt-perferendis-et-quidem-at-delectus-blanditiis-porro-quia-perferendis-aut-voluptas-molestias-nisi-iusto-ut-suscipit-quis-deserunt-in-consequatur", null, new DateTime(2018, 7, 15, 5, 46, 6, 447, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 5L, null, "officia-nisi-qui-aut-hic-ut-et-animi-non-error-alias-qui-doloremque-dolore-modi-rerum-dolore-et-maxime-asperiores-ipsum-atque-voluptatem-animi-non-exercitationem-ut-voluptatibus-consequatur-ut-totam-et-velit-nostrum-dolorum-nulla-repellendus-sunt-minima-debitis-praesentium-id-et-minima-neque-deserunt-fugiat-et-necessitatibus-eos-a-qui-modi-pariatur-placeat-odit-consectetur-pariatur-culpa-et-fuga-aut-mollitia-tempore-aspernatur-sunt-iure-quod-fuga-autem-aut-sequi-modi-accusamus-sed-similique-quam-officiis-iusto-itaque-laudantium-odit-explicabo-et-culpa-id-quia-ut-ut-sint-expedita-recusandae-excepturi-fuga-magnam-culpa-consequatur-reprehenderit-sit-officia", null, new DateTime(2018, 9, 8, 17, 45, 35, 246, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 4L, null, "voluptates-ea-fugiat-placeat-sit-recusandae-sunt-totam-inventore-dolore-id-numquam-asperiores-aspernatur-voluptas-sint-voluptatem-repellendus-et-dolor-in-est-a-sed-molestias-natus-cupiditate-ducimus-voluptatem-suscipit-expedita-veniam-quo-ut-odit-error-aut-aut-rerum-occaecati-ratione-et-tenetur-natus-neque-exercitationem-aliquid-suscipit-numquam-qui-odit-consequatur-a-harum-a-quaerat-in-et-labore-praesentium-voluptate-quia-ducimus-est-deserunt-voluptatem-autem-omnis-asperiores-omnis-impedit-nesciunt-quo-explicabo-doloremque-maxime-optio-in-ipsa-non-non-amet-ut-sed-tempora-nulla-quia-sed-ad-nulla-neque-dolor-eos-corrupti-aut-accusantium-quia-tempora-delectus-nulla", null, new DateTime(2017, 12, 21, 15, 40, 30, 994, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 2L, null, "sed-fuga-voluptatem-aliquam-sint-fugit-perferendis-tempore-nisi-corrupti-inventore-sed-vero-vel-sint-quaerat-autem-rerum-quo-necessitatibus-modi-itaque-dolorem-tempora-dicta-inventore-est-ipsa-vero-sunt-dolorum-consequuntur-quo-minima-dolore-soluta-odio-amet-est-reprehenderit-quia-sunt-dolor-quia-id-ex-libero-provident-blanditiis-officiis-enim-provident-eaque-et-nostrum-dolor-quibusdam-sunt-ipsum-praesentium-reprehenderit-aut-illum-est-et-recusandae-ea-culpa-similique-labore-illum-est-ut-dignissimos-voluptas-est-omnis-dolorum-dolorum-qui-reprehenderit-consectetur-qui-voluptatibus-quaerat-dicta-dicta-numquam-maiores-et-rerum-ut-perferendis-consectetur-alias-voluptatem-possimus-voluptate-laboriosam-tempore", null, new DateTime(2017, 12, 10, 4, 3, 16, 351, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 1L, null, "aperiam-minima-id-esse-quia-nam-voluptatibus-corrupti-voluptatem-ipsa-officia-quis-alias-id-laborum-aliquam-possimus-mollitia-consequatur-magni-perferendis-molestias-modi-sint-assumenda-rerum-dignissimos-delectus-aliquam-ut-optio-error-et-ut-eius-quisquam-optio-quia-cupiditate-deserunt-ratione-suscipit-rem-modi-esse-reiciendis-culpa-qui-non-vel-aut-amet-molestiae-distinctio-sit-cupiditate-inventore-eius-est-dolor-eius-perferendis-incidunt-ab-ut-accusantium-totam-praesentium-occaecati-necessitatibus-natus-qui-quasi-esse-maiores-cum-eaque-alias-aut-temporibus-commodi-corporis-possimus-odio-dolorem-molestias-dolores-dolore-occaecati-eligendi-nam-voluptatum-cupiditate-ut-quis-magni-odit-quam-debitis-iure", null, new DateTime(2018, 5, 19, 18, 30, 24, 482, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Bianka.Paucek70", 0, null, "ApplicationsUser", "Leopold.Quigley@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 10L, null, "Verdie", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Missouri_Stracke", 0, null, "ApplicationsUser", "Owen.Wilkinson@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 9L, null, "Jaquan", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Aurelia.Morissette", 0, null, "ApplicationsUser", "Ferne68@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 1L, null, "Queenie", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Magnolia_Murphy", 0, null, "ApplicationsUser", "Cordell12@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 7L, null, "Remington", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Dangelo_Cummerata79", 0, null, "ApplicationsUser", "Tara_Rippin@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 6L, null, "Savannah", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Richmond_Hauck", 0, null, "ApplicationsUser", "Pauline82@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 5L, null, "Hosea", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Martine.Stanton48", 0, null, "ApplicationsUser", "Orie.Fay35@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 4L, null, "Kole", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Alison72", 0, null, "ApplicationsUser", "Laurie_Morissette2@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 3L, null, "Cassidy", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Emma.Jerde", 0, null, "ApplicationsUser", "Moshe.Borer@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 2L, null, "Josefa", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Johnathan.Abbott38", 0, null, "ApplicationsUser", "Carolyn28@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 8L, null, "Lula", null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 5L, "Yundt", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 4L, "Bernhard", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 2L, "Schulist", "~/images/nothing.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 1L, "Zboncak", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 3L, "Leffler", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 4L, "quaerat-consequuntur-dolorem-temporibus-voluptatem-consequatur-aliquid-culpa" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 1L, "est-ut-et-voluptatem-quaerat-quo-ullam-corrupti" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 2L, "occaecati-sed-non-voluptas-temporibus-voluptas-consequuntur-atque" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 3L, "repellat-optio-similique-magnam-alias-et-officia-est" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 5L, "aut-qui-quasi-eos-repellendus-iusto-autem-doloremque" });

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
