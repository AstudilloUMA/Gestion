import java.util.Date;

public class mainP12_2022 {

	public static void main(String[] args) 
	{
		System.out.println("PACIENTES");
		System.out.println("=========");
		PintaPacientes();
		
		System.out.println("INSERTO Glucometria y Radiografia");
		System.out.println("================");	
		Glucometria pr1 = new Glucometria(10,"3", new Date(), 200);
		Radiografia pr2 = new Radiografia(11,"3", new Date(), true, "FICHERO TAC");
		
		Paciente p = new Paciente("3");
		System.out.println("PACIENTE 3");
		System.out.println("==========");
		System.out.println(p);
		PintaPruebas(p);
		
		System.out.println("MODIFICO PRUEBAS PACIENTE 3");
		System.out.println("===========================");
		pr1.setFecha(new Glucometria(1).getFecha());
		pr1.setVALOR_GLUCOSA(115);
		pr2.setTAC(false);
		pr2.setFICHERO("NF");
		System.out.println(p);
		PintaPruebas(p);
		
		System.out.println("BORRO PRUEBAS PACIENTE 3");
		System.out.println("========================");
		pr1.borrar();
		pr2.borrar();
		System.out.println(p);
		PintaPruebas(p);
				
		
	}

	public static void PintaPacientes()
	{
		for(Paciente p: Paciente.ListaPacientes())
		{
			System.out.println(p);
			PintaPruebas(p);

		}		
	}
	
	public static void PintaPruebas(Paciente p)
	{
		for(Prueba pr: p.getMiPruebas())
		{
			System.out.println("\t" + pr);
		}
	}
}
