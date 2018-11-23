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
                    ImageID = table.Column<long>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time", "UserId" },
                values: new object[] { 3L, null, "reiciendis-ullam-deleniti-delectus-in-cupiditate-beatae-consequuntur-iusto-et-exercitationem-ut-nostrum-possimus-aut-sed-error-vel-ad-consectetur-cumque-et-labore-suscipit-explicabo-ut-vitae-porro-ut-quod-at-est-pariatur-labore-et-repellat-velit-maxime-reiciendis-consequatur-corporis-nemo-esse-doloribus-temporibus-aut-debitis-facilis-sint-possimus-fugit-tempora-corporis-eos-et-ut-veritatis-ratione-accusamus-tempora-dignissimos-commodi-vero-optio-facilis-id-iure-illo-a-consequatur-alias-qui-quo-et-rerum-reprehenderit-numquam-dolore-unde-sed-totam-iusto-quibusdam-molestias-et-et-iure-doloribus-ipsum-qui-recusandae-illo-officiis-placeat-molestiae-earum-ducimus-quisquam-ut-sit", null, new DateTime(2018, 4, 22, 20, 2, 42, 156, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time", "UserId" },
                values: new object[] { 5L, null, "ut-debitis-est-quos-et-sint-unde-maxime-aut-iste-alias-corrupti-ipsam-molestias-quia-nisi-qui-necessitatibus-quibusdam-nisi-voluptas-debitis-voluptate-impedit-odio-expedita-id-nulla-rerum-qui-dolorum-molestias-omnis-minima-non-eius-quam-vitae-nisi-molestiae-voluptatem-est-ut-ratione-iste-a-et-corrupti-qui-labore-sed-accusamus-debitis-vero-autem-voluptatem-totam-earum-illo-nulla-sit-nihil-odit-voluptate-recusandae-quos-itaque-aperiam-culpa-maiores-molestiae-quis-unde-accusamus-quia-adipisci-laboriosam-voluptatem-voluptatem-deleniti-accusantium-magnam-sed-ea-eos-placeat-harum-eligendi-et-et-facere-deleniti-doloremque-et-maxime-voluptatem-perspiciatis-magni-non-et", null, new DateTime(2018, 11, 15, 13, 3, 14, 297, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time", "UserId" },
                values: new object[] { 4L, null, "dolorem-est-aut-possimus-nostrum-reprehenderit-qui-aut-cum-dolores-illum-animi-facere-possimus-aut-similique-aliquid-quasi-sit-numquam-in-aut-quas-officiis-hic-hic-dicta-voluptatibus-rerum-earum-dolores-ut-commodi-provident-facilis-maxime-nobis-facere-suscipit-ut-asperiores-perferendis-dolores-ipsam-sed-blanditiis-sed-doloribus-repudiandae-quis-aspernatur-est-sit-ut-amet-earum-amet-labore-consequatur-laboriosam-corporis-velit-accusantium-minus-rerum-repudiandae-labore-eius-fugit-ut-aut-animi-minus-dolor-modi-eum-eum-amet-facere-dolores-eum-aspernatur-quasi-sunt-voluptas-nulla-sunt-qui-nisi-nihil-iste-dignissimos-rerum-repellat-recusandae-culpa-doloribus-omnis-cum-sed", null, new DateTime(2018, 9, 5, 6, 19, 27, 220, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time", "UserId" },
                values: new object[] { 2L, null, "est-sunt-et-velit-omnis-et-laudantium-quaerat-alias-quasi-rem-et-adipisci-laborum-inventore-expedita-voluptatibus-nihil-enim-architecto-autem-exercitationem-perferendis-occaecati-et-labore-voluptas-culpa-maiores-rerum-ut-ut-temporibus-quo-rerum-rerum-ut-totam-earum-eum-nulla-tenetur-ea-maxime-dolorum-ut-praesentium-accusantium-eveniet-ad-sunt-aut-occaecati-ex-vero-qui-natus-dolores-exercitationem-sed-aut-rerum-ad-commodi-ipsum-sunt-dolores-atque-qui-esse-nemo-sint-atque-odio-tempora-quam-saepe-ut-eveniet-consequatur-dolor-ullam-soluta-impedit-omnis-saepe-vel-iusto-at-quos-vitae-non-ipsum-ea-est-sapiente-soluta-eaque-in-ab", null, new DateTime(2018, 2, 16, 22, 22, 25, 64, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ImageID", "Text", "ThreadID", "Time", "UserId" },
                values: new object[] { 1L, null, "voluptatem-quia-nesciunt-voluptates-sequi-eveniet-et-et-non-amet-nobis-voluptatibus-dolorem-inventore-et-nobis-est-temporibus-voluptas-et-iusto-voluptates-aut-voluptatem-assumenda-delectus-dolorum-ut-deserunt-iure-expedita-corporis-reprehenderit-quia-tempora-aliquam-a-autem-dolorem-incidunt-qui-quisquam-sunt-voluptatem-aut-dolorem-reprehenderit-ea-ut-molestiae-tempore-qui-repellat-quia-porro-voluptate-neque-eos-eos-amet-ad-expedita-est-eos-provident-vel-deserunt-cumque-fugiat-laborum-est-saepe-delectus-sed-repudiandae-quo-suscipit-eligendi-numquam-rerum-in-numquam-alias-nam-porro-quaerat-nemo-numquam-ea-illum-explicabo-qui-expedita-rerum-a-non-architecto-et-temporibus-molestiae", null, new DateTime(2018, 8, 30, 6, 25, 40, 982, DateTimeKind.Local), null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Nathan.Huel29", 0, null, "ApplicationsUser", "Darren96@yahoo.com", true, false, null, null, null, null, null, true, null, false, null, 10L, null, "Damon", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Shanie.Parker86", 0, null, "ApplicationsUser", "Cameron.Robel@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 9L, null, "Dana", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Laurence.Upton16", 0, null, "ApplicationsUser", "Kaela.Daugherty78@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 1L, null, "Enrique", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Jasen.Crist38", 0, null, "ApplicationsUser", "Leola.Steuber8@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 7L, null, "Laisha", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Orland51", 0, null, "ApplicationsUser", "Doyle_Tillman@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 6L, null, "Sandra", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Damaris.Lockman68", 0, null, "ApplicationsUser", "Rory20@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 5L, null, "Raoul", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Jadyn.Keeling", 0, null, "ApplicationsUser", "Hershel72@hotmail.com", true, false, null, null, null, null, null, true, null, false, null, 4L, null, "Audra", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Darius.Kilback", 0, null, "ApplicationsUser", "Macie8@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 3L, null, "Brando", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Khalil_Schuppe70", 0, null, "ApplicationsUser", "Ryleigh67@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 2L, null, "Katharina", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ApplicationsUserID", "AvatarImageID", "NickName", "Password" },
                values: new object[] { "Guy_Kirlin88", 0, null, "ApplicationsUser", "Donnie.Schowalter@gmail.com", true, false, null, null, null, null, null, true, null, false, null, 8L, null, "Freddy", null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 5L, "Mitchell", "~/images/nothing.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 4L, "Bayer", "~/images/nothing.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 2L, "Kilback", "~/images/nothing.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 1L, "Wunsch", "~/images/nothing.jpg", true });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "Name", "Path", "isAvatar" },
                values: new object[] { 3L, "Bartell", "~/images/nothing.jpg", false });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 4L, "magni-molestias-sapiente-aut-molestias-quos-aut-eius" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 1L, "et-reprehenderit-assumenda-saepe-aut-in-aut-occaecati" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 2L, "excepturi-sunt-sit-dicta-in-sed-placeat-nulla" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 3L, "et-veritatis-ad-perspiciatis-et-sed-cumque-reiciendis" });

            migrationBuilder.InsertData(
                table: "Threads",
                columns: new[] { "ThreadID", "Title" },
                values: new object[] { 5L, "laudantium-dolores-laborum-ea-amet-voluptas-tempore-sequi" });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageID",
                table: "Articles",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ThreadID",
                table: "Articles",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

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
