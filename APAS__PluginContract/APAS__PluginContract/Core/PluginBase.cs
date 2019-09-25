using PluginContract.Interface;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using SystemServiceContract.Core;

namespace PluginContract.Core
{
    public abstract class PluginBase : NotifyPropertyChangedBase, IPlugin, IDisposable
    {
        public virtual event MessageUpdateEventHandle MessageUpdated;

        #region Constructors

        /// <summary>
        /// Create the instance of the plugin.
        /// </summary>
        /// <param name="Derived">
        /// The derived class must be passed in to get the right GUID.
        /// Otherwise, the GUID of the base class will be returned.
        /// </param>
        public PluginBase(Assembly Derived, ISystemService APASService)
        {
            // get Guid.
            var attrs = Derived.GetCustomAttributes(false).OfType<System.Runtime.InteropServices.GuidAttribute>();
            if (attrs.Any())
            {
                this.Guid = Guid.Parse(attrs.First().Value);
            }
            else
            {
                throw new Exception("guid is not found.");
            }

            // get version
            this.Ver = Derived.GetName().Version;

            // get filename
            this.FileName = Path.GetFileNameWithoutExtension(Derived.GetName().CodeBase);

            this.APASService = APASService;

        }

        #endregion

        #region Properties

        public Guid Guid { get; }

        public Version Ver { get; }

        public string FileName { get; }

        public virtual string Name => throw new NotImplementedException();

        public virtual string Author => "Irixi";

        public virtual string Usage
        {
            get
            {
                return "NULL";
            }
        }

        public ISystemService APASService { get; }


        #endregion

        #region Methods

        /// <summary>
        /// Get the config file of the plugin.
        /// </summary>
        /// <returns></returns>
        protected Configuration GetAppConfig()
        {
            ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = this.GetType().Assembly.Location + ".config";
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
            return config;
        }

        public override string ToString()
        {
            return this.FileName;
        }

        #endregion

        #region Protected Methods

        protected virtual void OnMessageUpdated(object sender, MessageUpdateArgs e)
        {
            MessageUpdated?.Invoke(sender, e);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PluginBase() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #endregion
    }
}
