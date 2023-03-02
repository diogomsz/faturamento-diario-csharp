using System.Text.Json;

public class FaturamentoDiarioClass
{
    public static void Ler()
    {
        string fileName = "C:\\Users\\diogo\\OneDrive\\Ambiente de Trabalho\\project_dev\\dotnet_project\\target-sistemas\\target-sistemas\\dados.json";
        using StreamReader stream = new(fileName);
        string json = stream.ReadToEnd();
        List<Faturamento>? faturamento = JsonSerializer.Deserialize<List<Faturamento>>(json);

        double fMenor = faturamento.MinBy(x => x.valor).valor;
        Console.WriteLine($"Menor valor de faturamento: {fMenor:c}");

        double fMaior = faturamento.MaxBy(x => x.valor).valor;
        Console.WriteLine($"Maior valor de faturamento: {fMaior:c}");

        int dia = 0;
        int aux = 0;

        faturamento.ForEach(x =>
        {
            if (x.valor != 0.0)
            {
                aux++;
            }
        });

        double fMedia = faturamento.Sum(x => x.valor) / aux;

        faturamento.ForEach(x =>
        {
            if (x.valor > fMedia && x.valor != 0.0)
            {
                dia++;
            }
        });

        Console.WriteLine($"Quantidade de dias onde o valor é superior a média mensal: {dia}");
    }
}
