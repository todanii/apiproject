public class TaskDto
{
    public string TaskId { get; set; }
    public bool Enable { get; set; }

    public TaskDto (string taskId, bool enable) 
    {
        this.TaskId = taskId;
        this.Enable = enable;
    }
}