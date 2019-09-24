using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MokaCom
{
    internal partial class SelectServerForm : Form
    {
        private const string ServerInstanceRegistryKey = @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL";
        private const string SqlServerRegistryKey = @"SOFTWARE\Microsoft\Microsoft SQL Server";
        internal string SelectedServer { get; set; }
        internal string SelectedDatabase { get; set; }
        public List<DbServer> DbServers { get; set; }

        internal SelectServerForm()
        {
            InitializeComponent();
            mokaDatabases = new MokaDatabases();
        }

        private void SelectServerForm_Load(object sender, EventArgs e)
        {

            // Local Servers
            string ServerName = Environment.MachineName;
            RegistryView registryView = Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32;
            using (RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, registryView))
            {
                using (RegistryKey instancesKey = hklm.OpenSubKey(ServerInstanceRegistryKey))
                {
                    if (instancesKey != null)
                    {
                        using (instancesKey)
                        {
                            foreach (string instanceName in instancesKey.GetValueNames())
                            {
                                string instanceSetupKeyName = string.Format($"{SqlServerRegistryKey}\\{(string)instancesKey.GetValue(instanceName)}\\Setup");
                                try
                                {
                                    RegistryKey instanceSetupKey = hklm.OpenSubKey(instanceSetupKeyName);
                                    if (instanceSetupKey != null)
                                    {
                                        using (instanceSetupKey)
                                        {
                                            string version = (string)instanceSetupKey.GetValue("Version");
                                            string edition = (string)instanceSetupKey.GetValue("Edition");

                                            MokaDatabases.ServersRow srv = mokaDatabases.Servers.AddServersRow($@".\{instanceName}");
                                            GetDatabases(srv);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {

                                    throw;
                                }
                            }
                        }
                    }
                }
            };
            // Network servers
            SqlDataSourceEnumerator ServerLister = SqlDataSourceEnumerator.Instance;
            DataTable SqlServers = ServerLister.GetDataSources();
            foreach (DataRow server in SqlServers.Rows)
            {
                string thisServer = "";
                if (string.IsNullOrEmpty(server["InstanceName"].ToString())) thisServer = server["ServerName"].ToString();
                else thisServer = server["ServerName"].ToString() + "\\" + server["InstanceName"].ToString();

                MokaDatabases.ServersRow srv = mokaDatabases.Servers.AddServersRow(thisServer);
                GetDatabases(srv);
            }
        }

        private void GetDatabases(MokaDatabases.ServersRow server)
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder()
            {
                DataSource = server.Name,
                IntegratedSecurity = true,
                ConnectTimeout = 5
            };

            SqlConnection sqlConn = new SqlConnection(conn.ConnectionString);
            sqlConn.Open();
            DataTable tblDatabases = sqlConn.GetSchema("Databases");
            sqlConn.Close();

            foreach (DataRow row in tblDatabases.Rows)
            {
                string strDatabaseName = row["database_name"].ToString();
                mokaDatabases.Databases.AddDatabasesRow(server, strDatabaseName); ;
            }

        }


        private void OK_Click(object sender, EventArgs e)
        {
            if (serversListBox.SelectedIndex > -1)
                SelectedServer = serversListBox.SelectedValue.ToString();
            else
                SelectedServer = string.Empty;
            if (databasesListBox.SelectedIndex > -1)
                SelectedDatabase = databasesListBox.SelectedValue.ToString();
            else
                SelectedDatabase = string.Empty;
        }

        internal class DbServer
        { 
            internal string ServerName { get; set; }
            internal List<string> Databases { get; set; }
            public DbServer()
            {
                this.Databases = new List<string>();
            }
        }
    }
}
