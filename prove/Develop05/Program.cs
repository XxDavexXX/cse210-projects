using System;
using System.Collections.Generic;

public class Objetivo
{
    public string nombre;
    public int valor;

    public Objetivo(string nombre, int valor)
    {
        this.nombre = nombre;
        this.valor = valor;
    }

    public virtual void Completar()
    {
        Console.WriteLine($"Has completado el objetivo: {nombre}. Ganaste {valor} puntos.");
    }

    public string Nombre
    {
        get { return nombre; }
    }

    public int Valor
    {
        get { return valor; }
    }
}

public class ObjetivoSimple : Objetivo
{
    public ObjetivoSimple(string nombre, int valor) : base(nombre, valor)
    {
    }

    public override void Completar()
    {
        base.Completar();
    }
}

public class ObjetivoEterno : Objetivo
{
    public ObjetivoEterno(string nombre, int valor) : base(nombre, valor)
    {
    }

    public override void Completar()
    {
        base.Completar();
    }
}

public class ObjetivoListaVerificacion : Objetivo
{
    private int cantidadDeseada;
    private int completados;

    public ObjetivoListaVerificacion(string nombre, int valor, int cantidadDeseada) : base(nombre, valor)
    {
        this.cantidadDeseada = cantidadDeseada;
    }

    public override void Completar()
    {
        completados++;

        if (completados >= cantidadDeseada)
        {
            Console.WriteLine($"¡Has completado el objetivo de lista de verificación {nombre}! Ganaste un bono de {valor} puntos.");
        }
        else
        {
            base.Completar();
        }
    }

    public string Estado
    {
        get { return $"Completado {completados}/{cantidadDeseada} veces"; }
    }
}

public class ObjetivoProgresivo : Objetivo
{
    private int progresoActual;
    private int progresoObjetivo;

    public ObjetivoProgresivo(string nombre, int valor, int progresoObjetivo) : base(nombre, valor)
    {
        this.progresoActual = 0;
        this.progresoObjetivo = progresoObjetivo;
    }

    public void HacerProgreso(int cantidad)
    {
        progresoActual += cantidad;

        if (progresoActual >= progresoObjetivo)
        {
            Completar();
            progresoActual = 0; // Reinicia el progreso
        }
    }

    public override void Completar()
    {
        Console.WriteLine($"Has hecho suficiente progreso en el objetivo: {nombre}. Ganaste {valor} puntos.");
    }

    public string EstadoProgreso
    {
        get { return $"Progreso actual: {progresoActual}/{progresoObjetivo}"; }
    }
}

public class Usuario
{
    private int puntuacion;
    private List<Objetivo> objetivos = new List<Objetivo>();

    public int Puntuacion
    {
        get { return puntuacion; }
    }

    public void AgregarObjetivo(Objetivo objetivo)
    {
        objetivos.Add(objetivo);
    }

    public void RegistrarEvento(Objetivo objetivo)
    {
        objetivo.Completar();
        puntuacion += objetivo.Valor;
    }

    public void HacerProgresoEnObjetivoProgresivo(ObjetivoProgresivo objetivo, int cantidad)
    {
        objetivo.HacerProgreso(cantidad);
        puntuacion += objetivo.Valor;
    }

    public void MostrarObjetivos()
    {
        foreach (var objetivo in objetivos)
        {
            if (objetivo is ObjetivoListaVerificacion)
            {
                var objetivoLista = (ObjetivoListaVerificacion)objetivo;
                Console.WriteLine($"{objetivo.Nombre}: {objetivoLista.Estado}");
            }
            else if (objetivo is ObjetivoProgresivo)
            {
                var objetivoProgresivo = (ObjetivoProgresivo)objetivo;
                Console.WriteLine($"{objetivo.Nombre}: {objetivoProgresivo.EstadoProgreso}");
            }
            else
            {
                Console.WriteLine($"{objetivo.Nombre}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        ObjetivoSimple maraton = new ObjetivoSimple("Correr una maratón", 1000);
        ObjetivoEterno lecturaEscrituras = new ObjetivoEterno("Leer las Escrituras", 100);
        ObjetivoListaVerificacion asistirTemplo = new ObjetivoListaVerificacion("Asistir al templo", 50, 10);
        ObjetivoProgresivo trabajarProyecto = new ObjetivoProgresivo("Trabajar en el proyecto", 200, 5);
        ObjetivoProgresivo comerSaludable = new ObjetivoProgresivo("Comer saludable", 150, 10);

        Usuario usuario = new Usuario();
        usuario.AgregarObjetivo(maraton);
        usuario.AgregarObjetivo(lecturaEscrituras);
        usuario.AgregarObjetivo(asistirTemplo);
        usuario.AgregarObjetivo(trabajarProyecto);
        usuario.AgregarObjetivo(comerSaludable);

        usuario.RegistrarEvento(maraton);
        usuario.RegistrarEvento(lecturaEscrituras);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);
        usuario.RegistrarEvento(asistirTemplo);

        usuario.HacerProgresoEnObjetivoProgresivo(trabajarProyecto, 2);
        usuario.HacerProgresoEnObjetivoProgresivo(comerSaludable, 3);

        usuario.MostrarObjetivos();
        Console.WriteLine($"Puntuación total: {usuario.Puntuacion}");
    }
}
