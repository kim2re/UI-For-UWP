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
        private CallSite<Func<CallSite, object, object>> callSite;

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
            if (item is IDictionary<string, object> dynamicObject )
            {
                var value = this.callSite.Target(this.callSite, item);

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
            throw new NotImplementedException();
        }

        public bool Equals(IDataFieldInfo info)
        {
            return false;
        }
    }
}
