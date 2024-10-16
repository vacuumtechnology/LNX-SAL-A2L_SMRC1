using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using VTIWindowsControlLibrary.Classes.Configuration;
using VTIWindowsControlLibrary.Classes.IO;
using VTIWindowsControlLibrary.Interfaces;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration
{

    /// <summary>
    /// IOSettings
    /// 
    /// </summary>
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    [XmlRoot("IOSettings")]
    public class IOSettings : ApplicationSettingsBase, IIOSettings
    {
        [UserScopedSetting()]
        [XmlElement("Interface")]
        [DefaultSettingValue(@"
            <IOInterface>
                <Name>PLC</Name>
                <InterfaceDLL>VtiPLCInterface.DLL</InterfaceDLL>
            </IOInterface>
        ")]
        public IOInterface Interface
        {
            get
            {
                return ((IOInterface)this["Interface"]);
            }
            set
            {
                this["Interface"] = (IOInterface)value;
            }
        }
    }

}
