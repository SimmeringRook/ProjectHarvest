using Core.Utilities.Validation;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Core.Utilities.General
{
    internal static class ControlFactory
    {
        internal static Control CreateControlTemplate(Control templateType, string validationRegex = "", ErrorProvider errorProvider = null)
        {
            if (templateType is TextBox)
                return CreateTextbox(validationRegex, errorProvider);
            else if (templateType is Label)
                return CreateLabel();
            else if (templateType is ComboBox)
                return CreateComboBox();
            else if (templateType is CheckBox)
                return CreateCheckBox();
            else
                throw new NotImplementedException();
        }

        #region Templates
        private static TextBox CreateTextbox(string regex, ErrorProvider errorProvider)
        {
            TextBox template = new TextBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);

            if (errorProvider != null)
                template.Validating += (object sender, CancelEventArgs e) => { HarvestValidator.Validate(template, regex, errorProvider); };
            return template;
        }

        private static Label CreateLabel()
        {
            Label template = new Label();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
        }

        private static ComboBox CreateComboBox()
        {
            ComboBox template = new ComboBox();
            template.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            return template;
        }

        private static CheckBox CreateCheckBox()
        {
            CheckBox template = new CheckBox();
            template.Anchor = AnchorStyles.None;
            return template;
        }
        #endregion
    }
}
