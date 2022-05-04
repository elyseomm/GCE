using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.ClientHttp;
using WebCore.DTO;
using WebCore.Enums;
using WebCore.Extensions;

namespace WebCore.Services
{
    public class SupplierService
    {
        private ApiClientRequest _client = null;

        // * PING
        private string PING_SERVER = string.Empty;
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
        private string PUT_SUPPLIER_ACTIVATE = string.Empty;
        private string PUT_SUPPLIER_DEACTIVATE = string.Empty;
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
            PING_SERVER = Utils.Get("Ping");

            GET_ALL_SUPPLIERS = Utils.Get("SupplierList");
            GET_SUPPLIER = Utils.Get("Supplier");

            POST_SUPPLIER_PF = Utils.Get("NewPF");
            POST_SUPPLIER_PJ = Utils.Get("NewPJ");

            PUT_SUPPLIER_PF = Utils.Get("UpdatePF");
            PUT_SUPPLIER_PJ = Utils.Get("UpdatePJ");

            PUT_SUPPLIER_ACTIVATE = Utils.Get("Ativar");
            PUT_SUPPLIER_DEACTIVATE = Utils.Get("Desativar");

            DELETE_SUPPLIER = Utils.Get("Delete");
        }

        public async Task<List<SupplierDTO>> GetAll()
        {
            List<SupplierDTO> result = null;
            try
            {
                var jStrResponse = await _client.DoGet(GET_ALL_SUPPLIERS);
                if (jStrResponse.IsSet())
                {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<SupplierDTO> GetById(int id)
        {
            SupplierDTO result = null;
            try
            {
                var get_by_id = $"{GET_SUPPLIER}/{id}";
                var jStrResponse = await _client.DoGet(get_by_id);
                if (jStrResponse.IsSet())
                {
                    var jobj = Utils.ToJObj(jStrResponse);
                    if (jobj.IsNotNull())
                    {
                        result = new SupplierDTO()
                        {
                            Id = jobj.Value<int>("id"),
                            TipoPessoa = jobj.Value<int>("tipoPessoa"),
                            TipoEmpresa = jobj.Value<int>("tipoEmpresa"),
                            Nacional = jobj.Value<int>("nacional"),
                            Situacao = jobj.Value<int>("situacao"),

                            CPFCNPJ = jobj.Value<string>("cpfcnpj"),
                            RazaoSocial = jobj.Value<string>("razaoSocial"),
                            Fone1 = jobj.Value<string>("fone1"),
                            Fone2 = jobj.Value<string>("fone2"),
                            Fone3 = jobj.Value<string>("fone3"),
                            Email = jobj.Value<string>("email"),

                            DtAtualizacao = jobj.Value<DateTime>("dtAtualizacao"),

                            #region Atributos Pessoa Juridica

                            Porte = jobj.Value<int?>("porte"),
                            CaracterizacaoCapital = jobj.Value<int?>("caracterizacaoCapital"),
                            NomeFantasia = jobj.Value<string>("nomeFantasia"),
                            WebSite = jobj.Value<string>("webSite"),
                            QtdQuota = jobj.Value<decimal?>("qtdQuota"),
                            VlrQuota = jobj.Value<decimal?>("vlrQuota"),
                            CapitalSocial = jobj.Value<decimal?>("capitalSocial"),
                            DtConstituicao = jobj.Value<DateTime?>("dtConstituicao"),

                            #endregion

                            #region Atributos Pessoa Física

                            EstadoCivil = jobj.Value<int?>("estadoCivil"),
                            Profissao = jobj.Value<string>("profissao"),
                            DtNascimento = jobj.Value<DateTime?>("dtNascimento"),
                            Genero = jobj.Value<int?>("genero"),
                            Nacionalidade = jobj.Value<string>("nacionalidade")

                            #endregion

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public async Task<SupplierPFDTO> SalvarPF(SupplierPFDTO dados, bool isNewPF = false)
        {
            SupplierPFDTO result = null;
            try
            {
                var route = isNewPF ? POST_SUPPLIER_PF : PUT_SUPPLIER_PF;

                _client.JsonObj = JObject.FromObject(dados);

                if (isNewPF)
                {
                    var respINS = await _client.DoPost(route);                    

                    
                }
                else
                {
                    var respUPD = await _client.DoPut(route);
                    if (respUPD.Status == true)
                    {
                        var jobj = Utils.ToJObj(respUPD.Data.ToString());
                        if (jobj.IsNotNull())
                        {
                            result = new SupplierPFDTO()
                            {
                                Id = jobj.Value<int>("id"),
                                TipoPessoa = jobj.Value<int>("tipoPessoa"),
                                TipoEmpresa = jobj.Value<int>("tipoEmpresa"),
                                Nacional = jobj.Value<int>("nacional"),
                                Situacao = jobj.Value<int>("situacao"),
                                CPFCNPJ = jobj.Value<string>("cpfcnpj"),
                                RazaoSocial = jobj.Value<string>("razaoSocial"),
                                Fone1 = jobj.Value<string>("fone1"),
                                DtAtualizacao = jobj.Value<DateTime>("dtAtualizacao"),

                                Fone2 = jobj.Value<string>("fone2"),
                                Fone3 = jobj.Value<string>("fone3"),
                                Email = jobj.Value<string>("email"),
                                
                                #region Atributos Pessoa Física

                                EstadoCivil = jobj.Value<int?>("estadoCivil"),
                                Profissao = jobj.Value<string>("profissao"),
                                DtNascimento = jobj.Value<DateTime?>("dtNascimento"),
                                Genero = jobj.Value<int?>("genero"),
                                Nacionalidade = jobj.Value<string>("nacionalidade")

                                #endregion
                            };
                        }
                    }
                    else throw new Exception(respUPD.ResponseText);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public async Task<SupplierPJDTO> SalvarPJ(SupplierPJDTO dados, bool isNewPF = false)
        {
            SupplierPJDTO result = null;
            try
            {                
                var route = isNewPF ? POST_SUPPLIER_PJ : PUT_SUPPLIER_PJ;

                _client.JsonObj = JObject.FromObject(dados);

                if (isNewPF) { 

                    var respINS = await _client.DoPost(route);
                    
                }
                else
                {
                    var respUPD = await _client.DoPut(route);
                    if (respUPD.Status == true)
                    {
                        var jobj = Utils.ToJObj(respUPD.Data.ToString());
                        if (jobj.IsNotNull())
                        {
                            result = new SupplierPJDTO()
                            {
                                Id = jobj.Value<int>("id"),
                                TipoPessoa = jobj.Value<int>("tipoPessoa"),
                                TipoEmpresa = jobj.Value<int>("tipoEmpresa"),
                                Nacional = jobj.Value<int>("nacional"),
                                Situacao = jobj.Value<int>("situacao"),

                                CPFCNPJ = jobj.Value<string>("cpfcnpj"),
                                RazaoSocial = jobj.Value<string>("razaoSocial"),
                                Fone1 = jobj.Value<string>("fone1"),
                                Fone2 = jobj.Value<string>("fone2"),
                                Fone3 = jobj.Value<string>("fone3"),
                                Email = jobj.Value<string>("email"),

                                DtAtualizacao = jobj.Value<DateTime>("dtAtualizacao"),

                                #region Atributos Pessoa Juridica

                                Porte = jobj.Value<int?>("porte"),
                                CaracterizacaoCapital = jobj.Value<int?>("caracterizacaoCapital"),
                                NomeFantasia = jobj.Value<string>("nomeFantasia"),
                                WebSite = jobj.Value<string>("webSite"),
                                QtdQuota = jobj.Value<decimal?>("qtdQuota"),
                                VlrQuota = jobj.Value<decimal?>("vlrQuota"),
                                CapitalSocial = jobj.Value<decimal?>("capitalSocial"),
                                DtConstituicao = jobj.Value<DateTime?>("dtConstituicao"),

                                #endregion                                
                            };
                        }
                    }
                    else throw new Exception(respUPD.ResponseText);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id )
        {            
            try
            {
                var route = $"{DELETE_SUPPLIER}/{id}";
                var deletou = await _client.DoDelete(route);
                return deletou;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ChangeState(int id, int situation)
        {
            try
            {
                var route = situation == EnumSupplierSituation.Ativado.AsInt() ?
                            $"{PUT_SUPPLIER_ACTIVATE}/{id}" : $"{PUT_SUPPLIER_DEACTIVATE}/{id}";

                //$"{DELETE_SUPPLIER}/{id}";
                var alterou = await _client.DoPut(route);               
                return alterou.Status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
