
namespace Vehicle_Fleet_Management
{
    partial class Main
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
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnVehicles = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAllStates = new System.Windows.Forms.RadioButton();
            this.rbFuture = new System.Windows.Forms.RadioButton();
            this.rbClosed = new System.Windows.Forms.RadioButton();
            this.rbOpen = new System.Windows.Forms.RadioButton();
            this.lbWarrents = new System.Windows.Forms.ListBox();
            this.cbDrivers = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbExpences = new System.Windows.Forms.ListBox();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnUpdateItem = new System.Windows.Forms.Button();
            this.btnCreateItem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPhoneNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbWarrentDescription = new System.Windows.Forms.RichTextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lb = new System.Windows.Forms.Label();
            this.cbWarrentState = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbWarrentVehicle = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbWarrentDrivers = new System.Windows.Forms.ComboBox();
            this.dtWarrent = new System.Windows.Forms.DateTimePicker();
            this.btnRoutes = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDrivers
            // 
            this.btnDrivers.Location = new System.Drawing.Point(645, 229);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(186, 38);
            this.btnDrivers.TabIndex = 0;
            this.btnDrivers.Text = "Drivers";
            this.btnDrivers.UseVisualStyleBackColor = true;
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            // 
            // btnVehicles
            // 
            this.btnVehicles.Location = new System.Drawing.Point(645, 184);
            this.btnVehicles.Name = "btnVehicles";
            this.btnVehicles.Size = new System.Drawing.Size(186, 39);
            this.btnVehicles.TabIndex = 1;
            this.btnVehicles.Text = "Vehicles";
            this.btnVehicles.UseVisualStyleBackColor = true;
            this.btnVehicles.Click += new System.EventHandler(this.btnVehicles_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbAllStates);
            this.groupBox1.Controls.Add(this.rbFuture);
            this.groupBox1.Controls.Add(this.rbClosed);
            this.groupBox1.Controls.Add(this.rbOpen);
            this.groupBox1.Location = new System.Drawing.Point(645, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "filter";
            // 
            // rbAllStates
            // 
            this.rbAllStates.AutoSize = true;
            this.rbAllStates.Location = new System.Drawing.Point(6, 102);
            this.rbAllStates.Name = "rbAllStates";
            this.rbAllStates.Size = new System.Drawing.Size(44, 21);
            this.rbAllStates.TabIndex = 3;
            this.rbAllStates.TabStop = true;
            this.rbAllStates.Text = "All";
            this.rbAllStates.UseVisualStyleBackColor = true;
            this.rbAllStates.CheckedChanged += new System.EventHandler(this.rbAllStates_CheckedChanged);
            // 
            // rbFuture
            // 
            this.rbFuture.AutoSize = true;
            this.rbFuture.Location = new System.Drawing.Point(6, 75);
            this.rbFuture.Name = "rbFuture";
            this.rbFuture.Size = new System.Drawing.Size(70, 21);
            this.rbFuture.TabIndex = 2;
            this.rbFuture.TabStop = true;
            this.rbFuture.Text = "Future";
            this.rbFuture.UseVisualStyleBackColor = true;
            this.rbFuture.CheckedChanged += new System.EventHandler(this.rbFuture_CheckedChanged);
            // 
            // rbClosed
            // 
            this.rbClosed.AutoSize = true;
            this.rbClosed.Location = new System.Drawing.Point(6, 48);
            this.rbClosed.Name = "rbClosed";
            this.rbClosed.Size = new System.Drawing.Size(72, 21);
            this.rbClosed.TabIndex = 1;
            this.rbClosed.TabStop = true;
            this.rbClosed.Text = "Closed";
            this.rbClosed.UseVisualStyleBackColor = true;
            this.rbClosed.CheckedChanged += new System.EventHandler(this.rbClosed_CheckedChanged);
            // 
            // rbOpen
            // 
            this.rbOpen.AutoSize = true;
            this.rbOpen.Location = new System.Drawing.Point(6, 21);
            this.rbOpen.Name = "rbOpen";
            this.rbOpen.Size = new System.Drawing.Size(64, 21);
            this.rbOpen.TabIndex = 0;
            this.rbOpen.TabStop = true;
            this.rbOpen.Text = "Open";
            this.rbOpen.UseVisualStyleBackColor = true;
            this.rbOpen.CheckedChanged += new System.EventHandler(this.rbOpen_CheckedChanged);
            // 
            // lbWarrents
            // 
            this.lbWarrents.FormattingEnabled = true;
            this.lbWarrents.ItemHeight = 16;
            this.lbWarrents.Location = new System.Drawing.Point(12, 12);
            this.lbWarrents.Name = "lbWarrents";
            this.lbWarrents.Size = new System.Drawing.Size(627, 708);
            this.lbWarrents.TabIndex = 3;
            this.lbWarrents.SelectedIndexChanged += new System.EventHandler(this.lbWarrents_SelectedIndexChanged);
            // 
            // cbDrivers
            // 
            this.cbDrivers.FormattingEnabled = true;
            this.cbDrivers.Location = new System.Drawing.Point(645, 149);
            this.cbDrivers.Name = "cbDrivers";
            this.cbDrivers.Size = new System.Drawing.Size(186, 24);
            this.cbDrivers.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbExpences);
            this.groupBox2.Controls.Add(this.btnDeleteItem);
            this.groupBox2.Controls.Add(this.btnUpdateItem);
            this.groupBox2.Controls.Add(this.btnCreateItem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbPhoneNumber);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbSurname);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.Location = new System.Drawing.Point(847, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(436, 290);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Expences";
            // 
            // lbExpences
            // 
            this.lbExpences.FormattingEnabled = true;
            this.lbExpences.ItemHeight = 16;
            this.lbExpences.Location = new System.Drawing.Point(0, 125);
            this.lbExpences.Name = "lbExpences";
            this.lbExpences.Size = new System.Drawing.Size(435, 180);
            this.lbExpences.TabIndex = 20;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.Red;
            this.btnDeleteItem.Location = new System.Drawing.Point(355, 94);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(75, 29);
            this.btnDeleteItem.TabIndex = 19;
            this.btnDeleteItem.Text = "Delete";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            // 
            // btnUpdateItem
            // 
            this.btnUpdateItem.Location = new System.Drawing.Point(355, 45);
            this.btnUpdateItem.Name = "btnUpdateItem";
            this.btnUpdateItem.Size = new System.Drawing.Size(75, 29);
            this.btnUpdateItem.TabIndex = 18;
            this.btnUpdateItem.Text = "Update";
            this.btnUpdateItem.UseVisualStyleBackColor = true;
            // 
            // btnCreateItem
            // 
            this.btnCreateItem.Location = new System.Drawing.Point(355, 10);
            this.btnCreateItem.Name = "btnCreateItem";
            this.btnCreateItem.Size = new System.Drawing.Size(75, 29);
            this.btnCreateItem.TabIndex = 17;
            this.btnCreateItem.Text = "Create";
            this.btnCreateItem.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Price";
            // 
            // tbPhoneNumber
            // 
            this.tbPhoneNumber.Location = new System.Drawing.Point(123, 79);
            this.tbPhoneNumber.Name = "tbPhoneNumber";
            this.tbPhoneNumber.Size = new System.Drawing.Size(217, 22);
            this.tbPhoneNumber.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Amount";
            // 
            // tbSurname
            // 
            this.tbSurname.Location = new System.Drawing.Point(123, 51);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(217, 22);
            this.tbSurname.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Product";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(123, 23);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(217, 22);
            this.tbName.TabIndex = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(0, 368);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(476, 368);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(557, 368);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 29);
            this.btnCreate.TabIndex = 20;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRestore);
            this.groupBox3.Controls.Add(this.btnBackup);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbWarrentDescription);
            this.groupBox3.Controls.Add(this.lblMessage);
            this.groupBox3.Controls.Add(this.lb);
            this.groupBox3.Controls.Add(this.cbWarrentState);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbWarrentVehicle);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbWarrentDrivers);
            this.groupBox3.Controls.Add(this.dtWarrent);
            this.groupBox3.Controls.Add(this.btnRoutes);
            this.groupBox3.Controls.Add(this.btnDelete);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.btnCreate);
            this.groupBox3.Location = new System.Drawing.Point(651, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(637, 397);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trawel warrent data";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Description";
            // 
            // tbWarrentDescription
            // 
            this.tbWarrentDescription.Location = new System.Drawing.Point(6, 291);
            this.tbWarrentDescription.Name = "tbWarrentDescription";
            this.tbWarrentDescription.Size = new System.Drawing.Size(252, 71);
            this.tbWarrentDescription.TabIndex = 33;
            this.tbWarrentDescription.Text = "";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMessage.Location = new System.Drawing.Point(59, 67);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 32;
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Location = new System.Drawing.Point(6, 213);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(94, 17);
            this.lb.TabIndex = 31;
            this.lb.Text = "Warrent state";
            // 
            // cbWarrentState
            // 
            this.cbWarrentState.FormattingEnabled = true;
            this.cbWarrentState.Location = new System.Drawing.Point(6, 233);
            this.cbWarrentState.Name = "cbWarrentState";
            this.cbWarrentState.Size = new System.Drawing.Size(252, 24);
            this.cbWarrentState.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "Vehicles";
            // 
            // cbWarrentVehicle
            // 
            this.cbWarrentVehicle.FormattingEnabled = true;
            this.cbWarrentVehicle.Location = new System.Drawing.Point(7, 164);
            this.cbWarrentVehicle.Name = "cbWarrentVehicle";
            this.cbWarrentVehicle.Size = new System.Drawing.Size(252, 24);
            this.cbWarrentVehicle.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Drivers";
            // 
            // cbWarrentDrivers
            // 
            this.cbWarrentDrivers.FormattingEnabled = true;
            this.cbWarrentDrivers.Location = new System.Drawing.Point(6, 104);
            this.cbWarrentDrivers.Name = "cbWarrentDrivers";
            this.cbWarrentDrivers.Size = new System.Drawing.Size(252, 24);
            this.cbWarrentDrivers.TabIndex = 26;
            // 
            // dtWarrent
            // 
            this.dtWarrent.Location = new System.Drawing.Point(6, 37);
            this.dtWarrent.Name = "dtWarrent";
            this.dtWarrent.Size = new System.Drawing.Size(253, 22);
            this.dtWarrent.TabIndex = 25;
            // 
            // btnRoutes
            // 
            this.btnRoutes.Location = new System.Drawing.Point(440, 21);
            this.btnRoutes.Name = "btnRoutes";
            this.btnRoutes.Size = new System.Drawing.Size(186, 38);
            this.btnRoutes.TabIndex = 24;
            this.btnRoutes.Text = "Routes";
            this.btnRoutes.UseVisualStyleBackColor = true;
            this.btnRoutes.Click += new System.EventHandler(this.btnRoutes_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(440, 73);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(186, 38);
            this.btnBackup.TabIndex = 35;
            this.btnBackup.Text = "Backup DB";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(440, 123);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(186, 38);
            this.btnRestore.TabIndex = 36;
            this.btnRestore.Text = "Restore DB";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 738);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cbDrivers);
            this.Controls.Add(this.lbWarrents);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVehicles);
            this.Controls.Add(this.btnDrivers);
            this.Name = "Main";
            this.Text = "Travel warrents";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnVehicles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFuture;
        private System.Windows.Forms.RadioButton rbClosed;
        private System.Windows.Forms.RadioButton rbOpen;
        private System.Windows.Forms.RadioButton rbAllStates;
        private System.Windows.Forms.ListBox lbWarrents;
        private System.Windows.Forms.ComboBox cbDrivers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPhoneNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.ListBox lbExpences;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnUpdateItem;
        private System.Windows.Forms.Button btnCreateItem;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRoutes;
        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.ComboBox cbWarrentState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbWarrentVehicle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbWarrentDrivers;
        private System.Windows.Forms.DateTimePicker dtWarrent;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox tbWarrentDescription;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackup;
    }
}