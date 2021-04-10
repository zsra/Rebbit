using Rebbit.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Rebbit.Core.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string ProfilePictureUrl { get; set; }
        public DateTime JoinedAt { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Role Role { get; set; }
        public virtual IEnumerable<Group> FollowedGroups { get; set; }
        public virtual IEnumerable<Post> CreatedPosts { get; set; }
        public virtual IEnumerable<Comment> CreatedComments { get; set; }
    }
}
