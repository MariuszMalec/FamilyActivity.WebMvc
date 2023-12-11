﻿// <auto-generated />
using System;
using FamilyActivity.WebMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FamilyActivity.WebMvc.Migrations.WorkOrderDb
{
    [DbContext(typeof(WorkOrderDbContext))]
    [Migration("20231211181751_InitWorkOrderDb")]
    partial class InitWorkOrderDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("FamilyActivity.WebMvc.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Group 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Group 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Group 3"
                        });
                });

            modelBuilder.Entity("FamilyActivity.WebMvc.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GroupId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Resources");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupId = 1,
                            Name = "Person A"
                        },
                        new
                        {
                            Id = 2,
                            GroupId = 1,
                            Name = "Person B"
                        },
                        new
                        {
                            Id = 3,
                            GroupId = 1,
                            Name = "Person C"
                        },
                        new
                        {
                            Id = 4,
                            GroupId = 2,
                            Name = "Person D"
                        },
                        new
                        {
                            Id = 5,
                            GroupId = 2,
                            Name = "Person E"
                        },
                        new
                        {
                            Id = 6,
                            GroupId = 2,
                            Name = "Person F"
                        },
                        new
                        {
                            Id = 7,
                            GroupId = 3,
                            Name = "Person G"
                        },
                        new
                        {
                            Id = 8,
                            GroupId = 3,
                            Name = "Person H"
                        });
                });

            modelBuilder.Entity("FamilyActivity.WebMvc.Models.WorkOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ordinal")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrdinalPriority")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ResourceId");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("FamilyActivity.WebMvc.Models.Resource", b =>
                {
                    b.HasOne("FamilyActivity.WebMvc.Models.Group", "Group")
                        .WithMany("Resources")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FamilyActivity.WebMvc.Models.WorkOrder", b =>
                {
                    b.HasOne("FamilyActivity.WebMvc.Models.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("FamilyActivity.WebMvc.Models.Group", b =>
                {
                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
