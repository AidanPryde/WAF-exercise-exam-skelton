using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using DB.Models;
using WA.Models;
using WA.Services;

namespace WA.Controllers
{
    public class HomeController : ControllerBase
    {
        public HomeController(IMyService myService) : base(myService)
        {
        }

        public IActionResult Index(Int32? paging, Boolean? order, SearchViewModel searchViewModel)
        {
            IEnumerable<Table3> table3s;

            if (searchViewModel.Column1 > 0)
            {
                table3s = _myService.NarrowTable3sByColumn1(searchViewModel.Column1);
            }
            else
            {
                table3s = _myService.Table3sWithAll;
            }

            Int32 table3Count = table3s.Count();
            Int32 currentPaging = paging ?? 0;
            Boolean currentOrder = order ?? false;
            Int32 pagingSize = 20;

            if (currentPaging * pagingSize > table3Count - 1)
            {
                currentPaging = (table3Count / pagingSize);
            }

            List<Int32[]> pagingTab = CalculatePaging(table3Count);

            if (currentOrder)
            {
                table3s = table3s.OrderBy(t3 => t3.Id);
            }
            else
            {
                table3s = table3s.OrderByDescending(t3 => t3.Id);
            }

            table3s = _myService.NarrowTable3sSelection(table3s, currentPaging * pagingSize, pagingSize);

            ViewBag.PagingTab = pagingTab;
            ViewBag.Order = currentOrder;
            ViewBag.Table3s = table3s.ToList();

            return View("Index", searchViewModel);
        }

        public IActionResult Details(Int32? table3Id)
        {
            Int32 currentTable3Id = table3Id ?? 0;

            if (currentTable3Id == 0)
            {
                return RedirectToAction(nameof(HomeController.Index));
            }

            Table3 table3 = _myService.GetTable3ByTable3Id(currentTable3Id);

            if (table3 == null)
            {
                return RedirectToAction(nameof(HomeController.Index));
            }

            return View("Details", table3);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Int32[]> CalculatePaging(Int32 total, Int32 pageSize = 20)
        {
            Int32 from = 1;
            Int32 to = total > pageSize ? pageSize : total;

            List<Int32[]> pagingTab = new List<Int32[]>();

            if (total == 0)
            {
                pagingTab.Add(new Int32[] { 0, 0 });

                return pagingTab;
            }

            while (to < total)
            {
                pagingTab.Add(new Int32[] { from, to });
                from = to + 1;
                to += pageSize;
            }

            if (to > total)
            {
                to = total;
            }

            pagingTab.Add(new Int32[] { from, to });

            return pagingTab;
        }
    }
}
