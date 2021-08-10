using System;
using System.Collections.Generic;

#nullable disable

namespace DataService.Models.Entities
{
    public partial class Sound
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Liked { get; set; }
        public string SoundUrl { get; set; }
    }
}
