using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "x"){
                switch (opcaoUsuario){
                    case "1":
                        ListarSeries();
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
            
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
        }


        private static void ListarSeries(){
            System.Console.WriteLine("Listar series");

            var lista = repositorio.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }

            foreach(var serie in lista){
                var excluido = serie.retornaExcluido();
           
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(),serie.retornaTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static void InserirSerie(){
            Console.WriteLine("Inserir nova serie");
            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.Write("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Serie ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
                    
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie(){
            Console.WriteLine("Digite o id da Serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))){
                Console.Write("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o genêro entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo da Serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da Serie ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                        genero: (Genero) entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie,atualizarSerie);


        }

        private static void ExcluirSerie(){
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie(){
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie =  repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("DIO Series a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova Serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir Serie");
            Console.WriteLine("5- Visualizar Serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
