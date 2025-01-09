using SQL_Exodus;
using SQL_Exodus.Services;
using static SQL_Exodus.Models.DatabasesEnum;

Console.WriteLine($"Selecione o tipo do banco de dados");

foreach (Databases database in Enum.GetValues(typeof(Databases)))
{
    Console.WriteLine($"{(int)database + 1}. {database}");
}

Console.Write("Digite: ");
string opcaoEscolhida = Console.ReadLine()?.Trim().ToLower(); ;

if (!int.TryParse(opcaoEscolhida, out int numeroEscolhido))
{
    Console.WriteLine("Opção Inválida!. Digite um número.");
    return;
}

numeroEscolhido--;
  
string userName = "";
string passWord = "";

switch ((Databases)numeroEscolhido)
{
    case Databases.SQL_Server_Local:
    case Databases.SQL_Server_Remote:
        Console.Write("Nome do servidor: ");
        string serverName = Console.ReadLine();

        Console.Write("Windows Authentication? 1 = Sim; 0 = Não(Default): ");
        string IsWindowsAuthentication = Console.ReadLine();
        bool windowsAuthentication = (IsWindowsAuthentication == "1");

        if (!windowsAuthentication)
        {
            Console.Write("Usuário: ");
            userName = Console.ReadLine();

            Console.Write("Senha: ");
            passWord = Helper.ReadPassword();
            Console.WriteLine();
        }

        SQLServer sqlServer = new SQLServer(serverName, windowsAuthentication, userName, passWord);
        if (sqlServer.FirstConnection())
        {
            Console.Clear();
            Console.WriteLine("Conexão estabelecida com sucesso!");

            sqlServer.databaseNames.ForEach(Console.WriteLine);

            Console.Write("Deseja fazer um filtro nos bancos? (Caso não queira, digite 0): ");
            string filter = Console.ReadLine();
            if (filter != "0")
            {
                sqlServer.databaseNames = sqlServer.databaseNames.Where(x => x.StartsWith(filter)).ToList();
                Console.Clear();
                Console.WriteLine("Bancos de dados filtrados");
                sqlServer.databaseNames.ForEach(Console.WriteLine);
            }
        }

        break;
    default:
        Console.WriteLine("A opção não foi encontrada");
        break;
}

Console.WriteLine("Digite qualquer tecla para sair...");
Console.ReadKey();