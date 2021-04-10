using Rebbit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebbit.Web.ViewModels
{
    public class GroupViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfFollowers { get; set; }

        public List<Post> Posts { get; set; }
    }
}
