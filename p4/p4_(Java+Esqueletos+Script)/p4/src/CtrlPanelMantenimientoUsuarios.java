import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.*;

public class CtrlPanelMantenimientoUsuarios implements ActionListener  
{
	private I_PanelMantenimientoUsuarios vista;	
	private Usuario u=null;

	public CtrlPanelMantenimientoUsuarios(I_PanelMantenimientoUsuarios vista)
	{
		this.vista = vista;
	}

	public void actionPerformed(ActionEvent e) 
	{
		String cmd = e.getActionCommand();
		
		try
		{
			
			if (cmd.equals(I_PanelMantenimientoUsuarios.LOGIN))
			{								
				//COMPLETAR

				// Objetivo: Dar acceso al panel de usuario y permitir modificar si el usuario está autorizado.
				// Pasos:
				//   A) limpia todos los controles y desactiva los botones de la ventana
				vista.limpiar();
				vista.desactivaBotones();
				//   B) Comprueba que el usuario y la contraseña es correcto
				u = new Usuario(vista.getUser(),vista.getPwd());
				if(u.AccesoPantalla("USUARIOS"))
				{
				//   C)   Usuario correcto:
				//   C.1) Mostrar mensaje de "Usuario Identificado"
					vista.mensaje("Usuario Identificado");
				//   C.2) Si tiene acceso a la pantalla de "USUARIOS" invocar ActivarUsuarios en vista
					vista.ActivarUsuarios();
				//   C.3) Si tiene permiso para modificar "USUARIOS" activa el controladorLista de vista:
				//        En este paso debéis crear un objeto CtrlLista (pasando el usuario que está accediendo en el constructor)
				//        Y seguidamente invocar a controladorLista de vista con el objeto CtrlLista anteriormente creado.
					if(u.ModificarPantalla("Usuarios"))
					{
						CtrLista ctrLista = new CtrLista(u);
						vista.controladorLista(ctrLista);
					}
				}
				else
				{
				//   D)   Usuario Incorrecto:
				//   D.1) Mostrar alerta en la vista de "Usuario Desconocido"
					vista.alerta("Usuario Desconocido");
					u = null;
				}
			}
			else if (cmd.equals(I_PanelMantenimientoUsuarios.USUARIOS))
			{				
				//COMPLETAR

				// Objetivo: Preparar y cargar la lista de usuarios.
				// Pasos:
				//   A) limpiar la vista
				vista.limpiar();
				//   B) obtener la lista de usuarios
				List <Usuario> userList = Usuario.ListaUsuarios();
				//   C) pasar la lista MostrarUsuarios de vista
				vista.MostrarUsuarios(userList);
			}
		}	
		catch (Exception ex)
		{
			vista.alerta(ex.getMessage());
		}

	}

}
