//@QnSCodeCopy
//MdStart
using System;

namespace QnSCommunityCount.Logic.Modules.Security
{
    [AttributeUsage(AttributeTargets.Method)]
    internal partial class AllowAnonymousAttribute : AuthorizeAttribute
    {
        public AllowAnonymousAttribute()
            : base(false)
        {

        }
    }
}
//MdEnd
