using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model = QnSCommunityCount.AspMvc.Models.Business.App.CommunityCosts;
using Contract = QnSCommunityCount.Contracts.Business.App.ICommunityCosts;

namespace QnSCommunityCount.AspMvc.Controllers
{
    public partial class CommunityCostsController : AccessController
    {
        private readonly ILogger<IdentityController> _logger;
        public CommunityCostsController(ILogger<IdentityController> logger, IFactoryWrapper factoryWrapper) : base(factoryWrapper)
        {
            Constructing();
            _logger = logger;
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();

        [ActionName("Index")]
        public async Task<IActionResult> IndexAsync()
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entities = await ctrl.GetAllAsync().ConfigureAwait(false);

            return View(entities.Select(e => ConvertTo<Model, Contract>(e)));
        }
        [ActionName("Create")]
        public async Task<IActionResult> CreateAsync()
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.CreateAsync().ConfigureAwait(false);

            entity.CostCollection.Currency = "EUR";
            entity.CostCollection.Category = "Reise";
            return View(ConvertTo<Model, Contract>(entity));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public async Task<IActionResult> CreateAsync(Model model)
        {
            if (ModelState.IsValid == false)
            {
                model.ActionError = GetModelStateError();
                return View(model);
            }
            try
            {
                using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);

                await ctrl.InsertAsync(model).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                model.ActionError = GetExceptionError(ex);
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync(int id)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);

            return View(ConvertTo<Model, Contract>(entity));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> EditAsync(int id, Model model)
        {
            if (ModelState.IsValid == false)
            {
                model.ActionError = GetModelStateError();
                return View(model);
            }
            try
            {
                using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
                var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);

                entity.CostCollection.CopyProperties(model.CostCollection);
                await ctrl.UpdateAsync(entity).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                model.ActionError = GetExceptionError(ex);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAsync(int id, string error = null)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var model = ConvertTo<Model, Contract>(entity);

            model.ActionError = error;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteAsync(int id, Model model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Delete", new { id, error = GetModelStateError() });
            }
            try
            {
                using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);

                await ctrl.DeleteAsync(id).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Delete", new { id, error = GetExceptionError(ex) });
            }
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);

            return View(entity != null ? ConvertTo<Model, Contract>(entity) : entity);
        }

        [ActionName("CreateCostRecord")]
        public async Task<IActionResult> CreateCostRecordAsync(int id, string error = null)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var costRecord = new Models.Persistence.App.CostRecord();

            costRecord.ActionError = error;
            costRecord.CommunityCosts = entity;
            costRecord.CopyProperties(entity.CreateCostRecord());
            costRecord.CostCollectionId = entity.Id;
            
            return View("EditCostRecord", costRecord);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CreateCostRecord")]
        public async Task<IActionResult> CreateCostRecordAsync(Models.Persistence.App.CostRecord model)
        {
            int id = model.CostCollectionId;

            if (ModelState.IsValid == false)
            {
                return RedirectToAction("CreateCostRecord", new { id, error = GetModelStateError() });
            }
            try
            {
                using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
                var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
                var costRecord = entity.CreateCostRecord();

                costRecord.CopyProperties(model);
                entity.AddCostRecord(costRecord);
                await ctrl.UpdateAsync(entity).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return RedirectToAction("CreateCostRecord", new { id, error = GetExceptionError(ex) });
            }
            return RedirectToAction("Edit", new { id });
        }

        [ActionName("EditCostRecord")]
        public async Task<IActionResult> EditCostRecordAsync(int id, int detailId, string error = null)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var detail = entity.CostRecords.SingleOrDefault(i => i.Id == detailId);
            var costRecord = new Models.Persistence.App.CostRecord();

            costRecord.ActionError = error;
            costRecord.CommunityCosts = entity;
            costRecord.CopyProperties(detail);
            costRecord.CostCollectionId = entity.Id;

            return View(costRecord);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditCostRecord")]
        public async Task<IActionResult> EditCostRecordAsync(Models.Persistence.App.CostRecord model)
        {
            int id = model.CostCollectionId;

            if (ModelState.IsValid == false)
            {
                return RedirectToAction("EditCostRecord", new { id, error = GetModelStateError() });
            }
            try
            {
                using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
                var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);

                entity.UpdateCostRecord(model);
                await ctrl.UpdateAsync(entity).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return RedirectToAction("EditCostRecord", new { id, error = GetExceptionError(ex) });
            }
            return RedirectToAction("Edit", new { id });
        }

        [ActionName("DeleteCostRecord")]
        public async Task<IActionResult> DeleteCostRecordAsync(int id, int detailId, string error = null)
        {
            using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
            var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);
            var detail = entity.CostRecords.SingleOrDefault(i => i.Id == detailId);
            var costRecord = new Models.Persistence.App.CostRecord();

            costRecord.ActionError = error;
            costRecord.CommunityCosts = entity;
            costRecord.CopyProperties(detail);
            costRecord.CostCollectionId = entity.Id;

            return View(costRecord);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteCostRecord")]
        public async Task<IActionResult> DeleteCostRecordAsync(Models.Persistence.App.CostRecord model)
        {
            int id = model.CostCollectionId;

            if (ModelState.IsValid == false)
            {
                return RedirectToAction("DeleteCostRecord", new { id, error = GetModelStateError() });
            }
            try
            {
                using var ctrl = Factory.Create<Contract>(SessionWrapper.SessionToken);
                var entity = await ctrl.GetByIdAsync(id).ConfigureAwait(false);

                entity.RemoveCostRecord(model);
                await ctrl.UpdateAsync(entity).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return RedirectToAction("DeleteCostRecord", new { id, error = GetExceptionError(ex) });
            }
            return RedirectToAction("Edit", new { id });
        }
    }
}