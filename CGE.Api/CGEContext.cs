﻿using CGE.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CGE.Api
{
    public class CGEContext : DbContext
    {        
        public CGEContext(DbContextOptions<CGEContext> opt) : base(opt)
        {
            // Iniciar Dados
            SeedData();
        }

        public DbSet<Supplier> Suppliers { set; get; }

        private void SeedData()
        {
            #region ADDING PJ
                       
            Suppliers.Add(new Supplier() { TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "01571702000198", RazaoSocial ="HALEX ISTAR IND FARMACEUTICA LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "HALEXFARMACO@HALEX.COM.BR", CapitalSocial = 105000000});
            Suppliers.Add(new Supplier() { TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "01571702000198", RazaoSocial = "HALEX ISTAR IND FARMACEUTICA LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "HALEXFARMACO@HALEX.COM.BR", CapitalSocial = 105000000 });
            Suppliers.Add(new Supplier() { TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "01571702000198", RazaoSocial = "HALEX ISTAR IND FARMACEUTICA LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "HALEXFARMACO@HALEX.COM.BR", CapitalSocial = 105000000 });
            Suppliers.Add(new Supplier() { TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "01571702000198", RazaoSocial = "HALEX ISTAR IND FARMACEUTICA LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "HALEXFARMACO@HALEX.COM.BR", CapitalSocial = 105000000 });
            Suppliers.Add(new Supplier() { TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "01571702000198", RazaoSocial = "HALEX ISTAR IND FARMACEUTICA LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "HALEXFARMACO@HALEX.COM.BR", CapitalSocial = 105000000 });
            Suppliers.Add(new Supplier() { TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "01571702000198", RazaoSocial = "HALEX ISTAR IND FARMACEUTICA LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "HALEXFARMACO@HALEX.COM.BR", CapitalSocial = 105000000 });

            #endregion

            #region ADDING PF

            Suppliers.Add(new Supplier() { TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "97672971034", RazaoSocial = "CAMILA LAIS CARGNELUTTI", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "CAMILA_CARGNELUTTI@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-20).AddMonths(-1), Genero = 0 });
            Suppliers.Add(new Supplier() { TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "09641388049", RazaoSocial = "RUI GARIGHAM PINTO",      TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "RUIPINTO@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-24).AddMonths(-7), Genero = 1 });
            Suppliers.Add(new Supplier() { TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "94976767787", RazaoSocial = "GIBRALTAR PEDRO CIPRIANO", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "GILMARVIDAL@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-15).AddMonths(-3), Genero = 1, });
            Suppliers.Add(new Supplier() { TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "81254784004", RazaoSocial = "ANDRE BAZACAS VELHO",      TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "ANDREVELHO99@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-19).AddMonths(-1), Genero = 1, });
            Suppliers.Add(new Supplier() { TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "46056564053", RazaoSocial = "GILMAR THUME",             TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "GILMARTH90@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-22).AddMonths(-4), Genero = 1, });
            Suppliers.Add(new Supplier() { TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "28866991015", RazaoSocial = "CLEICE AMABILE LEVY ZAGO", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "CLEICEZAGO@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-21).AddMonths(-9), Genero = 0, });
            Suppliers.Add(new Supplier() { TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "93233728034", RazaoSocial = "MONICA CRISTIANE RINCK", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "MONICACRIS88@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-24).AddMonths(-1), Genero = 0, });
            Suppliers.Add(new Supplier() { TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "78508614004", RazaoSocial = "ALVARO MARQUES TEIXEIRA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "ALVAROM@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-18).AddMonths(-2), Genero = 1, });
           
            #endregion

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>(a =>
           {
               a.HasKey(e => e.Id);

               a.Property(x => x.Id).IsRequired();
               a.Property(x => x.TipoEmpresa).IsRequired();
               a.Property(x => x.Nacional).IsRequired();
               a.Property(x => x.TipoPessoa).IsRequired();
               a.Property(x => x.CPFCNPJ).HasMaxLength(18).IsRequired();
               a.Property(x => x.RazaoSocial).HasMaxLength(100).IsRequired();
               a.Property(x => x.Fone1).HasMaxLength(15).IsRequired();
               a.Property(x => x.Email).HasMaxLength(100).IsRequired();

               a.Property(x => x.NomeFantasia).HasMaxLength(100);
               a.Property(x => x.Fone2).HasMaxLength(15);
               a.Property(x => x.Fone3).HasMaxLength(15);
               a.Property(x => x.WebSite).HasMaxLength(100);
               a.Property(x => x.Profissao).HasMaxLength(100);
               a.Property(x => x.Nacionalidade).HasMaxLength(100);

               a.Property(p => p.QtdQuota)
                //.HasColumnName("val_tensaobaseft")
                .HasColumnType<decimal>("numeric");

               a.Property(p => p.VlrQuota)
                //.HasColumnName("val_tensaobaseft")
                .HasColumnType<decimal>("numeric");

               a.Property(p => p.CapitalSocial)
                //.HasColumnName("val_tensaobaseft")
                .HasColumnType<decimal>("numeric");

           });               
                

            //modelBuilder.Entity<Produto>()
            //    .Property(x => x.Preco).HasColumnType<decimal>("numeric").HasPrecision(18);

            //modelBuilder.Entity<Produto>().ToTable("Produtos");
            //modelBuilder.Entity<Categoria>().ToTable("Categorias");


            //modelBuilder.Entity<Empregado>().
            //        Property(x => x.Id).IsRequired();
            //modelBuilder.Entity<Empregado>().
            //        Property(x => x.Nome).IsRequired().HasMaxLength(100);


            //base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
