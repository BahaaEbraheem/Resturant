using Resturant;
using ITLand.CMMS.Libs.DevExtreme;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DevExtreme.AspNet.Data;

namespace ITLand.CMMS.Libs.DevExtreme
{
    partial class DataSourceLoadContext
    {
        readonly ResturantBaseListInputDto _options;
        readonly QueryProviderInfo _providerInfo;
        readonly Type _itemType;

        public DataSourceLoadContext(ResturantBaseListInputDto options, QueryProviderInfo providerInfo, Type itemType)
        {
            _options = options;
            _providerInfo = providerInfo;
            _itemType = itemType;
        }

        public bool GuardNulls
        {
            get
            {
                return _providerInfo.IsLinqToObjects;
            }
        }

        static bool IsEmptyList(IList list)
        {
            return list == null || list.Count < 1;
        }
    }

    // Filter
    partial class DataSourceLoadContext
    {
        public IList Filter => _options.FilterExpr;
        public bool HasFilter => !IsEmptyList(_options.FilterExpr);
        public bool UseStringToLower => DataSourceLoadOptionsBase.StringToLowerDefault ?? _providerInfo.IsLinqToObjects;
    }


}
