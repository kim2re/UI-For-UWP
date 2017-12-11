using System;
using System.Collections.Generic;
using System.Reflection;

namespace Telerik.Data.Core.Fields
{
    /// <summary>
    /// An <see cref="IDataFieldInfo"/> that uses <see cref="Func{Object, Object}"/> for property access.
    /// </summary>
    internal class TypedDictionaryFieldInfo : IDataFieldInfo, IMemberAccess
    {
        readonly string _name;
        readonly Type _dataType;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyInfoFieldInfo"/> class.
        /// </summary>
        /// <param name="propertyInfo">The property info.</param>
        public TypedDictionaryFieldInfo(string name, Type dataType)
        {
            _name = name;
            _dataType = dataType;
        }
        
        /// <inheritdoc />
        public string DisplayName
        {
            get
            {
                return _name;
            }
        }

        /// <inheritdoc />
        public Type DataType
        {
            get
            {
                return _dataType;
            }
        }

        /// <inheritdoc />
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <inheritdoc />
        public FieldRole Role
        {
            get;
            set;
        }

        /// <inheritdoc />
        public object GetValue(object item)
        {
            if(item is IDictionary<string, object> dictionary) 
            {
                return dictionary[_name];
            }
            return null;
        }

        /// <inheritdoc />
        public void SetValue(object item, object fieldValue)
        {
            if (item is IDictionary<string, object> dictionary) 
            {
                dictionary[_name] = fieldValue;
            }
        }

        public bool Equals(IDataFieldInfo info)
        {
            var propertyField = info as TypedDictionaryFieldInfo;
            if (propertyField == null)
            {
                return false;
            }

            return string.Compare(_name, propertyField._name, StringComparison.OrdinalIgnoreCase) == 0 &&
                _dataType.Equals(propertyField._dataType);
        }
    }
}