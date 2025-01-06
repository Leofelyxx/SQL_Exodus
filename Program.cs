using SQL_Exodus.Models;

Console.WriteLine($"Selecione o tipo do banco de dados");

foreach (DatabasesEnum.Databases database in Enum.GetValues(typeof(DatabasesEnum.Databases)))
{
    Console.WriteLine($"{(int)database + 1}. {database}");
}

string opcaoEscolhida = Console.ReadLine();

//TODO: verificar a opção se é SQL Server

Console.WriteLine("Digite o nome do servidor:");
string serverName = Console.ReadLine();

Console.WriteLine("É Windows Authentication?. 1 = Sim; 0 = Não(Default)");
string IsWindowsAuthentication = Console.ReadLine();

if (IsWindowsAuthentication != "1")
{
    Console.WriteLine("Digite o nome do usuário: ");
    string userName = Console.ReadLine();

    Console.WriteLine("Digite a senha: ");
    string password = ReadPassword();
}


// Método para ler a senha sem exibir os caracteres
static string ReadPassword()
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