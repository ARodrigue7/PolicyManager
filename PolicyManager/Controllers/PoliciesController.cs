using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PolicyManager.Data;
using PolicyManager.Models;
using PolicyManager.Models.Domain;

namespace PolicyManager.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly PoliciesDbContext policiesDbContext;

        public PoliciesController(PoliciesDbContext policiesDbContext)
        {
            this.policiesDbContext = policiesDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var policies = await policiesDbContext.Policies.ToListAsync();
            return View(policies);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPolicyViewModel addPolicyRequest)
        {
            var policy = new Policies()
            {
                Id = Guid.NewGuid(),
                Name = addPolicyRequest.Name,
                Description = addPolicyRequest.Description,
                Premium = addPolicyRequest.Premium
            };

            await policiesDbContext.Policies.AddAsync(policy);
            await policiesDbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var policy = await policiesDbContext.Policies.FirstOrDefaultAsync(x => x.Id == id);

            if (policy != null)
            {
                var viewModel = new UpdatePolicyViewModel()
                {
                    Id = policy.Id,
                    Name = policy.Name,
                    Description = policy.Description,
                    Premium = policy.Premium
                };

                return await Task.Run(() => View("View", viewModel));
            }



            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdatePolicyViewModel model)
        {
            var policies = await policiesDbContext.Policies.FindAsync(model.Id);

            if (policies != null)
            {
                policies.Name = model.Name;
                policies.Description = model.Description;
                policies.Premium = model.Premium;

                await policiesDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdatePolicyViewModel model)
        {
            var policies = await policiesDbContext.Policies.FindAsync(model.Id);

            if (policies != null)
            {
                policiesDbContext.Policies.Remove(policies);
                await policiesDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
