﻿// <auto-generated />
using System;
using LAB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LAB.Migrations
{
    [DbContext(typeof(LABAppContext))]
    partial class LABAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LAB.Models.Budget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("CountOfBudget")
                        .HasColumnType("float");

                    b.Property<double>("EmployeeRate")
                        .HasColumnType("float");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Budgets");
                });

            modelBuilder.Entity("LAB.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("LAB.Models.FinishedProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeasurementId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementId");

                    b.ToTable("FinishedProducts");
                });

            modelBuilder.Entity("LAB.Models.Ingredients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FinishedProductsId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int?>("RawsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinishedProductsId");

                    b.HasIndex("RawsId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("LAB.Models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Measurements")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("LAB.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("LAB.Models.Production", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FinishedProductsId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FinishedProductsId");

                    b.ToTable("Productions");
                });

            modelBuilder.Entity("LAB.Models.PurchaseRaw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("RawId")
                        .HasColumnType("int");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RawId");

                    b.ToTable("PurchaseRaws");
                });

            modelBuilder.Entity("LAB.Models.Raw", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeasurementId")
                        .HasColumnType("int");

                    b.Property<string>("NameOfRaw")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MeasurementId");

                    b.ToTable("Raws");
                });

            modelBuilder.Entity("LAB.Models.Salary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Confirm")
                        .HasColumnType("bit");

                    b.Property<int>("CountOfWork")
                        .HasColumnType("int");

                    b.Property<double>("FinishSalary")
                        .HasColumnType("float");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("employeeId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("LAB.Models.Sell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("FinishedProductsId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<double>("Sum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("FinishedProductsId");

                    b.ToTable("Sells");
                });

            modelBuilder.Entity("LAB.Models.Employee", b =>
                {
                    b.HasOne("LAB.Models.Position", "Position")
                        .WithMany("employees")
                        .HasForeignKey("PositionId");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("LAB.Models.FinishedProducts", b =>
                {
                    b.HasOne("LAB.Models.Measurement", "Measurement")
                        .WithMany("FinishedProducts")
                        .HasForeignKey("MeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("LAB.Models.Ingredients", b =>
                {
                    b.HasOne("LAB.Models.FinishedProducts", "FinishedProducts")
                        .WithMany("Ingredients")
                        .HasForeignKey("FinishedProductsId");

                    b.HasOne("LAB.Models.Raw", "Raws")
                        .WithMany("Ingredients")
                        .HasForeignKey("RawsId");

                    b.Navigation("FinishedProducts");

                    b.Navigation("Raws");
                });

            modelBuilder.Entity("LAB.Models.Production", b =>
                {
                    b.HasOne("LAB.Models.Employee", "Employee")
                        .WithMany("productions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAB.Models.FinishedProducts", "FinishedProducts")
                        .WithMany("productions")
                        .HasForeignKey("FinishedProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("FinishedProducts");
                });

            modelBuilder.Entity("LAB.Models.PurchaseRaw", b =>
                {
                    b.HasOne("LAB.Models.Employee", "Employee")
                        .WithMany("PurchaseRaws")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAB.Models.Raw", "Raw")
                        .WithMany("PurchaseRaws")
                        .HasForeignKey("RawId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Raw");
                });

            modelBuilder.Entity("LAB.Models.Raw", b =>
                {
                    b.HasOne("LAB.Models.Measurement", "Measurement")
                        .WithMany("Raws")
                        .HasForeignKey("MeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Measurement");
                });

            modelBuilder.Entity("LAB.Models.Salary", b =>
                {
                    b.HasOne("LAB.Models.Employee", "Employee")
                        .WithMany("salaries")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("LAB.Models.Sell", b =>
                {
                    b.HasOne("LAB.Models.Employee", "Employee")
                        .WithMany("Sells")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAB.Models.FinishedProducts", "FinishedProducts")
                        .WithMany("Sells")
                        .HasForeignKey("FinishedProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("FinishedProducts");
                });

            modelBuilder.Entity("LAB.Models.Employee", b =>
                {
                    b.Navigation("productions");

                    b.Navigation("PurchaseRaws");

                    b.Navigation("salaries");

                    b.Navigation("Sells");
                });

            modelBuilder.Entity("LAB.Models.FinishedProducts", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("productions");

                    b.Navigation("Sells");
                });

            modelBuilder.Entity("LAB.Models.Measurement", b =>
                {
                    b.Navigation("FinishedProducts");

                    b.Navigation("Raws");
                });

            modelBuilder.Entity("LAB.Models.Position", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("LAB.Models.Raw", b =>
                {
                    b.Navigation("Ingredients");

                    b.Navigation("PurchaseRaws");
                });
#pragma warning restore 612, 618
        }
    }
}
