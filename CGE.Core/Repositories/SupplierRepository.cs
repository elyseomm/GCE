using AutoMapper;
using CGE.Core.DTO;
using CGE.Core.Enums;
using CGE.Core.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CGE.Core.Repositories
{
    public class SupplierRepository : BaseRepository
    {
        #region MAPEAMENTOS ENTITY / DTO 
                
        private readonly MapperConfiguration pfMapConfig = new MapperConfiguration(c =>
                c.CreateMap<SupplierPFDTO, Supplier>());

        private readonly MapperConfiguration pjMapConfig = new MapperConfiguration(c =>
                c.CreateMap<SupplierPJDTO, Supplier>());

        private readonly MapperConfiguration pfDTOMapConfig = new MapperConfiguration(c =>
                c.CreateMap<Supplier, SupplierPFDTO>());

        private readonly MapperConfiguration pjDTOMapConfig = new MapperConfiguration(c =>
                c.CreateMap<Supplier,SupplierPJDTO>());

        #endregion
        public SupplierRepository(ILogger logger,
            CGEContext db) : base(logger, db)
        {
        }

        public IEnumerable<Supplier> GetAll() => _context.Suppliers.AsEnumerable();

        public Supplier GetById(int id) => _context.Suppliers.Find(id);

        public SupplierPFDTO NewPF(SupplierPFDTO pf)
        {            
            if (pf != null)
            {
                #region Field Validation

                ValidateSupplierFields(pf);

                if (string.IsNullOrWhiteSpace(pf.Profissao))
                    throw new Exception("Preencha o Profissão. Campo requerido!");

                if (!pf.DtNascimento.HasValue )
                    throw new Exception("Preencha a Data de Nascimento. Campo requerido!");

                if (pf.Genero < 0)
                    throw new Exception("Preencha o Gênero. Campo requerido!");

                #endregion
                                
                var newitem = MapToSave<SupplierPFDTO>(pfMapConfig, pf);

                newitem.DtAtualizacao = DateTime.Now;
                newitem.Situacao = 0;

                _context.Suppliers.Add(newitem);
                _context.SaveChanges();
                var resp = MapToDTO<SupplierPFDTO>(pfDTOMapConfig, newitem);

                return resp;
            }

            return null;
        }

        public SupplierPJDTO NewPJ(SupplierPJDTO pj)
        {
            if (pj != null)
            {
                #region Field Validation

                ValidateSupplierFields(pj);

                if (pj.CapitalSocial > 0)
                    throw new Exception("Preencha o Capital Social. Campo requerido!");

                #endregion

                var newitem = MapToSave<SupplierPJDTO>(pjMapConfig, pj);

                newitem.DtAtualizacao = DateTime.Now;
                newitem.Situacao = 0;

                _context.Suppliers.Add(newitem);
                _context.SaveChanges();

                var resp = MapToDTO<SupplierPJDTO>(pjDTOMapConfig, newitem);
                return resp;
            }
            return null;
        }

        public SupplierPFDTO UpdatePF(SupplierPFDTO pf)
        {
            if (pf != null)
            {
                var supp = GetById(pf.Id);
                if (supp != null)
                {
                    #region Field Validation

                    ValidateSupplierFields(pf);

                    if (string.IsNullOrWhiteSpace(pf.Profissao))
                        throw new Exception("Preencha o Profissão. Campo requerido!");

                    if (!pf.DtNascimento.HasValue)
                        throw new Exception("Preencha a Data de Nascimento. Campo requerido!");

                    if (pf.Genero < 0)
                        throw new Exception("Preencha o Gênero. Campo requerido!");

                    #endregion
                    
                    supp.TipoPessoa = pf.TipoPessoa;
                    supp.Nacional = pf.Nacional;
                    supp.CPFCNPJ = pf.CPFCNPJ;
                    supp.RazaoSocial = pf.RazaoSocial;
                    supp.Email = pf.Email;                    
                    supp.Fone1 = pf.Fone1;
                    supp.TipoEmpresa = pf.TipoEmpresa;
                    supp.DtNascimento = pf.DtNascimento;
                    supp.Genero = pf.Genero;
                    supp.Fone2 = pf.Fone2;
                    supp.Fone3 = pf.Fone3;                    

                    supp.EstadoCivil = pf.EstadoCivil;
                    supp.Profissao = pf.Profissao;
                    supp.DtNascimento = pf.DtNascimento;
                    supp.Nacionalidade = pf.Nacionalidade;
                    supp.Situacao = pf.Situacao;
                    supp.DtAtualizacao = DateTime.Now;
                    
                    _context.Suppliers.Update(supp);
                    _context.SaveChanges();
                    var resp = MapToDTO<SupplierPFDTO>(pfDTOMapConfig, supp);

                    return resp;
                }
            }

            return null;
        }

        public SupplierPJDTO UpdatePJ(SupplierPJDTO pj)
        {
            if (pj != null)
            {
                var supp = GetById(pj.Id);
                if (supp != null)
                {
                    #region Field Validation

                    ValidateSupplierFields(pj);

                    if (pj.CapitalSocial < 0)
                        throw new Exception("Preencha o Capital Social. Campo requerido!");

                    #endregion

                    supp.TipoPessoa = pj.TipoPessoa;
                    supp.Nacional = pj.Nacional;
                    supp.CPFCNPJ = pj.CPFCNPJ;
                    supp.RazaoSocial = pj.RazaoSocial;
                    supp.Email = pj.Email;                    
                    supp.Fone1 = pj.Fone1;
                    supp.TipoEmpresa = pj.TipoEmpresa;

                    supp.Fone2 = pj.Fone2;
                    supp.Fone3 = pj.Fone3;
                    supp.NomeFantasia = pj.NomeFantasia;
                    supp.DtConstituicao = pj.DtConstituicao;
                    supp.Porte = pj.Porte;
                    supp.WebSite = pj.WebSite;
                    supp.CaracterizacaoCapital = pj.CaracterizacaoCapital;
                    supp.QtdQuota = pj.QtdQuota;
                    supp.VlrQuota = pj.VlrQuota;
                    supp.CapitalSocial = pj.CapitalSocial;

                    supp.Situacao = pj.Situacao;
                    supp.DtAtualizacao = DateTime.Now;

                    _context.Suppliers.Update(supp);
                    _context.SaveChanges();
                    var resp = MapToDTO<SupplierPJDTO>(pjDTOMapConfig, supp);
                   
                    return resp;
                }
            }

            return null;
        }

        public bool AtivarSupplier(int id)
            => ChangeSupplierState(id, SupplierSituation.Ativado);

        public bool DesativarSupplier(int id)
            => ChangeSupplierState(id, SupplierSituation.Desativado);

        private bool ChangeSupplierState(int id, SupplierSituation state)
        {
            if (id < 0)
                throw new Exception("Supplier ID inválido");

            var supp = GetById(id);
            if (supp != null)
            {
                supp.Situacao = (int)state;
                supp.DtAtualizacao = DateTime.Now;
                _context.Suppliers.Update(supp);
                _context.SaveChanges();
                return true;                
            }

            return false;
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


        public bool DeleteSupplier(int id)
        {
            if (id < 0)
                throw new Exception("Supplier ID inválido");

            var supp = GetById(id);
            if (supp != null)
            {
                // * Só permite excluir registros EmElaboração / Desativados
                if (supp.Situacao == (int)SupplierSituation.EmElaboracao ||
                    supp.Situacao == (int)SupplierSituation.Desativado)
                {
                    _context.Suppliers.Remove(supp);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        #region DOING MAPPER THINGS !!!

        private static Supplier MapToSave<T>(MapperConfiguration cfg, T origin)
        {
            var mapper = new Mapper(cfg);
            var newitem = mapper.Map<T, Supplier>(origin);
            return newitem;
        }

        private static T MapToDTO<T>(MapperConfiguration cfg, Supplier origin)
        {
            var mapper = new Mapper(cfg);
            var newitem = mapper.Map<Supplier, T>(origin);
            return newitem;
        }

        #endregion
    }
}
