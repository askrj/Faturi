using AutoMapper;
using Faturi.Application.DTOs;
using Faturi.Application.Interfaces;
using Faturi.Domain.Entities;
using Faturi.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Services
{
    public class ConvenioService : IConvevioService
    {
        private readonly IMapper _mapper;
        private IConvenioRepository _convenioRepository;
        public ConvenioService(IConvenioRepository convenioRepository, IMapper mapper)
        {
            _convenioRepository = convenioRepository;
            _mapper = mapper;
        }

        public async Task Add(ConvenioDTO convenioDTO)
        {
            var convenioEntity = _mapper.Map<Convenio>(convenioDTO);
            await _convenioRepository.Create(convenioEntity);
        }

        public async Task<ConvenioDTO> GetById(int? id)
        {
            var convenioEntity = await _convenioRepository.GetById(id);
            return _mapper.Map<ConvenioDTO>(convenioEntity); 
        }


        public async Task<IEnumerable<ConvenioDTO>> GetConvenios()
        {
            var convenioEntity = await _convenioRepository.GetConvenio();
            return _mapper.Map<IEnumerable<ConvenioDTO>>(convenioEntity);
        }

        public async Task Remove(int? id)
        {
            var convenioEntity = _convenioRepository.GetById(id).Result;
            await _convenioRepository.Remove(convenioEntity);
        }

        public async Task Update(ConvenioDTO convenioDTO)
        {
            var convenioEntity = _mapper.Map<Convenio>(convenioDTO);
            await _convenioRepository.Update(convenioEntity);
        }
    }
}
