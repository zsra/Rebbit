using Rebbit.Core.Entities.Base;
using Rebbit.Core.Extensions;
using System;
using System.Collections.Generic;

namespace Rebbit.Core.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModeratorIds { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<User> Followers { get; set; }

        public IEnumerable<string> GetModeratorIds() => ModeratorIds.FromJson<IEnumerable<string>>();
        public void AddModeratorId(int id) => ModeratorIds = $"{ModeratorIds};{id}";
    }
}
