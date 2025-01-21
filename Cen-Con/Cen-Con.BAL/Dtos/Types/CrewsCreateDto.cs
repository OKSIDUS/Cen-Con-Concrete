﻿namespace Cen_Con.BAL.Dtos.Types
{
    public class CrewsCreateDto
    {
        public string CrewName { get; set; }
        public JobTypes JobType { get; set; }
        public decimal PricePerCubicMeter { get; set; }

        public enum JobTypes { Commercial, Residential }
    }
}
