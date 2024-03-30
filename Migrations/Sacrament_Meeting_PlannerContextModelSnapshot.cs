﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sacrament_Meeting_Planner.Data;

#nullable disable

namespace Sacrament_Meeting_Planner.Migrations
{
    [DbContext(typeof(Sacrament_Meeting_PlannerContext))]
    partial class Sacrament_Meeting_PlannerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Sacrament_Meeting_Planner.Models.Meeting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Benediction")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClosingHymn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Conducting")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("IntermediateHymn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Invocation")
                        .HasColumnType("TEXT");

                    b.Property<int>("OpeningHymn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Presiding")
                        .HasColumnType("TEXT");

                    b.Property<int>("SacramentHymn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpeakerSubject")
                        .HasColumnType("TEXT");

                    b.Property<string>("Speakers")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Meeting");
                });
#pragma warning restore 612, 618
        }
    }
}
