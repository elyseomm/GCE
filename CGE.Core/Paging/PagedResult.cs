using AutoMapper;
using System;
using System.Collections.Generic;

namespace CGE.Core.Paging
{
    public sealed class PagedResult<TResult>
    {
        public int LastPage => (int)Math.Ceiling((double)TotalCount / PageSize);
        public int TotalCount { get; private set; }
        public bool HasItems => TotalCount > 0;
        public int PageSize { get; private set; }
        public int PageIndex { get; private set; }
        public List<TResult> Items { get; private set; }

        /// <summary>
        /// Retorna um objeto sem itens.
        /// Ideal para uso no serviço sem precisar chegar no repositório.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static PagedResult<TResult> Empty(PagingConfig config)
            => new PagedResult<TResult>(config, new List<TResult>(), 0);

        /// <summary>
        /// Cria um PagedResult para envolver o resultado do banco de dados
        /// repassando todas as configurações de paginação
        /// </summary>
        /// <param name="config"></param>
        /// <param name="items"></param>
        /// <param name="totalCount"></param>
        public PagedResult(PagingConfig config, List<TResult> items, int totalCount)
        {
            PageSize = config.PageSize;
            PageIndex = config.PageIndex;
            TotalCount = totalCount;
            Items = items;
        }

        /// <summary>
        /// Mapeia os itens para um novo tipo sem perder as configurações de
        /// paginação
        /// </summary>
        /// <typeparam name="TNewType"></typeparam>
        /// <returns></returns>
        //public PagedResult<TNewType> MapItemsTo<TNewType>()
        //    => new PagedResult<TNewType>(
        //            new PagingConfig(PageIndex, PageSize),
        //            Mapper.Map<List<TResult>, List<TNewType>>(Items, opt => opt.ConfigureMap(MemberList.Destination)),
        //            TotalCount
        //        );
    }
}
