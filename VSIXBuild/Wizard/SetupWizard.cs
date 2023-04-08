using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSIXBuild.Wizard
{
    internal class SetupWizard : IWizard
    {
        private UserInputForm form;

        // This method is called before opening any item that
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem
            projectItem)
        {
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
        }

        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            try
            {
                form = new UserInputForm();
                form.ShowDialog();

                if (form.Cancelled)
                {
                    throw new WizardCancelledException("Project Creation Cancelled by input!");
                }

                replacementsDictionary["$mainmodpath$"] = form.SelectedPath;
                replacementsDictionary["$copybuildtoplugins$"] = form.AutoCopyBuild ? "true" : "false";
            }
            catch (WizardCancelledException cE)
            {
                throw cE;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}
