using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio=new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario= ObterOpcaoUsuario();
            
            while(opcaoUsuario.ToUpper()!="X")
            {
                switch(opcaoUsuario)
                {
                    case("1"):

                    ListarSeries();

                    break;
                    case("2"):

                    InserirSerie();

                    break;
                    case("3"):

                    AtualizarSerie();

                    break;
                    case("4"):

                    ExcluirSerie();

                    break;
                    case("5"):

                    VisualizarSerie();

                    break;
                    case("C"):

                    Console.Clear();

                    break;
                    case("X"):
                    break;
                    default:
                    throw new ArgumentOutOfRangeException("escolha errada, por favor reabra o projeto e tente novamente.");
                    
                }
                opcaoUsuario= ObterOpcaoUsuario();
            }
            



        }
        private static void ListarSeries()
        {
            var lista=repositorio.Lista();
            if(lista.Count==0)
            {
                Console.WriteLine("não há nenhuma lista no momento");
                return;
            }
            foreach(var serie in lista)
            {
                var excluido=serie.RetornaExcluido();
                Console.WriteLine("#ID: {0}:-{1} - {2}",serie.RetornaId(),serie.RetornaTitulo(), (excluido ? "Excluido":""));
            }
        }
        private static string ObterOpcaoUsuario()
            {
                Console.WriteLine();
                Console.WriteLine("DIO estudo de séries");
                Console.WriteLine("por favor, informe a informação desejada");
                Console.WriteLine("1- Listar suas séries");
                Console.WriteLine("2- inserir nova série");
                Console.WriteLine("3- atualizar uma série");
                Console.WriteLine("4- Excluir uma série");
                Console.WriteLine("5- Visualizar informações da Série");
                Console.WriteLine("C- Limpar tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();
                String opcaoUsuario= Console.ReadLine().ToUpper();
                return opcaoUsuario;
            }
        private static Serie CadastrarSerie(int id)
        {
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}",i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o gênero dentre as opções acima: ");
            Console.WriteLine();
            int entradaGenero=int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o título da série");
            Console.WriteLine();
            string entradaTitulo=Console.ReadLine();
            Console.WriteLine("Digite o ano de início da série");
            int entradaAno=int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a descrição da série");
            string entraDescricao=Console.ReadLine();
            Serie novaSerie=new Serie( 
                                    id :id,
                                    genero : (Genero)entradaGenero,
                                    titulo : entradaTitulo,
                                    ano : entradaAno,
                                    descricao : entraDescricao
            );
            return novaSerie;
        }
        private static void InserirSerie()
        {
            Console.WriteLine("inserção de nova série:");
            repositorio.Insere(CadastrarSerie(repositorio.ProximoId()));
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("digite o ID da serie a ser atualizada: ");
            int idSerie=int.Parse(Console.ReadLine());
            if (!repositorio.PesquisarId(idSerie))
            {
                Console.WriteLine("número errado. Atualização não sucedida");
                return;
            }
            repositorio.Atualiza(idSerie,CadastrarSerie(idSerie));

        }
        private static void ExcluirSerie()
        {
            Console.WriteLine("digite o ID da serie a ser excluída: ");
            int idSerie=int.Parse(Console.ReadLine());
            if (!repositorio.PesquisarId(idSerie))
            {
                Console.WriteLine("número errado. Exclusão não sucedida");
                return;
            }
            repositorio.Exclui(idSerie);
        }
        private static void VisualizarSerie()
        {
            Console.WriteLine("digite o ID da serie: ");
            int idSerie=int.Parse(Console.ReadLine());
            if (!repositorio.PesquisarId(idSerie))
            {
                Console.WriteLine("número errado. Visualização não sucedida");
                return;
            }
            var serie=repositorio.RetornaPorId(idSerie);
            Console.WriteLine(serie);

        }
    }
}
