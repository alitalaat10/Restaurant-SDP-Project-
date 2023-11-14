using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using design_pattern.Models.Branches;
using design_pattern.Models.Tables;

namespace design_pattern.Models.Workers
{
    public class Receptionist : Worker
    {
        public Receptionist() : base()
        {
            Type = WorkerType.Receptionist;
        }
        public Receptionist(string Wname, int sal) : base(Wname, sal)
        {
            Type = WorkerType.Receptionist;
        }
        public Receptionist(string Wname, int sal, Branch b) : base(Wname, sal, b)
        {
            Type = WorkerType.Receptionist;
        }

        public void AddTable(int seats, PositionType position)
        {
            if (db == null) return;
            Table t = new Table(seats, position);
            t.BranchName = this.BranchName;
            db.Tables.Add(t);
        }
        public bool ModifyTable(int id, int seats, PositionType position)
        {
            if (db == null) return false;
            Table oldTable = db.Tables.Where(x => x.Number == id && x.BranchName == BranchName).FirstOrDefault();
            if (oldTable == null) return false;
            oldTable.Seats = seats;
            oldTable.Position = position;
            return true;
        }
        public bool RemoveTable(int id)
        {
            if (db == null) return false;
            Table oldTable = db.Tables.Where(x => x.Number == id && x.BranchName == BranchName).FirstOrDefault();
            if (oldTable == null) return false;
            db.Tables.Remove(oldTable);
            return true;
        }
        public void CreateReservation(Table table, DateTime ReservationDate, string CustomerName, string CustomerEmail = "", string CustomerPhone = "")
        {
            if(db == null) return;
            Reservation res = new Reservation(){Date=ReservationDate, CustomerName=CustomerName, CustomerEmail=CustomerEmail,CustomerPhone=CustomerPhone};
            res.Table = table;
            db.Reservations.Add(res);
        }
        public Reservation CancelReservation(int resId)
        {
            if(db == null) return null;
            Reservation res = db.Reservations.Where(x => x.Id == resId).FirstOrDefault();
            if(res == null) return null;
            db.Reservations.Remove(res);
            return res;
        }
        public Reservation CheckInReservation(int resId)
        {
            if(db == null) return null;
            Reservation res = db.Reservations.Where(x => x.Id == resId).FirstOrDefault();
            if(res == null) return null;
            res.Status = ReservStatus.CheckedIn;
            return res;
        }
    }
}