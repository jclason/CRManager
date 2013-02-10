using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRManager.Models.Room;

namespace CRManager.Controllers
{
    public class RoomController : Controller
    {
        private const string connection = "DefaultConnection";

        public JsonResult GetSchedule(int roomId = 0)
        {
            // Check if user is authenticated and such here
            Massive.DynamicModel dm = Massive.DynamicModel.Open(connection);
            dynamic scheduleItems = dm.Query("GetSchedule @RoomID=@0", roomId);

            var reservationList = new Collection<ReservationModel>();
            foreach (var reservation in scheduleItems)
            {
                reservationList.Add(new ReservationModel() { 
                    RoomId = reservation.RoomID, 
                    ReservationId = reservation.ReservationID, 
                    EndTime = reservation.EndTime, 
                    JobNumber = reservation.JobNumber,
                    StartTime = reservation.StartTime, 
                    UserId = reservation.UserId 
                });
            }
            return Json(reservationList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRoomList()
        {
            // Check if user is authenticated and such here
            Massive.DynamicModel dm = Massive.DynamicModel.Open(connection);
            dynamic roomList = dm.Query("GetAllRooms");

            var rooms = new Collection<RoomModel>();
            foreach (var room in roomList)
            {
                rooms.Add(new RoomModel() {
                    RoomId = room.RoomID, 
                    RoomName = room.RoomName, 
                    ExchangeRoomId = room.ExchangeRoomID
                });
            }
            return Json(rooms, JsonRequestBehavior.AllowGet);
        }
    }
}
