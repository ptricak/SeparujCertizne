using System;
using System.Collections.Generic;

namespace SeparujCertizne.Models
{
    public class SeparationDataModel
    {
        /// <summary>
        /// Collection of next separation terms.
        /// </summary>
        public IEnumerable<SeparationTermModel> SeparationTerms { get; set; }
    }
}