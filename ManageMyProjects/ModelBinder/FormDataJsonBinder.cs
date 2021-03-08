using ManageMyProjects.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageMyProjects.ModelBinder
{
    public class FormDataJsonBinder : IModelBinder
    {
        private readonly ManageMyProjectDbContext _db;

        public FormDataJsonBinder(ManageMyProjectDbContext db)
        {
            _db = db;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            string fieldName = bindingContext.FieldName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(fieldName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            else
            {
                bindingContext.ModelState.SetModelValue(fieldName, valueProviderResult);
            }

            string value = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            try
            {
                object result = JsonConvert.DeserializeObject(value, bindingContext.ModelType);
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("file" + e.ToString());
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}
