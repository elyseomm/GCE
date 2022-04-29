using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CGE.Core.Migrations
{
    public partial class SetupInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPFCNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    TipoEmpresa = table.Column<int>(type: "int", nullable: false),
                    Fone1 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Fone2 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Fone3 = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nacional = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<int>(type: "int", nullable: false),
                    DtAtualizacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    NomeFantasia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DtConstituicao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Porte = table.Column<int>(type: "int", nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CaracterizacaoCapital = table.Column<int>(type: "int", nullable: true),
                    QtdQuota = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    VlrQuota = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    CapitalSocial = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    EstadoCivil = table.Column<int>(type: "int", nullable: true),
                    Profissao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "CPFCNPJ", "CapitalSocial", "CaracterizacaoCapital", "DtAtualizacao", "DtConstituicao", "DtNascimento", "Email", "EstadoCivil", "Fone1", "Fone2", "Fone3", "Genero", "Nacional", "Nacionalidade", "NomeFantasia", "Porte", "Profissao", "QtdQuota", "RazaoSocial", "Situacao", "TipoEmpresa", "TipoPessoa", "VlrQuota", "WebSite" },
                values: new object[,]
                {
                    { 1, "01571702000198", 20000000m, null, new DateTime(2022, 4, 28, 12, 28, 48, 5, DateTimeKind.Local).AddTicks(6959), null, null, "HALEXFARMACO@HALEX.COM.BR", null, "5133663806", null, null, null, 1, null, null, 5, null, null, "HALEX ISTAR IND FARMACEUTICA LTDA", 0, 1, 1, null, null },
                    { 2, "17162579000191", 5000000m, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(3314), null, null, "CONTATO@LIDERTAXI.COM.BR", null, "5133663806", null, null, null, 1, null, null, 5, null, null, "LIDER TAXI AEREO S/A AIR BRASIL", 0, 1, 1, null, null },
                    { 3, "28672087000162", 10000100m, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(3333), null, null, "CONTATO@SAINTGOBAIN.COM.BR", null, "5133663806", null, null, null, 1, null, null, 5, null, null, "SAINT GOBAIN CANALIZAÇÃO LTDA", 0, 1, 1, null, null },
                    { 4, "33113309000147", 85000500m, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(3337), null, null, "VALIDSOLUCOESSEGURANCA@VALIDSOLUÇÕES.COM.BR", null, "5133663806", null, null, null, 1, null, null, 5, null, null, "VALID SOLUÇÕES SERVIÇOS DE SEGURANÇA EM MEIOS", 0, 1, 1, null, null },
                    { 5, "33131079000149", 320000100m, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(3339), null, null, "CONTATO@CARLZEISS.COM.BR", null, "5133663806", null, null, null, 1, null, null, 5, null, null, "CARL ZEISS DO BRASIL LTDA", 0, 1, 1, null, null },
                    { 6, "97672971034", null, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(3340), null, new DateTime(2002, 3, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(3583), "CAMILA_CARGNELUTTI@GMAIL.COM", null, "5133663806", null, null, 0, 1, null, null, 5, "NÃO INFORMADO", null, "CAMILA LAIS CARGNELUTTI", 0, 1, 0, null, null },
                    { 7, "09641388049", null, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4452), null, new DateTime(1997, 9, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4457), "RUIPINTO@GMAIL.COM", null, "5133663806", null, null, 1, 1, null, null, 5, "NÃO INFORMADO", null, "RUI GARIGHAM PINTO", 0, 1, 0, null, null },
                    { 8, "94976767787", null, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4465), null, new DateTime(2007, 1, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4467), "GILMARVIDAL@GMAIL.COM", null, "5133663806", null, null, 1, 1, null, null, 5, "NÃO INFORMADO", null, "GIBRALTAR PEDRO CIPRIANO", 0, 1, 0, null, null },
                    { 9, "81254784004", null, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4470), null, new DateTime(2003, 3, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4471), "ANDREVELHO99@GMAIL.COM", null, "5133663806", null, null, 1, 1, null, null, 5, "NÃO INFORMADO", null, "ANDRE BAZACAS VELHO", 0, 1, 0, null, null },
                    { 10, "46056564053", null, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4473), null, new DateTime(1999, 12, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4475), "GILMARTH90@GMAIL.COM", null, "5133663806", null, null, 1, 1, null, null, 5, "NÃO INFORMADO", null, "GILMAR THUME", 0, 1, 0, null, null },
                    { 11, "28866991015", null, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4477), null, new DateTime(2000, 7, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4479), "CLEICEZAGO@GMAIL.COM", null, "5133663806", null, null, 0, 1, null, null, 5, "NÃO INFORMADO", null, "CLEICE AMABILE LEVY ZAGO", 0, 1, 0, null, null },
                    { 12, "93233728034", null, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4481), null, new DateTime(1998, 3, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4483), "MONICACRIS88@GMAIL.COM", null, "5133663806", null, null, 0, 1, null, null, 5, "NÃO INFORMADO", null, "MONICA CRISTIANE RINCK", 0, 1, 0, null, null },
                    { 13, "78508614004", null, null, new DateTime(2022, 4, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4485), null, new DateTime(2004, 2, 28, 12, 28, 48, 7, DateTimeKind.Local).AddTicks(4486), "ALVAROM@GMAIL.COM", null, "5133663806", null, null, 1, 1, null, null, 5, "NÃO INFORMADO", null, "ALVARO MARQUES TEIXEIRA", 0, 1, 0, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
