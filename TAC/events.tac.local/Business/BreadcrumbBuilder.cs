using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TAC.Sitecore.Abstractions.SitecoreImplementation;
using TAC.Sitecore.Abstractions.Interfaces;
using events.tac.local.Models;

namespace events.tac.local.Business
{
    public class BreadcrumbBuilder
    {
        private readonly IRenderingContext _context;

        public BreadcrumbBuilder() : this(SitecoreRenderingContext.Create()) {}

        public BreadcrumbBuilder(IRenderingContext context)
        {
            _context = context;
        }

        public IEnumerable<NavigationItem> Build()
        {
            if (_context == null || _context.ContextItem == null)
                return new List<NavigationItem>();

            var items = (from item in _context.ContextItem.GetAncestors()
                         where _context.HomeItem.IsAncestorOrSelf(item)
                         select new NavigationItem(item.DisplayName, item.Url, false)).ToList();
            items.Add(new NavigationItem(_context.ContextItem.DisplayName, _context.ContextItem.Url, true));

            return items;
        }
    }
}