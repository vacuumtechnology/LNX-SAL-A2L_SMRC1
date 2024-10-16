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
    /// COMMON FLOW parameters
    /// </summary>
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    [SettingsProvider(typeof(AllUsersSettingsProvider))]
    [XmlRoot("FlowSettings")]
    public class FlowSettings : EditCycleApplicationSettingsBase
    {

        #region Blue_Flowmeter_Zero_Warning_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Flowmeter Zero Warning Setpoint</DisplayName>
                <ProcessValue>0.5</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>10</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>oz/yr</Units>
                <ToolTip>Disables a warning if the Ref1 flowmeter signal is greter than Flowmeter_Zero_Warning_SetPoint when the system is idle</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Blue_Flowmeter_Zero_Warning_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Blue_Flowmeter_Zero_Warning_SetPoint"]);
            }
            set
            {
                this["Blue_Flowmeter_Zero_Warning_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Flowmeter_Zero_Warning_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Flowmeter Zero Warning Setpoint</DisplayName>
                <ProcessValue>0.5</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>10</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>oz/yr</Units>
                <ToolTip>Disables a warning if the flowmeter signal is greter than Flowmeter_Zero_Warning_SetPoint when the system is idle</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Flowmeter_Zero_Warning_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Flowmeter_Zero_Warning_SetPoint"]);
            }
            set
            {
                this["Flowmeter_Zero_Warning_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Blue_Circuit2_Flowmeter_Counts_Per_Ounce : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Flowmeter Counts Per Ounce</DisplayName>
                <ProcessValue>50.113</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>counts</Units>
                <ToolTip>Ref1 Flowmeter counts per ounce scale factor</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Blue_Circuit2_Flowmeter_Counts_Per_Ounce
        {
            get
            {
                return ((NumericParameter)this["Blue_Circuit2_Flowmeter_Counts_Per_Ounce"]);
            }
            set
            {
                this["Blue_Circuit2_Flowmeter_Counts_Per_Ounce"] = (NumericParameter)value;
            }
        }
        #endregion
        #region Blue_Circuit2_Flowmeter_Offset_Counts : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Flowmeter Offset Counts</DisplayName>
                <ProcessValue>-137</ProcessValue>
                <MinValue>-3000</MinValue>
                <MaxValue>3000</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>counts</Units>
                <ToolTip>Ref1 Flowmeter offset counts corrects for the time the charge valve takes to close</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Blue_Circuit2_Flowmeter_Offset_Counts
        {
            get
            {
                return ((NumericParameter)this["Blue_Circuit2_Flowmeter_Offset_Counts"]);
            }
            set
            {
                this["Blue_Circuit2_Flowmeter_Offset_Counts"] = (NumericParameter)value;
            }
        }
        #endregion
        #region Blue_Flowmeter_Calibration_Flow : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Flowmeter Calibration Flow</DisplayName>
                <ProcessValue>3.0</ProcessValue>
                <MinValue>0.01</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>oz/s</Units>
                <ToolTip>Ref1 Flowmeter flow at the end of calibration, used to adjust offset</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Blue_Flowmeter_Calibration_Flow
        {
            get
            {
                return ((NumericParameter)this["Blue_Flowmeter_Calibration_Flow"]);
            }
            set
            {
                this["Blue_Flowmeter_Calibration_Flow"] = (NumericParameter)value;
            }
        }
        #endregion
        #region Blue_Flowmeter_Flow_Factor : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Blue Flowmeter Flow Factor</DisplayName>
                <ProcessValue>0.1</ProcessValue>
                <MinValue>0.01</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units></Units>
                <ToolTip>Blue Flowmeter flow factor corrects flowmeter modbus output to match actual flow</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Blue_Flowmeter_Flow_Factor
        {
            get
            {
                return ((NumericParameter)this["Blue_Flowmeter_Flow_Factor"]);
            }
            set
            {
                this["Blue_Flowmeter_Flow_Factor"] = (NumericParameter)value;
            }
        }
        #endregion

        #region White_Circuit1_Flowmeter_Counts_Per_Ounce : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Flowmeter Counts Per Ounce</DisplayName>
                <ProcessValue>50.109</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>counts</Units>
                <ToolTip>Ref2 Flowmeter counts per ounce scale factor</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter White_Circuit1_Flowmeter_Counts_Per_Ounce
        {
            get
            {
                return ((NumericParameter)this["White_Circuit1_Flowmeter_Counts_Per_Ounce"]);
            }
            set
            {
                this["White_Circuit1_Flowmeter_Counts_Per_Ounce"] = (NumericParameter)value;
            }
        }
        #endregion
        #region White_Circuit1_Flowmeter_Offset_Counts : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Flowmeter Offset Counts</DisplayName>
                <ProcessValue>-154</ProcessValue>
                <MinValue>-3000</MinValue>
                <MaxValue>3000</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>counts</Units>
                <ToolTip>Ref2 Flowmeter offset counts corrects for the time the charge valve takes to close</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter White_Circuit1_Flowmeter_Offset_Counts
        {
            get
            {
                return ((NumericParameter)this["White_Circuit1_Flowmeter_Offset_Counts"]);
            }
            set
            {
                this["White_Circuit1_Flowmeter_Offset_Counts"] = (NumericParameter)value;
            }
        }
        #endregion
        #region White_Flowmeter_Calibration_Flow : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Flowmeter Calibration Flow</DisplayName>
                <ProcessValue>3.0</ProcessValue>
                <MinValue>0.01</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>oz/s</Units>
                <ToolTip>Ref2 Flowmeter flow at the end of calibration, used to adjust offset</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter White_Flowmeter_Calibration_Flow
        {
            get
            {
                return ((NumericParameter)this["White_Flowmeter_Calibration_Flow"]);
            }
            set
            {
                this["White_Flowmeter_Calibration_Flow"] = (NumericParameter)value;
            }
        }
        #endregion
        #region White_Flowmeter_Flow_Factor : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>White Flowmeter Flow Factor</DisplayName>
                <ProcessValue>0.1</ProcessValue>
                <MinValue>0.01</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units></Units>
                <ToolTip>White Flowmeter flow factor corrects flowmeter modbus output to match actual flow</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter White_Flowmeter_Flow_Factor
        {
            get
            {
                return ((NumericParameter)this["White_Flowmeter_Flow_Factor"]);
            }
            set
            {
                this["White_Flowmeter_Flow_Factor"] = (NumericParameter)value;
            }
        }
        #endregion


        #region Maximum_Over_Charge_Percentage : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Maximum Over Charge Percentage</DisplayName>
                <ProcessValue>150</ProcessValue>
                <MinValue>100</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>%</Units>
                <ToolTip>Ends charge cycle of measure charge exceeds Maximum_Over_Charge_Percentage/100.0 x Target Charge Weight</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Maximum_Over_Charge_Percentage
        {
            get
            {
                return ((NumericParameter)this["Maximum_Over_Charge_Percentage"]);
            }
            set
            {
                this["Maximum_Over_Charge_Percentage"] = (NumericParameter)value;
            }
        }
        #endregion
        #region Average_Charge_Rate : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Average Charge Rate</DisplayName>
                <ProcessValue>0.6</ProcessValue>
                <MinValue>0.1</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>0.01</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>oz/yr</Units>
                <ToolTip>Average Charge Rate, used to calculate charge time out delays</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Average_Charge_Rate
        {
            get
            {
                return ((NumericParameter)this["Average_Charge_Rate"]);
            }
            set
            {
                this["Average_Charge_Rate"] = (NumericParameter)value;
            }
        }
        #endregion
        #region Minimum_Flowmeter_Rate : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Minimum Flowmeter Rate</DisplayName>
                <ProcessValue>0.5</ProcessValue>
                <MinValue>0.1</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>0.01</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>oz/yr</Units>
                <ToolTip>Minimum Flowmeter Rate, aborts charge step if the flow rate drops below the Minimum_Flowmeter_Rate, indicates a flowmeter error or refrigerant pressure supply problem</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Minimum_Flowmeter_Rate
        {
            get
            {
                return ((NumericParameter)this["Minimum_Flowmeter_Rate"]);
            }
            set
            {
                this["Minimum_Flowmeter_Rate"] = (NumericParameter)value;
            }
        }
        #endregion
        #region MaximumChargeWeightError : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Maximum Charge Weight Error</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>0.01</MinValue>
                <MaxValue>5</MaxValue>
                <SmallStep>0.01</SmallStep>
                <LargeStep>0.1</LargeStep>
                <Units>oz charge</Units>
                <ToolTip>Maximum Charge Weight Error above the Target Weight.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter MaximumChargeWeightError
        {
            get
            {
                return ((NumericParameter)this["MaximumChargeWeightError"]);
            }
            set
            {
                this["MaximumChargeWeightError"] = (NumericParameter)value;
            }
        }
        #endregion
        #region MinimumChargeWeightError : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Minimum Charge Weight Error</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>0.01</MinValue>
                <MaxValue>5</MaxValue>
                <SmallStep>0.01</SmallStep>
                <LargeStep>0.1</LargeStep>
                <Units>oz charge</Units>
                <ToolTip>Minimum Charge Weight Error BELOW the Target Weight.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter MinimumChargeWeightError
        {
            get
            {
                return ((NumericParameter)this["MinimumChargeWeightError"]);
            }
            set
            {
                this["MinimumChargeWeightError"] = (NumericParameter)value;
            }
        }
        #endregion


        #region MaximumChargeWeightErrorFromScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Maximum Charge Weight Error From Scale</DisplayName>
                <ProcessValue>2</ProcessValue>
                <MinValue>0.01</MinValue>
                <MaxValue>5</MaxValue>
                <SmallStep>0.01</SmallStep>
                <LargeStep>0.1</LargeStep>
                <Units>oz charge</Units>
                <ToolTip>Maximum Charge Weight Error above the Target Weight from the scale measurement.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter MaximumChargeWeightErrorFromScale
        {
            get
            {
                return ((NumericParameter)this["MaximumChargeWeightErrorFromScale"]);
            }
            set
            {
                this["MaximumChargeWeightErrorFromScale"] = (NumericParameter)value;
            }
        }
        #endregion
        #region MinimumChargeWeightErrorFromScale : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Minimmum Charge Weight Error From Scale</DisplayName>
                <ProcessValue>2</ProcessValue>
                <MinValue>0.01</MinValue>
                <MaxValue>5</MaxValue>
                <SmallStep>0.01</SmallStep>
                <LargeStep>0.1</LargeStep>
                <Units>oz charge</Units>
                <ToolTip>Minimum Charge Weight Error BELOW the Target Weight from the scale measurement.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter MinimumChargeWeightErrorFromScale
        {
            get
            {
                return ((NumericParameter)this["MinimumChargeWeightErrorFromScale"]);
            }
            set
            {
                this["MinimumChargeWeightErrorFromScale"] = (NumericParameter)value;
            }
        }
        #endregion

    }

}
