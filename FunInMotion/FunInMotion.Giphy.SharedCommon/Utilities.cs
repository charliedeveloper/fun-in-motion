using FunInMotion.Gif.SharedCommon.Enums;
using System;
using System.Data.Entity;
using System.Text;

namespace FunInMotion.Gif.SharedCommon
{
    public static class Utilities
    {
        private static EntityState ConverState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Unchanged:
                    return EntityState.Unchanged;
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        public static void FixState(this DbContext context)
        {
            foreach(var entry in context.ChangeTracker.Entries<IStateObject>())
            {
                IStateObject stateInfo = entry.Entity;
                entry.State = ConverState(stateInfo.State);
            }
        }

        public static string ToHash(this string value)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}
