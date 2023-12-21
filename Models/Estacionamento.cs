 using System.Text.RegularExpressions;
  public class Estacionamento
  {
    private struct Registro{
        public DateTime HoraEntrada;
        public string NomeCondutor;
    }
    private Dictionary <string, Registro> checkIns = new Dictionary<string, Registro>();
    private double taxaPorHora = 5.00;

    // Valida se a placa tem o formato correto
    public bool PlacaValida(string placa)
    {
      return Regex.IsMatch(placa, @"^[A-Z]{3}\d{1}[A-Z]{1}\d{2}$");
    }

   public void EntradaVeiculo(string placa, string nomeCondutor)
   {
    if(!PlacaValida(placa)){
        Console.WriteLine("ERRO: A placa do veículo é inválida.");
        return;
    }

    if( string.IsNullOrWhiteSpace(nomeCondutor)){
        Console.WriteLine("ERRO: O nome do condutor não foi fornecido.");
        return;
    }
    Registro registro = new Registro();
    registro.HoraEntrada = DateTime.Now;
    registro.NomeCondutor = nomeCondutor;

    checkIns [placa] = registro;;    
   }

   public double SaidaVeiculo(string placa)
   {
    if(!checkIns.ContainsKey(placa))
    {
        Console.WriteLine("ERRO: Veiculo não encontrado");
        return 0;
    }

    Registro registro = checkIns[placa];
    double horasNoEstacionamento = (DateTime.Now - registro.HoraEntrada).TotalHours;

    double custo = horasNoEstacionamento * taxaPorHora;

    Console.WriteLine($"O custo para o veículo {placa}, conduzido por {registro.NomeCondutor}, é {custo:C2}");

    checkIns.Remove(placa);

    return custo;
   }

    public void ListarVeiculos()
    {
      if (checkIns.Count ==0)
      {  
        Console.WriteLine("Nenhum veículo estacionado no momento.");  
        return;        
      }

      Console.WriteLine("Veículos estacionados:");
      foreach (var veiculo in checkIns)
      {
        Console.WriteLine($"Placa: {veiculo.Key}, Data e Hora de entrada: {veiculo.Value.HoraEntrada}, Nome do Condutor: {veiculo.Value.NomeCondutor}");
      }
      
    }
  }
