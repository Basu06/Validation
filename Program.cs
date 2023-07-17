using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppValidation
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RegisterUser();
                Console.WriteLine("User Registeration Successfull");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine($"Validation Error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }

        private static void RegisterUser()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            ValidateName(name);
            ValidateEmail(email);
            ValidatePassword(password);
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException("Name is required");
            }
        }

        private static void ValidateEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                throw new ValidationException("Email is required");
            }

            if (!email.Contains("@"))
            {
                throw new ValidationException("Invalid email format");
            }
        }

        private static void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ValidationException("Password is required");
            }

            if (password.Length < 6)
            {
                throw new ValidationException("Password should be at least 6 characters long");
            }
        }
    }
}
