using PluginContract.Core;
using PluginContract.Interface;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using SystemServiceContract.Core;

namespace PluginContract.PluginType
{
    public abstract class PluginEquipment : PluginBase, IEquipmentPlugin
    {
        #region Constructors

        public PluginEquipment(Assembly Derived, ISystemService APASService) : base(Derived, APASService)
        {
            IsBusy = false;

            // the view is allowed to be displayed.
            IsShowView = true;

            // create the default view.
            UserControl control = new UserControl();
            Grid grid = new Grid();
            grid.Children.Add(new TextBlock()
            {
                Text = "No View Available",
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center
            });
            control.Content = grid;

            this.UserView = control;
        }

        #endregion

        #region properties

        /// <summary>
        /// Get whether the device is busy.
        /// </summary>
        public virtual bool IsBusy { get; protected set; }

        /// <summary>
        /// Get whether the view is allowed to be displayed.
        /// </summary>
        public virtual bool IsShowView { get; protected set; }

        /// <summary>
        /// Get the view of the plugin.
        /// </summary>
        public virtual UserControl UserView { get; protected set; }

        #endregion

        #region Methods

        public virtual async Task<object> Execute(object args)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual async Task Control(string param)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual async Task Wait(int timeout)
        {
            await Task.Run(() =>
            {
                bool is_timeout = false;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                while (IsBusy)
                {
                    if (sw.ElapsedMilliseconds > timeout)
                    {
                        is_timeout = true;
                        break;
                    }

                    Thread.Sleep(5);
                }

                if (is_timeout)
                    throw new TimeoutException();
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion

    }
}
