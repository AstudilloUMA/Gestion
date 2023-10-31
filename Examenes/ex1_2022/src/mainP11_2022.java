import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class mainP11_2022 {

	public static void main(String[] args) 
	{
		System.out.println("PACIENTES");
		System.out.println("=========");
		PintaPacientes();
		
		System.out.println("INSERTO Cita");
		System.out.println("=============");	
		Cita c1 = new Cita("3", new Date(),9,0);
		Cita c2 = new Cita("3", new Date(),12,45);
		
		Paciente p = new Paciente("3");
		p.addCita(c1);
		p.addCita(c2);
		System.out.println("PACIENTE 3");
		System.out.println("==========");
		System.out.println(p);
		
		int idc1 = c1.getID();
		int idc2 = c2.getID();		
		c1 = null;
		c2 = null;
				
		System.out.println("MODIFICO CITAS PACIENTE 3");
		System.out.println("===========================");
		c1 = new Cita(idc1);
		c2 = new Cita(idc2);		
		c1.setHora(10);
		c2.setMinutos(0);		
		System.out.println(p);
		
		System.out.println("BORRO PRUEBAS PACIENTE 3");
		System.out.println("========================");
		c1.borrar();
		c2.borrar();
		System.out.println(p);
		
		/*
		System.out.println("========================");
		List<Paciente> lista = new ArrayList<>();
		for(Paciente p1 : Paciente.ListaPacientes())
		{
			if(p1.getFechaNacimiento_Paciente().getYear() <= 2000)
			{
				lista.add(p1);
				System.out.println(p1.toString() + p1.getFechaNacimiento_Paciente());
			}
		}
		*/
		
	}

	public static void PintaPacientes()
	{
		for(Paciente p: Paciente.ListaPacientes())
		{
			System.out.println(p);
		}		
	}
}
