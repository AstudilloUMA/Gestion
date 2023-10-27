import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.*;

import com.microsoft.sqlserver.jdbc.SQLServerDataSource;

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
        BD dataBase = new BD(BD_SERVER,BD_NAME);
        for(Object[] lab : dataBase.Select("SELECT cif FROM tLaboratorio;"))
        {
        	String cif = (String) lab[0];
        	lista.add(new Laboratorio(cif));
        }
        return lista;
    }

    public Laboratorio(String cif)
    {
        BD dataBase = new BD(BD_SERVER,BD_NAME);
        Object[] lab = dataBase.Select("SELECT CIF, Nombre, Poblacion, Provincia FROM tLaboratorio WHERE CIF = '" + cif +"';").get(0);
        this.cif = (String)lab[0];
        this.nombre = (String)lab[1];
        this.poblacion = (String)lab[2];
        this.provincia = new Provincia((String)lab[3]);
    }

    public Laboratorio(String cif, String nombre, String poblacion, Provincia provincia)
    {
        BD dataBase = new BD(BD_SERVER,BD_NAME);
        dataBase.Insert("INSERT INTO tLaboratorio VALUES('" + cif + "','" + nombre + "','" + poblacion + ",'" + provincia.getCodigo() + "');");
        this.cif = cif;
        this.nombre = nombre;
        this.poblacion = poblacion;
        this.provincia = provincia;
    }

    public String getCIF()
    {
    	return cif; 
    }
    
    public void setCIF(String value)       
    {
    	BD dataBase = new BD(BD_SERVER,BD_NAME);
    	dataBase.Update("UPDATE tLaboratorio SET CIF = '" + value + "' WHERE CIF = '" + this.cif + "';");
    	this.cif = value;  
    }

    public String getNombre()
    {
    	return nombre; 
    }
        
    public void setNombre(String value)
    {
    	BD dataBase = new BD(BD_SERVER,BD_NAME);
    	dataBase.Update("UPDATE tLaboratorio SET Nombre = '" + value + "' WHERE CIF = '" + this.cif + "';");
    	this.nombre = value; 
    }

    public String getPoblacion()
    {
    	return poblacion; 
    }

    public void setPoblacion(String value)
    {
    	BD dataBase = new BD(BD_SERVER,BD_NAME);
    	dataBase.Update("UPDATE tLaboratorio SET Poblacion = '" + value + "' WHERE CIF = '" + this.cif + "';");
    	this.poblacion = value;   
    }

    public Provincia getProvincia()
    {
        return provincia;
    }
        
    public void setProvincia (Provincia value)      
    {
    	BD dataBase = new BD(BD_SERVER,BD_NAME);
    	dataBase.Update("UPDATE tLaboratorio SET Provincia = '" + value.getCodigo() + "' WHERE CIF = '" + this.cif + "';");
    	this.provincia = value;  
    }
    
    public void BorrarLaboratorio()
    {
    	BD dataBase = new BD(BD_SERVER,BD_NAME);
		dataBase.Update("UPDATE tLaboratorio SET CIF = NULL, Nombre = NULL, Provincia = NULL, Poblacion = NULL "
			+ "WHERE CIF = '" + this.cif + "';");
		this.cif = null;
		this.nombre = null;
		this.provincia = null;
		this.poblacion = null;
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
