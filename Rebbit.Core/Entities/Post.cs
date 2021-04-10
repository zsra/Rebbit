using Rebbit.Core.Entities.Base;
using Rebbit.Core.ValueObject;
using System;
using System.Collections.Generic;

namespace Rebbit.Core.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public RatingInfo RatingInfo { get; set; }
        public EditedInfo EditedInfo { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual User Creator { get; set; }

    }
}
