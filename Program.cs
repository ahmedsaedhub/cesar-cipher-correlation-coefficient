using System;
using caesar_cipher_igsr.lib;

namespace caesar_cipher_igsr {
    class Program {
        static void Main (string[] args) {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine ("-----------------------------------");
            Console.WriteLine (":: Cesar Cipher Encryption Center ::");
            Console.WriteLine ("-----------------------------------");

            MenuFlow ();
        }

        private static void MenuFlow () {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine ("(1) Encrypt New Text");
            Console.WriteLine ("(2) Text Decryption");
            Console.WriteLine ("--------");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine ("Select Function:");

            string selectedFunction = Console.ReadLine ();
            switch (selectedFunction) {
                case "1":
                    {
                        EncryptionFlow ();
                        break;
                    }
                case "2":
                    {
                        DecryptionFlow ();
                        break;
                    }
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine ("Invalid Selection!");
                        MenuFlow ();
                        break;
                    }
            }
        }
        private static void EncryptionFlow () {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine ("Enter Plain Text: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string plainText = Console.ReadLine ();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine ("Enter Encryption Key: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            int encryptionKey;
            if (!int.TryParse (Console.ReadLine (), out encryptionKey)) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine ("Invalid Key!");
                MenuFlow ();
            }
            Console.WriteLine (encryptionKey);
            var caesarEncyption = new CaesarCypherEncyption ();
            string encryptedText = caesarEncyption.EncryptText (plainText, encryptionKey);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine ("Encrypted Text Is: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine (encryptedText);
            MenuFlow ();
        }

        private static void DecryptionFlow () {
            var caesarEncyption = new CaesarCypherEncyption ();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine ("Enter Encrypted Text: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string text = Console.ReadLine ();

            // get key and resolve encrypted text
            int key = caesarEncyption.DetectCypherKey (text);
            string OriginalText = caesarEncyption.DecryptText (text, key);

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine ("Detected Key Is: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine (key);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine ("Original Text Is: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine (OriginalText);
            MenuFlow ();
        }
    }
}