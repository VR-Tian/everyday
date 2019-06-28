using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication.App_Start
{
    public static class FileSaveConfig
    {

        public static Task<HttpResponseMessage> ProceFile(MultipartFormDataStreamProvider provider)
        {
            int UploadImgMaxByte = 0;
            string UploadImgType = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("UploadImgType")) ?
                ConfigurationManager.AppSettings.Get("UploadImgType") : "jpg,png,gif,xlsx";
            string root = HttpContext.Current.Server.MapPath("~/App_Data");

            int.TryParse(ConfigurationManager.AppSettings.Get("UploadImgMaxByte"), out UploadImgMaxByte);
            UploadImgMaxByte = UploadImgMaxByte > 0 ? UploadImgMaxByte : 8192;

            var httpResponseMessageOfThis = Request.CreateResponse(HttpStatusCode.HttpVersionNotSupported);

            // This illustrates how to get the file names.
            foreach (MultipartFileData file in provider.FileData)
            {
                //获取上传文件名 这里获取含有双引号'" '
                string fileName = file.Headers.ContentDisposition.FileName.Trim('"');
                //获取上传文件后缀名
                string fileExt = fileName.Substring(fileName.LastIndexOf('.'));

                FileInfo fileInfo = new FileInfo(file.LocalFileName);

                if (string.IsNullOrEmpty(fileExt) || string.IsNullOrEmpty(UploadImgType.Split(',').Where(w => w == fileExt.Substring(1).ToLower()).FirstOrDefault()))
                {
                    fileInfo.Delete();
                    return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, UploadImgType);
                }
                if (fileInfo.Length > UploadImgMaxByte)
                {
                    httpResponseMessageOfThis.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { Message = string.Format("文件大小超过上限{0}KB", (UploadImgMaxByte / 1024m)) }));
                    httpResponseMessageOfThis.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return httpResponseMessageOfThis;
                }
                else
                {
                    //string newFileName = fileInfo.Name + fileExt;
                    string newFileName = Guid.NewGuid().ToString() + fileExt;
                    ////最后保存文件路径
                    //string saveUrl = Path.Combine(root, newFileName);

                    //fileInfo.MoveTo(saveUrl);

                    return FileSaveConfig.SaveFileProc(root, newFileName, fileInfo);
                }
            }
        }

        /// <summary>
        /// 执行保存文件
        /// </summary>
        /// <param name="filePath">文件保存物理路径</param>
        /// <param name="fileName">文件名称(包含后缀)</param>
        /// <param name="fileInfo">当前文件实例</param>
        /// <returns></returns>
        public static HttpResponseMessage SaveFileProc(string filePath,string fileName, FileInfo fileInfo)
        {
            HttpResponseMessage message = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            message.StatusCode = System.Net.HttpStatusCode.OK;
            var hear = message.Headers;
            try
            {
                if (fileInfo == null || string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(fileName))
                {
                    message.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    message.Content = new StringContent("Not fount fileInfo、filePath、fileName Properties", System.Text.Encoding.GetEncoding("utf-8"), "text/plain");
                    return message;
                }
                //为了避免一个文件夹内存储大量的文件，便于对文件的管理，实现“分页”结构来保存
                var nowdate = DateTime.Now.ToString("yyyy-MM-dd");
                filePath = Path.Combine(filePath, nowdate);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                var saveurl = Path.Combine(filePath, fileName);
                fileInfo.MoveTo(saveurl);
                return message;
            }
            catch (Exception ex)
            {
                message.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                message.Content = new StringContent(ex.Message);
                return message;
            }
        }
    }
}