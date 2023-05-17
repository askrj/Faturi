using Faturi.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Domain.Entities
{
    public sealed class Convenio : Entity
    {

        public string ANS { get; private set; }
        public string Nome { get; private set; }

        public Convenio(string nome, string ans)
        {
            ValidateDomain(nome, ans);
        }

        public Convenio(int id, string ans, string nome)
        {
            DomainValidation.When(id < 0, "Código inválido");
            ValidateDomain(nome, ans);
        }

        public void Update(string ans, string nome)
        {
            ValidateDomain(nome, ans);
        }


        public ICollection<Beneficiario> beneficiarios { get; set; }

        private void ValidateDomain(string nome, string ans)
        {
            DomainValidation.When(string.IsNullOrEmpty(nome), "Nome é obrigatório");

            DomainValidation.When(string.IsNullOrEmpty(ans), "Nome é obrigatório");


            DomainValidation.When(nome.Length < 5, 
                "Nome precisa de no minimo cinco caracteres");

            Nome = nome;
            ANS= ans;
        }
    }
}
