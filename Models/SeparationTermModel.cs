using System;

namespace SeparujCertizne.Models
{
    public class SeparationTermModel
    {
        /// <summary>
        /// Garbage type - Paper, Plastic etc.
        /// </summary>
        public string GarbageType { get; set; }

        /// <summary>
        /// Garbage type - Paper, Plastic etc.
        /// </summary>
        public string GarbageTypeString
        {
            get
            {
                return GarbageType switch
                {
                    "JedleOleje" => "Jedlé oleje<br/>a tuky",
                    "Plasty" => "Zmiešané plasty<br/>a PET fľaše",
                    "Papier" => "Papier<br/>a TETRA PACK",
                    "Sklo" => "Sklo<br/>a sklenené obaly",
                    "Elektro" => "Elektro<br/>a kovové obaly",
                    "NebezpecnyOdpad" => "Nebezpečný<br/>odpad",
                    _ => "Iný odpad",
                };
            }
        }

        /// <summary>
        /// Garbage picking date (time part not important).
        /// </summary>
        public DateTime GarbagePickingDate { get; set; }

        /// <summary>
        /// Garbage type color for Paper, Plastic etc.
        /// </summary>
        public string GarbageTypeColor
        {
            get
            {
                return GarbageType switch
                                {
                    "JedleOleje" => "#e67e22",
                    "Plasty" => "#f1c40f",
                    "Papier" => "#2980b9",
                    "Sklo" => "#27ae60",
                    "Elektro" => "#e74c3c",
                    "NebezpecnyOdpad" => "#34495e",
                    _ => "#fff",
                };
            }
        }
    }
}