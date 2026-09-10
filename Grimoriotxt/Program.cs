namespace Grimoriotxt;

using System.IO;
public class Program
{
    public static void Main()
    {
        string path = @"C:\repositorioC#\Grimoriotxt\saveGrimorio.txt";
        List<string> magics = new List<string>();
        if (File.Exists(path))
        {
           magics.AddRange(File.ReadAllLines(path));
        }
        
        
        while (true)
        {
            Console.WriteLine("\n==== MENU DE GRIMORIO ====\n");
            Console.WriteLine("1. Adicionar Magia");
            Console.WriteLine("2. Remover Magia");
            Console.WriteLine("3. Ver Magias");
            Console.WriteLine("4. Salvar e Fechar Menu");
            Console.WriteLine("\n Escolha sua opção: \n");
            int choice = Convert.ToInt32(Console.ReadLine());
            bool magicExist = false;
            bool magicRemoved = false;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nDigite o nome da magia que deseja adicionar: ");
                    string magicAdd = Console.ReadLine();
                    foreach (string magic in magics)
                    {
                        if (magic == magicAdd)
                        {
                            magicExist = true;
                        }
                    }
                    if (!magicExist)
                    {
                        magics.Add(magicAdd);
                        Console.WriteLine("Magia adicionada com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Magia já existe!");
                    }
                    break;
                case 2:
                    if (magics.Count == 0)
                    {
                        Console.WriteLine("Não há magia para remover!");
                    }
                    else
                    {
                        Console.WriteLine("Digite o nome da magia que deseja remover");
                        string magicRemove = Console.ReadLine();
                        for (int i = 0; i < magics.Count; i++)
                        {
                            if (magicRemove == magics[i])
                            {
                                magics.Remove(magics[i]);
                                magicRemoved = true;
                            }
                        }
                        if (magicRemoved)
                        {
                            Console.WriteLine("Magia removida com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Magia não encontrada!");
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("\n======Magias disponíveis=======\n");
                    if (magics.Count == 0)
                    {
                        Console.WriteLine("Não possui magias atualmente!");
                    }
                    else
                    {
                        for (int i = 0; i < magics.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {magics[i]}");
                        }
                    }
                    break;
                case 4:
                    File.WriteAllLines(path, magics);
                    Console.WriteLine("Magias salvas!");
                    Console.WriteLine("\nFechando grimório...");
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente!");
                    break;
            }
        }
        
    }
}
