using Internship_3_OOP.Classes.Enums;
using System.Windows.Markup;
using System.Xml.Linq;

namespace Internship_3_OOP.Classes
{
    public static class ValidationHelper
    {
        public static string NoEmptyStringValidation(string message)
        {
            string value;
            do
            {
                Console.Write(message);
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("Unos ne smije biti prazan");

            } while (string.IsNullOrWhiteSpace(value));

            return value;
        }

        public static string AllLettersStringValidation(string message)
        {
            string value;
            do
            {
                Console.Write(message);
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                    Console.WriteLine("Unos ne smije biti prazan");
                else if (!value.All(char.IsLetter))
                    Console.WriteLine("Unos smije imati samo slova!");

            } while (string.IsNullOrWhiteSpace(value) || !value.All(char.IsLetter));

            return value;
        }

        public static string EmailValidation(string message)
        {
            string value;
            while (true)
            {
                Console.Write(message);
                value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Unos ne smije biti prazan");
                    continue;
                }

                if (value.EndsWith("@mail.com"))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("E-mail mora završavati sa '@mail.com'!");
                }
            }
        }

        public static DateOnly DateOfBirthValidation(string message)
        {
            string value;
            DateOnly minTime = new DateOnly(1900, 1, 1);
            do
            {
                Console.Write(message);
                value = Console.ReadLine();

                if (DateOnly.TryParseExact(value, "yyyy-MM-dd", out DateOnly date))
                {
                    if (date < minTime)
                    {
                        Console.WriteLine("Datum ne moze biti starije od 1900 godine!");
                        continue;
                    }
                    else return date;
                }
                else
                {
                    Console.WriteLine("Neispravan unos datuma!");
                }
            } while (true);
        }

        public static Gender GenderValidation(string message)
        {
            string value;
            Console.WriteLine($"1 - {Gender.Male}");
            Console.WriteLine($"2 - {Gender.Female}");
            do
            {
                Console.Write(message);
                value = Console.ReadLine().Trim().ToUpper();

                if (value == "1" || value == "M" || value == "MALE")
                {
                    return Gender.Male;
                }

                else if (value == "2" || value == "F" || value == "FEMALE")
                {
                    return Gender.Female;
                }

                else
                {
                    Console.WriteLine("Morate upisati 1 ili 2!");
                    continue;
                }

            } while (true);
        }

        public static CrewPosition PositionValidation(string message)
        {
            string value;
            Console.WriteLine($"1 - {CrewPosition.Pilot}");
            Console.WriteLine($"2 - {CrewPosition.Copilot}");
            Console.WriteLine($"3 - {CrewPosition.FlightAttendant}");
            do
            {
                Console.Write(message);
                value = Console.ReadLine().Trim().ToUpper();

                if (value == "1" || value == "P" || value == "PILOT")
                {
                    return CrewPosition.Pilot;
                }

                else if (value == "2" || value == "C" || value == "COPILOT")
                {
                    return CrewPosition.Copilot;
                }

                else if (value == "3" || value == "F" || value == "FLIGHTATTENDANT")
                {
                    return CrewPosition.FlightAttendant;
                }

                else
                {
                    Console.WriteLine("Morate upisati 1 ili 2 ili 3!");
                    continue;
                }

            } while (true);
        }

        public static int CategoryIntValidation(string message)
        {
            string value;
            Console.WriteLine($"1 - {Category.Standard}");
            Console.WriteLine($"2 - {Category.Business}");
            Console.WriteLine($"3 - {Category.VIP}");
            do
            {
                Console.Write(message);
                value = Console.ReadLine().Trim().ToUpper();

                if (value == "1" || value == "S" || value == "STANDARD")
                {
                    return 0;
                }

                else if (value == "2" || value == "B" || value == "BUSINESS")
                {
                    return 1;
                }

                else if (value == "3" || value == "V" || value == "VIP")
                {
                    return 2;
                }

                else
                {
                    Console.WriteLine("Morate upisati 1 ili 2 ili 3!");
                    continue;
                }

            } while (true);
        }

        public static Guid GuidValidation(string message)
        {
            Console.Write(message);
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                Guid g = default;
                return g;
            }

            else if (!Guid.TryParse(value, out Guid ID))
            {
                Guid g = default;
                return g;
            }

            else return ID;
        }

        public static int ProductionValidation(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result < 2000 || result > 2025)
                    {
                        Console.WriteLine("Nemoguce da je napravljen te godine! Godina proizvodnje mora biti izmedu 2000 i 2025");
                        continue;
                    }
                    else return result;
                }
                else
                {
                    Console.WriteLine("Neispravan unos!");
                }
            }

        }

        public static int SeatValidation(string message, Category category)
        {

            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int result))
                {
                    if (result < 0)
                    {
                        Console.WriteLine("Nemoguce unijeti negativnu vrijednost");
                        continue;
                    }
                    else if (result > 20 && category == Category.VIP)
                    {
                        Console.WriteLine($"Previse sjedalica zelis unijeti za {category} kategoriju, 20 je maksimalno!");
                    }
                    else if (result > 50 && category == Category.Business)
                    {
                        Console.WriteLine($"Previse sjedalica zelis unijeti za {category} kategoriju, 50 je maksimalno!");
                    }
                    else if (result > 200 && category == Category.Standard)
                    {
                        Console.WriteLine("Previse sjedalica zelis unijeti, 200 je maksimalno!");
                        continue;
                    }
                    else return result;
                }
                else
                {
                    Console.WriteLine("Neispravan unos!");
                }
            }
        }

        public static DateTime FlightTimeValidation(string message, DateTime departureTime, DateTime arrivalTime = default)
        {
            string inputValue;

            while(true)
            {
                Console.Write(message);
                inputValue = Console.ReadLine();
                DateTime minTime = new DateTime(2010, 1, 1);

                if (string.IsNullOrEmpty(inputValue) && departureTime == DateTime.MinValue)
                    continue;

                else if (string.IsNullOrWhiteSpace(inputValue))
                {
                    return departureTime;
                }

                else if (DateTime.TryParseExact(inputValue, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime newTime))
                {
                    if (newTime < minTime)
                    {
                        Console.WriteLine("Vrijeme ne moze biti starije od 2010 godine!");
                        continue;
                    }
                    else if (arrivalTime == DateTime.MaxValue && newTime < departureTime)
                    {
                        Console.WriteLine("Vrijeme dolaska ne moze biti maje od vremena odlaska!");
                        continue;
                    }
                    else if (arrivalTime != DateTime.MaxValue && newTime > departureTime)
                        return newTime;
                    else return newTime;
                }

                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Neispravan format! Mora biti YYYY-MM-DD HH:mm!");
                    Console.WriteLine("");
                }
            }
        }

        public static bool AnswerValidation(string message)
        {
            Console.WriteLine("");
            string answer;
            bool answerCheck;

            while (true)
            {
                Console.Write(message);
                answer = Console.ReadLine().Trim().ToUpper();

                if (answer == "NE" || answer == "N")
                {
                    answerCheck = false;
                    return answerCheck;
                }

                else if (answer == "DA" || answer == "D")
                {
                    answerCheck = true;
                    return answerCheck;
                }

                else
                {
                    Console.WriteLine("Morate upisati DA ili NE!");
                    continue;
                }
            }
        }

        public static double DoubleValidation(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double result))
                {
                    if (result < 0)
                    {
                        Console.WriteLine("Neispravno je unijeti negativnu vrijednost!");
                        continue;
                    }
                    else return result;
                }
                else
                {
                    Console.WriteLine("Neispravan unos!");
                }
            }
        }
    }
}
