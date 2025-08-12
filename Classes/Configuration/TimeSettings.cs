using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using VTIWindowsControlLibrary.Classes.Configuration;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration
{

    /// <summary>
    /// COMMON TIME parameters
    /// </summary>
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    [SettingsProvider(typeof(AllUsersSettingsProvider))]
    [XmlRoot("TimeSettings")]
    public class TimeSettings : EditCycleApplicationSettingsBase
    {

        #region Tool_Open_Evac_Valve_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Tool Open Evac Delay</DisplayName>
                <ProcessValue>5</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time delay to evacuate the charge hoses and charge tools.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Tool_Open_Evac_Valve_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Tool_Open_Evac_Valve_Delay"]);
            }
            set
            {
                this["Tool_Open_Evac_Valve_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Tool_Quick_Check_Pressure_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Tool Quick Check Pressure Delay</DisplayName>
                <ProcessValue>3</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>At the end of the Tool Quick Check Pressure Delay if the pressure in the tool is above Tool_Quick_Check_Pressure_Setpoint, the tool is not connected to the unit.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Tool_Quick_Check_Pressure_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Tool_Quick_Check_Pressure_Delay"]);
            }
            set
            {
                this["Tool_Quick_Check_Pressure_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Tool_Check_Pressure_Timeout : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Tool Check Pressure Timeout</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Maximum time delay to check if tool is connected.  If the tool pressure is above the Tool_Check_Pressure_Setpoint at the end of the Tool_Check_Pressure_Timeout, the tool is not connected to the part.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Tool_Check_Pressure_Timeout
        {
            get
            {
                return ((TimeDelayParameter)this["Tool_Check_Pressure_Timeout"]);
            }
            set
            {
                this["Tool_Check_Pressure_Timeout"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Precharged_Unit_Check_Valve_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Precharged Unit Check Valve Delay</DisplayName>
                <ProcessValue>0.5</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Valve Step is opened and unit pressure is sensed.  If the tool pressure is greater Precharged_Unit_Check_Pressure_Setpoint after the Precharge_unit_Check_Open_Valve_Delay the unit is already filled with refrigerant.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Precharged_Unit_Check_Valve_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Precharged_Unit_Check_Valve_Delay"]);
            }
            set
            {
                this["Precharged_Unit_Check_Valve_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Pump_Before_Connector_Check_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Pump Before Connector Check Delay</DisplayName>
                <ProcessValue>2</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time to pump the unit before performing the connector check.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Pump_Before_Connector_Check_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Pump_Before_Connector_Check_Delay"]);
            }
            set
            {
                this["Pump_Before_Connector_Check_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Connector_Check_Timeout : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Connector Check Timeout</DisplayName>
                <ProcessValue>3</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>If the vacuum gauge pressure goes below the Connector_Check_Pressure_Setpoint at the end of the Connector_Check_Timeout a part is not connected to the tool, it is blanked or the service valve is closed.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Connector_Check_Timeout
        {
            get
            {
                return ((TimeDelayParameter)this["Connector_Check_Timeout"]);
            }
            set
            {
                this["Connector_Check_Timeout"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Base_Pressure_Check_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Base Pressure Check Delay</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>If the vacuum gauge pressure is greater then the Base_Pressure_Check_Pressure_Setpoint at the end of the Base_Pressure_Check_Delay the part fails, possibly indicating a problem with the vacuum pump.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Base_Pressure_Check_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Base_Pressure_Check_Delay"]);
            }
            set
            {
                this["Base_Pressure_Check_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Hose_Pre_Fill_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Hose Pre Fill Delay</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Amount of time to pre-fill the hose with refrigerant before charging the unit.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Hose_Pre_Fill_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Hose_Pre_Fill_Delay"]);
            }
            set
            {
                this["Hose_Pre_Fill_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Tool_Evac_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Tool Evac Delay</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time allowed to evac the tool.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Tool_Evac_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Tool_Evac_Delay"]);
            }
            set
            {
                this["Tool_Evac_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Unit_Recovery_Timeout : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Unit Recovery Timeout</DisplayName>
                <ProcessValue>1200</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time allowed to recover refrigerant from a unit.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Unit_Recovery_Timeout
        {
            get
            {
                return ((TimeDelayParameter)this["Unit_Recovery_Timeout"]);
            }
            set
            {
                this["Unit_Recovery_Timeout"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Diag_Test_Evac_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic Test Evac Delay</DisplayName>
                <ProcessValue>120</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Evacuation time before the diagnositic rate of rise tests to check the manifold and tools.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Diag_Test_Evac_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Diag_Test_Evac_Delay"]);
            }
            set
            {
                this["Diag_Test_Evac_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Diag_Test_Settle_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic Test Settle Delay</DisplayName>
                <ProcessValue>120</ProcessValue>
                <MinValue>30</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time delay for the diagnositic rate of rise tests to allow the pressure to settle after closing the rate of rise valve.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Diag_Test_Settle_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Diag_Test_Settle_Delay"]);
            }
            set
            {
                this["Diag_Test_Settle_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Diag_Test_ROR_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic Test Rate Of Rise Delay</DisplayName>
                <ProcessValue>120</ProcessValue>
                <MinValue>120</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time delay for the diagnositic rate of rise tests to check the manifold and tools.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Diag_Test_ROR_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Diag_Test_ROR_Delay"]);
            }
            set
            {
                this["Diag_Test_ROR_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region RoughPumpIdlePowerOff : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Rough Pump Idle Power Off Delay</DisplayName>
                <ProcessValue>5</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time delay to turn off the rough pump when the system is idle. Set to 0 to run pump continually.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter RoughPumpIdlePowerOff
        {
            get
            {
                return ((TimeDelayParameter)this["RoughPumpIdlePowerOff"]);
            }
            set
            {
                this["RoughPumpIdlePowerOff"] = (TimeDelayParameter)value;
            }
        }
        #endregion


        #region LateLeakCheckEvacDelay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Late Leak Check Evac Delay</DisplayName>
                <ProcessValue>2400</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time delay to evacuate the unit when performing a Late Leak Test</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter LateLeakCheckEvacDelay
        {
            get
            {
                return ((TimeDelayParameter)this["LateLeakCheckEvacDelay"]);
            }
            set
            {
                this["LateLeakCheckEvacDelay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region Late_Leak_Check_ROR_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Late Leak Check ROR Delay</DisplayName>
                <ProcessValue>15</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time delay to perform the ROR on the unit when performing a Late Leak Test</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Late_Leak_Check_ROR_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Late_Leak_Check_ROR_Delay"]);
            }
            set
            {
                this["Late_Leak_Check_ROR_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        //vvvvvvvvvvvvvv
        //Diagnostic Sequence
        #region DiagBasePressChckDly : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic: Base Pressure Check Delay</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>3</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>The amount of time the system will wait before checking the base pressure during the diagnostic sequence</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter DiagBasePressChckDly
        {
            get
            {
                return ((TimeDelayParameter)this["DiagBasePressChckDly"]);
            }
            set
            {
                this["DiagBasePressChckDly"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region DiagInitialEvacDelay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic: Initial Evacuation Time</DisplayName>
                <ProcessValue>300</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>3600</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>The amount of time the system will Evacuate the guns at the beginning of the diagnostic sequence</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter DiagInitialEvacDelay
        {
            get
            {
                return ((TimeDelayParameter)this["DiagInitialEvacDelay"]);
            }
            set
            {
                this["DiagInitialEvacDelay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region DiagEvacMaxTime : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic: Max Evacuation Time</DisplayName>
                <ProcessValue>300</ProcessValue>
                <MinValue>10</MinValue>
                <MaxValue>3600</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>The Maximum Time any evacuation during the diagnostic sequence can take before failing</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter DiagEvacMaxTime
        {
            get
            {
                return ((TimeDelayParameter)this["DiagEvacMaxTime"]);
            }
            set
            {
                this["DiagEvacMaxTime"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region DiagRORDelay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic: Rate of Rise Time Delay</DisplayName>
                <ProcessValue>180</ProcessValue>
                <MinValue>10</MinValue>
                <MaxValue>3600</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>The amount of time every Rate of Rise in the diagnostic sequence will take before checking the pressure</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter DiagRORDelay
        {
            get
            {
                return ((TimeDelayParameter)this["DiagRORDelay"]);
            }
            set
            {
                this["DiagRORDelay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region DiagVentingDelay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic: Venting Delay</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>3</MinValue>
                <MaxValue>300</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>This is the amount of time the hoses will spend venting before checking if the hoses are vented. needs to be vented to check the ROR valve in the diagnostic sequence </ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter DiagVentingDelay
        {
            get
            {
                return ((TimeDelayParameter)this["DiagVentingDelay"]);
            }
            set
            {
                this["DiagVentingDelay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region DiagRORValveChckDelay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic: Max Check ROR Valve Delay</DisplayName>
                <ProcessValue>0</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Maximum time it will spend checking the ROR valve in the diagnostic sequence</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter DiagRORValveChckDelay
        {
            get
            {
                return ((TimeDelayParameter)this["DiagRORValveChckDelay"]);
            }
            set
            {
                this["DiagRORValveChckDelay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region DiagMaxRcvrSupplyDly : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Diagnostic: Max time to Recover Supply lines</DisplayName>
                <ProcessValue>5</ProcessValue> 
                <MinValue>0</MinValue>
                <MaxValue>600</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Maximum time system will try to recover supply lines during diagnostic. Important because if you forgot to close supply valve, system will not fail for this amount of time.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter DiagMaxRcvrSupplyDly
        {
            get
            {
                return ((TimeDelayParameter)this["DiagMaxRcvrSupplyDly"]);
            }
            set
            {
                this["DiagMaxRcvrSupplyDly"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        //^^^^^^^^^^^^^^

    }
}
