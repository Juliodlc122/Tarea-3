using System;
using System.Collections.Generic;
//Julio Ruiz Matricula:2024-2009
class Program
{
    static List<Contacto> contactos = new List<Contacto>();
    static int nextId = 1;

    static void Main()
    {
        Console.WriteLine("Mi Agenda Perrón");
        Console.WriteLine("Bienvenido a tu lista de contactos");

        bool running = true;
        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Ver Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Modificar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Entrada inválida.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    ViewContacts();
                    break;
                case 3:
                    SearchContact();
                    break;
                case 4:
                    EditContact();
                    break;
                case 5:
                    DeleteContact();
                    break;
                case 6:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }
    }

    static void AddContact()
    {
        Console.WriteLine("Agregar nuevo contacto:");

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        contactos.Add(new Contacto(nextId++, nombre, telefono, email, direccion));

        Console.WriteLine("Contacto agregado correctamente.");
    }

    static void ViewContacts()
    {
        Console.WriteLine("Lista de Contactos:");
        Console.WriteLine("Id   Nombre   Teléfono   Email   Dirección");
        Console.WriteLine("-------------------------------------------------------");

        foreach (var contacto in contactos)
        {
            Console.WriteLine(contacto);
        }
    }

    static void SearchContact()
    {
        Console.Write("Ingrese el Id del contacto a buscar: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.");
        }
        else
        {
            Console.WriteLine("Contacto encontrado:");
            Console.WriteLine(contacto);
        }
    }

    static void EditContact()
    {
        Console.Write("Ingrese el Id del contacto a modificar: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.");
            return;
        }

        Console.WriteLine($"Nombre actual: {contacto.Nombre}");
        Console.Write("Nuevo Nombre (enter para no cambiar): ");
        string nombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nombre))
            contacto.Nombre = nombre;

        Console.WriteLine($"Teléfono actual: {contacto.Telefono}");
        Console.Write("Nuevo Teléfono (enter para no cambiar): ");
        string telefono = Console.ReadLine();
        if (!string.IsNullOrEmpty(telefono))
            contacto.Telefono = telefono;

        Console.WriteLine($"Email actual: {contacto.Email}");
        Console.Write("Nuevo Email (enter para no cambiar): ");
        string email = Console.ReadLine();
        if (!string.IsNullOrEmpty(email))
            contacto.Email = email;

        Console.WriteLine($"Dirección actual: {contacto.Direccion}");
        Console.Write("Nueva Dirección (enter para no cambiar): ");
        string direccion = Console.ReadLine();
        if (!string.IsNullOrEmpty(direccion))
            contacto.Direccion = direccion;

        Console.WriteLine("Contacto modificado exitosamente.");
    }

    static void DeleteContact()
    {
        Console.Write("Ingrese el Id del contacto a eliminar: ");
        int id;
        if (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Id inválido.");
            return;
        }

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.");
            return;
        }

        Console.WriteLine($"¿Seguro que quieres eliminar el contacto {contacto.Nombre}? (1=Sí, 2=No): ");
        int opcion;
        if (!int.TryParse(Console.ReadLine(), out opcion) || opcion != 1)
        {
            Console.WriteLine("Operación cancelada.");
            return;
        }

        contactos.Remove(contacto);
        Console.WriteLine("Contacto eliminado.");
    }
}

public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(int id, string nombre, string telefono, string email, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }

    public override string ToString()
    {
        return $"{Id}    {Nombre}    {Telefono}    {Email}    {Direccion}";
    }
}
