﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QnSCommunityCount.Logic.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Account");

            migrationBuilder.EnsureSchema(
                name: "App");

            migrationBuilder.CreateTable(
                name: "Identity",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    Guid = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    EnableJwtAuth = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Designation = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostCollection",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Designation = table.Column<string>(maxLength: 256, nullable: true),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    Currency = table.Column<string>(maxLength: 10, nullable: false),
                    Members = table.Column<string>(maxLength: 256, nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActionLog",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IdentityId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionLog_Identity_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "Account",
                        principalTable: "Identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoginSession",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IdentityId = table.Column<int>(nullable: false),
                    SessionToken = table.Column<string>(maxLength: 256, nullable: false),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    LastAccess = table.Column<DateTime>(nullable: false),
                    LogoutTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginSession_Identity_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "Account",
                        principalTable: "Identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityXRole",
                schema: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    IdentityId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityXRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityXRole_Identity_IdentityId",
                        column: x => x.IdentityId,
                        principalSchema: "Account",
                        principalTable: "Identity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentityXRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Account",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostRecord",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CostCollectionId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Designation = table.Column<string>(maxLength: 256, nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Member = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostRecord_CostCollection_CostCollectionId",
                        column: x => x.CostCollectionId,
                        principalSchema: "App",
                        principalTable: "CostCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionLog_IdentityId",
                schema: "Account",
                table: "ActionLog",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Identity_Email",
                schema: "Account",
                table: "Identity",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityXRole_IdentityId",
                schema: "Account",
                table: "IdentityXRole",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityXRole_RoleId",
                schema: "Account",
                table: "IdentityXRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginSession_IdentityId",
                schema: "Account",
                table: "LoginSession",
                column: "IdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Designation",
                schema: "Account",
                table: "Role",
                column: "Designation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CostCollection_Designation",
                schema: "App",
                table: "CostCollection",
                column: "Designation",
                unique: true,
                filter: "[Designation] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CostRecord_CostCollectionId",
                schema: "App",
                table: "CostRecord",
                column: "CostCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLog",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "IdentityXRole",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "LoginSession",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "CostRecord",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "Identity",
                schema: "Account");

            migrationBuilder.DropTable(
                name: "CostCollection",
                schema: "App");
        }
    }
}
