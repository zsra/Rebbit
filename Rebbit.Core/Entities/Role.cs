using Rebbit.Core.Entities.Base;
using Rebbit.Core.Extensions;
using System.Collections.Generic;

namespace Rebbit.Core.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }
        public string Permissions { get; set; }

        public IEnumerable<string> GetPermissions() => Permissions.FromJson<IEnumerable<string>>();
        public void AddModeratorId(int id) => Permissions = $"{Permissions};{id}";
    }
}
