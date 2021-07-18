using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketSystemDemo.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    TicketTypeKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    TicketName = table.Column<string>(type: "TEXT", nullable: true),
                    Summary = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsResolve = table.Column<bool>(type: "INTEGER", nullable: false),
                    Severity = table.Column<int>(type: "INTEGER", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketKey);
                });

            migrationBuilder.CreateTable(
                name: "TicketAuthority",
                columns: table => new
                {
                    TicketAuthorityKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserTypeKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsAdd = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsUpdate = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDel = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsResolve = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAuthority", x => x.TicketAuthorityKey);
                });

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    TicketTypeKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    TicketTypeName = table.Column<string>(type: "TEXT", nullable: true),
                    UserTypeKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResolveOnly = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketType", x => x.TicketTypeKey);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Userkey = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserTypeKey = table.Column<Guid>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Userkey);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeKey = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserTypeName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeKey);
                });

            migrationBuilder.InsertData(
                table: "TicketAuthority",
                columns: new[] { "TicketAuthorityKey", "IsAdd", "IsDel", "IsResolve", "IsUpdate", "UserTypeKey" },
                values: new object[] { new Guid("d46de679-d260-41cb-9f94-8c070a4f7966"), true, true, true, true, new Guid("15b65d1f-b1a4-4b68-b562-f2dad9882007") });

            migrationBuilder.InsertData(
                table: "TicketAuthority",
                columns: new[] { "TicketAuthorityKey", "IsAdd", "IsDel", "IsResolve", "IsUpdate", "UserTypeKey" },
                values: new object[] { new Guid("19af6d13-c5e2-4aad-8f0c-176b7b0235a4"), false, false, true, false, new Guid("8d5e5e67-6c1f-4379-bba2-ee0436253d85") });

            migrationBuilder.InsertData(
                table: "TicketType",
                columns: new[] { "TicketTypeKey", "ReadOnly", "ResolveOnly", "TicketTypeName", "UserTypeKey" },
                values: new object[] { new Guid("146c4440-62e1-4aba-b120-f061554c57f5"), false, false, "Default", new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "TicketType",
                columns: new[] { "TicketTypeKey", "ReadOnly", "ResolveOnly", "TicketTypeName", "UserTypeKey" },
                values: new object[] { new Guid("f8bc3132-6332-4b58-afe9-1f9649ed3a6d"), false, true, "Feature Request", new Guid("76226cc0-20d3-4004-90e9-5f34dd5aef24") });

            migrationBuilder.InsertData(
                table: "TicketType",
                columns: new[] { "TicketTypeKey", "ReadOnly", "ResolveOnly", "TicketTypeName", "UserTypeKey" },
                values: new object[] { new Guid("91741c42-3e16-4c16-97e5-7e31dbef8b83"), true, false, "Test Case", new Guid("15b65d1f-b1a4-4b68-b562-f2dad9882007") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Userkey", "UserName", "UserTypeKey" },
                values: new object[] { new Guid("cc96a024-e68b-4682-a6b2-c11632b197fd"), "QA User", new Guid("15b65d1f-b1a4-4b68-b562-f2dad9882007") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Userkey", "UserName", "UserTypeKey" },
                values: new object[] { new Guid("52dba8a3-89d7-4e89-9644-faa6cb012fa7"), "RD User", new Guid("8d5e5e67-6c1f-4379-bba2-ee0436253d85") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Userkey", "UserName", "UserTypeKey" },
                values: new object[] { new Guid("c22224c6-cb86-46bc-954c-dea23291f65d"), "PM User", new Guid("76226cc0-20d3-4004-90e9-5f34dd5aef24") });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Userkey", "UserName", "UserTypeKey" },
                values: new object[] { new Guid("0b87b103-c317-4be1-bc77-bfbda650f44a"), "Admin", new Guid("cbea8e8f-8b9f-48b5-a7d3-40c9be502fd8") });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeKey", "UserTypeName" },
                values: new object[] { new Guid("15b65d1f-b1a4-4b68-b562-f2dad9882007"), "QA" });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeKey", "UserTypeName" },
                values: new object[] { new Guid("8d5e5e67-6c1f-4379-bba2-ee0436253d85"), "RD" });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeKey", "UserTypeName" },
                values: new object[] { new Guid("76226cc0-20d3-4004-90e9-5f34dd5aef24"), "PM" });

            migrationBuilder.InsertData(
                table: "UserType",
                columns: new[] { "UserTypeKey", "UserTypeName" },
                values: new object[] { new Guid("cbea8e8f-8b9f-48b5-a7d3-40c9be502fd8"), "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketAuthority");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
