namespace Glyder.Licensing
{
    partial class Form1
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
            this.cbSSActive = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStateService = new System.Windows.Forms.TabPage();
            this.lbExpirationStateService = new System.Windows.Forms.Label();
            this.dpStateService = new System.Windows.Forms.DateTimePicker();
            this.tabSMI = new System.Windows.Forms.TabPage();
            this.lbExpirationSMI = new System.Windows.Forms.Label();
            this.dpSMI = new System.Windows.Forms.DateTimePicker();
            this.cbSMIActive = new System.Windows.Forms.CheckBox();
            this.tabWorkflow2 = new System.Windows.Forms.TabPage();
            this.lbExpirationWorkflow = new System.Windows.Forms.Label();
            this.dpWorkflow = new System.Windows.Forms.DateTimePicker();
            this.cbWorkflowActive = new System.Windows.Forms.CheckBox();
            this.tabWorkspace = new System.Windows.Forms.TabPage();
            this.lbExpirationWorkspace = new System.Windows.Forms.Label();
            this.dpWorkspace = new System.Windows.Forms.DateTimePicker();
            this.cbWorkspaceActive = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnUpdateXML = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.btnCreateLicense = new System.Windows.Forms.Button();
            this.btnDeleteLicense = new System.Windows.Forms.Button();
            this.cbWorkflowConcurrent = new System.Windows.Forms.CheckBox();
            this.lblWorkflowNumberConcurrent = new System.Windows.Forms.Label();
            this.nuWorkflowConcurrentUsers = new System.Windows.Forms.NumericUpDown();
            this.tabControl1.SuspendLayout();
            this.tabStateService.SuspendLayout();
            this.tabSMI.SuspendLayout();
            this.tabWorkflow2.SuspendLayout();
            this.tabWorkspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuWorkflowConcurrentUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSSActive
            // 
            this.cbSSActive.AutoSize = true;
            this.cbSSActive.Checked = true;
            this.cbSSActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSSActive.Location = new System.Drawing.Point(8, 6);
            this.cbSSActive.Name = "cbSSActive";
            this.cbSSActive.Size = new System.Drawing.Size(53, 17);
            this.cbSSActive.TabIndex = 5;
            this.cbSSActive.Text = "Aktief";
            this.cbSSActive.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabStateService);
            this.tabControl1.Controls.Add(this.tabSMI);
            this.tabControl1.Controls.Add(this.tabWorkflow2);
            this.tabControl1.Controls.Add(this.tabWorkspace);
            this.tabControl1.Location = new System.Drawing.Point(0, 57);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(729, 433);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 6;
            // 
            // tabStateService
            // 
            this.tabStateService.Controls.Add(this.lbExpirationStateService);
            this.tabStateService.Controls.Add(this.dpStateService);
            this.tabStateService.Controls.Add(this.cbSSActive);
            this.tabStateService.Location = new System.Drawing.Point(4, 22);
            this.tabStateService.Name = "tabStateService";
            this.tabStateService.Padding = new System.Windows.Forms.Padding(3);
            this.tabStateService.Size = new System.Drawing.Size(721, 407);
            this.tabStateService.TabIndex = 0;
            this.tabStateService.Text = "StateService";
            this.tabStateService.UseVisualStyleBackColor = true;
            // 
            // lbExpirationStateService
            // 
            this.lbExpirationStateService.AutoSize = true;
            this.lbExpirationStateService.Location = new System.Drawing.Point(8, 33);
            this.lbExpirationStateService.Name = "lbExpirationStateService";
            this.lbExpirationStateService.Size = new System.Drawing.Size(64, 13);
            this.lbExpirationStateService.TabIndex = 9;
            this.lbExpirationStateService.Text = "Verloopt op:";
            // 
            // dpStateService
            // 
            this.dpStateService.Location = new System.Drawing.Point(78, 27);
            this.dpStateService.Name = "dpStateService";
            this.dpStateService.Size = new System.Drawing.Size(200, 20);
            this.dpStateService.TabIndex = 6;
            // 
            // tabSMI
            // 
            this.tabSMI.Controls.Add(this.lbExpirationSMI);
            this.tabSMI.Controls.Add(this.dpSMI);
            this.tabSMI.Controls.Add(this.cbSMIActive);
            this.tabSMI.Location = new System.Drawing.Point(4, 22);
            this.tabSMI.Name = "tabSMI";
            this.tabSMI.Padding = new System.Windows.Forms.Padding(3);
            this.tabSMI.Size = new System.Drawing.Size(721, 407);
            this.tabSMI.TabIndex = 1;
            this.tabSMI.Text = "SMI";
            this.tabSMI.UseVisualStyleBackColor = true;
            // 
            // lbExpirationSMI
            // 
            this.lbExpirationSMI.AutoSize = true;
            this.lbExpirationSMI.Location = new System.Drawing.Point(8, 33);
            this.lbExpirationSMI.Name = "lbExpirationSMI";
            this.lbExpirationSMI.Size = new System.Drawing.Size(64, 13);
            this.lbExpirationSMI.TabIndex = 9;
            this.lbExpirationSMI.Text = "Verloopt op:";
            // 
            // dpSMI
            // 
            this.dpSMI.Location = new System.Drawing.Point(78, 27);
            this.dpSMI.Name = "dpSMI";
            this.dpSMI.Size = new System.Drawing.Size(200, 20);
            this.dpSMI.TabIndex = 7;
            // 
            // cbSMIActive
            // 
            this.cbSMIActive.AutoSize = true;
            this.cbSMIActive.Checked = true;
            this.cbSMIActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSMIActive.Location = new System.Drawing.Point(8, 6);
            this.cbSMIActive.Name = "cbSMIActive";
            this.cbSMIActive.Size = new System.Drawing.Size(53, 17);
            this.cbSMIActive.TabIndex = 6;
            this.cbSMIActive.Text = "Aktief";
            this.cbSMIActive.UseVisualStyleBackColor = true;
            // 
            // tabWorkflow2
            // 
            this.tabWorkflow2.Controls.Add(this.nuWorkflowConcurrentUsers);
            this.tabWorkflow2.Controls.Add(this.lblWorkflowNumberConcurrent);
            this.tabWorkflow2.Controls.Add(this.cbWorkflowConcurrent);
            this.tabWorkflow2.Controls.Add(this.lbExpirationWorkflow);
            this.tabWorkflow2.Controls.Add(this.dpWorkflow);
            this.tabWorkflow2.Controls.Add(this.cbWorkflowActive);
            this.tabWorkflow2.Location = new System.Drawing.Point(4, 22);
            this.tabWorkflow2.Name = "tabWorkflow2";
            this.tabWorkflow2.Size = new System.Drawing.Size(721, 407);
            this.tabWorkflow2.TabIndex = 3;
            this.tabWorkflow2.Text = "Workflow";
            this.tabWorkflow2.UseVisualStyleBackColor = true;
            // 
            // lbExpirationWorkflow
            // 
            this.lbExpirationWorkflow.AutoSize = true;
            this.lbExpirationWorkflow.Location = new System.Drawing.Point(8, 33);
            this.lbExpirationWorkflow.Name = "lbExpirationWorkflow";
            this.lbExpirationWorkflow.Size = new System.Drawing.Size(64, 13);
            this.lbExpirationWorkflow.TabIndex = 8;
            this.lbExpirationWorkflow.Text = "Verloopt op:";
            // 
            // dpWorkflow
            // 
            this.dpWorkflow.Location = new System.Drawing.Point(78, 27);
            this.dpWorkflow.Name = "dpWorkflow";
            this.dpWorkflow.Size = new System.Drawing.Size(200, 20);
            this.dpWorkflow.TabIndex = 7;
            // 
            // cbWorkflowActive
            // 
            this.cbWorkflowActive.AutoSize = true;
            this.cbWorkflowActive.Checked = true;
            this.cbWorkflowActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWorkflowActive.Location = new System.Drawing.Point(8, 6);
            this.cbWorkflowActive.Name = "cbWorkflowActive";
            this.cbWorkflowActive.Size = new System.Drawing.Size(53, 17);
            this.cbWorkflowActive.TabIndex = 6;
            this.cbWorkflowActive.Text = "Aktief";
            this.cbWorkflowActive.UseVisualStyleBackColor = true;
            // 
            // tabWorkspace
            // 
            this.tabWorkspace.Controls.Add(this.lbExpirationWorkspace);
            this.tabWorkspace.Controls.Add(this.dpWorkspace);
            this.tabWorkspace.Controls.Add(this.cbWorkspaceActive);
            this.tabWorkspace.Location = new System.Drawing.Point(4, 22);
            this.tabWorkspace.Name = "tabWorkspace";
            this.tabWorkspace.Size = new System.Drawing.Size(721, 407);
            this.tabWorkspace.TabIndex = 2;
            this.tabWorkspace.Text = "Workspace";
            this.tabWorkspace.UseVisualStyleBackColor = true;
            // 
            // lbExpirationWorkspace
            // 
            this.lbExpirationWorkspace.AutoSize = true;
            this.lbExpirationWorkspace.Location = new System.Drawing.Point(8, 33);
            this.lbExpirationWorkspace.Name = "lbExpirationWorkspace";
            this.lbExpirationWorkspace.Size = new System.Drawing.Size(64, 13);
            this.lbExpirationWorkspace.TabIndex = 9;
            this.lbExpirationWorkspace.Text = "Verloopt op:";
            // 
            // dpWorkspace
            // 
            this.dpWorkspace.Location = new System.Drawing.Point(78, 27);
            this.dpWorkspace.Name = "dpWorkspace";
            this.dpWorkspace.Size = new System.Drawing.Size(200, 20);
            this.dpWorkspace.TabIndex = 7;
            // 
            // cbWorkspaceActive
            // 
            this.cbWorkspaceActive.AutoSize = true;
            this.cbWorkspaceActive.Checked = true;
            this.cbWorkspaceActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWorkspaceActive.Location = new System.Drawing.Point(8, 6);
            this.cbWorkspaceActive.Name = "cbWorkspaceActive";
            this.cbWorkspaceActive.Size = new System.Drawing.Size(53, 17);
            this.cbWorkspaceActive.TabIndex = 6;
            this.cbWorkspaceActive.Text = "Aktief";
            this.cbWorkspaceActive.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnUpdateXML
            // 
            this.btnUpdateXML.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateXML.Location = new System.Drawing.Point(4, 497);
            this.btnUpdateXML.Name = "btnUpdateXML";
            this.btnUpdateXML.Size = new System.Drawing.Size(160, 23);
            this.btnUpdateXML.TabIndex = 3;
            this.btnUpdateXML.Text = "Update Licentie";
            this.btnUpdateXML.UseVisualStyleBackColor = true;
            this.btnUpdateXML.Click += new System.EventHandler(this.btnUpdateXML_Click);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(4, 16);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(42, 13);
            this.lblKey.TabIndex = 7;
            this.lblKey.Text = "Sleutel:";
            // 
            // tbKey
            // 
            this.tbKey.Enabled = false;
            this.tbKey.Location = new System.Drawing.Point(53, 13);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(656, 20);
            this.tbKey.TabIndex = 8;
            // 
            // btnCreateLicense
            // 
            this.btnCreateLicense.Location = new System.Drawing.Point(186, 497);
            this.btnCreateLicense.Name = "btnCreateLicense";
            this.btnCreateLicense.Size = new System.Drawing.Size(122, 23);
            this.btnCreateLicense.TabIndex = 9;
            this.btnCreateLicense.Text = "Maak licentie aan";
            this.btnCreateLicense.UseVisualStyleBackColor = true;
            this.btnCreateLicense.Click += new System.EventHandler(this.btnCreateLicense_Click);
            // 
            // btnDeleteLicense
            // 
            this.btnDeleteLicense.Location = new System.Drawing.Point(328, 497);
            this.btnDeleteLicense.Name = "btnDeleteLicense";
            this.btnDeleteLicense.Size = new System.Drawing.Size(147, 23);
            this.btnDeleteLicense.TabIndex = 10;
            this.btnDeleteLicense.Text = "Verwijder licentie";
            this.btnDeleteLicense.UseVisualStyleBackColor = true;
            this.btnDeleteLicense.Click += new System.EventHandler(this.btnDeleteLicense_Click);
            // 
            // cbWorkflowConcurrent
            // 
            this.cbWorkflowConcurrent.AutoSize = true;
            this.cbWorkflowConcurrent.Checked = true;
            this.cbWorkflowConcurrent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbWorkflowConcurrent.Location = new System.Drawing.Point(11, 61);
            this.cbWorkflowConcurrent.Name = "cbWorkflowConcurrent";
            this.cbWorkflowConcurrent.Size = new System.Drawing.Size(114, 17);
            this.cbWorkflowConcurrent.TabIndex = 9;
            this.cbWorkflowConcurrent.Text = "Limiteer gebruikers";
            this.cbWorkflowConcurrent.UseVisualStyleBackColor = true;
            this.cbWorkflowConcurrent.CheckedChanged += new System.EventHandler(this.cbWorkflowConcurrent_CheckedChanged);
            // 
            // lblWorkflowNumberConcurrent
            // 
            this.lblWorkflowNumberConcurrent.AutoSize = true;
            this.lblWorkflowNumberConcurrent.Location = new System.Drawing.Point(155, 64);
            this.lblWorkflowNumberConcurrent.Name = "lblWorkflowNumberConcurrent";
            this.lblWorkflowNumberConcurrent.Size = new System.Drawing.Size(40, 13);
            this.lblWorkflowNumberConcurrent.TabIndex = 11;
            this.lblWorkflowNumberConcurrent.Text = "Aantal:";
            // 
            // nuWorkflowConcurrentUsers
            // 
            this.nuWorkflowConcurrentUsers.Location = new System.Drawing.Point(201, 62);
            this.nuWorkflowConcurrentUsers.Name = "nuWorkflowConcurrentUsers";
            this.nuWorkflowConcurrentUsers.Size = new System.Drawing.Size(77, 20);
            this.nuWorkflowConcurrentUsers.TabIndex = 12;
            this.nuWorkflowConcurrentUsers.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 532);
            this.Controls.Add(this.btnDeleteLicense);
            this.Controls.Add(this.btnCreateLicense);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnUpdateXML);
            this.Name = "Form1";
            this.Text = "Glyder Licensing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabStateService.ResumeLayout(false);
            this.tabStateService.PerformLayout();
            this.tabSMI.ResumeLayout(false);
            this.tabSMI.PerformLayout();
            this.tabWorkflow2.ResumeLayout(false);
            this.tabWorkflow2.PerformLayout();
            this.tabWorkspace.ResumeLayout(false);
            this.tabWorkspace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuWorkflowConcurrentUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox cbSSActive;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStateService;
        private System.Windows.Forms.TabPage tabSMI;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabWorkspace;
        private System.Windows.Forms.TabPage tabWorkflow2;
        private System.Windows.Forms.CheckBox cbSMIActive;
        private System.Windows.Forms.CheckBox cbWorkflowActive;
        private System.Windows.Forms.CheckBox cbWorkspaceActive;
        private System.Windows.Forms.DateTimePicker dpStateService;
        private System.Windows.Forms.DateTimePicker dpSMI;
        private System.Windows.Forms.DateTimePicker dpWorkflow;
        private System.Windows.Forms.DateTimePicker dpWorkspace;
        private System.Windows.Forms.Label lbExpirationStateService;
        private System.Windows.Forms.Label lbExpirationWorkflow;
        private System.Windows.Forms.Label lbExpirationSMI;
        private System.Windows.Forms.Label lbExpirationWorkspace;
        private System.Windows.Forms.Button btnUpdateXML;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.Button btnCreateLicense;
        private System.Windows.Forms.Button btnDeleteLicense;
        private System.Windows.Forms.CheckBox cbWorkflowConcurrent;
        private System.Windows.Forms.Label lblWorkflowNumberConcurrent;
        private System.Windows.Forms.NumericUpDown nuWorkflowConcurrentUsers;
    }
}

