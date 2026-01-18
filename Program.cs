using System;

namespace ListaEnlazadaVehiculos
{
    // Clase vehículo
    class Vehiculo
    {
        public string Placa;
        public string Marca;
        public string Modelo;
        public int Año;
        public double Precio;
        public Vehiculo Siguiente;

        public Vehiculo(string placa, string marca, string modelo, int año, double precio)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Año = año;
            Precio = precio;
            Siguiente = null;
        }
    }

    class ListaVehiculos
    {
        private Vehiculo inicio;

        // Agregar vehículo
        public void Agregar(string placa, string marca, string modelo, int año, double precio)
        {
            Vehiculo nuevo = new Vehiculo(placa, marca, modelo, año, precio);

            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                Vehiculo aux = inicio;
                while (aux.Siguiente != null)
                {
                    aux = aux.Siguiente;
                }
                aux.Siguiente = nuevo;
            }
        }

        // Buscar por placa
        public void Buscar(string placa)
        {
            Vehiculo aux = inicio;
            while (aux != null)
            {
                if (aux.Placa == placa)
                {
                    Console.WriteLine($"Vehículo encontrado: {aux.Marca} {aux.Modelo} - Año {aux.Año}");
                    return;
                }
                aux = aux.Siguiente;
            }
            Console.WriteLine("Vehículo no encontrado.");
        }

        // Ver vehículos por año
        public void VerPorAño(int año)
        {
            Vehiculo aux = inicio;
            while (aux != null)
            {
                if (aux.Año == año)
                {
                    Console.WriteLine($"{aux.Placa} - {aux.Marca} {aux.Modelo}");
                }
                aux = aux.Siguiente;
            }
        }

        // Ver todos los vehículos
        public void MostrarTodos()
        {
            Vehiculo aux = inicio;
            while (aux != null)
            {
                Console.WriteLine($"{aux.Placa} - {aux.Marca} {aux.Modelo} - {aux.Año}");
                aux = aux.Siguiente;
            }
        }

        // Eliminar vehículo
        public void Eliminar(string placa)
        {
            if (inicio == null) return;

            if (inicio.Placa == placa)
            {
                inicio = inicio.Siguiente;
                Console.WriteLine("Vehículo eliminado.");
                return;
            }

            Vehiculo aux = inicio;
            while (aux.Siguiente != null)
            {
                if (aux.Siguiente.Placa == placa)
                {
                    aux.Siguiente = aux.Siguiente.Siguiente;
                    Console.WriteLine("Vehículo eliminado.");
                    return;
                }
                aux = aux.Siguiente;
            }

            Console.WriteLine("Vehículo no encontrado.");
        }
    }

    class Program
    {
        static void Main()
        {
            ListaVehiculos lista = new ListaVehiculos();

            lista.Agregar("ABC123", "Toyota", "Corolla", 2020, 15000);
            lista.Agregar("XYZ789", "Chevrolet", "Spark", 2019, 12000);

            lista.Buscar("ABC123");
            lista.VerPorAño(2020);
            lista.MostrarTodos();
            lista.Eliminar("XYZ789");

            Console.ReadKey();
        }
    }
}