using PandemiC.Web.Repo;
using PandemiC.Web.Client.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PandemiC.Web.Attribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RegExEMAILIfFilled : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null) value = "";

            string val = (string)value;
            Regex rx = new Regex(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+");
            if (rx.IsMatch(val) || (val.Trim()) == "")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
    public class RegExEMAIL : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null) value = "";

            string val = (string)value;
            Regex rx = new Regex(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+");
            if (rx.IsMatch(val) && val is not null)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }

    public class RegExPasswd : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string val = (string)value;
            Regex rx = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-=]).{7,50}$");

            if (rx.IsMatch(val) && (val is not null))
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }

    public class CheckEmailUnique : ValidationAttribute
    {
        private const string DefaultErrorMessageFormatString = "Email is is Already in Used";
        private readonly string _dependentProperties;
        public CheckEmailUnique(string dependentProperties)
        {
            _dependentProperties = dependentProperties;
            ErrorMessage = DefaultErrorMessageFormatString;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        { // Check into Database using the stored procedure the unicity of the EMAIL
            IUserService<User> userService = (IUserService<User>)validationContext.GetService(typeof(IUserService<User>));

            Object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            int index = type.GetProperty(_dependentProperties) is null ? 0 : (int)type.GetProperty(_dependentProperties).GetValue(instance, null);

            if (userService.EmailIsUsed(value.ToString(), index))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
    public class CheckNatRegNbrUnique : ValidationAttribute
    {
        private const string DefaultErrorMessageFormatString = "National Registry Number is is Already in Used";
        private readonly string _dependentProperties;
        public CheckNatRegNbrUnique(string dependentProperties)
        {
            _dependentProperties = dependentProperties;
            ErrorMessage = DefaultErrorMessageFormatString;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        { // Check into Database using the stored procedure the unicity of the NatRegNbr
            IUserService<User> userService = (IUserService<User>)validationContext.GetService(typeof(IUserService<User>));
            Object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            int index = type.GetProperty(_dependentProperties) is null ? 0 : (int)type.GetProperty(_dependentProperties).GetValue(instance, null);

            if (userService.NatRegNbrIsUsed(value.ToString(), index))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }

    public class CheckVATUnique : ValidationAttribute
    {
        private const string DefaultErrorMessageFormatString = "VAT Number is is Already in Used";
        private readonly string _dependentProperties;
        public CheckVATUnique(string dependentProperties)
        {
            _dependentProperties = dependentProperties;
            ErrorMessage = DefaultErrorMessageFormatString;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IRestaurantService<Restaurant> restoService = (IRestaurantService<Restaurant>)validationContext.GetService(typeof(IRestaurantService<Restaurant>));
            Object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            int index = type.GetProperty(_dependentProperties) is null ? 0 : (int)type.GetProperty(_dependentProperties).GetValue(instance, null);

            if (restoService.VATIsUsed(value.ToString(), index))
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
    }
}
