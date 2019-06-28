using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication.App_Start;

/// <summary>
/// 20190308 文件上传样例
/// 功能：1通过异步实现文件上传；2保存文件方式实现自定义
/// </summary>
namespace WebApplication.Controllers
{
    public class FileUploadController : ApiController
    {
        public async Task<HttpResponseMessage> PostFormData()
        {
            var httpResponseMessageOfThis = Request.CreateResponse(HttpStatusCode.HttpVersionNotSupported);
            //是否包含文件类型请求
            if (!Request.Content.IsMimeMultipartContent())
            {
                //同步情况下：
                //HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
                //httpResponseMessage.Content = new StringContent("{\"msg\":\"请检查文件是否上传\"}");
                //httpResponseMessage.StatusCode = HttpStatusCode.HttpVersionNotSupported;
                //httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                //return httpResponseMessage;

                //异步情况下，为当前响应请求创建响应内容

                httpResponseMessageOfThis.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { Message = "请检查文件是否上传" }));
                httpResponseMessageOfThis.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                return httpResponseMessageOfThis;
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            int UploadImgMaxByte = 0;
            string UploadImgType = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("UploadImgType")) ?
                ConfigurationManager.AppSettings.Get("UploadImgType") : "jpg,png,gif,xlsx";

            //string UploadSaveImgPath = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("UploadSaveImgPath")) ?
            //    ConfigurationManager.AppSettings.Get("UploadSaveImgPath") : "/Resource/Images";

            int.TryParse(ConfigurationManager.AppSettings.Get("UploadImgMaxByte"), out  UploadImgMaxByte);
            UploadImgMaxByte = UploadImgMaxByte > 0 ? UploadImgMaxByte : 8192;

            try
            {
                // Read the form data.(此步骤本地已接受对应上传文件，但此时的文件以文件流形式存在)
                await Request.Content.ReadAsMultipartAsync(provider);

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
                    if(fileInfo.Length> UploadImgMaxByte)
                    {
                        httpResponseMessageOfThis.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new { Message = string.Format("文件大小超过上限{0}KB",  (UploadImgMaxByte / 1024m)) }));
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
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
