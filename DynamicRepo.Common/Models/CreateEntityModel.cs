﻿using System.Collections.Generic;

namespace DynamicRepo.Common.Models
{
    public class CreateEntityModel
    {
        public List<EntityAttribute> AttributesCollection { get; set; }
        public string StoreGroupId { get; set; }
        public string EntityName { get; set; }
        public string EntityUID { get; set; }
        public string[] Constraints { get; set; }
    }
}