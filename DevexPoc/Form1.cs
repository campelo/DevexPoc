using CustomLabel;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner.Native;
using System;
using System.Drawing.Design;
using System.Windows.Forms;

namespace T461136 {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            XtraReport1 report = new XtraReport1();
            ReportDesignTool tool = new ReportDesignTool(report);

            tool.DesignForm.DesignMdiController.DesignPanelLoaded += DesignMdiController_DesignPanelLoaded;
            tool.ShowDesignerDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            XtraReport1 report = new XtraReport1();
            ReportDesignTool tool = new ReportDesignTool(report);
            tool.DesignRibbonForm.DesignMdiController.DesignPanelLoaded += DesignMdiController_DesignPanelLoaded;
            tool.ShowRibbonDesignerDialog();
        }

        void DesignMdiController_DesignPanelLoaded(object sender, DevExpress.XtraReports.UserDesigner.DesignerLoadedEventArgs e) {
            XRToolboxService ts = (XRToolboxService)e.DesignerHost.GetService(typeof(IToolboxService));
            ts.AddToolboxItem(new MyCustomToolboxItem(typeof(MyCustomLabel)), "Standard Controls");
        }
    }
    public class MyCustomToolboxItem : ToolboxItem {
        public MyCustomToolboxItem(Type toolType) : base(toolType) {
        }
        protected override void OnComponentsCreated(ToolboxComponentsCreatedEventArgs args) {
            base.OnComponentsCreated(args);
            MessageBox.Show("OnComponentsCreated");
        }
    }
}
