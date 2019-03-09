using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApplication.App_Start
{
    public static class FileSaveConfig
    {
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