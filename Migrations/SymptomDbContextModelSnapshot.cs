﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SymTom.Data;

namespace SymTom.Migrations
{
    [DbContext(typeof(SymptomDbContext))]
    partial class SymptomDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            
            modelBuilder.Entity("SymTom.Models.Symptom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("Severity");
                        
                    b.HasKey("ID");

                    b.ToTable("Symptoms");
                });

        }
    }
}
