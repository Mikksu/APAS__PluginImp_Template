using System.ServiceModel;
using System.Threading.Tasks;

namespace SystemServiceContract.Core
{
    [ServiceContract]
    public interface ISystemService
    {
        [OperationContract]
        Task __SSC_PrintMessage(string Message);

        [OperationContract]
        Task __SSC_Connect();

        [OperationContract]
        Task __SSC_Disonnect();

        [OperationContract]
        /// <summary>
        /// Pause the sequence for operators to control the system.
        /// </summary>
        /// <returns></returns>
        Task __SSC_SequenceStop();

        [OperationContract]
        /// <summary>
        /// Read the measurement result from the device.
        /// </summary>
        /// <param name="Caption">The caption of the device to be read.</param>
        /// <returns></returns>
        Task<double> __SSC_MeasurableDevice_Read(string Caption);

        [OperationContract]
        /// <summary>
        /// Move the specific axis.
        /// </summary>
        /// <param name="AlignerCaption">The caption of the aligner which is defined in the settings file.</param>
        /// <param name="AxisCaption">The caption of the axis in the specific aligner.</param>
        /// <param name="Mode">ABS/REL</param>
        /// <param name="Speed">Moving speed in the range of 1 - 100</param>
        /// <param name="Distance">The distance to move, the sign of the number indicates the moving direction.</param>
        /// <returns></returns>
        Task __SSC_MoveAxis(string Aligner, string Axis, SSC_MoveMode Mode, int Speed, double Distance);

        [OperationContract]
        /// <summary>
        /// Move to the preset position with the specific profile.
        /// </summary>
        /// <param name="MotionComp">The caption of the motion component.</param>
        /// <param name="Profile">The name of the profile.</param>
        /// <returns></returns>
        Task __SSC_MoveToPresetPosition(string MotionComp, string Profile);

        #region IO Control

        [OperationContract]
        /// <summary>
        /// Read the status of the specific IO.
        /// </summary>
        /// <param name="IO">The caption of the IO.</param>
        /// <param name="IOType">The type of the IO.</param>
        /// <returns></returns>
        Task<SSC_IOStatusEnum> __SSC_ReadIO(string IO, SSC_IOTypeEnum IOType);

        [OperationContract]
        /// <summary>
        /// Write the status of the specific IO.
        /// </summary>
        /// <param name="IO">The caption of the IO.</param>
        /// <param name="Status">The status of the IO to set.</param>
        /// <returns></returns>
        Task __SSC_WriteIO(string IO, SSC_IOStatusEnum Status);

        #endregion

        #region Alignment

        [OperationContract]
        /// <summary>
        /// Perform the blind search.
        /// </summary>
        /// <param name="Profile">The name of the profile</param>
        /// <returns></returns>
        Task __SSC_DoBlindSearch(string Profile);

        [OperationContract(Name = "DoBlindSearchWithParam")]
        /// <summary>
        /// Perform the Blind Search with the specific parameters.
        /// </summary>
        /// <param name="Aligner">The caption of the aligner</param>
        /// <param name="HorizontalAxis">The caption of the axis works as the horizontal axis.</param>
        /// <param name="VerticalAxis">The caption of the axis works as the vertical axis.</param>
        /// <param name="Interval">The interval of the sampling points. The unit depends on the axis.</param>
        /// <param name="Range">The range of the scan area. The unit depends on the axis.</param>
        /// <param name="Speed">The moving speed in %.</param>
        /// <param name="AnalogCaptureChannel">Which analog input channel of the M12 is used to capture the signal.</param>
        /// <returns></returns>
        Task __SSC_DoBlindSearch(string Aligner, string HorizontalAxis, string VerticalAxis, double Interval, 
            double Range, int Speed, int AnalogCaptureChannel);

        [OperationContract]
        /// <summary>
        /// Perform the Fast-1D scan.
        /// </summary>
        /// <param name="Aligner">The caption of the aligner.</param>
        /// <param name="Axis">The caption of the axis.</param>
        /// <param name="Interval">The interval of the sampling points. The unit depends on the axis.</param>
        /// <param name="Range">The range of the scan area. The unit depends on the axis.</param>
        /// <param name="Speed">The speed of scanning in %.</param>
        /// <returns></returns>
        Task __SSC_DoFast1D(string Aligner, string Axis, double Interval, double Range, int Speed);

        [OperationContract]
        /// <summary>
        /// Perform the Fast-ND.
        /// </summary>
        /// <param name="Profile">The name of the profile</param>
        /// <returns></returns>
        Task __SSC_DoFastND(string Profile);

        [OperationContract]
        /// <summary>
        /// Perform the Fast Angle Tuning.
        /// </summary>
        /// <param name="Profile">The name of the profile</param>
        /// <returns></returns>
        Task __SSC_DoFastAngleTuning(string Profile);

        [OperationContract(Name = "DoFastAngleTuningWithParam")]
        /// <summary>
        /// Perform the Fast Angle Tuning.
        /// </summary>
        /// <param name="Aligner">The caption of the aligner.</param>
        /// <param name="LinearAxis">The caption of the axis works to scan the ΔPos of the peak powers. The unit depends on the axis.</param>
        /// <param name="LinearInterval">The interval of the sampling points. The unit depends on the axis.</param>
        /// <param name="LinearRange">The range of the scan area. The unit depends on the axis.</param>
        /// <param name="Speed">The speed of scanning in %.</param>
        /// <param name="Pitch">The pitch between the two monitored channels.</param>
        /// <param name="AnalogCaptureChannel1">Which analog input channel of the M12 is used to capture the signal.</param>
        /// <param name="AnalogCaptureChannel2">Which analog input channel of the M12 is used to capture the signal.</param>
        /// <param name="RotatingAxis">The axis which is used to tuning the angle.</param>
        /// <param name="TuningFactor">The factor to currect the angle.</param>
        /// <param name="RotatingSpeed">The rotating speed in %.</param>
        /// <returns></returns>
        Task __SSC_DoFastAngleTuning(string Aligner, string LinearAxis, double LinearInterval, double LinearRange,
            int Speed, double Pitch, int AnalogCaptureChannel1, int AnalogCaptureChannel2, string RotatingAxis,
            double TuningFactor, int RotatingSpeed);

        [OperationContract]
        /// <summary>
        /// Perform the Profile-1D scan.
        /// </summary>
        /// <param name="Aligner">The caption of the aligner.</param>
        /// <param name="Axis">The caption of the axis.</param>
        /// <param name="Interval">The interval of the sampling points. The unit depends on the axis.</param>
        /// <param name="Range">The range of the scan area. The unit depends on the axis.</param>
        /// <param name="Speed">The speed of scanning in %.</param>
        /// <returns></returns>
        Task __SSC_DoProfile1D(string Aligner, string Axis, double Interval, double Range, int Speed);

        [OperationContract]
        /// <summary>
        /// Perform the Profile-ND.
        /// </summary>
        /// <param name="Profile">The name of the profile</param>
        /// <returns></returns>
        Task __SSC_DoProfileND(string Profile);

        #endregion

        #region Methods of Powermeter Operation

        [OperationContract]
        /// <summary>
        /// Set the unit of the specific powermeter.
        /// </summary>
        /// <param name="Caption">The caption of the powermeter which is defined in the settings file.</param>
        /// <param name="Unit">dBm, dB, mW, mA</param>
        /// <returns></returns>
        Task __SSC_Powermeter_SetUnit(string Caption, SSC_PMUnitEnum Unit);

        [OperationContract]
        /// <summary>
        /// Get the Unit of the specific powermeter.
        /// </summary>
        /// <param name="Caption">The caption of the powermeter which is defined in the settings file.</param>
        /// <returns></returns>
        Task<SSC_PMUnitEnum> __SSC_Powermeter_GetUnit(string Caption);

        [OperationContract]
        /// <summary>
        /// Set the range of the specific powermeter.
        /// </summary>
        /// <param name="Caption">The caption of the powermeter which is defined in the settings file.</param>
        /// <param name="Range">Range 1 - 6</param>
        /// <returns></returns>
        Task __SSC_Powermeter_SetRange(string Caption, SSC_PMRangeEnum Range);

        [OperationContract]
        /// <summary>
        /// Get the range of the specific powermeter.
        /// </summary>
        /// <param name="Caption">The caption of the powermeter which is defined in the settings file.</param>
        /// <returns></returns>
        Task<SSC_PMRangeEnum> __SSC_Powermeter_GetRange(string Caption);

        [OperationContract]
        /// <summary>
        /// Set the output to zero.
        /// <para>NOTE this function is only availiable while the unit is dB.</para>
        /// </summary>
        /// <param name="Caption">The caption of the powermeter which is defined in the settings file.</param>
        /// <returns></returns>
        Task __SSC_Powermeter_ZeroOutput(string Caption);

        [OperationContract]
        /// <summary>
        /// Read the measurement result of the specific powermeter.
        /// </summary>
        /// <param name="Caption">The caption of the powermeter which is defined in the settings file.</param>
        /// <returns></returns>
        Task<double> __SSC_Powermeter_Read(string Caption);

        #endregion

    }
}
