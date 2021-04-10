using Rebbit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebbit.Web.ViewModels
{
    public class FeedViewModel
    {
        public Dictionary<int, string> Groups { get; set; } = new Dictionary<int, string>();
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}
