using PluginContract.Core;
using System;
using SystemServiceContract.Core;

namespace PluginContract.Interface
{
    public delegate void MessageUpdateEventHandle(object sender, MessageUpdateArgs message);

    public interface IPlugin
    {
        event MessageUpdateEventHandle MessageUpdated;

        /// <summary>
        /// Get my Guid.
        /// </summary>
        Guid Guid { get; }

        Version Ver { get; }

        string FileName { get; }

        string Name { get; }

        string Author { get; }

        string Usage { get; }

        ISystemService APASService { get; }
    }
}
