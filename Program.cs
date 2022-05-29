using System.Diagnostics;
class Program
{
    class User
    {
        public class Name
        {
            public string FirstName;
            public string LastName;
            public string? MiddleName;

            public bool AlphabeticalTest(string s)
            {
                foreach (char c in s)
                {
                    if (!((int)c > 96 && (int)c < 123 || (int)c > 64 && (int)c < 91 || s == null)) return false; ;
                }
                return true;
            }

            public void CreateName()
            {
                Console.WriteLine("Please input the first name: ");
                do { FirstName = Console.ReadLine(); } while (!AlphabeticalTest(FirstName));

                Console.WriteLine("\nNow, if the subject has a middle name, enter it, if not, press enter:");
                do { MiddleName = Console.ReadLine(); } while (!AlphabeticalTest(MiddleName));

                Console.WriteLine("\nPlease enter the subject's last name:");
                do { LastName = Console.ReadLine(); } while (!AlphabeticalTest(LastName));
            }

            public string GetConsoleString()
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }

            public void TestName()
            {
                Debug.Assert(AlphabeticalTest("azAZ"));
                Debug.Assert(AlphabeticalTest("abcdefghijklmnopqrstuvwxyz"));
                Debug.Assert(!AlphabeticalTest("12dadas"));
                Debug.Assert(!AlphabeticalTest("{}?ASF}"));
            }

        }
        public class CreditCard
        {
            public class Number
            {
                public string CardNumber;
                bool ProperInputTest(string s)
                {
                    if (s.Length != 19) return false;

                    for (int i = 0; i < s.Length; i++)
                    {
                        if (i == 4 || i == 9 || i == 14)
                        {
                            if (s[i] != ' ') return false;
                        }
                        else if (!((int)s[i] > 47 && (int)s[i] < 58)) return false;
                    }
                    return true;
                }

                public void TestNumber()
                {
                    Debug.Assert(ProperInputTest("1234 4566 8901 1213"));
                    Debug.Assert(!ProperInputTest("12344566 8901  1213"));
                    Debug.Assert(!ProperInputTest("1234456689011213"));
                    Debug.Assert(!ProperInputTest("sdfs 1234 adsd 13da"));
                    Debug.Assert(!ProperInputTest("1234 1234 1234 5678 1892"));
                }

                public void CreateNumber()
                {
                    Console.Clear();
                    Console.WriteLine("\nNow please input the credit card number, it should be composed of 16 numberes with a space every 4 digits");
                    do { CardNumber = Console.ReadLine(); } while (!ProperInputTest(CardNumber));
                }

                public string GetConsoleString()
                {
                    return CardNumber;
                }
            }

            public class ExpirationDate 
            {
                public string Day;
                public string Month;

                public bool ProperInputTest(string s, bool IsMonth)
                {
                    if (IsMonth) 
                    {
                        if (int.Parse(s) > 0 && int.Parse(s) < 13) return true;
                        else return false;
                    }
                    if (!IsMonth) 
                    {
                        if (int.Parse(s) > 0 && int.Parse(s) < 32) return true;
                        else return false;
                    }
                    return false;
                }

                public void TestExpirationDate()
                {
                    Debug.Assert(ProperInputTest("1", true));
                    Debug.Assert(ProperInputTest("12", true));
                    Debug.Assert(!ProperInputTest("13", true));

                    Debug.Assert(ProperInputTest("1", false));
                    Debug.Assert(ProperInputTest("31", false));
                    Debug.Assert(!ProperInputTest("32", false));
                    Debug.Assert(!ProperInputTest("0", false));
                }
                
                public void CreateEpirationDate()
                {
                    Console.WriteLine("\nNow, please input the expiration date of the card starting by the month:");
                    do { Month = Console.ReadLine(); } while (!ProperInputTest(Month, true));

                    Console.WriteLine("\nPlease input the day in which it is expiring:");
                    do { Day = Console.ReadLine(); } while (!ProperInputTest(Day, false));
                }
                
                public string GetConsoleString()
                {
                    return $"{Month}/{Day}";
                }
            }

            public class CVV
            {
                public string Number;

                public bool ProperInputTest(string s)
                {
                    if (s.Length != 3) return false;

                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!((int)s[i] > 47 && (int)s[i] < 58)) return false;
                    }
                    return true;
                }

                public void TestCVV()
                {
                    Debug.Assert(ProperInputTest("050"));
                    Debug.Assert(!ProperInputTest("1234"));
                    Debug.Assert(!ProperInputTest("a34"));
                    Debug.Assert(!ProperInputTest("{}xa3"));
                }

                public void CreateCVV()
                {
                    Console.WriteLine("\nPlease input the 3-digit CVV:");
                    do { Number = Console.ReadLine(); } while (!ProperInputTest(Number));
                }

                public string GetConsoleString()
                {
                    return Number;
                }
            }
        }
    }

    public static void TestAll()
    {
        User.Name irrelevantVariable1 = new User.Name();
        irrelevantVariable1.TestName();

        User.CreditCard.Number irrelevantVariable2 = new User.CreditCard.Number();
        irrelevantVariable2.TestNumber();

        User.CreditCard.ExpirationDate irrelevantVariable3 = new User.CreditCard.ExpirationDate();
        irrelevantVariable3.TestExpirationDate();

        User.CreditCard.CVV irrelevantVariable4 = new User.CreditCard.CVV();
        irrelevantVariable4.TestCVV();
    }

    static void Main()
    {
        TestAll();
        Console.Clear();
        Console.WriteLine("Hello user! This program will let you create a human subject and define their name as well as their crdit card information (a little weird ngl)");
        Console.WriteLine("\nPress any key to begin.");
        ConsoleKey irrelevantVariable5 = Console.ReadKey(true).Key;
        Console.Clear();

        User.Name Name = new User.Name();
        Name.CreateName();

        User.CreditCard.Number CardNumber = new User.CreditCard.Number();
        CardNumber.CreateNumber();

        User.CreditCard.ExpirationDate ExpirationDate = new User.CreditCard.ExpirationDate();
        ExpirationDate.CreateEpirationDate();

        User.CreditCard.CVV CVV = new User.CreditCard.CVV();
        CVV.CreateCVV();

        Console.Clear();
        Console.WriteLine("Here is the information of the subject you just created:\n");
        Console.WriteLine("Full name: "+Name.GetConsoleString()+"\n");
        Console.WriteLine("Credit Card information: ");
        Console.WriteLine("\nNumber: "+CardNumber.GetConsoleString());
        Console.WriteLine("Expiration date: "+ExpirationDate.GetConsoleString());
        Console.WriteLine($"CVV: "+CVV.GetConsoleString()+"\n\n");


        //Console.WriteLine(g.GetConsoleString());
    }
}