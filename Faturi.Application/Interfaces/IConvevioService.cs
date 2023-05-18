using Faturi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Interfaces
{
    public interface IConvevioService
    {
        Task<IEnumerable<ConvenioDTO>> GetConvenios();
        Task<ConvenioDTO> GetById(int? id);
        Task Add(ConvenioDTO convenioDTO);
        Task Update(ConvenioDTO convenioDTO);
        Task Remove(int? id);
    }
}
