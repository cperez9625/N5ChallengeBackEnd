using N5.Data.Interfaces;
using N5.Shared;

namespace N5.Data.Repositories
{
    public class PermissionTypeRepository : ICRUDData<PermissionType>
    {
        private N5ChallengeContext _challengeContext;

        public PermissionTypeRepository(N5ChallengeContext n5ChallengeContext)
        {
            _challengeContext = n5ChallengeContext;
        }

        public PermissionType CreatePermissionType(PermissionType permissionType)
        {
            _challengeContext.PermissionTypes.Add(permissionType);
            _challengeContext.SaveChanges();
            return permissionType;

        }

        public PermissionType CreateItem(PermissionType item)
        {
            _challengeContext.PermissionTypes.Add(item);
            _challengeContext.SaveChanges();
            return item;
        }

        public PermissionType GetById(int id)
        {
            return _challengeContext.PermissionTypes.FirstOrDefault(permissionType => permissionType.Id == id);
        }

        public List<PermissionType> ItemList()
        {
            return _challengeContext.PermissionTypes.ToList();
        }

        public PermissionType UpdateItem(PermissionType item)
        {
            _challengeContext.PermissionTypes.Update(item);
            _challengeContext.SaveChanges();
            return item;
        }
    }
}
