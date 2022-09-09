using Microsoft.EntityFrameworkCore;
using OrderReceive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.DBContexts
{
    public class OrderReceiveDbContext :DbContext
    {
        public OrderReceiveDbContext(DbContextOptions<OrderReceiveDbContext> options) : base(options)
        {
        }

        public DbSet<OrderChangeProduct> OrderChangeProduct { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Products>().HasData(
                new Products { Product = "Laptop", Unit = "Qty" },
                new Products { Product = "Mobile", Unit = "Qty" },
                new Products { Product = "Charger", Unit = "Qty" }
                );

            //modelBuilder.Entity<OrderHeader>().HasMany(x => x.OrderLines)
            //.WithMany().IsRequired();

            modelBuilder.Entity<OrderHeader>().HasData(
                new OrderHeader
                {
                    OrderHeaderId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    Order_Code = "ORDER_001",
                    Order_Date = "20-01-2022",
                    Order_Status = "Pending",
                    Order_Time = "10:00:00",
                    Order_Type = "Manual",
                    Billed = "No",
                    Active =true,
                    Company_Code="ABC",
                    Company_Name="ABC",
                    CreatedBy="User1",
                    CreatedDate=new DateTime().Date.ToString(),
                    CreatedTime=new DateTime().TimeOfDay.ToString(),
                    Customer_Code="CUSTOMER_1",
                    Customer_Name="Customer Name 1",
                    Warehouse_Code="WAREHOUSE_1",
                    Warehouse_Name="Warehouse Name 1",
                    IsDeleted = false
                },
                new OrderHeader
                {
                    OrderHeaderId = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}"),
                    Order_Code = "ORDER_002",
                    Order_Date = "20-01-2022",
                    Order_Status = "Pending",
                    Order_Time = "10:00:00",
                    Order_Type = "Manual",
                    Billed = "No",
                    Active = true,
                    Company_Code = "ABC",
                    Company_Name = "ABC",
                    CreatedBy = "User1",
                    CreatedDate = new DateTime().Date.ToString(),
                    CreatedTime = new DateTime().TimeOfDay.ToString(),
                    Customer_Code = "CUSTOMER_1",
                    Customer_Name = "Customer Name 1",
                    Warehouse_Code = "WAREHOUSE_1",
                    Warehouse_Name = "Warehouse Name 1",
                    IsDeleted = false
                }
                );

            modelBuilder.Entity<OrderLines>().HasData(
                new OrderLines
                {
                    Id = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    OrderHeaderId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    LineId = "ORDER_LINE_001",
                    Order_Code="ORDER_001",
                    ProductCode = "Laptop",
                    ProductDescription = "Laptop",
                    Status ="Pending",
                    Unit="10",
                    QtyPerBox=5,
                    QtyOrdered=10,
                    QtyPlanned=10,
                    Active = true,
                    Company_Code = "ABC",
                    Company_Name = "ABC",
                    CreatedBy = "User1",
                    CreatedDate = new DateTime().Date.ToString(),
                    CreatedTime = new DateTime().TimeOfDay.ToString(),
                    Customer_Code = "CUSTOMER_1",
                    Customer_Name = "Customer Name 1",
                    Warehouse_Code = "WAREHOUSE_1",
                    Warehouse_Name = "Warehouse Name 1",
                    IsDeleted = false
                },

                new OrderLines
                {
                    Id = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}"),
                    OrderHeaderId = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}"),
                    LineId = "ORDER_LINE_002",
                    Order_Code = "ORDER_001",
                    ProductCode = "Mobile",
                    ProductDescription = "Mobile",
                    Status = "Pending",
                    Unit = "10",
                    QtyPerBox = 5,
                    QtyOrdered = 10,
                    QtyPlanned = 10,
                    Active = true,
                    Company_Code = "ABC",
                    Company_Name = "ABC",
                    CreatedBy = "User1",
                    CreatedDate = new DateTime().Date.ToString(),
                    CreatedTime = new DateTime().TimeOfDay.ToString(),
                    Customer_Code = "CUSTOMER_1",
                    Customer_Name = "Customer Name 1",
                    Warehouse_Code = "WAREHOUSE_1",
                    Warehouse_Name = "Warehouse Name 1",
                    IsDeleted = false
                },
                new OrderLines
                {
                    Id = Guid.Parse("{BF3F3002-7E53-441E-8B76-F6280BE284AA}"),
                    OrderHeaderId = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}"),
                    LineId = "ORDER_LINE_003",
                    Order_Code = "ORDER_002",
                    ProductCode = "Charger",
                    ProductDescription = "Charger",
                    Status = "Pending",
                    Unit = "5",
                    QtyPerBox = 5,
                    QtyOrdered = 10,
                    QtyPlanned = 10,
                    Active = true,
                    Company_Code = "ABC",
                    Company_Name = "ABC",
                    CreatedBy = "User1",
                    CreatedDate = new DateTime().Date.ToString(),
                    CreatedTime = new DateTime().TimeOfDay.ToString(),
                    Customer_Code = "CUSTOMER_1",
                    Customer_Name = "Customer Name 1",
                    Warehouse_Code = "WAREHOUSE_1",
                    Warehouse_Name = "Warehouse Name 1",
                    IsDeleted = false
                },
                new OrderLines
                {
                    Id = Guid.Parse("{FE98F549-E790-4E9F-AA16-18C2292A2EE9}"),
                    OrderHeaderId = Guid.Parse("{6313179F-7837-473A-A4D5-A5571B43E6A6}"),
                    LineId = "ORDER_LINE_004",
                    Order_Code = "ORDER_002",
                    ProductCode = "Mobile",
                    ProductDescription = "Mobile",
                    Status = "Pending",
                    Unit = "10",
                    QtyPerBox = 10,
                    QtyOrdered = 10,
                    QtyPlanned = 10,
                    Active = true,
                    Company_Code = "ABC",
                    Company_Name = "ABC",
                    CreatedBy = "User1",
                    CreatedDate = new DateTime().Date.ToString(),
                    CreatedTime = new DateTime().TimeOfDay.ToString(),
                    Customer_Code = "CUSTOMER_1",
                    Customer_Name = "Customer Name 1",
                    Warehouse_Code = "WAREHOUSE_1",
                    Warehouse_Name = "Warehouse Name 1",
                    IsDeleted = false
                }
                );
        }
    }
}
