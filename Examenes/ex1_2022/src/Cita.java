import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Objects;

public class Cita implements Comparable<Cita> 
{
    protected static String BD_SERVER = "localhost";
    protected static String BD_NAME = "P11_2022";
    
    private int ID;
	private String NIF;
	private Date Fecha;
	private int Hora;
	private int Minutos;
	
	public static List<Cita> ListaCitas()
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		List<Cita> xs = new ArrayList<>();
		for(Object[] obj : database.Select("SELECT ID FROM Cita"))
		{
			xs.add(new Cita((int)obj[0]));
		}
		database.finalize();
		return xs;
	}
	
	public static List<Cita> ListaCitas(Paciente p)
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		List<Cita> xs = new ArrayList<>();
		for(Object[] obj : database.Select("SELECT ID FROM Cita WHERE NIF=" + p.getNIF_Paciente()))
		{
			xs.add(new Cita((int)obj[0]));
		}
		database.finalize();
		return xs;
	}
	
	public Cita(int ID) {
	    BD database = new BD(BD_SERVER, BD_NAME);
	    List<Object[]> results = database.Select("SELECT ID, NIF, fecha, hora, minutos FROM Cita WHERE ID=" + ID + ";");

	    if (!results.isEmpty()) {
	        Object[] obj = results.get(0);
	        this.ID = (int) obj[0];
	        this.NIF = (String) obj[1];
	        this.Fecha = (Date) obj[2];
	        this.Hora = (int) obj[3];
	        this.Minutos = (int) obj[4];
	    }

	    database.finalize();
	}



	public Cita(String NIF, Date Fecha, int Hora, int Minutos)
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
		database.Insert("INSERT INTO Cita VALUES('"+NIF+"','"+date.format(Fecha)+"',"+Hora+","+Minutos+");");
		this.NIF = NIF;
		this.Fecha = Fecha;
		this.Hora = Hora;
		this.Minutos = Minutos;
		database.finalize();
	}
	
	public int getID() 
	{
		return this.ID;
	}

	public void setID(int value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Cita SET ID=" + value + " WHERE ID=" + this.ID);
		this.ID = value;
		database.finalize();
	}
	
	public String getNIF() 
	{
		return this.NIF;
	}

	public void setNIF(String value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Cita SET NIF='" + value + "' WHERE ID=" + this.ID);
		this.NIF = value;
		database.finalize();
	}
	
	public Date getFecha() 
	{
		return this.Fecha;
	}

	public void setFecha(Date value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
		database.Update("UPDATE Cita SET fecha='" + date.format(value) + "' WHERE ID=" + this.ID);
		this.Fecha = value;
		database.finalize();
	}
	
	public int getHora() 
	{
		return this.Hora;
	}

	public void setHora(int value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Cita SET hora=" + value + " WHERE ID=" + this.ID);
		this.Hora = value;
		database.finalize();
	}
	
	public int getMinutos() 
	{
		return this.Minutos;
	}

	public void setMinutos(int value) 
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Update("UPDATE Cita SET minutos=" + value + " WHERE ID=" + this.ID);
		this.Minutos = value;
		database.finalize();
	}
	
	public void borrar()
	{
		BD database = new BD(BD_SERVER,BD_NAME);
		database.Delete("DELETE FROM Cita WHERE ID=" + this.ID + ";");
		this.ID = -1;
		this.NIF = null;
		this.Fecha = null;
		this.Hora = -1;
		this.Minutos = -1;
		database.finalize();
	}

	@Override
	public String toString() {
		SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
		return this.ID + ";" + this.NIF + ";" + date.format(this.Fecha) + ";" + this.Hora + ";" + this.Minutos + ";";
	}

	@Override
	public int compareTo(Cita o) 
	{
		return Integer.compare(this.ID, o.getID());
	}

    public boolean equals(Object obj)
    {
		if(obj instanceof Cita) return ((Cita)obj).getID() == (this.ID);
		return false;
    }

    public int hashCode()
    {
		return Objects.hashCode(this.ID);
    }
}
