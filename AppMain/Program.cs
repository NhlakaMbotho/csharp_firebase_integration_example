
using System;
using System.Threading.Tasks;
using Firebase;

namespace ConsoleApp
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var fbUtils = new FirebaseUtils();

            string response = "";

            try
            {
                response = await fbUtils.SendMessageAsync("Test message to android device", "foo_bar");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed: {0}", ex.ToString());
            }

            Console.WriteLine("Successfully send message to firebase: {0}", response);
        }
    }
}

