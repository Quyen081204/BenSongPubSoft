using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;
using Newtonsoft.Json.Linq;
using Momo;
using QLNhaHangNhau.DTO;
using QRCoder;
using Newtonsoft.Json;
using System.Text.Json;


namespace QLNhaHangNhau.DAO
{
    public class PaymentResponse
    {
        public int resultCode { get; set; }
        public bool status { get; set; }
    }
    public class PaymentDAO
    {
        private static PaymentDAO instace;
        private string baseBackEndUrl = "https://5018-171-252-188-57.ngrok-free.app";
        public static PaymentDAO GetInstance()
        {
            if (instace == null)
            {
                instace = new PaymentDAO();
            }

            return instace;
        }

        private PaymentDAO() {}

        // Tao payment trong csdl
        public int CreatePayment(Payment payment)
        {
            string query = """
                    INSERT INTO Payments (request_id, order_id, amount, status, updated_at, hoaDonID)
                    VALUES ( 
                                @request_id, @order_id, @amount, @status, @updated_at ,@hoaDonID
                           )
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@request_id", payment.requestId);
            cmd.Parameters.AddWithValue("@order_id", payment.orderId);
            cmd.Parameters.AddWithValue("@amount", payment.amount);
            cmd.Parameters.AddWithValue("@status", payment.Status);
            cmd.Parameters.AddWithValue("@updated_at", payment.UpdateAt);
            cmd.Parameters.AddWithValue("@hoaDonID", payment.BillID);

            int rowAffected = DataProvider.Instance.ExecuteNonQuery(cmd);
            if (rowAffected > 0)
            {
                Console.WriteLine("== Insert payment successfully");
            }
            else
            {
                Console.WriteLine("== Insert payment fail");
            }
            return rowAffected;
        }

        // Call MoMo api
        public Bitmap ProcessPayment(Payment payment)
        {
            //request params need to request to MoMo system
            
            
            string endpoint = "https://test-payment.momo.vn/v2/gateway/api/create";
            string partnerCode = "MOMO";//"MOMO5RGX20191128";
            string accessKey = "F8BBA842ECF85";//"M8brj9K6E22vXoDB";
            string serectkey = "K951B6PE1waDMi640xX08PD3vg6EkVlz";//"nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
            string orderInfo = payment.orderInfo;
            string redirectUrl = $"{baseBackEndUrl}";
            string ipnUrl = $"{baseBackEndUrl}/api/processMomoCallBack/";
            string requestType = "captureWallet";  // captureWallet
                                                   // 
            string amount = payment.amount.ToString();
            string orderId = payment.orderId;
            string requestId = payment.requestId;
            string extraData = payment.extraData;


            //Before sign HMAC SHA256 signature
            string rawHash = "accessKey=" + accessKey +
                "&amount=" + amount +
                "&extraData=" + extraData +
                "&ipnUrl=" + ipnUrl +
                "&orderId=" + orderId +
                "&orderInfo=" + orderInfo +
                "&partnerCode=" + partnerCode +
                "&redirectUrl=" + redirectUrl +
                "&requestId=" + requestId +
                "&requestType=" + requestType
                ;

            //log.Debug("rawHash = " + rawHash);
            Console.WriteLine("rawHash = " + rawHash);

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);
            //log.Debug("Signature = " + signature);
            Console.WriteLine("Signature = " + signature);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", "Test" },
                { "storeId", "MomoTestStore" },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", ipnUrl },
                { "lang", "en" },
                { "extraData", extraData },
                { "requestType", requestType },
                { "signature", signature }

            };


            Console.WriteLine("Json request to MoMo: " + message.ToString());

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            Console.WriteLine("Return from MoMo: " + jmessage.ToString());

            // Xu ly response tu Momo
            if (jmessage.GetValue("resultCode").ToString() == "0")
            {
                Console.WriteLine(" ======> Tao ma qr code");
                // Thanh cong tien hanh tao ma qr code cho ng dung quet
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qRCodeData = qrGenerator.CreateQrCode(jmessage.GetValue("qrCodeUrl").ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qRCode = new QRCode(qRCodeData);

                Bitmap qrCodeImage = qRCode.GetGraphic(5);
                return qrCodeImage;
            }
            else
            {
                Console.WriteLine("== Xu ly that bai ==");
            }

            return null;

            //DialogResult result = MessageBox.Show(responseFromMomo, "Open in browser", MessageBoxButtons.OKCancel);
            //if (result == DialogResult.OK)
            //{
            //    //yes...
            //    Console.WriteLine(jmessage.GetValue("payUrl").ToString());
            //    System.Diagnostics.Process.Start(jmessage.GetValue("payUrl").ToString());

            //    SendPostRequest(payment);
            //}
            //else if (result == DialogResult.Cancel)
            //{
            //    //no.../*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/**/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
            //}

        }

        public async Task<PaymentResponse> SendPostRequest(string orderId)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new
                {
                    order_id = orderId
                };

                string json = JsonConvert.SerializeObject(data);

                Console.WriteLine($"data to check order {json}");

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{baseBackEndUrl}/api/checkOrderStatus/", content);
                string responseFromBackEnd = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine("--- Response from backend: " + responseFromBackEnd);

                PaymentResponse paymentResponse = System.Text.Json.JsonSerializer.Deserialize<PaymentResponse>(responseFromBackEnd);
                

                return paymentResponse;
            }
        }

        public async Task<bool> CheckPayment(string orderId)
        {
            // Each 5s send a polling check payment to check status of payment
            bool flag = false;
            int attempt = 0;

            while(!flag)
            {
                // JsonResponse({"resultCode": order.result_code, "status":order.status})
                PaymentResponse paymentResponse = await SendPostRequest(orderId);

                if (paymentResponse != null && paymentResponse.status == true)
                {
                    // The customer has paid the bill
                    return true; // Luu csdl 
                }
                
                await Task.Delay(3000);
                attempt++;
                if (attempt == 30) // 5s has ellapse
                {
                    flag = true;
                }
            }

            // Something goes wrong
            return false;
        }
    }
}
