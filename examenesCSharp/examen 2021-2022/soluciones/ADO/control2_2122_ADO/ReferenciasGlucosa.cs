using System;
using System.Collections.Generic;
using System.Text;
using BDLibrary;

namespace control2_2122
{
    class ReferenciasGlucosa
    {
        private static string BD_SERVER = Properties.Settings.Default.BD_SERVER;
        private static string BD_NAME = Properties.Settings.Default.BD_NAME;

        public static List<string> ListaValoresReferenciasGlucosa()
        {
            List<string> lista = new List<string>();
            lista.Add("Valor Erroneo");
            SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
            foreach (object[] tupla in miBD.Select("SELECT categoria FROM tReferenciasGlucosa;"))
            {
                lista.Add((string)tupla[0]);
            }
            return lista;
        }
        public static string ValorReferenciasGlucosa(double valor)
        {
            string res;

            try
            {
                SQLSERVERDB miBD = new SQLSERVERDB(BD_SERVER, BD_NAME);
                res = (string)miBD.SelectScalar("SELECT categoria FROM tReferenciasGlucosa WHERE desde <= " + valor
                            + " AND " + valor + " < hasta;");
                if (res == null || res.Length == 0) res = "Valor Erroneo";
            }
            catch
            {
                res = "Valor Erroneo";
            }
            return res;
        }

    }
}
