
namespace myGuestbook
{
    class Program
    {
        static void Main(string[] args)
        {

            GuestBook guestbook = new GuestBook();
            int i = 0;

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.WriteLine("G Ä S T B O K\n\n");

                Console.WriteLine("1. Skriv inlägg");
                Console.WriteLine("2. Ta bort inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                i = 0;
                foreach (Post post in guestbook.getPosts())
                { // List all cars in carstore
                    Console.WriteLine("[" + i++ + "] " + post.Name + " - " + post.Inlagg);
                }

                int inp = (int)Console.ReadKey(true).Key;
                switch (inp)
                {
                    case '1':
                        Console.CursorVisible = true;
                        string? name = null;
                        bool nameContainsDigits = false;
                        string? inlagg = null;

                        // Loop för att fortsätta be om ett giltigt namn som inte är tomt eller inte innehåller siffror
                        while (string.IsNullOrEmpty(name) || nameContainsDigits)
                        {
                            Console.Write("Ange namn: ");
                            name = Console.ReadLine();

                            // Kontrollera om namnet innehåller siffror
                            nameContainsDigits = name != null && name.Any(char.IsDigit);

                            if (string.IsNullOrEmpty(name))
                            {
                                Console.WriteLine("Skriv in ett namn.");
                            }
                            else if (nameContainsDigits)
                            {
                                Console.WriteLine("Namnet får inte innehålla siffror.");
                            }
                        }

                        // Loop för att fortsätta be om ett giltigt inlägg
                        while (string.IsNullOrEmpty(inlagg))
                        {
                            Console.Write("Skriv inlägg: ");
                            inlagg = Console.ReadLine();

                            // Kontrollera om inlägget är giltigt,dvs inte är tomt eller null
                            if (string.IsNullOrEmpty(inlagg))
                            {
                                Console.WriteLine("Inlägget får inte vara tomt.");
                            }
                        }

                        // Lägg till inlägg i gästboken
                        guestbook.addPost(name, inlagg);
                        break;



                    case '2':
                        Console.CursorVisible = true;
                        Console.Write("Ange index att radera: ");
                        string? index = Console.ReadLine();
                        if (!String.IsNullOrEmpty(index))
                            try
                            {
                                guestbook.delPost(Convert.ToInt32(index));
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Index out of range!\nPress button to proceed.");
                                Console.ReadKey();
                            }
                        break;
                    case 88:
                        Environment.Exit(0);
                        break;
                }

            }

        }
    }
}