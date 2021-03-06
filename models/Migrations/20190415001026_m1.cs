﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace models.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true),
                    Number_of_floors = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Electric",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Power = table.Column<double>(nullable: false),
                    UsingOfDay = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electric", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Post = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_of_rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_of_rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lighting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ElectricId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lighting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lighting_Electric_ElectricId",
                        column: x => x.ElectricId,
                        principalTable: "Electric",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricsByOrganization",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ElectricId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricsByOrganization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricsByOrganization_Electric_ElectricId",
                        column: x => x.ElectricId,
                        principalTable: "Electric",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElectricsByOrganization_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    Type_of_roomId = table.Column<Guid>(nullable: false),
                    BuildingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Type_of_rooms_Type_of_roomId",
                        column: x => x.Type_of_roomId,
                        principalTable: "Type_of_rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room_rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InputDate = table.Column<DateTime>(nullable: false),
                    OutputDate = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_rental", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Room_rental_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Room_rental_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricsByOrganization_ElectricId",
                table: "ElectricsByOrganization",
                column: "ElectricId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricsByOrganization_OrganizationId",
                table: "ElectricsByOrganization",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Lighting_ElectricId",
                table: "Lighting",
                column: "ElectricId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_rental_OrganizationId",
                table: "Room_rental",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_rental_RoomId",
                table: "Room_rental",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Type_of_roomId",
                table: "Rooms",
                column: "Type_of_roomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricsByOrganization");

            migrationBuilder.DropTable(
                name: "Lighting");

            migrationBuilder.DropTable(
                name: "Room_rental");

            migrationBuilder.DropTable(
                name: "Electric");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Type_of_rooms");
        }
    }
}
