using Catalogs.Client.Client;
using Data.Client.Client;
using Data.Client.Contracts;
using Reporting.API.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reporting.API.Application.CommandExecutors
{
    public class ReportingCommandExecutor
    {
        private readonly ICatalogClient _catalogClient;
        private readonly IDataClient _dataClient;

        public ReportingCommandExecutor(ICatalogClient catalogClient, IDataClient dataClient)
        {
            _catalogClient = catalogClient;
            _dataClient = dataClient;
        }

        public async Task<List<List<string>>> GenerateReport(
            CatalogMetadataPresentation rowCatalogRepresentation,
            CatalogMetadataPresentation columnCatalogRepresentation)
        {
            var rowCatalogMetadata = (await _catalogClient.GetCatalogMetadata(rowCatalogRepresentation.CatalogId)).Content;
            var columnCatalogMetadata = (await _catalogClient.GetCatalogMetadata(columnCatalogRepresentation.CatalogId)).Content;

            var firstCatalogElements = (await _catalogClient.GetCatalogElements(rowCatalogRepresentation.CatalogId)).Content;
            var secondCatalogElements = (await _catalogClient.GetCatalogElements(columnCatalogRepresentation.CatalogId)).Content;


            List<CatalogElementCrossDto> crossRequestDtos = 
                            firstCatalogElements
                            .SelectMany(el =>
                                secondCatalogElements.Select(el2 => new CatalogElementCrossDto
                                {
                                    FirstElement = new CatalogElement
                                    {
                                        // Trick, we assumpt that first is id
                                        // [TODO]: Should be done generally
                                        CatalogId = rowCatalogRepresentation.CatalogId,
                                        ElementId = Convert.ToInt32(el.Fields[rowCatalogMetadata.Attributes.First().Id])
                                    },
                                    SecondElement = new CatalogElement
                                    {
                                        CatalogId = columnCatalogRepresentation.CatalogId,
                                        ElementId = Convert.ToInt32(el2.Fields[columnCatalogMetadata.Attributes.First().Id])
                                    }
                                })).ToList();

            var crosses = (await _dataClient.GetCatalogElementCrosses(crossRequestDtos)).Content;

            var headers = rowCatalogMetadata
                            .Attributes
                            .Where(a => rowCatalogRepresentation.Attributes.Any(ar => ar.Id == a.Id))
                            .Select(a => new { a.Id, Name = "", IsFromColumn = false })
                            .OrderBy(a => rowCatalogRepresentation.Attributes.IndexOf(
                                            rowCatalogRepresentation.Attributes.First(attrRepr => a.Id == attrRepr.Id)))
                            .ToList();

            var selectedColumnCatalogAttributes = columnCatalogMetadata
                                                    .Attributes
                                                    .Where(a =>columnCatalogRepresentation.Attributes.Any(ar => ar.Id == a.Id))
                                                    .ToList();

            foreach (var element in secondCatalogElements)
            {
                foreach (var attribute in selectedColumnCatalogAttributes)
                {
                    // Form second catalog headers, where each header id represents relevant entry's id
                    headers.Add(new
                    {
                        Id = Convert.ToInt32(element.Fields[columnCatalogMetadata.Attributes.First().Id]),
                        Name = element.Fields[attribute.Id].ToString(),
                        IsFromColumn = true
                    });
                }
            }

            List<List<string>> table = new List<List<string>>();

            // Add headers as first row
            table.Add(headers.Select(h => h.Name).ToList());

            foreach (var firstCatalogElement in firstCatalogElements)
            {
                var firstCatalogElementId = Convert.ToInt32(firstCatalogElement.Fields[rowCatalogMetadata.Attributes.First().Id]);

                var firstCatalogHeaders = headers.Where(h => !h.IsFromColumn);

                // Form first catalog cells
                var rowData = firstCatalogHeaders.Select(h => firstCatalogElement.Fields[h.Id].ToString()).ToList();

                // Form second catalog cells
                var secondCatalogHeaders = headers.Where(h => h.IsFromColumn);

                foreach (var secondCatalogHeader in secondCatalogHeaders)
                {
                    var crossValue = crosses.FirstOrDefault(c => c.FirstElement.ElementId == firstCatalogElementId &&
                                                        c.SecondElement.ElementId == secondCatalogHeader.Id);

                    rowData.Add(crossValue?.Amount.ToString() ?? "-");
                }

                table.Add(rowData);
            }

            return table;
        }
    }
}
