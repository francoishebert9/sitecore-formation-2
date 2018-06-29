using events.tac.local.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class EventListController : Controller
    {
        private readonly EventsProvider _provider;

        public EventListController() : this(new EventsProvider()) { }

        public EventListController(EventsProvider provider)
        {
            _provider = provider;
        }

        // GET: EventList
        public ActionResult Index(int page = 1)
        {
            return View(_provider.GetEventsList(page - 1));
        }
    }
}