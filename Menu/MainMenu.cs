using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainStation.Service.Implementation;
using TrainStation.Service.Interface;

namespace TrainStation.Menu
{
    public partial class MainMenu
    {
        ICustomerService customerService = new CustomerService();
        IUserService userService= new UserService();
        public void Start()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("== WELCOME TO KAY STATION ==");
            Console.ResetColor();
            Console.WriteLine("1. Register\n2. Login\n#. Exit");
            Console.WriteLine();
            Console.Write("=> ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                RegisterMenu();
                Start();
            }
            else if (option == "2")
            {
                LoginMenu();
            }
            else if (option == "#")
            {
                Console.WriteLine("Thank you");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid option");
                Console.ResetColor();
                Start();
            }
        }
        public void RegisterMenu()
        {
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            

            var response = customerService.RegisterCustomer(name, email, password);
            if (response == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Registration failed");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Registration successful");
                Console.ResetColor();
            }
        }
        public void LoginMenu()
        {
            Console.WriteLine("== LOGIN ==");
            Console.Write("Enter email:");
            string email = Console.ReadLine();
            Console.Write("Enter password:");
            string password = Console.ReadLine();

            var response = userService.Login(email, password);
            if (response == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid credentials");
                Console.ResetColor();
                Start();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Login successful");
            Console.ResetColor();

            if (response.Role == "app_CEO")
            {
                CeoMenu();
            }
            else if (response.Role == "app_Customer")
            {
                CustomerMenu();
            }
        }
    }
}