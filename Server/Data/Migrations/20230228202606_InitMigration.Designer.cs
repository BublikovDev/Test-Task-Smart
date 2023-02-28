﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

#nullable disable

namespace Server.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230228202606_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shared.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CountOfEquipment")
                        .HasColumnType("int");

                    b.Property<int>("ProductionPremiseId")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfEquipmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductionPremiseId")
                        .IsUnique();

                    b.HasIndex("TypeOfEquipmentId")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Shared.Models.ProductionPremises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("EquipmentArea")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductionPremises");
                });

            modelBuilder.Entity("Shared.Models.TypeOfEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TypesOfEquipment");
                });

            modelBuilder.Entity("Shared.Models.Contract", b =>
                {
                    b.HasOne("Shared.Models.ProductionPremises", "ProductionPremise")
                        .WithOne("Contract")
                        .HasForeignKey("Shared.Models.Contract", "ProductionPremiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Models.TypeOfEquipment", "TypeOfEquipment")
                        .WithOne("Contract")
                        .HasForeignKey("Shared.Models.Contract", "TypeOfEquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductionPremise");

                    b.Navigation("TypeOfEquipment");
                });

            modelBuilder.Entity("Shared.Models.ProductionPremises", b =>
                {
                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Shared.Models.TypeOfEquipment", b =>
                {
                    b.Navigation("Contract");
                });
#pragma warning restore 612, 618
        }
    }
}
