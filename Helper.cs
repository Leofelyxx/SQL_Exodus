using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Exodus
{
    internal class Helper
    {
        // Método para ler a senha sem exibir os caracteres
        public static string ReadPassword()
        {
            string password = "";
            while (true)
            {
                var key = Console.ReadKey(intercept: true); // Não exibe a tecla pressionada no console
                if (key.Key == ConsoleKey.Enter) // Quando pressionar Enter, finaliza
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace) // Para a tecla Backspace
                {
                    if (password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1); // Remove o último caractere
                        Console.Write("\b \b"); // Apaga o caractere do console
                    }
                }
                else
                {
                    password += key.KeyChar; // Adiciona o caractere digitado à senha
                    Console.Write("*"); // Exibe um asterisco para cada caractere digitado
                }
            }
            return password;
        }
    }
}
