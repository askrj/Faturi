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
    public class BeneficiarioService : IBeneficiarioService
    {

        private readonly IMapper _mapper;
        private IBeneficiarioRepository _beneficiarioRepository;
        public BeneficiarioService(IBeneficiarioRepository beneficiarioRepository, IMapper mapper)
        {
            _beneficiarioRepository = beneficiarioRepository ?? throw new ArgumentNullException(nameof(beneficiarioRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<BeneficiarioDTO>> GetBeneficiarios()
        {
            var beneficiarioEntity = await _beneficiarioRepository.GetBeneficiario();
            return _mapper.Map<IEnumerable<BeneficiarioDTO>>(beneficiarioEntity);
        }

        public async Task<BeneficiarioDTO> GetBeneficiarioConvenio(int? id)
        {
            var beneficiarioEntity = await _beneficiarioRepository.GetBeneficiarioConvenioById(id);
            return _mapper.Map<BeneficiarioDTO>(beneficiarioEntity);
        }

        public async Task<BeneficiarioDTO> GetById(int? id)
        {
            var beneficiarioEntity = await _beneficiarioRepository.GetById(id);
            return _mapper.Map<BeneficiarioDTO>(beneficiarioEntity);
        }

        public async Task Add(BeneficiarioDTO beneficiarioDTO)
        {
            var beneficiarioEntity = _mapper.Map<Beneficiario>(beneficiarioDTO);
            await _beneficiarioRepository.Create(beneficiarioEntity);
        }

        public async Task Remove(int? id)
        {
            var beneficiarioEntity = _beneficiarioRepository.GetById(id).Result;
            await _beneficiarioRepository.Remove(beneficiarioEntity);
        }

        public async Task Update(BeneficiarioDTO beneficiarioDTO)
        {
            var beneficiarioEntity = _mapper.Map<Beneficiario>(beneficiarioDTO);
            await _beneficiarioRepository.Update(beneficiarioEntity);
        }
    }
}
