using System;
using System.Collections.Generic;

namespace BlazorFluentCMS.Core
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
        public List<int> RelatedArticleIds { get; set; } = new List<int>();
        public List<int> MenuIds { get; set; } = new List<int>();
    }
}
