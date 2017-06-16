using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace PicCommon
{
    public class Common
    {
        public static void SaveAs(String orginPath, String currentPath)
        {
            //FileStream fs = new FileStream(orginPath, FileMode.Open);
            //String name = fs.Name;
            //byte[] datas=new byte[fs.Length];
            //fs.Read(datas, 0, (int)fs.Length);
            //fs.Close();
            //fs.Dispose();

            byte[] datas = new byte[100];
            using (MemoryStream ms = new MemoryStream(datas))
            {
                Bitmap bitmap = new Bitmap(ms);
                bitmap.Save(@"D:\5.jpg");
            }
        }


        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片</param>
        /// <param name="dFile">压缩后保存位置</param>
        /// <param name="dHeight">高度</param>
        /// <param name="dWidth"></param>
        /// <param name="flag">压缩质量 1-100</param>
        /// <returns></returns>

        public static bool GetPicThumbnail(string sFile, string dFile, int dHeight, int dWidth, int flag)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);

            ImageFormat tFormat = iSource.RawFormat;

            int sW = 0, sH = 0;

            //按比例缩放

            Size tem_size = new Size(iSource.Width, iSource.Height);



            if (tem_size.Width > dHeight || tem_size.Width > dWidth) //将**改成c#中的或者操作符号
            {

                if ((tem_size.Width * dHeight) > (tem_size.Height * dWidth))
                {

                    sW = dWidth;

                    sH = (dWidth * tem_size.Height) / tem_size.Width;

                }

                else
                {

                    sH = dHeight;

                    sW = (tem_size.Width * dHeight) / tem_size.Height;

                }

            }

            else
            {

                sW = tem_size.Width;

                sH = tem_size.Height;

            }

            Bitmap ob = new Bitmap(dWidth, dHeight);

            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);

            g.CompositingQuality = CompositingQuality.HighQuality;

            g.SmoothingMode = SmoothingMode.HighQuality;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量

            EncoderParameters ep = new EncoderParameters();

            long[] qy = new long[1];

            qy[0] = flag;//设置压缩的比例1-100

            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);

            ep.Param[0] = eParam;

            try
            {

                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();

                ImageCodecInfo jpegICIinfo = null;

                for (int x = 0; x < arrayICI.Length; x++)
                {

                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {

                        jpegICIinfo = arrayICI[x];

                        break;

                    }

                }

                if (jpegICIinfo != null)
                {

                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径

                }

                else
                {

                    ob.Save(dFile, tFormat);

                }

                return true;

            }

            catch
            {

                return false;

            }

            finally
            {

                iSource.Dispose();

                ob.Dispose();

            }
        }

        public static Int32 Compress(String path)
        {
            int lenght = 0;
            String str = String.Empty;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                //byte[] data = new byte[fs.Length];
                //fs.Read(data, 0, (Int32)fs.Length);
                //lenght = str.Length;
                StreamReader sr = new StreamReader(fs);
                str = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }

            lenght = CompressString(str).Length;
            return lenght;
        }

        public static string CompressString(string str)
        {
            string compressString = "";
            byte[] compressBeforeByte = Encoding.GetEncoding("UTF-8").GetBytes(str);
            byte[] compressAfterByte = Compress(compressBeforeByte);
            //compressString = Encoding.GetEncoding("UTF-8").GetString(compressAfterByte);    
            compressString = Convert.ToBase64String(compressAfterByte);
            return compressString;
        }

        public static string DecompressString(string str)
        {
            string compressString = "";
            //byte[] compressBeforeByte = Encoding.GetEncoding("UTF-8").GetBytes(str);    
            byte[] compressBeforeByte = Convert.FromBase64String(str);
            byte[] compressAfterByte = Decompress(compressBeforeByte);
            compressString = Encoding.GetEncoding("UTF-8").GetString(compressAfterByte);
            return compressString;
        }

        /// <summary>  
        /// 字符串压缩  
        /// </summary>  
        /// <param name="strSource"></param>  
        /// <returns></returns>  
        public static byte[] Compress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true);
                zip.Write(data, 0, data.Length);
                zip.Close();
                byte[] buffer = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(buffer, 0, buffer.Length);
                ms.Close();
                return buffer;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>  
        /// 字符串解压缩  
        /// </summary>  
        /// <param name="strSource"></param>  
        /// <returns></returns>  
        public static byte[] Decompress(byte[] data)
        {
            try
            {
                MemoryStream ms = new MemoryStream(data);
                GZipStream zip = new GZipStream(ms, CompressionMode.Decompress, true);
                MemoryStream msreader = new MemoryStream();
                byte[] buffer = new byte[0x1000];
                while (true)
                {
                    int reader = zip.Read(buffer, 0, buffer.Length);
                    if (reader <= 0)
                    {
                        break;
                    }
                    msreader.Write(buffer, 0, reader);
                }
                zip.Close();
                ms.Close();
                msreader.Position = 0;
                buffer = msreader.ToArray();
                msreader.Close();
                return buffer;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }  
    }
}
