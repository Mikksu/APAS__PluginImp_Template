using APAS__PluginImp_Template;
using PluginContract.PluginType;
using System;
using System.IO.Ports;
using System.Reflection;
using System.Threading.Tasks;
using SystemServiceContract.Core;

namespace APAS__PluginImp_IUVOT
{
    public class AWGTester : PluginEquipment
    {

        #region Variables
        private readonly string pm1 = "";
        private readonly string pm2 = "";
        private readonly string pm3 = "";
        private readonly string pm4 = "";

        #endregion

        #region Constructors

        public AWGTester(ISystemService APASService) : base(Assembly.GetExecutingAssembly(), APASService)
        {
            var config = GetAppConfig();

            pm1 = config.AppSettings.Settings["PM1"].Value;
            pm2 = config.AppSettings.Settings["PM2"].Value;
            pm3 = config.AppSettings.Settings["PM3"].Value;
            pm4 = config.AppSettings.Settings["PM4"].Value;
           

            this.UserView = new AWGTesterView();
            this.IsShowView = true;

        }

        #endregion

        #region Properties

        public override string Name => "AWG芯片测试插件";

        public override string Usage => "自动或手动测试AWG芯片。";

        #endregion

        #region Methods

       
        public sealed override async Task<object> Execute(object args)
        {
            //_enable_ch1();
            //await Task.Delay(200);
            //_disable_ch1();

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
//             if (param == "ON")
//                 
//             else if (param == "OFF")
//                 
//             else
//                 throw new ArgumentException("unrecognized param.");

            await Task.CompletedTask;
        }

        protected override void Dispose(bool disposing)
        {
            
        }

        #endregion
    }
}
