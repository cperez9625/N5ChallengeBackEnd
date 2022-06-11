using Microsoft.EntityFrameworkCore;
using N5.Data.Interfaces;
using N5.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.Data.Repositories
{
    public class PermissionRepository : ICRUDData<Permission>
    {
        private N5ChallengeContext _challengeContext;
        public PermissionRepository(N5ChallengeContext n5ChallengeContext)
        {
            _challengeContext = n5ChallengeContext;
        }
        public Permission CreateItem(Permission item)
        {
            _challengeContext.Permissions.Add(item);
            _challengeContext.SaveChanges();
            return item;
        }

        public Permission GetById(int id)
        {
            return _challengeContext.Permissions.FirstOrDefault(permission => permission.Id == id);
        }

        public List<Permission> ItemList()
        {
            return _challengeContext.Permissions
                .Include(permission => permission.PermissionTypeNavigation)
                .ToList();
        }

        public Permission UpdateItem(Permission item)
        {
            //var testie = _challengeContext.Permissions.AsNoTracking();
            //_challengeContext.Attach(item);
            //_challengeContext.Permissions.Remove(item);
            _challengeContext.ChangeTracker.Clear();
            _challengeContext.Permissions.Update(item);
            _challengeContext.SaveChanges();
            return item;
        }
    }
}
