using System.Collections.Generic;
using Catalogs.API.Domain;

namespace Catalogs.API.Infrastructure.Persistence
{
    public class CatalogDb
    {
        public List<Catalog> Catalogs { get; private set; }

        public CatalogDb()
        {
            Catalogs = new List<Catalog>
            {
                new Catalog
                {
                    Id = 1,
                    Name = "Объекты строительства",
                    Attributes = new List<CatalogAttribute>
                    {
                        new CatalogAttribute
                        {
                            Id = 1,
                            Name = "Идентификатор",
                            DataType = CatalogAttributeDataType.Number
                        },
                        new CatalogAttribute
                        {
                            Id = 2,
                            Name = "Наименование",
                            DataType = CatalogAttributeDataType.Text
                        },
                        new CatalogAttribute
                        {
                            Id = 3,
                            Name = "Код объекта",
                            DataType = CatalogAttributeDataType.Text
                        },
                        new CatalogAttribute
                        {
                            Id = 4,
                            Name = "Бюджет, млн. руб",
                            DataType = CatalogAttributeDataType.Number
                        },
                    },
                    Elements = new List<CatalogElement>
                    {
                        new CatalogElement
                        {
                            Fields = new Dictionary<int, object>
                            {
                                { 1, "1" },
                                { 2, "Объект 1" },
                                { 3, "S-01" },
                                { 4, 100.25 }
                            }
                        },
                        new CatalogElement
                        {
                            Fields = new Dictionary<int, object>
                            {
                                { 1, "2" },
                                { 2, "Объект 2" },
                                { 3, "S-03" },
                                { 4, 150 }
                            }
                        },
                        new CatalogElement
                        {
                            Fields = new Dictionary<int, object>
                            {
                                { 1, "3" },
                                { 2, "Объект 3" },
                                { 3, "S-QWE" },
                                { 4, 99.678 }
                            }
                        }
                    }
                },
                new Catalog
                {
                    Id = 2,
                    Name = "«Версии данных",
                    Attributes = new List<CatalogAttribute>
                    {
                        new CatalogAttribute
                        {
                            Id = 1,
                            Name = "Идентификатор",
                            DataType = CatalogAttributeDataType.Number
                        },
                        new CatalogAttribute
                        {
                            Id = 2,
                            Name = "Наименование",
                            DataType = CatalogAttributeDataType.Text
                        },
                        new CatalogAttribute
                        {
                            Id = 3,
                            Name = "Тип версии",
                            DataType = CatalogAttributeDataType.Text
                        },
                    },
                    Elements = new List<CatalogElement>
                    {
                        new CatalogElement
                        {
                            Fields = new Dictionary<int, object>
                            {
                                { 1, "1" },
                                { 2, "Версия 1" },
                                { 3, "Основная" },
                            }
                        },
                        new CatalogElement
                        {
                            Fields = new Dictionary<int, object>
                            {
                                { 1, "2" },
                                { 2, "Версия 2" },
                                { 3, "Черновик" },
                            }
                        },
                        new CatalogElement
                        {
                            Fields = new Dictionary<int, object>
                            {
                                { 1, "3" },
                                { 2, "Версия 3" },
                                { 3, "Черновик" },
                            }
                        }
                    }
                }
            };
        }
    }
}
