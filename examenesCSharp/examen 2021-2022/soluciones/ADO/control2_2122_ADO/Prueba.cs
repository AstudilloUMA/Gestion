using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDLibrary;

namespace control2_2122
{
    public class Prueba
    {
        private static string BD_SERVER = Properties.Settings.Default.BD_SERVER;
        private static string BD_NAME = Properties.Settings.Default.BD_NAME;

        private int ID;
        private Paciente paciente;
        private DateTime fecha_hora;
        private double valor;
        private string categoria;

        public static List<Prueba> ListaPruebas(Paciente paciente)
        {
            List<Prueba> lista = new List<Prueba>();
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
            foreach (object[] tupla in miBD.Select("SELECT ID FROM tPruebas WHERE NIF='" + paciente.NIF_Paciente + "';"))
            {
                int id = (int)tupla[0];
                Prueba p = new Prueba(id);
                lista.Add(p);
            }
            return lista;
        }

        public Prueba(int id)
        {
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
            object[] tupla = miBD.Select("SELECT * FROM tPruebas WHERE ID=" + id + ";")[0];

            this.ID = (int)tupla[0];
            this.paciente = new Paciente((string)tupla[1]);
            this.fecha_hora = DateTime.Parse(tupla[2].ToString());
            this.valor = double.Parse(tupla[3].ToString());
            this.categoria = ReferenciasGlucosa.ValorReferenciasGlucosa(this.valor);
         }

         public Prueba(Paciente paciente, DateTime fecha_hora, double valor)
         {
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);            
            string sFecha = fecha_hora.ToShortDateString() + " " + fecha_hora.ToShortTimeString();

            miBD.Insert("INSERT INTO tPruebas(NIF,Fecha_Hora,valor_glucosa) VALUES('" + paciente.NIF_Paciente
                 + "', '" + sFecha + "', " + valor + ");");
            this.ID = (int)miBD.SelectScalar("SELECT MAX(ID) FROM tPruebas;");
            this.paciente = paciente;
            this.fecha_hora = fecha_hora;
            this.valor = valor;
            this.categoria = ReferenciasGlucosa.ValorReferenciasGlucosa(valor);
        }
         public int IDPrueba
         {
             get { return ID; }
             // No se permite cambiar el ID de una prueba
         }

         public Paciente PacientePrueba
         {
             get { return this.paciente; }
             // No se permite cambiar el paciente de una prueba
         }

         public DateTime FechaPrueba
         {
             get { return this.fecha_hora; }
             set
             {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                string sFecha = fecha_hora.ToShortDateString() + " " + fecha_hora.ToShortTimeString();

                miBD.Update("UPDATE tPruebas SET fecha_hora = '" + sFecha + "' WHERE ID=" + this.ID + ";");
                this.fecha_hora = value;
             }
         }

         public double ValorPrueba
         {
             get { return this.valor; }
             set
             {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPruebas SET valor_glucosa = " + value + " WHERE ID=" + this.ID + ";");
                this.valor = value;
                this.categoria = ReferenciasGlucosa.ValorReferenciasGlucosa(valor);
            }
         }

         public string CategoriaPrueba
         {
             get { return categoria; }
         }

         public void BorraPrueba()
         {
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
            miBD.Delete("DELETE FROM tPruebas WHERE ID=" + this.ID + ";");
            this.ID=-1; 
            this.paciente=null;
            this.fecha_hora=DateTime.Now;
            this.valor=-1;
            this.categoria=null;
        }
    }
}
