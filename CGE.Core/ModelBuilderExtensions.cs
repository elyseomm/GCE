using CGE.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CGE.Core
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().HasData(            
                
                #region ADDING PJ SUPPLIERS

                new Supplier() { Id = 1, TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "01571702000198", RazaoSocial = "HALEX ISTAR IND FARMACEUTICA LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "HALEXFARMACO@HALEX.COM.BR", CapitalSocial = 20000000 },
                new Supplier() { Id = 2, TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "17162579000191", RazaoSocial = "LIDER TAXI AEREO S/A AIR BRASIL", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "CONTATO@LIDERTAXI.COM.BR", CapitalSocial = 5000000 },
                new Supplier() { Id = 3, TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "28672087000162", RazaoSocial = "SAINT GOBAIN CANALIZAÇÃO LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "CONTATO@SAINTGOBAIN.COM.BR", CapitalSocial = 10000100 },
                new Supplier() { Id = 4, TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "33113309000147", RazaoSocial = "VALID SOLUÇÕES SERVIÇOS DE SEGURANÇA EM MEIOS", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "VALIDSOLUCOESSEGURANCA@VALIDSOLUÇÕES.COM.BR", CapitalSocial = 85000500 },
                new Supplier() { Id = 5, TipoPessoa = 1, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "33131079000149", RazaoSocial = "CARL ZEISS DO BRASIL LTDA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "CONTATO@CARLZEISS.COM.BR", CapitalSocial = 320000100 },

                #endregion

                #region ADDING PF SUPPLIERS

                new Supplier() { Id = 6, TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "97672971034", RazaoSocial = "CAMILA LAIS CARGNELUTTI", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "CAMILA_CARGNELUTTI@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-20).AddMonths(-1), Genero = 0 },
                new Supplier() { Id = 7, TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "09641388049", RazaoSocial = "RUI GARIGHAM PINTO", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "RUIPINTO@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-24).AddMonths(-7), Genero = 1 },
                new Supplier() { Id = 8, TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "94976767787", RazaoSocial = "GIBRALTAR PEDRO CIPRIANO", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "GILMARVIDAL@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-15).AddMonths(-3), Genero = 1, },
                new Supplier() { Id = 9, TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "81254784004", RazaoSocial = "ANDRE BAZACAS VELHO", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "ANDREVELHO99@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-19).AddMonths(-1), Genero = 1, },
                new Supplier() { Id = 10, TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "46056564053", RazaoSocial = "GILMAR THUME", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "GILMARTH90@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-22).AddMonths(-4), Genero = 1, },
                new Supplier() { Id = 11, TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "28866991015", RazaoSocial = "CLEICE AMABILE LEVY ZAGO", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "CLEICEZAGO@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-21).AddMonths(-9), Genero = 0, },
                new Supplier() { Id = 12, TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "93233728034", RazaoSocial = "MONICA CRISTIANE RINCK", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "MONICACRIS88@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-24).AddMonths(-1), Genero = 0, },
                new Supplier() { Id = 13, TipoPessoa = 0, Nacional = 1, DtAtualizacao = DateTime.Now, Situacao = 0, CPFCNPJ = "78508614004", RazaoSocial = "ALVARO MARQUES TEIXEIRA", TipoEmpresa = 1, Porte = 5, Fone1 = "5133663806", Email = "ALVAROM@GMAIL.COM", Profissao = "NÃO INFORMADO", DtNascimento = DateTime.Now.AddYears(-18).AddMonths(-2), Genero = 1, }

                #endregion
            );                        
        }
    }
}
