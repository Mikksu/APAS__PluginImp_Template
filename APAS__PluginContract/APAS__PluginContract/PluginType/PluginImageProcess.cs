using HalconDotNet;
using PluginContract.Core;
using PluginContract.Interface;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Threading.Tasks;
using SystemServiceContract.Core;

namespace PluginContract.PluginType
{
    public abstract class PluginImageProcess : PluginBase, IImageProcessPlugin
    {

        #region Constructors

        public PluginImageProcess(Assembly Derived, ISystemService APASService) : base(Derived, APASService) { }

        #endregion

        #region Methods

        /// <summary>
        /// Convert the 32bpp bitmap to the HObject.
        /// </summary>
        /// <param name="bmp">The image must be Format32bppArgb.</param>
        /// <param name="image"></param>
        public void Bitmap2HObjectBpp32(Bitmap bmp, out HObject image)
        {
            try
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

                BitmapData srcBmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                HOperatorSet.GenImageInterleaved(out image, srcBmpData.Scan0, "rgbx", bmp.Width, bmp.Height, 0, "byte", 0, 0, 0, 0, -1, 0);
                bmp.UnlockBits(srcBmpData);
            }
            catch (Exception ex)
            {
                throw new Exception($"unable to convert bitmap to hobject, {ex.Message}");
            }
        }

        /// <summary>
        /// Convert the 8bpp bitmap to the HObject.
        /// </summary>
        /// <param name="bmp">The image must be Format8bppIndexed.</param>
        /// <param name="image"></param>
        public void Bitmap2HObjectBpp8(Bitmap bmp, out HObject image)
        {
            try
            {
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

                BitmapData srcBmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                HOperatorSet.GenImage1(out image, "byte", bmp.Width, bmp.Height, srcBmpData.Scan0);
                bmp.UnlockBits(srcBmpData);
            }
            catch (Exception ex)
            {
                throw new Exception($"unable to convert bitmap to hobject, {ex.Message}");
            }
        }

        public virtual Task<object> DoProcess(Bitmap Image)
        {
            throw new NotImplementedException();
        }

        public virtual Task<object> DoProcess(HObject Image)
        {
            throw new NotImplementedException();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion
    }
}
