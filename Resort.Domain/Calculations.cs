// using Resort.Domain.Orders;
// using Resort.Domain.Bookings;
// using Resort.Domain.RoomHistory;
//
// namespace Resort.Domain;
//
// public class Calculations
// {
//     public Calculations(Room room, Order order, CheckInOutLogs checkInOutLogs)
//     {
//         DateTime checkInDate = checkInOutLogs.CheckInDate;
//         DateTime checkOutDate = checkInOutLogs.CheckOutDate;
//
//         TimeSpan stayDuration = checkOutDate - checkInDate;
//         
//         int totalStayDays = stayDuration.Days;
//
//         decimal roomPrice = room.Rate.Amount;
//         decimal TotalAmount = totalStayDays * roomPrice;
//
//         decimal grandTotal = TotalAmount + order.Total;
//     }
// }