﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyDemo.Models
{
    public class MongoEntity
    {
        public ObjectId Id { get; set; }
    }
}
