using System;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Serialization;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using VTIWindowsControlLibrary.Classes.Configuration;
using TRANE_Precharge.Enums;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration
{
    /// <summary>
    /// COMMON MODE parameters
    /// </summary>
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    [SettingsProvider(typeof(AllUsersSettingsProvider))]
    [XmlRoot("ModeSettings")]
    public class ModeSettings : EditCycleApplicationSettingsBase
    {
        #region ShowCycleSteps : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Display Cycle Steps Form</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Displays the active cycle steps form for debugging software.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter ShowCycleSteps
        {
            get
            {
                return ((BooleanParameter)this["ShowCycleSteps"]);
            }
            set
            {
                this["ShowCycleSteps"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region BlueCircuit2PortEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Ref1 Port Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables the Ref1 port.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter BlueCircuit2PortEnabled
        {
            get
            {
                return ((BooleanParameter)this["BlueCircuit2PortEnabled"]);
            }
            set
            {
                this["BlueCircuit2PortEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region WhiteCircuit1PortEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Ref2 Port Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables the Ref2 port.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter WhiteCircuit1PortEnabled
        {
            get
            {
                return ((BooleanParameter)this["WhiteCircuit1PortEnabled"]);
            }
            set
            {
                this["WhiteCircuit1PortEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region SelectModelFromSerialNumber : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Select Model From Serial Number Enabled</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Select Model From Serial Number.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter SelectModelFromSerialNumber
        {
            get
            {
                return ((BooleanParameter)this["SelectModelFromSerialNumber"]);
            }
            set
            {
                this["SelectModelFromSerialNumber"] = (BooleanParameter)value;
            }
        }
        #endregion
//        #region EvacTestPassFromESEnabled : BooleanParameter
//        [UserScopedSetting()]
//        [XmlElement("BooleanParameter")]
//        [DefaultSettingValue(@"
//            <BooleanParameter>
//                <DisplayName>Evac Test Pass From ES Enabled</DisplayName>
//                <ProcessValue>true</ProcessValue>
//                <ToolTip>Requires a PASS reacord from an ES system before charging the part.</ToolTip>
//            </BooleanParameter>
//        ")]
//        public BooleanParameter EvacTestPassFromESEnabled
//        {
//            get
//            {
//                return ((BooleanParameter)this["EvacTestPassFromESEnabled"]);
//            }
//            set
//            {
//                this["EvacTestPassFromESEnabled"] = (BooleanParameter)value;
//            }
//        }
//        #endregion

        #region BasePressureCheckEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Base Pressure Check Enabled</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Enables the Base Pressure Check cycle step.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter BasePressureCheckEnabled
        {
            get
            {
                return ((BooleanParameter)this["BasePressureCheckEnabled"]);
            }
            set
            {
                this["BasePressureCheckEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region RecoveryEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Recovery Enabled</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Enables the refrigerant recovery cycle step.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter RecoveryEnabled
        {
            get
            {
                return ((BooleanParameter)this["RecoveryEnabled"]);
            }
            set
            {
                this["RecoveryEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region ScaleEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Scale Enabled</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Enables the scale to weight the product before and after charge.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter ScaleEnabled
        {
            get
            {
                return ((BooleanParameter)this["ScaleEnabled"]);
            }
            set
            {
                this["ScaleEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region UseHardyScale : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Use Hardy Scale</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Use a Hardy HI6500 series scale.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter UseHardyScale
        {
          get
          {
            return ((BooleanParameter)this["UseHardyScale"]);
          }
          set
          {
            this["UseHardyScale"] = (BooleanParameter)value;
          }
        }
        #endregion


        #region AdjustOffsetCountsUsingFlowEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Adjust Offset Counts Using Flow Enabled</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Adjust the Offset Counts near the end of the charge using the measure flow into the part.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter AdjustOffsetCountsUsingFlowEnabled
        {
            get
            {
                return ((BooleanParameter)this["AdjustOffsetCountsUsingFlowEnabled"]);
            }
            set
            {
                this["AdjustOffsetCountsUsingFlowEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region RecoveryTankFloatSwitchEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Blue Recovery Tank Float Switch Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Disable charging if blue float switch is high.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter RecoveryTankFloatSwitchEnabled
        {
            get
            {
                return ((BooleanParameter)this["RecoveryTankFloatSwitchEnabled"]);
            }
            set
            {
                this["RecoveryTankFloatSwitchEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion
        #region WhiteRecoveryTankFloatSwitchEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>White Recovery Tank Float Switch Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Disable charging if white float switch is high.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter WhiteRecoveryTankFloatSwitchEnabled
        {
            get
            {
                return ((BooleanParameter)this["WhiteRecoveryTankFloatSwitchEnabled"]);
            }
            set
            {
                this["WhiteRecoveryTankFloatSwitchEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region HiSideConnectorCheckEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Hi Side Connector Check Enabled</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Enables the hi side connector check.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter HiSideConnectorCheckEnabled
        {
            get
            {
                return ((BooleanParameter)this["HiSideConnectorCheckEnabled"]);
            }
            set
            {
                this["HiSideConnectorCheckEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region LowSideConnectorCheckEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Low Side Connector Check Enabled</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Enables the low side connector check.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter LowSideConnectorCheckEnabled
        {
            get
            {
                return ((BooleanParameter)this["LowSideConnectorCheckEnabled"]);
            }
            set
            {
                this["LowSideConnectorCheckEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region ToolEvacEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Tool Evac Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables the tool evac check.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter ToolEvacEnabled
        {
            get
            {
                return ((BooleanParameter)this["ToolEvacEnabled"]);
            }
            set
            {
                this["ToolEvacEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion


        #region RecoverToServiceValvePartialStart : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Recover To Service Valve Partial Start</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Prompt to close service valves after charge, recover up to service valve, pump and prompt to remove tool</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter RecoverToServiceValvePartialStart
        {

            get
            {
                return ((BooleanParameter)this["RecoverToServiceValvePartialStart"]);
            }
            set
            {
                this["RecoverToServiceValvePartialStart"] = (BooleanParameter)value;
            }
        }
        #endregion


        #region BlueCircuit2HiSideEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Ref1 Hi Side Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables the Ref1 hi side gun.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter BlueCircuit2HiSideEnabled
        {
            get
            {
                return ((BooleanParameter)this["BlueCircuit2HiSideEnabled"]);
            }
            set
            {
                this["BlueCircuit2HiSideEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion
        #region BlueCircuit2LowSideEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Ref1 Low Side Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables the Ref1 low side gun.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter BlueCircuit2LowSideEnabled
        {
            get
            {
                return ((BooleanParameter)this["BlueCircuit2LowSideEnabled"]);
            }
            set
            {
                this["BlueCircuit2LowSideEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region WhiteCircuit1HiSideEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Ref2 Hi Side Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables the Ref2 hi side gun.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter WhiteCircuit1HiSideEnabled
        {
            get
            {
                return ((BooleanParameter)this["WhiteCircuit1HiSideEnabled"]);
            }
            set
            {
                this["WhiteCircuit1HiSideEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion
        #region WhiteCircuit1LowSideEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Ref2 Low Side Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables the Ref2 low side gun.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter WhiteCircuit1LowSideEnabled
        {
            get
            {
                return ((BooleanParameter)this["WhiteCircuit1LowSideEnabled"]);
            }
            set
            {
                this["WhiteCircuit1LowSideEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region CheckStoredProcedureEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Check Stored Procedure if OK to Test Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Check a stored procedure if OK to test.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter CheckStoredProcedureEnabled
        {
            get
            {
                return ((BooleanParameter)this["CheckStoredProcedureEnabled"]);
            }
            set
            {
                this["CheckStoredProcedureEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion


        #region CheckModelDatabase : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Check Model Database Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Gets model parameters from Rheem Server.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter CheckModelDatabase
        {
            get
            {
                return ((BooleanParameter)this["CheckModelDatabase"]);
            }
            set
            {
                this["CheckModelDatabase"] = (BooleanParameter)value;
            }
        }
        #endregion


        #region InsertValveCoresAfterChargeEnabled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Insert Valve Cores After Charge Enabled</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Prompts the operator to insert the valve cores after charging the unit, before tool recovery.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter InsertValveCoresAfterChargeEnabled
        {
            get
            {
                return ((BooleanParameter)this["InsertValveCoresAfterChargeEnabled"]);
            }
            set
            {
                this["InsertValveCoresAfterChargeEnabled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region Trace_Level : EnumParameter<TraceLevel>
        [UserScopedSetting()]
        [XmlElement("EnumParameter<TraceLevel>")]
        [DefaultSettingValue(@"
			<EnumParameterOfTraceLevel xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
				xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                <DisplayName>Trace Level</DisplayName>
				<ProcessValue>Info</ProcessValue>
				<ToolTip>Determines the level of detail created in the diagnostic output trace for the system.  Default level is Info.  Please change only at the request of VTI.</ToolTip>
			</EnumParameterOfTraceLevel>
        ")]
        public EnumParameter<VTIWindowsControlLibrary.Classes.SystemDiagnostics.TraceLevel> Trace_Level
        {
            get
            {
                return ((EnumParameter<VTIWindowsControlLibrary.Classes.SystemDiagnostics.TraceLevel>)this["Trace_Level"]);
            }
            set
            {
                this["Trace_Level"] = (EnumParameter<VTIWindowsControlLibrary.Classes.SystemDiagnostics.TraceLevel>)value;
            }
        }
        #endregion
        #region ModelScanMode : EnumParameter<ModelScanOptions>
        [UserScopedSetting()]
        [XmlElement("EnumParameter<ModelScanOptions>")]
        [DefaultSettingValue(@"
			<EnumParameterOfModelScanOptions>
                <DisplayName>Model Scan Mode</DisplayName>
				<ProcessValue>Select_Model_Number_via_Touch_Screen</ProcessValue>
				<ToolTip>Select the type of model scanning required. Use 'Select Model Number via Touch Screen' to use an on-screen form to select a model, which will remain in effect until another model is selected. Use 'Scan Model Number and Serial Number Barcodes Seperately' to scan two seperate model and serial barcodes. Use 'Scan Combined Model Number and Serial Number Barcode' to scan a single barcode and parse out the model and serial numbers.</ToolTip>
			</EnumParameterOfModelScanOptions>
        ")]
        public EnumParameter<ModelScanOptions> ModelScanMode
        {
            get
            {
                return ((EnumParameter<ModelScanOptions>)this["ModelScanMode"]);
            }
            set
            {
                this["ModelScanMode"] = (EnumParameter<ModelScanOptions>)value;
            }
        }
        #endregion
        #region BarCodeScannerMode : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Bar Code Scanner Mode</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables or disables bar code scanner.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter BarCodeScannerMode
        {
            get
            {
                return ((BooleanParameter)this["BarCodeScannerMode"]);
            }
            set
            {
                this["BarCodeScannerMode"] = (BooleanParameter)value;
            }
        }
        #endregion
        #region DigitalOutputInterlocks : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Digital Output Interlocks</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Enables or disables the Digital Output Interlocks.  The Digital Output Interlocks prevent the system from changing the state of a digital output if it will result in an undesirable or unsafe machine state.  The interlocks can be disabled if necessary for system diagnostics.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter DigitalOutputInterlocks
        {
            get
            {
                return ((BooleanParameter)this["DigitalOutputInterlocks"]);
            }
            set
            {
                this["DigitalOutputInterlocks"] = (BooleanParameter)value;
            }
        }
        #endregion
        #region AutoDemoCycleEnable : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Auto Demo Cycle Enabled</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Automaticly cycles the machine alternating between blank test and chamber leak.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter AutoDemoCycleEnable
        {

            get
            {
                return ((BooleanParameter)this["AutoDemoCycleEnable"]);
            }
            set
            {
                this["AutoDemoCycleEnable"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region AutoSetScaleOffsetEnable : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Auto Set Scale Offset </DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Automaticly Sets the scale offset parameter before starting the cycle</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter AutoSetScaleOffsetEnable
        {

            get
            {
                return ((BooleanParameter)this["AutoSetScaleOffsetEnable"]);
            }
            set
            {
                this["AutoSetScaleOffsetEnable"] = (BooleanParameter)value;
            }
        }
        #endregion


        #region CDGInstalled : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>CDG Installed </DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Capacitance Diagraphm Gauge (CDG) is Installed</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter CDGInstalled
        {

            get
            {
                return ((BooleanParameter)this["CDGInstalled"]);
            }
            set
            {
                this["CDGInstalled"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region UseCDGForTest : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Use CDG For Test </DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Use Capacitance Diagraphm Gauge (CDG) for the evac test</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter UseCDGForTest
        {

            get
            {
                return ((BooleanParameter)this["UseCDGForTest"]);
            }
            set
            {
                this["UseCDGForTest"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region ProductionModePlot : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Production Mode Plot </DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Plotting for Production Mode, if CDG is used will clear the Convection gauge trace from the plot</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter ProductionModePlot
        {

            get
            {
                return ((BooleanParameter)this["ProductionModePlot"]);
            }
            set
            {
                this["ProductionModePlot"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region RecoverStemsRetractedForceCharge : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Recover With Stems Retracted Force Charge</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>If enabled, the system will recover the guns with the gun stems retracted on a force charge</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter RecoverStemsRetractedForceCharge
        {

            get
            {
                return ((BooleanParameter)this["RecoverStemsRetractedForceCharge"]);
            }
            set
            {
                this["RecoverStemsRetractedForceCharge"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region RecoverStemsRetractedUnits : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Recover With Stems Retracted Units</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>If enabled, the system will recover the guns with the gun stems retracted for Units</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter RecoverStemsRetractedUnits
        {

            get
            {
                return ((BooleanParameter)this["RecoverStemsRetractedUnits"]);
            }
            set
            {
                this["RecoverStemsRetractedUnits"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region RecoverOnReset : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Recover On Reset</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>If enabled, the system will recover the guns on reset if the tool pressure is greater than the recover on reset pressure setpoint</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter RecoverOnReset
        {

            get
            {
                return ((BooleanParameter)this["RecoverOnReset"]);
            }
            set
            {
                this["RecoverOnReset"] = (BooleanParameter)value;
            }
        }
        #endregion

        #region ChangeFinalFormAckButton : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Change Final Form Ackowledge Button</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>If enabled the button on the final message form during the cycle will say 'Valves Closed' Instead of 'Acknowledge' and the text will be Pink Instead of Black</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter ChangeFinalFormAckButton
        {

            get
            {
                return ((BooleanParameter)this["ChangeFinalFormAckButton"]);
            }
            set
            {
                this["ChangeFinalFormAckButton"] = (BooleanParameter)value;
            }
        }
        #endregion


        #region A2LRefrigerantMode : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>A2L Refrigerant Mode</DisplayName>
                <ProcessValue>true</ProcessValue>
                <ToolTip>Displays warnings related to protecting the system from A2L Refrigerants such as the purge off warning</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter A2LRefrigerantMode
        {
            get
            {
                return ((BooleanParameter)this["A2LRefrigerantMode"]);
            }
            set
            {
                this["A2LRefrigerantMode"] = (BooleanParameter)value;
            }
        }
        #endregion
        #region HP_SwitchChargeOnFlow : BooleanParameter
        [UserScopedSetting()]
        [XmlElement("BooleanParameter")]
        [DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>HP Switch Charge On Flow</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>For Heat Pump units switch charge from hi side charge to low side charge when the flow falls below this value.</ToolTip>
            </BooleanParameter>
        ")]
        public BooleanParameter HP_SwitchChargeOnFlow
        {
            get
            {
                return ((BooleanParameter)this["HP_SwitchChargeOnFlow"]);
            }
            set
            {
                this["HP_SwitchChargeOnFlow"] = (BooleanParameter)value;
            }
        }
		#endregion


		#region UseNewStatusCheckStoredProcedure : BooleanParameter
		[UserScopedSetting()]
		[XmlElement("BooleanParameter")]
		[DefaultSettingValue(@"
            <BooleanParameter>
                <DisplayName>Use New Status Check Stored Procedure</DisplayName>
                <ProcessValue>false</ProcessValue>
                <ToolTip>Use new or old SQL stored procedure. New returns Coil Status, Model Number, Return message, Refrigerant type, Charge Weight. Old returns Coil Status, Model Number, Return message.</ToolTip>
            </BooleanParameter>
        ")]
		public BooleanParameter UseNewStatusCheckStoredProcedure {

			get {
				return ((BooleanParameter)this["UseNewStatusCheckStoredProcedure"]);
			}
			set {
				this["UseNewStatusCheckStoredProcedure"] = (BooleanParameter)value;
			}
		}
		#endregion
	}
}
