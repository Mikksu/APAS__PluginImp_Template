using APAS__PluginImp_Template;
using PluginContract.PluginType;
using System.Reflection;
using System.Threading.Tasks;
using SystemServiceContract.Core;

namespace APAS__PluginImp_Template
{
    public class PluginDemo : PluginEquipment
    {

        #region Variables
        private readonly string param1 = "";

        #endregion

        #region Constructors

        public PluginDemo(ISystemService APASService) : base(Assembly.GetExecutingAssembly(), APASService)
        {
            var config = GetAppConfig();

            param1 = config.AppSettings.Settings["Param1"].Value;
           

            this.UserView = new PluginDemoView();
            this.HasView = true;

        }

        #endregion

        #region Properties

        public override string Name => "APAS插件模板";

        public override string Usage => "该模板文件不具备实际功能，请根据实需求进行更改。使用方法请参考Readme.md文件";

        #endregion

        #region Methods

        public sealed override async Task<object> Execute(object args)
        {
            await Task.CompletedTask;
            return null;
        }

        /// <summary>
        /// Switch to the specific channel.
        /// </summary>
        /// <param name="param">[int] The specific channel.</param>
        /// <returns></returns>
        public sealed override async Task Control(string param)
        {
            await Task.CompletedTask;
        }

        protected override void Dispose(bool disposing)
        {
            
        }

        #endregion
    }
}
