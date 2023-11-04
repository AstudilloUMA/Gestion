import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.*;

import javax.swing.*;

public class PanelUsuario extends JPanel implements ActionListener  
{
	private JLabel lUserName, lPwd,lRol;
	private JTextField tUserName, tPwd;
	private JList<String> tRol;
	private DefaultListModel <String>modeloRol;
	private JButton bOK,bCancel;
	private boolean nuevo;
	private Usuario user, mostrado;
	private JLabel pulsaciones;
	
	public PanelUsuario(Usuario user)
	{
		nuevo = true;
		this.user = user;
		setLayout(new GridLayout(8, 2));
		
		lUserName = new JLabel("Usuario");
		lPwd = new JLabel("Contrase�a");
		lRol = new JLabel("Rol");
		
		tUserName= new JTextField(20);
		tPwd= new JTextField(20);
		tRol= new JList<String>();
		new JList<String>();
		modeloRol = new DefaultListModel<String>();
		new DefaultListModel<String>();
		tRol.setModel(modeloRol);
		bOK = new JButton("OK");
		bCancel = new JButton("CANCEL");
		
		pulsaciones = new JLabel();
		
		this.add(lUserName);
		this.add(tUserName);
		this.add(lPwd);
		this.add(tPwd);
		this.add(lRol);
		this.add(tRol);

		this.add(bOK);
		this.add(bCancel);
		
		this.add(new JLabel("Estado"));
		this.add(pulsaciones);
		
		bOK.addActionListener(this);
		bOK.setActionCommand("OK");
		
		bCancel.addActionListener(this);
		bCancel.setActionCommand("CANCEL");
		
		CargaRoles();
	}
	
	public void MostrarUsuario(Usuario u)
	{

				//COMPLETAR

				// Objetvo: cargar en los elementos gráficos del panel de usuario los datos del usuario u especificado.
				// Pasos:
				//   A) poner el nombre en tUserName
		tUserName.setText(u.getNIF());
				//   B) poner la password en tPwd
		tPwd.setText(u.getPassword());
				//   C) seleccionar el rol en tRol usando el método setSelectedValue
		tRol.setSelectedValue(u.getRol().getRolName(), true);
				//   D) este usuario está leído de la base de datos, luego no es nuevo, así que ponemos el campo nueva a false.
		nuevo = false;
				//   E) ahora mismo estamos mostrando el usuario que se nos acaba de pasar, así que asignamos a mostrado el usuario especificado.
		mostrado = u;
	}

	private void CargaRoles()
	{

				//COMPLETAR
				// Objetivo: carga los roles en la lista de roles.
				// Pasos:
				//   A) Obtener la lista de roles
				//   B) Por cada rol que exista en la lista:
				//         añadir el nombre del rol a modeloRol (usando el método modeloRol.addElement)
			for(Rol rol : Rol.ListaRoles())
			{
				modeloRol.addElement(rol.getRolName());
			}
	}
	
	
	public void actionPerformed(ActionEvent e) 
	{
		String cmd = e.getActionCommand();
		try
		{
			if (cmd.equals("CANCEL"))
			{

				//COMPLETAR
				// Objetivo: Vaciar la interfaz (todos los campos vacíos).
				// Pasos:
				//   A) Vaciar tUserName y tPwd (vaciarlos = asignarles la cadena vacía).
				tUserName.setText("");
				tPwd.setText("");
				//   B) Borrar la selección de tRol (usa setSelectedValue con "" como primer argumento)
				tRol.setSelectedValue("", true);
				//   C) Ahora no estamos mostrando ningún usuario por lo que si introducimos algo sería un usuario nuevo,
				//      así que establecemos el campo nuevo a true
				nuevo = true;
			}
			else if (cmd.equals("OK"))
			{

				//COMPLETAR
				// Objetivo: Insertar si el usuario es nuevo y actualizar si se ha modificado algo y no era nuevo.
				// Pasos:
				//   A) Si es nuevo:
				if(nuevo)
				{
				//   A.1) Crear un usuario con el nombre indicado, la password indicada y el rol seleccionado (el constructor lo insertará en la base de datos).
					Usuario u = new Usuario(tUserName.getText(),tPwd.getText());
				//   A.2) Asignar a mostrado este nuevo usuario creado.
					mostrado = u;
				//   A.3) Dado que ya está insertado en la base de datos el usuario no es nuevo, así que ponemos nuevo a false.
					nuevo = false;
				}
				else 
				{
				//   B) Si no es nuevo: (toca modificar)
				//   B.1) Si el NIF de "mostrado" es diferente al contenido de tUserName:
				//		  invocar al setter de NIF de "mostrado" para efectuar el cambio
					if(!mostrado.getNIF().equals(tUserName.getText()))
					{
						mostrado.setNIF(tUserName.getText());
					}
				//   B.2) Si la Password de "mostrado" es diferente al contenido de tPwd:
				//		  invocar al setter de Password de "mostrado" para efectuar el cambio
					if(!mostrado.getPassword().equals(tPwd.getText()))
					{
						mostrado.setPassword(tPwd.getText());
					}
				//   B.3) Si el nombre del rol de "mostrado" es diferente al contenido de tRol.getSeslectedValue():
				//		  invocar ModiRol del campo user pasando el usuario mostrado y el Rol seleccionado (hay que construir un Rol pasando el getSelectedValue anterior)
					if(!mostrado.getRol().equals(tRol.getSelectedValue()))
					{
						user.ModiRol(mostrado, new Rol(tRol.getSelectedValue()));
					}
				}
				pulsaciones.setText("Operaci�n Realizada");								
			}
		}
		catch(Exception ex)
		{
			pulsaciones.setText(ex.getMessage());
		}
		
	}
}
