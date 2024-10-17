using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using VTIWindowsControlLibrary.Classes.Configuration;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Interfaces;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration
{
    /// <summary>
    /// Model DEFAULT Parameters
    /// </summary>
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    [SettingsProvider(typeof(AllUsersSettingsProvider))]
    [XmlRoot("ModelSettings")]
    public class ModelSettings : ModelSettingsBase, IModelSettings
    {
        #region Description : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Description</DisplayName>
                <ProcessValue>Default Model</ProcessValue>
                <ToolTip>Description of the model</ToolTip>
            </StringParameter>
        ")]
        public StringParameter Description
        {
            get
            {
                return ((StringParameter)this["Description"]);
            }
            set
            {
                this["Description"] = (StringParameter)value;
            }
        }
        #endregion

        #region RefrigerantType : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Refrigerant Type</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>1</MinValue>
                <MaxValue>10</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units></Units>
                <ToolTip>Refrigerant Type.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter RefrigerantType
        {
            get
            {
                return ((NumericParameter)this["RefrigerantType"]);
            }
            set
            {
                this["RefrigerantType"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Precharged_Unit_Check_Pressure_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Precharge Unit Check Pressure Set Point</DisplayName>
                <ProcessValue>-10</ProcessValue>    
                <MinValue>-100</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Psig</Units>
                <ToolTip>The pressure in the charge tool must be below the Precharge_Unit_Check_Pressure_SetPoint at the end of the Tool_Check_Pressure_Timeout to check if the unit has already been charge with refrigerant.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Precharge_Unit_Check_Pressure_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Precharge_Unit_Check_Pressure_SetPoint"]);
            }
            set
            {
                this["Precharge_Unit_Check_Pressure_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Initial_Evac_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Initial Evac Delay</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>If the vacuum gauge pressure is greater then the Initial_Evac_Pressure_Setpoint at the end of the Initial_Evac_Delay the part fails, possibly indicating a gross leak.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Initial_Evac_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Initial_Evac_Delay"]);
            }
            set
            {
                this["Initial_Evac_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region Initial_Evac_Pressure_SetPointt : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Initial Evac Pressure Set Point</DisplayName>
                <ProcessValue>50</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>mTorr</Units>
                <ToolTip>The vacuum gauge pressure must be below the Initial_Evac_Pressure_SetPoint at the end of the Initial_Evac_Delay to pass, checks for gross leaks in the attached unit.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Initial_Evac_Pressure_SetPointt
        {
            get
            {
                return ((NumericParameter)this["Initial_Evac_Pressure_SetPointt"]);
            }
            set
            {
                this["Initial_Evac_Pressure_SetPointt"] = (NumericParameter)value;
            }
        }
        #endregion

        #region Final_Evac_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Final Evac Delay</DisplayName>
                <ProcessValue>110</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>If the vacuum gauge pressure is greater then the Final_Evac_Pressure_Setpoint at the end of the Final_Evac_Delay the part fails, possibly indicating a leak.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Final_Evac_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Final_Evac_Delay"]);
            }
            set
            {
                this["Final_Evac_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region Final_Evac_Pressure_SetPointt : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Final Evac Pressure Set Point</DisplayName>
                <ProcessValue>1</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>mTorr</Units>
                <ToolTip>The vacuum gauge pressure must be below the Final_Evac_Pressure_SetPoint at the end of the Final_Evac_Delay to pass, checks for leaks in the attached unit.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Final_Evac_Pressure_SetPointt
        {
            get
            {
                return ((NumericParameter)this["Final_Evac_Pressure_SetPointt"]);
            }
            set
            {
                this["Final_Evac_Pressure_SetPointt"] = (NumericParameter)value;
            }
        }
        #endregion
        #region Repeat_Evac_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Repeat Evac Delay</DisplayName>
                <ProcessValue>60</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>If the unit doesn't pass the Rate Of Rise test the system will continue to evacuate the unit for the Repeat Evac Delay before repeating the Rate of Rise test.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Repeat_Evac_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Repeat_Evac_Delay"]);
            }
            set
            {
                this["Repeat_Evac_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region Maximum_Evac_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Maximum Evac Delay</DisplayName>
                <ProcessValue>300</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>The system will continue to repeat the evacuation and rate of rise tests until the Maximum Evac Time.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Maximum_Evac_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Maximum_Evac_Delay"]);
            }
            set
            {
                this["Maximum_Evac_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region ROR_Pressure_Check_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>ROR Pressure Check Delay</DisplayName>
                <ProcessValue>30</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>The system closes the rate of rise valve for the ROR Pressue Check Delay, if the vacuum gauge pressure is less than the ROR_Pressure_Setpoint the part passes the rate of rise pressure check and charges the part.  If the rate of rise check fails, the system will repeat the evacuation</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter ROR_Pressure_Check_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["ROR_Pressure_Check_Delay"]);
            }
            set
            {
                this["ROR_Pressure_Check_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region ROR_Pressure_Check_Pressure_SetPointt : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Rate Of Rise Pressure Check Pressure Set Point</DisplayName>
                <ProcessValue>5</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>mTorr</Units>
                <ToolTip>The vacuum gauge pressure must be below the ROR_Pressure_Check_Pressure_SetPoint at the end of the ROR_Pressure_Check_Delay to pass, otherwise the system will repeat the evacuation.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter ROR_Pressure_Check_Pressure_SetPointt
        {
            get
            {
                return ((NumericParameter)this["ROR_Pressure_Check_Pressure_SetPointt"]);
            }
            set
            {
                this["ROR_Pressure_Check_Pressure_SetPointt"] = (NumericParameter)value;
            }
        }
		#endregion

		#region Initial_Recovery_Setpoint : NumericParameter
		[UserScopedSetting()]
		[XmlElement("NumericParameter")]
		[DefaultSettingValue(@"
	    <NumericParameter>
	        <DisplayName>Initial Recovery Pressure Set Point</DisplayName>
	        <ProcessValue>50</ProcessValue>    
	        <MinValue>0</MinValue>
	        <MaxValue>1000</MaxValue>
	        <SmallStep>.001</SmallStep>
	        <LargeStep>1</LargeStep>
	        <Units>Psig</Units>
	        <ToolTip>The tool pressure must be below the Initial Recovery Setpoint before the Initial Recovery Timeout to pass the recovery cycle step.</ToolTip>
	    </NumericParameter>
	")]
		public NumericParameter Initial_Recovery_Setpoint
		{
			get
			{
				return ((NumericParameter)this["Initial_Recovery_Setpoint"]);
			}
			set
			{
				this["Initial_Recovery_Setpoint"] = (NumericParameter)value;
			}
		}
		#endregion
		#region Initial_Recovery_Timeout : TimeDelayParameter
		[UserScopedSetting()]
		[XmlElement("TimeDelayParameter")]
		[DefaultSettingValue(@"
	    <TimeDelayParameter>
	        <DisplayName>Initial Recovery Timeout</DisplayName>
	        <ProcessValue>10</ProcessValue>
	        <MinValue>0</MinValue>
	        <MaxValue>6000</MaxValue>
	        <SmallStep>0.1</SmallStep>
	        <LargeStep>10</LargeStep>
	        <Units>Seconds</Units>
	        <ToolTip>Time allowed to recover refrigerant to Initial Recovery Pressure Setpoint in order to pass recovery.</ToolTip>
	    </TimeDelayParameter>
	")]
		public TimeDelayParameter Initial_Recovery_Timeout
		{
			get
			{
				return ((TimeDelayParameter)this["Initial_Recovery_Timeout"]);
			}
			set
			{
				this["Initial_Recovery_Timeout"] = (TimeDelayParameter)value;
			}
		}
		#endregion

		#region Recovery_Pressure_SetPoint : NumericParameter
		[UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Recovery Pressure Set Point</DisplayName>
                <ProcessValue>50</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.001</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Psig</Units>
                <ToolTip>The tool pressure must be below the Recovery_Pressure_SetPoint to finish the recovery cycle step.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Recovery_Pressure_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Recovery_Pressure_SetPoint"]);
            }
            set
            {
                this["Recovery_Pressure_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion
        #region Tool_Drain_Delay : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Tool Drain Delay</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time allowed to drain refrigerant from the tool before closing the stem.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Tool_Drain_Delay
        {
            get
            {
                return ((TimeDelayParameter)this["Tool_Drain_Delay"]);
            }
            set
            {
                this["Tool_Drain_Delay"] = (TimeDelayParameter)value;
            }
        }
        #endregion
        #region Tool_Recovery_Timeout : TimeDelayParameter
        [UserScopedSetting()]
        [XmlElement("TimeDelayParameter")]
        [DefaultSettingValue(@"
            <TimeDelayParameter>
                <DisplayName>Tool Recovery Timeout</DisplayName>
                <ProcessValue>10</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>6000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>10</LargeStep>
                <Units>Seconds</Units>
                <ToolTip>Time allowed to recover refrigerant from the tool.</ToolTip>
            </TimeDelayParameter>
        ")]
        public TimeDelayParameter Tool_Recovery_Timeout
        {
            get
            {
                return ((TimeDelayParameter)this["Tool_Recovery_Timeout"]);
            }
            set
            {
                this["Tool_Recovery_Timeout"] = (TimeDelayParameter)value;
            }
        }
        #endregion

        #region TotalCharge : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Total Charge</DisplayName>
                <ProcessValue>24</ProcessValue>
                <MinValue>1</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>oz</Units>
                <ToolTip>Total Refrigerant Charge.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter TotalCharge
        {
            get
            {
                return ((NumericParameter)this["TotalCharge"]);
            }
            set
            {
                this["TotalCharge"] = (NumericParameter)value;
            }
        }
        #endregion
        #region HiSidePercentage : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Hi Side Charge Percentage</DisplayName>
                <ProcessValue>100</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>%</Units>
                <ToolTip>Percentage Refrigerant Charge for the Hi Side.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter HiSidePercentage
        {
            get
            {
                return ((NumericParameter)this["HiSidePercentage"]);
            }
            set
            {
                this["HiSidePercentage"] = (NumericParameter)value;
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

        #region LowSideChargePressureCheckEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Low Side Charge Pressure Check Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables the Low Side Charge Pressure Check.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter LowSideChargePressureCheckEnabled
        {
            get
            {
                return ((BooleanParameter)this["LowSideChargePressureCheckEnabled"]);
            }
            set
            {
                this["LowSideChargePressureCheckEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion
        #region Low_Side_Charge_Pressure_Check_SetPoint : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Low Side Charge Pressure Check Set Point</DisplayName>
                <ProcessValue>10</ProcessValue>    
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>Psi</Units>
                <ToolTip>During a charge, the pressure in the charge tool must not change more then the Low Side Charge Pressure Check Set Point</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter Low_Side_Charge_Pressure_Check_SetPoint
        {
            get
            {
                return ((NumericParameter)this["Low_Side_Charge_Pressure_Check_SetPoint"]);
            }
            set
            {
                this["Low_Side_Charge_Pressure_Charge_SetPoint"] = (NumericParameter)value;
            }
        }
        #endregion

        #region ScaleWeightCorrection : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Scale Weight Correction</DisplayName>
                <ProcessValue>0</ProcessValue>
                <MinValue>-100</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>0.001</SmallStep>
                <LargeStep>0.1</LargeStep>
                <Units>oz charge</Units>
                <ToolTip>Weight added to scale net measurement to account for the weight of air or other items.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter ScaleWeightCorrection
        {
            get
            {
                return ((NumericParameter)this["ScaleWeightCorrection"]);
            }
            set
            {
                this["ScaleWeightCorrection"] = (NumericParameter)value;
            }
        }
        #endregion

        #region UnitType : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Unit Type</DisplayName>
                <ProcessValue>AC</ProcessValue>
                <ToolTip>Type of Unit AC or HP for Heat Pump</ToolTip>
            </StringParameter>
        ")]
        public StringParameter UnitType
        {
            get
            {
                return ((StringParameter)this["UnitType"]);
            }
            set
            {
                this["UnitType"] = (StringParameter)value;
            }
        }
        #endregion

        #region CoilType : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Coil Type</DisplayName>
                <ProcessValue>Cu</ProcessValue>
                <ToolTip>Type of Coil Cu for copper or Al for Aluminium</ToolTip>
            </StringParameter>
        ")]
        public StringParameter CoilType
        {
            get
            {
                return ((StringParameter)this["CoilType"]);
            }
            set
            {
                this["CoilType"] = (StringParameter)value;
            }
        }
        #endregion

        #region PartialChargePercent : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Partial Charge Percent</DisplayName>
                <ProcessValue>25</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>100</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>0.1</LargeStep>
                <Units>%</Units>
                <ToolTip>Percent of charge to be charge to unit for a Paritial Charge Test.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter PartialChargePercent
        {
            get
            {
                return ((NumericParameter)this["PartialChargePercent"]);
            }
            set
            {
                this["PartialChargePercent"] = (NumericParameter)value;
            }
        }
        #endregion

        #region PartialChargePressTarget : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Partial Charge Pressure Target</DisplayName>
                <ProcessValue>150</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>0.1</LargeStep>
                <Units>psig</Units>
                <ToolTip>Charge Pressure Target for the low side for a Partial Charge Test.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter PartialChargePressureTarget
        {
            get
            {
                return ((NumericParameter)this["PartialChargePressureTarget"]);
            }
            set
            {
                this["PartialChargePressureTarget"] = (NumericParameter)value;
            }
        }
        #endregion


        #region FlowRateSwitch : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Flow Rate Switch</DisplayName>
                <ProcessValue>1.0</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>10.0</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>0.01</LargeStep>
                <Units>psig</Units>
                <ToolTip>Switch from high side charging to low side changing when the flow rate drops below this level.</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter FlowRateSwitch
        {
            get
            {
                return ((NumericParameter)this["FlowRateSwitch"]);
            }
            set
            {
                this["FlowRateSwitch"] = (NumericParameter)value;
            }
        }
        #endregion
    }
}
