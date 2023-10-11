package p2;

import java.io.*;
import java.util.List;
import java.util.Scanner;
import java.sql.*;
import com.microsoft.sqlserver.jdbc.*;

public class principal 
{

	public static void main(String[] args) throws SQLException, IOException 
	{
		//cargaMontes();
		Consulta_A();
		Consulta_B();
		Consulta_C();
		
		System.out.println("Ejecuci�n Finalizada");
	}

	public static void cargaMontes() throws SQLException, IOException 
	{		
		SQLServerDataSource ds = new SQLServerDataSource();
		ds.setIntegratedSecurity(true);
		ds.setServerName("localhost");
		ds.setPortNumber(1433);
		ds.setDatabaseName("rediam");
		Connection con = ds.getConnection();
		
		String sql = "INSERT INTO Montes (CODIGO_MONTE, COD_PROVINCIA, ESPACIO_NATURAL, SUPERFICIE, NUMERO_MONTES) VALUES (?, ?, ?, ?, ?)";
		PreparedStatement pstmt = con.prepareStatement(sql);
		Scanner sc = new Scanner(new File("montes.txt"));
		
		while(sc.hasNext())
		{
			String line = sc.nextLine();
			String[] sections = line.split(";");
			
			pstmt.setInt(1, Integer.parseInt(sections[0]));
			pstmt.setString(2, sections[1]);
			pstmt.setString(3, sections[2]);
			pstmt.setInt(4, Integer.parseInt(sections[3]));
			pstmt.setInt(5, Integer.parseInt(sections[4]));
			
			pstmt.executeUpdate();
		}
		
		sc.close();
		pstmt.close();
		con.close();
	}
	
	public static void Consulta_A() throws SQLException
	{
		SQLServerDataSource ds = new SQLServerDataSource();
		ds.setIntegratedSecurity(true);
		ds.setServerName("localhost");
		ds.setPortNumber(1433);
		ds.setDatabaseName("rediam");
		Connection con = ds.getConnection();
		
		Statement stmt = con.createStatement();
		
		ResultSet rset = stmt.executeQuery("SELECT Provincia, ESPACIO_NATURAL, SUPERFICIE FROM Montes, Provincias"
				+ " where COD_PROVINCIA = Codigo and SUPERFICIE >= 10000;");
		
		String preProv = "";
		while (rset.next())
		{   
			String prov = rset.getString("Provincia");
			if(preProv.compareTo(prov) != 0)
			{
				System.out.println("ESPACIOS NATURALES CON MAS DE 10000m2 de " + prov);
				preProv = prov;
			}
			System.out.println(
					"\t" + rset.getString("Espacio_natural") + "\t" + rset.getInt("Superficie") );
		} 
		
		rset.close();
		stmt.close();
		con.close();	
	}
	public static void Consulta_B() throws SQLException
	{
		Scanner sc = new Scanner(System.in);
		
		System.out.println("Introduzca un codigo de provincia: ");
		String codProv = sc.next();
		
		SQLServerDataSource ds = new SQLServerDataSource();
		ds.setIntegratedSecurity(true);
		ds.setServerName("localhost");
		ds.setPortNumber(1433);
		ds.setDatabaseName("rediam");
		Connection con = ds.getConnection();
		
		String consulta = "SELECT Provincia, ESPACIO_NATURAL, NUMERO_MONTES FROM Montes,Provincias WHERE "
				+ "COD_PROVINCIA = Codigo and  ? = COD_PROVINCIA;";
		
		PreparedStatement pstmt = con.prepareStatement(consulta);
		pstmt.setString(1,codProv);
		
		ResultSet rset = pstmt.executeQuery();
		
		if(rset.next())
		{
			String prov = rset.getString("Provincia");
			System.out.println("ESPACIOS NATURALES CON MAS DE 10000m2 de " + prov);
			do
			{
				System.out.println(
						"\t" + rset.getString("Espacio_Natural") + "\t" + rset.getInt("Numero_montes"));
			} while(rset.next());
		}
	}
	
	public static void Consulta_C() throws SQLException
	{
		SQLServerDataSource ds = new SQLServerDataSource();
		ds.setIntegratedSecurity(true);
		ds.setServerName("localhost");
		ds.setPortNumber(1433);
		ds.setDatabaseName("rediam");
		Connection con = ds.getConnection();
		
		String consulta = "SELECT Provincia, sum(SUPERFICIE) Superficie_Total, SUM(NUMERO_MONTES) Montes_Total FROM Montes,Provincias WHERE "
				+ "COD_PROVINCIA = Codigo GROUP BY Provincia;";
		
		Statement stmt = con.createStatement();
		
		ResultSet rset = stmt.executeQuery(consulta);
		
		while(rset.next())
		{
			System.out.println("PROVINCIA: " + rset.getString("Provincia") 
				+ "\n\t" + "TOTAL SUPERFICIE: " + rset.getInt("Superficie_Total") 
				+ "\n\t" + "TOTAL NUMERO MONTES: " + rset.getInt("Montes_Total"));
		}
		
		rset.close();
		stmt.close();
		con.close();
	}
}