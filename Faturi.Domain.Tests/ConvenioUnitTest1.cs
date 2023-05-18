using Faturi.Domain.Entities;
using Faturi.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace Faturi.Domain.Tests
{
    public class ConvenioUnitTest1
    {
        [Fact]

        public void CreateConvenio_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Convenio(1, "417661","Fisco Saúde");
            action.Should().NotThrow<DomainValidation>();
        }

        [Fact]
        public void CreateConvenio_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Convenio(-1, "417661", "Category Name ");
            action.Should()
                .Throw<DomainValidation>()
                 .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateConvenio_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Convenio(1, "417661", "Ca");
            action.Should()
                .Throw<DomainValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateConvenio_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Convenio(1, "417661", "");
            action.Should()
                .Throw<DomainValidation>()
                .WithMessage("Invalid name.Name is required");
        }

        [Fact]
        public void CreateConvenio_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Convenio(1, "417661", null);
            action.Should()
                .Throw<DomainValidation>();
        }
    }
}
