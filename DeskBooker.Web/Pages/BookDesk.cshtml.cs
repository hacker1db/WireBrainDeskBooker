﻿using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeskBooker.Web.Pages
{
    public class BookDeskModel : PageModel
    {
        private readonly IDeskBookingRequestProcessor _deskBookingRequestProcessor;

        public BookDeskModel(IDeskBookingRequestProcessor deskBookingRequestProcessor)
        {
            _deskBookingRequestProcessor = deskBookingRequestProcessor;
        }

        [BindProperty] public DeskBookingRequest DeskBookingRequest { get; set; }

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                _deskBookingRequestProcessor.BookDesk(DeskBookingRequest);
            }
        }
    }
}