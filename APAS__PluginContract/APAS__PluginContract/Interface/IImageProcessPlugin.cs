using HalconDotNet;
using System.Drawing;
using System.Threading.Tasks;

namespace PluginContract.Interface
{
    public interface IImageProcessPlugin : IPlugin
    {
        Task<object> DoProcess(Bitmap Image);

        Task<object> DoProcess(HObject Image);
    }
}
