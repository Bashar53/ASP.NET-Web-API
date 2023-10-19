﻿// <auto-generated />
using System;
using IBoss.DbCon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IBoss.Migrations
{
    [DbContext(typeof(IBossProjectDbContext))]
    partial class IBossProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IBoss.Models.tblEmployee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("EmployeeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EmployeeSalary")
                        .HasColumnType("float");

                    b.Property<int>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 502030,
                            EmployeeCode = "EMP320",
                            EmployeeName = "Mehedi Hasan",
                            EmployeeSalary = 50000.0,
                            SupervisorId = 502036
                        },
                        new
                        {
                            EmployeeId = 502031,
                            EmployeeCode = "EMP321",
                            EmployeeName = "Ashikur Rahman",
                            EmployeeSalary = 45000.0,
                            SupervisorId = 502036
                        },
                        new
                        {
                            EmployeeId = 502032,
                            EmployeeCode = "EMP322",
                            EmployeeName = "Rakibul Islam",
                            EmployeeSalary = 52000.0,
                            SupervisorId = 502030
                        },
                        new
                        {
                            EmployeeId = 502033,
                            EmployeeCode = "EMP323",
                            EmployeeName = "Hasan Abdullah",
                            EmployeeSalary = 46000.0,
                            SupervisorId = 502031
                        },
                        new
                        {
                            EmployeeId = 502034,
                            EmployeeCode = "EMP324",
                            EmployeeName = "Akib Khan",
                            EmployeeSalary = 66000.0,
                            SupervisorId = 502032
                        },
                        new
                        {
                            EmployeeId = 502035,
                            EmployeeCode = "EMP325",
                            EmployeeName = "Rasel Shikder",
                            EmployeeSalary = 53500.0,
                            SupervisorId = 502033
                        },
                        new
                        {
                            EmployeeId = 502036,
                            EmployeeCode = "EMP326",
                            EmployeeName = "Selim Reja",
                            EmployeeSalary = 59000.0,
                            SupervisorId = 502035
                        });
                });

            modelBuilder.Entity("IBoss.Models.tblEmployeeAttendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AttendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAbsent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOffday")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit");

                    b.Property<int>("tblEmployeeEmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("tblEmployeeEmployeeId");

                    b.ToTable("EmployeeAttendances");
                });

            modelBuilder.Entity("IBoss.Models.tblEmployeeAttendance", b =>
                {
                    b.HasOne("IBoss.Models.tblEmployee", "tblEmployee")
                        .WithMany("EmployeeAttendances")
                        .HasForeignKey("tblEmployeeEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tblEmployee");
                });

            modelBuilder.Entity("IBoss.Models.tblEmployee", b =>
                {
                    b.Navigation("EmployeeAttendances");
                });
#pragma warning restore 612, 618
        }
    }
}
