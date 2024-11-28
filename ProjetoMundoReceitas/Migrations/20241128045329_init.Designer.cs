﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoMundoReceitas.Data;

#nullable disable

namespace ProjetoMundoReceitas.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241128045329_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("ProjetoMundoReceitas.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("RecipeAvaliation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecipeCust")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeIngredients")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeMaterials")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipePreparation")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Recipers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RecipeAvaliation = 0,
                            RecipeCust = "Custo medio",
                            RecipeDescription = "MUITO GOSTOSO",
                            RecipeIngredients = "TESTE TESTE TESTE TESTE",
                            RecipeMaterials = "TESTE TESTE TESTE",
                            RecipeName = "Bolo da Negona",
                            RecipePreparation = "TESTE",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            RecipeAvaliation = 0,
                            RecipeCust = "Custo medio",
                            RecipeDescription = "MUITO GOSTOSO",
                            RecipeIngredients = "TESTE TESTE TESTE TESTE",
                            RecipeMaterials = "TESTE TESTE TESTE",
                            RecipeName = "Bolo da Negona",
                            RecipePreparation = "TESTE",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            RecipeAvaliation = 0,
                            RecipeCust = "Custo medio",
                            RecipeDescription = "MUITO GOSTOSO",
                            RecipeIngredients = "TESTE TESTE TESTE TESTE",
                            RecipeMaterials = "TESTE TESTE TESTE",
                            RecipeName = "Bolo da Negona",
                            RecipePreparation = "TESTE",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("ProjetoMundoReceitas.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Lauro@gmail.com",
                            Name = "Lauro",
                            Password = "1234"
                        },
                        new
                        {
                            Id = 2,
                            Email = "Antonio@gmail.com",
                            Name = "Antonio",
                            Password = "1234"
                        },
                        new
                        {
                            Id = 3,
                            Email = "Batman@gmail.com",
                            Name = "Batman",
                            Password = "1234"
                        },
                        new
                        {
                            Id = 4,
                            Email = "Miguel@gmail.com",
                            Name = "Miguel",
                            Password = "1234"
                        },
                        new
                        {
                            Id = 5,
                            Email = "Lucas@gmail.com",
                            Name = "Lucas",
                            Password = "1234"
                        });
                });

            modelBuilder.Entity("ProjetoMundoReceitas.Models.Recipe", b =>
                {
                    b.HasOne("ProjetoMundoReceitas.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
