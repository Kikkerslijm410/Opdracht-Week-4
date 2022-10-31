﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using database;

#nullable disable

namespace opdrachtweek4.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("database.Attractie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Attractie", (string)null);
                });

            modelBuilder.Entity("database.GastInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("DbGastInfo");
                });

            modelBuilder.Entity("database.Gebruiker", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Email");

                    b.ToTable("Gebruiker", (string)null);
                });

            modelBuilder.Entity("database.Onderhoud", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("probleem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Onderhoud", (string)null);
                });

            modelBuilder.Entity("database.Reservering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GereserverdeAttractiesId")
                        .HasColumnType("int");

                    b.Property<int>("Id_Gast")
                        .HasColumnType("int");

                    b.Property<string>("gastEmail")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("GereserverdeAttractiesId");

                    b.HasIndex("gastEmail");

                    b.ToTable("DbReservering");
                });

            modelBuilder.Entity("database.Gast", b =>
                {
                    b.HasBaseType("database.Gebruiker");

                    b.Property<string>("BegeleiderEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<DateTime>("EersteBezoek")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FavorieteAttractieId")
                        .HasColumnType("int");

                    b.Property<int>("GastinfoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Geboortedatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasIndex("BegeleiderEmail")
                        .IsUnique()
                        .HasFilter("[BegeleiderEmail] IS NOT NULL");

                    b.HasIndex("FavorieteAttractieId");

                    b.HasIndex("GastinfoId")
                        .IsUnique()
                        .HasFilter("[GastinfoId] IS NOT NULL");

                    b.ToTable("Gast", (string)null);
                });

            modelBuilder.Entity("database.Medewerker", b =>
                {
                    b.HasBaseType("database.Gebruiker");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.ToTable("Medewerker", (string)null);
                });

            modelBuilder.Entity("database.GastInfo", b =>
                {
                    b.OwnsOne("database.Coordinate", "coordinaat", b1 =>
                        {
                            b1.Property<int>("GastInfoId")
                                .HasColumnType("int");

                            b1.HasKey("GastInfoId");

                            b1.ToTable("DbGastInfo");

                            b1.WithOwner()
                                .HasForeignKey("GastInfoId");
                        });

                    b.Navigation("coordinaat");
                });

            modelBuilder.Entity("database.Onderhoud", b =>
                {
                    b.HasOne("database.Attractie", "attractie")
                        .WithMany("onderhoud")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("database.DateTimeBereik", "DTB_Onderhoud", b1 =>
                        {
                            b1.Property<int>("OnderhoudId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Eind")
                                .HasColumnType("datetime2");

                            b1.HasKey("OnderhoudId");

                            b1.ToTable("Onderhoud");

                            b1.WithOwner()
                                .HasForeignKey("OnderhoudId");
                        });

                    b.Navigation("DTB_Onderhoud");

                    b.Navigation("attractie");
                });

            modelBuilder.Entity("database.Reservering", b =>
                {
                    b.HasOne("database.Attractie", "GereserverdeAttracties")
                        .WithMany("reservering")
                        .HasForeignKey("GereserverdeAttractiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("database.Gast", "gast")
                        .WithMany("reservering")
                        .HasForeignKey("gastEmail");

                    b.OwnsOne("database.DateTimeBereik", "DTB_Reservering", b1 =>
                        {
                            b1.Property<int>("ReserveringId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Begin")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("Eind")
                                .HasColumnType("datetime2");

                            b1.HasKey("ReserveringId");

                            b1.ToTable("DbReservering");

                            b1.WithOwner()
                                .HasForeignKey("ReserveringId");
                        });

                    b.Navigation("DTB_Reservering")
                        .IsRequired();

                    b.Navigation("GereserverdeAttracties");

                    b.Navigation("gast");
                });

            modelBuilder.Entity("database.Gast", b =>
                {
                    b.HasOne("database.Gast", "Begeleider")
                        .WithOne("Begeleid")
                        .HasForeignKey("database.Gast", "BegeleiderEmail");

                    b.HasOne("database.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("database.Gast", "Email")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("database.Attractie", "FavorieteAttractie")
                        .WithMany()
                        .HasForeignKey("FavorieteAttractieId");

                    b.HasOne("database.GastInfo", "GastInformatie")
                        .WithOne("gast")
                        .HasForeignKey("database.Gast", "GastinfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Begeleider");

                    b.Navigation("FavorieteAttractie");

                    b.Navigation("GastInformatie");
                });

            modelBuilder.Entity("database.Medewerker", b =>
                {
                    b.HasOne("database.Gebruiker", null)
                        .WithOne()
                        .HasForeignKey("database.Medewerker", "Email")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("database.Attractie", b =>
                {
                    b.Navigation("onderhoud");

                    b.Navigation("reservering");
                });

            modelBuilder.Entity("database.GastInfo", b =>
                {
                    b.Navigation("gast");
                });

            modelBuilder.Entity("database.Gast", b =>
                {
                    b.Navigation("Begeleid");

                    b.Navigation("reservering");
                });
#pragma warning restore 612, 618
        }
    }
}
