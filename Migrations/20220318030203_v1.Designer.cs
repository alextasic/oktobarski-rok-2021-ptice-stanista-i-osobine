// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Template.Migrations
{
    [DbContext(typeof(IspitDbContext))]
    [Migration("20220318030203_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Osobina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Vrednost")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Osobina");
                });

            modelBuilder.Entity("Models.Podrucje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Podrucje");
                });

            modelBuilder.Entity("Models.Ptica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("URLSlike")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Ptica");
                });

            modelBuilder.Entity("Models.PticaPodrucje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PodrucjeID")
                        .HasColumnType("int");

                    b.Property<int?>("PticaID")
                        .HasColumnType("int");

                    b.Property<int>("VidjenaPuta")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PodrucjeID");

                    b.HasIndex("PticaID");

                    b.ToTable("PticaPodrucje");
                });

            modelBuilder.Entity("OsobinaPtica", b =>
                {
                    b.Property<int>("OsobineID")
                        .HasColumnType("int");

                    b.Property<int>("PticeID")
                        .HasColumnType("int");

                    b.HasKey("OsobineID", "PticeID");

                    b.HasIndex("PticeID");

                    b.ToTable("OsobinaPtica");
                });

            modelBuilder.Entity("Models.PticaPodrucje", b =>
                {
                    b.HasOne("Models.Podrucje", "Podrucje")
                        .WithMany("PticaPodrucje")
                        .HasForeignKey("PodrucjeID");

                    b.HasOne("Models.Ptica", "Ptica")
                        .WithMany("PticaPodrucja")
                        .HasForeignKey("PticaID");

                    b.Navigation("Podrucje");

                    b.Navigation("Ptica");
                });

            modelBuilder.Entity("OsobinaPtica", b =>
                {
                    b.HasOne("Models.Osobina", null)
                        .WithMany()
                        .HasForeignKey("OsobineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Ptica", null)
                        .WithMany()
                        .HasForeignKey("PticeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Podrucje", b =>
                {
                    b.Navigation("PticaPodrucje");
                });

            modelBuilder.Entity("Models.Ptica", b =>
                {
                    b.Navigation("PticaPodrucja");
                });
#pragma warning restore 612, 618
        }
    }
}
