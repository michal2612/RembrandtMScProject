﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rembrandt.Dataset.Core.Context;

namespace Rembrandt.Dataset.Core.Migrations
{
    [DbContext(typeof(ObservationContext))]
    partial class ObservationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rembrandt.Dataset.Core.Models.Activities", b =>
                {
                    b.Property<int>("ActivitiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Biking")
                        .HasColumnType("bit");

                    b.Property<bool?>("Jogging")
                        .HasColumnType("bit");

                    b.Property<bool?>("Relaxing")
                        .HasColumnType("bit");

                    b.Property<bool?>("Socialising")
                        .HasColumnType("bit");

                    b.Property<bool?>("Walking")
                        .HasColumnType("bit");

                    b.HasKey("ActivitiesId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Rembrandt.Dataset.Core.Models.Attributes", b =>
                {
                    b.Property<int>("AttributesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Beauty")
                        .HasColumnType("int");

                    b.Property<int>("Benches")
                        .HasColumnType("int");

                    b.Property<int>("Biodiversity")
                        .HasColumnType("int");

                    b.Property<int>("Crowded")
                        .HasColumnType("int");

                    b.Property<int>("Facilities")
                        .HasColumnType("int");

                    b.Property<int>("Flowers")
                        .HasColumnType("int");

                    b.Property<int>("Garbage")
                        .HasColumnType("int");

                    b.Property<int>("Lawns")
                        .HasColumnType("int");

                    b.Property<int>("Lively")
                        .HasColumnType("int");

                    b.Property<int>("Natveg")
                        .HasColumnType("int");

                    b.Property<int>("Noisy")
                        .HasColumnType("int");

                    b.Property<int>("Paths")
                        .HasColumnType("int");

                    b.Property<int>("Play")
                        .HasColumnType("int");

                    b.Property<int>("Relaxing")
                        .HasColumnType("int");

                    b.Property<int>("Safe")
                        .HasColumnType("int");

                    b.Property<int>("Shrubs")
                        .HasColumnType("int");

                    b.Property<int>("Sports")
                        .HasColumnType("int");

                    b.Property<int>("Tranquil")
                        .HasColumnType("int");

                    b.Property<int>("Trees")
                        .HasColumnType("int");

                    b.Property<int>("Veget")
                        .HasColumnType("int");

                    b.HasKey("AttributesId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Rembrandt.Dataset.Core.Models.Contributor", b =>
                {
                    b.Property<int>("PrimaryKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<bool?>("DutchNationality")
                        .HasColumnType("bit");

                    b.Property<int?>("Education")
                        .HasColumnType("int");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("MoreInvolved")
                        .HasColumnType("bit");

                    b.Property<int?>("NatureOriented")
                        .HasColumnType("int");

                    b.Property<bool?>("VisitAlone")
                        .HasColumnType("bit");

                    b.Property<bool?>("VisitDaily")
                        .HasColumnType("bit");

                    b.Property<int?>("VisitFreq")
                        .HasColumnType("int");

                    b.Property<int?>("VisitOtherParks")
                        .HasColumnType("int");

                    b.Property<bool?>("WithChildren")
                        .HasColumnType("bit");

                    b.HasKey("PrimaryKey");

                    b.ToTable("Contributor");
                });

            modelBuilder.Entity("Rembrandt.Dataset.Core.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GpsAccuracy")
                        .HasColumnType("int");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Rembrandt.Dataset.Core.Models.Observation", b =>
                {
                    b.Property<int>("ObservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivitiesId")
                        .HasColumnType("int");

                    b.Property<int?>("AttributesId")
                        .HasColumnType("int");

                    b.Property<int?>("ContributorPrimaryKey")
                        .HasColumnType("int");

                    b.Property<int?>("ParkId")
                        .HasColumnType("int");

                    b.Property<string>("PhotoAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhotoTowardsPointCompass")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<string>("SkipReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeSubmitted")
                        .HasColumnType("datetime2");

                    b.HasKey("ObservationId");

                    b.HasIndex("ActivitiesId");

                    b.HasIndex("AttributesId");

                    b.HasIndex("ContributorPrimaryKey");

                    b.HasIndex("ParkId");

                    b.ToTable("Observations");
                });

            modelBuilder.Entity("Rembrandt.Dataset.Core.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActualLocationLocationId")
                        .HasColumnType("int");

                    b.Property<int?>("MeasuredLocationLocationId")
                        .HasColumnType("int");

                    b.HasKey("ParkId");

                    b.HasIndex("ActualLocationLocationId");

                    b.HasIndex("MeasuredLocationLocationId");

                    b.ToTable("Park");
                });

            modelBuilder.Entity("Rembrandt.Dataset.Core.Models.Observation", b =>
                {
                    b.HasOne("Rembrandt.Dataset.Core.Models.Activities", "Activities")
                        .WithMany()
                        .HasForeignKey("ActivitiesId");

                    b.HasOne("Rembrandt.Dataset.Core.Models.Attributes", "Attributes")
                        .WithMany()
                        .HasForeignKey("AttributesId");

                    b.HasOne("Rembrandt.Dataset.Core.Models.Contributor", "Contributor")
                        .WithMany()
                        .HasForeignKey("ContributorPrimaryKey");

                    b.HasOne("Rembrandt.Dataset.Core.Models.Park", "Park")
                        .WithMany()
                        .HasForeignKey("ParkId");
                });

            modelBuilder.Entity("Rembrandt.Dataset.Core.Models.Park", b =>
                {
                    b.HasOne("Rembrandt.Dataset.Core.Models.Location", "ActualLocation")
                        .WithMany()
                        .HasForeignKey("ActualLocationLocationId");

                    b.HasOne("Rembrandt.Dataset.Core.Models.Location", "MeasuredLocation")
                        .WithMany()
                        .HasForeignKey("MeasuredLocationLocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
