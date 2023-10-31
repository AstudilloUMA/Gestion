import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class Glucometria extends Prueba 
{
	private float VALOR_GLUCOSA;
	
	public static List<Prueba> ListaGlucometrias()
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		List<Prueba> xs = new ArrayList<Prueba>();
		for(Object[] obj : database.Select("SELECT G.ID FROM Glucometria G, Pruebas P WHERE P.ID = G.ID;"))
		{
			int id = (int)obj[0];
			xs.add(new Glucometria(id));
		}
		database.finalize();
		return xs;
	}
	
	public static List<Prueba> ListaGlucometrias(Paciente p)
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		List<Prueba> xs = new ArrayList<>();
		for(Object[] obj : database.Select("SELECT P.ID FROM Glucometria G, Pruebas P WHERE P.ID = G.ID and P.NIF = '" 
				+ p.getNIF_Paciente() + "';"))
		{
			xs.add(new Glucometria((int)obj[0]));
		}
		database.finalize();
		return xs;
	}
	
	public Glucometria(int ID)
	{
		super(ID);
		
		BD database = new BD(BD_SERVER,BD_NAME);
		this.VALOR_GLUCOSA = (float) database.SelectEscalar("SELECT VALOR_GLUCOSA FROM Glucometria G WHERE ID = " + ID);
		database.finalize();
		
	}

	public Glucometria(int ID, String NIF, Date Fecha, float VALOR_GLUCOSA)
	{
		super(ID,NIF,Fecha);
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Insert("INSERT INTO Glucometria VALUES(" + ID + "," + VALOR_GLUCOSA +");");
		this.VALOR_GLUCOSA = VALOR_GLUCOSA;
		database.finalize();
	}
	
	public float getVALOR_GLUCOSA() 
	{
		return this.VALOR_GLUCOSA;
	}

	public void setVALOR_GLUCOSA(float value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Glucometria SET VALOR_GLUCOSA = " + value + " WHERE ID=" + super.getID());
		this.VALOR_GLUCOSA = value;
		database.finalize();
	}
	
	public void borrar()
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Delete("DELETE FROM Pruebas WHERE ID=" + super.getID());
		this.VALOR_GLUCOSA = -1;
		super.borrar();
		database.finalize();
	}
	
	public String toString()
	{
		return super.toString() + this.VALOR_GLUCOSA;
	}
}
