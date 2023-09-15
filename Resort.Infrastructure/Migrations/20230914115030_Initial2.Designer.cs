﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resort.Infrastructure;

#nullable disable

namespace Resort.Infrastructure.Migrations
{
    [DbContext(typeof(ResortDbContext))]
    [Migration("20230914115030_Initial2")]
    partial class Initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Resort.Domain.Bookings.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Advance")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("DateBooked")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateBookedFor")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("FirmId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Resort.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Resort.Domain.Document.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Resort.Domain.Firms.Firm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Firms");
                });

            modelBuilder.Entity("Resort.Domain.Firms.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Resort.Domain.Orders.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<Guid>("FirmId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<bool>("Paid")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Resort.Domain.RoomHistory.CheckInOutLogs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("RoomNo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CheckInOutLogs");
                });

            modelBuilder.Entity("Resort.Domain.RoomHistory.CheckOutDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("GrandTotal")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Particulars")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("CheckOutDetails");
                });

            modelBuilder.Entity("Resort.Domain.Rooms.CheckInDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.ToTable("CheckInDetails");
                });

            modelBuilder.Entity("Resort.Domain.Customers.Customer", b =>
                {
                    b.OwnsOne("Resort.Domain.Customers.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("MobileNumber")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("Resort.Domain.SharedKernel.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("AddressLine")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Municipality")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("WardNo")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Contact")
                        .IsRequired();
                });

            modelBuilder.Entity("Resort.Domain.Firms.Firm", b =>
                {
                    b.OwnsOne("Resort.Domain.Firms.Contact", "Contact", b1 =>
                        {
                            b1.Property<Guid>("FirmId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("ContactPerson")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("MobileNumber")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("TelephoneNumber")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Website")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("FirmId");

                            b1.ToTable("Firms");

                            b1.WithOwner()
                                .HasForeignKey("FirmId");
                        });

                    b.OwnsOne("Resort.Domain.SharedKernel.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("FirmId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("AddressLine")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Municipality")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Province")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("WardNo")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("FirmId");

                            b1.ToTable("Firms");

                            b1.WithOwner()
                                .HasForeignKey("FirmId");
                        });

                    b.OwnsMany("Resort.Domain.FoodMenu", "Foods", b1 =>
                        {
                            b1.Property<Guid>("FirmId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("FoodName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.HasKey("FirmId", "Id");

                            b1.ToTable("FoodMenu");

                            b1.WithOwner()
                                .HasForeignKey("FirmId");

                            b1.OwnsOne("Resort.Domain.Rates", "Price", b2 =>
                                {
                                    b2.Property<Guid>("FoodMenuFirmId")
                                        .HasColumnType("char(36)");

                                    b2.Property<int>("FoodMenuId")
                                        .HasColumnType("int");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("decimal(65,30)");

                                    b2.Property<string>("Currency")
                                        .IsRequired()
                                        .HasColumnType("longtext");

                                    b2.HasKey("FoodMenuFirmId", "FoodMenuId");

                                    b2.ToTable("FoodMenu");

                                    b2.WithOwner()
                                        .HasForeignKey("FoodMenuFirmId", "FoodMenuId");
                                });

                            b1.OwnsOne("Resort.Domain.FoodType", "Type", b2 =>
                                {
                                    b2.Property<Guid>("FoodMenuFirmId")
                                        .HasColumnType("char(36)");

                                    b2.Property<int>("FoodMenuId")
                                        .HasColumnType("int");

                                    b2.Property<bool>("NonVeg")
                                        .HasColumnType("tinyint(1)");

                                    b2.HasKey("FoodMenuFirmId", "FoodMenuId");

                                    b2.ToTable("FoodMenu");

                                    b2.WithOwner()
                                        .HasForeignKey("FoodMenuFirmId", "FoodMenuId");
                                });

                            b1.Navigation("Price")
                                .IsRequired();

                            b1.Navigation("Type")
                                .IsRequired();
                        });

                    b.OwnsMany("Resort.Domain.Room", "Rooms", b1 =>
                        {
                            b1.Property<Guid>("FirmId")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("RoomId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("char(36)");

                            b1.Property<bool>("Availability")
                                .HasColumnType("tinyint(1)");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("RoomType")
                                .HasColumnType("int");

                            b1.Property<string>("Status")
                                .HasColumnType("longtext");

                            b1.HasKey("FirmId", "RoomId");

                            b1.ToTable("Rooms");

                            b1.WithOwner()
                                .HasForeignKey("FirmId");

                            b1.OwnsOne("Resort.Domain.Features", "Features", b2 =>
                                {
                                    b2.Property<Guid>("RoomFirmId")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid>("RoomId")
                                        .HasColumnType("char(36)");

                                    b2.Property<bool>("Ac")
                                        .HasColumnType("tinyint(1)");

                                    b2.Property<bool>("Bed")
                                        .HasColumnType("tinyint(1)");

                                    b2.Property<bool>("Tv")
                                        .HasColumnType("tinyint(1)");

                                    b2.Property<bool>("Wifi")
                                        .HasColumnType("tinyint(1)");

                                    b2.HasKey("RoomFirmId", "RoomId");

                                    b2.ToTable("Rooms");

                                    b2.WithOwner()
                                        .HasForeignKey("RoomFirmId", "RoomId");
                                });

                            b1.OwnsOne("Resort.Domain.Rates", "Rate", b2 =>
                                {
                                    b2.Property<Guid>("RoomFirmId")
                                        .HasColumnType("char(36)");

                                    b2.Property<Guid>("RoomId")
                                        .HasColumnType("char(36)");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("decimal(65,30)");

                                    b2.Property<string>("Currency")
                                        .IsRequired()
                                        .HasColumnType("longtext");

                                    b2.HasKey("RoomFirmId", "RoomId");

                                    b2.ToTable("Rooms");

                                    b2.WithOwner()
                                        .HasForeignKey("RoomFirmId", "RoomId");
                                });

                            b1.Navigation("Features")
                                .IsRequired();

                            b1.Navigation("Rate")
                                .IsRequired();
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Contact")
                        .IsRequired();

                    b.Navigation("Foods");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Resort.Domain.Orders.Order", b =>
                {
                    b.OwnsMany("Resort.Domain.Orders.OrderLineItem", "OrderDetails", b1 =>
                        {
                            b1.Property<Guid>("OrderId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<string>("Item")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<int>("Quantity")
                                .HasColumnType("int");

                            b1.Property<decimal>("Total")
                                .HasColumnType("decimal(65,30)");

                            b1.HasKey("OrderId", "Id");

                            b1.ToTable("OrderLineItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");

                            b1.OwnsOne("Resort.Domain.Rates", "Price", b2 =>
                                {
                                    b2.Property<Guid>("OrderLineItemOrderId")
                                        .HasColumnType("char(36)");

                                    b2.Property<int>("OrderLineItemId")
                                        .HasColumnType("int");

                                    b2.Property<decimal>("Amount")
                                        .HasColumnType("decimal(65,30)");

                                    b2.Property<string>("Currency")
                                        .IsRequired()
                                        .HasColumnType("longtext");

                                    b2.HasKey("OrderLineItemOrderId", "OrderLineItemId");

                                    b2.ToTable("OrderLineItem");

                                    b2.WithOwner()
                                        .HasForeignKey("OrderLineItemOrderId", "OrderLineItemId");
                                });

                            b1.Navigation("Price")
                                .IsRequired();
                        });

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("Resort.Domain.RoomHistory.CheckOutDetail", b =>
                {
                    b.OwnsOne("Resort.Domain.Rates", "Rate", b1 =>
                        {
                            b1.Property<Guid>("CheckOutDetailId")
                                .HasColumnType("char(36)");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(65,30)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("CheckOutDetailId");

                            b1.ToTable("CheckOutDetails");

                            b1.WithOwner()
                                .HasForeignKey("CheckOutDetailId");
                        });

                    b.Navigation("Rate")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
