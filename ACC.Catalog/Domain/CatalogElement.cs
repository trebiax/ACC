﻿using System.Collections.Generic;

namespace Catalogs.API.Domain
{
    public class CatalogElement
    {
        /// <summary>
        /// Key of dictionary represents id of an attribute
        /// </summary>
        public Dictionary<int, object> Fields { get; internal set; }
    }
}
