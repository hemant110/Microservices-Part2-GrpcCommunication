using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderReceive.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderChangeProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    OrderChangeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderChangeProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeader",
                columns: table => new
                {
                    OrderHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order_Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Billed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeader", x => x.OrderHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyPerBox = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QtyOrdered = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyPlanned = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyAllocated = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    QtyPicked = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Customer_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Warehouse_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_OrderHeader_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeader",
                        principalColumn: "OrderHeaderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderHeader",
                columns: new[] { "OrderHeaderId", "Active", "Billed", "Company_Code", "Company_Name", "CreatedBy", "CreatedDate", "CreatedTime", "Customer_Code", "Customer_Name", "DeletedBy", "DeletedDate", "DeletedTime", "IsDeleted", "Order_Code", "Order_Date", "Order_Notes", "Order_Status", "Order_Time", "Order_Type", "UpdatedBy", "UpdatedDate", "UpdatedTime", "Warehouse_Code", "Warehouse_Name" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), true, null, "ABC", "ABC", "User1", "1/1/0001 12:00:00 AM", "00:00:00", "CUSTOMER_1", "Customer Name 1", null, null, null, false, "ORDER_001", "20-01-2022", null, "Pending", "10:00:00", "Manual", null, null, null, "WAREHOUSE_1", "Warehouse Name 1" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), true, null, "ABC", "ABC", "User1", "1/1/0001 12:00:00 AM", "00:00:00", "CUSTOMER_1", "Customer Name 1", null, null, null, false, "ORDER_002", "20-01-2022", null, "Pending", "10:00:00", "Manual", null, null, null, "WAREHOUSE_1", "Warehouse Name 1" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Product", "Unit" },
                values: new object[,]
                {
                    { "Laptop", "Qty" },
                    { "Mobile", "Qty" },
                    { "Charger", "Qty" }
                });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "Id", "Active", "Company_Code", "Company_Name", "CreatedBy", "CreatedDate", "CreatedTime", "Customer_Code", "Customer_Name", "DeletedBy", "DeletedDate", "DeletedTime", "IsDeleted", "LineId", "Notes", "OrderHeaderId", "Order_Code", "ProductCode", "ProductDescription", "QtyAllocated", "QtyOrdered", "QtyPerBox", "QtyPicked", "QtyPlanned", "Status", "Unit", "UpdatedBy", "UpdatedDate", "UpdatedTime", "Warehouse_Code", "Warehouse_Name" },
                values: new object[,]
                {
                    { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), true, "ABC", "ABC", "User1", "1/1/0001 12:00:00 AM", "00:00:00", "CUSTOMER_1", "Customer Name 1", null, null, null, false, "ORDER_LINE_001", null, new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "ORDER_001", "Laptop", null, 0m, 10m, 5m, 0m, 10m, "Pending", "10", null, null, null, "WAREHOUSE_1", "Warehouse Name 1" },
                    { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), true, "ABC", "ABC", "User1", "1/1/0001 12:00:00 AM", "00:00:00", "CUSTOMER_1", "Customer Name 1", null, null, null, false, "ORDER_LINE_002", null, new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "ORDER_001", "Mobile", null, 0m, 10m, 5m, 0m, 10m, "Pending", "10", null, null, null, "WAREHOUSE_1", "Warehouse Name 1" },
                    { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), true, "ABC", "ABC", "User1", "1/1/0001 12:00:00 AM", "00:00:00", "CUSTOMER_1", "Customer Name 1", null, null, null, false, "ORDER_LINE_003", null, new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "ORDER_002", "Charger", null, 0m, 10m, 5m, 0m, 10m, "Pending", "5", null, null, null, "WAREHOUSE_1", "Warehouse Name 1" },
                    { new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"), true, "ABC", "ABC", "User1", "1/1/0001 12:00:00 AM", "00:00:00", "CUSTOMER_1", "Customer Name 1", null, null, null, false, "ORDER_LINE_004", null, new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "ORDER_002", "Mobile", null, 0m, 10m, 10m, 0m, 10m, "Pending", "10", null, null, null, "WAREHOUSE_1", "Warehouse Name 1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderHeaderId",
                table: "OrderLines",
                column: "OrderHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderChangeProduct");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderHeader");
        }
    }
}
