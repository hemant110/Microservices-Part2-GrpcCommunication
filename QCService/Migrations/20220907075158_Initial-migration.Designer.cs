﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QCService.DBContexts;

namespace QCService.Migrations
{
    [DbContext(typeof(QualityCheckDbContext))]
    [Migration("20220907075158_Initial-migration")]
    partial class Initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QCService.Entities.Products", b =>
                {
                    b.Property<string>("Product_Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Product_Code");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("QCService.Entities.QualityCheck", b =>
                {
                    b.Property<Guid>("QualityCheckId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Company_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeletedTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Product_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QC_Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QC_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QC_List")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QC_ListDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QC_ListTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QC_Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QC_Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QC_Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Warehouse_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Warehouse_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QualityCheckId");

                    b.ToTable("QualityCheck");
                });
#pragma warning restore 612, 618
        }
    }
}