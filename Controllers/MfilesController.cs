using Mfiles.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using public_link.Models.models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Mfiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MfilesController : ControllerBase
    {
        [HttpGet]
        public IActionResult getmfiles([FromQuery] string Username, [FromQuery] string Password, [FromQuery] string phrase)
        {
			var str = "";
			if (!string.IsNullOrWhiteSpace(Username))
				Username = Username.Trim();
			if (!string.IsNullOrWhiteSpace(Password))
				Password = Password.Trim();

			var jsonSerializer = JsonSerializer.CreateDefault();
			var username = Username;
			var password = Password;
			var guid="DBF3B54A-4B89-48F4-A8D1-A0F69546447B";
			// Create the authentication details.
			var auth = new
			{
				Username = Username,
				Password = Password,
				VaultGuid = "{DBF3B54A-4B89-48F4-A8D1-A0F69546447B}" // Use GUID format with {braces}.
			};

			var authenticationRequest = (HttpWebRequest)WebRequest.Create("http://66.23.226.169:81/REST/server/authenticationtokens.aspx");
			authenticationRequest.Method = "POST";
			using (var streamWriter = new StreamWriter(authenticationRequest.GetRequestStream()))
			{
				using (var jsonTextWriter = new JsonTextWriter(streamWriter))
				{
					jsonSerializer.Serialize(jsonTextWriter, auth);
				}
			}

			// Execute the request.
			var authenticationResponse = (HttpWebResponse)authenticationRequest.GetResponse();

			// Extract the authentication token.
			string authenticationToken = null;
			using (var streamReader = new StreamReader(authenticationResponse.GetResponseStream()))
			{
				using (var jsonTextReader = new JsonTextReader(streamReader))
				{
					authenticationToken = ((dynamic)jsonSerializer.Deserialize(jsonTextReader)).Value;
				}
			}
			if (!string.IsNullOrWhiteSpace(phrase))
			{
				phrase = phrase.Trim();
				str +="p1163*" + "=" + phrase;
			}
			var client = new RestClient($"http://66.23.226.169:81/REST/objects.aspx?0=0{str}");
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			request.AddHeader("X-Authentication", $"{authenticationToken}");
			IRestResponse response = client.Execute(request);
			Example account = JsonConvert.DeserializeObject<Example>(response.Content);

			foreach (var item in account.Items)
			{
				int fileID=0;
				int objid=item.ObjVer.ID;
				int fileFileVersionType=0;
				int objtype=item.ObjVer.Type;
				int objversion=item.ObjVer.Version;
				foreach (var item1 in item.Files)
                {
					fileID=item1.ID;
					fileFileVersionType=item1.FileVersionType;
				}
			public_link.Models.models.FileVer fileVer=new public_link.Models.models.FileVer();
			public_link.Models.models.ObjVer objVer=new public_link.Models.models.ObjVer();

			fileVer.ID=fileID;
            fileVer.Version=-1;
            fileVer.FileVersionType=fileFileVersionType;
            fileVer.ExpirationTime="2021-06-01T00:00:00Z";
            fileVer.Description="Created By Namanda";

			 objVer.ID=objid;
            objVer.Type=objtype;
            objVer.Version=objversion;

			 Root root=new Root();
            root.FileVer=fileVer;
            root.objVer=objVer;
            string output = JsonConvert.SerializeObject(root);
/*
			 var client1 = new RestClient($"http://66.23.226.169:81/REST/sharedlinks?");
            client1.Timeout = -1;
            var request1 = new RestRequest(Method.POST);
            request1.AddHeader("Content-Type", "application/json");
            request1.AddHeader("X-Authentication", $"{authenticationToken}");
            request1.AddParameter("application/json",output,  ParameterType.RequestBody);
            IRestResponse response1 = client1.Execute(request1);
			string stres=response1.Content.Substring(14,64);
			item.Fileurl=$"http://66.23.226.169:81/REST/sharedlinks/{guid}/{stres}/content";
			*/
			}
			

			var commands = new List<Example> { account };
			return new JsonResult(commands);
		}
        }
}
