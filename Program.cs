using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzasShopDuoTask
{
    class Program
    {
        readonly PizzaOrderingContext Context;

        public Program()
        {
            Context = new PizzaOrderingContext();
        }
        public void Menu()
        {
            Console.WriteLine("The Menu\n1)Login\n2)Register");
            int userchoice = GetNumber();
            switch (userchoice)
            {
                case 1:
                    Login();
                   


                    break;
                case 2:
                    RegisterNewUser();
                    break;

                default:
                    Console.WriteLine("Please choose 1 or 2");
                    Menu();
                    break;
            }
        }

        public void Login()
        {
            List<UsersDetail> usersdetails = Context.UsersDetails.ToList();
            try
            {
                string email, password;
                Console.WriteLine("Enter your email");
                email = Console.ReadLine();
                Console.WriteLine("Enter your pasword");
                password = Console.ReadLine();

                bool successfull = false;
                while (!successfull)
                {
                    foreach (UsersDetail user in usersdetails)
                    {
                        if (email == user.UserEmail && password == user.Password)
                        {
                            Console.WriteLine("You have successfully logged in!");

                            PrintPizzaDetails();
                            Console.ReadLine();
                            successfull = true;
                            break;
                        }
                    }

                    if (!successfull)
                    {
                        Console.WriteLine("Your email or pasword wrong");
                        Login();
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RegisterNewUser()
        {

            try
            {
                UsersDetail user = new UsersDetail();
                Console.WriteLine("Enter your user name");
                user.Name = Console.ReadLine();

                Console.WriteLine("Enter your email");
                user.UserEmail = Console.ReadLine();

                Console.WriteLine("Enter your pasword");
                user.Password = Console.ReadLine();

                Console.WriteLine("Enter your adress");
                user.Address = Console.ReadLine();

                Console.WriteLine("Enter your phone");
                user.Phone = Console.ReadLine();

                Context.Add(user);
                Context.SaveChanges();
                Console.WriteLine("Your registration completed successfully");

                Login();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                RegisterNewUser();
            }


        }
        public void PrintPizzaDetails()
        {
            List<Pizza> getPizzaDetails = Context.Pizzas.ToList();
            Console.WriteLine("The following pizzas are avaliable for ordering");
            Console.WriteLine("Number" + "        " + "Pizza" + "         " + "Price" + "    " + "Type");
            Console.WriteLine("---------" + "      " + "----------" + "      " + "------" + "   " + "----------");
            foreach (var item in getPizzaDetails)
            {

                Console.WriteLine("    " + item.PizzaNumber + "        " + item.PizzaName + "         " + item.Price + "       " + item.PizzaType);
            }
            PizzaOrderDetails();
            




        }
        public static int GetNumber()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("It's not a number. Please try again");
            }
            Console.WriteLine();
            return number;
        }

        public void PizzaOrderDetails()
        {
            Console.WriteLine("Enter the Pizza of your choice");
            int userChoice = GetNumber();
            List<Pizza> pizzadetails = Context.Pizzas.Where(a => a.PizzaNumber == userChoice).ToList();
            if (pizzadetails.Count == 1)
            {
                foreach (var item in pizzadetails)
                {
                    Console.WriteLine("You have selected " + item.PizzaName + " for $ " + item.Price);
                }
                    PrintToppingsDetails();
            }
            else
            {
                Console.WriteLine("the number you entered wrong try again");
                PizzaOrderDetails();
            }

        }

        public void PrintToppingsDetails()
        {
            Console.WriteLine("Do u want extra toppings?y/n");
            string userchoice = Console.ReadLine();


            if (userchoice == "y")
            {

                List<Topping> getToppingDetails = Context.Toppings.ToList();
                Console.WriteLine("The folowing are the toppings");
                Console.WriteLine("Number" + "        " + "Topping" + "         " + "Price");
                Console.WriteLine("---------" + "      " + "----------" + "      " + "------");
                foreach (var item in getToppingDetails)
                {
                    Console.WriteLine("    " + item.ToppingNumber + "        " + item.ToppingName + "         " + item.Price);
                }
                ToppingOrderDetails();
            }
            else
            {
                Console.WriteLine("Ok, we know about your order");
            }
        }
        public void ToppingOrderDetails()
        {
            Console.WriteLine("Select the topping");

            int userChoiceTopping = GetNumber();

            List<Topping> toppingdetails = Context.Toppings.Where(a => a.ToppingNumber == userChoiceTopping).ToList();

            if (toppingdetails.Count == 1)
            {
                foreach (var item in toppingdetails)
                {
                    Console.WriteLine("You have selected " + item.ToppingName + " for $ " + item.Price);
                    PrintToppingsDetails();
                }

                //PrintToppingsDetails();

            }
            else
            {
                Console.WriteLine("the number you entered wrong try again");
                ToppingOrderDetails();
            }

        }
        static void Main(string[] args)
        {
            Program programm = new Program();
            programm.Menu();
        }
    }
}
