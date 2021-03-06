using CGEWebApp.Tools;
using Newtonsoft.Json.Linq;
using PagedList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCore;
using WebCore.ClientHttp;
using WebCore.DTO;
using WebCore.Enums;
using WebCore.Extensions;
using WebCore.Responses;
using WebCore.Services;

namespace CGEWebApp.Controllers
{
    public class SupplierController : BaseController
    {
        private SupplierService _service = null;

        private SupplierService GetService()
        {
            if (_service.IsNull())
            {
                _service = new SupplierService();
            }
            return _service;
        }

        private void ValidateSupplierFields(ISupplierDTO sup)
        {
            #region Field Validation

            if (sup.TipoPessoa < 0)
                throw new Exception("Preencha o Tipo Pessoa. Campo requerido!");

            if (sup.Nacional < 0)
                throw new Exception("Preencha o Nacional. Campo requerido!");

            if (string.IsNullOrWhiteSpace(sup.CPFCNPJ))
                throw new Exception("Preencha o CPF. Campo requerido!");

            if (string.IsNullOrWhiteSpace(sup.RazaoSocial))
                throw new Exception("Preencha o Nome. Campo requerido!");

            if (string.IsNullOrWhiteSpace(sup.Email))
                throw new Exception("Preencha o Email. Campo requerido!");

            if (string.IsNullOrWhiteSpace(sup.Fone1))
                throw new Exception("Preencha o Fone1. Campo requerido!");

            if (sup.TipoEmpresa < 0)
                throw new Exception("Preencha o Tipo Empresa. Campo requerido!");

            #endregion
        }

        // GET: Supplier
        public ActionResult Index(int page = 1)
        {
            try
            {
                @ViewBag.Erro = string.Empty;
                _service = GetService();
                var rows = _service.GetAll().Result;
                var pagedRows = rows.OrderByDescending(a => a.TipoPessoa).ToPagedList(page, 50);
                return View(pagedRows);
            }
            catch (Exception ex)
            {
                @ViewBag.Erro = ex.Message;
            }
            return View();
        }

        // GET: Supplier/Details/5
        public JsonResult GetById(int id)
        {
            var response = ResponseBase.ResponseError("Fornecedor não encontrado!");
            _service = GetService();
            var row = _service.GetById(id).Result;
            if (row.IsNotNull())
            {
                var tipoEmpresaList = Tool.GetTipoEmpresasList();
                var porteList = Tool.GetPorteEmpresasList();
                var tipoCapitalList = Tool.GetTipoCapitalList();
                var generoList = Tool.GetGeneroList();
                var estCivilList = Tool.GetEstadoCivilList();

                response.ResponseText = "OK";
                response.Data = new { data = row,
                    lstTpEmpresas = tipoEmpresaList,
                    lstPorteEmpresas = porteList,
                    lstCaractCapital = tipoCapitalList,
                    lstGenero = generoList,
                    lstEstCivil = estCivilList,
                };
                response.Status = true;
                
                return JsonResponse(response);
            }
            return JsonResponse(response);
        }

        public ActionResult GetComboLists()
        {
            var tipoEmpresaList = Tool.GetTipoEmpresasList();
            var porteList = Tool.GetPorteEmpresasList();
            var tipoCapitalList = Tool.GetTipoCapitalList();
            var generoList = Tool.GetGeneroList();
            var estCivilList = Tool.GetEstadoCivilList();

            var response = new ResponseBase(new
            {
                lstTpEmpresas = tipoEmpresaList,
                lstPorteEmpresas = porteList,
                lstCaractCapital = tipoCapitalList,
                lstGenero = generoList,
                lstEstCivil = estCivilList,
            });
            return JsonResponse(response);
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            var response = new ResponseBase();
            try
            {
                _service = GetService();

                var tp = collection.GetValue("TipoPessoa").RawValue.ToInt();
                if (tp == EnumTipoPessoa.PF.AsInt())
                {
                    DateTime? dtNasc = null;
                    var strDtNasc = collection.GetValue("DtNascimento").AttemptedValue.Str();
                    if (strDtNasc.IsSet())
                        dtNasc = DateTime.Parse(strDtNasc);

                    var pfDTO = new SupplierPFDTO()
                    {
                        CPFCNPJ = collection.GetValue("CPF").AttemptedValue.Str(),
                        RazaoSocial = collection.GetValue("Nome").AttemptedValue.Str(),
                        TipoPessoa = tp,
                        Nacional = collection.GetValue("Nacional").AttemptedValue.ToInt(),
                        TipoEmpresa = collection.GetValue("TipoEmpresa").AttemptedValue.ToInt(),
                        Email = collection.GetValue("Email").AttemptedValue.Str(),
                        Situacao = EnumSupplierSituation.EmElaboracao.AsInt(),
                        
                        EstadoCivil = collection.GetValue("EstadoCivil")?.AttemptedValue.ToInt(),
                        Profissao = collection.GetValue("Profissao")?.AttemptedValue.Str(),
                        Fone1 = collection.GetValue("Fone1").AttemptedValue.Str(),
                        Fone2 = collection.GetValue("Fone2")?.AttemptedValue.Str(),
                        Fone3 = collection.GetValue("Fone3")?.AttemptedValue.Str(),
                        DtNascimento = dtNasc,
                        Genero = collection.GetValue("Genero")?.AttemptedValue.ToInt(),
                        Nacionalidade = collection.GetValue("Nacionalidade")?.AttemptedValue.Str()
                    };

                    ValidateSupplierFields(pfDTO);                    

                    if (string.IsNullOrWhiteSpace(pfDTO.Profissao))
                        throw new Exception("Preencha o Profissão. Campo requerido!");

                    if (!pfDTO.DtNascimento.HasValue)
                        throw new Exception("Preencha a Data de Nascimento. Campo requerido!");

                    if (pfDTO.Genero < 0)
                        throw new Exception("Preencha o Gênero. Campo requerido!");

                    var respPF = _service.SalvarPF(pfDTO, isNewPF: true).Result;

                    response.Status = true;
                    response.ResponseText = "Fornecedor Salvo com sucesso!";
                    response.Data = respPF;
                    
                }
                else  // PESSOA JURIDICA
                {
                    DateTime? dtConst = null;
                    var strDtConst = collection.GetValue("DtConstituicao").AttemptedValue.Str();
                    if (strDtConst.IsSet())
                        dtConst = DateTime.Parse(strDtConst);

                    var pjDTO = new SupplierPJDTO()
                    {
                        CPFCNPJ = collection.GetValue("CNPJ")?.AttemptedValue.Str(),
                        RazaoSocial = collection.GetValue("RazaoSocial")?.AttemptedValue.Str(),
                        TipoPessoa = tp,
                        Nacional = collection.GetValue("Nacional").AttemptedValue.ToInt(),
                        TipoEmpresa = collection.GetValue("TipoEmpresa").AttemptedValue.ToInt(),
                        Email = collection.GetValue("Email")?.AttemptedValue.Str(),
                        Situacao = EnumSupplierSituation.EmElaboracao.AsInt(),
                        DtConstituicao = dtConst,
                        Porte = collection.GetValue("Porte")?.AttemptedValue.ToInt(),
                        NomeFantasia = collection.GetValue("NomeFantasia")?.AttemptedValue.Str(),
                        WebSite = collection.GetValue("WebSite")?.AttemptedValue.Str(),
                        Fone1 = collection.GetValue("Fone1")?.AttemptedValue.Str(),
                        Fone2 = collection.GetValue("Fone2")?.AttemptedValue.Str(),
                        Fone3 = collection.GetValue("Fone3")?.AttemptedValue.Str(),

                        CaracterizacaoCapital = collection.GetValue("CaracterizacaoCapital")?.AttemptedValue?.ToInt(),
                        QtdQuota = collection.GetValue("QtdQuota").AttemptedValue?.ToDec(),
                        VlrQuota = Utils.FrmDec(collection.GetValue("VlrQuota")?.AttemptedValue),
                        CapitalSocial = Utils.FrmDec(collection.GetValue("CapitalSocial")?.AttemptedValue)
                    };
                    
                    ValidateSupplierFields(pjDTO);

                    if (pjDTO.CapitalSocial < 0)
                        throw new Exception("Preencha o Capital Social. Campo requerido!");

                    var respPJ = _service.SalvarPJ(pjDTO, isNewPF: true).Result;

                    response.Status = true;
                    response.ResponseText = "Fornecedor Salvo com sucesso!";
                    response.Data = respPJ;
                }
            }
            catch ( Exception ex)
            {
                response = ResponseBase.ResponseError(ex.Message);
            }
            return JsonResponse(response);
        }
        
        // POST: Supplier/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            var response = ResponseBase.ResponseError("Erro ao alterar o Fornecedor.");
            try
            {
                _service = GetService();

                var id = collection.GetValue("id").AttemptedValue.ToInt();
                var row = _service.GetById(id).Result;
                if (row.TipoPessoa == EnumTipoPessoa.PF.AsInt())
                {
                    DateTime? dtNasc = null;
                    var strDtNasc = collection.GetValue("DtNascimento")?.AttemptedValue.Str();
                    if (strDtNasc.IsSet())
                        dtNasc = DateTime.Parse(strDtNasc);
                    
                    row.CPFCNPJ = collection.GetValue("CPF").AttemptedValue.Str();
                    row.RazaoSocial = collection.GetValue("Nome").AttemptedValue.Str();
                    row.Nacional = collection.GetValue("Nacional").AttemptedValue.ToInt();
                    row.TipoEmpresa = collection.GetValue("TipoEmpresa").AttemptedValue.ToInt();
                    row.Email = collection.GetValue("Email").AttemptedValue.Str();

                    row.Fone1 = collection.GetValue("Fone1").AttemptedValue.Str();
                    row.Fone2 = collection.GetValue("Fone2")?.AttemptedValue.Str();
                    row.Fone3 = collection.GetValue("Fone3")?.AttemptedValue.Str();

                    row.DtNascimento = dtNasc;
                    row.EstadoCivil = collection.GetValue("EstadoCivil")?.AttemptedValue.ToInt();
                    row.Genero = collection.GetValue("Genero")?.AttemptedValue.ToInt();
                    row.Profissao = collection.GetValue("Profissao")?.AttemptedValue.Str();
                    row.Nacionalidade = collection.GetValue("Nacionalidade")?.AttemptedValue.Str();

                    SupplierPFDTO pfDTO = row.ParsePF();
                    var respPF = _service.SalvarPF(pfDTO).Result;
                    response.Status = true;
                    response.ResponseText = "Fornecedor Salvo com sucesso!";
                    response.Data = respPF;
                    return JsonResponse(response);
                }
                else
                {
                    DateTime? dtConst = null;
                    var strDtConst = collection.GetValue("DtConstituicao").AttemptedValue.Str();
                    if (strDtConst.IsSet())
                        dtConst = DateTime.Parse(strDtConst);

                    row.CPFCNPJ = collection.GetValue("CNPJ").AttemptedValue.Str();
                    row.RazaoSocial = collection.GetValue("RazaoSocial").AttemptedValue.Str();
                    row.Nacional = collection.GetValue("Nacional").AttemptedValue.ToInt();
                    row.TipoEmpresa = collection.GetValue("TipoEmpresa").AttemptedValue.ToInt();
                    row.Email = collection.GetValue("Email").AttemptedValue.Str();
                    
                    row.Fone1 = collection.GetValue("Fone1").AttemptedValue.Str();
                    row.Fone2 = collection.GetValue("Fone2").AttemptedValue.Str();
                    row.Fone3 = collection.GetValue("Fone3").AttemptedValue.Str();

                    row.WebSite = collection.GetValue("WebSite").AttemptedValue.Str();
                    row.DtConstituicao = dtConst;
                    row.NomeFantasia = collection.GetValue("NomeFantasia").AttemptedValue.Str();
                    row.Porte = collection.GetValue("Porte").AttemptedValue.ToInt();

                    row.CaracterizacaoCapital = collection.GetValue("CaracterizacaoCapital").AttemptedValue?.ToInt();
                    row.QtdQuota = collection.GetValue("QtdQuota").AttemptedValue?.ToDec();
                    row.VlrQuota = Utils.FrmDec(collection.GetValue("VlrQuota").AttemptedValue);
                    row.CapitalSocial = Utils.FrmDec(collection.GetValue("CapitalSocial").AttemptedValue);

                    SupplierPJDTO pjDTO = row.ParsePJ();
                    var respPJ = _service.SalvarPJ(pjDTO).Result;

                    response.Status = true;
                    response.ResponseText = "Fornecedor Salvo com sucesso!";
                    response.Data = respPJ;
                    return JsonResponse(response);
                }

            }
            catch (Exception ex)
            {
                response.ResponseText = ex.InnerException?.Message;
            }

            return JsonResponse(response);
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var response = ResponseBase.ResponseError("Fornecedor Ativado! Exclusão não permitida.");
            try
            {
                _service = GetService();
                response.Status = _service.Delete(id).Result;
                if (response.Status)
                    response.ResponseText = "OK";                
            }
            catch( Exception ex)
            {
                response.ResponseText = ex.Message;
            }
            return JsonResponse(response);
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        public ActionResult MudarSituacao(int id, int situacao)
        {
            var response = ResponseBase.ResponseError($"Fornecedor em Elaboração!");

            if (situacao > EnumSupplierSituation.EmElaboracao.AsInt())
            {                
                try
                {
                    _service = GetService();
                    response.Status = _service.ChangeState(id, situacao).Result;                    
                    if (response.Status)                   
                        response.ResponseText = "OK";
                }
                catch (Exception ex)
                {
                    response.ResponseText = ex.Message;
                }
            }
            return JsonResponse(response);
        }
    }
}
