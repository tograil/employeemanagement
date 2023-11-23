﻿// <auto-generated />
using System;
using EmployeeManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagement.Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20231123210107_ManagerNotNeeded")]
    partial class ManagerNotNeeded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeManagement.Domain.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeManagement.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("17a65533-756a-4959-a65e-e47b322aa08f"),
                            Name = "Director"
                        },
                        new
                        {
                            Id = new Guid("33230b26-092e-41b8-a7f9-a9f2ab5a0296"),
                            Name = "IT"
                        },
                        new
                        {
                            Id = new Guid("454438e1-cc71-4c44-a8b2-3f2a71046c55"),
                            Name = "Support"
                        },
                        new
                        {
                            Id = new Guid("f81c3471-369a-4d2d-a9fc-d971e6f64879"),
                            Name = "Analyst"
                        },
                        new
                        {
                            Id = new Guid("40822d9d-f06c-4f3f-b33e-d2d1427441ee"),
                            Name = "Sales"
                        },
                        new
                        {
                            Id = new Guid("fa55484b-ce48-4124-965f-414ab2abde08"),
                            Name = "Accounteing"
                        });
                });

            modelBuilder.Entity("EmployeeRole", b =>
                {
                    b.Property<Guid>("EmployeesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RolesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeesId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("EmployeeRole");
                });

            modelBuilder.Entity("EmployeeManagement.Domain.Models.Employee", b =>
                {
                    b.HasOne("EmployeeManagement.Domain.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("EmployeeRole", b =>
                {
                    b.HasOne("EmployeeManagement.Domain.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeManagement.Domain.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
