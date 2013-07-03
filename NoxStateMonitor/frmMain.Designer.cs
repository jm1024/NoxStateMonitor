namespace NoxStateMonitor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnToggle = new System.Windows.Forms.Button();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.point = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastSeen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRefresh = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSnapshot = new System.Windows.Forms.Button();
            this.cbMux = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(449, 7);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(46, 23);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Text = "Start";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Location = new System.Drawing.Point(98, 8);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(101, 20);
            this.txtServerAddress.TabIndex = 1;
            this.txtServerAddress.Text = "127.0.0.1:2090";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server Address";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.idName,
            this.reader,
            this.point,
            this.state,
            this.lastSeen,
            this.weight});
            this.dataGridView1.Location = new System.Drawing.Point(0, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(784, 519);
            this.dataGridView1.TabIndex = 3;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.id.FillWeight = 88.83247F;
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 35;
            this.id.Name = "id";
            this.id.Width = 41;
            // 
            // idName
            // 
            this.idName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idName.FillWeight = 101.8614F;
            this.idName.HeaderText = "Name";
            this.idName.Name = "idName";
            this.idName.ReadOnly = true;
            this.idName.Width = 60;
            // 
            // reader
            // 
            this.reader.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reader.FillWeight = 101.8614F;
            this.reader.HeaderText = "Reader";
            this.reader.Name = "reader";
            this.reader.ReadOnly = true;
            // 
            // point
            // 
            this.point.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.point.FillWeight = 101.8614F;
            this.point.HeaderText = "Point";
            this.point.Name = "point";
            this.point.ReadOnly = true;
            // 
            // state
            // 
            this.state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.state.FillWeight = 101.8614F;
            this.state.HeaderText = "State";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            // 
            // lastSeen
            // 
            this.lastSeen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lastSeen.FillWeight = 101.8614F;
            this.lastSeen.HeaderText = "Last Seen";
            this.lastSeen.Name = "lastSeen";
            this.lastSeen.ReadOnly = true;
            this.lastSeen.Width = 80;
            // 
            // weight
            // 
            this.weight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.weight.DefaultCellStyle = dataGridViewCellStyle1;
            this.weight.FillWeight = 101.8614F;
            this.weight.HeaderText = "Weight";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 66;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(501, 7);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(46, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Refresh (ms)";
            // 
            // txtRefresh
            // 
            this.txtRefresh.Location = new System.Drawing.Point(271, 8);
            this.txtRefresh.Name = "txtRefresh";
            this.txtRefresh.Size = new System.Drawing.Size(42, 20);
            this.txtRefresh.TabIndex = 6;
            this.txtRefresh.Text = "1000";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(553, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Not Connected";
            // 
            // btnSnapshot
            // 
            this.btnSnapshot.Location = new System.Drawing.Point(379, 7);
            this.btnSnapshot.Name = "btnSnapshot";
            this.btnSnapshot.Size = new System.Drawing.Size(64, 23);
            this.btnSnapshot.TabIndex = 8;
            this.btnSnapshot.Text = "Snapshot";
            this.btnSnapshot.UseVisualStyleBackColor = true;
            this.btnSnapshot.Click += new System.EventHandler(this.btnSnapshot_Click);
            // 
            // cbMux
            // 
            this.cbMux.AutoSize = true;
            this.cbMux.Location = new System.Drawing.Point(326, 10);
            this.cbMux.Name = "cbMux";
            this.cbMux.Size = new System.Drawing.Size(46, 17);
            this.cbMux.TabIndex = 9;
            this.cbMux.Text = "Mux";
            this.cbMux.UseVisualStyleBackColor = true;
            this.cbMux.CheckStateChanged += new System.EventHandler(this.cbMux_CheckStateChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 557);
            this.Controls.Add(this.cbMux);
            this.Controls.Add(this.btnSnapshot);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.btnToggle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Nox State Monitor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn idName;
        private System.Windows.Forms.DataGridViewTextBoxColumn reader;
        private System.Windows.Forms.DataGridViewTextBoxColumn point;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastSeen;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRefresh;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSnapshot;
        private System.Windows.Forms.CheckBox cbMux;
    }
}

