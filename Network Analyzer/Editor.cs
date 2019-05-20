using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Network_Analyzer.Models;
using Network_Analyzer.Network.Data;
using Network_Analyzer.Services;

namespace Network_Analyzer
{
    public partial class Editor : Form
    {
        private ConnectionModel m_ConnectionModel;

        public Editor(long connectionId)
        {
            InitializeComponent();
            Localizer.LocalizeForm(this);

            for (int i = 0; i < 100; i++)
            {
                dgvPackets.Rows.Add((i+1).ToString());
            }

            //m_ConnectionModel = Connections.GetConnection(connectionId);
        }
    }
}
