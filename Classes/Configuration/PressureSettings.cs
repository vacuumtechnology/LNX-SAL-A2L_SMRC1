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
    /// COMMON PRESSURE parameters
    /// </summary>
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    [SettingsProvider(typeof(AllUsersSettingsProvider))]
    [XmlRoot("PressureSettings")]
    public class PressureSettings : EditCycleApplicationSettingsBase
    {


        #region LateLeakCheckRORMaxSetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Late Leak Check ROR Max Set Point</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>5000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Full Scale range of Blue Supply manifold fill transducer.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter LateLeakCheckRORMaxSetPoint
        {
            get
            {
                return ((NumericParameter)this["LateLeakCheckRORMaxSetPoint"]);
            }
            set
            {
                this["LateLeakCheckRORMaxSetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region BlueCircuit2SupplyTransducerFullScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Supply Transducer Full Scale</DisplayName>
                <ProcessValue>1000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>5000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Full Scale range of Ref1 Supply manifold fill transducer.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCircuit2SupplyTransducerFullScale
        {
            get
            {
                return ((NumericParameter)this["BlueCircuit2SupplyTransducerFullScale"]);
            }
            set
            {
                this["BlueCircuit2SupplyTransducerFullScale"] = (NumericParameter)value;
            }
        }
        #endregion
        #region BlueCircuit2SupplyTransducerOffset : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Supply Transducer Offset</DisplayName>
                <ProcessValue>0</ProcessValue>    
                <MinValue>-1000</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Zero Offset of Blue Supply manifold fill transducer</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCircuit2SupplyTransducerOffset
        {
            get
            {
                return ((NumericParameter)this["BlueCircuit2SupplyTransducerOffset"]);
            }
            set
            {
                this["BlueCircuit2SupplyTransducerOffset"] = (NumericParameter)value;
            }
        }
        #endregion
        #region BlueCircuit2ToolCheckTransducerFullScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Tool Check Transducer Full Scale</DisplayName>
                <ProcessValue>1000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>5000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Full Scale range of Ref1 Tool Check manifold fill transducer.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCircuit2ToolCheckTransducerFullScale
        {
            get
            {
                return ((NumericParameter)this["BlueCircuit2ToolCheckTransducerFullScale"]);
            }
            set
            {
                this["BlueCircuit2ToolCheckTransducerFullScale"] = (NumericParameter)value;
            }
        }
        #endregion
        #region BlueCircuit2ToolCheckTransducerOffset : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Tool Check Transducer Offset</DisplayName>
                <ProcessValue>1.5</ProcessValue>    
                <MinValue>-1000</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Zero Offset of Ref1 Tool Check manifold fill transducer</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCircuit2ToolCheckTransducerOffset
        {
            get
            {
                return ((NumericParameter)this["BlueCircuit2ToolCheckTransducerOffset"]);
            }
            set
            {
                this["BlueCircuit2ToolCheckTransducerOffset"] = (NumericParameter)value;
            }
        }
        #endregion

        #region BlueCircuit2LoSideToolCheckTransducerFullScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Low Side Tool Check Transducer Full Scale</DisplayName>
                <ProcessValue>1000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>5000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Full Scale range of Ref1 Low Side Tool Check manifold fill transducer.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCircuit2LoSideToolCheckTransducerFullScale
        {
            get
            {
                return ((NumericParameter)this["BlueCircuit2LoSideToolCheckTransducerFullScale"]);
            }
            set
            {
                this["BlueCircuit2LoSideToolCheckTransducerFullScale"] = (NumericParameter)value;
            }
        }
        #endregion
        #region BlueCircuit2LoSideToolCheckTransducerOffset : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Low Side Tool Check Transducer Offset</DisplayName>
                <ProcessValue>0.0</ProcessValue>    
                <MinValue>-1000</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Zero Offset of Ref1 Low Side Tool Check manifold fill transducer</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCircuit2LoSideToolCheckTransducerOffset
        {
            get
            {
                return ((NumericParameter)this["BlueCircuit2LoSideToolCheckTransducerOffset"]);
            }
            set
            {
                this["BlueCircuit2LoSideToolCheckTransducerOffset"] = (NumericParameter)value;
            }
        }
        #endregion


        #region WhiteCircuit1SupplyTransducerFullScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Supply Transducer Full Scale</DisplayName>
                <ProcessValue>1000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>5000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Full Scale range of Ref2 Supply manifold fill transducer.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter WhiteCircuit1SupplyTransducerFullScale
        {
            get
            {
                return ((NumericParameter)this["WhiteCircuit1SupplyTransducerFullScale"]);
            }
            set
            {
                this["WhiteCircuit1SupplyTransducerFullScale"] = (NumericParameter)value;
            }
        }
        #endregion
        #region WhiteCircuit1SupplyTransducerOffset : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Supply Transducer Offset</DisplayName>
                <ProcessValue>0</ProcessValue>    
                <MinValue>-1000</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Zero Offset of Ref2 Supply manifold fill transducer</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter WhiteCircuit1SupplyTransducerOffset
        {
            get
            {
                return ((NumericParameter)this["WhiteCircuit1SupplyTransducerOffset"]);
            }
            set
            {
                this["WhiteCircuit1SupplyTransducerOffset"] = (NumericParameter)value;
            }
        }
        #endregion
        #region WhiteCircuit1ToolCheckTransducerFullScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Tool Check Transducer Full Scale</DisplayName>
                <ProcessValue>1000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>5000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Full Scale range of Ref2 Tool Check manifold fill transducer.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter WhiteCircuit1ToolCheckTransducerFullScale
        {
            get
            {
                return ((NumericParameter)this["WhiteCircuit1ToolCheckTransducerFullScale"]);
            }
            set
            {
                this["WhiteCircuit1ToolCheckTransducerFullScale"] = (NumericParameter)value;
            }
        }
        #endregion
        #region WhiteCircuit1ToolCheckTransducerOffset : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Tool Check Transducer Offset</DisplayName>
                <ProcessValue>1.5</ProcessValue>    
                <MinValue>-1000</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>PSIG</Units>
                <ToolTip>Zero Offset of Ref2 Tool Check manifold fill transducer</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter WhiteCircuit1ToolCheckTransducerOffset
        {
            get
            {
                return ((NumericParameter)this["WhiteCircuit1ToolCheckTransducerOffset"]);
            }
            set
            {
                this["WhiteCircuit1ToolCheckTransducerOffset"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Tool_Quick_Check_Pressure_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Tool Quick Check Pressure Set Point</DisplayName>
                <ProcessValue>500</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Torr</Units>
                <ToolTip>The pressure in the charge tool must be below the Tool_Quick_Check_Pressure_SetPoint at the end of the Tool_Quick_Check_Pressure_Delay to check if the tool is connected.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Tool_Quick_Check_Pressure_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Tool_Quick_Check_Pressure_SetPoint"]);
            }
            set
            {
                this["Tool_Quick_Check_Pressure_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion
        #region Tool_Check_Pressure_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Tool Check Pressure Set Point</DisplayName>
                <ProcessValue>50</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Torr</Units>
                <ToolTip>The pressure in the charge tool must be below the Tool_Check_Pressure_SetPoint at the end of the Tool_Check_Pressure_Timeout to check if the tool is connected.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Tool_Check_Pressure_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Tool_Check_Pressure_SetPoint"]);
            }
            set
            {
                this["Tool_Check_Pressure_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Connector_Check_Pressure_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Connector Check Pressure Set Point</DisplayName>
                <ProcessValue>5</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Torr</Units>
                <ToolTip>The pressure on the vacuum gauge must be above the Connector_Check_Pressure_SetPoint at the end of the Connector_Check_Timeout to check if the tool is connected to a unit.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Connector_Check_Pressure_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Connector_Check_Pressure_SetPoint"]);
            }
            set
            {
                this["Connector_Check_Pressure_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Base_Pressure_Check_Pressure_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Base Pressure Check Pressure Set Point</DisplayName>
                <ProcessValue>0.1</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Torr</Units>
                <ToolTip>The vacuum gauge pressure must be below the Base_Pressure_Check_Pressure_SetPoint at the end of the Base_Pressure_Check_Delay to pass, checks the condition of the vacuum pump.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Base_Pressure_Check_Pressure_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Base_Pressure_Check_Pressure_SetPoint"]);
            }
            set
            {
                this["Base_Pressure_Check_Pressure_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Minimum_ROR_Pressure_Change_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Minimum ROR Pressure Check Set Point</DisplayName>
                <ProcessValue>250</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>10000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>microns</Units>
                <ToolTip>The rate of rise pressure change must be greater then this value otherwise the gauge may be bad.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Minimum_ROR_Pressure_Change_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Minimum_ROR_Pressure_Change_SetPoint"]);
            }
            set
            {
                this["Minimum_ROR_Pressure_Change_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Minimum_Convection_Pressure_Reading : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Minimum Convention Pressure Reading for Error Check</DisplayName>
                <ProcessValue>10</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>10000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>microns</Units>
                <ToolTip>If the CDG Gauge is to be used for a test and the Convection gauge reads less then this value, use the CDG Gauge Reading (Gauge Reading 0 Check).</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Minimum_Convection_Pressure_Reading
        {
            get
            {
                return ((NumericParameter)this["Minimum_Convection_Pressure_Reading"]);
            }
            set
            {
                this["Minimum_Convection_Pressure_Reading"] = (NumericParameter)value;
            }
        }
        #endregion

        #region RecoverOnResetSetpoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Recover On Reset Setpoint</DisplayName>
                <ProcessValue>10</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>10000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>psi</Units>
                <ToolTip>If the tool pressure is greater than this amount on reset, the system will recover the tool</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter RecoverOnResetSetpoint
        {
            get
            {
                return ((NumericParameter)this["RecoverOnResetSetpoint"]);
            }
            set
            {
                this["RecoverOnResetSetpoint"] = (NumericParameter)value;
            }
        }
        #endregion


        #region Blue_Refrigerant_Low_Pressure_Alarm_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Refrigerant Low Pressure Alarm Set Point</DisplayName>
                <ProcessValue>450</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Psig</Units>
                <ToolTip>The refrigerant supply pressure must be above the Ref1_Refrigerant_Low_Pressure_Alarm_SetPoint during charging.  Will not allow the cycle to start if the refrigerant pressure is low.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Blue_Refrigerant_Low_Pressure_Alarm_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Blue_Refrigerant_Low_Pressure_Alarm_SetPoint"]);
            }
            set
            {
                this["Blue_Refrigerant_Low_Pressure_Alarm_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion
        #region White_Refrigerant_Low_Pressure_Alarm_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Refrigerant Low Pressure Alarm Set Point</DisplayName>
                <ProcessValue>125</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Psig</Units>
                <ToolTip>The refrigerant supply pressure must be above the Ref2_Refrigerant_Low_Pressure_Alarm_SetPoint during charging.  Will not allow the cycle to start if the refrigerant pressure is low.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter White_Refrigerant_Low_Pressure_Alarm_SetPoint
        {
            get
            {
                return ((NumericParameter)this["White_Refrigerant_Low_Pressure_Alarm_SetPoint"]);
            }
            set
            {
                this["White_Refrigerant_Low_Pressure_Alarm_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion


        #region BlueCDG10FullScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Blue Low CDG Full Scale</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>10000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>torr</Units>
                <ToolTip>Full Scale range of Smaller Range Blue CDG</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCDG10FullScale
        {
            get
            {
                return ((NumericParameter)this["BlueCDG10FullScale"]);
            }
            set
            {
                this["BlueCDG10FullScale"] = (NumericParameter)value;
            }
        }
        #endregion
        #region BlueCDG10Offset : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Blue Low CDG Offset</DisplayName>
                <ProcessValue>0</ProcessValue>    
                <MinValue>-1000</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>torr</Units>
                <ToolTip>Zero Offset of the lower range blue CDG</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCDG10Offset
        {
            get
            {
                return ((NumericParameter)this["BlueCDG10Offset"]);
            }
            set
            {
                this["BlueCDG10Offset"] = (NumericParameter)value;
            }
        }
        #endregion


        #region BlueCDG1000FullScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Blue High CDG Full Scale</DisplayName>
                <ProcessValue>1000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>10000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>torr</Units>
                <ToolTip>Full Scale range of Higher Range Blue CDG</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCDG1000FullScale
        {
            get
            {
                return ((NumericParameter)this["BlueCDG1000FullScale"]);
            }
            set
            {
                this["BlueCDG1000FullScale"] = (NumericParameter)value;
            }
        }
        #endregion
        #region BlueCDG1000Offset : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Blue High CDG Offset</DisplayName>
                <ProcessValue>0</ProcessValue>    
                <MinValue>-1000</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>torr</Units>
                <ToolTip>Zero Offset of the higher range blue CDG</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCDG1000Offset
        {
            get
            {
                return ((NumericParameter)this["BlueCDG1000Offset"]);
            }
            set
            {
                this["BlueCDG1000Offset"] = (NumericParameter)value;
            }
        }
        #endregion


        //        #region Refrigerant_Low_Pressure_Alarm_SetPoint : NumericParameter
        //        [UserScopedSetting()]
        //        [XmlElement("NumericParameter")]
        //        [DefaultSettingValue(@"
        //            <NumericParameter>
        //                <DisplayName>Refrigerant Low Pressure Alarm Set Point</DisplayName>
        //                <ProcessValue>450</ProcessValue>    
        //                <MinValue>0</MinValue>
        //                <MaxValue>1000</MaxValue>
        //                <SmallStep>.1</SmallStep>
        //                <LargeStep>1</LargeStep>
        //                <Units>Psig</Units>
        //                <ToolTip>The refrigerant supply pressure must be above the Refrigerant_Low_Pressure_Alarm_SetPoint during charging.  Will not allow the cycle to start if the refrigerant pressure is low.</ToolTip>
        //            </NumericParameter>
        //        ")]
        //        public NumericParameter Refrigerant_Low_Pressure_Alarm_SetPoint
        //        {
        //            get
        //            {
        //                return ((NumericParameter)this["Refrigerant_Low_Pressure_Alarm_SetPoint"]);
        //            }
        //            set
        //            {
        //                this["Refrigerant_Low_Pressure_Alarm_SetPoint"] = (NumericParameter)value;
        //            }
        //        }
        //        #endregion

        #region PartialChargeServiceValveEvacSetpoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Partial Charge Service Valve Evac Setpoint</DisplayName>
                <ProcessValue>5</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Torr</Units>
                <ToolTip>Evacuates service valves down to this pressure after partial charge</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter PartialChargeServiceValveEvacSetpoint
        {
            get
            {
                return ((NumericParameter)this["PartialChargeServiceValveEvacSetpoint"]);
            }
            set
            {
                this["PartialChargeServiceValveEvacSetpoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Vacuum_High_Pressure_Alarm_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Vacuum High Pressure Alarm Set Point</DisplayName>
                <ProcessValue>5</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Torr</Units>
                <ToolTip>If the vacuum pump rises above this pressure during charging the test is aborted.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Vacuum_High_Pressure_Alarm_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Vacuum_High_Pressure_Alarm_SetPoint"]);
            }
            set
            {
                this["Vacuum_High_Pressure_Alarm_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Diag_Test_ROR_Pressure_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Diagnostic Test Rate Of Rise Pressure Set Point</DisplayName>
                <ProcessValue>5</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Torr</Units>
                <ToolTip>Maximum Rate of Rise pressure allows for the diagnostic tests.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Diag_Test_ROR_Pressure_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Diag_Test_ROR_Pressure_SetPoint"]);
            }
            set
            {
                this["Diag_Test_ROR_Pressure_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region CDG_High_Pressure_Limit : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>CDG High Pressure Limit</DisplayName>
                <ProcessValue>9000</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1000</LargeStep>
                <Units>microns</Units>
                <ToolTip>If the CDG pressure is higher then this limit use the convection gauge pressure for measurements.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter CDG_High_Pressure_Limit
        {
            get
            {
                return ((NumericParameter)this["CDG_High_Pressure_Limit"]);
            }
            set
            {
                this["CDG_High_Pressure_Limit"] = (NumericParameter)value;
            }
        }
        #endregion

        //vvvvvvvvvvvvvv
        //Diagnostic Sequence
        #region DiagBasePressureStpnt : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Diagnostic: Base Pressure Target</DisplayName>
                <ProcessValue>250</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>700000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>microns</Units>
                <ToolTip>After the time delay, the pressure must be below this target to pass</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter DiagBasePressureStpnt
        {
            get
            {
                return ((NumericParameter)this["DiagBasePressureStpnt"]);
            }
            set
            {
                this["DiagBasePressureStpnt"] = (NumericParameter)value;
            }
        }
        #endregion
        #region DiagEvacSetpoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Diagnostic: Evacuation Setpoint</DisplayName>
                <ProcessValue>500</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>700000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>microns</Units>
                <ToolTip>Pressure must drop below this target during every evacuation during diagnostic sequence. Quits early if it hits it.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter DiagEvacSetpoint
        {
            get
            {
                return ((NumericParameter)this["DiagEvacSetpoint"]);
            }
            set
            {
                this["DiagEvacSetpoint"] = (NumericParameter)value;
            }
        }
        #endregion
        #region DiagRORSetpoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Diagnostic: Rate of Rise Set Point</DisplayName>
                <ProcessValue>2000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>700000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>microns</Units>
                <ToolTip>Pressure must be below this level to pass after every Rate of Rise in the diagnostic Sequence</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter DiagRORSetpoint
        {
            get
            {
                return ((NumericParameter)this["DiagRORSetpoint"]);
            }
            set
            {
                this["DiagRORSetpoint"] = (NumericParameter)value;
            }
        }
        #endregion
        #region DiagVentingSetpoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Diagnostic: Venting Pressure</DisplayName>
                <ProcessValue>700000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>1000000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>microns</Units>
                <ToolTip>While venting the hose during diagnostic sequence, Pressure must exceed this setpoint. quits early if it hits it</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter DiagVentingSetpoint
        {
            get
            {
                return ((NumericParameter)this["DiagVentingSetpoint"]);
            }
            set
            {
                this["DiagVentingSetpoint"] = (NumericParameter)value;
            }
        }
        #endregion
        #region DiagRORValvCheckSetpoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Diagnostic: Rate of Rise Valve Check Set Point</DisplayName>
                <ProcessValue>690000</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>1000000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>microns</Units>
                <ToolTip>If pressure drops below this value while checking the rate of rise valve, then it fails indicating a leak</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter DiagRORValvCheckSetpoint
        {
            get
            {
                return ((NumericParameter)this["DiagRORValvCheckSetpoint"]);
            }
            set
            {
                this["DiagRORValvCheckSetpoint"] = (NumericParameter)value;
            }
        }
        #endregion
        #region DiagRcvrSupplySetpoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Diagnostic: Recovering Supply Line Target</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>psi</Units>
                <ToolTip>When Recovering Supply line during diagnostic sequence, pressure must fall below this setpoint or it fails</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter DiagRcvrSupplySetpoint
        {
            get
            {
                return ((NumericParameter)this["DiagRcvrSupplySetpoint"]);
            }
            set
            {
                this["DiagRcvrSupplySetpoint"] = (NumericParameter)value;
            }
        }
        #endregion
        //^^^^^^^^^^^^^^
    }
}
