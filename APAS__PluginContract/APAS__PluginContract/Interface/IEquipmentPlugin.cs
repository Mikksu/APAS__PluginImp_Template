

using System.Threading.Tasks;
using System.Windows.Controls;

namespace PluginContract.Interface
{
    public interface IEquipmentPlugin : IPlugin
    {

        bool IsShowView { get; }

        /// <summary>
        /// Get whether the device is busy.
        /// </summary>
        bool IsBusy { get; }

        UserControl UserView { get; }

        /// <summary>
        /// Execute the integrated logic.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        Task<object> Execute(object args);

        /// <summary>
        ///  The method to control the device.
        /// </summary>
        /// <param name="param">The parameter is independent </param>
        /// <returns></returns>
        Task Control(string param);

        /// <summary>
        /// Wait while the status is busy.
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns></returns>
        Task Wait(int timeout);

    }
}
