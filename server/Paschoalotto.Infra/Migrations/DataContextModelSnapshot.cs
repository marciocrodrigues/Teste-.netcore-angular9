﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Paschoalotto.Infra.Data;

namespace Paschoalotto.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Paschoalotto.Domain.Entities.Divida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("datetime");

                    b.Property<string>("DocumentoDevedor")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasMaxLength(14);

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ValorOriginal")
                        .HasColumnType("numeric(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Divida");
                });

            modelBuilder.Entity("Paschoalotto.Domain.Entities.Parametrizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("MaximoParcelas")
                        .HasColumnType("smallint");

                    b.Property<decimal>("PorcentagemComissao")
                        .HasColumnType("numeric(8,4)");

                    b.Property<decimal>("PorcertagemJuros")
                        .HasColumnType("numeric(8,4)");

                    b.Property<string>("TipoJuros")
                        .IsRequired()
                        .HasColumnType("char(1)")
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("Parametrizacao");
                });

            modelBuilder.Entity("Paschoalotto.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b679d5e5-6315-4450-bc5e-0fc3dcc042ac"),
                            Codigo = "6521e4cc7a",
                            Documento = "12345678909",
                            Nome = "administrador",
                            Senha = "123456",
                            Telefone = "00000000000"
                        },
                        new
                        {
                            Id = new Guid("e43ed5da-3880-4641-a5d3-196f4d9dc44b"),
                            Codigo = "70efa5d926",
                            Documento = "12345678910",
                            Nome = "administrador2",
                            Senha = "123456",
                            Telefone = "00000000000"
                        });
                });

            modelBuilder.Entity("Paschoalotto.Domain.Entities.Divida", b =>
                {
                    b.HasOne("Paschoalotto.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Dividas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
