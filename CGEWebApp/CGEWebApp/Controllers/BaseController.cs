using AutoMapper;
using System.Web.Mvc;
using WebCore.DTO;
using WebCore.Extensions;

namespace CGEWebApp.Controllers
{
    public class BaseController : Controller
    {
        protected static readonly MapperConfiguration pfDTOMapConfig = new MapperConfiguration(c =>
                c.CreateMap<SupplierDTO, SupplierPFDTO>()             
                .IgnoreNoMap());


        protected static readonly MapperConfiguration pjDTOMapConfig = new MapperConfiguration(c =>
                c.CreateMap<SupplierDTO, SupplierPJDTO>()
                    .ForSourceMember(m => m.GetNacional, opt => opt.DoNotValidate())
                    .ForSourceMember(m => m.GetSituacao, opt => opt.DoNotValidate())
                    .ForSourceMember(m => m.GetTipoEmpresa, opt => opt.DoNotValidate())
                    .ForSourceMember(m => m.GetTipoPessoa, opt => opt.DoNotValidate())
                    .ForSourceMember(m => m.GetPorte, opt => opt.DoNotValidate())
                    //.IgnoreNoMap())
                    );

        protected JsonResult JsonResponse(object obj)
        {
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
       
        #region DOING MAPPER THINGS !!!

        protected static SupplierDTO MapToSave<T>(MapperConfiguration cfg, T origin)
        {            
            var mapper = new Mapper(cfg);
            var newitem = mapper.Map<T, SupplierDTO>(origin);
            return newitem;
        }

        protected static T MapToDTO<T>(MapperConfiguration cfg, SupplierDTO origin)
        {
            var mapper = new Mapper(cfg);
            var newitem = mapper.Map<SupplierDTO, T>(origin);
            return newitem;
        }

        #endregion
    }
}