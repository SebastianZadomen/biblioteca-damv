using System;

namespace BibliotecaDemo
{
    public static class Program
    {
        private const string ErrorNum = " Error: introdueix un número vàlid.";

        static string[] titols = new string[100];
        static string[] autors = new string[100];
        static int[] anys = new int[100];
        static int comptador = 0;

        public static void Main(string[] args)
        {
            const string MsgTitol = "=== SISTEMA DE GESTIÓ DE BIBLIOTECA ===";
            bool sortir = false;

            Console.WriteLine(MsgTitol);

            AfegirLlibre("El Quixot", "Cervantes", 1605);
            AfegirLlibre("1984", "Orwell", 1949);

            do
            {
                MostrarMenu();

                try
                {
                    int opcio;
                    bool validNum = int.TryParse(Console.ReadLine(), out opcio);
                    if (!validNum)
                    {
                        throw new FormatException(ErrorNum);
                    }

                    ProcessarOpcio(opcio, ref sortir);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperat: {ex.Message}");
                }

            } while (!sortir);

            Console.WriteLine("Adéu!");
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Mostrar llibres");
            Console.WriteLine("2. Cercar llibre");
            Console.WriteLine("3. Afegir llibre");
            Console.WriteLine("4. Estadístiques");
            Console.WriteLine("5. Sortir");
            Console.Write("Opció: ");
        }

        private static void ProcessarOpcio(int opcio, ref bool sortir)
        {
            switch (opcio)
            {
                case 1:
                    MostrarTotesLlibres();
                    break;

                case 2:
                    CercarLlibreConsola();
                    break;

                case 3:
                    AfegirLlibreConsola();
                    break;

                case 4:
                    MostrarEstadistiques();
                    break;

                case 5:
                    sortir = true;
                    break;

                default:
                    Console.WriteLine("Opció no vàlida.");
                    break;
            }
        }

        private static void CercarLlibreConsola()
        {
            try
            {
                Console.Write("Introdueix el títol: ");
                string titol = Console.ReadLine();

                int posicio = CercarLlibre(titol);

                if (posicio >= 0)
                {
                    Console.WriteLine($"\nTítol: {titols[posicio]}");
                    Console.WriteLine($"Autor: {autors[posicio]}");
                    Console.WriteLine($"Any: {anys[posicio]}");
                }
                else
                {
                    Console.WriteLine("Llibre no trobat.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void AfegirLlibreConsola()
        {
            bool flag = true;
            do
            {
                try
                {
                    Console.Write("Títol: ");
                    string titol = Console.ReadLine();

                    Console.Write("Autor: ");
                    string autor = Console.ReadLine();

                    int any;
                    bool validAny = false;

                    do
                    {
                        Console.Write("Any: ");
                        string entrada = Console.ReadLine();
                        validAny = int.TryParse(entrada, out any) && any > 0;
                        if (!validAny) Console.WriteLine(ErrorNum);

                    } while (!validAny);

                    AfegirLlibre(titol, autor, any);
                    flag = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    flag = true;

                }
            } while (flag);
        }

        private static void AfegirLlibre(string titol, string autor, int any)
        {
            titols[comptador] = titol;
            autors[comptador] = autor;
            anys[comptador] = any;
            comptador++;
            Console.WriteLine("Llibre afegit correctament");
        }

        private static int CercarLlibre(string titol)
        {
            for (int i = 0; i < comptador; i++)
                if (titols[i] == titol)
                    return i;
            return -1;
        }

        private static void MostrarTotesLlibres()
        {
            Console.WriteLine("\n=== CATÀLEG ===");
            for (int i = 0; i < comptador; i++)
                Console.WriteLine($"{i + 1}. {titols[i]} - {autors[i]} ({anys[i]})");
            Console.WriteLine($"\nTotal: {comptador}");
        }

        private static void MostrarEstadistiques()
        {
            if (comptador == 0)
            {
                Console.WriteLine("No hi ha llibres.");
                return;
            }

            int suma = 0;
            int antic = anys[0];
            int modern = anys[0];
            string titAntic = titols[0];
            string titModern = titols[0];

            for (int i = 0; i < comptador; i++)
            {
                suma += anys[i];
                if (anys[i] < antic)
                {
                    antic = anys[i];
                    titAntic = titols[i];
                }
                if (anys[i] > modern)
                {
                    modern = anys[i];
                    titModern = titols[i];
                }
            }

            Console.WriteLine("\n=== ESTADÍSTIQUES ===");
            Console.WriteLine($"Mitjana d'anys: {(double)suma / comptador:F1}");
            Console.WriteLine($"Més antic: {titAntic} ({antic})");
            Console.WriteLine($"Més modern: {titModern} ({modern})");
        }
    }
}