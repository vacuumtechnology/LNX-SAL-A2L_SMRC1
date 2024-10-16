using System.Collections;
using System.Reflection;
using System;
using System.Linq;
using System.Configuration;
using System.Xml.Serialization;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Classes.IO;
using VTIWindowsControlLibrary.Classes.IO.SignalConverters;
using VTIWindowsControlLibrary.Classes.IO.Interfaces;
using VTIWindowsControlLibrary.Components;
using VTIWindowsControlLibrary.Classes.IO.SerialIO;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses
{
    /// <summary>
    /// IO
    /// 
    /// 
    /// </summary>
    public class IO : GenericSingleton<IO>
    {
        #region Fields (7)

        #region Protected Fields (7)

        protected AnalogInputs _AIn;
        protected AnalogOutputs _AOut;
        protected DigitalInputs _DIn;
        protected DigitalOutputs _DOut;
        protected SerialInputs _SerialIn;
        protected AnalogSignalConverters _SignalConverters;
        protected AnalogSignals _Signals;

        #endregion Protected Fields

        #endregion Fields

        #region Constructors (1)

        protected IO() { }

        #endregion Constructors

        #region Properties (7)

        public static AnalogInputs AIn { get { return Instance._AIn; } }

        public static AnalogOutputs AOut { get { return Instance._AOut; } }

        public static DigitalInputs DIn { get { return Instance._DIn; } }

        public static DigitalOutputs DOut { get { return Instance._DOut; } }

        public static SerialInputs SerialIn { get { return Instance._SerialIn; } }

        public static AnalogSignalConverters SignalConverters { get { return Instance._SignalConverters; } }

        public static AnalogSignals Signals { get { return Instance._Signals; } }

        #endregion Properties

        #region Methods (2)

        #region Public Methods (1)

        public static void Initialize()
        {
            Instance = new IO();
        }

        #endregion Public Methods
        #region Protected Methods (1)

        protected override void InitializeInstance()
        {
            VtiEvent.Log.WriteVerbose("Initializing I/O Interface...");

            _AIn = new AnalogInputs(Config.IO.Interface);
            _AOut = new AnalogOutputs(Config.IO.Interface);
            _SerialIn = new SerialInputs();
            _SignalConverters = new AnalogSignalConverters();
            _Signals = new AnalogSignals();
            _DIn = new DigitalInputs(Config.IO.Interface);
            _DOut = new DigitalOutputs(Config.IO.Interface);
        }
        public void RestartSerialInDevices()
        {
            var _SerialInList = _SerialIn.GetType()
                     .GetFields()
                     .Select(field => field.GetValue(_SerialIn))
                     .Where(x => x != null)
                     .OfType<VTIWindowsControlLibrary.Classes.IO.SerialIO.SerialIOBase>()
                     .ToList();
            if (_SerialInList != null)
            {
                foreach (VTIWindowsControlLibrary.Classes.IO.SerialIO.SerialIOBase device in _SerialInList)
                {
                    device.Start();
                }
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}