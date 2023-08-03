using FluentValidation;
using gunesekremcom.Tools.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace gunesekremcom.Tools.Helpers
{
    public static class ValidationHelper
    {


        public class ValidationError
        {
            public string PropertyName { get; set; }
            public string ErrorMessage { get; set; }
        }
        public class ValidationResult<TModel>
        {
            public ValidationStatus Status { get; set; }
            public TModel Model { get; set; }
            public List<ValidationError> Errors { get; set; }

            public ValidationResult(ValidationStatus status, TModel model)
            {
                Status = status;
                Model = model;
                Errors = new List<ValidationError>();
            }
        }
        public static ValidationResult<TModel> ValidateAndHandleErrors<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult<TModel> validationResult = new ValidationResult<TModel>(ValidationStatus.Failure, model);
            var result = validator.Validate(model);

            if (result.IsValid)
            {
                validationResult.Status = ValidationStatus.Success;
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    validationResult.Errors.Add(new ValidationError
                    {
                        PropertyName = error.PropertyName,
                        ErrorMessage = error.ErrorMessage
                    });
                }
            }

            return validationResult;
        }

        public static void AddModelErrorsToModelState<TModel>(ModelStateDictionary modelState, ValidationResult<TModel> validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
