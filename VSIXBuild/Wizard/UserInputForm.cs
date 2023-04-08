using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSIXBuild.Wizard
{
    internal class UserInputForm : Form
    {
        private bool cancelled = false;
        private bool autocopyBuild, removeGTFOAPIReference;
        private string selectedPath;
        private TextBox pathTextField;
        private Label label1;
        private Label label2;
        private CheckBox checkBox_AfterBuildAction;
        private Button buttonCancel;
        private CheckBox checkBox_RemoveGTFO_API_Dependency;
        private Button buttonDone;

        public UserInputForm()
        {
            InitializeComponent();
        }

        public bool Cancelled
        {
            get => cancelled;
        }

        public bool AutoCopyBuild
        {
            get => autocopyBuild;
        }

        public bool RemoveGTFOAPI
        {
            get => removeGTFOAPIReference;
        }

        public string SelectedPath
        {
            get => selectedPath;
        }

        private void InitializeComponent()
        {
            this.pathTextField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDone = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_AfterBuildAction = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBox_RemoveGTFO_API_Dependency = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pathTextField
            // 
            this.pathTextField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.pathTextField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathTextField.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pathTextField.ForeColor = System.Drawing.Color.White;
            this.pathTextField.Location = new System.Drawing.Point(14, 41);
            this.pathTextField.Margin = new System.Windows.Forms.Padding(5);
            this.pathTextField.Name = "pathTextField";
            this.pathTextField.ReadOnly = true;
            this.pathTextField.Size = new System.Drawing.Size(619, 33);
            this.pathTextField.TabIndex = 0;
            this.pathTextField.Text = "Click Here to Select Folder...";
            this.pathTextField.Click += new System.EventHandler(this.PathTextField_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.label1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(531, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select Game Profile Folder from R2modman:";
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.buttonDone.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDone.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonDone.Location = new System.Drawing.Point(488, 189);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(145, 32);
            this.buttonDone.TabIndex = 3;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = false;
            this.buttonDone.Click += new System.EventHandler(this.OnClick_DoneButton);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.label2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(531, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Options";
            // 
            // checkBox_AfterBuildAction
            // 
            this.checkBox_AfterBuildAction.AutoSize = true;
            this.checkBox_AfterBuildAction.Checked = true;
            this.checkBox_AfterBuildAction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_AfterBuildAction.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox_AfterBuildAction.Location = new System.Drawing.Point(16, 129);
            this.checkBox_AfterBuildAction.Name = "checkBox_AfterBuildAction";
            this.checkBox_AfterBuildAction.Size = new System.Drawing.Size(275, 21);
            this.checkBox_AfterBuildAction.TabIndex = 5;
            this.checkBox_AfterBuildAction.Text = "Automatically Copy Build to Plugin folder";
            this.checkBox_AfterBuildAction.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(63)))), ((int)(((byte)(70)))));
            this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCancel.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonCancel.Location = new System.Drawing.Point(14, 189);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(145, 32);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.OnClick_CancelButton);
            // 
            // checkBox_RemoveGTFO_API_Dependency
            // 
            this.checkBox_RemoveGTFO_API_Dependency.AutoSize = true;
            this.checkBox_RemoveGTFO_API_Dependency.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.checkBox_RemoveGTFO_API_Dependency.Location = new System.Drawing.Point(16, 156);
            this.checkBox_RemoveGTFO_API_Dependency.Name = "checkBox_RemoveGTFO_API_Dependency";
            this.checkBox_RemoveGTFO_API_Dependency.Size = new System.Drawing.Size(215, 21);
            this.checkBox_RemoveGTFO_API_Dependency.TabIndex = 7;
            this.checkBox_RemoveGTFO_API_Dependency.Text = "Remove GTFO-API Dependency";
            this.checkBox_RemoveGTFO_API_Dependency.UseVisualStyleBackColor = true;
            // 
            // UserInputForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(645, 233);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox_RemoveGTFO_API_Dependency);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBox_AfterBuildAction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathTextField);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserInputForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserInputForm_FormClosing);
            this.Load += new System.EventHandler(this.UserInputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PathTextField_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                pathTextField.Text = dialog.FileName;
            }

            dialog.Dispose();
        }

        private void UserInputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var path = pathTextField.Text;
            if (!cancelled && !Directory.Exists(path))
            {
                e.Cancel = true;
                MessageBox.Show(text: "Path is Invalid!", caption: "Unable to Create Project!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedPath = path;
            autocopyBuild = checkBox_AfterBuildAction.Checked;
            removeGTFOAPIReference = checkBox_RemoveGTFO_API_Dependency.Checked;
        }

        private void UserInputForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        private void OnClick_DoneButton(object sender, EventArgs e)
        {
            cancelled = false;
            this.Close();
        }

        private void OnClick_CancelButton(object sender, EventArgs e)
        {
            cancelled = true;
            this.Close();
        }
    }
}
