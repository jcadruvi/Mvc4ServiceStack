﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4.ServiceStack.Models
{
    public class StoreViewModel
    {
        public int RetailerId { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public int? Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? OrgLevelId { get; set; }
        public int? SubOrgLevelId { get; set; }
    }
}