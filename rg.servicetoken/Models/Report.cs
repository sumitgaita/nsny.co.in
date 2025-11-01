using System.Collections.Generic;

namespace rg.service.Models
{
    public class ReportDTO
    {
        public string ResourcePath { get; set; }
        public List<DataSourceDto> DataSources { get; set; }
        public List<ParameterDTO> Parameters { get; set; }
        public string ReportDataSourceName { get; set; }
    }

    public class DataSourceDto
    {
        public string Name { get; set; }
        public string Data { get; set; }
    }

    public class ParameterDTO
    {
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
