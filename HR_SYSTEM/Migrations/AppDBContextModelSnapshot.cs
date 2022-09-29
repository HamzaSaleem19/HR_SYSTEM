﻿// <auto-generated />
using HR_SYSTEM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HR_SYSTEM.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HR_SYSTEM.Models.Company", b =>
                {
                    b.Property<int>("CompanyRegNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandlineNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyRegNo");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Department", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CompanyRegNo")
                        .HasColumnType("int");

                    b.Property<string>("DepName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LandlineNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepId");

                    b.HasIndex("CompanyRegNo");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Employee", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cnic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyRegNo")
                        .HasColumnType("int");

                    b.Property<int>("DepId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.HasIndex("DepId");

                    b.HasIndex("RoleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.MobileNo", b =>
                {
                    b.Property<int>("MobileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CompanyRegNo")
                        .HasColumnType("int");

                    b.Property<int>("DepId")
                        .HasColumnType("int");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MobileId");

                    b.HasIndex("EmpId");

                    b.ToTable("MobileNumbers");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("RoleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Department", b =>
                {
                    b.HasOne("HR_SYSTEM.Models.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyRegNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Employee", b =>
                {
                    b.HasOne("HR_SYSTEM.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HR_SYSTEM.Models.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.MobileNo", b =>
                {
                    b.HasOne("HR_SYSTEM.Models.Employee", "Employee")
                        .WithMany("MobileNos")
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Company", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Employee", b =>
                {
                    b.Navigation("MobileNos");
                });

            modelBuilder.Entity("HR_SYSTEM.Models.Role", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
