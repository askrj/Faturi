using Faturi.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Domain.Entities
{
    public sealed class Beneficiario : Entity
    {
        public string Nome { get; private set; }
        public string Carteira { get; private set; }
        public string CPF { get; private set; }
        public DateTime Nascimento { get; private set; }
        public string Foto { get; private set; }

        public Beneficiario(string nome, string carteira, string cpf, DateTime nascimento, string foto) 
        {
            ValidateDomain(nome, carteira, cpf, nascimento, foto);
        }

        public Beneficiario(int id, string nome, string carteira, string cpf, DateTime nascimento, string foto)
        {
            DomainValidation.When(id < 0, "Código inválido");
            ValidateDomain(nome, carteira, cpf, nascimento, foto);
        }

        public void update(string nome, string carteira, string cpf, DateTime nascimento, string foto)
        {
            ValidateDomain(nome, carteira, cpf, nascimento, foto);
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

            Nome = nome;
            Carteira = carteira;
            CPF = cpf;
            Foto = foto;

        }
        public Beneficiario(int id, string nome, string carteira, string cpf, DateTime nascimento)
        {
            Id= id;
            Nome= nome;
            Carteira= carteira;
            CPF= cpf;
            Nascimento= nascimento;
        }

        public int ConvenioId { get; set; }
        public Convenio Convenio { get; set; }
    }
}
