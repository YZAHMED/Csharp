using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {

        /// <summary>
        /// Q1: This method returns a welcome message to the course 5125.
        /// This methos accepts a GET request at: localhost:xx/api/q1/welcome -> Welcome to 5215!
        /// </summary>
        /// <returns>A welcome message: Welcome to 5215!</returns>
        [HttpGet(template:"/api/q1/welcome")]

        public string Welcome()
        {
            return "Welcome to 5215!";
        }

        /// <summary>
        /// Q2: This methods return a Hello Message to a name passed to it.
        /// </summary>
        /// <param name="name">This param takes in a Name that can be given by a requester</param>
        /// <returns>Hi Gary!</returns>
        [HttpGet(template: "/api/q2/greeting")]
        public string Greeting([FromQuery] string name)
        {
            string message = $"Hi {name}!";
            return message;
        }
        /// <summary>
        /// Q3: This method takes in a number the returns its cube
        /// </summary>
        /// <param name="cubein">It takes an int from user</param>
        /// <returns>return the cube of the inputted number</returns>


        [HttpGet(template:"/api/q3/cube/{cubein}")]
        public int Cube(int cubein)
        {
            int cube = cubein * cubein * cubein;
            return cube;
        }
        /// <summary>
        /// Q4 Return the start of a joke called knockknock using POST
        /// </summary>
        /// <returns>"Who's there?"</returns>
        [HttpPost(template:"/api/q4/knockknock")]
        public string Knockknock()
        {
            return "Who's there?";
        }
        /// <summary>
        /// Q5 It take a secret number then returns it uses POST method
        /// </summary>
        /// <param name="secret">this is the input from the use</param>
        /// <returns>the secret with a message</returns>
        [HttpPost(template:"/api/q5/secret")]
        public string Secret([FromBody]int secret)
        {
            string message = $"Shh.. the secret is {secret}";
            return message;
        }

        /// <summary>
        /// Q6 This is a GET method that calculates hexagon by taking in a number from users
        /// </summary>
        /// <param name="side">this is the input that user will add as a param</param>
        /// <returns>the hexagon of the inputted number</returns>

        [HttpGet(template:"/api/q6/hexagon")]
        public double GetHexa([FromQuery]double side)
        {
            return (3 * Math.Sqrt(3) / 2) * Math.Pow(side, 2);
        }

        /// <summary>
        /// This method returns a date added to an added date
        /// </summary>
        /// <param name="days">the days to added or minused </param>
        /// <returns>the date after those days either subtracted or added </returns>

        [HttpGet(template:"/api/q7/timemachine")]
        public string GetDayAdded([FromQuery]int days)
        {
            DateTime today = DateTime.Today;
            DateTime addorminus = today.AddDays(days);

            string dating = addorminus.ToString("yyyy-MM-dd");

            return dating;
        }

        /// <summary>
        /// The takes a number of small and a large the produces a respone based on the price with tax
        /// </summary>
        /// <param name="Small">takes number of small order</param>
        /// <param name="Large">takes number of large orders</param>
        /// <returns>the subtotal</returns>

        [HttpPost(template:"/api/q8/squashfellows")]
        [Consumes("application/x-www-form-urlencoded")]
        public string GetBill([FromForm]int Small, [FromForm]int Large)
        {
            double priceSmall = 25.50;
            double priceLarge = 40.50;

           
            double subtotalSmall = Small * priceSmall;
            double subtotalLarge = Large * priceLarge;

           
            double subtotal = subtotalSmall + subtotalLarge;

          
            double tax = subtotal * 0.13;

            double total = subtotal + tax;

            string message = $"{Small} Small @ ${priceSmall}; {Large} @ ${priceLarge} Subtotal = ${subtotal} ; Tax = ${tax} HST; Total = ${total}";


            return message;
        }


    }
}
