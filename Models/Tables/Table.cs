using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using design_pattern.Models.Branches;

namespace design_pattern.Models.Tables
{

    public enum PositionType
    {
        Indoor, Outdoor
    }
    public class Table : IPrototype
    {

        [Key]
        public int Number { get; set; }

        [Required(ErrorMessage = "Pleaser Enter Number Of Seats")]
        [Range(1, int.MaxValue, ErrorMessage = "Pleaser Enter at least 1 seat")]
        public int Seats { get; set; }
        [Required(ErrorMessage = "Pleaser Choose Position Of the table")]
        [EnumDataType(typeof(PositionType), ErrorMessage = "Must choose a position")]
        public PositionType Position { get; set; }

        public string BranchName { get; set; }
        public Branch Branch { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public Table()
        {
        }
        public Table(int Seats, PositionType Posititon)
        {
            this.Seats = Seats; this.Position = Position;
        }

        public IPrototype getClone()
        {
            Table t = new Table(this.Seats, this.Position);
            return t;
        }
    }
}