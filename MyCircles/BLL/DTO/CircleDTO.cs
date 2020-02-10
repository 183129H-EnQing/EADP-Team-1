using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCircles.BLL.DTO
{
    public class CircleDTO
    {
        public string Id { get; set; }
        public List<PostDTO> Posts { get; set; }
        public bool IsCircle { get; set; } = true;
    }
}