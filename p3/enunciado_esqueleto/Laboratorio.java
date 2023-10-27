import java.util.*;

public class Laboratorio 
{
    private static String BD_SERVER = "localhost";
    private static String BD_NAME = "GI1920";

    private String cif;
    private String nombre;
    private String poblacion;
    private Provincia provincia;

    public static List<Laboratorio> ListaLaboratorios()
    {
        List<Laboratorio> lista = new ArrayList<Laboratorio>();

        // COMPLETAR        

        return lista;
    }

    public Laboratorio(String cif)
    {
        // COMPLETAR
    }

    public Laboratorio(String cif, String nombre, String poblacion, Provincia provincia)
    {
        // COMPLETAR
    }

    public String getCIF()
    {
    	return cif; 
    }
    
    public void setCIF(String value)       
    {
        // COMPLETAR
    }

    public String getNombre()
    {
    	return nombre; 
    }
        
    public void setNombre(String value)
    {
        // COMPLETAR
    }

    public String getPoblacion()
    {
    	return poblacion; 
    }

    public void setPoblacion(String value)
    {
        // COMPLETAR
    }

    public Provincia getProvincia()
    {
        return provincia;
    }
        
    public void setProvincia (Provincia value)      
    {
        // COMPLETAR
    }
    
    public void BorrarLaboratorio()
    {
        // COMPLETAR
    }

    public String toString()
    {
        return cif + " " + nombre;
    }

    public boolean equals(Object obj)
    {
        return obj instanceof Laboratorio 
        		&& (((Laboratorio)obj).cif.compareToIgnoreCase(this.cif) == 0);
    }

    public int hashCode()
    {
        return cif.hashCode();
    }
}
