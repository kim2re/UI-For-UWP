using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Telerik.Data.Core.Fields
{
    internal class DynamicDictionaryFieldInfoDescriptionsProvider : IFieldInfoExtractor
    {
        private IDictionary<string,object> firstItem;

        public DynamicDictionaryFieldInfoDescriptionsProvider(IDictionary<string, object> dictionary)
        {
            this.firstItem = dictionary;
        }

        public bool IsInitialized
        {
            get
            {
                return this.firstItem != null;
            }
        }

        public bool IsDynamic
        {
            get
            {
                return true;
            }
        }

        public IEnumerable<IDataFieldInfo> GetDescriptions()
        {
            List<IDataFieldInfo> infos = new List<IDataFieldInfo>();

            if (this.firstItem != null)
            {
                foreach (var name in this.firstItem.Keys)
                {
                    var info = new DynamicDictionaryFieldInfo(name);

                    // the GetValue call will update the DataType member of the filed
                    info.GetValue(this.firstItem);

                    infos.Add(info);
                }
            }

            return infos;
        }
    }
}