
import java.util.*;
import java.text.SimpleDateFormat;

public class Paciente implements Comparable<Paciente>
{
	    private static String BD_SERVER = "localhost";
	    private static String BD_NAME = "P12_2022";
    
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
        private List<Prueba> miPruebas;

        public static List<Paciente> ListaPacientes()
        {
            List<Paciente> lista = new ArrayList<Paciente>();
            BD miBD = new BD(BD_SERVER,BD_NAME);
            for (Object[] tupla : miBD.Select("SELECT NIF FROM tPaciente;"))
            {
            	String id = (String)tupla[0];
                Paciente p = new Paciente(id);
                lista.add(p);
            }
            return lista;
        }

        public Paciente(String nif)
        {
        	BD miBD = new BD(BD_SERVER,BD_NAME);
            Object[] tupla = miBD.Select("SELECT * FROM tPaciente WHERE NIF='" + nif + "';").get(0);

            NIF= (String)tupla[0];
            NumSS= (int)tupla[1];            
            Nombre= (String)tupla[2];
            Apellidos= (String)tupla[3];
            Sexo = (String)tupla[4];
            FechaNacimiento = (Date) tupla[5];
            Direccion = (String)tupla[6];
            Poblacion = (String)tupla[7];
            miProvincia = new Provincia((String)tupla[8]);
            CodigoPostal = (String)tupla[9];            
            Telefono = (String)tupla[10];
            e_mail = (String)tupla[11];
            miPruebas = null;
        }

        public Paciente(int NumSS, String Nif, String Nombre, String Apellidos, String Sexo,
            Date FechaNacimiento, String Direccion, String Poblacion, String Provincia,
            String CodigoPostal, Provincia miProvincia, String Telefono, String e_mail)
        {
        	BD miBD = new BD(BD_SERVER,BD_NAME);
        	SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd"); 
            String DateToStr = format.format(FechaNacimiento); 
            
            String ins = "INSERT INTO tPaciente VALUES('" + Nif + "', " + NumSS + ", '"
                + Nombre + "', '" + Apellidos + "', '" + Sexo + "', '" + DateToStr
                + "', '" + Direccion + "', '" + Poblacion + "', '" + miProvincia.getCodigo()
                + "', '" + CodigoPostal + "', '" + Telefono + "', '" + e_mail + "');";
            miBD.Insert(ins);
            
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
            this.miProvincia = miProvincia;
            this.Telefono = Telefono;
            this.e_mail = e_mail;
            this.miPruebas = null;
        }
        
        public void BorrarPaciente()
        {
        	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Delete("DELETE tPaciente WHERE NIF='" + this.NIF + "';");

            NumSS = -1;
            NIF = null;
            Nombre = null;
            Apellidos = null;
            Sexo = null;
            FechaNacimiento = null;
            Direccion = null;
            Poblacion = null;
            miProvincia = null;
            CodigoPostal = null;
            Telefono = null;
            e_mail = null;

        }

        public int getNumeroSS_Paciente()
        {
            return NumSS; 
        }

        public void setNumeroSS_Paciente(int value)
        {
            BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET NumSeguro=" + value + " WHERE NIF='" + this.NIF + "';");
            this.NumSS = value;             
        }

        public String getNIF_Paciente()
        {
            return NIF;
        }
        public void setNIF_Paciente(String value)
        {
            BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET NIF='" + value + "' WHERE NIF='" + this.NIF + "';");
            NIF = value;
        }

        public String getNombre_Paciente()
        {
            return Nombre;
        }
            
        public void setNombre_Paciente(String value)
        {
           	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET Nombre='" + value + "' WHERE NIF='" + this.NIF + "';");
            Nombre = value;
        }

        public String getApellidos_Paciente()
        {
            return Apellidos;
        }
            
        public void setApellidos_Paciente(String value)            
        {
           	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET Apellidos='" + value + "' WHERE NIF='" + this.NIF + "';");
            Apellidos = value;
        }

        public String getSexo_Paciente()
        {
            return Sexo;
        }
            
        public void setSexo_Paciente(String value)            
        {
           	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET Sexo='" + value + "' WHERE NIF='" + this.NIF + "';");
            Sexo = value;
        }

        public Date getFechaNacimiento_Paciente()
        {
            return FechaNacimiento;
        }
            
        public void setFechaNacimiento_Paciente(Date value)
        {
           	BD miBD = new BD(BD_SERVER,BD_NAME);
           	SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd"); 
            String DateToStr = format.format(value); 
            	
             miBD.Update("UPDATE tPaciente SET FechaNacimiento='" + DateToStr 
            		 + "' WHERE NIF='" + this.NIF + "';");
             FechaNacimiento = value;
        }

        public String getDireccion_Paciente()
        {
            return Direccion;
        }
            
        public void setDireccion_Paciente(String value)
        {
           	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET Direccion='" + value + "' WHERE NIF='" + this.NIF + "';");
            Direccion = value;
        }

        public String getPoblacion_Paciente()
        {
            return Poblacion;
        }
        
        public void setPoblacion_Paciente(String value)
        {
            BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET Poblacion='" + value + "' WHERE NIF='" + this.NIF + "';");
            Poblacion = value;
        }

        public Provincia getProvincia_Paciente()
        {
            return this.miProvincia;
        }
        
        public void setProvincia_Paciente(Provincia value)
        {
            BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET Provincia='" + value.getCodigo() 
            		+ "' WHERE NIF='" + this.NIF + "';");
            miProvincia = value;
        }
        public String getCodigoPostal_Paciente()
        {
            return CodigoPostal;
        }
        
        public void setCodigoPostal_Paciente(String value)
        {
           	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET CodigoPostal='" + value 
            		+ "' WHERE NIF='" + this.NIF + "';");
            CodigoPostal = value;
        }

        public String getTelefono_Paciente()
        {
            return Telefono;
        }
        
        public void setTelefono_Paciente(String value)
        {
           	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET Telefono='" + value 
            		+ "' WHERE NIF='" + this.NIF + "';");
            Telefono = value;
        }

        public String getE_mail_Paciente()
        {
            return e_mail;
        }
        
        public void setE_mail_Paciente(String value)
        {
           	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tPaciente SET e_mail='" + value 
            		+ "' WHERE NIF='" + this.NIF + "';");
            e_mail = value;
        }
        

		public List<Prueba> getMiPruebas() 
		{
			miPruebas = Prueba.ListaPruebas(this);
			return miPruebas;
		}

        public String toString()
        {
            return this.NIF + ";" + this.NumSS + ";" + this.Nombre + ";" + this.Apellidos;
        }

		@Override
		public int compareTo(Paciente o) 
		{
			return this.NIF.compareTo(o.getNIF_Paciente());
		}
		
	    public boolean equals(Object obj)
	    {
	        return obj instanceof Paciente 
	        		&& (((Paciente)obj).getNIF_Paciente().equals(this.NIF));
	    }

	    public int hashCode()
	    {
	        return this.NIF.hashCode();
	    }

}
