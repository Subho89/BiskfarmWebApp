using Biskfarm.DAL;
using Biskfarm.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiskfarmWebApp.Components
{
    public class HeirarchyListViewComponent : ViewComponent
    {
        private readonly BiskfarmContext db;
        HierarchyServices services=new HierarchyServices();
        public HeirarchyListViewComponent(BiskfarmContext _db)
        {
            db= _db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var hierarchies = services.GetAllHierarchy(db);
            return View(hierarchies);
            //return View();
        }
    }
}
