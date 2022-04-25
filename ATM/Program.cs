using ATM.Classes;
using System;

namespace ATM
{
    internal class Program
    {
        static User FindUser(User[] users, string cardNum)
        {
            foreach (User user in users)
            {
                if (user.CardNum == cardNum)
                    return user;
            }
            return null;
        }
        public static void NewUser(ref User[] users, string firstName, string lastName, string cardNum, int pin)
        {
            Array.Resize(ref users, users.Length + 1);
            users[users.Length - 1] = new User(firstName, lastName, cardNum, pin, 0);
        }
        static void Main(string[] args)
        {
            User[] users = new User[3]
            {
            new User("Jack", "Sparrow", "325345846257454558", 3453, 4400),
            new User("John","Doe","3548344215462327554",4566,8564),
            new User("Will","Smith","1111111111111111",7856,2770),
            };

            Console.WriteLine("Welcome to our ATM machine");
            Console.WriteLine("Enter a number to choose from the options below");
            Console.WriteLine("1.Login 2.Register 3.Exit");

            string ans = Console.ReadLine();
            if (ans == "1")
            {
                Console.WriteLine("Please enter your First Name ");
                string newName = Console.ReadLine();
                if (string.IsNullOrEmpty(newName))
                {
                    Console.WriteLine("U must enter a First Name ");

                }
                Console.WriteLine("Please enter your Last Name ");
                string newLastName = Console.ReadLine();
                if (string.IsNullOrEmpty(newLastName))
                {
                    Console.WriteLine("U must enter a Last name ");

                }
                Console.WriteLine("Please enter your card number  ");
                string newCard = Console.ReadLine();
                if (string.IsNullOrEmpty(newCard))
                {
                    Console.WriteLine("U must enter a number");

                }
                if (newCard.Length != 16)
                {
                    Console.WriteLine("Invalid input card num must  be 16 digits");
                    
                }
                Console.WriteLine("Please enter your Pin code ");
                string newPin = Console.ReadLine();
                if(string.IsNullOrEmpty(newPin))
                {
                    Console.WriteLine("U must enter a number");

                }
                if (newPin.Length != 4)
                {
                    Console.WriteLine("Pin must be 4 digits");
                }
                if(!int.TryParse(newPin, out int parsedPin))
                {
                    Console.WriteLine("Pin must be a number");
                }
                NewUser(ref users, newName, newLastName, newCard, parsedPin);
                Console.WriteLine($"Successfully registered , welcome {newName},thank you for using our services");
                Console.ReadLine();
            }

            while (true)
            {
                Console.WriteLine("Please enter a 16 digit card number");

                string cardNumber = Console.ReadLine();

                User user = FindUser(users, cardNumber);


                if (string.IsNullOrEmpty(cardNumber))
                {
                    Console.WriteLine("You must enter the card number");
                    continue;
                }
                if (cardNumber.Length != 16)
                {
                    Console.WriteLine("Invalid input card num must  be 16 digits");
                    continue;
                }
                else if (user == null)
                {
                    Console.WriteLine("User is not found try again");
                    continue;

                }

                else
                {

                    while (true)
                    {
                        Console.WriteLine("Please enter pin");

                        if (!int.TryParse(Console.ReadLine(), out int pin))
                        {
                            Console.WriteLine("Pin must be a number");
                            continue;
                        }
                        if (pin.ToString().Length != 4)
                        {
                            Console.WriteLine("Pin must be 4 digits");
                            continue;
                        }

                        else if (user.CheckPin(pin) == false)
                        {
                            Console.WriteLine("Incorrect pin");
                            continue;
                        }
                        break;
                    }
                }
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome to the Atm {user.FirstName} {user.LastName}");
                    Console.WriteLine($"Enter a number to choose from the options below");
                    Console.WriteLine($" 1.Check Balance \n 2.Cash Withdrawal \n 3.Cash Deposit");
                    string choice = Console.ReadLine();


                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Your account balance is {user.GetAccBalance()}");
                            break;


                        case "2":
                            Console.WriteLine("Please enter the amount you would like to withdraw");
                            string amount = Console.ReadLine();
                            if (string.IsNullOrEmpty(amount))
                            {
                                Console.WriteLine("U must enter an amount");
                                Console.Read();
                                continue;
                            }
                            if (!double.TryParse(amount, out double parsedAmount))
                            {
                                Console.WriteLine("Invalid input ");
                                Console.Read();
                                continue;
                            }
                            if (user.Withdrawal(parsedAmount) == false)
                            {
                                Console.WriteLine("Insufficient funds ");
                                Console.Read();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine($"You have succsessfuly withdrawn {parsedAmount} you current account balance is {user.GetAccBalance()}");
                                break;
                            }

                        case "3":
                            Console.WriteLine("Please enter the amount you would like to deposit");
                            string deposit = Console.ReadLine();
                            if (string.IsNullOrEmpty(deposit))
                            {
                                Console.WriteLine("U must enter an amount");
                                Console.Read();
                                continue;
                            }
                            if (!double.TryParse(deposit, out double parsedDeposit))
                            {
                                Console.WriteLine("Invalid input ");
                                Console.Read();
                                continue;
                            }
                            else
                            {
                                user.Deposit(parsedDeposit);
                                Console.WriteLine($"You have succsessfuly deposited {parsedDeposit} you current account balance is {user.GetAccBalance()}");
                                
                                break;

                            }
                        default:
                            {
                               
                                continue;

                            }


                    }
                    Console.WriteLine($"Do you want to continue with transactions? \n 1.Press any key for yes \n 2.Press 'no' to exit");
                    string answer = Console.ReadLine();
                    if (answer.ToLower() == "no")
                    {
                        Console.WriteLine("Thank you for using our Atm.Goodbye");
                        break;
                    }
                    else    continue;
                }
                break;
            }

        }
    }
}
