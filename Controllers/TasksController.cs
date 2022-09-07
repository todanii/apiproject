namespace WebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly ApiContext _context;
 
    public TasksController(ApiContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessTask(TaskDto taskdto)
    {
        var headers = this.Request.Headers;

        Microsoft.Extensions.Primitives.StringValues apiKeyHeader;
        if(headers.TryGetValue("api-key", out apiKeyHeader)) 
        {
            string apiKey = apiKeyHeader.FirstOrDefault();

            if(apiKey != "ajkshdahd211ojkasd2") 
            {
                return Ok("Invalid API Key");
            }
        }
        else 
        {
            return Ok("Invalid API Key");
        }

        if(!taskdto.Enable) 
        {
            return Ok();
        }

        Task task = new Task();
        task.TaskId = taskdto.TaskId;
        task.DateModified = new DateTime();

        _context.Tasks.Add(task);
        _context.SaveChanges();

        return Ok();
    }
}
