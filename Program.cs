using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        StreamReader? file1 = null; // Variável para leitura do primeiro arquivo informado
        StreamReader? file2 = null; // Variável para leitura do segundo arquivo informado

        try
        {
            Console.WriteLine("Seja bem vindo!!!");
            Console.WriteLine("Informe os caminhos dos dois arquivos de textos a serem comparados");
            
            var filePath = string.Empty;

            // Abre arquivo 1 para leitura
            Console.Write("Arquivo 1: ");
            filePath = Console.ReadLine();
            if(!File.Exists(filePath))
            {
                throw new Exception("ERRO - Não foi possivel encontrar o arquivo informado");
            }
            file1 = new StreamReader(filePath);

            // Abre arquivo 1 para leitura
            Console.Write("Arquivo 2: ");
            filePath = Console.ReadLine();
            if (!File.Exists(filePath))
            {
                throw new Exception("ERRO - Não foi possivel encontrar o arquivo informado");
            }
            file2 = new StreamReader(filePath);

            var file1Txt = new List<string>(file1.ReadToEnd().Split(Environment.NewLine)); // Array com as linhas do arquivo 1
            
            // Itera linha por linha do arquivo 2 verificando se existe alguma linha coincidente no arquivo 1
            var sb = new StringBuilder();
            var line = file2.ReadLine();
            while(line != null)
            {
                if(file1Txt.RemoveAll(x => x == line) > 0)
                {
                    sb.AppendLine(line);
                }

                line = file2.ReadLine();
            }

            // Gera terceiro arquivo e grava as interseções entre os dois primeiros
            var newFilePath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "intersecao.txt");
            var newFile = File.CreateText(newFilePath);
            newFile.Write(sb.ToString());
            newFile.Close();
            Console.WriteLine("Um arquivo com a interseção entre os arquivos foi gerada no seguinte caminho: " + newFilePath);
        }
        catch(Exception ex)
        { 
            Console.Error.WriteLine(ex.Message);
            Console.Error.WriteLine("Finalizando programa devido ao erro ocorrido, verifique as informações tente novamente mais tarde!");
        }
        finally
        {
            if (file1 != null) { file1.Close(); }
            if (file2 != null) { file2.Close(); }
        }


        Console.WriteLine("FIM DO PROGRAMA");
    }
}