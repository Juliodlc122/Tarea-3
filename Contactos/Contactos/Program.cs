﻿using System;
using System.Collections.Generic;
//Julio Ruiz Matricula:2024-2009
class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido a mi lista de Contactes");

        bool runing = true;
        List<int> ids = new List<int>();
        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> telephones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        while (runing)
        {
            Console.WriteLine(@"
1. Agregar Contacto
2. Ver Contactos
3. Buscar Contactos
4. Modificar Contacto
5. Eliminar Contacto
6. Salir");

            Console.WriteLine("Digite el número de la opción deseada");

            int typeOption = Convert.ToInt32(Console.ReadLine());

            switch (typeOption)
            {
                case 1:
                    AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 2:
                    ViewContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 3:
                    SearchContact(ids, names, lastnames);
                    break;

                case 4:
                    ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 5:
                    DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 6:
                    runing = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el nombre de la persona");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la dirección");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el teléfono de la persona");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona");
        string email = Console.ReadLine();
        Console.WriteLine("Digite la edad de la persona en números");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Es mejor amigo? (1 = Sí, 2 = No)");
        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        int id = ids.Count + 1;
        ids.Add(id);
        names[id] = name;
        lastnames[id] = lastname;
        addresses[id] = address;
        telephones[id] = phone;
        emails[id] = email;
        ages[id] = age;
        bestFriends[id] = isBestFriend;
    }

    static void ViewContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Nombre\tApellido\tDirección\tTeléfono\tEmail\tEdad\t¿Mejor Amigo?");
        Console.WriteLine("--------------------------------------------------------------------------------");

        foreach (var id in ids)
        {
            string best = bestFriends[id] ? "Sí" : "No";
            Console.WriteLine($"{names[id]}\t{lastnames[id]}\t{addresses[id]}\t{telephones[id]}\t{emails[id]}\t{ages[id]}\t{best}");
        }
    }

    static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames)
    {
        Console.WriteLine("Digite el nombre o apellido a buscar:");
        string searchTerm = Console.ReadLine().ToLower();
        bool found = false;

        foreach (var id in ids)
        {
            if (names[id].ToLower().Contains(searchTerm) || lastnames[id].ToLower().Contains(searchTerm))
            {
                Console.WriteLine($"ID: {id} - {names[id]} {lastnames[id]}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No se encontró ningún contacto con ese nombre o apellido.");
        }
    }

    static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el ID del contacto que desea modificar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("ID no encontrado.");
            return;
        }

        Console.WriteLine("Digite el nuevo nombre:");
        names[id] = Console.ReadLine();
        Console.WriteLine("Digite el nuevo apellido:");
        lastnames[id] = Console.ReadLine();
        Console.WriteLine("Digite la nueva dirección:");
        addresses[id] = Console.ReadLine();
        Console.WriteLine("Digite el nuevo teléfono:");
        telephones[id] = Console.ReadLine();
        Console.WriteLine("Digite el nuevo email:");
        emails[id] = Console.ReadLine();
        Console.WriteLine("Digite la nueva edad:");
        ages[id] = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("¿Es mejor amigo? (1 = Sí, 2 = No)");
        bestFriends[id] = Convert.ToInt32(Console.ReadLine()) == 1;

        Console.WriteLine("Contacto modificado exitosamente.");
    }

    static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el ID del contacto a eliminar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("ID no encontrado.");
            return;
        }

        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("Contacto eliminado exitosamente.");
    }
}