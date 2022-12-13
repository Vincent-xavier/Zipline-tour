﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZiplineTour.Services;
using ZiplineTour.Models.Input;

namespace ZiplineTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("eventbooking")]
        public async Task<IActionResult> EventBooking(BookingModel bookingModel)
        {
            var result = await _bookingService.SaveEventBooking(bookingModel);

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("fetchAllBookings")]
        public async Task<IActionResult> FetchBooking()
        {
            var result = await _bookingService.FetchBooking();

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getBookingDetails/{bookingId}")]
        public async Task<IActionResult> BookingDetailsById(int bookingId)
        {
            var result = await _bookingService.BookingDetailsById(bookingId);

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("payment")]
        public async Task<IActionResult> Payment(Payment pay)
        {
            var result = await _bookingService.Payment(pay);

            if (result.StatusCode == 200)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
