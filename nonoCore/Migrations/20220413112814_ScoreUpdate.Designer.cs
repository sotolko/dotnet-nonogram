﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nonoCore.Service;

namespace nonoCore.Migrations
{
    [DbContext(typeof(ScoreDBContext))]
    [Migration("20220413112814_ScoreUpdate")]
    partial class ScoreUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("nonoCore.Entity.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Player")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seconds")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}
