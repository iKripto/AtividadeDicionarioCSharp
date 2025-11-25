using System.Security;

var filmesRegistrados = new Dictionary<string, List<int>>();

void menu()
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1 - Adicionar filme");
    Console.WriteLine("2 - Listar filmes");
    Console.WriteLine("3 - Avaliar filme");
    Console.WriteLine("4 - Exibir média de um filme");
    Console.WriteLine("0 - Sair");
    var escolhaUsuario = Console.ReadLine()!;

    switch (escolhaUsuario)
    {
        case "1":
            adicionarFilme();
            break;
        case "2":
            listarFilmes();
            break;
        case "3":
            avaliarFilme();
            break;
        case "4":
            exibirMediaFilme();
            break;
        case "0":
            Console.WriteLine("Saindo...");
            return;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
}

void adicionarFilme()
{
    Console.Write("Digite o nome do filme: ");
    var nomeFilme = Console.ReadLine();
    filmesRegistrados.Add(nomeFilme!, new List<int>());
    Console.WriteLine($"Filme '{nomeFilme}' adicionado com sucesso!");
}

void listarFilmes()
{
    foreach (var filme in filmesRegistrados)
    {
        var avaliacoes = filme.Value;
        var mediaAvaliacao = avaliacoes.Count > 0 ? avaliacoes.Average() : 0;
        Console.WriteLine($"Filme: {filme.Key}, Avaliações: {avaliacoes.Count}, Média: {mediaAvaliacao:F2}");
    }
}
void avaliarFilme()
{
    Console.Write("Digite o nome do filme que deseja avaliar: ");
    var nomeFilme = Console.ReadLine();
    if (filmesRegistrados.ContainsKey(nomeFilme!))
    {
        Console.Write("Digite sua avaliação (0 a 10): ");
        var avaliacao = int.Parse(Console.ReadLine()!);
        filmesRegistrados[nomeFilme!].Add(avaliacao);
        Console.WriteLine($"Avaliação de {avaliacao} adicionada ao filme '{nomeFilme}'");
    }
    else
    {
        Console.WriteLine("Filme não encontrado.");
    }
}

void exibirMediaFilme()
{
    Console.Write("Digite o nome do filme para ver a média de avaliações: ");
    var nomeFilme = Console.ReadLine();
    if (filmesRegistrados.ContainsKey(nomeFilme!))
    {
        var avaliacoes = filmesRegistrados[nomeFilme!];
        var mediaAvaliacao = avaliacoes.Count > 0 ? avaliacoes.Average() : 0;
        Console.WriteLine($"Média de avaliações para '{nomeFilme}': {mediaAvaliacao:F2}");
    }
    else
    {
        Console.WriteLine("Filme não encontrado.");
    }
}