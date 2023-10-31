import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Objects;

public class Paciente implements Comparable<Paciente>
{
	    private static String BD_SERVER = "localhost";
	    private static String BD_NAME = "P11_2022";
    
        private String NIF;
        private int NumSS;
        private String Nombre;
        private String Apellidos;
        private String Sexo;
        private Date FechaNacimiento;
        private String Direccion;
        private String Poblacion;
        private Provincia miProvincia;
        private String CodigoPostal;        
        private String Telefono;
        private String e_mail;
        private List<Cita> Citas;

        public static List<Paciente> ListaPacientes()
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
    		List<Paciente> xs = new ArrayList<>();
    		for(Object[] obj : database.Select("SELECT NIF FROM tPaciente"))
    		{
    			xs.add(new Paciente((String)obj[0]));
    		}
    		database.finalize();
    		return xs;
        }

        public Paciente(String nif)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
    		Object[] obj = database.Select("SELECT NIF, NumSeguro, Nombre, Apellidos, Sexo, " + 
    				"FechaNacimiento, Direccion, Poblacion, Provincia," + 
    				" CodigoPostal, Telefono, e_mail FROM tPaciente WHERE NIF=" + nif).get(0);
  		
    		this.Citas = new ArrayList<>();
    		for(Object[] elem : database.Select("SELECT ID FROM Cita WHERE NIF='" + nif + "';")){
    			if(elem != null) this.Citas.add(new Cita((int)elem[0]));
    		}
    		this.NIF = (String)obj[0];
            this.NumSS = (int)obj[1];
            this.Nombre = (String)obj[2];
            this.Apellidos = (String)obj[3];
            this.Sexo = (String)obj[4];
            this.FechaNacimiento = (Date)obj[5];
            this.Direccion = (String)obj[6];
            this.Poblacion = (String)obj[7];
            this.miProvincia = new Provincia((String)obj[8]);
            this.CodigoPostal = (String)obj[9];        
            this.Telefono = (String)obj[10];
            this.e_mail = (String)obj[11];
    		database.finalize();
        }

        public Paciente(int NumSS, String Nif, String Nombre, String Apellidos, String Sexo,
            Date FechaNacimiento, String Direccion, String Poblacion, String Provincia,
            String CodigoPostal, Provincia miProvincia, String Telefono, String e_mail)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
        	database.Insert("INSERT NIF, NumSeguro Nombre, Apellidos, Sexo, " + 
    				"FechaNacimiento, Direccion, Poblacion, Provincia," + 
    				" CodigoPostal, Telefono, e_mail INTO tPaciente VALUES('"+Nif+"',"+NumSS+",'"+Nombre+"','"+
    					Apellidos+"','"+Sexo+"','"+date.format(FechaNacimiento)+"','"+Direccion+"','"+Poblacion+"','"+
    					Provincia+"','"+CodigoPostal+"','"+Telefono+"','"+e_mail+"');");
        	
        	this.Citas = new ArrayList<>();
        	this.NIF = Nif;
            this.NumSS = NumSS;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Sexo = Sexo;
            this.FechaNacimiento = FechaNacimiento;
            this.Direccion = Direccion;
            this.Poblacion = Poblacion;
            this.miProvincia = miProvincia;
            this.CodigoPostal = CodigoPostal;       
            this.Telefono = Telefono;
            this.e_mail = e_mail;
            database.finalize();
        }
        
        public void BorrarPaciente()
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Delete("DELETE FROM tPaciente WHERE NIF='"+this.NIF+"';");
        	this.NIF = null;
            this.NumSS = -1;
            this.Nombre = null;
            this.Apellidos = null;
            this.Sexo = null;
            this.FechaNacimiento = null;
            this.Direccion = null;
            this.Poblacion = null;
            this.miProvincia = null;
            this.CodigoPostal = null;       
            this.Telefono = null;
            this.e_mail = null;
            database.finalize();
//        	for(Paciente p : Paciente.ListaPacientes())
//        	{
//        		database.Delete("DELETE FROM tPaciente WHERE NIF='" + p.getNIF_Paciente() + "';");
//        	}
        	
        }

        public int getNumeroSS_Paciente()
        {
        	return this.NumSS;
        }

        public void setNumeroSS_Paciente(int value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET NumSeguro="+value+" WHERE NIF='"+this.NIF+"';");
        	this.NumSS = value;
        	database.finalize();
        }

        public String getNIF_Paciente()
        {
        	return this.NIF;
        }
        public void setNIF_Paciente(String value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET NIF="+value+" WHERE NIF='"+this.NIF+"';");
        	this.NIF = value;
        	database.finalize();
        }

        public String getNombre_Paciente()
        {
			return this.Nombre;
        }
            
        public void setNombre_Paciente(String value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET Nombre="+value+" WHERE NIF='"+this.NIF+"';");
        	this.Nombre = value;
        	database.finalize();
        }

        public String getApellidos_Paciente()
        {
			return this.Apellidos;
        }
            
        public void setApellidos_Paciente(String value)            
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET Apellidos="+value+" WHERE NIF='"+this.NIF+"';");
        	this.Apellidos = value;
        	database.finalize();
        }

        public String getSexo_Paciente()
        {
			return this.Sexo;
        }
            
        public void setSexo_Paciente(String value)            
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET Sexo="+value+" WHERE NIF='"+this.NIF+"';");
        	this.Sexo = value;
        	database.finalize();
        }

        public Date getFechaNacimiento_Paciente()
        {
			return this.FechaNacimiento;
        }
            
        public void setFechaNacimiento_Paciente(Date value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	SimpleDateFormat date = new SimpleDateFormat("yyyy-MM-dd");
        	database.Update("UPDATE tPaciente SET FechaNacimiento="+date.format(value)+" WHERE NIF='"+this.NIF+"';");
        	this.FechaNacimiento = value;
        	database.finalize();
        }

        public String getDireccion_Paciente()
        {
			return this.Direccion;
        }
            
        public void setDireccion_Paciente(String value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET Direccion="+value+" WHERE NIF='"+this.NIF+"';");
        	this.Direccion = value;
        	database.finalize();
        }

        public String getPoblacion_Paciente()
        {
			return this.Poblacion;
        }
        
        public void setPoblacion_Paciente(String value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET Poblacion="+value+" WHERE NIF='"+this.NIF+"';");
        	this.Poblacion = value;
        	database.finalize();
        }

        public Provincia getProvincia_Paciente()
        {
			return this.miProvincia;
        }
        
        public void setProvincia_Paciente(Provincia value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET Provincia="+value.getDescripcion()+" WHERE NIF='"+this.NIF+"';");
        	this.miProvincia = value;
        	database.finalize();
        }
        public String getCodigoPostal_Paciente()
        {
			return this.CodigoPostal;
        }
        
        public void setCodigoPostal_Paciente(String value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET CodigoPostal="+value+" WHERE NIF='"+this.NIF+"';");
        	this.CodigoPostal = value;
        	database.finalize();
        }

        public String getTelefono_Paciente()
        {
			return this.Telefono;
        }
        
        public void setTelefono_Paciente(String value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET Telefono="+value+" WHERE NIF='"+this.NIF+"';");
        	this.Telefono = value;
        	database.finalize();
        }

        public String getE_mail_Paciente()
        {
			return this.e_mail;
        }
        
        public void setE_mail_Paciente(String value)
        {
        	BD database = new BD(BD_SERVER,BD_NAME);
        	database.Update("UPDATE tPaciente SET e_mail="+value+" WHERE NIF='"+this.NIF+"';");
        	this.e_mail = value;
        	database.finalize();
        }
        

        public void addCita(Cita c)
        {
        	boolean salir = false;
        	int i = 0;
        	while(!salir && i < this.Citas.size())
        	{
        		if(c.equals(this.Citas.get(i))) salir = true;
        		else i++;
        	}
        	if(i != this.Citas.size()) this.Citas.remove(i);
        	this.Citas.add(c);
        }
		public List<Cita> getCitas() 
		{
			return this.Citas;
		}

		@Override
        public String toString()
        {
			StringBuilder str = new StringBuilder("{");
			for(Cita c : Citas)
			{
				str.append(c.toString());
			}
			str.append("}");
        	return this.NIF + ";" + this.NumSS + ";" + this.Nombre + ";" + this.Apellidos + ";\t" + str.toString();
        }

		@Override
		public int compareTo(Paciente o) 
		{
			return this.NIF.compareToIgnoreCase(o.getNIF_Paciente());
		}
		
	    public boolean equals(Object obj)
	    {
	    	if(obj instanceof Paciente)
	    	{
	    		return ((Paciente)obj).getNIF_Paciente().equalsIgnoreCase(this.NIF);
	    	}
	    	return false;
	    }

	    public int hashCode()
	    {
			return Objects.hashCode(this.NIF);
	    }
}
