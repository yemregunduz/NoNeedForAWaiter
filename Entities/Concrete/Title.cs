﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Title:IEntity
    {
        public int Id { get; set; }
        public string Title_ { get; set; }
    }
}