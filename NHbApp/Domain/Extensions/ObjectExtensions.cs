using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace NHbApp.Domain.ComponentModel.DataAnnotations
{
    public static class ObjectExtensions
    {
        public static bool IsValid(this object entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            bool isValid = true;
            WorkTheAttributes(entity, (validationAttribute, value, displayName) => isValid &= validationAttribute.IsValid(value));

            return isValid;
        }

        public static void Validate(this object entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            IList<ValidationException> validationExceptions = new List<ValidationException>();

            WorkTheAttributes(entity,
                (validationAttribute, value, displayName) =>
                {
                    try
                    {
                        validationAttribute.Validate(value, displayName);
                    }
                    catch (ValidationException validationException)
                    {
                        validationExceptions.Add(validationException);
                    }
                });

            if (validationExceptions.Count == 1)
                throw validationExceptions.First();

            if (validationExceptions.Count > 1)
                throw new AggregateException(validationExceptions);
        }

        private static void WorkTheAttributes(object entity, Action<ValidationAttribute, object, string> work)
        {
            Type entityType = entity.GetType();

            // Validation attributes can be defined in a metadata type.

            Type metadataType = entityType;
            MetadataTypeAttribute metadataTypeAttribute = entityType.GetCustomAttributes(false).OfType<MetadataTypeAttribute>().FirstOrDefault();

            if (metadataTypeAttribute != null)
                metadataType = metadataTypeAttribute.MetadataClassType;

            // Go to work on the class validation attributes.
            foreach (ValidationAttribute validationAttribute in metadataType.GetCustomAttributes(true).OfType<ValidationAttribute>())
                work(validationAttribute, entity, GetDisplayName(metadataType));

            // Go to work on the property validation attributes.
            foreach (PropertyInfo metadataProperty in metadataType.GetProperties())
                foreach (ValidationAttribute validationAttribute in metadataProperty.GetCustomAttributes(true).OfType<ValidationAttribute>())
                {
                    PropertyInfo entityProperty = entityType.GetProperty(metadataProperty.Name);
                    work(validationAttribute, entityProperty.GetValue(entity, null), GetDisplayName(metadataProperty));
                }
        }

        private static string GetDisplayName(MemberInfo metadataMemberInfo)
        {
            DisplayNameAttribute displayNameAttribute = metadataMemberInfo.GetCustomAttributes(true).OfType<DisplayNameAttribute>().FirstOrDefault();

            if (displayNameAttribute != null)
                return displayNameAttribute.DisplayName;

            return metadataMemberInfo.Name;
        }
    }
}
