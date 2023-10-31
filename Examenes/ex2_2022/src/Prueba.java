import java.util.Date;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public abstract class Prueba implements Comparable<Prueba> 
{
    protected static String BD_SERVER = "localhost";
    protected static String BD_NAME = "P12_2022";
    
	private int ID;
	private String NIF;
	private Date Fecha;
	
	public static List<Prueba> ListaPruebas()
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		List<Prueba> xs = new ArrayList<Prueba>();
		xs.addAll(Glucometria.ListaGlucometrias());
		xs.addAll(Radiografia.ListaRadiografias());
		database.finalize();
		return xs;
	}
	
	public static List<Prueba> ListaPruebas(Paciente p)
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		List<Prueba> xs = new ArrayList<>();
		xs.addAll(Glucometria.ListaGlucometrias(p));
		xs.addAll(Radiografia.ListaRadiografias(p));
		database.finalize();
		return xs;
	}
	
	public Prueba(int ID)
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		Object[] obj = database.Select("SELECT ID, NIF, Fecha FROM Pruebas WHERE ID = " + ID + ";").get(0);
		this.ID = (int)obj[0];
		this.NIF = (String)obj[1];
		this.Fecha = (Date)obj[2];
		database.finalize();
	}

	public Prueba(int ID, String NIF, Date Fecha)
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
		database.Insert("INSERT INTO Pruebas VALUES(" + ID + ",'" + NIF + "', '" + date.format(Fecha) + "');");
		this.ID = ID;
		this.NIF = NIF;
		this.Fecha = Fecha;
		database.finalize();
	}
	
	public int getID() 
	{
		return ID;
	}

	public void setID(int value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Pruebas SET ID = " + value + " WHERE ID=" + this.ID + ";");
		this.ID = value;
		database.finalize();
	}
	
	public String getNIF() 
	{
		return NIF;
	}

	public void setNIF(String value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Pruebas SET NIF = '" + value + "' WHERE ID=" + this.ID + ";");
		this.NIF = value;
		database.finalize();
	}
	
	public Date getFecha() 
	{
		return Fecha;
	}

	public void setFecha(Date value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
		database.Update("UPDATE Pruebas SET Fecha = '" + date.format(value) + "' WHERE ID =" + this.ID + ";");
		this.Fecha = value;
		database.finalize();
	}
	
	public void borrar()
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Delete("DELETE FROM Pruebas WHERE ID=" + this.ID + ";");
		this.ID = -1;
		this.NIF = null;
		this.Fecha = null;
		database.finalize();
	}
	
	public String toString()
	{
		/*
		String res;
		List<Prueba> xs = Glucometria.ListaGlucometrias();
		List<Prueba> ys = Glucometria.ListaGlucometrias();
		SimpleDateFormat date = new SimpleDateFormat("dd/MM/yyyy");
		Glucometria gluco = new Glucometria(ID);
		Radiografia radio = new Radiografia(ID);
		Boolean estaG = false;
		Boolean estaR = false;
		int i = 0;
		while(i<xs.size() && !estaG)
		{
			if(xs.get(i).ID == this.ID) estaG = true;
			i++;
		}
		int t = 0;
		while(t<ys.size() && !estaR)
		{
			if(ys.get(t).ID == this.ID) estaR = true;
			t++;
		}
		
		if(estaG)
		{
			res = (ID + ";" + NIF + ";" + date.format(Fecha) + ";" + gluco.toString());
		}
		else if(estaR)
		{
			res = (ID + ";" + NIF + ";" + date.format(Fecha) + ";" + radio.toString());
		}
		else
		{
			throw new RuntimeException("No existe esta prueba");
		}
		
		res =  (ID + ";" + NIF + ";" + date.format(Fecha) + ";" + this.getClass().toString());
		*/
		SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
		return (ID + ";" + NIF + ";" + date.format(Fecha) + ";" + this.getClass().getCanonicalName() + ";");
	}
	
	@Override
	public int compareTo(Prueba o) 
	{
		return Integer.compare(o.ID, this.ID);
	}

    public boolean equals(Object obj)
    {
    	if(obj instanceof Prueba)
    	{
    		Prueba x = (Prueba)obj;
    		return x.ID == this.ID;
    	}
    	
    	return false;
    }

    public int hashCode()
    {
		return Objects.hashCode(this.ID);
    }
}
