using System;
using System.Collections.Generic;


//  Classe que representa um usuário no sistema
class Usuario
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }

    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }
}

class Cadastro
{
    // Criando a Lista que vai armazenar os usuários cadastrados
    static List<Usuario> usuarios = new List<Usuario>();

    static void Main()
    {
        int opcao;
        do
        {
            // Inicializa o Menu de opções do sistema
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Buscar Usuário");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");

            // Validação da opção digitada pelo usuário deve ser de 1 a 4 
            if (!int.TryParse(Console.ReadLine() ?? "0", out opcao))
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                continue;
            }

            // Começando a Execução da opção escolhida
            switch (opcao)
            {
                case 1:
                    CadastrarUsuario();
                    break;
                case 2:
                    ListarUsuarios();
                    break;
                case 3:
                    BuscarUsuario();
                    break;
                case 4:
                    Console.WriteLine("Saindo... Até a proxima execução !");
                    break;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        } while (opcao != 4);
    }

    // Metodo criado para cadastrar um novo usuario no sistema
    static void CadastrarUsuario()
    {
        Console.Write("Digite o nome: ");
        string nome = Console.ReadLine() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(nome))
        {
            Console.WriteLine("Nome não pode ser vazio! Cadastro cancelado.");
            return;
        }
        
        Console.Write("Digite o e-mail: ");
        string email = Console.ReadLine() ?? string.Empty;
        // Validando se o usuario digitou um e-mail que contenha informação ou o caracter @ para validar que é realmente o formado de um possivel e-mail.
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
        {
            Console.WriteLine("E-mail não pode ser vazio ou não foi digitado corretamente, siga o exemplo: (teste@gmail.com");
             Console.WriteLine("Cadastro cancelado!");
            return;
        }
        
        Console.Write("Digite a idade: ");
        if (!int.TryParse(Console.ReadLine() ?? "0", out int idade))
        {
            Console.WriteLine("Idade inválida! Cadastro cancelado.");
            return;
        }
        // Adicionando o usuário criado à lista
        usuarios.Add(new Usuario(nome, email, idade));
        Console.WriteLine("Usuário cadastrado com sucesso!");
    }
    // Metodo que lista todos os usuários cadastrados
    static void ListarUsuarios()
    {
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            return;
        }

        Console.WriteLine("\nLista de Usuários:");
        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"Nome: {usuario.Nome}, E-mail: {usuario.Email}, Idade: {usuario.Idade}");
        }
    }

    // Método para buscar um usuário pelo nome 
    static void BuscarUsuario()
    {
        Console.Write("Digite o nome do usuário para buscar: ");
        string nomeBusca = Console.ReadLine() ?? string.Empty;
        
        var usuario = usuarios.Find(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));
        
        if (usuario != null)
        {
            Console.WriteLine($"Usuário encontrado: Nome: {usuario.Nome}, E-mail: {usuario.Email}, Idade: {usuario.Idade}");
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
        }
    }
}
