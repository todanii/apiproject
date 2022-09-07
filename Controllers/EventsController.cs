namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;
using System.Text;
using System.Text.Json;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{ 
    [HttpPost]
    public async Task<IActionResult> ProcessEvent(Event eventObject)
    {
        if(eventObject.Payload.TaskKey != "InvidemTask") 
        {
            return Ok("Invalid Task Key");
        }

        string taskId = eventObject.Payload.TaskId;
        TaskDto task = new TaskDto(taskId, true);

        string apiUrl = "http://localhost:5000/Tasks";

        using (HttpClient client=new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("api-key", "ajkshdahd211ojkasd2");

            var taskString = JsonSerializer.Serialize(task);
            var requestContent = new StringContent(taskString, Encoding.UTF8, "application/json");

            try 
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                }
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return Ok();
    }
}
