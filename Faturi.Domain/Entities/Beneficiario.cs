using Faturi.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Faturi.Domain.Entities
{
    public sealed class Beneficiario : Entity
    {
        public string Nome { get; private set; }
        public string Carteira { get; private set; }
        public string CPF { get; private set; }
        public DateTime Nascimento { get; private set; }
        public string Foto { get; private set; }

        public Beneficiario() { }

        public Beneficiario(string nome, string carteira, string cpf, DateTime nascimento, string foto) 
        {
            ValidateDomain(nome, carteira, cpf, nascimento, foto);
        }

        public Beneficiario(int id, string nome, string carteira, string cpf, DateTime nascimento, string foto)
        {
            DomainValidation.When(id < 0, "Código inválido");
            Id = id;
            ValidateDomain(nome, carteira, cpf, nascimento, foto);
        }

        public void update(string nome, string carteira, string cpf, DateTime nascimento, string foto, int convenioId)
        {
            ValidateDomain(nome, carteira, cpf, nascimento, foto);
            ConvenioId = convenioId;
        }



        public void ValidateDomain(string nome, string carteira, string cpf, DateTime nascimento,  string foto)
        {
            DomainValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");

            DomainValidation.When(string.IsNullOrEmpty(carteira), "Nome é obrigatório");
            DomainValidation.When(string.IsNullOrEmpty(cpf), "Nome é obrigatório");


            DomainValidation.When(nome.Length < 5,
                "Nome precisa de no minimo cinco caracteres");

            DomainValidation.When(foto.Length > 255,
                "Nome precisa de no minimo cinco caracteres");

            DomainValidation.When(foto.Length > 250,
                "Invalid image name, too long, maximum 250 characters");

            Nome = nome;
            Carteira = carteira;
            CPF = cpf;
            Nascimento = nascimento;
            Foto = foto;

        }

        public int ConvenioId { get; set; }
        public Convenio Convenio { get; set; } 
    }
}
