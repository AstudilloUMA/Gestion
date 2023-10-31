import java.util.*;

public class Provincia
{
    private static String BD_SERVER = "localhost";
    private static String BD_NAME = "P12_2022";
    
    private String cod;
    private String des;

        public static List<Provincia> ListaProvinciaes()
        {
        	List<Provincia> lista = new ArrayList<Provincia>();
        	BD miBD = new BD(BD_SERVER,BD_NAME);
            
            for (Object[] tupla : miBD.Select("SELECT Codigo FROM tProvincia;"))
            {
                String id = (String)tupla[0];
                Provincia p = new Provincia(id);
                lista.add(p);
            }

            return lista;
        }

        public Provincia(String cod)
        {
        	BD miBD = new BD(BD_SERVER,BD_NAME);
            Object[] tupla = miBD.Select("SELECT * FROM tProvincia WHERE Codigo='" + cod + "';").get(0);

            this.cod = (String)tupla[0];
            this.des = (String)tupla[1];
        }

        public Provincia(String cod, String des)
        {
        	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Insert("INSERT INTO tProvincia VALUES('" + cod + "', '" + des + "');");
            this.cod = cod;
            this.des = des;
        }

        public String getCodigo()
        {
            return cod; 
        }
        
        public void setCodigo(String value)
        {
        	BD miBD = new BD(BD_SERVER,BD_NAME);
            miBD.Update("UPDATE tProvincia SET Codigo = '" + value
                    + "' WHERE Codigo='" + this.cod + "';");
            cod = value;
        }

        public String getDescripcion()
        {
            return des; 
        }

        public void setDescripcion(String value)            
        {            	
        	BD miBD = new BD(BD_SERVER,BD_NAME);                
        	miBD.Update("UPDATE tProvincia SET Descripcion = '" + value
                    + "' WHERE Codigo='" + this.cod + "';");
            des = value;
        }

        public String toString()
        {
            return des;
        }
}
