using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Telerik.Core;

namespace Telerik.Data.Core.Fields
{
    /// <summary>
    /// An <see cref="IFieldInfoExtractor"/> for <see cref="IEnumerable"/> source.
    /// </summary>
    internal class TypedDictionaryFieldDescriptionsInfoProvider : IFieldInfoExtractor
    {
        IDictionary<string, Type> _propertyInfos;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableFieldDescriptionsExtractor"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public TypedDictionaryFieldDescriptionsInfoProvider(IDictionary<string,Type> propertyInfos)
        {
            if (propertyInfos == null)
            {
                throw new ArgumentNullException(nameof(propertyInfos));
            }

            this._propertyInfos = propertyInfos;
        }

        public bool IsInitialized
        {
            get
            {
                return true;
            }
        }

        public bool IsDynamic
        {
            get
            {
                return false;
            }
        }

        /// <inheritdoc />
        public IEnumerable<IDataFieldInfo> GetDescriptions()
        {
            var retVal = new List<IDataFieldInfo>();

            foreach (var key in _propertyInfos.Keys) 
            {
                retVal.Add(new TypedDictionaryFieldInfo(key, _propertyInfos[key]));
            }

            return retVal;
        }        
    }
}