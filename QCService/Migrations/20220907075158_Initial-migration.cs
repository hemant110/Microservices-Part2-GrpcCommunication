using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QCService.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Product_Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Product_Code);
                });

            migrationBuilder.CreateTable(
                name: "QualityCheck",
                columns: table => new
                {
                    QualityCheckId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Product_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QC_Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QC_List = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QC_ListDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QC_ListTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QC_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QC_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QC_Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QC_Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_QualityCheck", x => x.QualityCheckId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "QualityCheck");
        }
    }
}
