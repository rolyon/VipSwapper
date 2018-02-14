﻿//----------------------------------------------------------------------------------------------
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//----------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrainingPoint.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public string OrganizationId { get; set; }
        public string CreatedBy { get; set; }
        [NotMapped]
        public string CreatedByDisplay 
        {
            get {
                if (CreatedBy == null) return null;
                else return TrainingPoint.GraphUtil.LookupDisplayNameOfAADObject(CreatedBy).Result;
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection <AccessControlEntry> SharedWith { get; set; }

        public Training() { SharedWith = new List<AccessControlEntry>(); }
    }
}