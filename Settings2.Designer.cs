﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5466
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VTI_EVAC_AND_SINGLE_CHARGE {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class Settings2 : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings2 defaultInstance = ((Settings2)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings2())));
        
        public static Settings2 Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=\'C:\\UUTRecords\\" +
            "VtiData.mdf\';Integrated Security=sspi;Connect Timeout=30;User" +
            " Instance=True")]
        public string VtiDataConnectionString {
            get {
                return ((string)(this["VtiDataConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
        public global::System.Drawing.Color EventViewerColorInformation {
            get {
                return ((global::System.Drawing.Color)(this["EventViewerColorInformation"]));
            }
            set {
                this["EventViewerColorInformation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("255, 255, 192")]
        public global::System.Drawing.Color EventViewerColorWarning {
            get {
                return ((global::System.Drawing.Color)(this["EventViewerColorWarning"]));
            }
            set {
                this["EventViewerColorWarning"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LightSalmon")]
        public global::System.Drawing.Color EventViewerColorError {
            get {
                return ((global::System.Drawing.Color)(this["EventViewerColorError"]));
            }
            set {
                this["EventViewerColorError"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("253")]
        public int OpFormSingleHorizSplitter {
            get {
                return ((int)(this["OpFormSingleHorizSplitter"]));
            }
            set {
                this["OpFormSingleHorizSplitter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("196")]
        public int OpFormSingleVertSplitter {
            get {
                return ((int)(this["OpFormSingleVertSplitter"]));
            }
            set {
                this["OpFormSingleVertSplitter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormSingleCommandControlVisible {
            get {
                return ((bool)(this["OpFormSingleCommandControlVisible"]));
            }
            set {
                this["OpFormSingleCommandControlVisible"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormSingleFlowRateIndicatorVisible {
            get {
                return ((bool)(this["OpFormSingleFlowRateIndicatorVisible"]));
            }
            set {
                this["OpFormSingleFlowRateIndicatorVisible"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormSingleSystemSignalsVisible {
            get {
                return ((bool)(this["OpFormSingleSystemSignalsVisible"]));
            }
            set {
                this["OpFormSingleSystemSignalsVisible"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormSingleTestHistoryIsDocked {
            get {
                return ((bool)(this["OpFormSingleTestHistoryIsDocked"]));
            }
            set {
                this["OpFormSingleTestHistoryIsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormSingleValvesPanelIsDocked {
            get {
                return ((bool)(this["OpFormSingleValvesPanelIsDocked"]));
            }
            set {
                this["OpFormSingleValvesPanelIsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormSingleDataPlotIsDocked {
            get {
                return ((bool)(this["OpFormSingleDataPlotIsDocked"]));
            }
            set {
                this["OpFormSingleDataPlotIsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int OpFormSingleTestHistoryX {
            get {
                return ((int)(this["OpFormSingleTestHistoryX"]));
            }
            set {
                this["OpFormSingleTestHistoryX"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("580")]
        public int OpFormSingleTestHistoryY {
            get {
                return ((int)(this["OpFormSingleTestHistoryY"]));
            }
            set {
                this["OpFormSingleTestHistoryY"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int OpFormSingleValvesPanelX {
            get {
                return ((int)(this["OpFormSingleValvesPanelX"]));
            }
            set {
                this["OpFormSingleValvesPanelX"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("580")]
        public int OpFormSingleValvesPanelY {
            get {
                return ((int)(this["OpFormSingleValvesPanelY"]));
            }
            set {
                this["OpFormSingleValvesPanelY"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Data\\VtiData.mdf;Integr" +
            "ated Security=sspi;User Instance=True")]
        public string VtiDataConnectionString1 {
            get {
                return ((string)(this["VtiDataConnectionString1"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormSingleTestHistoryVisible {
            get {
                return ((bool)(this["OpFormSingleTestHistoryVisible"]));
            }
            set {
                this["OpFormSingleTestHistoryVisible"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("330")]
        public int OpFormDualHorizSplitter1 {
            get {
                return ((int)(this["OpFormDualHorizSplitter1"]));
            }
            set {
                this["OpFormDualHorizSplitter1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("330")]
        public int OpFormDualHorizSplitter2 {
            get {
                return ((int)(this["OpFormDualHorizSplitter2"]));
            }
            set {
                this["OpFormDualHorizSplitter2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualCommandControl1Visible {
            get {
                return ((bool)(this["OpFormDualCommandControl1Visible"]));
            }
            set {
                this["OpFormDualCommandControl1Visible"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualCommandControl2Visible {
            get {
                return ((bool)(this["OpFormDualCommandControl2Visible"]));
            }
            set {
                this["OpFormDualCommandControl2Visible"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualSystemSignals1Visible {
            get {
                return ((bool)(this["OpFormDualSystemSignals1Visible"]));
            }
            set {
                this["OpFormDualSystemSignals1Visible"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualSystemSignals2Visible {
            get {
                return ((bool)(this["OpFormDualSystemSignals2Visible"]));
            }
            set {
                this["OpFormDualSystemSignals2Visible"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualTestHistory1IsDocked {
            get {
                return ((bool)(this["OpFormDualTestHistory1IsDocked"]));
            }
            set {
                this["OpFormDualTestHistory1IsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualTestHistory2IsDocked {
            get {
                return ((bool)(this["OpFormDualTestHistory2IsDocked"]));
            }
            set {
                this["OpFormDualTestHistory2IsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualValvesPanel1IsDocked {
            get {
                return ((bool)(this["OpFormDualValvesPanel1IsDocked"]));
            }
            set {
                this["OpFormDualValvesPanel1IsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualValvesPanel2IsDocked {
            get {
                return ((bool)(this["OpFormDualValvesPanel2IsDocked"]));
            }
            set {
                this["OpFormDualValvesPanel2IsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualDataPlot1IsDocked {
            get {
                return ((bool)(this["OpFormDualDataPlot1IsDocked"]));
            }
            set {
                this["OpFormDualDataPlot1IsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool OpFormDualDataPlot2IsDocked {
            get {
                return ((bool)(this["OpFormDualDataPlot2IsDocked"]));
            }
            set {
                this["OpFormDualDataPlot2IsDocked"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int OpFormDualTestHistory1X {
            get {
                return ((int)(this["OpFormDualTestHistory1X"]));
            }
            set {
                this["OpFormDualTestHistory1X"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("580")]
        public int OpFormDualTestHistory1Y {
            get {
                return ((int)(this["OpFormDualTestHistory1Y"]));
            }
            set {
                this["OpFormDualTestHistory1Y"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("400")]
        public int OpFormDualTestHistory2X {
            get {
                return ((int)(this["OpFormDualTestHistory2X"]));
            }
            set {
                this["OpFormDualTestHistory2X"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("580")]
        public int OpFormDualTestHistory2Y {
            get {
                return ((int)(this["OpFormDualTestHistory2Y"]));
            }
            set {
                this["OpFormDualTestHistory2Y"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int OpFormDualValvesPanel1X {
            get {
                return ((int)(this["OpFormDualValvesPanel1X"]));
            }
            set {
                this["OpFormDualValvesPanel1X"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("580")]
        public int OpFormDualValvesPanel1Y {
            get {
                return ((int)(this["OpFormDualValvesPanel1Y"]));
            }
            set {
                this["OpFormDualValvesPanel1Y"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("400")]
        public int OpFormDualValvesPanel2X {
            get {
                return ((int)(this["OpFormDualValvesPanel2X"]));
            }
            set {
                this["OpFormDualValvesPanel2X"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("580")]
        public int OpFormDualValvesPanel2Y {
            get {
                return ((int)(this["OpFormDualValvesPanel2Y"]));
            }
            set {
                this["OpFormDualValvesPanel2Y"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("LawnGreen")]
        public global::System.Drawing.Color SequenceGoodColor {
            get {
                return ((global::System.Drawing.Color)(this["SequenceGoodColor"]));
            }
            set {
                this["SequenceGoodColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Red")]
        public global::System.Drawing.Color SequenceBadColor {
            get {
                return ((global::System.Drawing.Color)(this["SequenceBadColor"]));
            }
            set {
                this["SequenceBadColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Yellow")]
        public global::System.Drawing.Color SequenceTestingColor {
            get {
                return ((global::System.Drawing.Color)(this["SequenceTestingColor"]));
            }
            set {
                this["SequenceTestingColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CallUpgrade {
            get {
                return ((bool)(this["CallUpgrade"]));
            }
            set {
                this["CallUpgrade"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool OpFormSingleValvesPanelVisible {
            get {
                return ((bool)(this["OpFormSingleValvesPanelVisible"]));
            }
            set {
                this["OpFormSingleValvesPanelVisible"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Data\\VtiData.mdf;Integr" +
            "ated Security=True;Connect Timeout=30;User Instance=True")]
        public string VtiDataConnectionString2 {
            get {
                return ((string)(this["VtiDataConnectionString2"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Data\\VtiData.mdf;Integr" +
            "ated Security=True;User Instance=True")]
        public string VtiDataConnectionString3 {
            get {
                return ((string)(this["VtiDataConnectionString3"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Classes\\Data\\VtiData.md" +
            "f;Integrated Security=True;User Instance=True")]
        public string VtiDataConnectionString4 {
            get {
                return ((string)(this["VtiDataConnectionString4"]));
            }
        }
    }
}
