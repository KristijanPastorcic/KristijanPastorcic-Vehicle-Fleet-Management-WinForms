
namespace Vehicle_Fleet_Management.Forms
{
    partial class RoutesForm
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
            this.lbRoutes = new System.Windows.Forms.ListBox();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.tbStartLocation = new System.Windows.Forms.TextBox();
            this.tbEndLocation = new System.Windows.Forms.TextBox();
            this.tbDistance = new System.Windows.Forms.TextBox();
            this.tbFuel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnXmlImport = new System.Windows.Forms.Button();
            this.btnXmlExport = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbRoutes
            // 
            this.lbRoutes.FormattingEnabled = true;
            this.lbRoutes.ItemHeight = 16;
            this.lbRoutes.Location = new System.Drawing.Point(2, 3);
            this.lbRoutes.Name = "lbRoutes";
            this.lbRoutes.Size = new System.Drawing.Size(221, 644);
            this.lbRoutes.TabIndex = 0;
            this.lbRoutes.SelectedIndexChanged += new System.EventHandler(this.lbRoutes_SelectedIndexChanged);
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(241, 45);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(200, 22);
            this.dtStart.TabIndex = 1;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(462, 45);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(200, 22);
            this.dtEnd.TabIndex = 2;
            // 
            // tbStartLocation
            // 
            this.tbStartLocation.Location = new System.Drawing.Point(241, 112);
            this.tbStartLocation.Name = "tbStartLocation";
            this.tbStartLocation.Size = new System.Drawing.Size(200, 22);
            this.tbStartLocation.TabIndex = 3;
            // 
            // tbEndLocation
            // 
            this.tbEndLocation.Location = new System.Drawing.Point(241, 180);
            this.tbEndLocation.Name = "tbEndLocation";
            this.tbEndLocation.Size = new System.Drawing.Size(200, 22);
            this.tbEndLocation.TabIndex = 4;
            // 
            // tbDistance
            // 
            this.tbDistance.Location = new System.Drawing.Point(241, 245);
            this.tbDistance.Name = "tbDistance";
            this.tbDistance.Size = new System.Drawing.Size(200, 22);
            this.tbDistance.TabIndex = 5;
            // 
            // tbFuel
            // 
            this.tbFuel.Location = new System.Drawing.Point(241, 311);
            this.tbFuel.Name = "tbFuel";
            this.tbFuel.Size = new System.Drawing.Size(200, 22);
            this.tbFuel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Start date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "End date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Start location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "End location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Distance";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(238, 291);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fuel spent";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(236, 618);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(495, 618);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 29);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(414, 618);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 29);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnXmlImport
            // 
            this.btnXmlImport.Location = new System.Drawing.Point(836, 76);
            this.btnXmlImport.Name = "btnXmlImport";
            this.btnXmlImport.Size = new System.Drawing.Size(135, 59);
            this.btnXmlImport.TabIndex = 16;
            this.btnXmlImport.Text = "Import xml";
            this.btnXmlImport.UseVisualStyleBackColor = true;
            this.btnXmlImport.Click += new System.EventHandler(this.btnXmlImport_Click);
            // 
            // btnXmlExport
            // 
            this.btnXmlExport.Location = new System.Drawing.Point(836, 141);
            this.btnXmlExport.Name = "btnXmlExport";
            this.btnXmlExport.Size = new System.Drawing.Size(135, 61);
            this.btnXmlExport.TabIndex = 17;
            this.btnXmlExport.Text = "Export Xml";
            this.btnXmlExport.UseVisualStyleBackColor = true;
            this.btnXmlExport.Click += new System.EventHandler(this.btnXmlExport_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMessage.Location = new System.Drawing.Point(329, 401);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 20;
            // 
            // RoutesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 659);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnXmlExport);
            this.Controls.Add(this.btnXmlImport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFuel);
            this.Controls.Add(this.tbDistance);
            this.Controls.Add(this.tbEndLocation);
            this.Controls.Add(this.tbStartLocation);
            this.Controls.Add(this.dtEnd);
            this.Controls.Add(this.dtStart);
            this.Controls.Add(this.lbRoutes);
            this.Name = "RoutesForm";
            this.Text = "RoutesForm";
            this.Load += new System.EventHandler(this.RoutesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbRoutes;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.TextBox tbStartLocation;
        private System.Windows.Forms.TextBox tbEndLocation;
        private System.Windows.Forms.TextBox tbDistance;
        private System.Windows.Forms.TextBox tbFuel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnXmlImport;
        private System.Windows.Forms.Button btnXmlExport;
        private System.Windows.Forms.Label lblMessage;
    }
}