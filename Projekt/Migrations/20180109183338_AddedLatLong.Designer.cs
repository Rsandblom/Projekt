﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Projekt.Models;
using System;

namespace Projekt.Migrations
{
    [DbContext(typeof(ProjektContext))]
    [Migration("20180109183338_AddedLatLong")]
    partial class AddedLatLong
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projekt.Models.DiningExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Dish");

                    b.Property<double>("Latitude");

                    b.Property<double>("MyProperty");

                    b.Property<string>("Restaurant");

                    b.HasKey("Id");

                    b.ToTable("DiningExperience");
                });

            modelBuilder.Entity("Projekt.Models.SearchTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DiningExperienceId");

                    b.Property<string>("Tag");

                    b.HasKey("Id");

                    b.HasIndex("DiningExperienceId");

                    b.ToTable("SearchTag");
                });

            modelBuilder.Entity("Projekt.Models.SearchTag", b =>
                {
                    b.HasOne("Projekt.Models.DiningExperience", "DiningExperience")
                        .WithMany("SearchTagsList")
                        .HasForeignKey("DiningExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}