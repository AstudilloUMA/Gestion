import java.util.*;

public class Provincia 
{
    private static String BD_SERVER = "localhost";
    private static String BD_NAME = "GI1920";
    
	private String codigo;
	private String nombre;
	
	public static List<Provincia> ListaProvincias()
	{
        		// COMPLETAR
		return lista;
	}

	
	public Provincia(String codigo)
	{
        		// COMPLETAR
	}
	
	public Provincia(String codigo, String provincia)
	{
        		// COMPLETAR
	}
	
	public String getCodigo() 
	{
		// Devuelve el valor del atributo
		return this.codigo;
	}
	
	public void setCodigo(String value) 
	{
		// Establece el valor del atributo y actualiza la tabla
        		// COMPLETAR
		
	}
	public String getProvincia() 
	{
		// Devuelve el valor del atributo
		return this.nombre;
	}
	
	public void setProvincia(String value) 
	{
		// Establece el valor del atributo y actualiza la tabla
        		// COMPLETAR
	}
	
	public void borrarProvincia()
	{
        		// COMPLETAR
	}
		   
	public String toString()	
	{	        
		return nombre;
	}
	   
	public boolean equals(Object obj)	   
	{	       
		return obj instanceof Provincia 
	       		&& (((Provincia)obj).codigo.compareToIgnoreCase(this.codigo) == 0);	   
	}

	public int hashCode()	   
	{	        
		return codigo.hashCode();	    
	}
}
