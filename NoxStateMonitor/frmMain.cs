using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace NoxStateMonitor
{
    public partial class frmMain : Form
    {
        public const String VERSION = "0.04.00";
        private Boolean m_running = false;
        private Boolean m_inTick = false;

        /////////////////////////////////////////////////////
        public frmMain()
        {
            InitializeComponent();
        }

        /////////////////////////////////////////////////////
        private void startup()
        {
            this.Text = "Nox State Monitor " + VERSION;

            dataGridView1.Width = this.ClientSize.Width;
            dataGridView1.Height = this.ClientSize.Height - dataGridView1.Top;

            timer1.Interval = 1000;
            timer1.Start();
        }

        /////////////////////////////////////////////////////
        private void tick()
        {
            if (!m_running || m_inTick)
            {
                return;
            }

            m_inTick = true;

            poll();

            m_inTick = false;

        }

        /////////////////////////////////////////////////////
        private void poll()
        {
            //set the cursor to busy and get the start time of the poll
            Cursor.Current = Cursors.WaitCursor;

            //get raw data from the server
            String data = getDataFromServer(txtServerAddress.Text);

            //parse and display the data
            parseData(data);

            //set the cursor to normal
            Cursor.Current = Cursors.Default;
        }

        /////////////////////////////////////////////////////
        private String getDataFromServer(String address)
        {
            String ret = "";

            try
            {
                String URL = "";
                if (cbMux.Checked)
                {
                    URL = "HTTP://" + address + "/?op=stateList";
                }
                else
                {
                    URL = "HTTP://" + address + "/?op=stateList&raw=true";
                }
                WebRequest request = WebRequest.Create(URL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                ret = reader.ReadToEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception e)
            {
                lblStatus.Text = e.Message;
                lblStatus.Refresh();
                System.Threading.Thread.Sleep(500);
            }

            return ret;
        }

        /////////////////////////////////////////////////////
        private void parseData(String rawData)
        {
            String[] lines = Regex.Split(rawData, System.Environment.NewLine);

            double countPresent = 0;
            double countAbsent = 0;
            double countSquelch = 0;

            String id = "";
            String idName = "";
            String reader = "";
            String point = "";
            String zone = "";
            String state = "";
            DateTime lastSeen = DateTime.Now;
            Double weight = 0;

            String tName = "";
            String tValue = "";
            foreach (String s in lines)
            {
                if (s == "")
                {
                    continue;
                }
                try
                {
                    String[] data = s.Split('|');
                    tName = data[0];
                    tValue = data[1];
                    switch (tName)
                    {
                        case "id":
                            if (id != "")
                            {
                                //add the item to the data grid
                                if(cbMux.Checked)
                                {
                                    displayItemMuxed(id, idName, zone, state, lastSeen, weight);
                                }
                                else
                                {
                                    displayItemRaw(id, idName, reader, point, state, lastSeen, weight);
                                }
                                if (state == "present") { countPresent++; }
                                if (state == "absent") { countAbsent++; }
                                if (state == "squelch") { countSquelch++; }
                            }
                            id = tValue;
                            break;
                        case "idName":
                            idName = tValue;
                            break;
                        case "reader":
                            reader = tValue;
                            break;
                        case "point":
                            point = tValue;
                            break;
                        case "zone":
                            zone = tValue;
                            break;
                        case "state":
                            state = tValue;
                            break;
                        case "lastSeen":
                            lastSeen = DateTime.Parse(tValue);
                            break;
                        case "weight":
                            weight = Convert.ToDouble(tValue);
                            break;
                    }
                    
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error parsing data: " + e.Message);
                }
            }

            //add the last item if it exists
            if (id != "")
            {
                //add the item to the data grid
                if(cbMux.Checked)
                {
                    displayItemMuxed(id, idName, zone, state, lastSeen, weight);
                }
                else
                {
                    displayItemRaw(id, idName, reader, point, state, lastSeen, weight);
                }
                if (state == "present") { countPresent++; }
                if (state == "absent") { countAbsent++; }
                if (state == "squelch") { countSquelch++; }
            }

            //set the status text
            lblStatus.Text = "p:" + countPresent.ToString() + "   a:" + countAbsent.ToString() + "   s:" + countSquelch.ToString();
        }

        /////////////////////////////////////////////////////
        private void displayItemRaw(String id, String idName, String reader, String point, String state, DateTime lastSeen, Double weight)
        {
            Boolean bFound = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value.ToString() == id && row.Cells[2].Value.ToString() == reader && row.Cells[3].Value.ToString() == point)
                    {
                        row.Cells[4].Value = state;
                        row.Cells[5].Value = lastSeen;
                        row.Cells[6].Value = weight;

                        if (state == "present") { row.DefaultCellStyle.BackColor = Color.LawnGreen; }
                        if (state == "absent") { row.DefaultCellStyle.BackColor = Color.LightCoral; }
                        if (state == "squelch") { row.DefaultCellStyle.BackColor = Color.LemonChiffon; }

                        bFound = true;
                        break;
                    }
                }
                catch (Exception)
                {
                }
            }

            if (!bFound)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = id;
                row.Cells[1].Value = idName;
                row.Cells[2].Value = reader;
                row.Cells[3].Value = point;
                row.Cells[4].Value = state;
                row.Cells[5].Value = lastSeen;
                row.Cells[6].Value = weight;

                if (state == "present") { row.DefaultCellStyle.BackColor = Color.LawnGreen; }
                if (state == "absent") { row.DefaultCellStyle.BackColor = Color.LightCoral; }
                if (state == "squelch") { row.DefaultCellStyle.BackColor = Color.LemonChiffon; }

                dataGridView1.Rows.Add(row);
            }


        }
        /////////////////////////////////////////////////////
        private void displayItemMuxed(String id, String idName, String zone, String state, DateTime lastSeen, Double weight)
        {
            Boolean bFound = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (row.Cells[0].Value.ToString() == id && row.Cells[2].Value.ToString() == zone)
                    {
                        row.Cells[4].Value = state;
                        row.Cells[5].Value = lastSeen;
                        row.Cells[6].Value = weight;

                        if (state == "present") { row.DefaultCellStyle.BackColor = Color.LawnGreen; }
                        if (state == "absent") { row.DefaultCellStyle.BackColor = Color.LightCoral; }
                        if (state == "squelch") { row.DefaultCellStyle.BackColor = Color.LemonChiffon; }

                        bFound = true;
                        break;
                    }
                }
                catch (Exception)
                {
                }
            }

            if (!bFound)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                row.Cells[0].Value = id;
                row.Cells[1].Value = idName;
                row.Cells[2].Value = zone;
                row.Cells[3].Value = "n/a";
                row.Cells[4].Value = state;
                row.Cells[5].Value = lastSeen;
                row.Cells[6].Value = weight;

                if (state == "present") { row.DefaultCellStyle.BackColor = Color.LawnGreen; }
                if (state == "absent") { row.DefaultCellStyle.BackColor = Color.LightCoral; }

                dataGridView1.Rows.Add(row);
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        #region events
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////
        private void btnToggle_Click(object sender, EventArgs e)
        {
            if (m_running)
            {
                m_running = false;
                btnToggle.Text = "Start";
            }
            else
            {
                try
                {
                    timer1.Interval = Convert.ToInt32(txtRefresh.Text);
                }
                catch (Exception)
                {
                    timer1.Interval = 1000;
                    txtRefresh.Text = "1000";
                }
                m_running = true;
                btnToggle.Text = "Stop";
            }
        }


        /////////////////////////////////////////////////////
        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        /////////////////////////////////////////////////////
        private void btnSnapshot_Click(object sender, EventArgs e)
        {
            poll();
        }

        /////////////////////////////////////////////////////
        private void cbMux_CheckStateChanged(object sender, EventArgs e)
        {
            //need to clear the grid as results will be different
            dataGridView1.Rows.Clear();

            if (cbMux.Checked)
            {
                dataGridView1.Columns[2].HeaderText = "Zone";
            }
            else
            {
                dataGridView1.Columns[2].HeaderText = "Reader";
            }

        }

        /////////////////////////////////////////////////////
        private void frmMain_Load(object sender, EventArgs e)
        {
            startup();
        }

        /////////////////////////////////////////////////////
        private void frmMain_Resize(object sender, EventArgs e)
        {
            dataGridView1.Width = this.ClientSize.Width;
            dataGridView1.Height = this.ClientSize.Height - dataGridView1.Top;
        }

        /////////////////////////////////////////////////////
        private void timer1_Tick(object sender, EventArgs e)
        {
            tick();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion events
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
