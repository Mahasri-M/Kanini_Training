using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Booking_System.Migrations
{
    /// <inheritdoc />
    public partial class hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Hotel_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hotel_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Hotel_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "11, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "200, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<double>(type: "float", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customers_Hotels_Hotel_Id",
                        column: x => x.Hotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "50, 1"),
                    Employee_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Employee_Id);
                    table.ForeignKey(
                        name: "FK_Employees_Hotels_Hotel_Id",
                        column: x => x.Hotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    Room_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hotel_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_Hotel_Id",
                        column: x => x.Hotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id");
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "150, 1"),
                    Booking_Person_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Phone_Number = table.Column<double>(type: "float", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hotel_Id = table.Column<int>(type: "int", nullable: true),
                    Room_Id = table.Column<int>(type: "int", nullable: true),
                    Customer_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Book_Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customers",
                        principalColumn: "Customer_Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Hotels_Hotel_Id",
                        column: x => x.Hotel_Id,
                        principalTable: "Hotels",
                        principalColumn: "Hotel_Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_Room_Id",
                        column: x => x.Room_Id,
                        principalTable: "Rooms",
                        principalColumn: "Room_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Customer_Id",
                table: "Bookings",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Hotel_Id",
                table: "Bookings",
                column: "Hotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_Room_Id",
                table: "Bookings",
                column: "Room_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Hotel_Id",
                table: "Customers",
                column: "Hotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Hotel_Id",
                table: "Employees",
                column: "Hotel_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_Hotel_Id",
                table: "Rooms",
                column: "Hotel_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Hotels");
        }
    }
}
