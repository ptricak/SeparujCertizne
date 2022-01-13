using System;
using TinyCsvParser.Mapping;

namespace SeparujCertizne.Mappers
{
    public class SeparationDataMapping : CsvMapping<Models.SeparationTermModel>
    {
        public SeparationDataMapping() : base()
        {
            MapProperty(0, p => p.GarbageType);
            MapProperty(1, p => p.GarbagePickingDate);
        }
    }
}
