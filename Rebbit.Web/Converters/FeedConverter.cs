using Rebbit.Core.Entities;
using Rebbit.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebbit.Web.Converters
{
    public static class FeedConverter
    {
        public static FeedViewModel EntityToViewModel(IDictionary<int, string> followedGroups, IEnumerable<Post> posts) => new FeedViewModel
        {
            Groups = new Dictionary<int, string>(followedGroups),
            Posts = new List<Post>(posts)
        };
    }
}
