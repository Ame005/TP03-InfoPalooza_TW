internal class Program{
    private static void Main(string[] args){
        Dictionary<int,Cliente> evento = new Dictionary<int,Cliente>{};
        int opcion,id=0;
        bool posible=false;
        do{
            opcion=menuEjercicio();
            switch(opcion){
                case 1:
                int tEnt=0;
                double tAbo=0;
                string dni=IngresarString("Ingrese su DNI");
                if(!(evento[id].DNI==dni)){
                    string ape=IngresarString("Ingrese su apellido");
                    string nom=IngresarString("Ingresar su nombre");
                    DateTime fins=IngresarDatetime();
                    do{
                        menuPrecios();
                        tEnt=IngresarInt("Ingrese su tipo de entrada");
                        tAbo=IngresarDouble("Ingrese su precio abonado");
                        posible=verificarPrecioEntrada(tEnt,tAbo);
                    }while(!posible);
                    if(posible){
                       Cliente nuevo = new Cliente(dni,ape,nom,fins,tEnt,tAbo);
                       evento.Add(id,nuevo);
                       id++;
                    }
                }
                break;
                case 2:
                    verEntradas(evento);
                break;
                case 3:
                break;
                case 4:
                break;
            }
            Console.ReadKey();
        }while(opcion!=5);
    }
    static void verEntradas(Dictionary<int,Cliente> evento){
        int cont1=0,cont2=0,cont3=0,cont4=0,contGen=0;
        double total1=0,total2=0,total3=0,total4=0,totalGen=0;
        if(evento.ContainsKey(1)){
            foreach(int entrada in evento.Keys){
            switch(evento[entrada].TipoEntrada){
                case 1:
                    cont1++;
                    total1+=evento[entrada].TotalAbonado;
                break;
                case 2:
                    cont2++;
                    total2+=evento[entrada].TotalAbonado;
                break;
                case 3:
                    cont3++;
                    total3+=evento[entrada].TotalAbonado;
                break;
                case 4:
                    cont4++;
                    total4+=evento[entrada].TotalAbonado;
                break;
            }
            contGen++;
            totalGen+=evento[entrada].TotalAbonado;
        }
        Console.WriteLine(contGen);
        Console.WriteLine("Tipo 1: "+(cont1/contGen)+100+"%-Recaudación: $"+total1);
        Console.WriteLine("Tipo 2: "+(cont2/contGen)+100+"%-Recaudación: $"+total2);
        Console.WriteLine("Tipo 3: "+(cont3/contGen)+100+"%-Recaudación: $"+total3);
        Console.WriteLine("Tipo 4: "+(cont4/contGen)+100+"%");
        Console.WriteLine("recaudación total: $"+totalGen);
        }
        else
        Console.WriteLine("Aún no se anotó nadie");
    }
    static DateTime IngresarDatetime(){
        DateTime devolver=new DateTime();
        bool valido=false;
        int dia=1, mes=1, anio=1;
        string fecha;
        do{
            anio=IngresarInt("Ingrese su año de nacimiento");
            mes=IngresarInt("Ingrese su mes");
            dia=IngresarInt("Ingese su dia");
            fecha=dia+"/"+mes+"/"+anio; 
            valido=DateTime.TryParse(fecha, out devolver);
        }while(!valido);
        return devolver;
    }
    static bool verificarPrecioEntrada(int entrada,double tAbo){
        bool devolver=false;
        int[] precios= {15000,30000,10000,40000};
        if(tAbo>=precios[entrada-1]){
            devolver=true;
            if(tAbo>precios[entrada-1])
            Console.WriteLine("Su vuelto sería "+(tAbo-precios[entrada-1]));
        }
        return devolver;
    }
    static string IngresarString(string mensaje){
        string devolver;
        Console.WriteLine(mensaje);
        devolver=Console.ReadLine();
        return devolver;
    }
    static double IngresarDouble(string mensaje){
        double devolver;
        Console.WriteLine(mensaje);
        devolver=double.Parse(Console.ReadLine());
        return devolver;
    }
    static int IngresarInt(string mensaje){
        int devolver;
        Console.WriteLine(mensaje);
        devolver=int.Parse(Console.ReadLine());
        return devolver;
    }
    static void menuPrecios(){
        Console.WriteLine("1- Día 1 , valor a abonar $15000");
        Console.WriteLine("2- Día 2, valor a abonar $30000");
        Console.WriteLine("3- Día 3, valor a abonar $10000");
        Console.WriteLine("4- Full Pass, valor a abonar $40000");
    }
    static int menuEjercicio(){
        int devolver;
        do{
            Console.WriteLine("1- Nueva inscripcion");
            Console.WriteLine("2- Obetener estadísticas del Evento");
            Console.WriteLine("3- Buscar Cliente");
            Console.WriteLine("4- Cambiar entrada de un Cliente");
            Console.WriteLine("5- Salir");
            devolver=int.Parse(Console.ReadLine());
        }while(devolver<1||devolver>5);
        return devolver;
    }
}
