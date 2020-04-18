using QnSCommunityCount.Logic.Entities.Persistence.App;
using System;
using System.Threading.Tasks;

namespace QnSCommunityCount.Logic.Controllers.Persistence.App
{
    partial class CostRecordController
    {
        protected override Task BeforeInsertingAsync(CostRecord entity)
        {
            entity.Date = DateTime.Now;

            return base.BeforeInsertingAsync(entity);
        }
    }
}
