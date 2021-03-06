﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using WebApplication5.Models;

namespace WebApplication5.Migrations
{
    [DbContext(typeof(ModelContext))]
    partial class ModelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WebApplication5.Models.Bundle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Info");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Bundles");
                });

            modelBuilder.Entity("WebApplication5.Models.BundlePath", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BundleId");

                    b.Property<int>("PathId");

                    b.HasKey("Id");

                    b.HasIndex("BundleId");

                    b.HasIndex("PathId");

                    b.ToTable("BundlePath");
                });

            modelBuilder.Entity("WebApplication5.Models.Path", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Duration");

                    b.Property<string>("Image");

                    b.Property<string>("Info");

                    b.Property<string>("Length");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Paths");
                });

            modelBuilder.Entity("WebApplication5.Models.PathPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PathId");

                    b.Property<int>("PlaceId");

                    b.HasKey("Id");

                    b.HasIndex("PathId");

                    b.HasIndex("PlaceId");

                    b.ToTable("PathPlace");
                });

            modelBuilder.Entity("WebApplication5.Models.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Image");

                    b.Property<string>("Info");

                    b.Property<string>("Name");

                    b.Property<int>("Radius");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("WebApplication5.Models.BundlePath", b =>
                {
                    b.HasOne("WebApplication5.Models.Bundle")
                        .WithMany("BundlePaths")
                        .HasForeignKey("BundleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication5.Models.Path", "Path")
                        .WithMany()
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication5.Models.PathPlace", b =>
                {
                    b.HasOne("WebApplication5.Models.Path", "Path")
                        .WithMany("Places")
                        .HasForeignKey("PathId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication5.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
