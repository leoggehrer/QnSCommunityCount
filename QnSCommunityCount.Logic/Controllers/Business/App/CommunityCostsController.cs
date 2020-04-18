using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonBase.Extensions;
using QnSCommunityCount.Contracts.Business.App;
using QnSCommunityCount.Logic.Controllers.Persistence.App;
using QnSCommunityCount.Logic.Entities.Business.App;
using QnSCommunityCount.Logic.Entities.Persistence.App;

namespace QnSCommunityCount.Logic.Controllers.Business.App
{
    partial class CommunityCostsController
    {
        private CostCollectionController costCollectionController;
        private CostRecordController costRecordController;

        partial void Constructed()
        {
            costCollectionController = new CostCollectionController(this);
            costRecordController = new CostRecordController(this);
            ChangedSessionToken += CommunityCostsController_ChangedSessionToken;
        }

        private void CommunityCostsController_ChangedSessionToken(object sender, EventArgs e)
        {
            costCollectionController.SessionToken = SessionToken;
            costRecordController.SessionToken = SessionToken;
        }

        public override int MaxPageSize => costCollectionController.MaxPageSize;
        public override Task<int> CountAsync()
        {
            return costCollectionController.CountAsync();
        }
        public override Task<ICommunityCosts> CreateAsync()
        {
            return Task.Run<ICommunityCosts>(() => new CommunityCosts());
        }

        public override async Task<ICommunityCosts> GetByIdAsync(int id)
        {
            var result = default(CommunityCosts);
            var costCollection = await costCollectionController.GetByIdAsync(id).ConfigureAwait(false);

            if (costCollection != null)
            {
                result = new CommunityCosts();
                result.CostCollectionEntity.CopyProperties(costCollection);
                await LoadCostRecordsAsync(result).ConfigureAwait(false);
            }
            else
            {
                throw new Exception("Entity can't find!");
            }
            return result;
        }
        private async Task LoadCostRecordsAsync(CommunityCosts communityCosts)
        {
            communityCosts.CostRecordEntities.Clear();

            foreach (var item in await costRecordController.ExecuteQueryAllAsync(e => e.CostCollectionId == communityCosts.Id))
            {
                var costRecord = new CostRecord();

                costRecord.CopyProperties(item);
                communityCosts.CostRecordEntities.Add(costRecord);
            }
        }
        public override async Task<IQueryable<ICommunityCosts>> GetPageListAsync(int pageIndex, int pageSize)
        {
            var result = new List<CommunityCosts>();

            foreach (var item in await costCollectionController.GetPageListAsync(pageIndex, pageSize).ConfigureAwait(false))
            {
                var communityCosts = new CommunityCosts();

                communityCosts.CostCollectionEntity.CopyProperties(item);
                await LoadCostRecordsAsync(communityCosts).ConfigureAwait(false);
                result.Add(communityCosts);
            }
            return result.AsQueryable();
        }
        public override async Task<IQueryable<ICommunityCosts>> GetAllAsync()
        {
            var result = new List<CommunityCosts>();

            foreach (var item in await costCollectionController.GetAllAsync().ConfigureAwait(false))
            {
                var communityCosts = new CommunityCosts();

                communityCosts.CostCollectionEntity.CopyProperties(item);
                await LoadCostRecordsAsync(communityCosts).ConfigureAwait(false);
                result.Add(communityCosts);
            }
            return result.AsQueryable();
        }

        public override async Task<IQueryable<ICommunityCosts>> QueryPageListAsync(string predicate, int pageIndex, int pageSize)
        {
            var result = new List<CommunityCosts>();

            foreach (var item in await costCollectionController.QueryPageListAsync(predicate, pageIndex, pageSize).ConfigureAwait(false))
            {
                var communityCosts = new CommunityCosts();

                communityCosts.CostCollectionEntity.CopyProperties(item);
                await LoadCostRecordsAsync(communityCosts).ConfigureAwait(false);
                result.Add(communityCosts);
            }
            return result.AsQueryable();
        }
        public override async Task<IQueryable<ICommunityCosts>> QueryAllAsync(string predicate)
        {
            var result = new List<CommunityCosts>();

            foreach (var item in await costCollectionController.QueryAllAsync(predicate).ConfigureAwait(false))
            {
                var communityCosts = new CommunityCosts();

                communityCosts.CostCollectionEntity.CopyProperties(item);
                await LoadCostRecordsAsync(communityCosts).ConfigureAwait(false);
                result.Add(communityCosts);
            }
            return result.AsQueryable();
        }

        public override async Task<ICommunityCosts> InsertAsync(ICommunityCosts entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.CostCollection.CheckArgument(nameof(entity.CostCollection));
            entity.CostRecords.CheckArgument(nameof(entity.CostRecords));

            var result = new CommunityCosts();

            result.CostCollectionEntity.CopyProperties(entity.CostCollection);
            await costCollectionController.InsertAsync(result.CostCollectionEntity);

            foreach (var item in entity.CostRecords)
            {
                var costRecord = new CostRecord();

                costRecord.CopyProperties(item);
                costRecord.CostCollection = result.CostCollectionEntity;

                await costRecordController.InsertAsync(costRecord).ConfigureAwait(false);
                result.CostRecordEntities.Add(costRecord);
            }
            return result;
        }
        public override async Task<ICommunityCosts> UpdateAsync(ICommunityCosts entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.CostCollection.CheckArgument(nameof(entity.CostCollection));
            entity.CostRecords.CheckArgument(nameof(entity.CostRecords));

            //Delete all costs that are no longer included in the list.
            foreach (var item in await costRecordController.ExecuteQueryAllAsync(e => e.CostCollectionId == entity.CostCollection.Id).ConfigureAwait(false))
            {
                var tmpExpense = entity.CostRecords.SingleOrDefault(i => i.Id == item.Id);

                if (tmpExpense == null)
                {
                    await costRecordController.DeleteAsync(item.Id).ConfigureAwait(false);
                }
            }

            var result = new CommunityCosts();
            var costCollection = await costCollectionController.UpdateAsync(entity.CostCollection).ConfigureAwait(false);

            result.CostCollection.CopyProperties(costCollection);
            foreach (var item in entity.CostRecords)
            {
                if (item.Id == 0)
                {
                    item.CostCollectionId = entity.CostCollection.Id;
                    var insEntity = await costRecordController.InsertAsync(item).ConfigureAwait(false);

                    item.CopyProperties(insEntity);
                }
                else
                {
                    var updEntity = await costRecordController.UpdateAsync(item).ConfigureAwait(false);

                    item.CopyProperties(updEntity);
                }
            }
            return result;
        }
        public override async Task DeleteAsync(int id)
        {
            var deleteItem = await GetByIdAsync(id);

            if (deleteItem != null)
            {
                foreach (var item in deleteItem.CostRecords)
                {
                    await costRecordController.DeleteAsync(item.Id).ConfigureAwait(false);
                }
                await costCollectionController.DeleteAsync(deleteItem.Id).ConfigureAwait(false);
            }
            else
            {
                throw new Exception("Item not found!");
            }
        }

        public override Task SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            costCollectionController.Dispose();
            costRecordController.Dispose();

            costCollectionController = null;
            costRecordController = null;
        }
    }
}
