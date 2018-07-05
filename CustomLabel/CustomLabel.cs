using System;
using System.Drawing;
using System.ComponentModel;
using DevExpress.XtraReports;
using DevExpress.Utils.Design;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Design;
using System.ComponentModel.Design;
using System.Collections;

namespace CustomLabel {
    [ToolboxItem(true),
    ToolboxSvgImage("CustomLabel.CustomLabel.svg, CustomLabel"),
    Designer("CustomLabel.MyCustomLabelDesigner"),
    XRDesigner("CustomLabel.MyCustomLabelDesigner")]
    public class MyCustomLabel : XRLabel {
        bool _checkValue;
        [DefaultValue(true)]
        public virtual bool CheckValue {
            get { return _checkValue; }
            set {
                if(_checkValue != value) {
                    _checkValue = value;
                    OnPropertiesChanged();
                }
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), Bindable(false)]
        public override Color ForeColor {
            get {
                return base.ForeColor;
            }
            set {
                base.ForeColor = value;
            }
        }

        public override string Text {
            get {
                return base.Text;
            }
            set {
                base.Text = value;
                OnPropertiesChanged();
            }
        }

        public MyCustomLabel() {
            //you can modify MyCustomLabel properties here for Design Time and Run Time
            this.Font = new Font("Calibri", 12, FontStyle.Bold);
            this.CheckValue = true;
        }

        private void OnPropertiesChanged() {
            int result;
            if(_checkValue)
                ForeColor = int.TryParse(Text, out result) ? Color.DarkGreen : Color.Red;
            else
                ForeColor = Color.Black;
        }
    }

    public class MyCustomLabelDesigner : XRTextControlDesigner {
        MyCustomLabel MyCustomLabel { get { return (MyCustomLabel)Component; } }
        protected override void RegisterActionLists(System.ComponentModel.Design.DesignerActionListCollection list) {
            base.RegisterActionLists(list);
            list.Add(new MyCustomLabelActionList(this));
        }
        public override void InitializeNewComponent(IDictionary defaultValues) {
            //you can modify MyCustomLabel properties here for Design Time only 
            base.InitializeNewComponent(defaultValues);
        }
    }

    public class MyCustomLabelActionList : XRComponentDesignerActionList {
        public MyCustomLabelActionList(XRComponentDesigner componentDesigner)
            : base(componentDesigner) { }

        protected override void FillActionItemCollection(DesignerActionItemCollection actionItems) {
            base.FillActionItemCollection(actionItems);
            AddPropertyItem(actionItems, "CheckValue", "CheckValue");
        }

        public bool CheckValue {
            get { return ((MyCustomLabel)this.Component).CheckValue; }
            set { this.SetPropertyValue("CheckValue", value); }
        }
    }
}
