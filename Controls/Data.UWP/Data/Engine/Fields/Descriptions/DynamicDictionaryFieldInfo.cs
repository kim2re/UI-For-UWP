using System;
using System.Dynamic;
using System.Runtime.CompilerServices;
using Microsoft.CSharp.RuntimeBinder;
using System.Collections.Generic;

namespace Telerik.Data.Core.Fields
{
    internal class DynamicDictionaryFieldInfo : IDataFieldInfo, IMemberAccess
    {
        private string name;
        private Type dataType;

        public DynamicDictionaryFieldInfo(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public Type DataType
        {
            get
            {
                return this.dataType;
            }
        }

        public FieldRole Role
        {
            get;
            set;
        }

        public string DisplayName
        {
            get
            {
                return this.name;
            }
        }

        public object GetValue(object item)
        {
            if (item is IDictionary<string, object> dictionary )
            {
                var value = dictionary[name];

                if (this.dataType == null && value != null)
                {
                    this.dataType = value.GetType();
                }

                return value;
            }

            return null;
        }

        public void SetValue(object item, object fieldValue) 
        {
            if (item is IDictionary<string, object> dictionary) 
            {
                dictionary[name] = fieldValue;
            }
        }

        public bool Equals(IDataFieldInfo info)
        {
            return false;
        }
    }
}
