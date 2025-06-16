

//Alumno
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

public class Alumno : Iorientadores
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public bool Experiencia { get; set; }
    public int MesesDePractica { get; set; }

    public Alumno(string nombre, int edad, bool exp, int tiempo)
    {
        this.Nombre = nombre;
        this.Edad = edad;
        this.Experiencia = exp;
        this.MesesDePractica = tiempo;
    }

    public void Graduacion()
    {
        if (MesesDePractica >= 12)
        {
           Console.WriteLine($" {Nombre} es cinturon GRIS");
        } else if (MesesDePractica >= 9)
        {
            Console.WriteLine($" {Nombre} es cinturon VERDE");
        }
        else if (MesesDePractica > 6)
        {
            Console.WriteLine($" {Nombre} es cinturon NARANJA");
        }
        else if (MesesDePractica >= 3)
        {
             Console.WriteLine($" {Nombre} es cinturon AMARILLO");
        }
        else
        {
            Console.WriteLine($" {Nombre} es cinturon BLANCO");
        }
    }

    public void Entrenar()
    {
        Console.WriteLine($" {Nombre} esta entrenando");
       MesesDePractica++;
    }

    public virtual void Compensatorio()
    {
            Console.WriteLine($" {Nombre} no puede hacer un compensatorio porque no es instructor");     
    }

} 

public class Instructor : Alumno
{
    private int _compensatorios;

    public int CompensatoriosRealizados
    {
        get { return _compensatorios; }
    }

    public string CompHechos
    {
        get { return $"{Nombre} hizo {_compensatorios} compensatorios"; }
    }

   public Instructor(string nombre, int edad, bool exp) : base(nombre, edad, exp, 12)
    {
        this._compensatorios = 0;
    }
    public void Enseñar()
    {
        Console.WriteLine($" {Nombre} esta enseñando");
    }
    public override void Compensatorio()
    {
        _compensatorios++;
        Console.WriteLine($" {Nombre} esta haciendo un compensatorio. Total de compensatorios: {_compensatorios}");
    }

}

interface Iorientadores
{
    String Nombre { get; set; }
    int Edad { get; set; }

    void Compensatorio() => Console.Write($" {Nombre} esta haciendo un compensatorio"); 
}

class Alumnos<T> where T : Alumno
{
    private List<T> _ListaAlumnos = new List<T>();

    public int CantidadAlumnos { 
        get { return _ListaAlumnos.Count; } 
    }

    public void AgregarAlumno(T alumno)
    {
        _ListaAlumnos.Add(alumno);
        Console.WriteLine($"SE AGREGO {alumno.Nombre} a la lista");
    }

    public void GetAlumnos()
    {
        foreach (var alumno in _ListaAlumnos)
        {
           int index = _ListaAlumnos.IndexOf(alumno) + 1;
            Console.WriteLine($" {index} - nombre: {alumno.Nombre} - {alumno.Edad}");
        }
    }
}

//CLASES para LINQ
public class Alumnox
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public int Nota { get; set; }
    public int IdCurso { get; set; }
}

public class Curso
{
    public int Id { get; set; }
    public string NombreCurso { get; set; }
}






public class Program
{
    public static void Main(string[] args)
    {
        //Alumno
        var alumno1 = new Alumno("Franco", 28, false, 0);
        Console.WriteLine("INICIANDO SISTEMA ALUMNOS");
        alumno1.Graduacion();
        alumno1.Entrenar();
        alumno1.Entrenar();
        alumno1.Entrenar();
        alumno1.Graduacion();

        Console.WriteLine("\n-------------------------\n");

        //Instructor
        Console.WriteLine("INICIANDO SISTEMA INSTRUCTORES");
        var intructor1 = new Instructor("Juan Manuel", 29, false);
        intructor1.Graduacion();
        Console.WriteLine($"el instructor tiene: {intructor1.CompensatoriosRealizados} compensatorios");
        intructor1.Enseñar();
        intructor1.Compensatorio();
        Console.WriteLine(intructor1.CompHechos);

        //Lista de Alumnos
        Console.WriteLine("\n-------------------------\n");
        Console.WriteLine("INICIANDO SISTEMA DE ALUMNOS");

        Alumnos<Alumno> listaAlumnos = new Alumnos<Alumno>();
        listaAlumnos.AgregarAlumno(alumno1);
        listaAlumnos.AgregarAlumno(intructor1);
        Console.WriteLine("-----------");
        listaAlumnos.GetAlumnos();
        Console.WriteLine($"cantidad de alumnos: {listaAlumnos.CantidadAlumnos}");


        
        //EJERCICIOS LAMBDAS
        {
            Console.WriteLine("\n-------------------------\n");

            void Calculadora(Func<int, int, int> Calc, int numb1, int numb2)
            {
                var result = Calc(numb1, numb2);
                Console.WriteLine($"El resultado de la operacion es: {result}");
            }

            Calculadora((a, b) => a + b, 10, 5);
            Calculadora((a, b) => a - b, 100, 20);
            Calculadora((a, b) => a * b, 7, 8);
            Console.WriteLine("\n-------------------------\n");

            {

                void CambiarNombres(Func<List<string>, List<string>> fn, List<string> list)
                {
                    var mayuscula = fn(list);
                    Console.WriteLine($"Los nombres en mayuscula son: {string.Join(",", mayuscula)}");
                }

                List<string> nombres = new List<string> { "franco", "juan", "pedro", "maria" };

                var Mayus = (List<string> list) => list.Select(m => m.ToUpper()).ToList();

                CambiarNombres(Mayus, nombres);
            }

            Console.WriteLine("\n-------------------------\n");

            void TransformarLista(List<string> original, Func<string, string> reglaDeTransformacion)
            {
                List<string> new_list = new List<string>();
                foreach (var item in original)
                {
                    new_list.Add(reglaDeTransformacion(item));
                }
                Console.WriteLine($"Lista de modificada: {string.Join(", ", new_list)}");
            }
            List<string> nombres2 = new List<string> { "franco", "juan", "pedro", "maria" };
            //mayuscula
            var grande = (string s) => s.ToUpper();

            //agregar sr.
            var titulo = (string s) => $"Sr. {s}";

            //dejar invertido
            var invertir = (string s) => new string(s.Reverse().ToArray());

            TransformarLista(nombres2, grande);
            TransformarLista(nombres2, titulo);
            TransformarLista(nombres2, invertir);
        }

        Console.WriteLine("\n-------------------------\n");
        //EJERCICIOS LINQ
        // Y aquí una lista de datos para que puedas probar tus consultas:

        List<Curso> cursos = new List<Curso>
                {
                    new Curso { Id = 1, NombreCurso = "Matemáticas" },
                    new Curso { Id = 2, NombreCurso = "Historia" },
                    new Curso { Id = 3, NombreCurso = "Programación" }
                };

                List<Alumnox> alumnos = new List<Alumnox>
                {
                    new Alumnox { Id = 1, Nom = "Ana", Nota = 90, IdCurso = 1 },
                    new Alumnox { Id = 2, Nom = "Luis", Nota = 70, IdCurso = 3 },
                    new Alumnox { Id = 3, Nom = "Carla", Nota = 88, IdCurso = 1 },
                    new Alumnox { Id = 4, Nom = "Pedro", Nota = 65, IdCurso = 2 },
                    new Alumnox { Id = 5, Nom = "Maria", Nota = 95, IdCurso = 3 },
                    new Alumnox { Id = 6, Nom = "Juan", Nota = 40, IdCurso = 2 },
                    new Alumnox { Id = 7, Nom = "Laura", Nota = 82, IdCurso = 1 },
                    new Alumnox { Id = 8, Nom = "Miguel", Nota = 98, IdCurso = 3 }
                };            

     //1. Obtener todos los alumnos que aprobaron (nota >= 70).
        var aprobados = alumnos.Where(a => a.Nota >= 70);

        foreach(var alu in aprobados)
        {
            Console.WriteLine($"APROBADOS: {alu.Nom}");
        }


     //2. Ordernar el nombre de los alumnos
        var orden = from o in alumnos
                    orderby o.Nom
                    select o;

        Console.WriteLine("\n-------------------------\n");
        int ind = 0;
        foreach (var alu in orden)
        {
            ind++;
            Console.WriteLine($"n° de orden {ind} - {alu.Nom}");
        }

     //3. Sacar los nombres y guardarlos en una lista
        List<string> elegidos = new List<string>();

        var prospecto = alumnos.Select(a => a.Nom);

        Console.WriteLine("\n-------------------------\n");
        foreach (var alu in prospecto)
        {
            elegidos.Add(alu);
        }

        Console.WriteLine($"Elegidos: {string.Join(", ", prospecto)}");
        Console.WriteLine("\n-------------------------\n");

        //4. Ejercicio propio 
        List<string> prospectoMayus = new List<string>(); //V1

        foreach (var ALU in prospecto)
        {
            if (ALU.Contains("a"))
            {
                prospectoMayus.Add(ALU.ToUpper());
            }
            else { 
            prospectoMayus.Add(ALU);
            }   

        }

        Console.WriteLine($"lista nueva: {string.Join(", ", prospectoMayus)}");


        //V2
        var prospectoMayus2 = prospecto.Select(a => a.Contains("a") ? a.ToUpper() : a);
        Console.WriteLine($"lista Nueva LINQ: {string.Join(", ", prospectoMayus2)}");
    }
}
