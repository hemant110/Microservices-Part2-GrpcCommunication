using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderReceive.Migrations
{
    public partial class UpdatedSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderHeader",
                keyColumn: "OrderHeaderId",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "Billed",
                value: "No");

            migrationBuilder.UpdateData(
                table: "OrderHeader",
                keyColumn: "OrderHeaderId",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                column: "Billed",
                value: "No");

            migrationBuilder.UpdateData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "ProductDescription",
                value: "Mobile");

            migrationBuilder.UpdateData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                column: "ProductDescription",
                value: "Laptop");

            migrationBuilder.UpdateData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                column: "ProductDescription",
                value: "Charger");

            migrationBuilder.UpdateData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                column: "ProductDescription",
                value: "Mobile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderHeader",
                keyColumn: "OrderHeaderId",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "Billed",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderHeader",
                keyColumn: "OrderHeaderId",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                column: "Billed",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                column: "ProductDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                column: "ProductDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                column: "ProductDescription",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderLines",
                keyColumn: "Id",
                keyValue: new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                column: "ProductDescription",
                value: null);
        }
    }
}
