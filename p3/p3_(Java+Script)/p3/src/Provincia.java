import java.util.*;

public class Provincia 
{
    private static String BD_SERVER = "localhost";
    private static String BD_NAME = "GI1920";
    
	private String codigo;
	private String nombre;
	
	public static List<Provincia> ListaProvincias()
	{
		List<Provincia> lista = new ArrayList<Provincia>();
        BD database = new BD(BD_SERVER,BD_NAME);
        for(Object[] prov : database.Select("SELECT Codigo FROM tProvincia;"))
        {
        	String codigo = (String)prov[0];
        	lista.add(new Provincia(codigo));
        }
		return lista;
	}

	
	public Provincia(String codigo)
	{
        BD database = new BD(BD_SERVER,BD_NAME);
        Object[] prov = database.Select("SELECT Codigo, Nombre FROM tProvincia WHERE Codigo = '" + codigo + "';").get(0);
        this.codigo = (String)prov[0];
        this.nombre = (String)prov[1];
	}
	
	public Provincia(String codigo, String provincia)
	{
        BD database = new BD(BD_SERVER,BD_NAME);
        database.Insert("INSERT INTO tProvincia VALUES('" + codigo + "','" + provincia + "');");
        this.codigo = codigo;
        this.nombre = provincia;
	}
	
	public String getCodigo() 
	{
		// Devuelve el valor del atributo
		return this.codigo;
	}
	
	public void setCodigo(String value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE tProvincia SET Codigo = '" + value + "' WHERE Codigo = '" + this.codigo + "';");
		this.codigo = value;
	}
	public String getProvincia() 
	{
		// Devuelve el valor del atributo
		return this.nombre;
	}
	
	public void setProvincia(String value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE tProvincia SET Nombre = '" + value + "' WHERE Codigo = '" + this.codigo + "';");
		this.nombre = value;
	}
	
	public void borrarProvincia()
	{
        BD database = new BD(BD_SERVER,BD_NAME);
        database.Update("UPDATE tProvincia SET Codigo = NULL, Nombre = NULL WHERE Codigo = '" + this.codigo + "';");
        this.codigo = null;
        this.nombre = null;
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
