﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class AddNewFamilyDto
    {
        public Guid FamilyId { get; set; }
        public string FamilyName { get; set; }
    }
}