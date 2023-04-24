public static class Funciones
{
    public static string IngresarTexto(string msj)
    {
        string texto = "";
        while (texto == "")
        {
            Console.WriteLine(msj);
            texto = Console.ReadLine();
        }
        return texto;
    }
    public static int IngresarEntero(string msj)
    {
        int entero=-1;
        while (entero == -1)
        {   
            Console.WriteLine(msj);
            int.TryParse(Console.ReadLine(), out entero);
        }
        return entero;
    }
    public static double IngresarReal(string msj){
        double real=-1;
        while (real==-1){
            Console.WriteLine(msj);
            double.TryParse(Console.ReadLine(), out real);
        }
        return real;
    }

    public static int IngresarEnteroEnRango(string msj, int minimo, int maximo)
    {
        int entero;
        entero = IngresarEntero(msj);
        while (entero < minimo || entero > maximo)
        {
            entero = IngresarEntero("ERROR! " + msj);
        }
        return entero;
    }

    public static DateTime IngresarFecha(string msj)
    {
        DateTime fechaDate;
        string fechaCadena = IngresarTexto(msj);
        while (!DateTime.TryParse(fechaCadena, out fechaDate))
        {
            fechaCadena = IngresarTexto("ERROR! " + msj);
        }
        return fechaDate;
    }
}