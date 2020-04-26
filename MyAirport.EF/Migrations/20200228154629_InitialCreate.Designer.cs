﻿// <auto-generated />
using System;
using GBO.MyAirport.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#pragma warning disable CS1591

namespace GBO.MyAirport.EF.Migrations
{
    [DbContext(typeof(MyAirportContext))]
    [Migration("20200228154629_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GBO.MyAirport.EF.Bagage", b =>
                {
                    b.Property<int>("BagageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Classe")
                        .HasColumnType("char(1)");

                    b.Property<string>("CodeIata")
                        .IsRequired()
                        .HasColumnType("char(12)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("varchar(3)");

                    b.Property<string>("Escale")
                        .HasColumnType("char(3)");

                    b.Property<bool?>("Prioritaire")
                        .HasColumnType("bit");

                    b.Property<string>("Ssur")
                        .HasColumnType("char(3)");

                    b.Property<string>("Sta")
                        .HasColumnType("char(1)");

                    b.Property<int?>("VolID")
                        .HasColumnType("int");

                    b.HasKey("BagageID");

                    b.HasIndex("VolID");

                    b.ToTable("Bagages");
                });

            modelBuilder.Entity("GBO.MyAirport.EF.Vol", b =>
                {
                    b.Property<int>("VolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cie")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Des")
                        .HasColumnType("char(3)");

                    b.Property<DateTime?>("Dhc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imm")
                        .HasColumnType("char(6)");

                    b.Property<string>("Lig")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<short?>("Pax")
                        .HasColumnType("smallint");

                    b.Property<string>("Pkg")
                        .HasColumnType("char(3)");

                    b.HasKey("VolID");

                    b.ToTable("Vols");
                });

            modelBuilder.Entity("GBO.MyAirport.EF.Bagage", b =>
                {
                    b.HasOne("GBO.MyAirport.EF.Vol", "Vol")
                        .WithMany("Bagages")
                        .HasForeignKey("VolID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
