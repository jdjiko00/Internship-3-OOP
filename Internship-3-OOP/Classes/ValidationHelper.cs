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

        public static DateOnly DateOfBirthValidation(string message)
        {
            string value;
            do
            {
                Console.Write(message);
                value = Console.ReadLine();

                if (DateOnly.TryParseExact(value, "yyyy-MM-dd", out DateOnly date))
                {
                    return date;
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

        public static DateTime FlightTimeValidation(string message, DateTime departureTime, DateTime arrivalTime = default)
        {
            Console.WriteLine("");
            if (arrivalTime == default)
                arrivalTime = DateTime.MaxValue;
            string inputValue;

            while(true)
            {
                Console.Write(message);
                inputValue = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputValue))
                {
                    return departureTime;
                }

                else if (DateTime.TryParseExact(inputValue, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime newTime))
                {
                    if (arrivalTime == DateTime.MaxValue)
                        return newTime;
                    else if (arrivalTime != DateTime.MaxValue && newTime > departureTime)
                        return newTime;
                    else Console.WriteLine("Vrijeme dolaska ne moze biti prije od vremana polaska");
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
    }
}
