using System;
using System.IO;
namespace EditorDeTexto
{
    class Program
    {
        
        public static void Main(string[]args)
        {
            Menu();
        }
        static void Menu(){
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo.");
            Console.WriteLine("2 - Criar novo arquivo.");
            Console.WriteLine("0 - Sair");
            short option=short.Parse(Console.ReadLine());
            switch (option)
            {
                case (short)EOption.Close:Close();break;
                case (short)EOption.Open:Open();break;
                case (short)EOption.Create:Create();break;
                default:Menu();break;
            }
        }
        static void Salvar(string text){
            Console.Clear();
            Console.WriteLine("Qual Caminho para salvar o arquivo?");
            var path=Console.ReadLine();
            using (var file=new StreamWriter(path))
            {
                file.Write(text);   
            }
            Console.WriteLine($"Arquivo {path} salvo com sucesso!!");
           Console.ReadLine();
            Menu();
        }
        static void Open(){
            Console.Clear();
            Console.WriteLine("Qual Caminho para salvar o arquivo?");
            var path=Console.ReadLine();
            using (var file=new StreamReader(path))
            {
               var text=file.ReadToEnd();
               Console.WriteLine(text);      
            }
            Console.WriteLine();
            Console.ReadLine();
            Menu();
        }
        static void Close(){
            System.Environment.Exit(0);
        }
        static void Create(){
            Console.Clear();
            Console.WriteLine("Digite o seu texto abaixo [ESC para sair]");
            Console.WriteLine("-------------------------");
            string text="";
            do
            {
                text+=Console.ReadLine();
                text+=Environment.NewLine;
            }
            while (Console.ReadKey().Key!=ConsoleKey.Escape);
            Salvar(text);
        }

        enum EOption{
            Close=0,
            Open=1,
            Create=2
            
        }
    }
    
}