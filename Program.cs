
Estacionamento estacionamento = new Estacionamento();

string opcao = string.Empty; //string.Empty é a mesma coisa que ""
bool exibirMenu = true;

while (exibirMenu)
{
  Console.WriteLine("Sejá bem vindo ao PMB estacionamento.");
  Console.WriteLine();
  Console.WriteLine("Digite a opção desejada.");
  Console.WriteLine();
  Console.WriteLine("1 - Check-in de Veículo");
  Console.WriteLine("2 - Check-out de Veículo");  
  Console.WriteLine("3 - Listar veículo");
  Console.WriteLine();
  Console.WriteLine("4 - Encerrar");

  switch (Console.ReadLine())
  {
    case "1":
      Console.WriteLine("Digite a placa do veículo Check-in: ");
      string placaEntrada = Console.ReadLine();
      Console.WriteLine("Digite o nome do condutor:");
      string nomeCondutor = Console.ReadLine();
      estacionamento.EntradaVeiculo(placaEntrada, nomeCondutor);
      break;

    case "2":
      Console.WriteLine("Digite a placa do veículo Check-out");
      string saidaVeiculo = Console.ReadLine();
      double custo = estacionamento.SaidaVeiculo(saidaVeiculo); 
      Console.WriteLine($"Custo: {custo:C2}"); 
      break;

    case "3":
      estacionamento.ListarVeiculos();
      break;

    case "4":
      exibirMenu = false;
      break;
    
  
    default:
      Console.WriteLine("Opção inválida!");
      break;
  }

  Console.WriteLine("Precione Enter para prossegir");
  Console.ReadLine();
  
}

Console.WriteLine("O programa se encerrou!");
