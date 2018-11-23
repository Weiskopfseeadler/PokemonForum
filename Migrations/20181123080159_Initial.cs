using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PokemonForum.Migrations
{
    public partial class Initial : Migration
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
                values: new object[] { 3L, null, "autem-et-impedit-accusamus-perferendis-odio-dolor-saepe-fugiat-id-eum-porro-facere-est-rerum-nulla-odio-possimus-ut-eos-neque-sed-ut-amet-eum-voluptas-aut-ex-ut-rem-assumenda-ad-et-rerum-qui-reiciendis-officiis-qui-voluptatibus-aut-rerum-voluptas-doloremque-soluta-necessitatibus-quia-error-placeat-saepe-tempora-pariatur-enim-eius-eum-error-aliquam-reiciendis-occaecati-atque-ipsum-quidem-dolorem-perspiciatis-ea-ut-omnis-numquam-accusamus-enim-distinctio-aut-dolorum-omnis-quaerat-eius-qui-molestias-qui-exercitationem-veritatis-minima-illo-praesentium-quia-fuga-blanditiis-illo-sed-voluptatem-velit-repellat-aliquid-suscipit-vel-laboriosam-illum-eius-libero-impedit-suscipit", null, new DateTime(2018, 10, 15, 19, 4, 26, 326, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 5L, null, "ducimus-et-placeat-ipsam-magnam-animi-animi-iusto-eos-quod-repellendus-sint-magni-in-provident-officiis-vel-laborum-consequatur-quo-qui-sint-eos-quo-deleniti-corporis-aut-magnam-ut-a-labore-beatae-delectus-harum-et-molestiae-esse-harum-magni-ullam-vitae-nobis-sunt-nihil-iure-qui-fugit-debitis-vel-dolor-quis-unde-sed-aliquam-quisquam-non-possimus-voluptates-quo-rerum-quisquam-ut-dicta-ut-et-nihil-omnis-dolores-et-odit-praesentium-sit-atque-impedit-possimus-blanditiis-molestiae-sequi-qui-laboriosam-consectetur-alias-odio-ipsum-officia-eligendi-perspiciatis-impedit-repudiandae-asperiores-libero-molestias-quibusdam-sit-in-minus-mollitia-amet-sed-soluta", null, new DateTime(2018, 4, 21, 21, 35, 1, 431, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 4L, null, "eligendi-deleniti-ut-magnam-tempora-sed-sapiente-dolorem-dolorem-maxime-reprehenderit-modi-nihil-necessitatibus-qui-commodi-quam-minus-sint-dolores-aspernatur-omnis-architecto-distinctio-fuga-veniam-sapiente-et-in-dolor-quo-debitis-sapiente-a-officia-in-tempora-officiis-qui-sint-explicabo-tenetur-voluptatem-qui-est-consequuntur-repudiandae-et-possimus-qui-quibusdam-itaque-adipisci-quo-consequatur-qui-ea-sunt-et-rerum-in-ipsa-voluptas-doloribus-voluptates-sint-voluptatem-totam-corporis-consequatur-eos-unde-suscipit-mollitia-ea-ratione-in-dolorum-illo-dolores-quis-ipsa-dolorem-hic-vel-ut-soluta-quia-hic-dignissimos-ipsum-expedita-et-qui-nisi-illo-amet-nesciunt-perspiciatis-sunt", null, new DateTime(2018, 1, 12, 7, 12, 36, 860, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 2L, null, "et-qui-dolores-sint-voluptate-alias-dolorum-odit-non-temporibus-sunt-temporibus-vero-soluta-sit-molestiae-voluptas-quisquam-minima-sint-quia-nam-quo-libero-voluptatem-odio-ratione-adipisci-reiciendis-ipsum-eos-necessitatibus-aut-blanditiis-repellat-minima-quas-soluta-dignissimos-reprehenderit-et-velit-dolorem-odit-molestiae-perspiciatis-adipisci-molestiae-laborum-nostrum-quia-quisquam-quasi-ipsam-deserunt-in-natus-laudantium-commodi-ut-vero-molestiae-consequuntur-possimus-et-soluta-illum-in-nobis-et-nihil-neque-minima-necessitatibus-quam-omnis-voluptas-qui-maxime-est-dolore-eius-culpa-est-repellat-esse-qui-expedita-eos-quam-porro-eaque-voluptatem-rem-provident-quasi-quis-quasi-blanditiis-et", null, new DateTime(2018, 3, 3, 17, 15, 0, 210, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time" },
                values: new object[] { 1L, null, "tenetur-beatae-rem-voluptas-dolorem-distinctio-dolores-labore-ipsam-dolorem-voluptas-molestias-nostrum-asperiores-voluptatum-illum-et-minima-facilis-ut-dolore-officia-ut-voluptatum-nobis-et-aut-recusandae-velit-maxime-voluptatem-qui-illum-officiis-quaerat-enim-sit-consequuntur-non-expedita-omnis-inventore-aut-accusantium-enim-praesentium-nam-magni-ullam-alias-saepe-possimus-laborum-ullam-sed-commodi-vel-asperiores-beatae-et-vero-natus-eaque-sunt-cum-eaque-eligendi-quam-minus-dolorem-corrupti-corrupti-facere-doloribus-adipisci-consectetur-in-labore-sed-modi-et-cum-quidem-adipisci-pariatur-qui-sed-occaecati-facere-saepe-dolores-suscipit-ab-est-quibusdam-numquam-sit-odio-aliquid-incidunt", null, new DateTime(2018, 2, 16, 1, 53, 31, 231, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Delbert.Feil", 0, null, "ApplicationsUser", "Theodore95@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 10L, null, "Kathryne", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Kelsie54", 0, null, "ApplicationsUser", "Marielle.McKenzie73@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 9L, null, "Cooper", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Levi_Farrell19", 0, null, "ApplicationsUser", "Jessy_Gislason@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 1L, null, "Annabell", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Luna.Pfeffer93", 0, null, "ApplicationsUser", "Tessie_Dibbert@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 7L, null, "Cesar", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Alexander77", 0, null, "ApplicationsUser", "Matilde.Kreiger@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 6L, null, "Rachelle", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Amara_Gutkowski", 0, null, "ApplicationsUser", "Savanah_Huel@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 5L, null, "Reva", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Kieran.Sanford39", 0, null, "ApplicationsUser", "Cornelius.OConner@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 4L, null, "Lindsey", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Howell.Wiegand", 0, null, "ApplicationsUser", "Ryleigh_Flatley74@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 3L, null, "Brendon", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Jada_Kuphal90", 0, null, "ApplicationsUser", "Ramona_Cronin65@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 2L, null, "Teresa", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Tremaine_Cruickshank", 0, null, "ApplicationsUser", "Dominique37@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 8L, null, "Arnulfo", null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 5L, "DuBuque", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 4L, "Mertz", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 2L, "Gaylord", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 1L, "McKenzie", "~/images/nothing.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 3L, "Ankunding", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 4L, "ipsam-enim-exercitationem-voluptas-at-eaque-ut-a" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 1L, "et-molestias-quidem-sapiente-et-ut-sint-sed" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 2L, "excepturi-et-eos-molestiae-impedit-sit-aliquam-amet" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 3L, "maiores-dicta-ut-numquam-iure-et-saepe-ex" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 5L, "quia-omnis-illum-excepturi-aperiam-aliquam-enim-commodi" });

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
