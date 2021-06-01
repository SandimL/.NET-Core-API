using FluentValidation;
using Hahn.ApplicatonProcess.February2021.Domain.Models.Assets;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Domain.Validators
{
    public class AssetValidator : AbstractValidator<Asset>, IValidator<Asset>
    {
        public AssetValidator()
        {
            RuleFor(Asset => Asset.AssetName).MinimumLength(5).WithMessage("Name has minimum caracthers lenght required(5)");
            RuleFor(Asset => Asset.Department).IsInEnum().WithMessage("Departament not exists");
            RuleFor(Asset => Asset.PurchaseDate).Must(NotBeOlderThenOneYear).WithMessage("Purchase date must be less than one year");
            RuleFor(Asset => Asset.EMailAdressOfDepartment).Must(BeValidEmail).WithMessage("Email is not valid");
            RuleFor(Asset => Asset.broken).NotNull().WithMessage("Broken cannot be null");
        }

        private bool NotBeOlderThenOneYear(DateTime purchaseDate)
        {
            DateTime today = DateTime.Now;
            int daysCount = today.Subtract(purchaseDate).Days;
            return daysCount <= 365;
        }

        private bool BeValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
    }
}
