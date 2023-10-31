import java.util.Date;
import java.util.ArrayList;
import java.util.List;

public class Radiografia extends Prueba 
{
	private boolean TAC;
	private String FICHERO;
	
	public static List<Prueba> ListaRadiografias()
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		List<Prueba> xs = new ArrayList<>();
		for(Object[] obj : database.Select("SELECT R.ID FROM Radiografia R, Pruebas P WHERE P.ID = R.ID;"))
		{
			xs.add(new Radiografia((int)obj[0]));
		}
		database.finalize();
		return xs;
	}
	
	public static List<Prueba> ListaRadiografias(Paciente p)
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		List<Prueba> xs = new ArrayList<>();
		for(Object[] obj : database.Select("SELECT R.ID FROM Radiografia R, Pruebas P WHERE P.ID = R.ID AND P.NIF='"+p.getNIF_Paciente() + "';"))
		{
			xs.add(new Radiografia((int)obj[0]));
		}
		database.finalize();
		return xs;
	}
	
	public Radiografia(int ID)
	{
		super(ID);
		BD database = new BD(BD_SERVER,BD_NAME);
		Object[] obj = database.Select("SELECT TAC, fichero FROM Radiografia WHERE ID = " + super.getID()).get(0);
		this.TAC = (boolean)obj[0];
		this.FICHERO = (String)obj[1];
		database.finalize();
	}

	public Radiografia(int ID, String NIF, Date Fecha, boolean TAC, String FICHERO)
	{
		super(ID,NIF,Fecha);
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Insert("INSERT INTO Radiografia VALUES(" + ID + "," + (TAC?1:0) + ",'" + FICHERO + "')");
		this.TAC = TAC;
		this.FICHERO = FICHERO;
		database.finalize();
	}
	
	public boolean getTAC() 
	{
		return this.TAC;
	}

	public void setTAC(boolean value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Radiografia SET TAC = " + (value?1:0) + " WHERE ID = " + super.getID());
		this.TAC = value;
		database.finalize();
	}
	
	public String getFICHERO() 
	{
		return this.FICHERO;
	}

	public void setFICHERO(String value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Radiografia SET FICHERO = '" + value + "' WHERE ID = " + super.getID());
		this.FICHERO = value;
		database.finalize();
	}
	
	public void borrar()
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Delete("DELETE Radiografia WHERE ID = " + super.getID());
		super.borrar();
		this.TAC = false;
		this.FICHERO = null;
		database.finalize();
	}
	
	public String toString()
	{
		return super.toString() + this.TAC + ";" + this.FICHERO;
	}

}
