﻿using System;
using System.Collections.Generic;

namespace Reader.Models
{
    public class Feed
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string Title { get; set; }
        public DateTime Added { get; set; }
        public DateTime LastChecked { get; set; }
        public ICollection<Item> Items { get; set; }
    }
}
