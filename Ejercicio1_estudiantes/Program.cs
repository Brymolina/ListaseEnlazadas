using System;

namespace ListaEnlazadaEstudiantes
{
    // Clase que representa al estudiante
    class Estudiante
    {
        public string Cedula;
        public string Nombre;
        public string Apellido;
        public string Correo;
        public int Nota;
        public Estudiante Siguiente;

        public Estudiante(string cedula, string nombre, string apellido, string correo, int nota)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Nota = nota;
            Siguiente = null;
        }
    }

    // Clase lista enlazada
    class ListaEstudiantes
    {
        private Estudiante inicio;

        // Agregar estudiante según su nota
        public void Agregar(string cedula, string nombre, string apellido, string correo, int nota)
        {
            Estudiante nuevo = new Estudiante(cedula, nombre, apellido, correo, nota);

            // Si la lista está vacía
            if (inicio == null)
            {
                inicio = nuevo;
                return;
            }

            // Aprobados al inicio
            if (nota >= 7)
            {
                nuevo.Siguiente = inicio;
                inicio = nuevo;
            }
            // Reprobados al final
            else
            {
                Estudiante aux = inicio;
                while (aux.Siguiente != null)
                {
                    aux = aux.Siguiente;
                }
                aux.Siguiente = nuevo;
            }
        }

        // Buscar estudiante por cédula
        public void Buscar(string cedula)
        {
            Estudiante aux = inicio;
            while (aux != null)
            {
                if (aux.Cedula == cedula)
                {
                    Console.WriteLine($"Estudiante encontrado: {aux.Nombre} {aux.Apellido} - Nota: {aux.Nota}");
                    return;
                }
                aux = aux.Siguiente;
            }
            Console.WriteLine("Estudiante no encontrado.");
        }

        // Eliminar estudiante
        public void Eliminar(string cedula)
        {
            if (inicio == null) return;

            if (inicio.Cedula == cedula)
            {
                inicio = inicio.Siguiente;
                Console.WriteLine("Estudiante eliminado.");
                return;
            }

            Estudiante aux = inicio;
            while (aux.Siguiente != null)
            {
                if (aux.Siguiente.Cedula == cedula)
                {
                    aux.Siguiente = aux.Siguiente.Siguiente;
                    Console.WriteLine("Estudiante eliminado.");
                    return;
                }
                aux = aux.Siguiente;
            }

            Console.WriteLine("No se encontró el estudiante.");
        }

        public void ContarAprobadosReprobados()
        {
            int aprobados = 0, reprobados = 0;
            Estudiante aux = inicio;

            while (aux != null)
            {
                if (aux.Nota >= 7)
                    aprobados++;
                else
                    reprobados++;
                aux = aux.Siguiente;
            }

            Console.WriteLine($"Total aprobados: {aprobados}");
            Console.WriteLine($"Total reprobados: {reprobados}");
        }
    }

    class Program
    {
        static void Main()
        {
            ListaEstudiantes lista = new ListaEstudiantes();

            lista.Agregar("0101", "Pedro", "Vilela", "pedro@gmail.com", 8);
            lista.Agregar("0102", "Ana", "Conde", "ana@gmail.com", 6);
            lista.Agregar("0103", "Bryan", "Molina", "bryan@gmail.com", 9);

            lista.Buscar("0102");
            lista.ContarAprobadosReprobados();
            lista.Eliminar("0101");

            Console.ReadKey();
        }
    }
}