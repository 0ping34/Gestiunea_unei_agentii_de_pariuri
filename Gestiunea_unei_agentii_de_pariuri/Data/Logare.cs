using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Gestiunea_unei_agentii_de_pariuri.Data
{
    internal class Logare
    {
        public static MySqlConnection connMaster = new MySqlConnection();

        static string server = "127.0.0.1;";
        static string database = "casa_de_pariuri;";
        static string Uid = "admin;";
        static string password = "1234;";
        public MySqlConnection conn = new MySqlConnection($"server={server} database={database} Uid={Uid} password={password}");
        public static MySqlConnection dataSource()
        {
            connMaster = new MySqlConnection($"server={server} database={database} Uid={Uid} password={password}");
            return connMaster;
        }

        public bool bool_connOpen()
        {
            try
            {
                dataSource();
                connMaster.Open();
                return true;
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        public void connOpen()
        {
            dataSource();
            connMaster.Open();
        }

        public void connClose()
        {
            dataSource();
            connMaster.Close();
        }
    }
}
