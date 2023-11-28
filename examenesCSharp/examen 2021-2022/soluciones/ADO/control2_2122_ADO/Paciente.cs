using System;
using System.Collections.Generic;
using System.Text;
using BDLibrary;

namespace control2_2122
{
    public class Paciente
    {
        private static string BD_SERVER = Properties.Settings.Default.BD_SERVER;
        private static string BD_NAME = Properties.Settings.Default.BD_NAME;

        private string NIF;
        private int NumSS;
        private string Nombre;
        private string Apellidos;
        private string Sexo;
        private DateTime FechaNacimiento;
        private string Direccion;
        private string Poblacion;
        private Provincia Provincia;
        private string CodigoPostal;
        private string Telefono;
        private string e_mail;

        public static List<Paciente> ListaPacientes()
        {
            List<Paciente> lista = new List<Paciente>();
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
            foreach (object[] tupla in miBD.Select("SELECT NIF FROM tPaciente;"))
            {
                string id = (string)tupla[0];
                Paciente p = new Paciente(id);
                lista.Add(p);
            }
            return lista;
        }

        public Paciente(string nif)
        {
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
            object[] tupla = miBD.Select("SELECT * FROM tPaciente WHERE NIF='" + nif + "';")[0];

            NIF= (string)tupla[0];
            NumSS = (int)tupla[1];
            Nombre= (string)tupla[2];
            Apellidos= (string)tupla[3];
            Sexo= (string)tupla[4];
            string[] fecha = tupla[5].ToString().Split('-');
            FechaNacimiento = new DateTime(int.Parse(fecha[0]), 
                int.Parse(fecha[1]), 
                int.Parse(fecha[2]));
            Direccion = (string)tupla[6];
            Poblacion = (string)tupla[7];
            Provincia = new Provincia((string)tupla[8]);
            CodigoPostal = (string)tupla[9];
            Telefono = (string)tupla[10];
            e_mail = (string)tupla[11];
            
        }

        public Paciente(string DNI_NIE, int NumSS, string Nombre, string Apellidos, string Sexo,
            DateTime FechaNacimiento, string Direccion, string Poblacion, Provincia Provincia,
            string CodigoPostal, string Telefono, string e_mail)
        {
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
            string ins = "INSERT INTO tPaciente VALUES('" + DNI_NIE + "', " + NumSS + ", '"
                + Nombre + "', '" + Apellidos + "', '" + Sexo + "', '" + FechaNacimiento.ToShortDateString()
                + "', '" + Direccion + "', '" + Poblacion + "', '" + Provincia.Codigo + "', '" + CodigoPostal
                + "', '" + Telefono + "', '" + e_mail + "');";
            miBD.Insert(ins);

            this.NIF = DNI_NIE;
            this.NumSS = NumSS;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Sexo = Sexo;
            this.FechaNacimiento = FechaNacimiento;
            this.Direccion = Direccion;
            this.Poblacion = Poblacion;
            this.Provincia = Provincia;
            this.CodigoPostal = CodigoPostal;
            this.Telefono = Telefono;
            this.e_mail = e_mail;
        }

        public void BorrarPaciente()
        {
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
            miBD.Delete("DELETE tPaciente WHERE NIF='" + this.NIF + "';");

            NumSS = -1;
            NIF = null;
            Nombre = null;
            Apellidos = null;
            Sexo = null;
            FechaNacimiento = DateTime.Today;
            Direccion = null;
            Poblacion = null;
            Provincia = null;
            CodigoPostal = null;
            Telefono = null;
            e_mail = null;

        }

        public int NumeroSS_Paciente
        {
            get { return NumSS; }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET NumSeguro=" + value + " WHERE NIF='" + this.NIF + "';");
                NumSS = value;
            }
        }


        public string NIF_Paciente
        {
            get
            {
                return NIF;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET NIF='" + value +"' WHERE NIF='" + this.NIF + "';");
                NIF = value;
            }
        }

        public string Nombre_Paciente
        {
            get
            {
                return Nombre;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET Nombre='" + value + "' WHERE NIF='" + this.NIF + "';"); 
                Nombre = value;
            }
        }

        public string Apellidos_Paciente
        {
            get
            {
                return Apellidos;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET Apellidos='" + value + "' WHERE NIF='" + this.NIF + "';");
                Apellidos = value;
            }
        }

        public string Sexo_Paciente
        {
            get
            {
                return Sexo;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET Sexo='" + value + "' WHERE NIF='" + this.NIF + "';");
                Sexo = value;
            }
        }

        public DateTime FechaNacimiento_Paciente
        {
            get
            {
                return FechaNacimiento;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET FechaNacimiento='" + value.ToShortDateString()
                    + "' WHERE NIF='" + this.NIF + "';");
                FechaNacimiento = value;
            }
        }

        public string Direccion_Paciente
        {
            get
            {
                return Direccion;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET Direccion='" + value + "' WHERE NIF='" + this.NIF + "';");
                Direccion = value;
            }
        }

        public string Poblacion_Paciente
        {
            get
            {
                return Poblacion;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET Poblacion='" + value + "' WHERE NIF='" + this.NIF + "';");
                Poblacion = value;
            }
        }

        public Provincia Provincia_Paciente
        {
            get
            {
                return Provincia;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET Provincia='" + value.Codigo + "' WHERE NIF='" + this.NIF + "';");
                Provincia = value;
            }
        }

        public string CodigoPostal_Paciente
        {
            get
            {
                return CodigoPostal;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET CodigoPostal='" + value + "' WHERE NIF='" + this.NIF + "';");
                CodigoPostal = value;
            }
        }

        public string Telefono_Paciente
        {
            get
            {
                return Telefono;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET Telefono='" + value + "' WHERE NIF='" + this.NIF + "';");
                Telefono = value;
            }
        }

        public string e_mail_Paciente
        {
            get
            {
                return e_mail;
            }
            set
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                miBD.Update("UPDATE tPaciente SET e_mail='" + value + "' WHERE NIF='" + this.NIF + "';"); e_mail = value;
            }
        }

        public override string ToString()
        {
            return NIF + ";" + Nombre + ";" + Apellidos;
        }

        public override bool Equals(object obj)
        {
            return obj is Paciente && ((Paciente)obj).NIF.Equals(NIF);
        }

        public override int GetHashCode()
        {
            return NIF.GetHashCode();
        }
    }
}
