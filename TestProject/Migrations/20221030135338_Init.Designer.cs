// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestProject.Infrastructure;

#nullable disable

namespace TestProject.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221030135338_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BookOrderItem", b =>
                {
                    b.Property<Guid>("BooksId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderItemsId")
                        .HasColumnType("uuid");

                    b.HasKey("BooksId", "OrderItemsId");

                    b.HasIndex("OrderItemsId");

                    b.ToTable("BookOrderItem");
                });

            modelBuilder.Entity("OrderUser", b =>
                {
                    b.Property<Guid>("OrdersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uuid");

                    b.HasKey("OrdersId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("OrderUser");
                });

            modelBuilder.Entity("SimpleDatabase.Infrastructure.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("TimeOfCreation")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("SimpleDatabase.Infrastructure.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Sum")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("TimeOfCreation")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SimpleDatabase.Infrastructure.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("TimeOfCreation")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("SimpleDatabase.Infrastructure.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TimeOfCreation")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("SimpleDatabase.Infrastructure.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("TimeOfCreation")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookOrderItem", b =>
                {
                    b.HasOne("SimpleDatabase.Infrastructure.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleDatabase.Infrastructure.Models.OrderItem", null)
                        .WithMany()
                        .HasForeignKey("OrderItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrderUser", b =>
                {
                    b.HasOne("SimpleDatabase.Infrastructure.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleDatabase.Infrastructure.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleDatabase.Infrastructure.Models.OrderItem", b =>
                {
                    b.HasOne("SimpleDatabase.Infrastructure.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SimpleDatabase.Infrastructure.Models.User", b =>
                {
                    b.HasOne("SimpleDatabase.Infrastructure.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SimpleDatabase.Infrastructure.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
