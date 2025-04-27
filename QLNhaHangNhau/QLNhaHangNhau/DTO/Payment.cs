using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DTO
{
    public class Payment
    {
        public string orderInfo { get; set; }
        public long amount { get; set; }
        public string orderId { get; set; }
        public string requestId { get; set; }
        public string extraData { get; set; }
        //public string partnerName { get; set; }
        public string storeId { get; set; }
        public string requestType { get; set; }
        public string lang { get; set; }
        public string partnerCode { get; set; }
        public string Status { get; set; }
        public DateTime UpdateAt { get; set; }
        public int BillID { get; set; }

        public Payment()
        {
            this.orderId = Guid.NewGuid().ToString();
            this.requestId = Guid.NewGuid().ToString();
            this.Status = "PENDING";
            this.lang = "vi";
            this.partnerCode = "MOMO";
            this.storeId = "Bên Sông Pub";
            this.orderInfo = "pay with momo";
            this.extraData = "";
            this.requestType = "captureWallet";
        }
    }
}
