﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VTI_EVAC_AND_SINGLE_CHARGE.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool CallUpgrade {
            get {
                return ((bool)(this["CallUpgrade"]));
            }
            set {
                this["CallUpgrade"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DebugMode {
            get {
                return ((bool)(this["DebugMode"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DualPortSystem {
            get {
                return ((bool)(this["DualPortSystem"]));
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
        public bool CallUpgradeDataplot {
            get {
                return ((bool)(this["CallUpgradeDataplot"]));
            }
            set {
                this["CallUpgradeDataplot"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\sqlexpress;Initial Catalog=VtiData;User ID=vtiuser;Password=vtiuser" +
            "")]
        public string VtiDataConnectionString {
            get {
                return ((string)(this["VtiDataConnectionString"]));
            }
        }
        
        /// <summary>
        /// Enter the colors for the port prompts.  Enter as &quot;ForeColor,BackColor&quot;
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Enter the colors for the port prompts.  Enter as \"ForeColor,BackColor\"")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <string>White,Blue</string>
  <string>Blue,White</string>
  <string>Yellow,Red</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection PortColors {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["PortColors"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
  <string>Blue Port</string>
  <string>White Port</string>
  <string>Red Port</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection PortNames {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["PortNames"]));
            }
        }
    }
}