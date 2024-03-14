using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Order_
    {
        public int Id { get; set; }
        public DateTime Date_ { get; set; }
        public Decimal Cost { get; set; }
        public int Code { get; set; }
        public string Status { get; set; }
        public Order_() { }
        public Order_(int id, DateTime date_, Decimal cost, int code, string status)
        {
            Id = id;
            Date_ = date_;
            Cost = cost;
            Code = code;
            Status = status;
        }
    }
}
