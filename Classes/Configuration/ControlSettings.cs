using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using VTIWindowsControlLibrary.Classes.Configuration;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration
{

    /// <summary>
    /// COMMON CONTROL parameters
    /// </summary>
    [Serializable]
    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    [SettingsProvider(typeof(AllUsersSettingsProvider))]
    [XmlRoot("ControlSettings")]
    public class ControlSettings : EditCycleApplicationSettingsBase
    {
        #region System_ID : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>System ID</DisplayName>
                <ProcessValue>VTI_EVAC_AND_SINGLE_CHARGE</ProcessValue>
                <ToolTip>Unique Name for this Station, used to denote tests performed on this machine in the Machine Records and UUT Records databases.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter System_ID
        {
            get
            {
                return ((StringParameter)this["System_ID"]);
            }
            set
            {
                this["System_ID"] = (StringParameter)value;
            }
        }
        #endregion

        #region Language : EnumParameter<Languages>
        [UserScopedSetting()]
        [XmlElement("EnumParameter<Languages>")]
        [DefaultSettingValue(@"
			<EnumParameterOfLanguages xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
				xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
        <DisplayName>Language</DisplayName>
				<ProcessValue>English</ProcessValue>
				<ToolTip>Language to use to display on-screen prompts.</ToolTip>
			</EnumParameterOfLanguages>
        ")]
        public EnumParameter<Languages> Language
        {
            get
            {
                return ((EnumParameter<Languages>)this["Language"]);
            }
            set
            {
                this["Language"] = (EnumParameter<Languages>)value;
            }
        }
        #endregion

        #region ChargeMode : EnumParameter<ChargeModes>
        [UserScopedSetting()]
        [XmlElement("EnumParameter<ChargeModes>")]
        [DefaultSettingValue(@"
			<EnumParameterOfChargeModes xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
				xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
        <DisplayName>ChargeMode</DisplayName>
				<ProcessValue>NormalCharge</ProcessValue>
				<ToolTip>System Charge Mode, NormalCharge fully charges the unit, PartialChargeStart gives the unit an initial charge for run test and leak test, ParialChargeEnd charges a Partially Charged unit to the final Charge Target, Par</ToolTip>
			</EnumParameterOfChargeModes>
        ")]
        public EnumParameter<ChargeModes> ChargeMode
        {
            get
            {
                return ((EnumParameter<ChargeModes>)this["ChargeMode"]);
            }
            set
            {
                this["ChargeMode"] = (EnumParameter<ChargeModes>)value;
            }
        }
        #endregion

        #region UutRecordTestType : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>UUT Record Test Type</DisplayName>
                <ProcessValue>Ref Charge</ProcessValue>
                <ToolTip>Value to use for the 'Test Type' field of the UUT Records in the database.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter UutRecordTestType
        {
            get
            {
                return ((StringParameter)this["UutRecordTestType"]);
            }
            set
            {
                this["UutRecordTestType"] = (StringParameter)value;
            }
        }
        #endregion

        #region SerialNumberPattern : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Serial Number Pattern</DisplayName>
                <ProcessValue>.*</ProcessValue>
                <ToolTip>Pattern that the serial number must match.  This is a 'regular expression' pattern.  Default value of '.*' matches anything.  A pattern of '.{X}' where X is a number would match any serial number X characters long.  For further assistance, contact VTI.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter SerialNumberPattern
        {
            get
            {
                return ((StringParameter)this["SerialNumberPattern"]);
            }
            set
            {
                this["SerialNumberPattern"] = (StringParameter)value;
            }
        }
        #endregion

        #region BadgeNumberPattern : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Badge Number Pattern</DisplayName>
                <ProcessValue>^[0-9]{6}$</ProcessValue>
                <ToolTip>Pattern that the badge number must match.  This is a 'regular expression' pattern.  Default value of '.*' matches anything.  A pattern of '.{X}' where X is a number would match any serial number X characters long.  For further assistance, contact VTI.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter BadgeNumberPattern
        {
            get
            {
                return ((StringParameter)this["BadgeNumberPattern"]);
            }
            set
            {
                this["BadgeNumberPattern"] = (StringParameter)value;
            }
        }
        #endregion

        #region BlueRefrigerantName : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Ref1 Refrigerant name</DisplayName>
                <ProcessValue>R22</ProcessValue>
                <ToolTip>Ref1 Refrigerant Name.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter BlueRefrigerantName
        {
            get
            {
                return ((StringParameter)this["BlueRefrigerantName"]);
            }
            set
            {
                this["BlueRefrigerantName"] = (StringParameter)value;
            }
        }
        #endregion
        #region BlueRefrigerantType : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref1 Refrigerant Type</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>1</MinValue>
                <MaxValue>10</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>#</Units>
                <ToolTip>Ref1 Refrigerant Type 1 = R22 2 = R410a</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueRefrigerantType
        {
            get
            {
                return ((NumericParameter)this["BlueRefrigerantType"]);
            }
            set
            {
                this["BlueRefrigerantType"] = (NumericParameter)value;
            }
        }
        #endregion

        #region WhiteRefrigerantName : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Ref2 Refrigerant name</DisplayName>
                <ProcessValue>R410a</ProcessValue>
                <ToolTip>Ref2 Refrigerant Name.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter WhiteRefrigerantName
        {
            get
            {
                return ((StringParameter)this["WhiteRefrigerantName"]);
            }
            set
            {
                this["WhiteRefrigerantName"] = (StringParameter)value;
            }
        }
        #endregion
        #region WhiteRefrigerantType : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Ref2 Refrigerant Type</DisplayName>
                <ProcessValue>2</ProcessValue>
                <MinValue>1</MinValue>
                <MaxValue>10</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>#</Units>
                <ToolTip>Ref2 Refrigerant Type 1 = R22 2 = R410a</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter WhiteRefrigerantType
        {
            get
            {
                return ((NumericParameter)this["WhiteRefrigerantType"]);
            }
            set
            {
                this["WhiteRefrigerantType"] = (NumericParameter)value;
            }
        }
        #endregion


//        #region ModelInSerialNumberStartLocation : NumericParameter
//        [UserScopedSetting()]
//        [XmlElement("NumericParameter")]
//        [DefaultSettingValue(@"
//            <NumericParameter>
//                <DisplayName>Location of the start character for the Model number code</DisplayName>
//                <ProcessValue>4</ProcessValue>
//                <MinValue>0</MinValue>
//                <MaxValue>100</MaxValue>
//                <SmallStep>1</SmallStep>
//                <LargeStep>1</LargeStep>
//                <Units>#</Units>
//                <ToolTip>Location of the start character for the Model number code</ToolTip>
//            </NumericParameter>
//        ")]
//        public NumericParameter ModelInSerialNumberStartLocation
//        {
//            get
//            {
//                return ((NumericParameter)this["ModelInSerialNumberStartLocation"]);
//            }
//            set
//            {
//                this["ModelInSerialNumberStartLocation"] = (NumericParameter)value;
//            }
//        }
//        #endregion
//        #region ModelInSerialNumberLength : NumericParameter
//        [UserScopedSetting()]
//        [XmlElement("NumericParameter")]
//        [DefaultSettingValue(@"
//            <NumericParameter>
//                <DisplayName>Length of the Model number code</DisplayName>
//                <ProcessValue>3</ProcessValue>
//                <MinValue>0</MinValue>
//                <MaxValue>100</MaxValue>
//                <SmallStep>1</SmallStep>
//                <LargeStep>1</LargeStep>
//                <Units>#</Units>
//                <ToolTip>Length of the Model number code</ToolTip>
//            </NumericParameter>
//        ")]
//        public NumericParameter ModelInSerialNumberLength
//        {
//            get
//            {
//                return ((NumericParameter)this["ModelInSerialNumberLength"]);
//            }
//            set
//            {
//                this["ModelInSerialNumberLength"] = (NumericParameter)value;
//            }
//        }
//        #endregion
        #region ModelDataConnectionString : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Connection String for Model Data</DisplayName>
                <ProcessValue>Data Source=wn1appprod02;Initial Catalog=VTIDATA;User ID=vtisql;Password = RheemVTI2;</ProcessValue>
                <ToolTip>Connection String used get model data.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter ModelDataConnectionString
        {
            get
            {
                return ((StringParameter)this["ModelDataConnectionString"]);
            }
            set
            {
                this["ModelDataConnectionString"] = (StringParameter)value;
            }
        }
        #endregion
        #region ModelDataSelectString : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Select String for Model Data</DisplayName>
                <ProcessValue>select RefType,ChargeWt,EvacSetPoint,EvacDelay,RORSetPoint,RORDelay </ProcessValue>
                <ToolTip>Select String used get model data.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter ModelDataSelectString
        {
            get
            {
                return ((StringParameter)this["ModelDataSelectString"]);
            }
            set
            {
                this["ModelDataSelectString"] = (StringParameter)value;
            }
        }
        #endregion
        #region ModelDataFromTableNameString : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>From Table Name String for Model Data</DisplayName>
                <ProcessValue>from dbo.ModelData</ProcessValue>
                <ToolTip>From Table Name String used get model data.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter ModelDataFromTableNameString
        {
            get
            {
                return ((StringParameter)this["ModelDataFromTableNameString"]);
            }
            set
            {
                this["ModelDataFromTableNameString"] = (StringParameter)value;
            }
        }
        #endregion
        #region ModelDataWhereString : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Where String for Model Data</DisplayName>
                <ProcessValue>where ModelNo ='{0}'</ProcessValue>
                <ToolTip>Where String used get model data.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter ModelDataWhereString
        {
            get
            {
                return ((StringParameter)this["ModelDataWhereString"]);
            }
            set
            {
                this["ModelDataWhereString"] = (StringParameter)value;
            }
        }
        #endregion

        #region StoredProcedureConnectionString : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Connection String for Stored Procedure</DisplayName>
                <ProcessValue>Data Source=wn1appprod02;Initial Catalog=PinpointLine1;User ID=vtisql;Password = RheemVTI2;</ProcessValue>
                <ToolTip>Connection String for pretest stored procedure.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter StoredProcedureConnectionString
        {
            get
            {
                return ((StringParameter)this["StoredProcedureConnectionString"]);
            }
            set
            {
                this["StoredProcedureConnectionString"] = (StringParameter)value;
            }
        }
        #endregion

        #region TestResultConnectionString : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Connection String for Test Result Data</DisplayName>
                <ProcessValue>Data Source=wn1appprod02;Initial Catalog=VTIDATA;User ID=vtisql;Password = RheemVTI2;</ProcessValue>
                <ToolTip>Connection String used store test result data.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter TestResultConnectionString
        {
            get
            {
                return ((StringParameter)this["TestResultConnectionString"]);
            }
            set
            {
                this["TestResultConnectionString"] = (StringParameter)value;
            }
        }
        #endregion
        #region TestResultTableName : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Table Name for Test Result Data</DisplayName>
                <ProcessValue>dbo.TestResults</ProcessValue>
                <ToolTip>Table Name used store test result data.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter TestResultTableName
        {
            get
            {
                return ((StringParameter)this["TestResultTableName"]);
            }
            set
            {
                this["TestResultTableName"] = (StringParameter)value;
            }
        }
        #endregion

//        #region ESTestSQLString : StringParameter
//        [UserScopedSetting()]
//        [XmlElement("StringParameter")]
//        [DefaultSettingValue(@"
//            <StringParameter>
//                <DisplayName>SQL String for ES Pass Check</DisplayName>
//                <ProcessValue>Select SerialNo from dbo.UUTRecords where SerialNo = '{0}' AND TestResult ='PASSED' and SystemID = 'PDDemo1'</ProcessValue>
//                <ToolTip>SQL String used to check for an ES Test PASS.</ToolTip>
//            </StringParameter>
//        ")]
//        public StringParameter ESTestSQLString
//        {
//            get
//            {
//                return ((StringParameter)this["ESTestSQLString"]);
//            }
//            set
//            {
//                this["ESTestSQLString"] = (StringParameter)value;
//            }
//        }
//        #endregion
//        #region ESTestFieldToReturnString : StringParameter
//        [UserScopedSetting()]
//        [XmlElement("StringParameter")]
//        [DefaultSettingValue(@"
//            <StringParameter>
//                <DisplayName>Field to Return for ES Pass Check</DisplayName>
//                <ProcessValue>Test_Result</ProcessValue>
//                <ToolTip>Field to return to check for an ES Test PASS.</ToolTip>
//            </StringParameter>
//        ")]
//        public StringParameter ESTestFieldToReturnString
//        {
//            get
//            {
//                return ((StringParameter)this["ESTestFieldToReturnString"]);
//            }
//            set
//            {
//                this["ESTestFieldToReturnString"] = (StringParameter)value;
//            }
//        }
//        #endregion
//        #region ModelFromSNSQLString : StringParameter
//        [UserScopedSetting()]
//        [XmlElement("StringParameter")]
//        [DefaultSettingValue(@"
//            <StringParameter>
//                <DisplayName>SQL String for Model from Serial Number Check</DisplayName>
//                <ProcessValue>Select SerialNo from dbo.UUTRecords where SerialNo = '{0}' AND TestResult ='PASSED' and SystemID = 'PDDemo1'</ProcessValue>
//                <ToolTip>SQL String used to determine a model number from a a serial number scan.</ToolTip>
//            </StringParameter>
//        ")]
//        public StringParameter ModelFromSNSQLString
//        {
//            get
//            {
//                return ((StringParameter)this["ModelFromSNSQLString"]);
//            }
//            set
//            {
//                this["ModelFromSNSQLString"] = (StringParameter)value;
//            }
//        }
//        #endregion

        #region ModelNumberPattern : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Model Number Pattern</DisplayName>
                <ProcessValue>.*</ProcessValue>
                <ToolTip>Pattern that the model number must match.  This is a 'regular expression' pattern.  Default value of '.*' matches anything.  A pattern of '.{X}' where X is a number would match any model number X characters long.  For further assistance, contact VTI.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter ModelNumberPattern
        {
            get
            {
                return ((StringParameter)this["ModelNumberPattern"]);
            }
            set
            {
                this["ModelNumberPattern"] = (StringParameter)value;
            }
        }
        #endregion

        #region ScannerPort : SerialPortParameter
        [UserScopedSetting()]
        [XmlElement("SerialPortParameter")]
        [DefaultSettingValue(@"
          <SerialPortParameter>
            <DisplayName>Scanner Serial Port</DisplayName>
            <ProcessValue>
	            <PortName>COM1</PortName>
              <BaudRate>19200</BaudRate>
              <Parity>None</Parity>
              <DataBits>8</DataBits>
              <StopBits>One</StopBits>
              <Handshake>None</Handshake>
            </ProcessValue>
            <ToolTip>Serial Port for Barcode Scanner</ToolTip>
          </SerialPortParameter>
        ")]
        public SerialPortParameter ScannerPort
        {
            get
            {
                return ((SerialPortParameter)this["ScannerPort"]);
            }
            set
            {
                this["ScannerPort"] = (SerialPortParameter)value;
            }
        }
        #endregion

        #region ScaleCommPort : SerialPortParameter
        [UserScopedSetting()]
        [XmlElement("SerialPortParameter")]
        [DefaultSettingValue(@"
          <SerialPortParameter>
            <DisplayName>Scale Serial Port</DisplayName>
            <ProcessValue>
	            <PortName>COM2</PortName>
              <BaudRate>9600</BaudRate>
              <Parity>None</Parity>
              <DataBits>8</DataBits>
              <StopBits>One</StopBits>
              <Handshake>None</Handshake>
            </ProcessValue>
            <ToolTip>Serial Port for Scale</ToolTip>
          </SerialPortParameter>
        ")]
        public SerialPortParameter ScaleCommPort
        {
            get
            {
                return ((SerialPortParameter)this["ScaleCommPort"]);
            }
            set
            {
                this["ScaleCommPort"] = (SerialPortParameter)value;
            }
        }
        #endregion

        #region SerialNumberLocationIn2DBarcode : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Location of the serial number in the 2D barcode</DisplayName>
                <ProcessValue>3</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>10</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>#</Units>
                <ToolTip>Number Location of the serial number in the 2D barcode</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter SerialNumberLocationIn2DBarcode
        {
            get
            {
                return ((NumericParameter)this["SerialNumberLocationIn2DBarcode"]);
            }
            set
            {
                this["SerialNumberLocationIn2DBarcode"] = (NumericParameter)value;
            }
        }
        #endregion

        #region BarcodeDelimiterCode : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>ASCII code for the 2D barcode delimiter</DisplayName>
                <ProcessValue>29</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>255</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>#</Units>
                <ToolTip>ASCII code for the 2D barcode delimiter</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BarcodeDelimiterCode
        {
            get
            {
                return ((NumericParameter)this["BarcodeDelimiterCode"]);
            }
            set
            {
                this["BarcodeDelimiterCode"] = (NumericParameter)value;
            }
        }
        #endregion

        #region BlueCircuit2FlowmeterPort : SerialPortParameter
        [UserScopedSetting()]
        [XmlElement("SerialPortParameter")]
        [DefaultSettingValue(@"
          <SerialPortParameter>
            <DisplayName>Blue Flowmeter Serial Port</DisplayName>
            <ProcessValue>
	            <PortName>COM7</PortName>
              <BaudRate>57600</BaudRate>
              <Parity>None</Parity>
              <DataBits>8</DataBits>
              <StopBits>One</StopBits>
              <Handshake>None</Handshake>
            </ProcessValue>
            <ToolTip>Serial Port for Blue Flowmeter</ToolTip>
          </SerialPortParameter>
        ")]
        public SerialPortParameter BlueCircuit2FlowmeterPort
        {
            get
            {
                return ((SerialPortParameter)this["BlueCircuit2FlowmeterPort"]);
            }
            set
            {
                this["BlueCircuit2FlowmeterPort"] = (SerialPortParameter)value;
            }
        }
        #endregion

        #region BlueCircuit2FlowmeterID : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Blue Flowmeter ID</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>1</MinValue>
                <MaxValue>255</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units></Units>
                <ToolTip>Node Address for Blue Flowmeter</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter BlueCircuit2FlowmeterID
        {
            get
            {
                return ((NumericParameter)this["BlueCircuit2FlowmeterID"]);
            }
            set
            {
                this["BlueCircuit2FlowmeterID"] = (NumericParameter)value;
            }
        }
        #endregion

        #region WhiteCircuit1FlowmeterPort : SerialPortParameter
        [UserScopedSetting()]
        [XmlElement("SerialPortParameter")]
        [DefaultSettingValue(@"
          <SerialPortParameter>
            <DisplayName>White Flowmeter Serial Port</DisplayName>
            <ProcessValue>
	            <PortName>COM8</PortName>
              <BaudRate>57600</BaudRate>
              <Parity>None</Parity>
              <DataBits>8</DataBits>
              <StopBits>One</StopBits>
              <Handshake>None</Handshake>
            </ProcessValue>
            <ToolTip>Serial Port for White Flowmeter</ToolTip>
          </SerialPortParameter>
        ")]
        public SerialPortParameter WhiteCircuit1FlowmeterPort
        {
            get
            {
                return ((SerialPortParameter)this["WhiteCircuit1FlowmeterPort"]);
            }
            set
            {
                this["WhiteCircut1FlowmeterPort"] = (SerialPortParameter)value;
            }
        }
        #endregion

        #region WhiteCircuit1FlowmeterID : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>White Flowmeter ID</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>1</MinValue>
                <MaxValue>255</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units></Units>
                <ToolTip>Node Address for White Flowmeter</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter WhiteCircuit1FlowmeterID
        {
            get
            {
                return ((NumericParameter)this["WhiteCircuit1FlowmeterID"]);
            }
            set
            {
                this["WhiteCircuit1FlowmeterID"] = (NumericParameter)value;
            }
        }
        #endregion

        #region HorizontalSplitterLocation : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Location of the Horizontal Splitter on the Op Form</DisplayName>
                <ProcessValue>253</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>10000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units></Units>
                <ToolTip>Locaiton of the Horizontal Splitter on the Op Form</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter HorizontalSplitterLocation
        {
            get
            {
                return ((NumericParameter)this["HorizontalSplitterLocation"]);
            }
            set
            {
                this["HorizontalSplitterLocation"] = (NumericParameter)value;
            }
        }
        #endregion

        #region VerticalSplitterLocation : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Location of the Vertical Splitter on the Op Form</DisplayName>
                <ProcessValue>159</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>10000</MaxValue>
                <SmallStep>1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units></Units>
                <ToolTip>Locaiton of the Vertical Splitter on the Op Form</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter VerticalSplitterLocation
        {
            get
            {
                return ((NumericParameter)this["VerticalSplitterLocation"]);
            }
            set
            {
                this["VerticalSplitterLocation"] = (NumericParameter)value;
            }
        }
        #endregion



        #region RemoteConnectionString_VTI : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
        <StringParameter>
            <DisplayName>Remote Connection String VTI</DisplayName>
            <ProcessValue>Data Source=LENNOX-5;Initial Catalog=VTI_COIL_RECORDS;Integrated Security=True</ProcessValue>
            <ToolTip>Connection String to use when connecting to remote SQL database</ToolTip>
        </StringParameter>
    ")]
        public StringParameter RemoteConnectionString_VTI
        {
            get
            {
                return ((StringParameter)this["RemoteConnectionString_VTI"]);
            }
            set
            {
                this["RemoteConnectionString_VTI"] = (StringParameter)value;
            }
        }
        #endregion

        #region RemoteConnectionString_VTIToLennox : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
        <StringParameter>
            <DisplayName>Remote Connection String VTI Data To Lennox Server</DisplayName>
            <ProcessValue>Data Source=LENNOX-5;Initial Catalog=VTI_COIL_RECORDS;Integrated Security=True</ProcessValue>
            <ToolTip>Connection String to use when storing VTI data to remote Lennox SQL database</ToolTip>
        </StringParameter>
    ")]
        public StringParameter RemoteConnectionString_VTIToLennox
        {
            get
            {
                return ((StringParameter)this["RemoteConnectionString_VTIToLennox"]);
            }
            set
            {
                this["RemoteConnectionString_VTIToLennox"] = (StringParameter)value;
            }
        }
        #endregion


        #region LNXQA
        #region RemoteConnectionString_LennoxKeywords : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
        <StringParameter>
            <DisplayName>Remote Connection String Lennox Keywords</DisplayName>
            <ProcessValue></ProcessValue>
            <ToolTip>Connection String Keywords to use when connecting to remote Lennox Status SQL database</ToolTip>
        </StringParameter>
    ")]
        public StringParameter RemoteConnectionString_LennoxKeywords
        {
            get
            {
                return ((StringParameter)this["RemoteConnectionString_LennoxKeywords"]);
            }
            set
            {
                this["RemoteConnectionString_LennoxKeywords"] = (StringParameter)value;
            }
        }
        #endregion

        #region RemoteConnectionString_LennoxServerName : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
        <StringParameter>
            <DisplayName>Remote Connection String Lennox Server</DisplayName>
            <ProcessValue></ProcessValue>
            <ToolTip>Connection String Server to use when connecting to remote Lennox Status SQL database</ToolTip>
        </StringParameter>
    ")]
        public StringParameter RemoteConnectionString_LennoxServerName
        {
            get
            {
                return ((StringParameter)this["RemoteConnectionString_LennoxServerName"]);
            }
            set
            {
                this["RemoteConnectionString_LennoxServerName"] = (StringParameter)value;
            }
        }
        #endregion

        #region RemoteConnectionString_LennoxDatabaseName : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
        <StringParameter>
            <DisplayName>Remote Connection String Lennox Database</DisplayName>
            <ProcessValue></ProcessValue>
            <ToolTip>Connection String Database Name to use when connecting to remote Lennox Status SQL database</ToolTip>
        </StringParameter>
    ")]
        public StringParameter RemoteConnectionString_LennoxDatabaseName
        {
            get
            {
                return ((StringParameter)this["RemoteConnectionString_LennoxDatabaseName"]);
            }
            set
            {
                this["RemoteConnectionString_LennoxDatabaseName"] = (StringParameter)value;
            }
        }
        #endregion

        #region RemoteConnectionString_LennoxLogin : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
        <StringParameter>
            <DisplayName>Remote Connection String Lennox Login</DisplayName>
            <ProcessValue></ProcessValue>
            <ToolTip>Connection String Login Name to use when connecting to remote Lennox Status SQL database</ToolTip>
        </StringParameter>
    ")]
        public StringParameter RemoteConnectionString_LennoxLogin
        {
            get
            {
                return ((StringParameter)this["RemoteConnectionString_LennoxLogin"]);
            }
            set
            {
                this["RemoteConnectionString_LennoxLogin"] = (StringParameter)value;
            }
        }
        #endregion

        #region RemoteConnectionString_LennoxPassword : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
        <StringParameter>
            <DisplayName>Remote Connection String Lennox Password</DisplayName>
            <ProcessValue></ProcessValue>
            <ToolTip>Connection String Password to use when connecting to remote Lennox Status SQL database</ToolTip>
        </StringParameter>
    ")]
        public StringParameter RemoteConnectionString_LennoxPassword
        {
            get
            {
                return ((StringParameter)this["RemoteConnectionString_LennoxPassword"]);
            }
            set
            {
                this["RemoteConnectionString_LennoxPassword"] = (StringParameter)value;
            }
        }
        #endregion

        #region RemoteConnectionString_LennoxStatusCheckSP : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
        <StringParameter>
            <DisplayName>Lennox Status Check Stored Procedure Name</DisplayName>
            <ProcessValue>PROCESS_STATUS</ProcessValue>
            <ToolTip>Lennox Status Update Stroed Procedure Name</ToolTip>
        </StringParameter>
    ")]
        public StringParameter RemoteConnectionString_LennoxStatusCheckSP
        {
            get
            {
                return ((StringParameter)this["RemoteConnectionString_LennoxStatusCheckSP"]);
            }
            set
            {
                this["RemoteConnectionString_LennoxStatusCheckSP"] = (StringParameter)value;
            }
        }
        #endregion

        #region StatusReadPassValue : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Status Read Pass Value</DisplayName>
                <ProcessValue>100, 999</ProcessValue>
                <ToolTip>Character String representing a PASS from the Status Read of the Remote Database.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter StatusReadPassValue
        {
            get
            {
                return ((StringParameter)this["StatusReadPassValue"]);
            }
            set
            {
                this["StatusReadPassValue"] = (StringParameter)value;
            }
        }
        #endregion

        #region StatusWritePassValue : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Status Write Pass Value</DisplayName>
                <ProcessValue>P3</ProcessValue>
                <ToolTip>Character String representing a PASS from the Status Write to the Remote Database.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter StatusWritePassValue
        {
            get
            {
                return ((StringParameter)this["StatusWritePassValue"]);
            }
            set
            {
                this["StatusWritePassValue"] = (StringParameter)value;
            }
        }
        #endregion

        #region StatusWriteCuPassValue : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Status Write Pass for Copper Coil Value</DisplayName>
                <ProcessValue>PC3</ProcessValue>
                <ToolTip>Character String representing a PASS for a Copper Coil from the Status Write to the Remote Database.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter StatusWriteCuPassValue
        {
            get
            {
                return ((StringParameter)this["StatusWriteCuPassValue"]);
            }
            set
            {
                this["StatusWriteCuPassValue"] = (StringParameter)value;
            }
        }
        #endregion

        #region StatusWriteCAlPassValue : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Status Write Pass for Aluminium Coil Value</DisplayName>
                <ProcessValue>PA3</ProcessValue>
                <ToolTip>Character String representing a PASS for an Aluminium Coil from the Status Write to the Remote Database.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter StatusWriteAlPassValue
        {
            get
            {
                return ((StringParameter)this["StatusWriteAlPassValue"]);
            }
            set
            {
                this["StatusWriteAlPassValue"] = (StringParameter)value;
            }
        }
        #endregion


        #region StatusWriteFailValue : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Status Write Fail Value</DisplayName>
                <ProcessValue>F3</ProcessValue>
                <ToolTip>Character String representing a FAIL from the Status Write to the Remote Database.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter StatusWriteFailValue
        {
            get
            {
                return ((StringParameter)this["StatusWriteFailValue"]);
            }
            set
            {
                this["StatusWriteFailValue"] = (StringParameter)value;
            }
        }
        #endregion

        #region LennoxLineNum : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Lennox Line Number</DisplayName>
                <ProcessValue>2</ProcessValue>
                <ToolTip>Ascii String representing the Lennox Line Number of this System.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter LennoxLineNum
        {
            get
            {
                return ((StringParameter)this["LennoxLineNum"]);
            }
            set
            {
                this["LennoxLineNum"] = (StringParameter)value;
            }
        }

        #endregion

        #region LennoxStationNum : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Lennox Station Number</DisplayName>
                <ProcessValue>2</ProcessValue>
                <ToolTip>Ascii String representing the Lennox Station Number of this System.</ToolTip>
            </StringParameter>
        ")]
        public StringParameter LennoxStationNum
        {
            get
            {
                return ((StringParameter)this["LennoxStationNum"]);
            }
            set
            {
                this["LennoxStationNum"] = (StringParameter)value;
            }
        }

        #endregion
        #endregion


        #region BlueCircuit2EvacPressurePort : SerialPortParameter
        [UserScopedSetting()]
        [XmlElement("SerialPortParameter")]
        [DefaultSettingValue(@"
          <SerialPortParameter>
            <DisplayName>Evac Pressure Serial Port</DisplayName>
            <ProcessValue>
	            <PortName>COM9</PortName>
              <BaudRate>19200</BaudRate>
              <Parity>None</Parity>
              <DataBits>8</DataBits>
              <StopBits>One</StopBits>
              <Handshake>None</Handshake>
            </ProcessValue>
            <ToolTip>Serial Port for Evac Pressure Torrcon III</ToolTip>
          </SerialPortParameter>
        ")]
        public SerialPortParameter BlueCircuit2EvacPressurePort
        {
            get
            {
                return ((SerialPortParameter)this["BlueCircuit2EvacPressurePort"]);
            }
            set
            {
                this["BlueCircuit2EvacPressurePort"] = (SerialPortParameter)value;
            }
        }
        #endregion

        #region WhiteCircuit1EvacPressurePort : SerialPortParameter
        [UserScopedSetting()]
        [XmlElement("SerialPortParameter")]
        [DefaultSettingValue(@"
          <SerialPortParameter>
            <DisplayName>White Evac Pressure Serial Port</DisplayName>
            <ProcessValue>
	            <PortName>COM10</PortName>
              <BaudRate>19200</BaudRate>
              <Parity>None</Parity>
              <DataBits>8</DataBits>
              <StopBits>One</StopBits>
              <Handshake>None</Handshake>
            </ProcessValue>
            <ToolTip>Serial Port for White Evac Pressure Torrcon III</ToolTip>
          </SerialPortParameter>
        ")]
        public SerialPortParameter WhiteCircuit1EvacPressurePort
        {
            get
            {
                return ((SerialPortParameter)this["WhiteCircuit1EvacPressurePort"]);
            }
            set
            {
                this["WhiteCircuit1EvacPressurePort"] = (SerialPortParameter)value;
            }
        }
        #endregion

        #region ScaleWeightOffset : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Scale Weight Offset</DisplayName>
                <ProcessValue>1</ProcessValue>
                <MinValue>-1000</MinValue>
                <MaxValue>1000</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>lbs</Units>
                <ToolTip>Offset that adjusts and unloaded scale reading to zero</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter ScaleWeightOffset
        {
            get
            {
                return ((NumericParameter)this["ScaleWeightOffset"]);
            }
            set
            {
                this["ScaleWeightOffset"] = (NumericParameter)value;
            }
        }
        #endregion

        #region CDGEvacPressurePort : SerialPortParameter
        [UserScopedSetting()]
        [XmlElement("SerialPortParameter")]
        [DefaultSettingValue(@"
          <SerialPortParameter>
            <DisplayName>CDG Evac Pressure Serial Port</DisplayName>
            <ProcessValue>
	            <PortName>COM14</PortName>
              <BaudRate>19200</BaudRate>
              <Parity>None</Parity>
              <DataBits>8</DataBits>
              <StopBits>One</StopBits>
              <Handshake>None</Handshake>
            </ProcessValue>
            <ToolTip>Serial Port for Capacitance Diagpharm Gauge (CDG) Evac Pressure Torrcon III</ToolTip>
          </SerialPortParameter>
        ")]
        public SerialPortParameter CDGEvacPressurePort
        {
            get
            {
                return ((SerialPortParameter)this["CDGEvacPressurePort"]);
            }
            set
            {
                this["CDGEvacPressurePort"] = (SerialPortParameter)value;
            }
        }
        #endregion


        #region AreaMonitorLowLevelAlarm : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Area Monitor Low Level Alarm</DisplayName>
                <ProcessValue>650</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>1500</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>ppm</Units>
                <ToolTip>If PPM of area monitor gets above this value, a warning on the screen will appear</ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter AreaMonitorLowLevelAlarm
        {
            get
            {
                return ((NumericParameter)this["AreaMonitorLowLevelAlarm"]);
            }
            set
            {
                this["AreaMonitorLowLevelAlarm"] = (NumericParameter)value;
            }
        }
        #endregion

        #region AreaMonitorHighLevelAlarm : NumericParameter
        [UserScopedSetting()]
        [XmlElement("NumericParameter")]
        [DefaultSettingValue(@"
            <NumericParameter>
                <DisplayName>Area Monitor High Level Alarm</DisplayName>
                <ProcessValue>950</ProcessValue>
                <MinValue>0</MinValue>
                <MaxValue>1500</MaxValue>
                <SmallStep>0.1</SmallStep>
                <LargeStep>1</LargeStep>
                <Units>ppm</Units>
                <ToolTip>If PPM of area monitor gets above this value, a warning on the screen will appear. Also this PPM setpoint gets converted to voltage and sent to PLC. If the voltage from the area montior increases above this value, the supply valve will turn off </ToolTip>
            </NumericParameter>
        ")]
        public NumericParameter AreaMonitorHighLevelAlarm
        {
            get
            {
                return ((NumericParameter)this["AreaMonitorHighLevelAlarm"]);
            }
            set
            {
                this["AreaMonitorHighLevelAlarm"] = (NumericParameter)value;
            }
        }
        #endregion


        #region PostChargeOperatorInstruction : StringParameter
        [UserScopedSetting()]
        [XmlElement("StringParameter")]
        [DefaultSettingValue(@"
            <StringParameter>
                <DisplayName>Post Charge Operator Instruction</DisplayName>
                <ProcessValue>Close the Service Valves</ProcessValue>
                <ToolTip>This instruction will be given to the operator after charge before recovery. Instructions such as close services valves or disconnect unit or this can be left blank</ToolTip>
            </StringParameter>
        ")]
        public StringParameter PostChargeOperatorInstruction
        {
            get
            {
                return ((StringParameter)this["PostChargeOperatorInstruction"]);
            }
            set
            {
                this["PostChargeOperatorInstruction"] = (StringParameter)value;
            }
        }
        #endregion

    }
}
