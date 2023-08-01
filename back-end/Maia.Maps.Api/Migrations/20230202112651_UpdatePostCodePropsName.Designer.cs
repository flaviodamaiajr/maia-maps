﻿// <auto-generated />
using System;
using Maia.Maps.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Maia.Maps.Api.Migrations
{
    [DbContext(typeof(MaiaContext))]
    [Migration("20230202112651_UpdatePostCodePropsName")]
    partial class UpdatePostCodePropsName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Maia.Maps.Domain.Entities.SearchHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("SearchHistories");
                });

            modelBuilder.Entity("Maia.Maps.Domain.Entities.SearchHistory", b =>
                {
                    b.OwnsOne("Maia.Maps.Domain.ValuesObjects.Coordinate", "CoordinatesFrom", b1 =>
                        {
                            b1.Property<long>("SearchHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<double>("Latitude")
                                .HasColumnType("double");

                            b1.Property<double>("Longitude")
                                .HasColumnType("double");

                            b1.HasKey("SearchHistoryId");

                            b1.ToTable("SearchHistories");

                            b1.WithOwner()
                                .HasForeignKey("SearchHistoryId");
                        });

                    b.OwnsOne("Maia.Maps.Domain.ValuesObjects.Coordinate", "CoordinatesTo", b1 =>
                        {
                            b1.Property<long>("SearchHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<double>("Latitude")
                                .HasColumnType("double");

                            b1.Property<double>("Longitude")
                                .HasColumnType("double");

                            b1.HasKey("SearchHistoryId");

                            b1.ToTable("SearchHistories");

                            b1.WithOwner()
                                .HasForeignKey("SearchHistoryId");
                        });

                    b.OwnsOne("Maia.Maps.Domain.ValuesObjects.Distance", "Distance", b1 =>
                        {
                            b1.Property<long>("SearchHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<double>("Kilometers")
                                .HasPrecision(10, 2)
                                .HasColumnType("double");

                            b1.Property<double>("Miles")
                                .HasPrecision(10, 2)
                                .HasColumnType("double");

                            b1.HasKey("SearchHistoryId");

                            b1.ToTable("SearchHistories");

                            b1.WithOwner()
                                .HasForeignKey("SearchHistoryId");
                        });

                    b.OwnsOne("Maia.Maps.Domain.ValuesObjects.PostCode", "PostCode", b1 =>
                        {
                            b1.Property<long>("SearchHistoryId")
                                .HasColumnType("bigint");

                            b1.Property<string>("From")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)");

                            b1.Property<string>("To")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)");

                            b1.HasKey("SearchHistoryId");

                            b1.ToTable("SearchHistories");

                            b1.WithOwner()
                                .HasForeignKey("SearchHistoryId");
                        });

                    b.Navigation("CoordinatesFrom")
                        .IsRequired();

                    b.Navigation("CoordinatesTo")
                        .IsRequired();

                    b.Navigation("Distance");

                    b.Navigation("PostCode")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
