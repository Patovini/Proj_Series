using System;

namespace Dio.projUm
{
    class Program
    {   

        static SerieRepositorioo repositorio = new SerieRepositorioo(); 
        static void Main(string[] args)
        {       
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                    break;

                    case "2":
                        InserirSerie();
                    break;

                    case "3":
                        AtualizarSerie();
                    break;

                    case "4":
                        ExcluirSerie();
                    break;

                    case "5":
                        VisualizarSerie();
                    break;

                    case "C":
                        Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }    

            Console.WriteLine("Obrigado por utilizar nosso APP");
            Console.ReadLine();       
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar Serie");

            var lista = repositorio.Lista();

            if(lista.Count == 0) // if vai verificar se a lista esta vazia
            {
                Console.WriteLine("nenhuma serie cadastrada.");
                return;
            }

            foreach (var serie in lista) // ele vai verificar na var lista e jogar dentro da variavel serie
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova serie");

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-5.0
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-5.0

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
        
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Serie:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
        

            repositorio.Insere(novaSerie);
        }
        
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da Serie");
            int indiceSerie = int.Parse(Console.ReadLine());

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=net-5.0
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=net-5.0

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
        
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano da Serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da Serie:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
        

            repositorio.Atualiza(indiceSerie, atualizarSerie);
        }

        private static void ExcluirSerie()
        {   
            Console.WriteLine("digite a Serie que deseja excluir");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite a o numero da serie para ver");
            int indiceSerie = int.Parse(Console.ReadLine());

            var verSerie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(verSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Serie.com ao seu dispor");
            Console.WriteLine("Informe a opção desejada: ");
            
            Console.WriteLine("1- lista serie");
            Console.WriteLine("2- Insira uma serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

   
    
    }
    
}
