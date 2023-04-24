internal class Program{
    private static void Main(string[] args){
        Dictionary<int,Cliente> evento = new Dictionary<int,Cliente>{};
        int opcion,buscado=0;
        do{
            opcion=menuEjercicio();
            switch(opcion){
                case 1:
                crearNuevoCliente(evento);
                break;
                case 2:
                verEntradas(evento);
                break;
                case 3:
                buscado=Funciones.IngresarEntero("Ingrese el ID de la persona a buscar");
                buscarID(evento,buscado);
                break;
                case 4:
                buscado=Funciones.IngresarEntero("Ingrese el ID del cliente que desea cambiar su entrada");
                cambiarEntrada(evento,buscado);
                break;
            }
            Console.ReadKey();
        }while(opcion!=5);
    }
    static void cambiarEntrada(Dictionary<int,Cliente> evento, int buscado){
        int nEnt=0;
        double nAbo=0;
        nEnt=Funciones.IngresarEntero("Ingrese el tipo de la nueva entrada");
        nAbo=Funciones.IngresarReal("Ingrese el precio de la nueva entrada");
        if(evento.ContainsKey(buscado)&&evento[buscado].CambiarEntrada(nEnt,nAbo)){
            if(verificarPrecioEntrada(nEnt,nAbo)){
                evento[buscado].TipoEntrada=nEnt;
                evento[buscado].TotalAbonado=nAbo;
                evento[buscado].FechaInscripcion=DateTime.Today;
            }
        }
        else
        Console.WriteLine("No se encuentra el ID");
    }
    static void buscarID(Dictionary<int,Cliente> evento, int buscado){
        if(evento.ContainsKey(buscado)){
            Console.WriteLine(evento[buscado].DNI);
            Console.WriteLine(evento[buscado].Apellido);
            Console.WriteLine(evento[buscado].Nombre);
            Console.WriteLine(evento[buscado].FechaInscripcion);
            Console.WriteLine(evento[buscado].TipoEntrada);
            Console.WriteLine(evento[buscado].TotalAbonado);
        }
        else
        Console.WriteLine("No se encuentra el ID");
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
    static void crearNuevoCliente(Dictionary<int,Cliente> evento){
        int tEnt=0,id;
        bool posible=false;
                double tAbo=0;
                string dni=Funciones.IngresarTexto("Ingrese su DNI");
                string ape=Funciones.IngresarTexto("Ingrese su apellido");
                string nom=Funciones.IngresarTexto("Ingresar su nombre");
                DateTime fins=DateTime.Now;
                do{
                    menuPrecios();
                    tEnt=Funciones.IngresarEntero("Ingrese su tipo de entrada");
                    tAbo=Funciones.IngresarReal("Ingrese su precio abonado");
                    posible=verificarPrecioEntrada(tEnt,tAbo);
                }while(!posible);
                if(posible){
                    Cliente nuevo = new Cliente(dni,ape,nom,fins,tEnt,tAbo);
                    id = Tiquetera.DevolverUltimoID();
                    evento.Add(id,nuevo);
                    Console.WriteLine("Su ID es "+id);
                }
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
