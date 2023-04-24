class Cliente{
    public string DNI{get;set;}
    public string Apellido{get;set;}
    public string Nombre{get;set;}
    public DateTime FechaInscripcion{get;set;}
    public int TipoEntrada{get;set;}
    public double TotalAbonado{get;set;}

    public Cliente(string dni,string ape,string nom, DateTime fins,int tent,double tabo){
        DNI=dni;
        Apellido=ape;
        Nombre=nom;
        FechaInscripcion=fins;
        TipoEntrada=tent;
        TotalAbonado=tabo;
    }
    public bool CambiarEntrada(int nEnt,double nAbo){
        /*Solo puede cambiar la entrada
        si el precio es mayor al anterior*/
        bool posible=false;
        if(nAbo>TotalAbonado){
            TipoEntrada=nEnt;
            TotalAbonado=nAbo;
            posible=true;
        }
        else if (TipoEntrada==4){
            posible=false;
            Console.WriteLine("Ya tiene la entrada más cara, el cambio no va a ser posible");
        }
        return posible;
    }
}