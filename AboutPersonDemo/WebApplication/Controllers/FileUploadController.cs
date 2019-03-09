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

namespace WebApplication.Controllers
{
    public class FileUploadController : ApiController
    {
        public async Task<HttpResponseMessage> PostFormData()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            int UploadImgMaxByte = 0;
            string UploadImgType = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("UploadImgType")) ?
                ConfigurationManager.AppSettings.Get("UploadImgType") : "jpg,png,gif";

            //string UploadSaveImgPath = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings.Get("UploadSaveImgPath")) ?
            //    ConfigurationManager.AppSettings.Get("UploadSaveImgPath") : "/Resource/Images";

            int.TryParse(ConfigurationManager.AppSettings.Get("UploadImgMaxByte"), out  UploadImgMaxByte);
            UploadImgMaxByte = UploadImgMaxByte > 0 ? UploadImgMaxByte : 5242880;

            try
            {
                // Read the form data.
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
                    else
                    {
                        //string newFileName = fileInfo.Name + fileExt;
                        string newFileName = Guid.NewGuid().ToString() + fileExt;
                        //最后保存文件路径
                        string saveUrl = Path.Combine(root, newFileName);
                        fileInfo.MoveTo(saveUrl);
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
