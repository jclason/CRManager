using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRManager.Models.Room
{
    public class ReservationModel
    {
        public int ReservationId;
        public int RoomId;
        public DateTime StartTime;
        public DateTime EndTime;
        public int UserId;
        public string JobNumber;
    }

    public class RoomModel
    {
        public int RoomId;
        public string RoomName;
        public string ExchangeRoomId;
    }
}