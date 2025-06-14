

/*using System;

//Prueba
var discipulo1 = new Alumno("Juan Manuel", 29, false, 2);*/

/*Console.WriteLine($"{discipulo1.nombre} tiene  {discipulo1.mesesDePractica} Meses de Practica:");
discipulo1.Entrenar();

Console.WriteLine($"{discipulo1.nombre} tiene: {discipulo1.mesesDePractica} Meses de Practica");
discipulo1.Entrenar();

discipulo1.Graduacion();*/


//Alumno
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
    }
}