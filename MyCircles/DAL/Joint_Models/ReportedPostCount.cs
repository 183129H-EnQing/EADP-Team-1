using MyCircles.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.DAL.Joint_Models
{
    public class ReportedPostCount
    {
        public DateTime dateCreated { get; set; }
        public int reportsCount { get; set; }

        public ReportedPostCount(DateTime dateCreated, int reportsCount)
        {
            this.dateCreated = dateCreated;
            this.reportsCount = reportsCount;
        }
    }
}