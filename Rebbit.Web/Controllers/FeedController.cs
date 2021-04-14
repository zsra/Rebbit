using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Rebbit.Core.Entities.Base;
using Rebbit.Core.Interfaces.Services;
using Rebbit.Infrastructure.Identity;
using Rebbit.Web.Converters;
using Rebbit.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rebbit.Web.Controllers
{
    public class FeedController : Controller
    {
        private readonly IFeedService _feedService;

        public FeedController(IFeedService feedService)
        {
            _feedService = feedService;
        }

        public async Task<IActionResult> Index()
        {
            var store = new UserStore<ApplicationUser>(new AppIdentityDbContext());
            var userManager = new UserManager<ApplicationUser>(store);
            ApplicationUser user = userManager.FindByNameAsync(User.Identity.Name).Result;
            FeedViewModel viewModel = FeedConverter.EntityToViewModel( await _feedService.GetFollowedGroups(user.Id) );
            return View(viewModel);
        }
    }
}
