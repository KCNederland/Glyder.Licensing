using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Glyder.Licensing.Models;

namespace Glyder.Licensing
{
    public partial class Form1 : Form
    {
        private GlyderLicensing gl;

        public Form1()
        {
            InitializeComponent();
            gl = new GlyderLicensing();
            tbKey.Text = gl.key;            
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            
        }

        public void loadLicense()
        {
            try
            {
                glyderLicense gll = gl.getGlyderLicense();
                cbSSActive.Checked = gll.glyderStateServiceLicense.active;
                cbSMIActive.Checked = gll.glyderSMILicense.active;
                cbWorkflowActive.Checked = gll.glyderWorkflowLicense.active;
                cbWorkspaceActive.Checked = gll.glyderWorkspaceLicense.active;
                if (dpStateService.MinDate > gll.glyderStateServiceLicense.expirationDate.Date)
                {
                    dpStateService.MinDate = gll.glyderStateServiceLicense.expirationDate.Date;
                }
                dpStateService.Value = gll.glyderStateServiceLicense.expirationDate;
                if (dpSMI.MinDate > gll.glyderSMILicense.expirationDate.Date)
                {
                    dpSMI.MinDate = gll.glyderSMILicense.expirationDate.Date;
                }
                dpSMI.Value = gll.glyderSMILicense.expirationDate;
                if (dpWorkflow.MinDate > gll.glyderWorkflowLicense.expirationDate.Date)
                {
                    dpWorkflow.MinDate = gll.glyderWorkflowLicense.expirationDate.Date;
                }
                dpWorkflow.Value = gll.glyderWorkflowLicense.expirationDate;
                if (dpWorkspace.MinDate > gll.glyderWorkspaceLicense.expirationDate.Date)
                {
                    dpWorkspace.MinDate = gll.glyderWorkspaceLicense.expirationDate.Date;
                }
                dpWorkspace.Value = gll.glyderWorkspaceLicense.expirationDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Laden licentie mislukt: " + ex.ToString());
            }
        }

        private void btnUpdateXML_Click(object sender, EventArgs e)
        {
            glyderLicense gll = bindLicense();
            

            Result updateRes = gl.updateGlyderLicense(gll);
            if (updateRes.success)
            {
                MessageBox.Show("Update succesvol", "GlyderLicensing");
            }
            else
            {
                MessageBox.Show("Update mislukt: " + updateRes.exception.ToString(), "GlyderLicensing");
            }
            
        }

        public glyderLicense bindLicense()
        {
            glyderLicense gll = new glyderLicense();
            try
            {
                gll.glyderStateServiceLicense = new GlyderStateServiceLicense();
                gll.glyderStateServiceLicense.active = cbSSActive.Checked;
                gll.glyderStateServiceLicense.expirationDate = dpStateService.Value.Date;

                gll.glyderSMILicense = new GlyderSMILicense();
                gll.glyderSMILicense.active = cbSMIActive.Checked;
                gll.glyderSMILicense.expirationDate = dpSMI.Value.Date;

                gll.glyderWorkflowLicense = new GlyderWorkflowLicense();
                gll.glyderWorkflowLicense.active = cbWorkflowActive.Checked;
                gll.glyderWorkflowLicense.expirationDate = dpWorkflow.Value.Date;

                gll.glyderWorkspaceLicense = new GlyderWorkspaceLicense();
                gll.glyderWorkspaceLicense.active = cbWorkspaceActive.Checked;
                gll.glyderWorkspaceLicense.expirationDate = dpWorkspace.Value.Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to bind license: " + ex.Message, "GlyderLicensing");
            }
            return gll;
        }
           

        private void Form1_Load(object sender, EventArgs e)
        {
            checkIfLicenseExists();
        }
        
        private void btnCreateLicense_Click(object sender, EventArgs e)
        {            
            glyderLicense gll = bindLicense();
            Result createRes = gl.createNewLicense(gll);
            if (!createRes.success)
            {
                MessageBox.Show(createRes.exception.Message);
            }
            else
            {
                checkIfLicenseExists();
            }
        }

        private void btnDeleteLicense_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Weet u zeker dat u de licentie wilt verwijderen?", "GlyderLicensing", MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                gl.deleteLicense();
                checkIfLicenseExists();
            }
        }

        private void checkIfLicenseExists()
        {
            try
            {
                btnDeleteLicense.Enabled = false;
                btnUpdateXML.Enabled = false;
                btnCreateLicense.Enabled = false;

                if (gl.checkifLicenseExists())
                {
                    loadLicense();
                    btnUpdateXML.Enabled = true;
                    btnDeleteLicense.Enabled = true;
                }
                else
                {
                    DateTime initialDateTime = DateTime.Now.AddMonths(1);

                    dpStateService.MinDate = initialDateTime;
                    dpSMI.MinDate = initialDateTime;
                    dpWorkflow.MinDate = initialDateTime;
                    dpWorkspace.MinDate = initialDateTime;

                    btnCreateLicense.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "GlyderLicensing");
            }
        }

        private void cbWorkflowConcurrent_CheckedChanged(object sender, EventArgs e)
        {
            lblWorkflowNumberConcurrent.Visible = cbWorkflowConcurrent.Checked;
            nuWorkflowConcurrentUsers.Visible = cbWorkflowConcurrent.Checked;            
        }
    }
}
