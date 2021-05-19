﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjetoSeplag.Infra.Data.Context;

namespace ProjetoSeplag.Infra.Migrations
{
    [DbContext(typeof(AplicationContext))]
    [Migration("20210519002332_primeira-migration")]
    partial class primeiramigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ProjetoSeplag.Domain.Updates.Entitys.UpdateEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Alias")
                        .HasColumnType("text");

                    b.Property<DateTime>("CurrentReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CvrfUrl")
                        .HasColumnType("text");

                    b.Property<string>("DocumentTitle")
                        .HasColumnType("text");

                    b.Property<DateTime>("InitialReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Severity")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UpdateEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
