﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rembrandt.DatasetStats.Core.Context;

namespace Rembrandt.DatasetStats.Core.Migrations
{
    [DbContext(typeof(ObservationStatContext))]
    [Migration("20200716200136_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rembrandt.DatasetStats.Core.Models.ActivitiesStat", b =>
                {
                    b.Property<int>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Biking")
                        .HasColumnType("bit");

                    b.Property<bool>("Jogging")
                        .HasColumnType("bit");

                    b.Property<bool>("Relaxing")
                        .HasColumnType("bit");

                    b.Property<bool>("Socialising")
                        .HasColumnType("bit");

                    b.Property<bool>("Walking")
                        .HasColumnType("bit");

                    b.HasKey("PrimaryKey");

                    b.ToTable("ActivitiesStat");
                });

            modelBuilder.Entity("Rembrandt.DatasetStats.Core.Models.AttributesStat", b =>
                {
                    b.Property<int>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Beauty")
                        .HasColumnType("real");

                    b.Property<float>("Benches")
                        .HasColumnType("real");

                    b.Property<float>("Biodiversity")
                        .HasColumnType("real");

                    b.Property<float>("Crowded")
                        .HasColumnType("real");

                    b.Property<float>("Facilities")
                        .HasColumnType("real");

                    b.Property<float>("Flowers")
                        .HasColumnType("real");

                    b.Property<float>("Garbage")
                        .HasColumnType("real");

                    b.Property<float>("Lawns")
                        .HasColumnType("real");

                    b.Property<float>("Lively")
                        .HasColumnType("real");

                    b.Property<float>("Natveg")
                        .HasColumnType("real");

                    b.Property<float>("Noisy")
                        .HasColumnType("real");

                    b.Property<float>("Paths")
                        .HasColumnType("real");

                    b.Property<float>("Play")
                        .HasColumnType("real");

                    b.Property<float>("Relaxing")
                        .HasColumnType("real");

                    b.Property<float>("Safe")
                        .HasColumnType("real");

                    b.Property<float>("Shrubs")
                        .HasColumnType("real");

                    b.Property<float>("Sports")
                        .HasColumnType("real");

                    b.Property<float>("Tranquil")
                        .HasColumnType("real");

                    b.Property<float>("Trees")
                        .HasColumnType("real");

                    b.Property<float>("Veget")
                        .HasColumnType("real");

                    b.HasKey("PrimaryKey");

                    b.ToTable("AttributesStat");
                });

            modelBuilder.Entity("Rembrandt.DatasetStats.Core.Models.ObservationStat", b =>
                {
                    b.Property<int>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivitiesPrimaryKey")
                        .HasColumnType("int");

                    b.Property<int?>("AttributesPrimaryKey")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("PrimaryKey");

                    b.HasIndex("ActivitiesPrimaryKey");

                    b.HasIndex("AttributesPrimaryKey");

                    b.ToTable("ObservationsStat");
                });

            modelBuilder.Entity("Rembrandt.DatasetStats.Core.Models.PhotoAddress", b =>
                {
                    b.Property<int>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObservationStatPrimaryKey")
                        .HasColumnType("int");

                    b.HasKey("PrimaryKey");

                    b.HasIndex("ObservationStatPrimaryKey");

                    b.ToTable("PhotoAdresses");
                });

            modelBuilder.Entity("Rembrandt.DatasetStats.Core.Models.SkipReasons", b =>
                {
                    b.Property<int>("SkipReasonsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ObservationStatPrimaryKey")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReasonCount")
                        .HasColumnType("int");

                    b.HasKey("SkipReasonsId");

                    b.HasIndex("ObservationStatPrimaryKey");

                    b.ToTable("SkipReasons");
                });

            modelBuilder.Entity("Rembrandt.DatasetStats.Core.Models.ObservationStat", b =>
                {
                    b.HasOne("Rembrandt.DatasetStats.Core.Models.ActivitiesStat", "Activities")
                        .WithMany()
                        .HasForeignKey("ActivitiesPrimaryKey");

                    b.HasOne("Rembrandt.DatasetStats.Core.Models.AttributesStat", "Attributes")
                        .WithMany()
                        .HasForeignKey("AttributesPrimaryKey");
                });

            modelBuilder.Entity("Rembrandt.DatasetStats.Core.Models.PhotoAddress", b =>
                {
                    b.HasOne("Rembrandt.DatasetStats.Core.Models.ObservationStat", null)
                        .WithMany("PhotosAddresses")
                        .HasForeignKey("ObservationStatPrimaryKey");
                });

            modelBuilder.Entity("Rembrandt.DatasetStats.Core.Models.SkipReasons", b =>
                {
                    b.HasOne("Rembrandt.DatasetStats.Core.Models.ObservationStat", null)
                        .WithMany("SkipReasons")
                        .HasForeignKey("ObservationStatPrimaryKey");
                });
#pragma warning restore 612, 618
        }
    }
}
