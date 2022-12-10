﻿using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ZiplineTour.DBEngine;
using ZiplineTour.Models.Input;
using ZiplineTour.Repository;
using ZiplineTour.Services;

namespace ZiplineTour.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize(Roles ="Admin")]
    //[Authorize(Roles ="User")]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IServerHandler _serverHandler;
        public EventController(IEventService eventService, IServerHandler serverHandler)
        {
            _eventService = eventService;
            _serverHandler = serverHandler;
        }

        [HttpGet]
        [Route("fetchEvent")]
        public async Task<IActionResult> FetchEvent()
        {
            var events = await _eventService.FetchEvents();

            if (events.StatusCode == 200)
            {
                return Ok(events);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("eventById/{eventId}")]
        public async Task<IActionResult> EventById(int eventId)
        {
            return Ok(await _eventService.EventById(eventId));
        }

        [HttpGet]
        [Route("eventDetails")]
        public async Task<IActionResult> EventDetails()
        {
            var events = await _eventService.EventDetails();


            if (events.StatusCode == 200)
            {
                return Ok(events);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("eventDetailsById/{eventId}")]
        public async Task<IActionResult> EventDetailsById(int eventId)
        {
            return Ok(await _eventService.EventDetailsById(eventId));
        }

        [HttpPost]
        [Route("saveEvent")]
        public async Task<IActionResult> SaveEvent([FromForm] EventModel eventModel)
        {
            return Ok(await _eventService.SaveEvent(eventModel));
        }

        [HttpPost]
        [Route("saveSchedule")]
        public async Task<IActionResult> SaveEventSchedule(EventSchedule schedule)
        {
            return Ok(await _eventService.SaveEventSchedule(schedule));
        }

        [HttpGet("getSchedules/{EventId}")]
        public async Task<IActionResult> GetScheduleDetails(int EventId)
        {
            var Schedule = await _eventService.GetEventSchedule(EventId);

            if (Schedule == null)
            {
                return BadRequest();
            }
            else if (Schedule != null && Schedule.StatusCode == 200)
            {
                return Ok(Schedule);
            }
            return BadRequest();

        }

        [HttpGet("getScheduleById/{ScheduleId}")]
        public async Task<IActionResult> ScheduleById(int ScheduleId)
        {
            var Schedule = await _eventService.ScheduleById(ScheduleId);

            if (Schedule == null)
            {
                return BadRequest();
            }
            else if (Schedule != null && Schedule.StatusCode == 200)
            {
                return Ok(Schedule);
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("BulkInsert")]
        public async Task<IActionResult> BulkInsert()
        {

            string ConnectionString = "Server=192.168.1.7;Port=3306;Database=zipline;Uid=sjc;Pwd=admin@sjc;";
            StringBuilder sCommand = new StringBuilder("INSERT INTO test_usernames (Date,ScheduleId,EventId) VALUES ");
            using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
            {
                List<string> Rows = new List<string>();
                int scheduleId = 8;
                int eventId = 5;
                var dates = new List<DateTime>();
                dates.Add(DateTime.Now);

                //for (int i = 0; i < 10; i++)
                //{
                //    Rows.Add(string.Format("('{0}')", MySqlHelper.EscapeString("test")));

                //}
                foreach (var item in dates)
                {
                    Rows.Add(string.Format("('{0}','{1}','{2}')",item,scheduleId,eventId));
                }
                sCommand.Append(string.Join(",", Rows));
                sCommand.Append(";");
                mConnection.Open();
                using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), mConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    var result = myCmd.ExecuteNonQuery();
                }
            }


            return Ok();
        }

    }
}
