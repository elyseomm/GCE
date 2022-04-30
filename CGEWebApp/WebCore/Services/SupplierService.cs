using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.ClientHttp;
using WebCore.DTO;

namespace WebCore.Services
{
    public class SupplierService
    {
        private ApiClientRequest _client = null;

        // * LISTAR
        private string GET_ALL_SUPPLIERS = string.Empty;
        private string GET_SUPPLIER = string.Empty;
        // * SALVAR
        private string POST_SUPPLIER_PF = string.Empty;
        private string POST_SUPPLIER_PJ = string.Empty;
        // * ATUALIZAR
        private string PUT_SUPPLIER_PF = string.Empty;
        private string PUT_SUPPLIER_PJ = string.Empty;
        // * ATIVAR / DESATIVAR
        private string PATCH_SUPPLIER_ACTIVATE = string.Empty;
        private string PATCH_SUPPLIER_DEACTIVATE = string.Empty;
        // * DELETAR
        private string DELETE_SUPPLIER = string.Empty;

        public SupplierService()
        {
            _client = new ApiClientRequest();

            // * Carrega os endereços das rotas da API ...
            FillInSupplierApiRoutes();
        }

        private void FillInSupplierApiRoutes()
        {
            GET_ALL_SUPPLIERS = Utils.Get("SupplierList");
            GET_SUPPLIER = Utils.Get("Supplier");

            POST_SUPPLIER_PF = Utils.Get("NewPF");
            POST_SUPPLIER_PJ = Utils.Get("NewPJ");

            PUT_SUPPLIER_PF = Utils.Get("UpdatePF");
            PUT_SUPPLIER_PJ = Utils.Get("UpdatePJ");

            PATCH_SUPPLIER_ACTIVATE = Utils.Get("Ativar");
            PATCH_SUPPLIER_ACTIVATE = Utils.Get("Desativar");

            DELETE_SUPPLIER = Utils.Get("Delete");
        }

        public async Task<List<SupplierDTO>> GetAll()
        {
            List<SupplierDTO> result = null;
            try
            {
                var jStrResponse = await _client.DoGet(GET_ALL_SUPPLIERS);

                var jrows = Utils.ToJArray(jStrResponse);
                if (jrows.IsNotNull())
                {
                    result = jrows.Select(x => new SupplierDTO()
                    {
                        Id = x.Value<int>("id"),
                        TipoPessoa = x.Value<int>("tipoPessoa"),
                        TipoEmpresa = x.Value<int>("tipoEmpresa"),
                        Nacional = x.Value<int>("nacional"),
                        Situacao = x.Value<int>("situacao"),
                        
                        CPFCNPJ = x.Value<string>("cpfcnpj"),
                        RazaoSocial = x.Value<string>("razaoSocial"),
                        Fone1 = x.Value<string>("fone1"),
                        Fone2 = x.Value<string>("fone2"),
                        Fone3 = x.Value<string>("fone3"),
                        Email = x.Value<string>("email"),

                        DtAtualizacao = x.Value<DateTime>("dtAtualizacao"),

                        #region Atributos Pessoa Juridica

                        Porte = x.Value<int?>("porte"),
                        CaracterizacaoCapital = x.Value<int?>("caracterizacaoCapital"),                        
                        NomeFantasia = x.Value<string>("nomeFantasia"),
                        WebSite = x.Value<string>("webSite"),
                        QtdQuota = x.Value<decimal?>("qtdQuota"),
                        VlrQuota = x.Value<decimal?>("vlrQuota"),
                        CapitalSocial = x.Value<decimal?>("capitalSocial"),
                        DtConstituicao = x.Value<DateTime?>("dtConstituicao"),

                        #endregion
                        
                        #region Atributos Pessoa Física

                        EstadoCivil = x.Value<int?>("estadoCivil"),
                        Profissao = x.Value<string>("profissao"),
                        DtNascimento = x.Value<DateTime?>("dtNascimento"),
                        Genero = x.Value<int?>("genero"),
                        Nacionalidade = x.Value<string>("nacionalidade")
                        
                        #endregion

                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public SupplierDTO GetById(int id)
        {
            SupplierDTO result = null;
            try
            {
                var get_by_id = $"{GET_SUPPLIER}/{id}";
                var jStrResponse = _client.DoGet(get_by_id).Result;

                var jobj = Utils.ToJObj(jStrResponse);
                var jrows = Utils.ToJArray(jStrResponse);
                if (jrows.IsNotNull())
                {
                    result = jrows.Select(x => new SupplierDTO()
                    {
                        Id = x.Value<int>("id"),
                        TipoPessoa = x.Value<int>("tipoPessoa"),
                        TipoEmpresa = x.Value<int>("tipoEmpresa"),
                        Nacional = x.Value<int>("nacional"),
                        Situacao = x.Value<int>("situacao"),

                        CPFCNPJ = x.Value<string>("cpfcnpj"),
                        RazaoSocial = x.Value<string>("razaoSocial"),
                        Fone1 = x.Value<string>("fone1"),
                        Fone2 = x.Value<string>("fone2"),
                        Fone3 = x.Value<string>("fone3"),
                        Email = x.Value<string>("email"),

                        DtAtualizacao = x.Value<DateTime>("dtAtualizacao"),

                        #region Atributos Pessoa Juridica

                        Porte = x.Value<int?>("porte"),
                        CaracterizacaoCapital = x.Value<int?>("caracterizacaoCapital"),
                        NomeFantasia = x.Value<string>("nomeFantasia"),
                        WebSite = x.Value<string>("webSite"),
                        QtdQuota = x.Value<decimal?>("qtdQuota"),
                        VlrQuota = x.Value<decimal?>("vlrQuota"),
                        CapitalSocial = x.Value<decimal?>("capitalSocial"),
                        DtConstituicao = x.Value<DateTime?>("dtConstituicao"),

                        #endregion

                        #region Atributos Pessoa Física

                        EstadoCivil = x.Value<int?>("estadoCivil"),
                        Profissao = x.Value<string>("profissao"),
                        DtNascimento = x.Value<DateTime?>("dtNascimento"),
                        Genero = x.Value<int?>("genero"),
                        Nacionalidade = x.Value<string>("nacionalidade")

                        #endregion

                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public SupplierPFDTO SalvarPF(SupplierPFDTO dados)
        {
            SupplierPFDTO result = null;
            try
            {
                var route = $"{POST_SUPPLIER_PF}";

                var jObj = JObject.FromObject(dados);

                _client.AddValue("data", jObj.ToString());

                var jrows = _client.DoPost(route).Result;

                var jobj = Utils.ToJObj(jrows);

                if (jobj.IsNotNull())
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public SupplierPFDTO SalvarPJ(SupplierPFDTO dados)
        {
            SupplierPFDTO result = null;
            try
            {
                var route = $"{POST_SUPPLIER_PJ}";

                var jObj = JObject.FromObject(dados);

                _client.AddValue("data", jObj.ToString());

                var jrows = _client.DoPost(route).Result;

                var jobj = Utils.ToJObj(jrows);

                if (jobj.IsNotNull())
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public bool Delete(int id )
        {            
            try
            {
                var route = $"{DELETE_SUPPLIER}/{id}";
                var jrows = _client.DoDelete(route).Result;

                var jobj = Utils.ToJObj(jrows);

                if (jobj.IsNotNull())
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
