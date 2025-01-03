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
    [Migration("20241130220624_init")]
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

                    b.Property<byte[]>("Image")
                        .HasColumnType("BLOB");

                    b.Property<int>("RecipeAvaliation")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecipeCust")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("RecipeIngredients")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("RecipeMaterials")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.PrimitiveCollection<string>("RecipePreparation")
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
                            Image = new byte[] { 32, 32, 32 },
                            RecipeAvaliation = 0,
                            RecipeCust = "Custo médio",
                            RecipeDescription = "MUITO GOSTOSO",
                            RecipeIngredients = "[\"Ingrediente 1\",\"Ingrediente 2\",\"Ingrediente 3\"]",
                            RecipeMaterials = "[\"Material 1\",\"Material 2\"]",
                            RecipeName = "Bolo da Negona",
                            RecipePreparation = "[\"Passo 1\",\"Passo 2\",\"Passo 3\"]",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Image = new byte[] { 32, 32, 32 },
                            RecipeAvaliation = 0,
                            RecipeCust = "Custo médio",
                            RecipeDescription = "Delicioso!",
                            RecipeIngredients = "[\"Ingrediente A\",\"Ingrediente B\"]",
                            RecipeMaterials = "[\"Material X\",\"Material Y\"]",
                            RecipeName = "Bolo de Chocolate",
                            RecipePreparation = "[\"Passo A\",\"Passo B\"]",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Image = new byte[] { 32, 32, 32 },
                            RecipeAvaliation = 0,
                            RecipeCust = "Custo baixo",
                            RecipeDescription = "Super saboroso",
                            RecipeIngredients = "[\"Ingrediente M\",\"Ingrediente N\"]",
                            RecipeMaterials = "[\"Material Z\"]",
                            RecipeName = "Bolo de Morango",
                            RecipePreparation = "[\"Passo M\",\"Passo N\"]",
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
